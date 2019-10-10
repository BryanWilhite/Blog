---json
{
  "documentId": 0,
  "title": "The Ornery Twitter API 1.1: Struggling with the Lack of Fresh Documentation",
  "documentShortName": "2013-09-16-the-ornery-twitter-api-1-1-struggling-with-the-lack-of-fresh-documentation",
  "fileName": "index.html",
  "path": "./entry/2013-09-16-the-ornery-twitter-api-1-1-struggling-with-the-lack-of-fresh-documentation",
  "date": "2013-09-16T07:00:00.000Z",
  "modificationDate": "2013-09-16T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2013-09-16-the-ornery-twitter-api-1-1-struggling-with-the-lack-of-fresh-documentation",
  "tag": "{\r\n  \"extract\": \"The abstract “personality” of Twitter matches the curt, blunt tone coming from the current “leader” of Twitter, CEO Dick Costolo in “Twitter’s CEO says a leader doesn’t care what people think and shouldn’t copy others” (by Ken Yeung). It took me a ridicu...\"\r\n}"
}
---

# The Ornery Twitter API 1.1: Struggling with the Lack of Fresh Documentation

The abstract “personality” of Twitter matches the curt, blunt tone coming from the current “leader” of Twitter, CEO Dick Costolo in “[Twitter’s CEO says a leader doesn’t care what people think and shouldn’t copy others](https://bit.ly/2M70BPX)” (by Ken Yeung). It took me a ridiculously large time to solve my problem with the Twitter API (version 1.1) because of Twitter culture not caring what I think (especially as a .NET developer).

I am not alone. Collectively, Twitter doesn’t care what Tom Scott of the [“dead” KloucheBag](http://www.tomscott.com/klouchebag/) thinks either:

<blockquote>

They’re steadily squeezing out third-party clients like Tweetbot, Echofon and Dabr, and they’re removing unauthenticated API calls. The latter means that every Twitter app, no matter how minor, will require a “Sign in with Twitter” button.

</blockquote>

What Tom is saying here is not exactly true: what he might say after a little Twitter-soul searching is every Twitter app *that matters* will require a Twitter button. You see folks my app does not matter because it is built for me, alone. I am a registered developer with Twitter. I have registered my application with Twitter—and for my troubles I was given keys and secrets that I can send to Twitter and pretty much do what I want *as long as I am working with my own Twitter account*.

So: for a .NET developer like me who make apps that don’t matter I recommend installing the NuGet Package `LinqToTwitter` and then doing a little something like this (in ASP.NET MVC space):

```c#
[HttpPost]
public ActionResult TwitterItems()
{
    var authorizer = this.GetLinqToTwitterCredentialsAndAuthorizer();
    var ctx = new TwitterContext(authorizer);
    var query = ctx.Favorites
        .Where(i => i.Type == FavoritesType.Favorites)
        .Where(i => i.Count == 50)
        .Where(i => i.IncludeEntities == true);
    var count = query.Count();
    if (count == 0) throw new TwitterQueryException("No items were found.");
    var favorites = query.ToList();
    if (favorites == null) throw new TwitterQueryException("No items were found.");
    return this.Json(favorites);
}
```

I make it look so easy after all of my unknowns are known. But I can assure you it was a ridiculously comical nightmare to get to this level of simplicity—and it is all for an app that does not really matter (because it is designed for one Twitter account—*my* account).

## Twitter Documentation ‘Misleading’

The Twitter REST API documentation should introduce itself to newbies by prioritizing “[Authentication & Authorization](https://dev.twitter.com/docs/auth).” The opinion here is that it is ‘misleading’ to visually position this subject below or next to other REST API subjects. It should be made clear that, in the 1.1 API world, you can do *nothing* unless you get authentication and authorization working. The academic subtlety of a statement like “Be sure and read about [Authentication & Authorization](https://dev.twitter.com/docs/auth)” does not suggest that it is a prerequisite instead of an optional detail.

Once a Twitter application is defined I suggest starting with cURL by selecting the OAuth Tool for the application and press the **See OAuth signature for this request** button. Greg Williams details this in “[Using Twitter’s OAuth Tool](http://greglib.org/using-twitters-oauth-tool/).” From my Ubuntu command line, we have verification that Twitter is working with your account:

```console
curl --get 'https://api.twitter.com/1.1/favorites/list.json' --data 'count=2&screen_name=BryanWilhite' --header 'Authorization: OAuth oauth_consumer_key="[your key]", oauth_nonce="[nonce]", oauth_signature="[signature]", oauth_signature_method="HMAC-SHA1", oauth_timestamp="1373088858", oauth_token="[token]", oauth_version="1.0"' –verbose
```

This cURL statement is altered from the one provided by Twitter as it is retrieving just two of my Favorites from my account with get operation, `--get 'https://api.twitter.com/1.1/favorites/list.json'`, with data parameter, `--data 'count=2&screen_name=BryanWilhite'`. The rest of the cURL statement comes from Twitter.

This cURL command represents a request for a Twitter app that ‘does not matter’—it represents what Twitter calls an “[application-only auth](https://dev.twitter.com/docs/auth/application-only-auth)” request opposed to an “[OAuth signed](https://dev.twitter.com/docs/auth/obtaining-access-tokens)” request. But this classification feels ‘misleading’ to me because both requests use OAuth—right? No?

## “Authorizers” in LinqToTwitter

Most of the ‘comical’ misery with Twitter comes in generating the Authorization header. You can literally see this by measuring how much our cURL command above is dominated by authorization data. In the world of `LinqToTwitter`, the ‘seed’ that generates the header is the *authorizer*.

It took me months to find that the authorizer for my limited needs is the `SingleUserAuthorizer` (which should be called—according to Twitter documentation—“application-only-authorizer”?) From my ASP.NET MVC example above we have:

```c#
ITwitterAuthorizer GetLinqToTwitterCredentialsAndAuthorizer()
{
    var data = new OpenAuthorizationData(ConfigurationManager.AppSettings);
    var authorizer = new SingleUserAuthorizer
    {
        Credentials = new InMemoryCredentials
        {
            ConsumerKey = data.ConsumerKey,
            ConsumerSecret = data.ConsumerSecret,
            OAuthToken = data.Token,
            AccessToken = data.TokenSecret
        },
    };
    return authorizer;
}
```

The `OpenAuthorizationData` instance is of a little housekeeping class I use to clearly define my keys and secrets.

## Related Links

<table class="WordWalkingStickTable"><tr><td>
“[How to get tweet’s HTML with LinqToTwitter?](http://stackoverflow.com/questions/7855347/how-to-get-tweets-html-with-linqtotwitter)”
</td><td>
I will need something like `TwitterExtensions` for a WPF version of my little project.
</td></tr><tr><td>
“[How to get HTML instead of plain text (Status.Text)](http://linqtotwitter.codeplex.com/discussions/449076)”
</td><td>
“There’s an `Entities` property that contains metadata for various parts of a tweet, including the Start and End character positions. One of those is `UrlEntities`, which you can use to determine where the URLs are in the tweet. With that, you can write code to arrange the entities and work backwards through the tweet to transform the text into HTML.”
</td></tr><tr><td>
“[Implementing Single User Authorization](https://linqtotwitter.codeplex.com/wikipage?title=Single User Authorization)”
</td><td>
“The `SingleUserAuthorizer` allows you to fill in all of your credentials at one time, bypassing the user-centric authorization process. It's designed for application-only operations…”
</td></tr><tr><td>
“[How do I tweet, using the DotNetOpenAuth library?](http://stackoverflow.com/questions/2141251/how-do-i-tweet-using-the-dotnetopenauth-library)”
</td><td>
“…it would probably be much easier for you to download `LinqToTwitter`, which uses `DotNetOpenAuth` and offers an extensive Twitter library to do most/all the operations Twitter supports.”
</td></tr><tr><td>
“[TwitterConsumer.cs](https://github.com/DotNetOpenAuth/DotNetOpenAuth/blob/master/samples/DotNetOpenAuth.ApplicationBlock/OAuth1/TwitterConsumer.cs)”
</td><td>
I tried and failed to get something like this working on a Windows Azure Websites server (see also: “[2-legged OAuth with DotNetOpenAuth and Twitter. Getting a 401 error](http://stackoverflow.com/questions/15883368/2-legged-oauth-with-dotnetopenauth-and-twitter-getting-a-401-error)”).
</td></tr><tr><td>
“[Two tastes better together: Combining OpenID and OAuth with OpenID Connect](http://factoryjoe.com/blog/2010/05/16/combing-openid-and-oauth-with-openid-connect/)”
</td><td>
“OpenID, by design, favors the user rather than the relying party. In contrast, technologies like Facebook and Twitter Connect emphasize the benefits to relying parties. So while it might seem like an inconvenience to custom-tailor your personal privacy settings on Facebook, the liberal defaults are meant to make Facebook users’ accounts more valuable to relying parties than other, more privacy-preserving account configurations.”
</td></tr><tr><td>
“[Managing session state in Windows Azure: What are the options?](https://www.simple-talk.com/cloud/platform-as-a-service/managing-session-state-in-windows-azure-what-are-the-options/)”
</td><td>
When I was ignorant of the usefulness of `LinqToTwitter` and `SingleUserAuthorizer`, I assumed that I needed Session State support on Windows Azure to properly handle Twitter authentication and authorization. I thought that manually logging in to Twitter was the *only *way to access the REST API.
</td></tr><tr><td>
“[How to maintain session state in Window Azure](http://www.arunrana.net/2011/12/how-to-maintain-session-state-in-window.html)”
</td><td>
It turns out that I was quite pleased with my success with implementing session state with `TableStorageSessionStateProvider`. So this digression from my Twitter problems should pay off later.
</td></tr><tr><td>
“[Session State Provider for Windows Azure Cache](http://msdn.microsoft.com/en-us/library/windowsazure/gg185668.aspx)”
</td><td>
Table Storage worked for me: I do not recall getting this cache-based stuff up and running (see also: “[Introducing Windows Azure Caching](http://www.dotnetcurry.com/ShowArticle.aspx?ID=865)”).
</td></tr><tr><td>
“[Implementing OAuth for MVC Applications](http://linqtotwitter.codeplex.com/wikipage?title=Implementing OAuth for ASP.NET MVC&referringTitle=Learning to use OAuth)”
</td><td>
Even though this documentation is from `LinqToTwitter` people it was total fail for me. I assume that I could not get it to work because I am running MVC on Windows Azure.
</td></tr><tr><td>
“[Getting Twitter Access Secret using DotNetOpenAuth in MVC4](http://stackoverflow.com/questions/12198734/getting-twitter-access-secret-using-dotnetopenauth-in-mvc4)”
</td><td>
For a very large time I assumed that I could get things to working solely with `DotNetOpenAuth`. Nope. By the way, there is no official answer to this StackOverflow.com question. Also: it was this question that really helped me to distinguish between *authentication* and *authorization*: “The `DotNetOpenAuth.AspNet.Clients.TwitterClient` class only allows authentication, not authorization. So you wouldn't be able to post tweets as that user if you use that class. Instead, you can use `DotNetOpenAuth.ApplicationBlock.TwitterConsumer` [[http://nuget.org/packages/DotNetOpenAuth.ApplicationBlock](http://nuget.org/packages/DotNetOpenAuth.ApplicationBlock)], which does not share this limitation and you can even copy the source code for this type into your application and extend it as necessary.”
</td></tr><tr><td>
“[DotNetOpenAuth.AspNet Twitter,Facebook,Google,Microsoft,LinkedIn Authentication](https://coderwall.com/p/j9essg)”
</td><td>
I could not get this example to work on Windows Azure. I kept getting that 401 unauthorized error. This may be the right to mention that Twitter folk should save detailed error messages for developers available for viewing on dev.twitter.com.
</td></tr><tr><td>
“[OAuth with Verification in .NET](http://stackoverflow.com/questions/4002847/oauth-with-verification-in-net)”
</td><td>
“I agree with you. The open-source OAuth support classes available for .NET apps are hard to understand, overly complicated (how many methods are exposed by `DotNetOpenAuth`?), poorly designed (look at the methods with 10 string parameters in the `OAuthBase.cs` module from that google link you provided—there’s no state management at all), or otherwise unsatisfactory.”
</td></tr><tr><td>
“[How to Connect in Twitter API Using PHP](http://ronzohan.blogspot.com/2013/01/how-to-connect-in-twitter-using-php.html)”
</td><td>
Okay here is the punch line: the PHP code in this article modified slightly for my Windows Azure Websites server ran flawlessly. No problems whatsoever!
</td></tr><tr><td>
“[Multi-service Authentication the Easy Way](http://netitude.bc3tech.net/2013/02/22/multi-service-authentication-the-easy-way/)”

“[Enabling Twitter OAuth For An Azure Mobile Service (Zumo) in a Windows 8 Game](http://www.dotnetcurry.com/ShowArticle.aspx?ID=860)”
</td><td>
A bunch of Windows 8 and Windows Azure links related to OAuth.
</td></tr><tr><td>
“[Parsing Twitter Usernames, Hashtags and URLs with JavaScript](http://www.simonwhatley.co.uk/parsing-twitter-usernames-hashtags-and-urls-with-javascript)”
</td><td>
I am using these techniques for the MVC version of my little app.
</td></tr></table>

@[BryanWilhite](https://twitter.com/BryanWilhite)
