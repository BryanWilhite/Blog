---json
{
  "documentId": 0,
  "title": "studio status report: 2021-02",
  "documentShortName": "2021-02-27-studio-status-report-2021-02",
  "fileName": "index.html",
  "path": "./entry/2021-02-27-studio-status-report-2021-02",
  "date": "2021-02-28T02:23:03.809Z",
  "modificationDate": "2021-02-28T02:23:03.809Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-02-27-studio-status-report-2021-02",
  "tag": "{\n  \"extract\": \"month 02 of 2021 was about eleventy (11ty.dev) index layout I have spent months complaining about being stuck on the Stills API. This month is no exception but it is now clear that I am not breaking out the ‘sibling’ work items correctly. My work on the e…\"\n}"
}
---

# studio status report: 2021-02

## month 02 of 2021 was about eleventy (11ty.dev) index layout

I have spent months complaining about being stuck on the Stills API (about a few months less than _fifteen_ months). This month is no exception but it is now clear that I am not breaking out the ‘sibling’ work items correctly. My work on the [eleventy (11ty.dev) index layout](https://github.com/BryanWilhite/nodejs/tree/master/responsive-layouts/index-11ty#readme) should have been listed before (or immediately after) the Stills API item in my development schedule below.

This work is a significant breakthrough! It establishes the Publication Index in the realm of eleventy, making the upgrade of kintespace.com technically possible (with help forthcoming from LiteDB [🐙🐈 [GitHub](https://github.com/mbdavid/litedb)]).

## my first full-stack sample, featuring formly

The day-job breakthrough for month 02 is my [new Angular forms sample](https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-web-mvc-angular-forms#readme) over the .NET 5.0 flavor of ASP.NET. I am slightly embarrassed to have waited so long in my full-stack-developer career to make an HTML forms showcase for myself—because the elevator pitch for the SPA in general and Angular in particular is the Web-forms pipeline experience.

When my last day-job contract ended, I was inspired to go through a retrospective which led to these highlights:

- Akita (used on the job) [🐙🐈 [GitHub](https://github.com/datorama/akita)]
- `ui-router` (used on the job) [🐙🐈 [GitHub](https://github.com/ui-router/angular)]
- SubSink (used on the job) [🐙🐈 [GitHub](https://github.com/wardbell/subsink)]
- formly [🐙🐈 [GitHub](https://github.com/ngx-formly/ngx-formly)]

[formly](https://formly.dev/) (and perhaps later [form.io](https://www.form.io/)) supplies the motivation to work on my first full-stack demo. Thanks to [Abdellatif Ait boudad](https://github.com/aitboudad) for building a server-based, JSON-driven solution to generate Angular forms!

## seeing the end of `Newtonsoft.Json`

The formly work 🐇🕳 led to the discovery that ASP.NET of .NET 5.0 does not support `Newtonsoft.Json` by default:

>`System.Text.Json` focuses primarily on performance, security, and standards compliance. It has some key differences in default behavior and doesn't aim to have feature parity with `Newtonsoft.Json`. For some scenarios, `System.Text.Json` has no built-in functionality, but there are recommended workarounds. For other scenarios, workarounds are impractical.
>
> [📖 [docs](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to?pivots=dotnet-5-0)]

I have [an issue out](https://github.com/BryanWilhite/SonghayCore/issues/106) in `SonghayCore` to address the existence of `System.Text.Json`. I have also started to [play around](https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-tests/Songhay.DotNet/Songhay.DotNet.Tests/System.Text.Json) with `System.Text.Json` in my `dotnet-core` repo. I look forward to, say, using `BenchmarkDotNet` [🐙🐈 [GitHub](https://github.com/dotnet/BenchmarkDotNet)] to prove that `System.Text.Json` is faster than `Newtonsoft.Json` for the scenarios of concern.

## sketching out a development schedule (revision 14)

The schedule of the month:

- ~~upgrade core Studio packages to .NET Core 5.0 📦↑~~
- ~~add eleventy (11ty.dev) index layout~~
- build Web components required for new version of SonghaySystem.com 🖼
- upgrade [`songhay-ng-workspace`](https://github.com/BryanWilhite/songhay-ng-workspace) to Angular latest 📦↑
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- incorporate LiteDB [🐙🐈 [GitHub](https://github.com/mbdavid/litedb)] into `Songhay.Publications`
- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

<https://github.com/BryanWilhite/>
