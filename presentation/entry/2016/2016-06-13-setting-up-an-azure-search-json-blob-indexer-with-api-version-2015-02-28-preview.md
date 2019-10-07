---json
{
  "author": "Bryan Wilhite",
  "content": "I would like to thank Microsoft’s Eugene Shvets for helping me out with setting up Azure Search for JSON blobs. What I am going to write here should be available visually in the Azure Portal soon after June 2016. I am going to share a few RESTful OData-f...",
  "inceptDate": "2016-06-13T21:42:54.1078686-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "setting-up-an-azure-search-json-blob-indexer-with-api-version-2015-02-28-preview",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Setting up an @Azure Search JSON blob Indexer with api-version=2015-02-28-Preview"
}
---

I would like to thank [Microsoft’s Eugene Shvets](https://twitter.com/chaosrealm4) for helping me out with setting up Azure Search for JSON blobs. What I am going to write here should be available *visually* in the Azure Portal soon after June 2016. I am going to share a few RESTful OData-flavored calls using an old shoe in the .NET closet called `HttpWebRequest`. To further reveal how old I am, kids, I am going to use [Visual Studio Test](https://msdn.microsoft.com/en-us/library/hh598957.aspx) (to “confuse” you) in all of my code samples.

Once we use these REST calls to get search working, we can use the Azure Portal to run test searches. This is what it looks like:
[<img alt="Azure Search of JSON Blobs" src="https://farm8.staticflickr.com/7294/26980553034_89827d84d4_z_d.jpg">](https://www.flickr.com/photos/wilhite/26980553034/in/dateposted-public/ "Azure Search of JSON Blobs")

There are three ‘components’ to get Azure search working:

*   Data Source (of type `azureblob`)
*   Index (without a default field key of `id`)
*   Indexer (with configuration parameter `useJsonParser = true`)

As of today, it is not possible to use the Azure Portal to generate an `azureblob` Data Source. It is also not possible to use the Portal to get an Indexer—and, while it *is* possible to get an Index in the Portal, it will have a default key of `id` which I cannot change in the UI. So, it’s best to make REST calls—likely the *same *calls made from the Portal.

### Learn to DELETE and GET a search ‘component’ before generating it…

I am not a Test-Driven Development type of guy but I do have opinions and I like to be as clean and neat as possible. All of these quirks drive me to mention the need to `DELETE` the things I `POST` to Azure for the need to undo any mistake I might make. So here is my “confusing” way to `DELETE`:

```c#
[TestCategory("Integration")]
[TestMethod]
[TestProperty("apiBase", "https://my-azure.search.windows.net")]
[TestProperty("apiKey", "[copy and paste from Portal]")]
[TestProperty("apiTemplate", "{componentName}/{itemName}?api-version=2015-02-28-Preview")]
[TestProperty("componentName", "indexers")]
[TestProperty("itemName", "songhayblog-indexer")]
public void ShouldDeleteAzureSearchServiceComponent()
{
    var projectRoot = this.TestContext.ShouldGetProjectsFolder(this.GetType());
    #region test properties:
    var apiBase = this.TestContext.Properties["apiBase"].ToString();
    var apiKey = this.TestContext.Properties["apiKey"].ToString();
    var apiTemplate = new UriTemplate(this.TestContext.Properties["apiTemplate"].ToString());
    var componentName = this.TestContext.Properties["componentName"].ToString();
    var itemName = this.TestContext.Properties["itemName"].ToString();
    #endregion
    var uri = apiTemplate.BindByPosition(new Uri(apiBase, UriKind.Absolute), componentName, itemName);
    this.TestContext.WriteLine("uri: {0}", uri);
    var request = ((HttpWebRequest)WebRequest.Create(uri));
    request.Method = "DELETE";
    request.Accept = MimeTypes.ApplicationJson;
    request.ContentType = MimeTypes.ApplicationJson;
    request.Headers.Add("api-key", apiKey);
    var code = request.ToHttpStatusCode();
    this.TestContext.WriteLine("HttpStatusCode: {0}", code);
    Assert.IsTrue(code == HttpStatusCode.NoContent, "The expected status code is not here.");
}
```

For details on where apiKey comes from, see “[Query your Azure Search index using the REST API](https://azure.microsoft.com/en-us/documentation/articles/search-query-rest-api/)” by Ashish Makadia. So without the .NET ceremony a `DELETE` looks like this:

```plaintext
https://my-azure.search.windows.net/{componentName}/{itemName}?api-version=2015-02-28-Preview
```

…where `componentName` represents our three ‘components’, `datasources`, `indexers` and `indexes`, and `itemName` is your name of the ‘component.’

When we change this line:

```c#
request.Method = "DELETE";
```

…to this:

```c#
request.Method = "GET";
```

Our `DELETE` changes to a `GET`—so the URI above can be used for `GET` operations to verify that our `POST `operations are working. I am sure, by the way, that `PUT` is supported here but I did not want to bother Eugene about this (see “[Azure Search Service REST](https://msdn.microsoft.com/library/azure/dn798935.aspx)”—this might be of help).

### POST of a new Azure-Blob Data Source

We have already seen that `DELETE` and `GET` operations can be shared. It should be no surprise that all of our `POST` operations are the same—the only thing that changes is the JSON “body.” In the screenshot below, I have highlighted the `json` variable—being passed to my not-required-at-all, custom extension method `WithRequestBody()`:
[<img alt="Azure Search of JSON Blobs" src="https://farm8.staticflickr.com/7561/26981648063_180d8cf85f_z_d.jpg">](https://www.flickr.com/photos/wilhite/26981648063/in/dateposted-public/ "Azure Search of JSON Blobs")

So, the important piece is not shown above is the JSON in the `POST`:

```json
{
    "name": "songhayblog-datasource",
    "type": "azureblob",
    "credentials": { "connectionString": "[copy and paste from Portal]" },
    "container": {
        "name": "songhayblog-azurewebsites-net",
        "query": "BlogEntry"
    }
}
```

For details on where `connectionString` comes from, see “[Windows Azure—Configuring Storage Accounts](https://msblogs.wordpress.com/tag/connection-string-to-azure-storage-account/)” by Biju Paulose. The rest of these JSON properties are covered by Eugene in “[Indexing Documents in Azure Blob Storage with Azure Search](https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/).”

The response from the Azure Search API looks like this:
[<img alt="Azure Search of JSON Blobs" src="https://farm8.staticflickr.com/7709/26980552954_b9ae4b65e5_z_d.jpg">](https://www.flickr.com/photos/wilhite/26980552954/in/dateposted-public/ "Azure Search of JSON Blobs")

### POST of a new Azure-Blob Index

This is the JSON payload for generating a new Index:

```json
{
    "name": "songhayblog-index",
    "fields": [
        {
            "name": "Slug",
            "type": "Edm.String",
            "key": true,
            "searchable": false
        },
        {
            "name": "Content",
            "type": "Edm.String",
            "searchable": true
        },
        {
            "name": "Title",
            "type": "Edm.String",
            "searchable": true
        }
    ]
}
```

The `fields` of this Index refer to the JSON shape that represents the `BlogEntry` object that defines the Blog entries for the Blog you are reading now:

```json
{
  "Author": "Bryan Wilhite",
  "Content": "&lt;p&gt;I would like to thank &lt;a href=\"https://twitter.com/chaosrealm4\"&gt;Microsoft’s Eugene Shvets&lt;/a&gt; for helping me [XHTML truncated]",
  "InceptDate": "2016-06-13T21:42:54.1078686-07:00",
  "IsPublished": true,
  "ItemCategory": null,
  "ModificationDate": "0001-01-01T00:00:00",
  "Slug": "setting-up-an-azure-search-json-blob-indexer-with-api-version-2015-02-28-preview",
  "SortOrdinal": 0,
  "Tag": null,
  "Title": "Setting up an @Azure Search JSON blob Indexer with api-version=2015-02-28-Preview"
}
```

### POST of a new Azure-Blob Indexer

The Indexer is what ‘fills’ the Index, starting the “crawl” of the Azure Blob Container. In the `POST` JSON payload, we see it targeting the index named above, using a schedule interval I copied from Eugene:

```json
{
    "name": "songhayblog-indexer",
    "dataSourceName": "songhayblog-datasource",
    "parameters": { "configuration": { "useJsonParser": true } },
    "targetIndexName": "songhayblog-index",
    "schedule": { "interval": "PT2H" }
}
```

### In case you care about this HttpWebRequest stuff…

My `HttpWebRequest` stuff here is not “confusing” it is more likely to be considered “old” (compared to the async-only `HttpClient`)—but experience informs me that this “old” stuff is backwards compatible. So I have made investments in a few extension methods around `HttpWebRequest` :

<script src="https://gist.github.com/BryanWilhite/b04945418a6635e754e3.js"></script>

### Related Links

*   “[Azure Search Service REST](https://msdn.microsoft.com/library/azure/dn798935.aspx)”
*   “[Indexing Documents in Azure Blob Storage with Azure Search](https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/)” by Eugene Shvets
*   “[Get started with Azure Search in the portal](https://azure.microsoft.com/en-us/documentation/articles/search-get-started-portal/)” by Heidi Steen
*   “[Query your Azure Search index using the REST API](https://azure.microsoft.com/en-us/documentation/articles/search-query-rest-api/)” by Ashish Makadia
