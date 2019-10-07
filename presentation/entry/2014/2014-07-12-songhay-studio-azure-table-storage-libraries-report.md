---json
{
  "author": "Bryan Wilhite",
  "content": "Gratuitous nostalgia demands to know about the first time the Songhay System published interest in Windows Azure: that was in 2010. Then, in 2012, a massive moment in Internet history is declared with the introduction of Azure Web Sites. So far nothing h...",
  "inceptDate": "2014-07-12T00:00:00",
  "isPublished": true,
  "slug": "songhay-studio-azure-table-storage-libraries-report",
  "title": "Songhay Studio: Azure Table Storage Libraries Report"
}
---

Gratuitous nostalgia demands to know about the first time the Songhay System published interest in Windows Azure: [that was in 2010](http://kintespace.com/rasxlog/?p=2370). Then, in 2012, [a massive moment in Internet history is declared](http://songhayblog.azurewebsites.net/Entry/Show/new-azure-web-sites-features) with the introduction of Azure Web Sites. So far nothing has been posted about Azure Table Storage (ATS) and, based on what will be reported here, it’s understandable. The Songhay System strategy for ATS is locked in the Silverlight era: the library, `Songhay.Cloud.Entities`, shows intent to support RIA Services—as [declared forcefully](http://songhayblog.azurewebsites.net/Entry/Show/ria-services-and-ef-entities) here in 2012. Like everything in the universe, this is going to change. The following is what we have at the moment.

First of all, there is no real Partition Key design strategy. More on this later… (?)

`Songhay.Cloud.Entities` is built on these packages:

    &lt;package id="Microsoft.WindowsAzure.ConfigurationManager" version="1.7.0.3" targetFramework="net45" /&gt;
    &lt;package id="RIAServices.WindowsAzure" version="4.1.60730.0" targetFramework="net40" /&gt;
    &lt;package id="WindowsAzure.Storage" version="1.7.0.0" targetFramework="net45" /&gt;

Because of the versions used above, the ‘old way’ (the “Data Context” way) of working with ATS is in effect. For example, [the old way](http://blogs.msdn.com/b/windowsazurestorage/archive/2010/11/06/how-to-get-most-out-of-windows-azure-tables.aspx) of retrieving a document:

    var tableClient = account.CreateCloudTableClient();

    var context = tableClient.GetDataServiceContext();
    var query = context.CreateQuery&lt;TableStorageDocument&gt;("TableStorageDocument");

    var document = query
        .Where(i =&gt; i.PartitionKey == partitionKey)
        .Where(i =&gt; i.RowKey == rowKey)
        .FirstOrDefault();

Here would be the ‘new’ (verbose-but-systematically-honest) way:

    var tableClient = account.CreateCloudTableClient();

    var tableReference = tableClient.GetTableReference("TableStorageDocument");
    var operation = TableOperation.Retrieve&lt;TableStorageDocument&gt;(partitionKey, rowKey);
    var operationResult = tableReference.Execute(operation);

    if(operationResult == null) throw new NullReferenceException("The expected result is not here.");

    var document = operationResult.Result as TableStorageDocument;

Note how the new way (Windows Azure SDK v2.x) is removing any LINQ-related, misleading suggestions of query flexibility.

And then there is the <acronym title="Representational State Transfer">REST</acronym>-based [way](http://msdn.microsoft.com/en-us/library/azure/dd894031.aspx), considered by many the *only* way. But the snag (for me) is getting past how authentication is done for REST-based operations. There seems to be buzz about “Shared Key” and “Shared Key Lite”—stuff I’ve no time to grasp today…

## Related Links

<table class="WordWalkingStickTable"><tr><td>

“[How to get most out of Windows Azure Tables](http://blogs.msdn.com/b/windowsazurestorage/archive/2010/11/06/how-to-get-most-out-of-windows-azure-tables.aspx)”
</td><td>

The ‘old,’ 2010 of approaching Azure Table Storage…
</td></tr><tr><td>

“[How to: Retrieve a single entity](http://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-tables/)”
</td><td>

The ‘new,’ 2014 way of handling ATS…
</td></tr><tr><td>

“[Because’s Azure Tables for LightSwitch](http://visualstudiogallery.msdn.microsoft.com/6a010249-4786-4d91-9aef-eda8ec474a9f)”
</td><td>

This link came from search result during an experiment.
</td></tr><tr><td>

“[Querying Tables and Entities](http://msdn.microsoft.com/en-us/library/azure/dd894031.aspx)”
</td><td>

MSDN documentation on the REST-based way to ATS.
</td></tr><tr><td>

“[Windows Azure Tables REST Api Authentication](http://stackoverflow.com/questions/15056894/windows-azure-tables-rest-api-authentication)”
</td><td>

“The Table service requires that each request be authenticated. Both Shared Key and Shared Key Lite authentication are supported. Shared Key authentication is more secure and is recommended for requests made against the Table service using the REST API.”
</td></tr><tr><td>

“[How to Sort Azure Table Store results Chronologically](http://blog.liamcavanagh.com/2011/11/how-to-sort-azure-table-store-results-chronologically/)”
</td><td>

“The trick I learned to handle this came from this whitepaper which uses a `RowKey` value of `DateTime.MaxValue.Ticks`—`DateTime.UtcNow.Ticks` to allow me to sort the items by an offsetted time from newest items to older items.”
</td></tr><tr><td>

“[Configuring Azure Connection Strings](http://msdn.microsoft.com/library/azure/ee758697.aspx)”
</td><td>

“The Azure storage services support both HTTP and HTTPS; however, using HTTPS is highly recommended.”
</td></tr><tr><td>

“[Types supported by Windows Azure Table Storage Domain Service](http://blogs.msdn.com/b/danliuatms/archive/2011/03/10/types-supported-by-windows-azure-table-storage-domain-service.aspx)”
</td><td>

“Kyle has several blog posts [explaining] how to use Windows Azure Table Storage (WATS) Domain Service, the support of which comes from WCF RIA Services Toolkit.”
</td></tr><tr><td>

“[RIA Services Toolkit (all packages) 4.2.0](http://www.nuget.org/packages/RIAServices.Toolkit.All)”
</td><td>

“The owner has unlisted this package. This could mean that the package is deprecated or shouldn’t be used anymore. …Includes SOAP and JSON Endpoints, EntityFramework 4.1 support, jQuery Client, T4 Code Generation, and the Windows Azure Table Storage DomainService.”
</td></tr><tr><td>

“[RIA Services and Windows Azure Table Storage](http://blogs.msdn.com/b/kylemc/archive/2010/11/01/ria-services-and-windows-azure-table-storage.aspx)”
</td><td>

“The difference between [Jim’s approach](http://blogs.msdn.com/b/jnak/archive/2010/01/06/walkthrough-windows-azure-table-storage-nov-2009-and-later.aspx) and what I’ll show here are the steps we take to integrate with existing `DomainService` patterns. Without further introduction, I’ll jump into the things you need to know to get the most out of our `Microsoft.ServiceModel.DomainServices.WindowsAzure` assembly preview.”
</td></tr><tr><td>

“[Azure—Part 4—Table Storage Service in Windows Azure](http://geekswithblogs.net/shaunxu/archive/2010/03/09/azure---part-4---table-storage-service-in-windows.aspx)”
</td><td>

“The partition key is being used for the load balance of the Azure OS and the group entity transaction. As you know in the cloud you will never know which machine is hosting your application and your data. It could be moving based on the transaction weight and the number of the requests. If the Azure OS found that there are many requests connect to your Book entities with the partition key equals ‘Novel’ it will move them to another idle machine to increase the performance. So when choosing the partition key for your entities you need to make sure they [indicate] the category or [group] information so that the Azure OS can perform the load balance as you wish.”
</td></tr><tr><td>

“[Windows Azure Table Storage LINQ Support](http://blogs.msdn.com/b/kylemc/archive/2010/11/22/windows-azure-table-storage-linq-support.aspx)”
</td><td>

“Windows Azure Table storage has minimal support for LINQ queries. They support a few key operations, but a majority of the operators are unsupported.”
</td></tr><tr><td>

“[SQL Azure and Microsoft Azure Table Storage](http://msdn.microsoft.com/en-us/magazine/gg309178.aspx)”
</td><td>

“At first, working with Windows Azure Table Storage may seem a little unwieldy due to assumptions made by relating “table storage” to a SQL database. The use of ‘table’ in the name doesn’t help. When thinking about Windows Azure Table Storage, I suggest that you think of it as object storage.”
</td></tr><tr><td>

“[Comparing AWS SimpleDB and Windows Azure Table Storage—Part I](http://seroter.wordpress.com/2010/09/30/comparing-aws-simple-db-and-windows-azure-table-storage-part-i/)”
</td><td>

“If you’re looking for fast, highly flexible data storage with high redundancy and no need for the rigor of a relational database, then AWS SimpleDB is a nice choice.”
</td></tr><tr><td>

“[Accessing Windows Azure Table Data as OData via PHP](http://blogs.msdn.com/b/brian_swan/archive/2010/09/16/accessing-windows-azure-table-data-as-odata-via-php.aspx)”
</td><td>

“Did you know that data stored in Windows Azure Table storage can be accessed through an OData feed? Does that question even make sense to you? If you answered no to either of those questions and you are interested in learning more, then read on. In this post I’ll show you how to use the OData SDK for PHP to retrieve, insert, update, and delete data stored in Windows Azure Table storage.”
</td></tr></table>
