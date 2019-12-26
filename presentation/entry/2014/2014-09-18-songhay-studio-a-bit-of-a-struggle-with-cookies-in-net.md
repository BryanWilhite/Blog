---json
{
  "documentId": 0,
  "title": "Songhay Studio: a bit of a struggle with cookies in .NET",
  "documentShortName": "2014-09-18-songhay-studio-a-bit-of-a-struggle-with-cookies-in-net",
  "fileName": "index.html",
  "path": "./entry/2014-09-18-songhay-studio-a-bit-of-a-struggle-with-cookies-in-net",
  "date": "2014-09-18T07:00:00Z",
  "modificationDate": "2014-09-18T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-09-18-songhay-studio-a-bit-of-a-struggle-with-cookies-in-net",
  "tag": "{\r\n  \"extract\": \"I’ve finally come to terms with cookies. This, yet again, would be very, very strange and suspicion-inspiring to any dude that has worked with ASP.NET for as long as I have. They would certainly ask the question, “You have worked with ASP.NET for over 10...\"\r\n}"
}
---

# Songhay Studio: a bit of a struggle with cookies in .NET

I’ve finally come to terms with cookies. This, yet again, would be very, very strange and suspicion-inspiring to any dude that has worked with ASP.NET for as long as I have. They would certainly ask the question, “You have worked with ASP.NET for over 10 years and you’ve never used them?” My answer to this question would be quickly forgotten because it is likely to be misinterpreted as pretentious or hurtful (yes, developers are *quite* emotional).

First of all, I’ve been a Web 1.0 specialist for the longest. When I worked with classic, pre-.NET ASP at UCLA for eight years, all of the sites I worked on were read-only, document-based sites. I was key in making all UCLA hospitals go paperless by serving PDF-based policies to the nurses—no cookies needed. I was also the guy that wrote the new-employee quiz at UCLA (over 20,000 employees) that required session state, which I hand-rolled with GUIDs on SQL Server—no cookies needed.

When ASP.NET Web Forms came out, I made the “mistake” of discovering and hating the fact that this technology was not HTML compliant *for years*. This compliance is actually important when you need to treat UI like a proper data format—so XHTML is a proper XML format (and rendering XHTML allowed me to use ASP.NET HTTP handlers, .ASHX pages, to render XHTML via XML and XSLT). When I shunned ASP.NET Web Forms, I allowed the mass of Web Forms lovers to consider me an idiot because I knew nothing intimate about the technology—including its historical relationship to Cookies.

Cookies are complicated and unintuitive because they were (and probably still are) a big-ass security hole. Some guy on StackOverflow.com [says it](http://stackoverflow.com/questions/8992415/are-cookies-a-security-risk) best:

<blockquote>

Cookies can be easily modified, added and deleted by users and should be treated as untrusted user input. They are just as prone to XSS and SQL injection [vulnerabilities] as any other user input.

</blockquote>

So here’s my flippant remarks:

* When you have to use cookies use “Http-Only” cookies (use `System.Web.HttpCookie`).
* Never trust the browser to “manage” cookies (this includes Silverlight—do not use `System.Net.Cookie`—and that weird `CookieContainer`).
* Use the `System.Windows.Browser.HtmlDocument.Cookies` string to read cookies data (treat as read-only—in Silverlight you see this string in `HtmlPage.Document.Cookies`).
* Expose cookie “management” to the client through a (RESTful, JSON-based) service.

My flippant remarks above flippantly reveal that there are (at least) three different ways cookies are represented in .NET and cookies are presented as a single, delimited string or as a collection of objects (quite non-straightforward).

So here in the studio, I had to use cookies, following my own guidance. On the server side I defined `ClientCookieWrapper`. This class has a public `SetCookie()` method and a private `GetCookie()` method. The intent behind these accessors is to say, ‘Use `SetCookie()` in a service call to update/generate/delete cookies; use `GetCookie()` to fill in `ClientCookieWrapper` properties specific to the application domain. Here’s what `ClientCookieWrapper.SetCookie()` looks like:

```c#
public void SetCookie(string selected)
{
    var cookieValue = this._defaultCookieValue.Replace(":selected=", "=");
    cookieValue = cookieValue.Replace(string.Format("{0}=", selected), string.Format("{0}:selected=", selected));
    var cookie = this.GenerateCookie(cookieValue);
    HttpContext.Current.Response.Cookies.Add(cookie);
}

Now, `ClientCookieWrapper.GetCookie()`:

HttpCookie GetCookie()
{
    HttpCookie cookie = this.CurrentCookie;
    if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(this.CookieKey))
    {
        cookie = this.GenerateCookie(this._defaultCookieValue);
        HttpContext.Current.Response.Cookies.Add(cookie);
    }
    return cookie;
}

Both of these methods share this:

HttpCookie GenerateCookie(string defaultCookieValue)
{
    var expires = DateTime.UtcNow.AddDays(15);
    var cookieValue = string.Format("{0};expires={1}", defaultCookieValue, expires.ToString("R"));
    var cookie = new HttpCookie(this.CookieKey, cookieValue);
    cookie.Expires = expires;
    return cookie;
}

Finally, on the client side (which happens to be Silverlight), I can do this (with that service call I’ve not shown in this article set up):

void DoConnectionChangeCommand()
{
    if (this.ConnectionName == null) return;

    if (!HtmlPage.Document.Cookies.StartsWith(cookieKey))
                throw new NotSupportedException("The expected cookie format was not found.");

    this.DoRiaOperationSetCookie(this.ConnectionName.Name, () =>
            {
                var currentUri = HtmlPage.Document.DocumentUri;
                var location = currentUri.GetComponents(
                    UriComponents.SchemeAndServer | UriComponents.Path, UriFormat.SafeUnescaped);
                HtmlPage.Window.Navigate(new Uri(location.TrimEnd('/')), "_self");
            });
}
```

We see that `DoRiaOperationSetCookie()` will call the server and set the cookie—and when it runs successfully, it will navigate to the default page of the client.

Now, two sentences of history: In 2005 [Scott Hanselman introduces a hack](http://www.hanselman.com/blog/HttpOnlyCookiesOnASPNET11.aspx) to make cookies more secure (in the ASP.NET 1.1 timeframe). In 2008, Jeff Atwood jumps on the bandwagon in “[Protecting Your Cookies: HttpOnly](http://blog.codinghorror.com/protecting-your-cookies-httponly/).”

@[BryanWilhite](https://twitter.com/BryanWilhite)
