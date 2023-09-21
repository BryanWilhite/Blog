---json
{
  "documentId": 0,
  "title": "Songhay Publications and the Concept of the Index (2021)",
  "documentShortName": "2023-09-20-songhay-publications-and-the-concept-of-the-index-2021",
  "fileName": "index.html",
  "path": "./entry/2023-09-20-songhay-publications-and-the-concept-of-the-index-2021",
  "date": "2023-09-21T02:34:38.029Z",
  "modificationDate": "2023-09-21T02:34:38.029Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2023-09-20-songhay-publications-and-the-concept-of-the-index-2021",
  "tag": "{\n  \"extract\": \"The intent here is to build upon the 2020 version of this subject and move forward toward new definitions and techniques that will work well in my Studio. That 2020 exploration gives us: - the Search Index Entry\\nthe Publications Index Entry We will see fr…\"\n}"
}
---

# Songhay Publications and the Concept of the Index (2021)

The intent here is to build upon [the 2020 version](http://songhayblog.azurewebsites.net/entry/2020-12-24-songhay-publications-and-the-concept-of-the-index/) of this subject and move forward toward new definitions and techniques that will work well in my Studio. That 2020 exploration gives us:

- the Search Index Entry
- the Publications Index Entry

We will see from the sections below that the _Search Index Entry_ is a `Document` with just one `extract` property tacked on—and the _Publications Index Entry_ is a way to present a tree-like hierarchy of parent and child `Segment` data with any related child `Document` data. 

## Search Index Entry

In Typescript, the `SearchIndexEntry` is just an extension of `Document`:

```typescript
interface SearchIndexEntry extends Partial<Document> {
  string extract;
}
```

The following table summarizes its usage in the Studio:

| repo | language | remarks |
|-|-|-|
| `songhay-core` | Typescript | consumed in Day Path and rasx() context Blogs by lunrjs, client-side search UX |
| `Songhay.Publications` | C# | `Songhay.Publications.Activities.GenerateSearchIndexFrom11tyEntries()` |

## Publications Index Entry

In Typescript, the `IndexEntry` is an extension of `Segment`:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<Document>[];
}
```

| repo | language | remarks |
|- |- |-|
| `songhay-core` | Typescript | consumed by Publication Index layouts GitHub](https://github.com/BryanWilhite/nodejs/tree/master/responsive-layouts)] |
| `Songhay.Publications` | C# | `ISegmentExtensions.ToPublicationIndexEntryJObject()` |

The information design goal behind this ‘tree-like hierarchy of parent and child `Segment` data’ is to represent something like a [site map](https://developer.mozilla.org/en-US/docs/Glossary/Site_map) of a website. It would define how to break one large segment (the entire website) down into smaller child segments each with their child documents.

## unifying these Index concepts

In Typescript, we can unify these two Index types into a new (proposed) `IndexEntry` type:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<SearchIndexEntry>[];
}
```

For the sake of naming, I would rename `SearchIndexEntry` to `IndexDocument`:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<IndexDocument>[];
}
```

## translating these Typescript definitions into F♯

The contemporary goal of this Studio is to maximize the use of F♯ via Blazor/Bolero which means the role Typescript plays should be significantly reduced.

In the world of F♯, our `IndexEntry` would look like this:

```fsharp
type IndexEntry() =
    inherit Segment()

    member val segments = Unchecked.defaultof<IndexEntry[] option> with get, set
    member val documents= Unchecked.defaultof<(Document * Extract)[] option> with get, set
```

…where `Extract` is `type Extract = Extract of string`.

We can see that move like this (which includes inheriting from the classic C♯ `Segment`) makes `IndexEntry` a bridge 🌉 between the C♯ and F♯ worlds. Such a ‘bridge’ might save me from having to rewrite _all_ the Studio’s C♯ as F♯—which _feels_ like an unwise move in terms of consuming even _more_ of my precious time 👴 at the very least.

## obtaining the `Document` extract

This new `Extract` type introduces a very important subject matter: the fate of the C♯ `Fragment`. So far, according to Studio tradition, we have made mention of the classic C♯-based GenericWeb schema of this Studio: the `Segment` and the `Document`. But what about the `Fragment`❓

At the turn of the century, I developed the `Fragment` because my Studio only had ‘formal’ recognition of the <acronym title="Extensible Hypertext Markup Language">XHTML</acronym> document (which is just an aspect of the massive investment in <acronym title="Extensible Markup Language">XML</acronym>, founding this Studio) and the <acronym title="Portable Document Format">PDF</acronym> document. What was missing from this Studio at the turn of the century (for well over a decade) were:

- the Git repository over the file system
- the cloud 🌩 file system (Azure Storage)
- cross-platform PowerShell
- the markdown document
- the <acronym title="JavaScript Object Notation">JSON</acronym> document

“Power User” workflows around Git, Azure Storage, PowerShell, markdown and <acronym title="JavaScript Object Notation">JSON</acronym> effectively eliminate the need for the `Fragment`. For example, yielding an `Extract` would involve consulting a `Document` that would point to a markdown document. The markdown document would have [front matter](https://en.wikipedia.org/wiki/Book_design#Front_matter) in the form of embedded <acronym title="JavaScript Object Notation">JSON</acronym> (or even <acronym title="YAML Ain’t Markup Language">YAML</acronym>), storing the `Extract` string.

This new [front matter](https://en.wikipedia.org/wiki/Book_design#Front_matter) concept in markdown is the leading justification for deprecating `Fragment`. In the old world 👴 of GenericWeb, the `Document` represented a statically-generated <acronym title="HyperText Markup Language">HTML</acronym> document to be displayed _in the near future_. In this new world of Songhay Publications, the `Document` should be a pointer to a _real_ document (or binary file) existing _in the present_ (and this present file can then be used to statically-generate <acronym title="HyperText Markup Language">HTML</acronym> at future publication).

The original thinking 🧠🐣 behind GenericWeb was to build a poor-man’s version of [Microsoft Index Server](https://learn.microsoft.com/en-us/previous-versions/office/developer/server-technologies/dd582938(v=office.11)?redirectedfrom=MSDN) (released in August 1996) that could also personalize [Web analytics](https://en.wikipedia.org/wiki/Web_analytics) reporting, based on breaking down a website into user-defined ‘segments.’ GenericWeb, by the way, was ‘sold’ to UCLA Medical Center Computing Services in the late 1990s when I was consultant-turned-employee.

## does your “Studio” not recognize the NoSQL database?

Notice how the section above (“#obtaining the `Document` extract”) makes no mention of the [NoSQL database](https://en.wikipedia.org/wiki/NoSQL). No MongoDB? No LiteDB? The explanation for this ignorance can only be more ignorance—and it starts with this 💸 ignorant statement: this Studio does not need NoSQL technologies because there is no need to collect arbitrary shapes of data from “customers” all over the world. This Studio is currently focused on read-only-mostly  solutions for _publishing_ which is different from read-write solutions for advertising-based “engagement” 💸

What is ignorant of this Studio—and also embarrassing for this Studio—is the lack of a solid distributed cache support (like Azure Cache for Redis) and the lack of years of experience with <acronym title="Content Delivery Network">CDN</acronym> products. Working on these world-dominating things have a higher priority than developing a better understanding of NoSQL tech.

## spending decades building ‘Power User workflows’ means being doomed to loneliness 😐

Since the turn of the century, there has been a social-media side to being a software developer. And well before GitHub there was the social engineering required for the many <acronym title="Most Valuable Professional">MVP</acronym> programs sponsored by multi-national corporations.

The work being done here is rather sprawling, delayed (by years often) and was never popular in the first place. My use of the world _sprawling_ is meant to take the glamour out of the word “interdisciplinary”: the crossing of C♯ and F♯ with a focus on building something like the [Quark Publishing System](https://en.wikipedia.org/wiki/Quark_Publishing_System) or maybe something like [AppleScript](https://en.wikipedia.org/wiki/AppleScript) entwined around [Adobe FrameMaker](https://en.wikipedia.org/wiki/Adobe_FrameMaker) sounds archaic, misplaced and bizarre to most socially adept tech folks.

Even the promise of introducing more user-friendly <acronym title="Graphical User Interface">GUI</acronym>-based tools (before 2030 😆) will only make my work rise to the level of a modicum of fame around command-line wrappers like [Handbrake](https://en.wikipedia.org/wiki/HandBrake) (because that is all I plan to build: command-line wrappers around Songhay Activity assemblies). So, earlier, I got rid of the money 💸and now am ridding myself of fame 👻

I am just a guy that started writing macros in Microsoft Word and somehow ended up here 👴 building digital tools for a small publishing house: this Studio. That sounds okay to me!

<https://github.com/BryanWilhite/>
