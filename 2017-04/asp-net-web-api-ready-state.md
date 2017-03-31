<h2>ASP.NET Web API Ready State</h2>

I need to record my personal satisfaction with ASP.NET Web API ‘readiness’ (as in battle-ready state), after about four years of working toward this _feeling_. The trigger for this emotional outburst came with understanding how [claims-based security](https://msdn.microsoft.com/en-us/library/ff359101.aspx) can be used with ASP/NET Web API. Now I can make a little list of highlights for this ready state:

* Using claims-based authentication to ‘spawn’ a generic/shared user without LDAP or AD
* Sharing routes among services with an abstract `ApiController` class
* Moving legacy databases to SQL Azure
* Automated testing of API controllers with [OWIN](http://owin.org/)
* Using the `EnableCors` attribute to support Cross-Origin Resource Sharing
* Leveraging `JObject` with Web API
* Extending `DefaultContractResolver` to handle circular references in data access models
* Building a `JObject` Repository to back an API (with AutoFac)
* `IHttpActionResult`, attribute-based routing and other ‘basics’
* My use of ‘model context’ namespaces for data access.

And now the punchline: All of these learnings have to migrated to ASP.NET Core.

<h3>Related Links</h3>

* “[An Introduction to Claims](https://msdn.microsoft.com/en-us/library/ff359101.aspx)”
* “[Raffaele Rialdi on Security in ASP.NET Core](https://channel9.msdn.com/Blogs/Technology-and-Friends/tf426)”