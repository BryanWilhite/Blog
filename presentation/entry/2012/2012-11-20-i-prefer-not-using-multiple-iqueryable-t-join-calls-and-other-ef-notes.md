---json
{
  "documentId": 0,
  "title": "‘I prefer not using multiple IQueryable.Join() calls’ and other EF notes…",
  "documentShortName": "2012-11-20-i-prefer-not-using-multiple-iqueryable-t-join-calls-and-other-ef-notes",
  "fileName": "index.html",
  "path": "./entry/2012-11-20-i-prefer-not-using-multiple-iqueryable-join-calls-and-other-ef-notes",
  "date": "2012-11-21T00:00:00.000Z",
  "modificationDate": "2012-11-21T00:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-11-20-i-prefer-not-using-multiple-iqueryable-t-join-calls-and-other-ef-notes",
  "tag": "{\r\n  \"extract\": \"I haven’t checked with Julie Lerman but I think I’m an intermediate Entity Framework DbContext developer. I have enough experience to need to write some things down about what little I know.Warning: I prefer to use the “dot syntax” when I write LINQ-to-E...\"\r\n}"
}
---

# ‘I prefer not using multiple `IQueryable.Join()` calls’ and other EF notes…

I haven’t checked with [Julie Lerman](http://msdn.microsoft.com/en-us/magazine/ee532098.aspx?sdmr=julielerman&sdmi=authors) but I think I’m an intermediate Entity Framework `DbContext` developer. I have enough experience to need to write some things down about what little I know.

<span style="font-variant:small-caps;">Warning</span>: I prefer to use the “[dot syntax](http://www.hookedonlinq.com/ExtensionMethodSyntax.ashx)” when I write LINQ-to-Entities queries.

<span style="font-variant:small-caps;">Warning</span>: these notes are confined to Entity Framework over Microsoft SQL Server.

## I prefer not using multiple `IQueryable<T>.Join()` calls.

I have yet to find a situation where I *need* to use `IQueryable<T>.Join()`. This is because (so far) I’ve been tempted to use joins to perform lookups. My problem with this temptation is what I call the ‘cascading anonymous object’ effect—because one rarely does more than one lookup one will be tempted to write multiple `Join()` calls—very messy:

```c#
var ctx = GetContext();
    var statusIdsQuery = ctx.OrderStatuses
        .Select(i => i.OrderStatusId);
    var orderIdsQuery = ctx.OrderDetails
        .Where(i => i.BusinessType == "R")
        .Select(i => i.OrderID);
    var rentalChildrenQuery = XavierContext.QueryRentalChildren()
        .Select(i => i.OrderId);
    var query = ctx.OrderHeaders
        .Where(i => i.OrderId != null)
        .Where(i => i.RequisitionType == "R")
        .Where(i => statusIdsQuery.Contains(i.OrderStatusID))
        .Where(i => !orderIdsQuery.Contains(i.OrderId))
        .Where(i => i.IsRentalParent == false)
        .Where(i => !rentalChildrenQuery.Contains(i.OrderId))
        .Join(ctx.Departments,
            oh => oh.DepartmentID,
            dept => dept.DepartmentID,
            (oh, dept) => new {oh, dept})
        .Join(ctx.OrderStatuses,
            join => join.oh.OrderStatusID,
            status => status.OrderStatusId,
            (join, status) => new { join, status })
        .Join(ctx.OrderDetails,
            join => join.join.oh.OrderId,
            detail => detail.OrderID,
            (join, detail) => new { join, detail })
        .OrderByDescending(i => i.join.join.oh.OrderId)
        .Select(i => new Requisition
        {
            OrderId = i.join.join.oh.OrderId,
            OrderNumber = i.join.join.oh.OrderNumber,
            PONumber = i.join.join.oh.PONumber,
            DepartmentName = i.join.join.dept.DepartmentName,
            CustomerName = i.join.join.oh.CustomerName,
            CreatedDt = i.join.join.oh.CreatedDt,
            PriorityFl = i.join.join.oh.PriorityFl,
            OrderStatusDescription = i.join.status.StatusDescription,
            CreatedBy = i.join.join.oh.CreatedBy,
            OrderTotal = i.join.join.oh.OrderDetails.Sum(j => j.TotalAmount)
        });
```

Do you see all that `i.join.join` stuff? Yeesh. This might make a programmer proud of surviving the day’s work and “learning” Entity Framework simultaneously. But for me it was not “elegant” enough—which is another way of saying that this design is not maintainable and is hostile to new programmers working with this code. (By the way, why can’t we use a Tuple in a `Join()` instead of an anonymous object?) So let’s not yet again make a hostile work environment.

This is my attempt at elegance:

```c#
var ctx = GetContext();
    var statusIdsQuery = ctx.OrderStatuses
        .Select(i => i.OrderStatusId);
    var orderIdsQuery = ctx.OrderDetails
        .Where(i => i.BusinessType == "R")
        .Select(i => i.OrderID);
    var rentalChildrenQuery = XavierContext.QueryRentalChildren()
        .Select(i => i.OrderId);
    var query = ctx.OrderHeaders
        .Where(i => i.OrderId != null)
        .Where(i => i.RequisitionType == "R")
        .Where(i => statusIdsQuery.Contains(i.OrderStatusID))
        .Where(i => !orderIdsQuery.Contains(i.OrderId))
        .Where(i => i.IsRentalParent == false)
        .Where(i => !rentalChildrenQuery.Contains(i.OrderId))
        .OrderByDescending(i => i.OrderId)
        .Select(i => new Requisition
        {
            OrderId = i.OrderId,
            OrderNumber = i.OrderNumber,
            PONumber = i.PONumber,
            DepartmentName = ctx.Departments.FirstOrDefault(j => j.DepartmentID == i.DepartmentID).DepartmentName,
            CustomerName = i.CustomerName,
            CreatedDt = i.CreatedDt,
            PriorityFl = i.PriorityFl,
            OrderStatusDescription = ctx.OrderStatuses.FirstOrDefault(j => j.OrderStatusId == i.OrderStatusID).StatusDescription,
            CreatedBy = i.CreatedBy,
            OrderTotal = i.OrderDetails.Sum(j => j.TotalAmount)
        });
```

## Use of `IQueryable<T>.FirstOrDefault()` in an EF `Select()` expression is awesome!

This would never happen in the Java-world in which I came of age but *error messages from the system told how to improve my code* Were it not for excellent error messages coming from Entity Framework, I would have never, *ever* dream that I could use `IQueryable<T>.FirstOrDefault()` in a `Select()` expression (don’t use `.First<T>()` and don’t use `.Single<T>()`). In my work so far, `IQueryable<T>.FirstOrDefault()` translates into a `LEFT OUTER JOIN`, including all of the rows of the lookup table. This type of join is more forgiving for an equijoin; whereas, my ‘messy’ `IQueryable<T>.Join()` example above, uses `INNER JOIN` exclusively (this might be a performance benefit—but I still think it’s *messy*).

What might be considered messy in all of my self-proclaimed elegance is my lack of null checks for `.FirstOrDefault()`. But what I *think* is going here is that null checking in ‘`IQueryable` context’ is not necessary because this expression-tree stuff gets translated into SQL on the server (however, a code analysis tool might pick this up).

By the way, I must admit that I am so amazed by this because LINQ to Entities does way, way less than what LINQ to Objects can do…

## Use of `IEnumerable<T>.Sum()` in an EF `Select()` expression is surprising!

My limited experience with LINQ to Entities (and its excellent error messages) led me to assume that, once things go `IEnumerable<T>` in an `IQueryable<T>` Expression, an error message is not far away—some error telling me what is not supported. So, in my ‘elegant’ query above, I am surprised to find that `IEnumerable<T>.Sum()` is translated into a column-projection [sub-query](http://msdn.microsoft.com/en-us/library/ms189575(v=sql.105).aspx): `(SELECT SUM(…) FROM … WHERE …) AS [C1]` ([see full listing of t-SQL](http://pastebin.com/Ew9tKZuz)).

## Composing `IQueryable<T>` objects with `IQueryable<T>.Contains()`.

Obviously I’m thrilled about composing an `IQueryable<T>.Select()` Expression out of other `IQueryable` objects (and one surprising `IEnumerable`). In my examples above, you can see that I’m using `IQueryable<T>.Where()` calls with `IQueryable<T>.Contains()`. This translates into an `EXISTS/NOT EXISTS` constraint on the server.

I have asked myself, ‘How can I get an `IN` constraint on the server?’ Tests show me that `IEnumerable<T>.Contains()` translates into `IN/NOT IN` on the server. So, instead of using `.Where(i => !rentalChildrenQuery.Contains(i.OrderId))`, which translates into:

```sql
WHERE NOT EXISTS (SELECT
        1 AS [CX]
        FROM [dbo].[OrderHeader] AS [ExtentX]
        WHERE (0 = [ExtentN].[IsRentalParent])
```

I can use `.Where(i => !rentalChildrenList.Contains(i.OrderId))`, which should translate into:

WHERE NOT IN (1001, 1002, 1003, …)

Note that `rentalChildrenList` needs to be executed before we enter our query: `var rentalChildrenList = rentalChildrenQuery.ToList()`.

As of today’s notes, I am not sure which one’s better in terms of performance (I think `EXISTS` is faster)—but I prefer `EXISTS` because another developer reading my code (and examining any SQL generated by EF) will find `EXISTS` easier to read (because an `IN` list can get crazy huge).

## Before resorting to `IEnumerable<T>` operations, consider Canonical Entity Functions…

As an Entity Framework newbie, I assumed that the `System.Data.Objects` namespace, was exclusively for “internal use,” providing the basic building blocks of the entity framework, providing “[…core functionality of Object Services](http://msdn.microsoft.com/en-us/library/system.data.objects.aspx).” However, this namespace contains `EntityFunctions`, which “…Provides common language runtime (CLR) methods that expose conceptual model canonical functions in LINQ to Entities queries.” What the hell does that mean?

Let’s say you want to do some simple date operation inside of an `IQueryable<T>.Select()` expression: `.Select(i => new DateTime(i.LogStamp.Date))`. All I am trying to do here is get the date portion of my `LogStamp` column so I can show it in a Telerik grid that can filter by the day (instead of by the day and time—which looks silly in a grid). Too bad for me! This operation will not work on the server for several reasons, including:

* Entity Framework only supports objects with parameter-less constructors.
* EF does not recognize the `.Date` property—it cannot be translated into a “store expression.”

What translates easily into store expressions are the members of `EntityFunctions`. This is what I am looking for: `.Select(i => EntityFunctions.TruncateTime(i.LogStamp))`. The `TruncateTime()` function is just one of the many “[Canonical Functions](http://msdn.microsoft.com/en-us/library/bb738626.aspx)”—*canonical* because they “are supported by all data providers, and can be used by all querying technologies.”

Do not confuse `SqlFunctions` with `EntityFunctions`.

## Related Links

<table class="WordWalkingStickTable"><tr><td>

“[Subquery Fundamentals](http://msdn.microsoft.com/en-us/library/ms189575(v=sql.105).aspx)”

</td><td>

“A subquery is a query that is nested inside a `SELECT`, `INSERT`, `UPDATE`, or `DELETE` statement, or inside another subquery. A subquery can be used anywhere an expression is allowed.” This feature in SQL Server is actually ‘new’ to me—I’ve got to get out of the pre-2005 timeframe!

</td></tr><tr><td>

“[Using Joins](http://msdn.microsoft.com/en-us/library/ms191472(v=sql.105).aspx)”

</td><td>

I never hurts to review for those rote-memorization, sophomoric interview questions!

</td></tr><tr><td>

“[Functional difference between ‘NOT IN’ vs ‘NOT EXISTS’ clauses](http://ramanisandeep.net/2009/04/18/functional-difference-between-“not-in”-vs-“not-exists”-clauses/)”

</td><td>

“When using ‘NOT IN’, the query performs nested full table scans, whereas for ‘NOT EXISTS’, query can use an index within the sub-query.”

</td></tr><tr><td>

“[Composable and Efficient LINQ Queries](http://destructothedevilcat.wordpress.com/2009/02/15/composable-and-efficient-linq-queries/)”

</td><td>

“Whether you come from a functional, procedural, or object oriented background, it’s always a good idea to promote code reuse as much as possible.”

</td></tr><tr><td>

“[[Entity Framework] Using Include with lambda expressions](http://www.thomaslevesque.com/2010/10/03/entity-framework-using-include-with-lambda-expressions/)”

</td><td>

“However, there’s something that really bothers me with this Include method: the property path is passed as a string. This approach has two major drawbacks…”

</td></tr><tr><td>

“[Avoiding NotSupportedException with IQueryable](http://odetocode.com/Blogs/scott/archive/2012/03/19/avoiding-notsupportedexception-with-iqueryable.aspx)”

</td><td>

…my painful introduction to store expressions…

</td></tr><tr><td>

“[Canonical Functions](http://msdn.microsoft.com/en-us/library/bb738626.aspx)”

</td><td>

Somebody should make a cool, info-graphical poster of these…

</td></tr><tr><td>

“[Stop using AutoMapper in your Data Access Code](http://www.devtrends.co.uk/blog/stop-using-automapper-in-your-data-access-code)”

</td><td>

“Whilst I am a big fan of AutoMapper and use it in most projects I work on, especially for Domain to ViewModel mapping, when [it] comes to data access code, AutoMapper is not so useful. To put it simply, AutoMapper only works with in memory data, not the `IQueryable` interface which is more typically used in DAL scenarios.”

</td></tr><tr><td>

“[Entity Framework Code First DbContext Checks the ConnectionString During Compile? - Stack Overflow](http://stackoverflow.com/questions/7598242/entity-framework-code-first-dbcontext-checks-the-connectionstring-during-compile)”

</td><td>

Research inspired by the “Failed to get the `MetadataWorkspace` for the `DbContext` type” error…

According [to Jeff Handley](http://jeffhandley.com/archive/2011/06/30/RIAServicesCodeFirst.aspx): “WCF RIA Services instantiates a `DbContext` at design time and build time, not only at runtime… In order to generate code into your Silverlight project, RIA Services has to inspect your `DbContext` at build time in order to get the entity types that are available.”

Also from [somebody at Microsoft](http://varunpuranik.wordpress.com/2011/06/29/wcf-ria-services-support-for-ef-4-1-and-ef-code-first/): “…The difference between EF CodeFirst stand alone and with RIA Services is that we initialize a new `DbContext` at design time as well. …If the connection string is not valid or the connection can't be established you apparently get the exception you mentioned.”
</td></tr></table>

@[BryanWilhite](https://twitter.com/BryanWilhite)
