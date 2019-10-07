---json
{
  "author": "@BryanWilhite",
  "content": "I need to record my personal satisfaction with ASP.NET Web API ‘readiness’ (as in battle-ready state), after about four years of working toward this feeling. The trigger for this emotional outburst came with understanding how claims-based security can be...",
  "inceptDate": "2017-04-27T17:38:01.2601276-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "asp-net-web-api-ready-state-4-2017",
  "sortOrdinal": 0,
  "tag": null,
  "title": "ASP.NET Web API Ready State (4/2017)"
}
---

I need to record my personal satisfaction with ASP.NET Web API ‘readiness’ (as in battle-ready state), after about four years of working toward this *feeling*. The trigger for this emotional outburst came with understanding how [claims-based security](https://msdn.microsoft.com/en-us/library/ff359101.aspx) can be used with ASP/NET Web API. Now I can make a little list of highlights for this ready state:

*   Using claims-based authentication to ‘spawn’ a generic/shared user without LDAP or AD
*   Sharing routes among services with an abstract `ApiController` class
*   Moving legacy databases to SQL Azure
*   Automated testing of API controllers with [OWIN](http://owin.org/)
*   Using the `EnableCors` attribute to support Cross-Origin Resource Sharing
*   Leveraging `JObject` with Web API
*   Extending `DefaultContractResolver` to handle circular references in data access models
*   Building a `JObject` Repository to back an API (with [Autofac](https://autofac.org/))
*   `IHttpActionResult`, attribute-based routing and other ‘basics’
*   My use of ‘business domain’ (`*.Foo.Models` =&gt; `*.Foo.ModelContext` and/or `*.Foo.Models` =&gt; `*.Foo.Repository`) namespaces for data access (with Autofac).

And now the punchline: All of these learnings have to migrated to ASP.NET Core. Before this great migration, I will need to write notes about each of these items to preserve my progress in these areas and prevent relearning-bottlenecks in future.

## Related Links

*   “[An Introduction to Claims](https://msdn.microsoft.com/en-us/library/ff359101.aspx)”
*   “[Raffaele Rialdi on Security in ASP.NET Core](https://channel9.msdn.com/Blogs/Technology-and-Friends/tf426)”
