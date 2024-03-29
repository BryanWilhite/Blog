---json
{
  "documentId": 0,
  "title": "Entity Framework and JSON.NET",
  "documentShortName": "2015-04-03-entity-framework-and-json-net",
  "fileName": "index.html",
  "path": "./entry/2015-04-03-entity-framework-and-json-net",
  "date": "2015-04-03T07:00:00Z",
  "modificationDate": "2015-04-03T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-04-03-entity-framework-and-json-net",
  "tag": "{\r\n  \"extract\": \"Converting code-first, EF6 Entity models to JSON (with JSON.NET) is more complicated than I expected. First of all, Include() does not behave as I expected (after one level as suggested in “EF 6” or “.include with multiple levels”).For me, there was no d...\"\r\n}"
}
---

# Entity Framework and JSON.NET

Converting code-first, EF6 Entity models to JSON (with JSON.NET) is more complicated than I expected. First of all, `Include()` does not behave as I expected (after one level as suggested in “[EF 6](https://entityframework.codeplex.com/workitem/2256)” or “.[include with multiple levels](https://entityframework.codeplex.com/discussions/436875)”).

For me, there was no difference between this:

```cs
var segments = GetContext().Segments
        .Include(i => i.ChildSegments)
        .Where(i => (i.ParentSegmentId == null) && i.IsActive.HasValue && i.IsActive.Value)
        .OrderBy(i => i.SegmentName);
```

…and this:

```cs
var segments = GetContext().Segments
        .Include(i => i.ChildSegments)
        .Include(i => i.ChildSegments)
        .Where(i => (i.ParentSegmentId == null) && i.IsActive.HasValue && i.IsActive.Value)
        .OrderBy(i => i.SegmentName);
```

I did not bother run SQL Profiler and dissect the SQL but in both cases there were no “grandchild” segments. (By the way, it’s been a few years so I should help to mention that EF6 over SQL Server still does not support the Nullable extension method `GetValueOrDefault()`. So, for the example above, we see `i.IsActive.HasValue && i.IsActive.Value` in place of `i.IsActive.GetValueOrDefault()`.)

So my need for these “grandchild” segments suggests (correctly) that my `Segment` type has a “parent” `Segment`. This “self-join” can cause JSON.NET to throw a circular-reference exception and/or an out-of-memory exception (as it travels from parent to children—and children of children). Moreover, the `Segment` has a Documents collection (where each `Document` has a `Segment`—faithfully duplicated by JSON.NET until it runs out of memory!) To address these issues I have this:

```cs
var documentSettings = new JsonSerializerSettings
{
    ContractResolver = new InterfaceContractResolver<IDocument>(),
    PreserveReferencesHandling = PreserveReferencesHandling.None,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};
```

What stands out is my `InterfaceContractResolver<IDocument>`, taking the guidance from Newton-King’s “[Serialization using ContractResolver](http://www.newtonsoft.com/json/help/html/ContractResolver.htm).” I’ve defined this resolver to ‘filter’ my Entity model Document through `IDocument` (which defines no parent-child relations):

```cs
public class InterfaceContractResolver<TInterface> : DefaultContractResolver where TInterface : class
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IList<JsonProperty> properties = base.CreateProperties(typeof(TInterface), memberSerialization);
        return properties;
    }
}
```

This looks straight forward when you want to do something like this:

```cs
var rootDocuments = segment.ChildSegments.Select(k =>
    {
        var rootDocument = context.Documents
            .Where(l => l.SegmentId == k.SegmentId)
            .Where(l => l.IsActive.HasValue && l.IsActive.Value)
            .Where(l => l.IsRoot.HasValue && l.IsRoot.Value)
            .FirstOrDefault();

var documentJson = JsonConvert.SerializeObject(rootDocument, documentSettings);
        return documentJson;
    })
    .ToArray();
```

But what I have here is an array of JSON strings—why did I do that? Well, it turns out that I cannot (it could just be me) configure JSON.NET to handle `enumerationOfDocuments` in this:

```cs
var json = JsonConvert.SerializeObject(new
{
    SegmentId = segment.SegmentId,
    SegmentName = segment.SegmentName,
    SortOrdinal = segment.SortOrdinal,
    CreateDate = segment.CreateDate,
    ParentSegmentId = segment.ParentSegmentId,
    ClientId = segment.ClientId,
    IsActive = segment.IsActive,
    ChildDocuments = enumerationOfDocuments,
});
```

Either it is not possible or I do not know how to extend `DefaultContractResolver` to deal with an object that has an `IEnumerable<Document>` property that should be ‘filtered’ into `IEnumerable<IDocument>`.

So I’m resorting to old-fashioned string manipulation tricks to get around this limitation of me—or of JSON.NET.

<https://github.com/BryanWilhite/>
