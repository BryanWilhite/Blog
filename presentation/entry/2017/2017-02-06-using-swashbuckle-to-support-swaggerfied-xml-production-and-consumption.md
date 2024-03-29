---json
{
  "documentId": 0,
  "title": "Using Swashbuckle to Support Swaggerfied XML Production and Consumption",
  "documentShortName": "2017-02-06-using-swashbuckle-to-support-swaggerfied-xml-production-and-consumption",
  "fileName": "index.html",
  "path": "./entry/2017-02-06-using-swashbuckle-to-support-swaggerfied-xml-production-and-consumption",
  "date": "2017-02-07T02:33:53.712Z",
  "modificationDate": "2017-02-07T02:33:53.712Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-02-06-using-swashbuckle-to-support-swaggerfied-xml-production-and-consumption",
  "tag": "{\r\n  \"extract\": \"Every ASP.NET NuGet package that I have used before Swashbuckle spoiled me with just working out of the box and/or having decent documentation. When I used ELMAH (before Application Insights), I felt that it just worked. Autofac gives me that same feelin...\"\r\n}"
}
---

# Using Swashbuckle to Support Swaggerfied XML Production and Consumption

Every ASP.NET NuGet package that I have used before [Swashbuckle](http://www.nuget.org/packages/Swashbuckle/5.5.3) spoiled me with just working out of the box and/or having decent documentation. When I used [ELMAH](https://www.nuget.org/packages/elmah/) (before [Application Insights](https://azure.microsoft.com/en-us/services/application-insights/)), I *felt* that it just worked. [Autofac](https://www.nuget.org/packages/Autofac/) gives me that same feeling as well (in spite of some [drama](http://songhayblog.azurewebsites.net/entry/my-autofac-packages-drama)). My point is that Swashbuckle really stands out due to my particular approach to the technology.

My approach (due to the demands of my day job) is the need to consume/produce XML. I am deliberately using consume/produce, by the way, to align with produces/consumes of [the Swagger Specification](http://swagger.io/specification/). So let’s take a look at the default Swagger UI for an XML endpoint auto-generated by version 5.5.3 of Swashbuckle:

<div style="text-align:center">

[<img src="https://farm1.staticflickr.com/645/31941217903_4d0bf088c2_z_d.jpg" alt="Swashbuckle Swagger UI is JSON-centric by default" title="!*m81">](https://www.flickr.com/photos/wilhite/31941217903/in/dateposted-public/)

</div>

It took me awhile to notice the obvious: Swashbuckle is biased toward JSON. This makes perfect sense until we go back to XML. Here is the ASP.NET Web API controller method that Swashbuckle is working with:

```cs
/// <summary>
/// Consumes the XML.
/// </summary>
/// <param name="xmlInput">The XML input.</param>
/// <returns></returns>
/// <remarks>
/// This endpoint cannot catch malformed XML errors for the logging system.
/// This endpoint was intended for use in Swagger,
/// using the same critical code that the production endpoint uses.
/// </remarks>
[HttpPost]
[Route("xml-endpoint")]
public IHttpActionResult ConsumeXml([FromBody]XElement xmlInput)
{
    return this.Ok<XElement>(xmlInput.ToResponseDocument());
}
```

When I mention that `ToResponseDocument()` in the method body above is just an some custom extension method that I wrote, we can disregard the method body. Swashbuckle is pretty much doing that as well. In order to get Swashbuckle to tell Swagger to consume/produce XML *exclusively*, we need to add my custom method attribute, `SwaggerContentType`, and my class implementing `IOperationFilter` ([in Swashbuckle.Core](https://github.com/domaindrivendev/Swashbuckle/blob/master/Swashbuckle.Core/Swagger/IOperationFilter.cs)), `SwaggerContentTypeOperationFilter`, mediated by entries in `SwaggerConfig.cs`.

We can see what our controller method looks like with `SwaggerContentType` declaring Swagger production and consumption:

```cs
/// <summary>
/// Consumes the XML.
/// </summary>
/// <param name="xmlInput">The XML input.</param>
/// <returns></returns>
/// <remarks>
/// This endpoint cannot catch malformed XML errors for the logging system.
/// This endpoint was intended for use in Swagger,
/// using the same critical code that the production endpoint uses.
/// </remarks>
[HttpPost]
[Route("xml-endpoint")]
[SwaggerContentType(mimeType: MimeTypes.ApplicationXml,
    IsExclusive = true,
    IsConsumption = false,
    Tag = nameof(MyController.ConsumeXml))]
[SwaggerContentType(mimeType: MimeTypes.ApplicationXml,
    IsExclusive = true,
    IsConsumption = true,
    MethodParameterName = "xmlInput",
    Tag = nameof(MyController.ConsumeXml))]
public IHttpActionResult ConsumeXml([FromBody]XElement xmlInput)
{
    return this.Ok<XElement>(xmlInput.ToResponseDocument());
}
```

With these attributes (and their backing `IOperationFilter` classes), we can now see Swashbuckle generating improved Swagger:

<div style="text-align:center">

[<img src="https://farm1.staticflickr.com/584/32714653736_330d5a60cd_z_d.jpg" alt="Swashbuckle Swagger UI with basic XML customization">](https://www.flickr.com/photos/wilhite/32714653736/in/dateposted-public/)

</div>

To make this happen, `SwaggerContentTypeOperationFilter` pulls our custom attributes by LINQ-querying [`ApiDescription`](https://msdn.microsoft.com/en-us/library/system.web.http.description.apidescription%28v=vs.118%29.aspx). We can use this custom attribute data to edit an instance of Swashbuckle’s `Operation` class (which is on line 99 of `SwaggerDocument.cs` class [in the current master](https://github.com/domaindrivendev/Swashbuckle/blob/master/Swashbuckle.Core/Swagger/SwaggerDocument.cs#L99)). My GitHub [Gist shows](https://gist.github.com/BryanWilhite/1a0e8c14a5002995aa5eb7984bfa5cd0#file-swaggercontenttypeoperationfilter-cs)`SwaggerContentTypeOperationFilter`*applying* these changes, handling Swagger consumption *and* production.

Once all of these classes are in place and the method attributes are adorning, we can add this mediating line to that `GlobalConfiguration.Configuration.EnableSwagger` lambda expression in `SwaggerConfig.cs` jam-packed with comments:

```cs
// Similar to Schema filters, Swashbuckle also supports Operation and Document filters:
//
// Post-modify Operation descriptions once they've been generated by wiring up one or more
// Operation filters.
//
//c.OperationFilter<AddDefaultResponse>();
//
// Set filter to apply Custom Content Types to operations
c.OperationFilter<SwaggerContentTypeOperationFilter>();
```

I notice that all of this work has no control over the “Example Value” XML shown in the Swagger UI. I think this is controlled by [the Swagger Definitions Object](http://swagger.io/specification/#definitionsObject). Assuming that a newer version of Swashbuckle will *not* get this working out of the box *for XML*, I will have to come back to this later.

<https://github.com/BryanWilhite/>
