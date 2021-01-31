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
  "tag": "{\n  \"extract\": \"month 01 of 2021 was about upgrading the core Studio packages to .NET 5.0 Yes, I did it. 🐇🕳 I am wasting too much your/my sweet time but the Studio needed to upgrade to .NET 3.0—and I waited so long that the Studio needed to upgrade to .NET 5.0. The fol…\"\n}"
}
---

# studio status report: 2021-01

## month 01 of 2021 was about upgrading the core Studio packages to .NET 5.0

Yes, I did it. 🐇🕳 I am wasting too much your/my sweet time but the Studio _needed_ to upgrade to .NET 3.0—and I waited so long that the Studio _needed_ to upgrade to .NET 5.0. The following GitHub projects detail the upgrades:

- [`SonghayCore` Project #19](https://github.com/BryanWilhite/SonghayCore/projects/19) [📦[NuGet](https://www.nuget.org/packages/SonghayCore/)]
- [`Songhay.DataAccess` Project #1](https://github.com/BryanWilhite/Songhay.DataAccess/projects/1) [📦[NuGet](https://www.nuget.org/packages/Songhay.DataAccess/)]

`Songhay.Cloud.BlobStorage` [📦[NuGet](https://www.nuget.org/packages/Songhay.Cloud.BlobStorage/)] was also upgraded to .NET 5.0 (apparently without a project); I guess I flew though this one after I found out that `WindowsAzure.Storage` [has been deprecated](https://github.com/BryanWilhite/Songhay.Cloud.BlobStorage/issues/16) and I decided to leave it in place to avoid dealing with the fundamental, breaking, architectural changes 🐇🕳 in the new package.

`Songhay.Publications` [📦[Nuget](https://www.nuget.org/packages/Songhay.Publications/)] was also upgraded and not properly tracked by a Project 😬🕔🔥 To make management matters worse, I left two previous [projects](https://github.com/BryanWilhite/Songhay.Publications/projects) open with unresolved tasks! (I rolled these projects over into a `5.1.0` [release project](https://github.com/BryanWilhite/Songhay.Publications/projects/7).)

## the `Songhay.Publications` 5.1.0 release is breaking away from relational DBM systems

The breaking changes in the `5.1.0` [release project](https://github.com/BryanWilhite/Songhay.Publications/projects/7) is about moving out of DBM-systems patterns (and kludges) toward a No-SQL world. As of this writing, [there are plans](https://github.com/BryanWilhite/Songhay.Publications/issues/38) to embrace LiteDB ([GitHub](https://github.com/mbdavid/litedb)) which is really a move toward the MongoDB space, specifically the [Azure Cosmos DB API for MongoDB](https://docs.microsoft.com/en-us/azure/cosmos-db/introduction). Much of this enthusiasm comes from exporting the legacy, GenericWeb SQL Azure databases into gigabytes of JSON by using the relatively new JSON export feature in [SQL Database Query Editor](https://azure.microsoft.com/en-us/blog/t-sql-query-editor-in-browser-azure-portal/) under the Azure portal. Exporting this data so trivially is a major milestone for myself _and_ Microsoft.🤠

## the `lit-html`-based responsive layouts are done, but…

…but 🐇🕳 using `lit-html` in production _for an Index_ is yet another SEO nightmare waiting to happen (but it is great to have when playing around with CSS). This means I have to add an `eleventy`-based version and make sure the static JSON in play looks like `IndexEntry` introduced last month:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<Document>[];
}
```

The formal definition of `IndexEntry` has an [issue out](https://github.com/BryanWilhite/songhay-core/issues/24), waiting. And there is a relatively subtle relationship between `IndexEntry` and the Publications `Segment` (GitHub), crossing the boundary between Typescript and C#, for which I should make notes as a kind sequel to “[Songhay Publications and the Concept of the Index](http://songhayblog.azurewebsites.net/entry/2020-12-24-songhay-publications-and-the-concept-of-the-index).” In the meantime, there is [a closed issue](https://github.com/BryanWilhite/Songhay.Publications/issues/37) that would spark discussion.

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
