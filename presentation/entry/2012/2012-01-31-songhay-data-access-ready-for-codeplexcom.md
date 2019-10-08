---json
{
  "documentId": 0,
  "title": "Songhay Data Access Ready for CodePlex.com!",
  "documentShortName": "2012-01-31-songhay-data-access-ready-for-codeplexcom",
  "fileName": "index.html",
  "path": "./entry/2012-01-31-songhay-data-access-ready-for-codeplex-com",
  "date": "2012-02-01T00:00:00.000Z",
  "modificationDate": "2012-02-01T00:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-01-31-songhay-data-access-ready-for-codeplexcom",
  "tag": "{\r\n  \"extract\": \"I actually need this for my current work: I removed the Songhay.DataAccess.Runner namespace from the Songhay.DataAccess project.I’ve renamed the old Songhay.DataAccess.Runner project to Songhay.DataAccess.Runner-Console (this might be a new convention goi...\"\r\n}"
}
---

# Songhay Data Access Ready for CodePlex.com!

[<img alt="Yoda Mug" src="http://farm8.staticflickr.com/7006/6705622765_8d6e05522e_m.jpg" style="float:right;margin:16px;">](http://www.flickr.com/photos/wilhite/6705622765/in/photostream/ "Yoda Mug")

I actually need this for my current work:

* I removed the `Songhay.DataAccess.Runner` namespace from the `Songhay.DataAccess` project.
* I’ve renamed the old `Songhay.DataAccess.Runner` project to `Songhay.DataAccess.Runner-Console` (this might be a new convention going forward).
* I’ve generated a new `Songhay.DataAccess.Runner` project with the removed assets from the `Songhay.DataAccess` project

Now that the DAR stuff is cleanly separated from the `System.Data.Common` stuff, my generic data access routines that date back to .NET 2.0 is ready for the public.
[<img alt="Songhay Data Access" src="http://farm8.staticflickr.com/7154/6762510791_99721a18ff_o.png" style="display:block;margin:16px;margin-left:auto;margin-right:auto">](http://songhaydataaccess.codeplex.com/ "Songhay Data Access")

### Songhay Data Access

[Songhay Data Access](http://songhaydataaccess.codeplex.com/) is a set of static helper classes defining routines around `System.Data.Common`. As of this writing Songhay Data Access has been used with SQLite, MySQL and SQL Server, but, in theory, this set of libraries will work with *any* database that has an ADO.NET provider written for it.

Here are some of the highlights:

* Gets a `Common.DbConnection` object from a provider name and connection string (in `CommonDbms`).
* Converts a generic Dictionary into an array of `IDataParameter` (in `CommonParameter`).
* Returns a string or an object with an `IDbConnection` and a SQL statement (in `CommonScalar`).
* Returns an instance of `IDataReader` with an `IDbConnection` and a SQL statement (in `CommonReader`).
* Returns an `XPathDocument` with an `IDbConnection` and a SQL statement (in `CommonReader`).
* Full support for parsing Nullable generics with overloads for custom default values (in `FrameworkTypeUtility`).

Most “normal” .NET developers, starting out with .NET 1.x or 2.x, live almost exclusively in the world of `System.Data.SqlClient` to meet data-access needs. I was drawn to `System.Data.Common` from the very beginning because Microsoft’s work in this namespace represents ‘the sequel’ to [ODBC](http://en.wikipedia.org/wiki/ODBC)—of the olden days of <acronym title="Microsoft Component Object Model">COM</acronym> when [Don Box](http://en.wikipedia.org/wiki/Don_Box) was but a young Jedi. Writing helpers for `System.Data.Common` seems like, um, “common” sense to me, while investing heavily in `System.Data.SqlClient` is a bold declaration that all databases on your watch will be SQL Server for ever more.

I was very pleased to find out that the [Entity Framework](http://msdn.microsoft.com/en-us/library/system.data.entityclient.entitycommand(v=vs.110).aspx) is based on `System.Data.Common`. Songhay Data Access is my tiny alternative to the Entity Framework, when I need to get as close to the <acronym title="Database Management System">DBMS</acronym> as .NET will allow.

@[BryanWilhite](https://twitter.com/BryanWilhite)
