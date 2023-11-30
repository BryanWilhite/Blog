---json
{
  "documentId": 0,
  "title": "studio status report: 2023-11",
  "documentShortName": "2023-11-29-studio-status-report-2023-11",
  "fileName": "index.html",
  "path": "./entry/2023-11-29-studio-status-report-2023-11",
  "date": "2023-11-30T02:43:13.441Z",
  "modificationDate": "2023-11-30T02:43:13.441Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2023-11-29-studio-status-report-2023-11",
  "tag": "{\n  \"extract\": \"month 11 of 2023 was about releasing Songhay.Player.ProgressiveAudio and returning to SQL Server Songhay.Player.ProgressiveAudio is released and running on kintespace.com. This release was only ‘half’ of what is needed to completely replace http://kintesp…\"\n}"
}
---

# studio status report: 2023-11

## month 11 of 2023 was about releasing `Songhay.Player.ProgressiveAudio` and returning to SQL Server

`Songhay.Player.ProgressiveAudio` is released and running [on kintespace.com](http://kintespace.com/b-roll/audio/default). This release was only ‘half’ of what is needed to completely replace `http://kintespace.com/player.html`. The other ‘half’ includes:

- `Songhay.Modules` release 6.4.0 📦🚀 [[GitHub](https://github.com/users/BryanWilhite/projects/26)]
- `Songhay.Modules.Bolero` release 6.4.0 📦🚀 [[GitHub](https://github.com/users/BryanWilhite/projects/27)]
- `Songhay.Player.YouTube` release 6.3.0 📦🚀 [[GitHub](https://github.com/users/BryanWilhite/projects/25)]

The entire stack under `Songhay.Player.YouTube` has be touched to capture the release of [F# 8](https://devblogs.microsoft.com/dotnet/announcing-fsharp-8/).

To service the day job (and my personal study), I am pleased to see the return of Microsoft SQL Server to my Studio. The following Jupyter notebooks were published because of this great change:

- “[`OPENJSON` and `JSON_QUERY`](https://github.com/BryanWilhite/jupyter-central/blob/master/funkykb/t-sql/openjson-and-json_query.ipynb)”
- “[`OPENJSON` and `CROSS APPLY`](https://github.com/BryanWilhite/jupyter-central/blob/master/funkykb/t-sql/openjson-and-cross-apply.ipynb)”
- “[recursive CTEs](https://github.com/BryanWilhite/jupyter-central/blob/master/funkykb/t-sql/recursive-ctes.ipynb)”

In addition to the notes above are the usual Obsidian notes. The Obsidian visualization for month 11 is:

![Obsidian visualization for month 11](../presentation/image/day-path-2023-11-29-19-31-54.png)

Selected notes:

## [[Bolero]]: “Advanced Blazor State Management Using Fluxor”

I think that an article like “[Advanced Blazor State Management Using Fluxor](https://dev.to/mr_eking/advanced-blazor-state-management-using-fluxor-part-1-696)” will verify that the [[Elmish]] piece of [[Bolero]] eliminates the need for something like [[Fluxor]] \[🔗 [GitHub](https://github.com/mrpmorris/Fluxor) \].

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=sAyH-O0dFaI">
        <img alt="Fluxor + C#9 - Redux Pattern in Blazor WebAssembly" src="https://img.youtube.com/vi/sAyH-O0dFaI/maxresdefault.jpg" width="480" />
    </a>
    <p><small>Fluxor + C#9 - Redux Pattern in Blazor WebAssembly</small></p>
</figure>

</div>

## [[dotnet|.NET]] Interactive repo docs have been improved!

I notice these docs are in [[markdown]] format:

<https://github.com/dotnet/interactive/tree/main/docs>

Highlights:

- at the beginning of this year a [FAQ doc](https://github.com/dotnet/interactive/blob/main/docs/FAQ.md) was added 🏁
- 🤓 “.NET interactive kernel already supports connecting to any Jupyter kernel as a sub kernel.” \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/adding-jupyter-kernels.md) \]
- the `dotnet interactive` <acronym title="Command Line Interface">CLI</acronym> \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/command-line-interface.md) \]
- 🤓 “You can create extensions for .NET Interactive in order to create custom experiences including custom visualizations, new magic commands, new subkernels supporting additional languages, and more.” #to-do \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/extending-dotnet-interactive.md) \]
- The `#!import` magic command \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/import-magic-command.md) \] was always there but I did not really know what ti did.
- To share values between JavaScript cells, “Declare your JavaScript variables without using a keyword such as `let`, `const`, or `var`…” 🤓 \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/javascript-overview.md) \]
- To display JavaScript-cell data, the `return` keyword has be used 😐 \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/javascript-overview.md#return-values) \] 🤓
- along with `require` there is `import` for ES5 modules \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/javascript-overview.md#using-import) \]
- “[.NET Interactive Architectural Overview](https://github.com/dotnet/interactive/blob/main/docs/kernels-overview.md)” is definitely new
- a clear explanation of `#!set` \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/variable-sharing.md#set-a-variable-from-a-value-directly) \]
- an even clearer explanation of `#!connect` (and no suggestion that connection strings can be obfuscated 😐) \[📖 [docs](https://github.com/dotnet/interactive/blob/main/docs/working-with-data.md) \] 🤓

## `Microsoft.AspNetCore.Mvc.Testing` 📦 #day-job

My main purpose for using `Microsoft.AspNetCore.Mvc.Testing` \[🔗 [NuGet](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing) \] is to get the [[ASP.NET]] “service provider” that will go to production instead of rolling some stuff 💩 together for testing only.

I need to remember the importance of setting up `IServiceScope` \[📖 [docs](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0#customize-the-client-with-withwebhostbuilder) \] before trying to get a service:

```csharp
using var scope = _factory.Services.CreateScope();

IMyRepo? repo = scope.ServiceProvider.GetRequiredService<IMyRepo>();
```

The strongly-typed `GetRequiredService<TDep>()` method will be impossible to find and call without setting up a `scope`.

## more #day-job disappointment from [[xUnit]] 😐  #make-blog-post

The “philosophy” of [[xUnit]] is based on _you_ using the default features of [[dotnet|.NET]] instead of leveraging some kind feature-rich custom <acronym title="Application Programming Interface">API</acronym>. This “philosophy” slapped me in the face again when I discovered that my ordered tests were not stopping when one of them fails.

An [[xUnit]] issue from 2016, “[Should be able to Cancel ordered tests collection run on first fail #856](https://github.com/xunit/xunit/issues/856),” was closed by a bot 🤖 based on its age 😐

I reached back into my <acronym title="Windows Presentation Foundation">WPF</acronym> experience to expect some kind of `AppDomain`-level exception watcher and it turns out there has been one since [[dotnet|.NET]] Core 2.x, `AppDomain.FirstChanceException`:

>Occurs when an exception is thrown in managed code, before the runtime searches the call stack for an exception handler in the application domain.
>
>…This event is only a notification. Handling this event does not handle the exception or affect subsequent exception handling in any way.
>
>—[learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/api/system.appdomain.firstchanceexception?view=net-7.0#system-appdomain-firstchanceexception)
>

The `AppDomain` event I used in my <acronym title="Windows Presentation Foundation">WPF</acronym> days was `AppDomain.UnhandledException` \[📖 [docs](https://learn.microsoft.com/en-us/dotnet/api/system.appdomain.unhandledexception?view=net-7.0) \] which is needed to hide errors from users. With `FirstChanceException` there is no risk of hiding/swallowing or not seeing exceptions which is great for automated tests.

`FirstChanceException` can be used in a test base class to set a `static protected` logic-gate field to signal to the sub-class that an exception has occurred. This field can be checked _before_ a test method runs with `Assert`—and this check has to be called _explicitly_ in _every_ test method because remember [[xUnit]] disappoints _by design_.

### what about the `BeforeAfterTestAttribute`❓

The `BeforeAfterTestAttribute` \[🔗 [GitHub](https://github.com/xunit/xunit/blob/4fade5bc7d5fe2128af051983ff0b44141f5e2ff/src/xunit.v3.core/Sdk/BeforeAfterTestAttribute.cs#L12) \] passes _no_ information about test runs. It only passes reflection data about the adorned method 😐 There is [a StackOverflow question](https://stackoverflow.com/questions/49442237/how-can-i-pass-xunit-test-results-to-a-custom-attribute) from over five years ago asking for this functionality and getting no answers.

### related reading

- <https://github.com/xunit/samples.xunit>
- “[xUnit BeforeAfterTestAttribute: How to Run Code Before And After Test](https://hamidmosalla.com/2018/08/30/xunit-beforeaftertestattribute-how-to-run-code-before-and-after-test/)”
- “[xUnit: Control the Test Execution Order](https://hamidmosalla.com/2018/08/16/xunit-control-the-test-execution-order/)”

## [[howler.js]]: the [[James Simpson]] presentation makes it clear…

…actually the `audio` element (what James calls “HTML5 audio”) is _needed_ for streaming audio. He warns that the Web Audio <acronym title="Application Programming Interface">API</acronym> needs to load the _entire_ file before playing which is great for high-performance “sound sprites” (for the games he is making) but not so great for CD-quality music:

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=TxZMeFHFZmA">
        <img alt="Web Audio Made Easy with Howler JS - James Simpson: ThunderPlains 2019" src="https://img.youtube.com/vi/TxZMeFHFZmA/maxresdefault.jpg" width="480" />
    </a>
    <p><small>Web Audio Made Easy with Howler JS - James Simpson: ThunderPlains 2019</small></p>
</figure>

</div>

>[!important]
>There is no need to experiment with [[howler.js]] as long as the there is no streaming support for the Web Audio <acronym title="Application Programming Interface">API</acronym>.

## [[OpenEXR]] is _the_ compositing file format

What I thought was cool (since the turn of the century 👴) was working hard on a Photoshop composition with layers—and then opening that `*.psd` file up in [[Adobe After Effects]] to animate it.

The real world of compositing has moved on to a workflow where, say, [[Blender]] renders a scene to ILM’s [[OpenEXR]] format \[🔗 [Wikipedia](https://en.wikipedia.org/wiki/OpenEXR) \]. Here is a tutorial featuring EXR and [[DaVinci Resolve]]:

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=-UjJqwwMJc8">
        <img alt="Tutorial: Real-time EXR Workflow | DaVinci Resolve + Blender" src="https://img.youtube.com/vi/-UjJqwwMJc8/maxresdefault.jpg" width="480" />
    </a>
    <p><small>Tutorial: Real-time EXR Workflow | DaVinci Resolve + Blender</small></p>
</figure>

</div>

This EXR ‘tutorial’ juxtaposes [[Natron]] (the open source subset of Nuke) and [[Blender]]:

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=-xRXES8QEqo">
        <img alt="Why Blender Users Need To Learn Natron!! - Compositing relighting Tutorial" src="https://img.youtube.com/vi/-xRXES8QEqo/maxresdefault.jpg" width="480" />
    </a>
    <p><small>Why Blender Users Need To Learn Natron!! - Compositing relighting Tutorial</small></p>
</figure>

</div>

>OpenEXR provides the specification and reference implementation of the EXR file format, the professional-grade image storage format of the motion picture industry.
>
> The purpose of EXR format is to accurately and efficiently represent high-dynamic-range scene-linear image data and associated metadata, with strong support for multi-part, multi-channel use cases.
>
> —<https://openexr.com/en/latest/>
>

I am still ignorant enough to think that EXR is a highly technical replacement of the `*.psd` file. When this ignorance is actually reality then [[GNU Image Manipulation Program]] would save/export to this format:

>High bit depth support allows processing images with up to 32-bit per color channel precision and open/export PSD, TIFF, PNG, EXR, and RGBE files in their native fidelity. Additionally, FITS images can be opened with up to 64-bit per channel precision. 
>
>—<https://docs.gimp.org/en/gimp-introduction-history-2-10.html>
>

There is a plugin \[🔗 [GitHub](https://github.com/yorikvanhavre/gimp-exr-plugin) \] for [[GNU Image Manipulation Program]] that can _import_ `*.exr` files. This situation is similar in the world of Photoshop. The world of [[Python]] data science has Imageio:

>Website: [https://imageio.readthedocs.io/](https://imageio.readthedocs.io/)
>
>Imageio is a Python library that provides an easy interface to read and write a wide range of image data, including animated images, video, volumetric data, and scientific formats.
>
>—<https://github.com/imageio/imageio>
>

## sketching out development projects

The current, unfinished public projects on GitHub:

- replace the Angular app in `http://kintespace.com/player.html` with a Bolero app 🚜🔥
- finish the “`SonghayCore` 📦✨ release 6.0.5” [project](https://github.com/users/BryanWilhite/projects/7)
- start the “`Songhay.Publications.Models` 6.0.0” 📦🚀 [project](https://github.com/users/BryanWilhite/projects/23/views/1)

The proposed project items:

- add kinté space presentations support to `Songhay.Player.YouTube` 🔨 🚜✨
- generate Publication indices from SQLite for `Songhay.Publications.KinteSpace`
- generate a new repo with proposed name, `Songhay.Modules.Bolero.Index` ✨🚧 and add a GitHub Project
- switch Studio from Material Design to Bulma 💄 ➡️ 💄✨

<https://github.com/BryanWilhite/>
