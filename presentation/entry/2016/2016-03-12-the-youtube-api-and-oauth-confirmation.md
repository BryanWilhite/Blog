---json
{
  "author": "Bryan Wilhite",
  "content": "I need to use the YouTube API to get the Playlist Item data associated with the subscribed Channels under my Google account. I can then take that Playlist Item data and stick it under a Songhay System API for read access without incurring YouTube quota c...",
  "inceptDate": "2016-03-12T23:07:44.515829-08:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "the-youtube-api-and-oauth-confirmation",
  "sortOrdinal": 0,
  "tag": null,
  "title": "The YouTube API and OAuth Confirmation"
}
---

I need to use the YouTube API to get the Playlist Item data associated with the subscribed Channels under my Google account. I can then take that Playlist Item data and stick it under a Songhay System API for read access without incurring YouTube quota costs.

The Playlist Item data needs to be refreshed with an Azure Web Job. This could be a problem because OAuth authentication is required for many YouTube API calls (like the call to get Channels under my account). Google surely understands this problem because most API Reference entries at developers.google.com have a “Try It!” section with a little button labelled **Execute without OAuth**.

Experimenting with this little button allows me to choose how I should approach Google APIs: when I get a 403 error, I know I need to use the full [OAuth C# stack](https://www.nuget.org/packages/Google.Apis.Auth/); when I don’t, I can use my Server API Key and an old-fashioned `HttpWebRequest`. This old-fashioned `HttpWebRequest` stuff is perfect for an Azure Web Job. And the OAuth heavy-lifting can be an infrequent or one-time thing on my Desktop with Visual Studio.

### Calling the YouTube API to Get Channel Playlist Item Data

I need to [list Playlist Item data](https://developers.google.com/youtube/v3/docs/playlists/list) by the `playlistId` associated with the Channel under my account. This can be done without OAuth with my Server API Key. The `playlistId` value comes from `contentDetails` associated with the JSON returned [listing by Channel](https://developers.google.com/youtube/v3/docs/channels/list). From a JSON.NET point of view, the search for `playlistId` looks like this:


var playlistId = jA[0]["contentDetails"]["relatedPlaylists"]["uploads"].Value&lt;string&gt;();
    

It does not matter what `jA[0]` is apart from being the first element in a JSON.NET `JArray`.

Once I have the `playlistId` I can run a nasty, out-of-fashion VSTEST like this:


[TestMethod]
[TestProperty("channelPlaylistId", "UUp4cuWZKxR5ZNbcWrP1DozA")
[TestProperty("googleServerApiKey", "XXXXXXXXX")]
[TestProperty("uriBase", "https://www.googleapis.com/youtube/v3")]
[TestProperty("uriTemplate", "playlistItems?part=snippet,contentDetails&amp;playlistId={playlistId}&amp;maxResults=10&amp;key={apiKey}")]
public void ShouldGetPlaylistItems()
{
    #region test properties:
    var channelPlaylistId = this.TestContext.Properties["channelPlaylistId"].ToString();
    var googleServerApiKey = this.TestContext.Properties["googleServerApiKey"].ToString();
    var uriBase = new Uri(this.TestContext.Properties["uriBase"].ToString(), UriKind.Absolute);
    var uriTemplate = new UriTemplate(this.TestContext.Properties["uriTemplate"].ToString());
    #endregion
    var uri = uriTemplate.BindByPosition(uriBase, channelPlaylistId, googleServerApiKey);
    this.TestContext.WriteLine("URI: {0}", uri);
    var responseString = (WebRequest.Create(uri) as HttpWebRequest).DownloadToString();
    this.TestContext.WriteLine(responseString.EscapeInterpolation());
}
    

The methods `DownloadToString()` and `EscapeInterpolation()` are my personal crap and can be disregarded (I haven’t had a chance to consider “upgrading” to `HttpClient`). The point is all of this work is being done with plain old .NET (no NuGet packages from Google).

### Calling the YouTube API to get a list of Channel IDs from my Subscriptions

None of the above is possible without a Channel ID. The quickest way I know how to get a bunch of these IDs is by reading my own subscription data. This is the part that will require OAuth so I have to run something like this in Visual Studio (using `Google.Apis`, `Google.Apis.Auth` and `Google.Apis.YouTube.v3` NuGet packages):


[TestMethod]
[TestProperty("googleClientMetadataFile", "GoogleClientMetadata.json")]
[TestProperty("googleSubscriptionsFile", "GoogleSubscriptions.json")]
[TestProperty("userName", "bryan.wilhite")]
public void ShouldGetUserSubscriptions()
{
    var projectsFolder = this.TestContext.ShouldGetProjectsFolder(this.GetType());
    #region test properties:
    var googleClientMetadataFile = this.TestContext.Properties["googleClientMetadataFile"].ToString();
    googleClientMetadataFile = Path.Combine(projectsFolder, this.GetType().Namespace, googleClientMetadataFile);
    this.TestContext.ShouldFindFile(googleClientMetadataFile);
    var googleSubscriptionsFile = this.TestContext.Properties["googleSubscriptionsFile"].ToString();
    googleSubscriptionsFile = Path.Combine(projectsFolder, this.GetType().Namespace, googleSubscriptionsFile);
    this.TestContext.ShouldFindFile(googleSubscriptionsFile);
    var userName = this.TestContext.Properties["userName"].ToString();
    #endregion
    UserCredential credential = null;
    using (var stream = new FileStream(googleClientMetadataFile, FileMode.Open, FileAccess.Read))
    {
        var apiScopes = new[] { YouTubeService.Scope.YoutubeReadonly };
        var dataStore = new FileDataStore(this.GetType().Name);
        var secrets = GoogleClientSecrets.Load(stream).Secrets;
        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, apiScopes, userName, CancellationToken.None, dataStore).Result;
    }
    Assert.IsNotNull(credential, "The expected Google User Credential is not here.");
    this.TestContext.WriteLine("Credential user ID: {0}", credential.UserId);
    this.TestContext.WriteLine("Credential token: {0}", credential.Token.AccessToken);
    Assert.AreEqual(userName, credential.UserId);
    var initializer = new BaseClientService.Initializer
    {
        ApplicationName = this.GetType().Name,
        HttpClientInitializer = credential
    };
    using (var clientService = new YouTubeService(initializer))
    {
        var request = clientService.Subscriptions.List("snippet");
        request.MaxResults = 50;
        request.Mine = true;
        var nextPageToken = string.Empty;
        var totalSubscriptions = 0;
        var subscriptionList = new List&lt;SubscriptionSnippet&gt;();
        do
        {
            request.PageToken = nextPageToken;
            var response = request.Execute();
            Assert.IsNotNull(response, "The expected List Request response is not here.");
            Assert.IsNotNull(response.Items, "The expected List Request items are not here.");
            Assert.IsTrue(response.Items.Any(), "The expected List Request items are not here.");
            totalSubscriptions += response.Items.Count;
            response.Items.ForEachInEnumerable(i =&gt;
            {
                this.TestContext.WriteLine("Subscription ID: {0}", i.Id);
                Assert.IsNotNull(i.Snippet, "The expected Snippet is not here.");
                this.TestContext.WriteLine("Channel Title: {0}", i.Snippet.Title);
                this.TestContext.WriteLine("Channel ID: {0}", i.Snippet.ChannelId);
                subscriptionList.Add(i.Snippet);
            });
            nextPageToken = response.NextPageToken;
        } while (!string.IsNullOrEmpty(nextPageToken));
        this.TestContext.WriteLine("Total Subscriptions: {0}", totalSubscriptions);
        var json = JsonConvert.SerializeObject(subscriptionList.ToArray());
        File.WriteAllText(googleSubscriptionsFile, json);
    }
}
    

The first time I run this, I notice that I am prompted by a Web browser, asking me to log into Google. Welcome to the horrors of OAuth. I often leave horrible little science experiments like this as integration tests in Visual Studio indefinitely.

After runs, a JSON file, `GoogleSubscriptions.json`, is generated. This gives me the hand-curated Channel IDs I need to run a Web Job on Azure. More on this later…
