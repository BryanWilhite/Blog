---json
{
  "documentId": 0,
  "segmentName": "Songhay Publications and the Concept of the Index",
  "documentShortName": "2020-12-13-songhay-publications-and-the-concept-of-the-index",
  "fileName": "index.html",
  "path": "./entry/2020-12-13-songhay-publications-and-the-concept-of-the-index",
  "date": "2020-12-14T01:22:02.437Z",
  "modificationDate": "2020-12-14T01:22:02.437Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-12-13-songhay-publications-and-the-concept-of-the-index",
  "tag": "{\n  \"extract\": \"\"\n}"
}
---

# Songhay Publications and the Concept of the Index

What you are reading now is a Songhay Publication, this Blog website. A Songhay Publication centers around the `Document` [[GitHub](https://github.com/BryanWilhite/Songhay.Publications/blob/master/Songhay.Publications/Models/Document.cs)]. Several `Document` instances can be grouped under one or more `Segment` [[GitHub](https://github.com/BryanWilhite/Songhay.Publications/blob/master/Songhay.Publications/Models/Segment.cs)] instances. Further up the hierarchy, a `Segment` can group other `Segment` instances.

Compiling a collection of `Segment` groups into a file renders an _Index_. Meanwhile, in the real world, [there is the confusion](https://english.stackexchange.com/questions/45555/is-a-table-of-contents-an-index) between a “table of contents” and an _Index_. As of this writing in the Songhay studio, we avoid this confusion by defining an _Index_ here and looking forward to defining a Keyword Index (which is a real-world index).

All of this fantastic thinking about the Index comes from [my work](https://github.com/BryanWilhite/nodejs/tree/master/responsive-layouts) on rendering a Web Publication Index in HTML. I have been working on the visual design of two kinds of Index layouts:

1. the Index
2. the Blog Index

Behind the visual design is the _information_ design (too many years of my life was spent here). Both of these visual layouts are driven by a static JSON file this getting closer and closer to shapes of the models in `Songhay.Publications`. Today, I assume Songhay Index data will eventually look like this:

```json
[
  {
    "segmentName": "Section 1",
    "segments": [
      {
        "segmentName": "Section 1.1",
        "segments": [
          {
            "segmentName": "Section 1.1.1"
          },
          {
            "segmentName": "Section 1.1.2"
          },
          {
            "segmentName": "Section 1.1.3"
          }
        ]
      },
      {
        "segmentName": "Section 1.2",
        "segments": [
          {
            "segmentName": "Section 1.2.1"
          },
          {
            "segmentName": "Section 1.2.2"
          },
          {
            "segmentName": "Section 1.2.3"
          }
        ]
      },
      {
        "segmentName": "Section 1.3",
        "segments": [
          {
            "segmentName": "Section 1.3.1"
          },
          {
            "segmentName": "Section 1.3.2"
          },
          {
            "segmentName": "Section 1.3.3"
          }
        ]
      }
    ]
  },
  {
    "segmentName": "Section 2",
    "segments": [
      {
        "segmentName": "Section 2.1",
        "segments": [
          {
            "segmentName": "Section 2.1.1"
          },
          {
            "segmentName": "Section 2.1.2"
          },
          {
            "segmentName": "Section 2.1.3"
          }
        ]
      },
      {
        "segmentName": "Section 2.2",
        "segments": [
          {
            "segmentName": "Section 2.2.1"
          },
          {
            "segmentName": "Section 2.2.2"
          },
          {
            "segmentName": "Section 2.2.3"
          }
        ]
      }
    ]
  }
]
```

The JSON above is truncated for prose reading which means that `Document` data has been left out. For example, `Section 2.2` would have documents shaped like this:

```json
{
  "segmentName": "Section 2.2",
  "segments": [
    {
      "segmentName": "Section 2.2.1",
      "documents": [
        {
            "title": "Article 2.2.1.1",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        },
        {
            "title": "Article 2.2.1.2",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        },
        {
            "title": "Article 2.2.1.3",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        }
      ]
    },
    {
      "segmentName": "Section 2.2.2",
      "documents": [
        {
            "title": "Article 2.2.2.1",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        },
        {
            "title": "Article 2.2.2.2",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        }
      ]
    },
    {
      "segmentName": "Section 2.2.3",
      "documents": [
        {
            "title": "Article 2.2.3.1",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        },
        {
            "title": "Article 2.2.3.2",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        },
        {
            "title": "Article 2.2.3.3",
            "fileName ": "..",
            "modificationDate ": "..",
            "path": "..",
            "sortOrdinal": "..",
            "tag": ".."
        }
      ]
    }
  ]
}
```

## the Songhay Publications Index in Typescript

The JSON above can be used as a guide to define a single Index entry in Typescript:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<Document>[];
}
```

I made [a little manual test](https://stackblitz.com/edit/songhay-index-entry) to verify whether this type is working.

@[BryanWilhite](https://twitter.com/BryanWilhite)
