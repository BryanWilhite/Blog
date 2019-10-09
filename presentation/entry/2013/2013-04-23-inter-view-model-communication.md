---json
{
  "documentId": 0,
  "title": "Inter-View-Model Communication",
  "documentShortName": "2013-04-23-inter-view-model-communication",
  "fileName": "index.html",
  "path": "./entry/2013-04-23-inter-view-model-communication",
  "date": "2013-04-24T00:00:00.000Z",
  "modificationDate": "2013-04-24T00:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2013-04-23-inter-view-model-communication",
  "tag": "{\r\n  \"extract\": \"Previously, I saw only one way View Models exchange data: through Light Messaging. I think I’m seeing a second way: through service-locating (Microsoft.Practices.ServiceLocation.ServiceLocator). I regard service-locating as the imperative equivalent of t...\"\r\n}"
}
---

# Inter-View-Model Communication

Previously, I saw only one way View Models exchange data: through [Light Messaging](http://tonychampion.net/blog/index.php/2010/07/messaging-in-silverlight-with-mvvm-light/). I think I’m seeing a second way: through service-locating (`Microsoft.Practices.ServiceLocation``.``ServiceLocator`). I regard service-locating as the imperative equivalent of the `Locator` static resource used in XAML declarations. With this regard, it follows that `ServiceLocator` is best for synchronous sharing of data (like getting a property value) and messaging is the choice for asynchronous sharing (service calls to the server).

The `ObjectExtensions` class that I was previously using for a certain category of MVVM Light Messaging has its members completely replaced with `ServiceLocator` routines ([see pastebin.com code listing](http://pastebin.com/adWHcVZr)). In spite of the dangers of using static classes in certain automated testing scenarios, I currently prefer to use extension methods, handling `ServiceLocator` routines. This preference confines references to `Microsoft.Practices.*` in one area of the code base.

## Related Links

* “[The Common Service Locator from Microsoft Patterns & Practices](http://www.fatagnus.com/the-common-service-locator-from-microsoft-patterns-practices/)”
* “[MVVM with Prism 101 – Part 5b: ServiceLocator vs Dependency Injection](http://www.developmentalmadness.com/archive/2009/11/02/mvvm-with-prism-101-ndash-part-5b-servicelocator-vs-depdency.aspx)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
