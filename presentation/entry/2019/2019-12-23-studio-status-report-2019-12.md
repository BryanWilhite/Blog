---json
{
  "documentId": 0,
  "title": "studio status report: 2019-12",
  "documentShortName": "2019-12-23-studio-status-report-2019-12",
  "fileName": "index.html",
  "path": "./entry/2019-12-23-studio-status-report-2019-12",
  "date": "2019-12-23T18:18:27.986Z",
  "modificationDate": "2019-12-23T18:18:27.986Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2019-12-23-studio-status-report-2019-12",
  "tag": "{\r\n  \"extract\": \"month 12 is about firmly planting the Songhay System in the serverless cloud game Issue #83 in the Songhay Core represents the final touches on the Activity architecture that is the heart of the Songhay System. Thirteen years ago I made first mention of t…\"\r\n}"
}
---

# studio status report: 2019-12

## month 12 is about firmly planting the Songhay System in the serverless cloud game

Issue [#83](https://github.com/BryanWilhite/SonghayCore/issues/83) in the Songhay Core represents the final touches on the `Activity` architecture that is the heart of the Songhay System. Thirteen years ago I made [first mention](http://kintespace.com/rasxlog/entry/2006-05-24-more-technical-misses-by-bryan/) of the Data Activity Runner and only now can I consider this architecture complete. I _could_ argue that the 13-year lag came from waiting for `async`-`await` to [appear](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)#Versions) c. 2012 in C# 5 (and, by the way, `Task<T>` came out in C# 4, 2010) but that would leave at least _seven years_ for me to figure this shit out. No, the real credit goes to [David Maciel](https://www.linkedin.com/in/damaciel/) from one of my day jobs. My one little architecture looks nothing like his several _architectures_ but his advice to me (given in less than 15 minutes) changed everything for the better.

The `Activity` is now being called every 12 hours to update my curated collection of YouTube channels. This is taking place in the serverless space Microsoft calls [Azure Durable Functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview?tabs=csharp). The _durable_ part of Azure Functions builds on top of Azure [WebJobs](https://docs.microsoft.com/en-us/azure/app-service/webjobs-create) which I have been using since before 2017 (Magnus Mårtensson [announced](https://www.youtube.com/watch?v=I6YfdTWvhMk) general availability in 2014).

## getting the `@songhay/index` as a side-car app is not trivial

Before `@songhay/index` as a side-car app is in play, the `lunr` auto-complete experience has to be established. Before the `lunr` thing can play, the backend index data needs a pipeline. That’s two rabbit holes! 🕳🐰X2

## the Songhay Stills API will add progressive image support to the Studio

The b-roll Stills API will be the heart of the Songhay Studio online presence. Every image shown by Songhay System should go through this API.

endpoint | plan
- | -
`/api/player/v1/stills/{id}/srcset-sizes` | Should return some JSON describing all the responsive images of the specified ID.
`/api/player/v1/stills/{presentationKey}/frames` | Should return some JSON describing all the frames of a presentation. The data should contain a rollup of the equivalent of several srcset-sizes calls.

💡the data might contain URIs pointing to a CDN or BLOB storage

🐰🕳the data might contain some kind of guided-view declarations

So, this is the reason why none of my new Web sites have so few images. This thing needs to be built.

## sketching out a development schedule (revision 6)

Today the studio development schedule looks like this:

* ~~build out `Songhay.Player.Activities` and plug into Azure Functions~~ ✔
* build out `Songhay.Social.Activities` (automated social-media posting) and plug into Azure Functions 🤖🌩
* add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
* use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
* use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
* modernize the kinté hits page into a progressive web app 💄✨
* convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
* use the learnings of previous work to upgrade and re-release the kinté space 🚀

<https://github.com/BryanWilhite/>
