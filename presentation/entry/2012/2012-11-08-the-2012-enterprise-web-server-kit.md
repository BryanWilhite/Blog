---json
{
  "documentId": 0,
  "title": "The 2012 Enterprise Web Server Kit",
  "documentShortName": "2012-11-08-the-2012-enterprise-web-server-kit",
  "fileName": "index.html",
  "path": "./entry/2012-11-08-the-2012-enterprise-web-server-kit",
  "date": "2012-11-09T00:00:00Z",
  "modificationDate": "2012-11-09T00:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-11-08-the-2012-enterprise-web-server-kit",
  "tag": "{\r\n  \"extract\": \"This represents my contemporary understanding of lower-middle-class, Microsoft Web server building for the enterprise. So we’re still not talking about building a solution that’s performance-enhanced for one million hits per minute but we are still quite...\"\r\n}"
}
---

# The 2012 Enterprise Web Server Kit

This represents my contemporary understanding of lower-middle-class, Microsoft Web server building for the enterprise. So we’re still not talking about building a solution that’s performance-enhanced for one million hits per minute but we are still quite serious.

Here are some design goals:

* For maintainability, use NuGet packages to install all third-party libraries. Be willing to sacrifice convenience *for the convenience of NuGet*—this means that I am very, very reluctant to install some third-party stuff that is *not* in a NuGet package.
* Prefer third-party, server-based solutions that come from the Java world. This is me trying to be totally political/psychological as most authority figures are willing to green-light an “unknown” like Log4Net because it’s “just a port” from Log4J.
* Bias for ‘smart defaults’ instead of complex customizations. Complex/intimate customizations tend to cause complex/intimate problems during deployment/maintenance—so I prefer to stay in defaults to allow others (who cannot really care as much) move my code around without worrying about brittle parts falling off.

## We need ELMAH because we are not perfect.

Should someone ever ask me, “What is the one NuGet package you cannot develop on a .NET web server without? ...,” my answer is ELMAH. It took me a while to come around—years after [Scott Hanselman’s famous 2009 article](http://www.hanselman.com/blog/ELMAHErrorLoggingModulesAndHandlersForASPNETAndMVCToo.aspx). The most import thing that ELMAH gives is professional handling of *unhandled* exceptions *by default*. ELMAH is the way developers can show genuine affection to “operations” (the people who maintain/support applications after they are developed). It is a way to communicate that developers actually care what happens to their work once it goes into the wild.

So because of this warm, fuzzy ELMAH security blanket, I was inspired to write something like this:

```cs
IOrderedQueryable<Segment> segments = null;
try
{
    segments = GenericWebContext.GetTopSegments();
}
catch(AggregateException aex)
{
    foreach(var ex in aex.Flatten().InnerExceptions)
    {
        if(HttpContext.Current != null)
            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
    }
}
catch(Exception ex)
{
    if(HttpContext.Current != null)
        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
}
return segments;
```

All because of ELMAH, the following programmer intents are implied:

* Web clients should be dumb about exceptions (they can be *rich* clients but still dumb). The most they should handle is `null`.
* When any exception detail is shown on a Client—this implies that the developer has a bug that the developer should be very, very ashamed of… Friendly, generic error messages on the client side (shown in the branding of the company) imply that the developer is in control and all is well in the Shire.
* When a client is getting the mysterious null, the operations team needs to run to ELMAH to figure out what *really* happened.
* By default, finding out what really happened can only be done from the `localhost` of the Web Server where it happened—which makes security-conscious operations people smile with Remote-Desktop-addiction joy.

Note that ELMAH works in `HttpContext.Current` this may suggest that another logging solution is needed for stuff happening outside of HTTP Context. This implementation detail happens to lead to the next item in my kit…

<table class="WordWalkingStickTable"><tr><td>

Related Links:

</td></tr><tr><td>

“[Logging Errors with ELMAH in ASP.NET MVC 3](http://joel.net/logging-errors-with-elmah-in-asp.net-mvc-3--part-1--setup)”

</td><td>

Introductory article…

</td></tr><tr><td>

“[How to get ELMAH to work with ASP.NET MVC [HandleError] attribute?](http://stackoverflow.com/questions/766610/how-to-get-elmah-to-work-with-asp-net-mvc-handleerror-attribute)”

</td><td>

```cs
protected override void OnException(ExceptionContext filterContext)
{
    base.OnException(filterContext);
    if (!filterContext.ExceptionHandled) return;
    var httpContext = filterContext.HttpContext.ApplicationInstance.Context;
    var signal = ErrorSignal.FromContext(httpContext);
    signal.Raise(filterContext.Exception, httpContext);
}
```

</td></tr><tr><td>

“[ASP.NET MVC HandleError Attribute, Custom Error Pages and Logging Exceptions](http://blog.dantup.com/2009/04/aspnet-mvc-handleerror-attribute-custom.html)”

</td><td>

“The `System.Web.Mvc.Controller` class contains a method called `OnException` which is called whenever an exception [occurs] within an action. This does not rely on the `HandleError` attribute being set. If you’re being a good coder and have your own base Controller class you can override this method in one place to handle/log all errors for your site.”

</td></tr><tr><td>

“[ELMAH with Windows Azure Table Storage](http://nuget.org/packages/WindowsAzure.ELMAH.Tables)”

</td><td>

Wade Wenger’s NuGet package is awesome! Supporting research below…

</td></tr><tr><td>

“[Extending ELMAH on Windows Azure Table Storage](http://libertycode.org/post/28377288184/extending-elmah-on-windows-azure-table-storage)”

</td><td>

“…This is because the Table Storage Service limits the size of any string value property to 64KB. When you further examine the `ErrorEntity` class, you will find that this is actually quite easy to accomplish with exceptions that have large stack traces. A little examination reveals that the error caught by ELMAH is encoded to an XML string and saved to the `SerializedError` property.”

</td></tr><tr><td>

“[Using ELMAH in Windows Azure with Table Storage](http://www.wadewegner.com/2011/08/using-elmah-in-windows-azure-with-table-storage/)”

</td><td>

“…The great part is that these files are getting serialized into Windows Azure table storage. The benefit of this is you can read them from anywhere—in fact, you don’t have to even deploy the `elmah.axd` handler with your web application! You could run it locally.”

</td></tr><tr><td>

“[ElmahR = ELMAH + SignalR](http://www.codeproject.com/Articles/377394/ElmahR-equals-ELMAH-plus-SignalR)”

</td><td>

Novel… haven’t had the time to try this…

</td></tr></table>

## Once you commit to Quartz.net then just use Log4Net.

[Log4Net](https://nuget.org/packages/log4net) is one of those solutions from the Java world. This is your ELMAH-like coverage, outside of HTTP context. You get Log4Net by default when you choose another Java-world veteran, [Quartz.net](https://nuget.org/packages/Quartz). I was mistakenly led into using Quartz.net from a Web application domain/pool. But [this quote](http://groups.google.com/group/quartznet/browse_thread/thread/da953a9e5820fca7) shows the error of my way:

<blockquote>

If you place your initialization of Quartz.NET to `Application_Start` event in `Global.asax` it should be checked whenever application is restarted. Of course this event will be raised _after_ the first request to your application which could mean that on low traffic site the Quartz.NET might not be initialized even daily.

</blockquote>

Here are [more discouraging words](http://stackoverflow.com/questions/2870562/pros-and-cons-of-running-quartz-net-embedded-or-as-a-windows-service) to keep you from using Quartz.net in a Web application:

<blockquote>

The main concern is to the application pool handling prior to IIS 7.5. Without constant checks your application worker can get recycled and your scheduler will be down until someone issues a web request to fire up the application pool again. IIS 7.5 has the new feature to keep application pools running all the time.

</blockquote>

I need Quartz.net when I need to run “back-end” jobs, automatically—according to a schedule—, instead of manually at the command line. Quartz.net suddenly becomes important and necessary when we realize that a job we might run from SQL Server Agent (like an [SSIS](http://msdn.microsoft.com/en-us/library/ms141026.aspx) package) is not unit-testable and over time very difficult to maintain. Switching to Quartz.net allows us to schedule jobs made of testable .NET code. Quartz.net (or another competitive solution) gets my technical plans out of the 2005/2008 timeframe.

## Use a strongly-typed wrapper for ConfigurationManager.AppSettings values.

There is a way to get strongly-typed objects directly from `web.config` (see “[How to: Create Custom Configuration Sections Using IConfigurationSectionHandler](http://msdn.microsoft.com/en-us/library/ms228056.aspx)”) but the technique recommended here *feels* faster and easier to understand: in the `MyApp.Models` namespace/project, I define an `ApplicationSettings` class with a constructor like this:

```cs
public ApplicationSettings()
{
    var appSettings = ConfigurationManager.AppSettings;
    var appSettingsKeys = appSettings.Keys.OfType<string>();
    var key = "LatitudeLongitudeForCenturyCity";
    if (appSettingsKeys.Contains(key))
        this.LatitudeLongitudeForCenturyCity = new LatitudeLongitude(appSettings[key]);
    key = "RemoteDocumentRequestInSeconds";
    if (appSettingsKeys.Contains(key))
        this.RemoteDocumentRequestInSeconds = Convert.ToInt32(appSettings[key]);
    key = "UriForNoaaWeather";
    if (appSettingsKeys.Contains(key))
        this.UriForNoaaWeather = new Uri(appSettings[key], UriKind.Absolute);
}
```

Remember that `ConfigurationManager.AppSettings` is not just for Web applications.

## ASP.NET MVC: Use an MVC4 project because it’s NuGet-centric…

At the beginning of this year in “[ASP.NET MVC 4 Beta Released!](http://weblogs.asp.net/jgalloway/archive/2012/02/16/asp-net-4-beta-released.aspx),” Jon Galloway was celebrating:

<blockquote>

When you create a new ASP.NET MVC 4 project, you’ll notice that a bunch of NuGet packages are being installed. That’s because the project template heavily leverages the NuGet package restore feature—in fact, even [ASP.NET MVC 4 is a NuGet package](http://nuget.org/packages/AspNetMvc).

</blockquote>

My experience with Debian/Linux package manager culture encourages me to be excited about NuGet packages. And then there is this thing called [Chocolat](http://chocolatey.org/)…

<table class="WordWalkingStickTable"><tr><td>

Related Links:

</td></tr><tr><td>

“[Deploying ASP.NET MVC to IIS 6](http://blog.stevensanderson.com/2008/07/04/options-for-deploying-aspnet-mvc-to-iis-6/)”

</td><td>

Horrible but not impossible. I prefer “Option 2: Put .aspx in all your route entries’ URL patterns”… I’ve confused myself by forgetting to [enable ASP.NET in IIS](http://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/44f16c37-f727-4244-9813-2289e13dadba.mspx?mfr=true) and not giving the `IIS_User` and `NETWORK SERVICE` users proper permissions (see below).

</td></tr><tr><td>

“[InfoWorker Solutions: IIS6: App-Domain could not be created](http://kjellsj.blogspot.com/2007/09/iis6-app-domain-could-not-be-created.html)”

</td><td>

“The cause of the problem is that the identity (e.g. NETWORK SERVICE) of the IIS application pool used to run the web application, needs read access to the application’s `web.config` file to be able to launch the ASP.NET worker process.”

</td></tr></table>

## ASP.NET MVC: Use `HttpContext.Current.IsDebuggingEnabled`…

“[Automatically minify and combine JavaScript in Visual Studio](http://encosia.com/automatically-minify-and-combine-javascript-in-visual-studio/)” by Dave Ward introduced me to the importance of `HttpContext.Current.IsDebuggingEnabled`:

<blockquote>

When the web.config’s compilation mode is set to debug, the `*.debug.js` versions of the files are referenced, and the auto-minified bundle otherwise. Now we have the best of both worlds.

</blockquote>

I use this approach in my conventional MVC `/Shared/_Layout.cshtml` (see it [on pastebin.com](http://pastebin.com/wmX1XLLz)).

## ASP.NET MVC: Avoid Using the Models Folder

I have yet to find a self-propelled reason why I need a `/Models` folder in a Web Project. This means you will never find a `MyAwesomeApp.Web.Models` namespace (so far). My respect for unit testing and code reuse compels me to have:

* A `MyAwesomeApp.Models` namespace, defining the *passive* data classes of the `MyAwesomeApp` domain.
* A `MyAwesomeApp.ModelContext` namespace, defining the *active* use of the passive models in the `MyAwesomeApp` domain.

The concept of a Model Context is definitely not a Rocky Lhotka thing. He might use a term like “Business Rules Context”—so my work here is not backed by the recognized experts. I should have covered this in “[RIA Services and EF Entities](http://songhayblog.azurewebsites.net/entry/show/ria-services-and-ef-entities)” or “[Silverlight, Entity Framework and RIA Services Recipe](http://songhayblog.azurewebsites.net/entry/show/silverlight-entity-framework-and-ria-services-recipe)” but I didn’t. More on this later (I think)…

## While looking for a replacement to RIA Services, use RIA Services…

My limited research shows me two possible alternatives to RIA Services: i) some rendition of Rocky Lhotka’s CSLA or ii) some future version of or NuGet package for ASP.NET Web API. Since Rocky is awesome [he addressed this issue](http://forums.lhotka.net/forums/p/8394/39951.aspx) about two years ago:

<blockquote>

Regarding RIA Services, I’m an advisor to that product group. It is true that they are building something that is architecturally similar to CSLA, though there are some very real implementation differences (some good, some maybe not).

In 2010 we’ll probably see their v1 release, which will be (imo) a pretty fair prototype. Like most products, it won’t be until v2 or v3 that it is really ready for widespread use. So in 2012 or 2014 I rather suspect RIA Services will really rock.

Their scope is both smaller and larger than CSLA. It is smaller, in that they do Silverlight, and a little web, while CSLA does every interface technology in .NET (including non-interactive ones like workflow). Their scope is larger in that they have integration into Visual Studio and other Microsoft tools/products that are not realistic for a one-man open source project like CSLA.

</blockquote>

Today in my ASP.NET MVC projects I have a /Services folder where I expose my RIA Services. I prefer RIA services because I can use them with Silverlight and jQuery. There are UI controls from Telerik and Microsoft that exploit RIA conventions. I cover my RIA issues in detail in “[RIA Services and EF Entities](http://songhayblog.azurewebsites.net/entry/show/ria-services-and-ef-entities)” and “[Silverlight, Entity Framework and RIA Services Recipe](http://songhayblog.azurewebsites.net/entry/show/silverlight-entity-framework-and-ria-services-recipe).”

<table class="WordWalkingStickTable"><tr><td>

Related Links:

</td></tr><tr><td>

“[Paging with the Silverlight RIA services DomainDataSource](http://msmvps.com/blogs/theproblemsolver/archive/2009/04/27/paging-with-the-silverlight-ria-services-domaindatasource.aspx)”

</td><td>

“…Another thing you can specify is the `LoadSize`. This determines how many rows are loaded with each request and if not set equals the `PageSize`. Setting this to double the `PageSize` will improve the responsiveness of the client application so might be a good idea if the data isn’t too large.”

</td></tr><tr><td>

“[WCF RIA Services Toolkit (August 2011)—And Updated NuGet Packages](http://jeffhandley.com/archive/2011/08/02/ToolkitAugust2011.aspx)”

</td><td>

Jeff Handley’s 2011 overview of the RIA NuGet packages…

</td></tr><tr><td>

“[RIA Services and Validation](http://www.nikhilk.net/RIA-Services-Validation.aspx)”

</td><td>

Nikhil Kothari’s introduction to RIA validation…

</td></tr><tr><td>

“[Installing RIA Services on a server](http://blogs.msdn.com/b/deepm/archive/2010/03/15/are-you-a-hoster-and-want-to-support-ria-services.aspx)”

</td><td>

“…The RIAServices msi now has a command line override, especially for hosters. The msi is now configured to take a ‘Server’ command line parameter that will only check for .NET Framework 4.0. The command line parameter will install all the RIA Services server assemblies. …Here is how to use this option:”

* “Download the RIA Services MSI and save it on your machine”
* “Open up a command prompt and type the following command: `msiexec /i RIAServices.msi SERVER=true`”

See also: “[Deploying Application built using RIA Services RC](http://blogs.msdn.com/b/saurabh/archive/2010/03/16/ria-services-application-deployment.aspx)”

</td></tr><tr><td>

“[RIA Services Inheritence error](http://stackoverflow.com/questions/8247583/ria-services-inheritence-error)”

</td><td>

“Only one complex type in an inheritance hierarchy can be exposed from a domain service.”

</td></tr><tr><td>

“[RIA Services and multiple/dynamic ‘Include’ strategies](http://stackoverflow.com/questions/2718570/ria-services-and-multiple-dynamic-include-strategies)”

</td><td>

“Include in a RIA sense has a different meaning than Include in an EF sense. In EF it means ‘include when retrieving from the database’; in RIA it means ‘include when serializing for the client’.”

</td></tr><tr><td>

“[WCF RIA Services—‘Not Found’ Error Message](http://blogs.objectsharp.com/post/2010/04/13/WCF-RIA-Services-“Not-Found”-Error-Message.aspx)”

</td><td>

“…needed this because of ‘The exception message is: Unable to load one or more of the requested types. Retrieve the `LoaderExceptions` property for more information’ error.... turns out I was using EF5.x with RIA Services so EF entities could not load with RIA...”

</td></tr></table>

@[BryanWilhite](https://twitter.com/BryanWilhite)
