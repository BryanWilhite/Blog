---json
{
  "documentId": 0,
  "title": "ASP.NET Web API Ready State (4/2017)",
  "documentShortName": "2017-04-27-asp-net-web-api-ready-state-4-2017",
  "fileName": "index.html",
  "path": "./entry/2017-04-27-asp-net-web-api-ready-state-4-2017",
  "date": "2017-04-28T00:38:01.260Z",
  "modificationDate": "2017-04-28T00:38:01.260Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-04-27-asp-net-web-api-ready-state-4-2017",
  "tag": "{\r\n  \"extract\": \"I need to record my personal satisfaction with ASP.NET Web API ‘readiness’ (as in battle-ready state), after about four years of working toward this feeling. The trigger for this emotional outburst came with understanding how claims-based security can be...\"\r\n}"
}
---

# ASP.NET Web API Ready State (4/2017)

I need to record my personal satisfaction with ASP.NET Web API ‘readiness’ (as in battle-ready state), after about four years of working toward this *feeling*. The trigger for this emotional outburst came with understanding how [claims-based security](https://msdn.microsoft.com/en-us/library/ff359101.aspx) can be used with ASP/NET Web API. Now I can make a little list of highlights for this ready state:

* Using claims-based authentication to ‘spawn’ a generic/shared user without LDAP or AD
* Sharing routes among services with an abstract `ApiController` class
* Moving legacy databases to SQL Azure
* Automated testing of API controllers with [OWIN](http://owin.org/)
* Using the `EnableCors` attribute to support Cross-Origin Resource Sharing
* Leveraging `JObject` with Web API
* Extending `DefaultContractResolver` to handle circular references in data access models
* Building a `JObject` Repository to back an API (with [Autofac](https://autofac.org/))
* `IHttpActionResult`, attribute-based routing and other ‘basics’
* My use of ‘business domain’ (`*.Foo.Models` => `*.Foo.ModelContext` and/or `*.Foo.Models` => `*.Foo.Repository`) namespaces for data access (with Autofac).

And now the punchline: All of these learnings have to migrated to ASP.NET Core. Before this great migration, I will need to write notes about each of these items to preserve my progress in these areas and prevent relearning-bottlenecks in future.

## Related Links

* “[An Introduction to Claims](https://msdn.microsoft.com/en-us/library/ff359101.aspx)”
* “[Raffaele Rialdi on Security in ASP.NET Core](https://channel9.msdn.com/Blogs/Technology-and-Friends/tf426)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
