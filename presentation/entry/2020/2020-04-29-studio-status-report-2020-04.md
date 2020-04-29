---json
{
  "documentId": 0,
  "title": "studio status report: 2020-04",
  "documentShortName": "2020-04-29-studio-status-report-2020-04",
  "fileName": "index.html",
  "path": "./entry/2020-04-29-studio-status-report-2020-04",
  "date": "2020-04-29T16:52:35.482Z",
  "modificationDate": "2020-04-29T16:52:35.482Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-04-29-studio-status-report-2020-04",
  "tag": "{\r\n  \"extract\": \"month 4 of 2020 was about really understanding why the lunr index issue is still open Issue #25 for this Blog is still open. But this is great because I had to formally research the subject of Web Components and finally, finally learn how use webpack dire…\"\r\n}"
}
---

# studio status report: 2020-04

## month 4 of 2020 was about really understanding why the lunr index issue is still open

[Issue #25](https://github.com/BryanWilhite/Blog/issues/25) for this Blog is _still_ open. But this is great because I had to [formally research the subject of Web Components](https://github.com/BryanWilhite/nodejs/issues/18) and finally, _finally_ learn how use `webpack` [directly](https://github.com/BryanWilhite/nodejs#webpack-and-rollup-commentary) (instead of indirectly through a CLI).

This marks a return to fundamental: _progressive enhancement_. This Studio has suffered _for years_ because [progressive enhancement](https://en.wikipedia.org/wiki/Progressive_enhancement) in the world of the SPA was impossible (which is probably the result of using Angular instead of React or Vue). There were only two extremes: static documents and full-blown SPAs—_nothing_ in between. This kind of suffering is over!

## my cloud-related work from last month was useful but not quite successful

[Last month](http://songhayblog.azurewebsites.net/entry/2020-03-26-studio-status-report-2020-03), I mentioned this:

> `IActivityWithTask<TInput, TOutput>` had to be re-factored to support _multiple_, serverless Activity Function calls

One great side effect of such re-factoring is seeing general improvement of the code without regard to the specific problem. I have to mention this because I deactivated the Azure Durable Functions portion of this work in production and rolled back to Azure WebJobs.

This was done because all the work done for Durable Functions last month revealed more clearly my lack of understanding of the _replay_ concept in particular and the [event sourcing pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/event-sourcing) in general. My StackOverflow.com [question related](https://stackoverflow.com/questions/60819603/is-it-always-wrong-to-use-an-if-else-structure-inside-a-durable-orchestrat) to this lack, has not been answered to my satisfaction.

## sketching out a development schedule (revision 8)

The schedule of the month:

- build lunr index experience 🏗
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
