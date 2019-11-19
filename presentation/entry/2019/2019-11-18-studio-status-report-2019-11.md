---json
{
  "documentId": 0,
  "title": "studio status report: 2019-11",
  "documentShortName": "2019-11-18-studio-status-report-2019-11",
  "fileName": "index.html",
  "path": "e:\\~sourceRoot\\Blog\\presentation\\entry\\20192019-11-18-studio-status-report-2019-11",
  "date": "2019-11-19T01:08:12.552Z",
  "modificationDate": "2019-11-19T01:08:12.552Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2019-11-18-studio-status-report-2019-11",
  "tag": "{\n  \"extract\": \"month 11 is about a day-job 🐰🕳 and the Tweeted Links Builder The day job leads me to lodge some issues, reminding me to revive and research a few things: * https://github.com/BryanWilhite/Blog/issues/15\\nhttps://github.com/BryanWilhite/Blog/issues/20 The…\"\n}"
}
---

# studio status report: 2019-11

## month 11 is about a day-job 🐰🕳 and the Tweeted Links Builder

The day job leads me to lodge some issues, reminding me to revive and research a few things:

* <https://github.com/BryanWilhite/Blog/issues/15>
* <https://github.com/BryanWilhite/Blog/issues/20>

The switch to an 11ty-based, markdown-based world means the Tweeted Links system has to get in line. The next release of `Songhay.Dashboard` [[GitHub](https://github.com/BryanWilhite/Songhay.Dashboard)] will show this move, covered in [a GitHub issue](https://github.com/BryanWilhite/Songhay.Dashboard/issues/60).

In concert, resolution of this `Blog` repo issue should allow Blogging Tweeted Links to resume in the Studio: <https://github.com/BryanWilhite/Blog/issues/18>.

## Feedly Drama

My `Blog` Atom Feed [template](https://github.com/BryanWilhite/Blog/blob/master/presentation/entry/feed.liquid) generates [valid output](http://www.feedvalidator.org/check.cgi?url=http%3A%2F%2Fsonghayblog.azurewebsites.net%2Fentry%2Ffeed.xml) but will _still_ not function correctly when imported into [Feedly](https://feedly.com). In Feedly, the article links point to the top-level web site instead of the article. As of now, I assume that Feedly’s [fetcher](https://www.feedly.com/fetcher.html) is caching a previous, incorrect version(s) of my feed (while somehow showing new entries 😑🤷‍♀️—not very likely).

Relevant quote from Feedly:

>If you have an questions or would like to get early access to the kit, please email publishers@feedly.com with information about what is driving your interest.

Research link: <https://blog.feedly.com/10-ways-to-optimize-your-feed-for-feedly/> 📚

## Azure WebJobs Drama

It helps to remind myself that the [Azure WebJob](https://docs.microsoft.com/en-us/azure/app-service/webjobs-create) investments are not even archived (online). There is a test, `ShouldZipDeploymentForAzure`, in `Songhay.Player.Shell.Tests` that points to files in a folder that is gone (as far as I know as of this writing). My intent is to move out of Azure WebJobs toward Azure Functions, calling routines in a library designed to run in the [Songhay System Shell Activities architecture](https://github.com/BryanWilhite/Songhay.HelloWorlds.Activities) (implementing `IActivity` [[GitHub](https://github.com/BryanWilhite/SonghayCore/blob/master/SonghayCore/Models/IActivity.cs)]).

All of this is important because my original design of the WebJob that updates my YouTube feeds will fail when it runs into problems with a _single_ YouTube channel. This means that one ‘bad’ channel can prevent _all_ channels from being updated. This is really becoming a problem in 2019 as more channels seem to ‘fail’ and as the YouTube API seems to be less reliable.

I have updated my schedule (below) to make `Songhay.Player.Shell.Tests` a top priority (which cuts in line ahead of my previous obligations 🙄). This prioritization recognizes my need to update my resume and canonize my day-job learnings around Azure Functions.

## sketching out a development schedule (revision 5)

Today the studio development schedule looks like this:

* ~~get 11ty pipelines running with the FunkyKB~~ ✔
* ~~migrate Thunderbird email to new Hyper-V Ubuntu VM~~ ✔
* ~~move the kinté space blog to an 11ty pipeline (this has been another emergency *for years*)~~ ✔
* ~~update SonghaySystem.com with my new `@songhay/player-video-you-tube`~~ ✔
* ~~convert the Day Path blog to 11ty~~ ✔
* ~~add markdown support to SonghaySystem.com Tweeted Links Builder~~ ✔
* build out `Songhay.Player.Shell` and plug into Azure Functions ☁🤖
* use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
* use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
* set up automated social-media posting with Azure logic apps (and Azure functions orchestration) ☁🤖
* modernize the kinté hits page into a progressive web app 💄✨
* convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
* use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/bryanwilhite)
