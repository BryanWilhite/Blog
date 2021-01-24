---json
{
  "documentId": 0,
  "title": "studio status report: 2021-01",
  "documentShortName": "2021-01-23-studio-status-report-2021-01",
  "fileName": "index.html",
  "path": "./entry/2021-01-23-studio-status-report-2021-01",
  "date": "2021-01-24T04:27:07.709Z",
  "modificationDate": "2021-01-24T04:27:07.709Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-01-23-studio-status-report-2021-01",
  "tag": "{\n  \"extract\": \"\"\n}"
}
---

# studio status report: 2021-01

## month 01 of 2021 was about upgrading the core Studio packages to .NET 5.0

Yes, I did it. 🐇🕳 I am wasting too much your sweet time. I give it right back one of these days. The following GitHub projects detail the upgrades:

- [`SonghayCore` Project #19](https://github.com/BryanWilhite/SonghayCore/projects/19) [📦[NuGet](https://www.nuget.org/packages/SonghayCore/)]
- [`Songhay.DataAccess` Project #1](https://github.com/BryanWilhite/Songhay.DataAccess/projects/1) [📦[NuGet](https://www.nuget.org/packages/Songhay.DataAccess/)]

`Songhay.Cloud.BlobStorage` [📦[NuGet](https://www.nuget.org/packages/Songhay.Cloud.BlobStorage/)] was also upgraded to .NET 5.0 (apparently without a project); I guess I flew though this one after I found out that `WindowsAzure.Storage` [has been deprecated](https://github.com/BryanWilhite/Songhay.Cloud.BlobStorage/issues/16) and I decided to leave it in place to avoid dealing with the fundamental, breaking, architectural changes 🐇🕳 in the new package.

`Songhay.Publications` [📦[Nuget](https://www.nuget.org/packages/Songhay.Publications/)] was also upgraded and not properly tracked by a Project. To make management matters worse, I left two previous [projects](https://github.com/BryanWilhite/Songhay.Publications/projects) open with unresolved tasks! (Roll these projects over into a `5.1.0` release project?) I deserve to be fired for poor accountancy but I am not doing this as an abject work for hire. Ha!

## all Generic Web databases were exported to gigabytes of JSON!

This is a major milestone.🤠

## the `lit-html`-based responsive layouts are done…

…but using `lit-html` in production _for an Index_ is yet another SEO nightmare waiting to happen. This means I have to add an `eleventy`-based version and make sure the static JSON in play looks like `IndexEntry` introduced last month:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<Document>[];
}
```

## sketching out a development schedule (revision 13)

The schedule of the month:

- ~~upgrade core Studio packages to .NET Core 5.0 📦↑~~
- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
