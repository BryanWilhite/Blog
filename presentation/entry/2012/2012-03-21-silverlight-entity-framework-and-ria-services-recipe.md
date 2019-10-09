---json
{
  "documentId": 0,
  "title": "Silverlight, Entity Framework and RIA Services Recipe",
  "documentShortName": "2012-03-21-silverlight-entity-framework-and-ria-services-recipe",
  "fileName": "index.html",
  "path": "./entry/2012-03-21-silverlight-entity-framework-and-ria-services-recipe",
  "date": "2012-03-21T19:05:00Z",
  "modificationDate": "2012-03-21T19:05:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-03-21-silverlight-entity-framework-and-ria-services-recipe",
  "tag": "{\r\n  \"extract\": \"Here’s a short list for database-first DbContext with RIA Services: Define and generate the database.Generate the Entities with the database.Generate a Web Project to host the DbContext class and the “Database Domain Service of T” class.Write the DbContex...\"\r\n}"
}
---

# Silverlight, Entity Framework and RIA Services Recipe

Here’s a short list for database-first `DbContext` with [RIA Services](http://www.silverlight.net/learn/advanced-techniques/wcf-ria-services/get-started-with-wcf-ria-services):

* Define and generate the database.
* Generate the Entities with the database.
* Generate a Web Project to host the `DbContext` class and the “Database Domain Service of T” class.
* Write the `DbContext` class for the Entities. This had a gotcha for me (see below).
* Write the “Database Domain Service of T” (`DbDomainService<T>`) for the `DbContext` class for the Entities.
* Build your client and “wire up” the client with the “Database Domain Service of T” (this step is supposed to be auto-magic).
* Follow [@julielerman](https://twitter.com/)!

Yes, my stuff is database-first but my recipe here is based on “[RIA Services EF Code First Support](http://jeffhandley.com/archive/2011/06/30/RIAServicesCodeFirst.aspx)” by Jeff Handley.

## Now, some details…

**Define and generate the database.** Define a new data source: in my case it’s a SQL Server database. Generate a SQL Server 2008 Database Project. Because I am weird, I run the **Import Database Objects and Settings…** command against an empty database. This gives me a `Schema Objects\Schemas\dbo\Tables` folder where I write `*.table.sql` scripts. My intention is to have a data-source level project that is most flexible for the data source. Based on my current level of experience however, I expect to define my tables and users and then let Entity Framework handle the rest.

**Generate the Entities with the database.** Generate a Class Library Project for the Entities. Install Entity Framework 4.1.10715.0 via NuGet like this:    Install-Package EntityFramework –Version 4.1.10715.0This is done to keep the version of EF in line with RIA Services.

**Generate a Web Project to host the**`DbContext`**class and the “Database Domain Service of T” class.** Generate an ASP.NET MVC 3 Web Application (`*.Web`). Install the `RIAServices.EntityFramework` NuGet package on the `*.Web` project. Add a folder to this Project called `ModelContext`—this is where my data access stuff will live—the classes extending `DbContext`. I currently see no need to move these files to a separate project. Based on scraps of details about ASP.NET MVC 4 and Glenn Block’s Web API, I assume that an MVC Web application will be a serious Web Service provider with multiple endpoints spitting out JSON and XML until the cows come home. This implies that the Silverlight project with a **WCF RIA Services link** pointing at this MVC Web is but one consumer of many.

**Write the**`DbContext`**class for the Entities**. In old-school, Provider-Model talk this would be the “provider” for the RIA service. I had a serious problem here that took hours away from my life! I kept getting a “Failed to get the `MetadataWorkspace` for the `DbContext` type...” error. The problem was based on [this fact](http://stackoverflow.com/questions/7598242/entity-framework-code-first-dbcontext-checks-the-connectionstring-during-compile):

<blockquote>

In order to generate code into your Silverlight project, RIA Services has to inspect your `DbContext` at build time in order to get the entity types that are available.

</blockquote>

Because I failed to specify a connection string linking to a real database, this error hounded!

Here also is the place to start unit test coverage for data access.
[<img alt="DbContext Lesson Learned" src="http://farm7.staticflickr.com/6050/7001608941_c1f08e17d2_o.png">](http://www.flickr.com/photos/wilhite/7001608941/in/photostream/ "DbContext Lesson Learned")

**Write the “Database Domain Service of T”…** Finally! This is the class that RIA services will use to auto-magically generate code on the client. This code will be the `WebContext` on the client. <acronym title="Microsoft Developer Network">MSDN</acronym>[explains](http://msdn.microsoft.com/en-us/library/ee707361(v=vs.91).aspx):

<blockquote>

When you build the solution, RIA Services automatically generates a WebContext class in the client project.

</blockquote>

When you attribute a method in this class extending `DbDomainService<T>` with, say, `[Invoke]`, it becomes a method that that returns `InvokeOperation<T>` on the client. Any methods in this class returning `IQueryable<T>` will translate into `LoadOperation<T>` on the client.

**Build your client and “wire up” the client…** Generate Silverlight project with a **WCF RIA Services link** pointing at this ***.Web** project.

### More Links

* “[Get Started with WCF RIA Services: Silverlight.NET](http://www.silverlight.net/learn/advanced-techniques/wcf-ria-services/get-started-with-wcf-ria-services)”
* “[Programming Entity Framework](http://learnentityframework.com/)”
* “[Setting up a new Silverlight 4 Project with WCF RIA Services](http://geekswithblogs.net/kgrossnicklaus/archive/2011/01/30/setting-up-a-new-silverlight-4-project-with-wcf-ria.aspx)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
