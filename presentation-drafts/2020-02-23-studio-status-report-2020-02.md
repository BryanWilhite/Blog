---json
{
  "documentId": 0,
  "title": "studio status report: 2020-02",
  "documentShortName": "2020-02-23-studio-status-report-2020-02",
  "fileName": "index.html",
  "path": "./entry/2020-02-23-studio-status-report-2020-02",
  "date": "2020-02-23T17:02:46.406Z",
  "modificationDate": "2020-02-23T17:02:46.406Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-02-23-studio-status-report-2020-02",
  "tag": "{\r\n  \"extract\": \"month 2 of 2020 is about moving sideways into day-job, onboarding drama I pushed a bunch of 2020-02 commits to my LinqPad repo that betray how much I forgot about ASP.NET MVC 5. My need to even care about MVC 5 further betrays the needs of the day job. I …\"\r\n}"
}
---

# studio status report: 2020-02

## month 2 of 2020 is about moving sideways into day-job, onboarding drama

I pushed [a bunch of 2020-02 commits](https://github.com/BryanWilhite/LinqPad/graphs/commit-activity) to my `LinqPad` repo that betray how much I forgot about ASP.NET MVC 5. My need to even care about MVC 5 further betrays the needs of the day job. I have taken these needs and transformed them into an opportunity for me to finally commit my MVC 5 understandings to a repository. My last attempt to seriously study ASP.NET MVC 5 predates the use of GitHub in my practice and my notes were actually written on paper, transferred from my _chalkboard_.

ASP.NET MVC 5 is significantly hostile to mocking and it misleads one to dedicate way too much [Ballmer-era](https://www.theguardian.com/technology/2013/aug/23/microsoft-ceo-steve-ballmer-critics) Windows infrastructure just to play around with it. (For example, when one sees that `Microsoft.AspNet.Hosting` was [left in beta in 2015](https://www.nuget.org/packages/Microsoft.AspNet.Hosting/1.0.0-beta7); for another example, [mocking](https://github.com/BryanWilhite/LinqPad/blob/master/Queries/funkyKB/ASP.NET%20MVC%20-%20Model%20binding%20with%20JsonValueProvider%20and%20Moq.linq#L44) `HttpContextWrapper` is _not_ trivial) one could just throw up hands in an emotional outburst and install IIS Express or worse). It is therefore a bit of an achievement (for me) to see bits of MVC running in memory on LinqPad.

## plugging `Songhay.Player.Activities` into Azure Functions did not make a perfect fit

The [significant achievement of 2020-01](http://songhayblog.azurewebsites.net/entry/2020-02-08-studio-status-report-2020-01/) was not a slam dunk. Fanning out over a set of function calls is not scalable as the set of calls grows linearly (_O_(_n_)). When completing all of the calls takes longer than the default 10-minute limit, the orchestration behaves in unexpected ways. The Player YouTube indices are not being updated (this update only runs when all of the calls run). Moreover, there is a possibility that an individual call could hang and eat into the 10-minute limit. There should be a mechanism that limits how much time an individual call takes.

I think the solution to this _O_(_n_) problem is to partition the calls into subsets and increase the frequency the entire job runs. Every time the job runs it cycles through each partition and updated the indices. I assume that the partition data can be stored with the relatively new [Durable Entity](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-entities?tabs=csharp).

## overestimating the time available for the lunr index issue

[Issue #25](https://github.com/BryanWilhite/Blog/issues/25) for this Blog was opened while I was unemployed. I assume this could be knocked out “off the books” (without the need to mention it in this status report). I overestimated how much time would be available while I was unemployed (because I took multiple meetings with potential employers per week for an entire month).

## sketching out a development schedule (revision 6)

Today, the studio development schedule looks like this:

* ~~build out `Songhay.Player.Activities` and plug into Azure Functions~~ ✔
* ~~build out `Songhay.Social.Activities` (automated social-media posting) and plug into Azure Functions~~ 🤖🌩
* address `Songhay.Player.Activities` _O_(_n_) problem 🤖🌩
* build lunr index experience 🏗
* use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
* add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
* use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
* modernize the kinté hits page into a progressive web app 💄✨
* convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
* use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
