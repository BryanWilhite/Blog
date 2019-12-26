---json
{
  "documentId": 0,
  "title": "RIA Services and EF Entities",
  "documentShortName": "2012-08-13-ria-services-and-ef-entities",
  "fileName": "index.html",
  "path": "./entry/2012-08-13-ria-services-and-ef-entities",
  "date": "2012-08-13T23:10:00Z",
  "modificationDate": "2012-08-13T23:10:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-08-13-ria-services-and-ef-entities",
  "tag": "{\r\n  \"extract\": \"Currently, my preferred technical plan for Data Access depends on using RIA Services and Entity Framework (EF). This decision promises to lead me to a design that allows me to build Web services (for that SOA buzzword-ism) and have bright and clear data ...\"\r\n}"
}
---

# RIA Services and EF Entities

[<img alt="Amazon.com product" src="http://kintespace.com/bitmaps/blog_ef4_dbcontext_book.jpg" style="float:right;margin:16px;">](http://www.amazon.com/exec/obidos/ASIN/1449312969/thekintespacec00A/ "Buy this product at Amazon.com!")

Currently, my *preferred* technical plan for Data Access depends on using RIA Services and Entity Framework (EF). This decision promises to lead me to a design that allows me to build Web services (for that SOA buzzword-ism) and have bright and clear data access patterns for Silverlight, “Metro” UI and HTML clients. In the recently-made-ancient Silverlight world, using the `DataForm` and RIA Services with EF entities gives me a modern, scalable equivalent to the classic design experience that made Microsoft Access world famous in the 1990s. My decision to use ASP.NET MVC/RIA Services/EF is also my 21<sup>st</sup>-century update to the ASP/<acronym title="Extensible Stylesheet Language Transformations">XSLT</acronym> Data Access stack I built in the 1990s. To mark the calendar correctly, I need to remind myself that RIA Services was announced in 2009—and like Silverlight—it matters little to me that the term “RIA Services” might be considered “dead” right about now—even to Nikhil Kothari himself.
[<img alt="Amazon.com product" src="http://kintespace.com/bitmaps/blog_ef4_book.jpg" style="float:left;margin:16px;">](http://www.amazon.com/exec/obidos/ASIN/0596807260/thekintespacec00A/ "Buy this product at Amazon.com!")

What is important is that the patterns, practices and design-time/maintenance expectations surrounding this technology will live longer than the technology itself. In the same manner that I looked for a technical/practical equivalent (or superior) to Microsoft Access, I will look for the same with regard to RIA Services ([Web API](http://www.asp.net/web-api)?). This implies that I should “never be happy” with any technology, keeping a critical eye on what’s desired for v-next. In keeping with such healthy criticism, these notes go into a few bits about my current relations with RIA Services/EF:

## RIA Services is not “dead” just because the brand name “Silverlight” is no longer premier.

Here’s a bottom line: there’s a RIA services framework for JavaScript. (See “[RIA/JS—jQuery client for WCF RIA Services](http://jeffhandley.com/archive/2011/04/13/RIAJS-jQuery-client-for-WCF-RIA-Services.aspx)”.) This implies that that RIA Services is giving developer’s something they need and it is not locked in the world of Silverlight. Lenni Lobel in “[WCF Data Services vs. WCF RIA Services–Making the Right Choice](http://blog.tallan.com/2012/02/19/wcf-data-services-vs-wcf-ria-services-–-making-the-right-choice/)” makes a great opening argument:

<blockquote>

The answer extends a bit beyond the standard “it depends on your scenario” response, since WCF RIA Services offers a lot more than just data access functionality. It also features client-side self-tracking entities, client-side validation, automatic server-to-client code generation, and more.

</blockquote>

I’ll be looking for similar client-side greatness for the hot, new ASP.NET Web API—and even on the server side, I need to see an implementation (or a superior replacement) of what Microsoft calls a “[Domain Service](http://msdn.microsoft.com/en-us/library/ee707373(v=VS.91).aspx)”:

<blockquote>

Domain services are Windows Communication Foundation (WCF) services that encapsulate the business logic of a WCF RIA Services application. A domain service exposes a set of related operations in the form of a service layer. When you define a domain service, you specify the data operations that are permitted through the domain service.

</blockquote>

So a future question coming from me might be, ‘How does ASP.NET Web API eliminate or incorporate the need for a Domain Service?’ Here’s [a quote](http://forums.silverlight.net/p/245432/613499.aspx/1?WCF+Web+API+vs+RIA+Services+Endpoints+JSON+SOAP+OData+) from a Silverlight forums, all-star Colin Blair:

<blockquote>

In general, it is important to keep in mind that there is a single WCF team at Microsoft. WCF Web API, WCF RIA Services, and WCF Data Services are all interrelated technologies. What you are seeing in WCF Web API is a new iteration of the base WCF technology itself and it has been built using what was learned in WCF Data Services and WCF RIA Services. So, you are seeing some overlap there because some of what you see in WCF RIA Services V1 has migrated into WCF Web API.

What I expect to see is a WCF RIA Services V2 built using the WCF Web API but that is not going to happen until the WCF Web API is completed and it is currently still in preview. My recommendation is to stick with what you are currently doing, don't try to jump ahead of the WCF team.

</blockquote>

## Using RIA Services with EF drags EF behind the current version.

The Entity Framework Team is working faster than Nikhil Kothari can have spare time for projects other than [Windows-Azure-related tasks](http://www.nikhilk.net/NewWindowsAzure.aspx). Nikhil certainly works faster than me! My effort to write what’s written here means I’ve caught up with him back in 2010! …so there’s this NuGet package, `RIAServices.EntityFramework`, that requires `EntityFramework` 4.1.10715.0. As of this writing, we have the latest Entity Framework 4.3.1.

## By default, an EF Entity cannot be a property of another object.

Somewhere between these two articles, “[Composition Support in RIA Services](http://blogs.msdn.com/b/digital_ruminations/archive/2009/11/18/composition-support-in-ria-services.aspx)” and “[Associations in EF Code First CTP5: Part 1—Complex Types](http://weblogs.asp.net/manavi/archive/2010/12/11/entity-association-mapping-with-code-first-part-1-one-to-one-associations.aspx),” my fuzziness around the complex type (or Complex Object) and the [compositional hierarchy](http://msdn.microsoft.com/en-us/library/ee707346(v=VS.91).aspx) may sharpen into focus. It’s all a blur to me but I *feel* like the subject matter in these articles has something to do with RIA Services ignoring a property of a Complex Object when this property is an Entity type. Feelings change…

While I’m here it may also help very little to mention that RIA Services ignore the properties of a Complex Object that are interfaces as an interface simply cannot be serialized. To confuse myself further, I quote Colin Blair in “[Interlude–Entities do not have children](http://www.riaservicesblog.net/Blog/post/Interlude-e28093-Entities-do-not-have-children.aspx)”:

<blockquote>

In RIA Services, every entity should be considered a top level entity. There is no such thing as a parent child relationship in RIA Services; all entities are equal to each other.

</blockquote>

This [quote](http://msdn.microsoft.com/en-us/library/ee382831(v=vs.110).aspx) from <acronym title="Microsoft Developer Network">MSDN</acronym> may yet again make me dizzy:

<blockquote>

Complex types cannot participate in associations. Neither end of an association can be a complex type, and therefore navigation properties cannot be defined on complex types.

</blockquote>

What this last quote twists me toward is the definite possibility that a Complex Object cannot have “navigation properties” and since an Entity is likely to have such properties they cannot be members of a Complex Object. This stackoverflow.com post, “[RIA Services Invoke Operation return Complex Type with Entity properties](http://stackoverflow.com/questions/9335650/ria-services-invoke-operation-return-complex-type-with-entity-properties),” appears to support this twist.

## Do not forget to use System.ServiceModel.DomainServices.Client for the Client

When you don’t use `System.ServiceModel.DomainServices.Client` on the Client, you will not be able to use LINQ extensions on `EntityQuery<T>`. …I don’t think most people still using RIA Services will run into this problem because this problem should appear when trying to re-factor a mature Silverlight project to support RIA Services. Following samples like “[WCF RIA Services](http://www.silverlight.net/learn/advanced-techniques/wcf-ria-services/wcf-ria-services-(silverlight-quickstart))” or “[Walkthrough: Creating a RIA Services Solution](http://msdn.microsoft.com/en-us/library/ee707376(VS.91).aspx)” where you check “Enable WCF RIA Services” in the “New Silverlight Application dialog box” should give you a client-side reference to `System.ServiceModel.DomainServices.Client` for free.

## The standalone MetadataType classes can have members of type object for convenience.

What’s important are matching member names, not types. Writing these classes by hand can be rather tedious so specifying object for each member is convenient. In “[Fluent API for .NET RIA Services Metadata](http://www.nikhilk.net/RIA-Services-Fluent-Metadata-API.aspx),” Nikhil Kothari suggests that we use a fluent (lambda-based) API instead of going through this tedium of building “ugly buddy” classes. And yes, according to a forum post, “[Announcement: FluentMetadata for WCF RIA Services](http://forums.silverlight.net/p/242023/603456.aspx/1?Announcement+FluentMetadata+for+WCF+RIA+Services),” there is NuGet package for this: `FluentMetadata`.

## For “Include” associations to work as expected use the attribute and the method call.

This one may be obvious to many, many others. But Jeff Handley took some [forum time](http://forums.silverlight.net/p/221917/532286.aspx) to post this:

<blockquote>

`.Include()` within your Query method tells Entity Framework to include the data in the query.

`[Include]` on your metadata tells RIA Services to include the child data in serialization.

RIA Services cannot infer whether or not to include child entities in serialization because some DALs support lazy loading of child entities. So we don't traverse child properties for their data unless the [Include] attribute is present.

</blockquote>

## Don’t be ‘fooled’ by child entity counts of zero.

Madeleine of South Africa in “[Eager loading EF4 entities with RIA services using Silverlight 4.0](http://madsdevblog.blogspot.com/2011/02/eager-loading-ef4-entities-with-ria.html)” writes:

<blockquote>

The first stumbling block when trying to access these navigation properties from the client side was due to the fact that LazyLoading was enabled by default.

</blockquote>

So often “by default,” when you are debugging code with entities, the entity navigation properties will give zero counts for data that you know is there. You can insure that children are loaded by explicitly loading the children (with, say `.ToList()`—see “For ‘Include’ associations to work as expected use the attribute and the method call.” above).

## You want JSON from your RIA Service? …you’ll need to write a little *.svc file.

For me, “[How to open a WCF RIA Services application to other type of clients: the SOAP endpoint (3/5)](http://blogs.msdn.com/b/davrous/archive/2010/12/03/how-to-open-a-wcf-ria-services-application-to-other-type-of-clients-the-soap-endpoint-3-5.aspx)” by David Rousset of Microsoft France, sold me on RIA Services. The information in this article provides me with the ability to live in two worlds at the same time: the Microsoft world before 2010 (largely, the SOAP world) and the bright future world of 2010.

There is also a <acronym title="Representational State Transfer">REST</acronym> world that has been thriving before 2010—a <acronym title="JavaScript Object Notation">JSON</acronym>-based REST world. Sandrino Di Mattia in “[Things you can do with WCF RIA Services and a regular .svc file](http://blogs.realdolmen.com/experts/2010/09/01/things-you-can-do-with-wcf-ria-services-and-a-regular-svc-file/)” and stackoverflow.com’s “[Problems exposing a RIA services as SOAP, Json, etc](http://stackoverflow.com/questions/5119924/problems-exposing-a-ria-services-as-soap-json-etc)” delve into the details of exposing a RIA service as RESTful JSON. The stackoverflow.com folks provide a very important bit of information:

<blockquote>

An INVOKE-decorated method is exposed as JSON only if it has the property `HasSideEffect=false`.

</blockquote>

This attribute decoration is the equivalent of `[HttpGet]` (with `JsonRequestBehavior.AllowGet`) in ASP.NET MVC.

Sandrino’s work, by the way, helped me get rid of this error message:Parser Error Message: The CLR Type 'System.ServiceModel.DomainServices.Hosting.DomainServiceHostFactory' could not be loaded during service compilation.This was due to how the `<%@ ServiceHost`` …>` declaration is written in the *.svc file.

This wonderful ability to expose JSON from a RIA Service via a *.svc file is , by the way again, the solution to the problem surfaced in “[Can Generic types be returned from RIA Service[?]](http://forums.silverlight.net/t/208798.aspx/1).”

Now that we know we can use a *.svc file with RIA Services, the following excerpt from [a](http://goldytech.wordpress.com/2010/11/13/silverlight-enabled-wcf-service-deployment-on-iis/) is either out of date or questionable:

<blockquote>

Both WCF RIA service (Domain Service) and Silverlight enabled WCF service works on the core principles of WCF technology. The difference is that lot of code is generated by RIA Services framework and there is no physical .svc file in your project whereas in the Silverlight enabled WCF service you have .svc file with you and things are more under your control.

</blockquote>

## RIA Services only supports output caching for GET [Query] operations.

This is not really a problem for me but Mathew Charles took some time in “[RIA Services Output Caching](http://blogs.msdn.com/b/digital_ruminations/archive/2011/01/05/ria-services-output-caching.aspx)” to highlight an “important feature of RIA Services—our integration with ASP.NET output caching.” What’s notable for me from this article is that “…caching is only enabled for query methods, and only if they use <span style="font-variant:small-caps;">get</span>.” I have no idea (today) why one would need to cache a <span style="font-variant:small-caps;">post</span> operation but this is just today…

## Obscure error: The "CreateRiaClientFilesTask" task was not given a value for the required parameter…

The “"CreateRiaClientFilesTask" task was not given a value for the required parameter” error was a problem for me. This is also a bit fuzzy to me but I think this problem was related to having Silverlight 5 stuff installing over the SL4 stuff. This issue is suggested in a [forum post](http://social.microsoft.com/Forums/en-US/Offtopic/thread/01e396fe-2a01-4687-8914-9e8dab52ec7a/)—and another [forum post](http://forums.silverlight.net/t/235423.aspx/1).

## RIA Services had support for Windows Azure in 2011 but…

I am not quite sure that RIA services just works with the latest version of Azure table storage (the 2012/Windows 8 time frame). I will start with articles like “[RIA Services and Windows Azure Table Storage](http://blogs.msdn.com/b/kylemc/archive/2010/11/01/ria-services-and-windows-azure-table-storage.aspx)” by Kyle McClellan or Jeff Handley’s [2011 coverage](http://jeffhandley.com/archive/2011/04/13/MIX11Releases.aspx) of this topic and then see how things go with the new Windows Azure.

## Related Resources

* “[WCF RIA Services](http://msdn.microsoft.com/en-us/library/ee707344(v=VS.91).aspx)”
* “[MSDN Samples Gallery Getting Started—WCF RIA Services](https://code.msdn.microsoft.com/site/search?f[0].Type=Technology&f[0].Value=WCF%20RIA%20Services&f[1].Type=Affiliation&f[1].Value=Microsoft)”
* “[Developing with WCF RIA Services Quickly and Effectively](http://channel9.msdn.com/Events/MIX/MIX10/CL09)”
* “[What is .NET RIA Services?](http://blogs.msdn.com/b/brada/archive/2009/03/19/what-is-net-ria-services.aspx)”
* “[MIX10 Talk—Slides and Code](http://www.nikhilk.net/RIA-Services-MIX10-Slides-Code.aspx)”
* “[Silverlight 4 Tools for VS 2010 and WCF RIA Services Released](http://weblogs.asp.net/scottgu/archive/2010/05/17/silverlight-4-tools-for-vs-2010-and-wcf-ria-services-released.aspx)”
* “[RIA Services—v1 Shipped!](http://www.nikhilk.net/RIA-Services-V1.aspx)”
* “[A Sample Silverlight 4 Application Using MEF, MVVM, and WCF RIA Services](http://www.codeproject.com/Articles/82298/A-Sample-Silverlight-4-Application-Using-MEF-MVVM)”
* “[RIA Services and Entity Framework POCOs](http://thedatafarm.com/blog/data-access/ria-services-and-entity-framework-pocos/)”
* “[POCO Entities Through RIA Services](http://www.codeproject.com/Articles/133414/POCO-Entities-Through-RIA-Services)”
* “[How to: Create a Domain Service that uses POCO-defined Entities](http://msdn.microsoft.com/en-us/library/gg602754(v=vs.91).aspx)”
* “[WCF RIA Services Support for EF 4.1 (and EF Code-First)](http://varunpuranik.wordpress.com/2011/06/29/wcf-ria-services-support-for-ef-4-1-and-ef-code-first/)”
* “[RIA Services EF Code First Support](http://jeffhandley.com/archive/2011/06/30/RIAServicesCodeFirst.aspx)”
* “[WCF RIA Services Part 3: Updating Data](http://www.silverlightshow.net/items/WCF-RIA-Services-Part-3-Updating-Data.aspx)”
* “[RIA/JS—jQuery client for WCF RIA Services](http://jeffhandley.com/archive/2011/04/13/RIAJS-jQuery-client-for-WCF-RIA-Services.aspx)”
* “[Silverlight 4 + RIA Services](http://blogs.msdn.com/b/brada/archive/2010/03/16/silverlight-4-ria-services-ready-for-business-exposing-odata-services.aspx)”
* “[Silverlight 4 + RIA Services—Ready for Business: Ajax Endpoint](http://blogs.msdn.com/b/brada/archive/2010/04/12/silverlight-4-ria-services-ready-for-business-ajax-endpoint.aspx)”
* “[Simple WCF Ria Services EF 4.1 Scaffolding](http://blog.larud.net/archive/2011/07/04/simple-wcf-ria-services-ef-4-1-scaffolding-aspx)”
* “[ASP.NET WebAPI: Getting Started with MVC4 and WebAPI](http://www.codeproject.com/Articles/344078/ASP-NET-WebAPI-Getting-Started-with-MVC4-and-WebAP)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
