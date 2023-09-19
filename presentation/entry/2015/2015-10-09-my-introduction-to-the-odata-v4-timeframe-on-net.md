---json
{
  "documentId": 0,
  "title": "My introduction to the OData v4 timeframe on .NET",
  "documentShortName": "2015-10-09-my-introduction-to-the-odata-v4-timeframe-on-net",
  "fileName": "index.html",
  "path": "./entry/2015-10-09-my-introduction-to-the-odata-v4-timeframe-on-net",
  "date": "2015-10-09T23:21:34.318Z",
  "modificationDate": "2015-10-09T23:21:34.318Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-10-09-my-introduction-to-the-odata-v4-timeframe-on-net",
  "tag": "{\r\n  \"extract\": \"The Microsoft OData v4 world is built on top of these NuGet packages: Microsoft.AspNet.OData, Microsoft.OData.Core and Microsoft.OData.Edm. It is far too easy to slip into an older implementation or worse to mix versions, causing the problems outlined in...\"\r\n}"
}
---

# My introduction to the OData v4 timeframe on .NET

The Microsoft OData v4 world is built on top of these NuGet packages: [Microsoft.AspNet.OData](https://www.nuget.org/packages/Microsoft.AspNet.OData/), [Microsoft.OData.Core](https://www.nuget.org/packages/Microsoft.OData.Core/) and [Microsoft.OData.Edm](https://www.nuget.org/packages/Microsoft.OData.Edm/). It is far too easy to slip into an older implementation or worse to mix versions, causing the problems outlined in “[ODataController returning HTTP 406 Not Available](http://stackoverflow.com/questions/29975653/odatacontroller-returning-http-406-not-available/29975654?stw=2).”

I have turned to [a LINQPad file (as a GitHub gist)](https://gist.github.com/BryanWilhite/25046e8d35341ea88e23) to summarize my introduction to OData v4:

```html
<script src="https://gist.github.com/BryanWilhite/25046e8d35341ea88e23.js"></script>
```

## Using OWIN Self-Hosting to test Web API

The `Microsoft.Owin.SelfHost` (with `Microsoft.Owin`, `Microsoft.AspNet.WebApi.Owin`, and `Owin`) Nuget Package gives us an in-memory, tiny server. This means server code can be tested from a .NET web server that is completely independent of IIS or IIS Express. When I attempt to show this new technology to .NET veterans, oftentimes this technology is so radically different (and just too simple) that it’s hard to understand what’s being said! It may be better to show rather than tell. The gist above shows just how simple the standard [OWIN](http://owin.org/) implementation is to use:

```cs
var baseAddress = "http://localhost:9000/";
var client = new HttpClient();
try
{
    using (WebApp.Start<Startup>(url: baseAddress))
    {
        HttpResponseMessage response;

Action<string> callOwin = path =>
        {
            response = client.GetAsync(baseAddress + path).Result;
            response.Dump();
            response.Content.ReadAsStringAsync().Result.Dump();
        };
        callOwin("api/$metadata");
        callOwin("api/Product?$count=true");
        callOwin("api/Product(2)");
        callOwin("api/Product?$filter=Category+eq+'Bakery'+and+indexof(Name,'Tortillas')+ne+-1");
    }
}
finally
{
    client.Dispose();
}
```

## OData EDM model building/routing

The single call `WebApp.Start<Startup>()` our way into OWIN. The class definition `Startup` has one, conventional method, `Configuration()`, that handles `HttpConfiguration` just like the conventional ASP.NET MVC `*Config` static classes in the `App_Start` folder. Our OData concerns for [EDM model](http://chriswoodruff.com/2011/12/04/31-days-of-odata-day-3-odata-entity-data-model/) building and routing are handled in this `Startup.Configuration()` method:

```cs
var builder = new ODataConventionModelBuilder();
builder
    .EntitySet<Product>("Product")
    .EntityType.DerivesFrom<IProduct>();
var model = builder.GetEdmModel();
config.MapODataServiceRoute("odata", "api", model);
```

The EDM model building (with the `builder` variable) uses `EntityType.DerivesFrom<>()` to tell OData that the interface `IProduct` is implemented by `Product`. The assumption here is that OData clients should work with interface types rather than server model classes for the sake of simplicity and security through obscurity. Without this builder, the standard OData `./$metadata` call would return almost nothing or not work at all.

The `MapODataServiceRoute()` extension method (of `HttpConfiguration`) makes a standard OData call, like `./api/Product?$count=true`, possible by way of the route prefix `"api"` specified in the second argument of this extension method.

## The importance of MetadataController

The `ControllerResolver` in our gist above is used in OWIN `Startup.Configuration()` to ultimately inject `ProductController` into `HttpConfiguration`. In my production ASP.NET MVC Web API application, AutoFac would handle this auto-magically. Notice also that `ControllerResolver` is ‘manually’ loading `MetadataController`. Without `MetadataController`, the `./$metadata` call would fail (it should be a 404 error).

## Extending from ODataController

The `ProductController` extends from `ODataController`. One of the not-so-subtle implications with extending from `ODataController` is the intent to emit only types defined in the `$metadata` output. So, the use of `ODataController`, means the controller is confined to emitting Entity Data models.

## Related Links

* “[Paging with ASP.NET Web API OData](http://blogs.msdn.com/b/youssefm/archive/2013/02/19/paging-with-asp-net-web-api-odata.aspx)”
* “[Supporting OData $inlinecount & json verbose with Web API OData](http://janvanderhaegen.com/2015/04/30/supporting-odata-inlinecount-json-verbose-with-web-api-odata/)”
* “[OData support in ASP.NET Web API](http://blogs.msdn.com/b/alexj/archive/2012/08/15/odata-support-in-asp-net-web-api.aspx)” [from 2012]
* “[Getting started with Web API and OData V4 Part 1](http://damienbod.com/2014/06/10/getting-started-with-web-api-and-odata-v4/)”
* “[An OData Journey in ASP.NET Web API Part 2 – Introducing Linq to Querystring](https://roysvork.wordpress.com/2013/04/09/an-odata-journey-in-asp-net-web-api-part-2-introducing-linq-to-querystring/)”
* “[I was using OData 4 (System.Web.OData) in my WebApiConfig and OData 3 (System.Web.Http.OData) in my controller. Turns out, they don](http://stackoverflow.com/questions/29975653/odatacontroller-returning-http-406-not-available/29975654?stw=2)”
* “[Create an OData v4 Endpoint Using ASP.NET Web API 2.2](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-endpoint)”
* “[Web API OData V4 Lessons Learned](http://blogs.msdn.com/b/davidhardin/archive/2014/12/17/web-api-odata-v4-pitfalls-and-lessons-learned.aspx)”
* “[Turns out, OData implements one: System.Web.OData.MetadataController, which provides for the $metadata keyword.](http://stackoverflow.com/questions/25772485/metadata-with-webapi-odata-attribute-routing-not-working/25894806?stw=2)”
* “[Typeless Entity Object Support in WebApi](http://blogs.msdn.com/b/leohu/archive/2013/11/05/typeless-entity-object-support-in-webapi.aspx)”
* “[Does ASP.NET Web API + OData filter at the database level? Let](http://weblogs.asp.net/jongalloway/does-asp-net-web-api-odata-filter-at-the-database-level-let-s-ask-intellitrace)”
* “[Open Data Protocol by Example](https://msdn.microsoft.com/en-us/library/ff478141.aspx)”
* “[How to use OData Client Code Generator to generate client-side proxy class](http://blogs.msdn.com/b/odatateam/archive/2014/03/11/how-to-use-odata-client-code-generator-to-generate-client-side-proxy-class.aspx)”
* “[ASP.Net: Web API 2 + Help Pages + OData](http://jerther.blogspot.ca/2014/11/aspnet-web-api-2-help-pages-odata_28.html)”
* “[Parsing OData Paths, $select and $expand using the ODataUriParser](http://blogs.msdn.com/b/alexj/archive/2013/05/10/parsing-odata-paths-select-and-expand-using-the-odatauriparser.aspx)”

<https://github.com/BryanWilhite/>
