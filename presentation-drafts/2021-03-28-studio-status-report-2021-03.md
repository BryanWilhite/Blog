---json
{
  "documentId": 0,
  "title": "studio status report: 2021-03",
  "documentShortName": "2021-03-28-studio-status-report-2021-03",
  "fileName": "index.html",
  "path": "./entry/2021-03-28-studio-status-report-2021-03",
  "date": "2021-03-28T22:48:37.448Z",
  "modificationDate": "2021-03-28T22:48:37.448Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-03-28-studio-status-report-2021-03",
  "tag": "{\n  \"extract\": \"\"\n}"
}
---

# studio status report: 2021-03

## month 03 of 2021 was about regrouping around Publications

The phrase ‘regrouping around Publications’ is a fluffy cloud of words 🌩 hovering over hard changes:

- retiring the private `Songhay.GenericWeb` repo 🚜🔥 and building out the private `Songhay.Publications.KinteSpace` repo 🚜✨
- enforcing a CQRS-ish principle in the b-roll repo 🔨 🚜🔥
- addressing b-roll repo TODOs by releasing a new package for `Songhay.Publications` 📦🚀
- enforcing the design choice that `Activities` must encapsulate as much logic as possible, starting with the b-roll repo 🚜🔥

### retiring the private `Songhay.GenericWeb` repo 🚜🔥 and building out the private `Songhay.Publications.KinteSpace` repo 🚜✨

After over 20 years the terms `gen-web` and `GenericWeb` are no more! This change represents the move away from relational data support and repository-patterning as an ongoing study. Ironically, I am using an ER diagram to sketch out the document-database, no-SQL schema that should be the future of this Studio:

![the document-database, no-SQL schema](../presentation/image/day-path-2021-03-29-19-17-04.png)

My plan is to use [LiteDB](https://www.litedb.org/)—a lightweight, embedded .NET document database—which should meet my apparently limited needs. The development schedule below has been revised to reflect this massive change.

## sketching out a development schedule (revision 15)

The schedule of the month:

- ~~add Stills API to `Songhay.Player` (b-roll player) 🕸🌩~~
- incorporate LiteDB [🐙🐈 [GitHub](https://github.com/mbdavid/litedb)] into `Songhay.Publications.KinteSpace`
- build Web components required for new version of SonghaySystem.com 🖼
- upgrade [`songhay-ng-workspace`](https://github.com/BryanWilhite/songhay-ng-workspace) to Angular latest 📦↑
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
