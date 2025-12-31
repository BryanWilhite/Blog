---json
{
  "documentId": 0,
  "title": "studio status report: 2025-12",
  "documentShortName": "2025-12-30-studio-status-report-2025-12",
  "fileName": "index.html",
  "path": "./entry/2025-12-30-studio-status-report-2025-12",
  "date": "2025-12-30T21:21:19.897Z",
  "modificationDate": "2025-12-30T21:21:19.897Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2025-12-30-studio-status-report-2025-12",
  "tag": "{\n  \u0022extract\u0022: \u0022Month 12 of 2025 was about getting the re-release of kintespace.com almost out the \\u2018door\\u2019\\u2014well over 90% is done! I am seeing 16 days of work on kintespace.com in the Obsidian graph: the Obsidian graph of the month I will try to select notes below that cap\\u2026\u0022\n}"
}
---

# studio status report: 2025-12

Month 12 of 2025 was about getting the re-release of kintespace.com almost out the ‘door’—well over 90% is done! I am seeing 16 days of work on kintespace.com in the Obsidian graph:

![the Obsidian graph of the month](../../image/day-path-2025-12-30-21-23-15.png)

I will try to select notes below that capture the highlights of the month, including:

- establishing conventions with Obsidian front matter
- showing how Publications Data is loaded and processed into the eleventy pipeline
- beginning serious investigation into responsive-image data
- understanding that Songhay Publications Index (F♯) is an interesting combination of a generic visualizer of Index data and an online “advanced search”/research tool of Index data

## Let’s Encrypt: “Decreasing Certificate Lifetimes to 45 Days” 😐 #to-do

>Let’s Encrypt will be reducing the validity period of the certificates we issue. We currently issue certificates valid for 90 days, which will be cut in half to 45 days by 2028.
>
>This change is being made along with the rest of the industry, as required by the [CA/Browser Forum Baseline Requirements](https://cabforum.org/working-groups/server/baseline-requirements/requirements/), which set the technical requirements that we must follow. All publicly-trusted Certificate Authorities like Let’s Encrypt will be making similar changes. Reducing how long certificates are valid for helps improve the security of the internet, by limiting the scope of compromise, and making certificate revocation technologies more efficient.
>
>—“[Decreasing Certificate Lifetimes to 45 Days](https://letsencrypt.org/2025/12/02/from-90-to-45.html)”
>

## GitHub: “GitHub no longer uses toasts because of their accessibility and usability issues.”

>While it can be tempting to use toast UI as a solution for your task, know that there are many accessibility and usability issues inherent with this pattern. Because of this, **GitHub recommends using other more established, effective, and accessible ways of communicating with users**.
>
>…
>
>Toast UI risks violating the following [Web Content Accessibility Guideline](https://www.w3.org/TR/WCAG22/) (WCAG) Success Criteria (SC). Each of these SCs has one of three levels for support, and represent friction or a hard barrier for our users. GitHub honors the first two levels: A and AA.
>
>—“[Toasts](https://primer.style/accessibility/toasts/)”
>

## Entity Framework and AutoMapper for the #day-job #to-do 😐

Stuff to read:

- “[AutoMapper and EntityFramework Proxies - a workaround](https://jonegerton.com/dotnet/automapper-and-entityframework-proxies-a-workaround/)” (“When calling Mapper.Map we simply need to specify the types manually…”)
- “[AutoMapper with Entity Framework the right way](https://noobgrammerdotcom.wordpress.com/2021/10/23/automapper-with-entity-framework-the-right-way/)” (…it will send a full query to the database, selecting all the columns in Person table while we only need two columns…)
- “[Stop Using AutoMapper: Mapperly & Mapster in 2025](https://amarozka.dev/stop-using-automapper-mapster-mapperly-zero-allocation/)” (“…this “magic” comes with a cost: reflection at startup, hidden mapping rules, and unpleasant surprises at runtime…”)

## Internet Products: the data transformations between `MarkdownEntry` and `IDocument` are complete 😐✅

Based on the latest Studio conventions, the round trip between `MarkdownEntry` and `IDocument` is established! A few novelties were encountered:

1. the extension methods `JsonElement.GetJsonPropertyOrNull` do not return a `JsonProperty` because Microsoft’s `JsonElement.TryGetProperty` sets a `JsonElement`—which means counter intuitively that these `GetJsonProperty*` methods do not return a `JsonProperty`; they return `JsonElement`
2. `JsonElement.EnumerateObject` returns a collection of `JsonProperty`
3. the `JsonObject` equivalent of `JsonElement.EnumerateObject` is `JsonObject.AsEnumerable()` which returns an unexpected collection of `(string?, JsonNode?)` tuples
4. I decided to write `MarkdownEntry.ToIDocument` to use a switch structure to convert to `IDocument` from `JsonObject` instead of serializing it and then de-serializing into `IDocument`; this `switch`-structure approach _has_ to be higher performance than serializing and de-serializing #to-do
5. .NET 9.0 introduced `JsonSerializerOptions.IndentSize` \[📖 [docs](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.indentsize?view=net-10.0#system-text-json-jsonserializeroptions-indentsize) \]; meanwhile, in .NET 8.0, we have be aware that <acronym title="JavaScript Object Notation">JSON</acronym> serialization defaults to two spaces which is important to know when asserting equality in unit tests

## Internet Products: the Studio metadata story has completed its first chapter

What we see below is a ‘front matter model’ that is _fully integrated_ with Publications Data:

<div style="text-align:center">

![Obsidian front matter in this Studio](../../image/day-path-2025-12-30-21-48-32.png)

</div>

This model represents a mixture of Publications Document data and other data ‘points’ (prefixed by `rx`) that would have been Fragment data in the distant past.

## Songhay System Studio: for the first time in my life, I _see_ a “wah-wah” visualization 😐

>[!important]
>Wah-wah is EQ gain changing over time—with the time signature of the musical context.

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=ePmPn4w40LI">
        <img alt="Auto- Wah Effects in REAPER" src="https://img.youtube.com/vi/ePmPn4w40LI/maxresdefault.jpg" width="480" />
    </a>
    <p><small>Auto- Wah Effects in REAPER</small></p>
</figure>

</div>

## Internet Products: time to use b-roll player <acronym title="Uniform Resource Name">URN</acronym>s 😐🎊

Today, we look forward to configuring eleventy to generate HTML from `11ty/presentation/progressive-audio/p_*.md` data ❄⚙

- [x] change eleventy filter `rx_get_front_matter_link` to support b-roll URNs 🔨✨

My notes from over 10 days ago lead me to tabulate all known <acronym title="Uniform Resource Name">URN</acronym>s:

| URN                         | description                                                                                                                                     |
| --------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| `urn:b-roll:audio-p:<key>`  | b-roll progressive audio                                                                                                                        |
| `urn:b-roll:poetry:<key>`   | b-roll poetry, interactive                                                                                                                      |
| `urn:b-roll:video-d:<key>`  | b-roll video, <acronym title="Moving Picture Experts Group">MPEG</acronym>-<acronym title="Dynamic Adaptive Streaming over HTTP">DASH</acronym> |
| `urn:b-roll:video-yt:<key>` | b-roll video, YouTube                                                                                                                       |
| `urn:static:dd:<key>`       | static content: design diary                                                                                                                    |
| `urn:static:pdf:<key>`      | static content: <acronym title="Portable Document Format">PDF</acronym>                                                                         |
| `urn:static:poetry:<key>`   | static content: poetry, interactive                                                                                                             |
| `urn:static:swf:<key>`      | static content: Flash (2024-09-16#ruffle An open source Flash Player emulator\|ruffle? #to-do)                                              |

It would be awesome housekeeping 🧹 in the near future to change the directory names of the b-roll player and the Obsidian files to match the naming conventions of the `urn:b-roll:` URNs above #to-do

## Blender will officially incorporate the work of DillonGoo Studios 😐🎊

The [Goo Engine](https://www.dillongoostudios.com/gooengine) is on the way:

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=0SWKajvcWQQ">
        <img alt="Is This The End of Photorealistic Dominance in Blender?" src="https://img.youtube.com/vi/0SWKajvcWQQ/maxresdefault.jpg" width="480" />
    </a>
    <p><small>Is This The End of Photorealistic Dominance in Blender?</small></p>
</figure>

</div>

## Songhay Index should be regarded as a researcher tool 😐💡

The Songhay Index experience is not just a “power user” option for the casual visitor. It is a research tool (for me) that will allow anyone seriously investigating the content of Songhay Publications to find material.

## Internet Products: task roll-up complete 😐☑☑

Yesterday’s task roll-up is complete 👏

The `11ty/.eleventyignore` file shows what ‘partition’ of the publication is being worked on:

<div style="text-align:center">

![the eleventy ignore file](../../image/day-path-2025-12-30-21-56-15.png)

</div>

>[!success]
>Only the `app` ‘partition’ remains for the re-release!

I need to review any notes I may have about the `index.html` page to clarify next steps 🎊

## Internet Products: no, `clientId` is needed for the Obsidian ‘client’ 😐💡✨

>[!question]
>Should the Publications Client ID be used to locate items in the Obsidian vault?

When the answer to this question is _yes_, then the naming convention of `clientId` should change (from the one noted yesterday):

>[!info]
>Client ID is a root Publication slug followed by Obsidian path and file name, all as a kabob-case slug.

For example,

```plaintext
kinte-space-presentation-b-roll-video-yt-p-bowie0
```

This usage of `clientId` strongly implies that, for kintespace.com, it should _not_ be used for `og:url`:

```html
<meta property="og:url" content="{{ settings.uri }}entry/{{ clientId }}" />
```

A yes answer also means the “client” of `clientId` is the Obsidian ‘client’ 😐—but this identifier can be used on any ‘client’ as it continues to hide the core database ID.

## Internet Products: the Obsidian vault directory structure 😐💡✨

>[!important]
>The hierarchical relationships among Songhay Index Segment entities can be independent of Obsidian vault directory structure.

When the kinté space vault directory structure mirrors its Segment entities, it would look something like this:

```plaintext
11ty
├── space-people
│   ├── digitized-art
│   ├── poetry-in-xhtml5
│   ├── poetry-in-pdf
│   └── poetry-in-streams
└── space-time
│   ├── documentary
│   ├── prose
│   └── the-rasx-context
└── space-visitors
```

Back when I started the new repo for kintespace.com, I would _not_ have built this by hand. Hand-making this is too labor intensive!

Currently the Obsidian vault directory structure like this and may revisit it later #to-do:

```shell
$ tree -d -I node_modules
.
├── app
├── _data
├── _includes
│   ├── layouts
│   └── snippets
├── presentation
│   ├── b-roll
│   │   ├── audio-p
│   │   ├── poetry
│   │   └── video-yt
│   └── static
│       ├── dd
│       ├── pdf
│       ├── poetry
│       └── swf
├── prose
└── templates
    ├── html
    └── markdown
```

This structure can be brutally regarded as a _confusion_ among:

- a fusion of eleventy and Obsidian conventional directories
- an attempt to echo the Publications Presentation, containing a sub-structure based on recently developed <acronym title="Uniform Resource Name">URN</acronym> conventions
- a conceptually orphaned `prose/` directory which was initially contrasting itself with a `poetry/` directory—which was swallowed up by the URN convention

### the `"permalink": "{{fileName}}"` problem

My needs from 1998 introduce one, very small problem:

```plaintext
11ty
├── space-people
│   ├── digitized-art
│   ├── poetry-in-xhtml5
│   ├── poetry-in-pdf
│   └── poetry-in-streams
└── space-time
│   ├── documentary
│   ├── prose
│   │   └── oddity.md
│   └── the-rasx-context
└── space-visitors
    ├── about.md
    ├── faqs.md
    ├── hits.md
    └── oddity.md
```

The vault directory structure above shows two Markdown files with the same file name. Because the eleventy configuration for kintespace.com uses `"permalink": "{{fileName}}"`, there can only be _one_ `oddity.html` file in this contrived example.

This problem explains why mainstream eleventy people would wonder what the hell am I doing with `"permalink": "{{fileName}}"`.

## Internet Products: building the fundamental static <acronym title="JavaScript Object Notation">JSON</acronym> sets for kintespace.com

Here are the fundamental fundamental static <acronym title="JavaScript Object Notation">JSON</acronym> sets:

- the Publications Data responsive-image data  (not currently available #to-do; cannot generate the home page—and customize <acronym title="the Open Graph protocol">og</acronym> metadata throughout the site—without it)
- the Publications Data indices (under `app-staging/data`; cannot generate the home page without it)
- the kintespace.com analytics data (not currently available #to-do; cannot generate `khits.html` without it)

## Internet Products: “List of True 16:9 Resolutions”

There are two known aspect-ratio ‘vectors’ of concern in this Studio:

1. 4:3 (≈1.33333) => 1024×768, 800×600, 640×480
2. 16:9 (≈1.77777) => 2560×1440 (WQHD), 1920×1080 (1080p / Full HD), 1280×720 (720p / HD ready), 512×288 

Because of the interests in cinema around this Studio, we will take the 16:9 ‘vector’:

>In an effort to enhance the knowledge of the video-making community, I have compiled a list of all true 16:9 video resolutions, including their associated standard when applicable, as well as when the resolution is divisible by 8, which is useful for limited video encoders. The table goes up to 1080p and includes common resolutions like that of a typical 27 inch 16:9 computer monitor and Super Hi-Vision.
>
>**Note:** If you’ve ever worked with SD content, you’ll notice that no resolution here fits the DVD standard. That’s because DVDs were originally made to comply with the NTSC broadcasting resolution, which is a non-square pixel standard using the resolution of 720 by 480 pixels, stretched to accommodate either 4:3 or 16:9 content, never producing a true 16:9 resolution.
>
>—“[List of True 16:9 Resolutions](https://pacoup.com/2011/06/12/list-of-true-169-resolutions/)”
>

## Internet Products: `staticJson*` imports shaped like Publications Data is in the kintespace.com pipeline 😐✅

The `11ty/.eleventy.js` file now reveals the second convention between Publications Data and eleventy:

![eleventy import statements](../../image/day-path-2025-12-30-22-03-28.png)

Each of these `staticJson*` imports represents each `Segment` of the Publication. These `staticJson*` imports can be used to locate the latest `Document` by `Segment` to inform the rendering of `index.html`.

- [x] add `staticJson*` imports to the `11ty/.eleventy.js` file 🔨✨

>[!important]
>These `staticJson*` imports are optionally available to the `addGlobalData` method \[📖 [docs](https://www.11ty.dev/docs/data-global-custom/) \] of eleventy.
>

I will probably use this `addGlobalData` method (first mentioned in the Studio at the end of last winter) to load `khits.html` data of kintespace.com analytics #to-do

## Internet Products: my work from over five years ago with ImageMagick 😐🧠💆‍♂

Yesterday, I had a _feeling_ that I made notes on Responsive Images. Now, I am collecting myself: over five years ago, I made extensive notes about ImageMagick:

- “[Wand Binds to ImageMagick](https://github.com/BryanWilhite/jupyter-central/blob/main/wand/README.md)”
- “[Generating Responsive Images](https://github.com/BryanWilhite/jupyter-central/blob/main/wand-responsive-images/README.md)” ([the associated notebook](https://github.com/BryanWilhite/jupyter-central/blob/main/wand-responsive-images/generating-responsive-images.ipynb) has be rewritten in light of thoughts experienced this month, specifically yesterday #to-do)

## open pull requests on GitHub 🐙🐈

- <https://github.com/BryanWilhite/Songhay.HelloWorlds.Activities/pull/14>
- <https://github.com/BryanWilhite/dotnet-core/pull/67>

## sketching out development projects

- consider using Lerna to coordinate the two levels of `npm` scripts 🧠👟
- use a Jupyter Notebook to track finding and changing Amazon links to open source links 📓⚙
- use a Jupyter Notebook to convert flickr links to Publications (responsive image) links 📓⚙
- establish `DataAccess` logic for Obsidian markdown metadata 🔨✨
- establish `DataAccess` logic for Index data, including adding and removing Obsidian documents (and Segments) 🔨✨
- package `DataAccess` logic in `*Shell` project for `npm` scripting 🚜✨
- convert rasx() context repo to the relevant conventions shown in the diagram above 🔨🚜
- retire the old `kinte-space` repo for kintespace.com 🚜🧊
- convert Songhay Day Path Blog repo to the relevant conventions shown in the diagram above 🔨🚜
- re-release Songhay Dashboard by updating its repo to the relevant conventions shown in the diagram above 🔨🚜
- start development of Songhay Publications Index (F♯) experience for WebAssembly 🍱✨
- start development of Songhay Publications - Data Editor to establish a <acronym title="Graphical User Interface">GUI</acronym> for `*Shell` and provide visualizations and interactions for Publications data 🍱✨

🐙🐈<https://github.com/BryanWilhite/>
