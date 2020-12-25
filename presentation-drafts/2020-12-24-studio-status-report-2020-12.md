---json
{
  "documentId": 0,
  "title": "studio status report: 2020-12",
  "documentShortName": "2020-12-24-studio-status-report-2020-12",
  "fileName": "index.html",
  "path": "./entry/2020-12-24-studio-status-report-2020-12",
  "date": "2020-12-25T01:01:14.984Z",
  "modificationDate": "2020-12-25T01:01:14.984Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-12-24-studio-status-report-2020-12",
  "tag": "{\n  \"extract\": \"month 12 of 2020 was about the data behind the Index layout I have always been fractal with the rabbit holes 🐇🕳 I may break things but I do not move “fast.” I got “lost” this month in formally thinking about the data I would be using to drive the displa…\"\n}"
}
---

# studio status report: 2020-12

## month 12 of 2020 was about _the data_ behind the Index layout

I have always been fractal with the rabbit holes 🐇🕳 I may break things but I do not move “fast.” I got “lost” this month in formally thinking about the data I would be using to drive the display of [the index layout work](https://github.com/BryanWilhite/nodejs/tree/master/responsive-layouts) from last month.

I have written “[Songhay Publications and the Concept of the Index](http://songhayblog.azurewebsites.net/entry/2020-12-24-songhay-publications-and-the-concept-of-the-index/)” to really think about Index data. This discussion with myself produced these Studio novelties:

```typescript
interface IndexEntry extends Partial<Segment> {
  segments?: IndexEntry[];
  documents?: Partial<Document>[];
}

interface SearchIndexEntry extends Partial<Document> {
  string extract;
}
```

## the first dedicated Linux workstations in the Studio

For most of 2018 and almost all of 2019, I suffered with Hyper-V-related and VirtualBox-related crashes in Windows 10. I assume these crashes were largely related to my use of AMD-based hardware. Nevertheless, I took these rude interruptions as a prompt for me to move my Ubuntu-desktop-based workflows (featuring Visual Studio Code) to real hardware. I have been experimenting with Linux on Windows-hosted VMs since the early 2000s. The time to move on was long gone: I went with the ASUS PB50 Barebone MiniPC with AMD Ryzen 7 3750H [[NewEgg](https://www.newegg.com/asus-pb50-bbr009md/p/N82E16856110195?Description=ryzen%20mini%20pc&cm_re=ryzen_mini%20pc-_-9SIAB94BEN4139-_-Product), [Amazon](https://www.amazon.com/ASUS-Integrated-Radeon-DisplayPort-Bluetooth-PB50-BBR009MD/dp/B081B5QTCY/ref=pd_di_sccai_1/144-7585039-8084019?_encoding=UTF8&pd_rd_i=B081B5QTCY&pd_rd_r=2afe08bc-a6cd-401f-945c-18ad7d585ff8&pd_rd_w=HdGbL&pd_rd_wg=DT0zi&pf_rd_p=c9443270-b914-4430-a90b-72e3e7e784e0&pf_rd_r=43VPS6PTTGJ1KMY54JQV&psc=1&refRID=43VPS6PTTGJ1KMY54JQV)].

## the ‘pressure’ is on to upgrade to .NET 5

This is a common occurrence in this Studio: Project _A_ takes so long that Project _B_ (which is queued behind _A_) _must_ be done. For the “10x developer” that does almost nothing in their life but work on .NET, it should have been super-duper obvious to me that when .NET Core 2.2 went to end-of-life ([announced this month last year](https://devblogs.microsoft.com/dotnet/net-core-2-2-will-reach-end-of-life-on-december-23-2019/)) I should have upgraded everything to .NET 3.0.

In [.NET Rocks! #1719](https://www.dotnetrocks.com/?show=1719), Scott Hunter is basically saying (towards the end of the episode) that, going forward from .NET 5.0, upgrades should be easy and _expected_. When a development team uses a LTS version of any software, updates are part of the deal. The practice of writing software and stuffing it away and never looking at it again is only something the people that sign the checks of developers can do and still regard themselves as _professional_. So I need to be more professional here.

The end-of-life announcement did not make me upgrade. What is pressuring me is the embarrassingly recent discovery (in 2020) that Visual Studio 2019 with .NET 5 _should_ no longer need the `x86` version of the .NET Core SDK to run tests in the IDE correctly. Finding documentation on this issue is challenging because “everyone” (myself included) is using Visual Studio Code _more_ than Visual Studio. The one low-hanging hint out there is the fact that a version of the .NET 5 SDK ships with Visual Studio 2019.

## day-job drama: needing to know what happened between .NET 4.5.x and 4.6.x

Unless I am deeply mistaken—and I _can_ be deeply mistaken, having the latest version of Visual Studio (or the equivalent SDK) allows us to compile “down” any advanced syntax to earlier versions of .NET. The problem with day-job drama is not knowing whether everyone on the “team” is using the ‘right’ version of Visual Studio. This annoying concern has led me to carefully study “[What’s new in .NET Framework](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/)” and “[The history of C#](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-50)” (with a little [help from Wikipedia](https://en.wikipedia.org/wiki/C_Sharp_(programming_language))) to arrange an eye-opening table:

| framework version | release year | framework summary | C#  summary |
|- |- |- |-
| 4.8 | 2019 | Major work on the [CLR](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#common-language-runtime), cryptography, WCF and WPF ([High DPI](https://docs.microsoft.com/en-us/windows/win32/hidpi/high-dpi-desktop-application-development-on-windows))| **C# 8.0** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-80)]: `null`-coalescing assignment (`??=`) [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#null-coalescing-assignment)], ‘more’ pattern-matching [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#more-patterns-in-more-places)], `static` local functions [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions)], enhancement to interpolated verbatim strings [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#enhancement-of-interpolated-verbatim-strings)]
| 4.7.2 | 2018 | Major work on cryptography, [ASP.NET](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#aspnet), [SQLClient](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#sqlclient), [WPF](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#windows-presentation-foundation) and ClickOnce | **C# 7.3** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-73)]
| 4.7.1 | 2017 | Support added for .NET Standard 2.0; major work on the [CLR](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#common-language-runtime-clr) and [ASP.NET](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#aspnet-1) | **C# 7.0** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-70), Visual Studio 2017], **7.1** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-71)], **7.2** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-72)]: tuples and deconstruction [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#tuples-and-discards)], discards, pattern matching [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#pattern-matching)], local functions [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#local-functions)], `out` variables [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#out-variables)], “more” expression-body members [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#more-expression-bodied-members)]
| 4.7 | 2017 | Major work on [ASP.NET](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#aspnet-2) (Object Cache Extensibility) WCF, Windows Forms (High DPI) and [WPF](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#windows-presentation-foundation-wpf-1) (touch/stylus stack)
| 4.6.2 | 2016 | Major work on [ASP.NET](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#aspnet-3), [Unicode](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#character-categories), cryptography, [SqlClient](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#sqlclient-1), WCF, [WPF](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#windows-presentation-foundation-wpf-2), WF, ClickOnce and [UWP](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#converting-windows-forms-and-wpf-apps-to--uwp-apps)
| 4.6.1 | 2015 | Major work on cryptography, [ADO.NET](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#adonet), [WPF](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#windows-presentation-foundation-wpf-3), WF (transactions) and [profiling](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#profiling)
| 4.6 | 2015 | release of [ASP.NET Core](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#whats-new-in-net-2015), [.NET Native](https://docs.microsoft.com/en-us/dotnet/framework/net-native/getting-started-with-net-native) and `IReadOnlyCollection<T>`; major work on cryptography, GC, WCF WF and WPF | **C# 6.0** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-60), Visual Studio 2015]: `nameof()`, `$` string interpolation [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)], expression-body members [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition)], auto-property initializers [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/properties)], , Null-conditional operators `?.` (“Elvis” operator) and `?[]` [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)], `when` in a `catch` statement (exception filters) [[📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/when#when-in-a-catch-statement)], `using static` (static imports) [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-static)]
| 4.5.2 | 2014 | major work on [ASP.NET](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#whats-new-in-net-framework-452)
| 4.5.1 | 2013 | tied to [Visual Studio 2013 Update 2](https://go.microsoft.com/fwlink/p/?LinkId=393658); announced “async-aware debugging” and “Edit and Continue for 64-bit apps”
| 4.5 | 2012 | introduced background just-in-time (JIT) compilation and parallelism; major work on GC and [MEF](https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#managed-extensibility-framework-mef) | **C# 5.0** [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-50), Visual Studio 2012]: `async`-`await` and caller attributes [📖 [docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information)]

😲💡 It is clear to me now that .NET Framework 4.7.1 (and everyone on _at least_ Visual Studio 2017) is the sweet spot for teams with heavy legacy load as they can iteratively move most library projects to .NET Core, targeting .NET Standard while still staying with the “old” .NET Framework.

BTW: since recruiters ask me this question too often, I need to recall that I probably started using the .NET Framework in 2003 when version 1.1 was released [[Wikipedia](https://en.wikipedia.org/wiki/.NET_Framework_version_history)].

## sketching out a development schedule (revision 11)

The schedule of the month:

- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- consider upgrading to .NET Core 3.0
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
