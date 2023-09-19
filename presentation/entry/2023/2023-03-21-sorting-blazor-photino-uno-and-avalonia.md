---json
{
  "documentId": 0,
  "title": "sorting Blazor, Photino, Uno and Avalonia",
  "documentShortName": "2023-03-21-sorting-blazor-photino-uno-and-avalonia",
  "fileName": "index.html",
  "path": "./entry/2023-03-21-sorting-blazor-photino-uno-and-avalonia",
  "date": "2023-03-22T01:14:27.528Z",
  "modificationDate": "2023-03-22T01:14:27.528Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2023-03-21-sorting-blazor-photino-uno-and-avalonia",
  "tag": "{\n  \"extract\": \"This is my first bit of prose officially recognizing that something has happened in the .NET desktop GUI space after the fall of the .NET Framework. There is life after WPF and here is one awakening to a new, cross-platform world. ## Avalonia The Avalonia…\"\n}"
}
---

# sorting Blazor, Photino, Uno and Avalonia

This is my first bit of prose officially recognizing that something has happened in the .NET desktop <acronym title="Graphical User Interface">GUI</acronym> space after the fall of the .NET _Framework_. There is life after <acronym title="Windows Presentation Foundation">WPF</acronym> and here is one awakening to a new, cross-platform world.

## Avalonia

The [Avalonia](https://www.avaloniaui.net/) space is about taking the _W_ out of <acronym title="Windows Presentation Foundation">WPF</acronym>. It is a direct replacement of <acronym title="Windows Presentation Foundation">WPF</acronym> —without recognizing the existence of the [Universal Windows Platform](https://en.wikipedia.org/wiki/Universal_Windows_Platform). To choose Avalonia is to embrace a <acronym title="Extensible Application Markup Language">XAML</acronym>-based client for an _existing_ back-end on a _classic_ desktop. My [dabbling](https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-avalonia) with Avalonia shows me it is preserving the classic <acronym title="Model–View–ViewModel">MVVM</acronym> pattern—and it supports F♯!

The JetBrains folks actually like Avalonia:

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=kZCIporjJ70">
        <img alt="Building Engaging Cross Platform Applications using Rider and Avalonia" src="https://img.youtube.com/vi/kZCIporjJ70/maxresdefault.jpg" width="640" />
    </a>
    <p><small>Building Engaging Cross Platform Applications using Rider and Avalonia</small></p>
</figure>

<figure>
    <a href="https://www.youtube.com/watch?v=q6uWPtKw3UQ">
        <img alt="Getting started with Avalonia and ReactiveUI" src="https://img.youtube.com/vi/q6uWPtKw3UQ/maxresdefault.jpg" width="640" />
    </a>
    <p><small>Getting started with Avalonia and ReactiveUI</small></p>
</figure>

</div>

## Photino

Once the novelty of releasing >100 MB applications with [Electron.NET](https://github.com/ElectronNET) wears off, Photino (<https://www.tryphotino.io>) is the fundamental particle we need to have a slimmed-down sub-feature-set of [Electron](https://www.electronjs.org/). The fact that there is a [Photino.Blazor](https://github.com/tryphotino/photino.Blazor) project strongly suggests that there can be a Bolero flavor of Photino.

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=LecE0CFpyCc">
        <img alt="Photino in Six Minutes" src="https://img.youtube.com/vi/LecE0CFpyCc/maxresdefault.jpg" width="640" />
    </a>
    <p><small>Photino in Six Minutes</small></p>
</figure>

</div>

Photino is considered by Steve Sanderson the successor of his use of `WebWindow` (see “[Meet WebWindow, a cross-platform webview library for .NET Core](https://blog.stevensanderson.com/2019/11/18/2019-11-18-webwindow-a-cross-platform-webview-for-dotnet-core/)”). This might mean that Loïc “Tarmil” Denuzière will follow up “[Desktop applications with Bolero and WebWindow](https://blog.tarmil.fr/article/2019/11/24/bolero-webwindow)” with an entry for Photino. #to-do 

## Uno

The [Uno Platform](https://platform.uno/) defines _cross-platform_ like how [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-7.0) defines cross-platform: one solution for _mobile_ platforms _first_ (and maybe some non-Windows, non-Mac desktops later).

<div style="text-align:center">

<figure>
    <a href="https://www.youtube.com/watch?v=-s5ur9pTcfs">
        <img alt="Andres Pineda - Understanding and Developing WebAssembly Apps with Uno Platform" src="https://img.youtube.com/vi/-s5ur9pTcfs/maxresdefault.jpg" width="640" />
    </a>
    <p><small>Andres Pineda - Understanding and Developing WebAssembly Apps with Uno Platform</small></p>
</figure>

</div>

## Blazor Hybrid

The interesting thing about [Blazor Hybrid](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-7.0) is its hybrid meshing with .NET MAUI _and_ <acronym title="Windows Presentation Foundation">WPF</acronym>. This approach can be regarded as Microsoft taking responsibility for the Windows platform (and its mobile concerns inspired by the iPhone and Samsung) which quietly implies the Linux desktop is left unattended.

## The .NET Core Podcast  interviews everybody

[The .NET Core Podcast](https://dotnetcore.show/) has a [whole category of interviews about Blazor](https://dotnetcore.show/categories/blazor/) and then drills down into:

- “[Episode 102 - Photino With Otto Dobretsberger](https://dotnetcore.show/episode-102-photino-with-otto-dobretsberger/)”
- “[Episode 95 - Avalonia UI with Dan Walmsley](https://dotnetcore.show/episode-95-avalonia-ui-with-dan-walmsley/)”
- “[Episode 60 - Uno Platform With Jérôme Laban](https://dotnetcore.show/episode-60-uno-platform-with-jerome-laban/)”

<https://github.com/BryanWilhite/>
