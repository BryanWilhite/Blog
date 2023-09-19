---json
{
  "documentId": 0,
  "title": "Songhay Publications and the Concept of the Index (2021)",
  "documentShortName": "2021-06-28-songhay-publications-and-the-concept-of-the-index-2021",
  "fileName": "index.html",
  "path": "./entry/2021-06-28-songhay-publications-and-the-concept-of-the-index-2021",
  "date": "2021-06-28T18:38:11.326Z",
  "modificationDate": "2021-06-28T18:38:11.326Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-06-28-songhay-publications-and-the-concept-of-the-index-2021",
  "tag": "{\n  \"extract\": \"\"\n}"
}
---

# Songhay Publications and the Concept of the Index (2021)

The intent here is to build upon [the 2020 version](http://songhayblog.azurewebsites.net/entry/2020-12-24-songhay-publications-and-the-concept-of-the-index/) of this subject and move forward toward techniques that will work well in my Studio. That 2020 exploration gives us:

- the Search Index Entry
- the Publications Index Entry

Clearly, we have two Index-Entry concepts: (i) Search and (ii) Publications. We can express these Entry types in Typescript:

## Search Index Entry

```typescript
interface SearchIndexEntry extends Partial<Document> {
  string extract;
}
```

| repo | language | remarks |
|- |- |-
| `songhay-core` | Typescript | consumed in Day Path and rasx() context Blogs by lunrjs, client-side search UX |
| `Songhay.Publications` | C# | `Songhay.Publications.Activities.GenerateSearchIndexFrom11tyEntries()` |

## Publications Index Entry

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<Document>[];
}
```

| repo | language | remarks |
|- |- |-
| `songhay-core` | Typescript | consumed by Publication Index layouts [[GitHub](https://github.com/BryanWilhite/nodejs/tree/master/responsive-layouts)] |
| `Songhay.Publications` | C# | `ISegmentExtensions.ToPublicationIndexEntryJObject()` |

<https://github.com/BryanWilhite/>
