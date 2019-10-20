---json
{
  "documentId": 0,
  "title": "Windows 10 VM Setup",
  "documentShortName": "2015-08-01-windows-10-vm-setup",
  "fileName": "index.html",
  "path": "./entry/2015-08-01-windows-10-vm-setup",
  "date": "2015-08-02T01:59:53.633Z",
  "modificationDate": "2015-08-02T01:59:53.633Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-08-01-windows-10-vm-setup",
  "tag": "{\r\n  \"extract\": \"In under three days, my Microsoft-based, virtual development environment has moved to Windows 10 Enterprise. What follows are my relatively secure notes to self that may be helpful to others.A generic VMware Windows 10 Enterprise x64 image was built. A c...\"\r\n}"
}
---

In under three days, my Microsoft-based, virtual development environment has moved to Windows 10 Enterprise. What follows are my relatively secure notes to self that may be helpful to others.

A generic VMware **Windows 10 Enterprise x64** image was built. A copy was moved into `\VMware\songhay11v` along with a copy of `SonghayHomeDrive.vmdk`. I eventually activated Windows manually by entering my MSDN reserved product code (`SLUI.EXE`).

## Wrestling with OneDrive

I tried and failed to move the default OneDrive folder to `\dataRoot\OneDrive`. I confused the moving of the “My Documents” folder to OneDrive. It is an error to use the OneDrive root as a standard “My Documents” folder. OneDrive attempted a sync operation when it was not pointing at the correct location on my `SonghayHomeDrive` volume. The Recent docs list in the cloud emptied and for a second I thought I lost everything!

## Changes to the shares layout

This is a sketch of the new layout:

```plaintext
\appRoot
\dataRoot
\sourceRoot
\util
\webRoot
```

Added `\appRoot` to anticipate mirroring in the cloud as a full (Nano-server?) VM and/or a Docker-like container.

Added `sourceRoot\songhay-system` for what is currently under TFS (which is just about everything). What was called ‘Projects (public)’ is now called `\sourceRoot\samples`. It turns out that the [Bing Developer Assistant](https://channel9.msdn.com/Shows/Visual-Studio-Toolbox/Bing-Developer-Assistant) has a “samples” concept as well, so I changed settings in VS2015 to point to `\sourceRoot\samples`.

The `\util` folder is almost empty (and many, many binaries were removed from `\sourceRoot\samples`) as many of these things were superseded by Chocolatey running under OneGet.
[<img alt="OneGet Experimental Build Splash" src="https://farm1.staticflickr.com/541/20155687415_1d9c8dcdba_m_d.jpg">](https://www.flickr.com/photos/wilhite/20155687415/in/dateposted-public/ "OneGet Experimental Build Splash")

## Getting the “experimental” OneGet installer

The version of OneGet shipping with Windows 10 does not support Chocolatey. So I’ve taken the risk and downloaded [the “experimental” build](https://github.com/OneGet/oneget) from GitHub. After the “experiment” is installed, there are some instructions to follow to get OneGet running. The only accurate instructions I’ve seen for the latest build are [displayed in a dialog](https://www.flickr.com/photos/wilhite/20155687415/in/dateposted-public/) just before the `*.exe` installs. Here are the instructions in my own words: in an administrator-level session of PowerShell enter:

```powershell
Set-ExecutionPolicy Unrestricted
Import-Module oneget-edge
# run Install-Package foo a bunch of times
Set-ExecutionPolicy RemoteSigned
```

## Got Chocolatey?

There are [several packages for Sublime Text 2/3](https://chocolatey.org/packages?q=sublime) but I’ll need to get back to this to make a detail-based decision on which ones to take.

<table class="WordWalkingStickTable"><tr><td>
Application
</td><td>
Package?
</td></tr><tr><td>
Piriform Defraggler
</td><td>

[Defraggler 2.19.982](https://chocolatey.org/packages/defraggler) [ `defraggler` ]

</td></tr><tr><td>
CCleaner
</td><td>

[CCleaner 5.08.5308](https://chocolatey.org/packages/ccleaner) [ `ccleaner` ]

</td></tr><tr><td>
7-Zip
</td><td>

[7-Zip (Install) 9.38](https://chocolatey.org/packages/7zip.install) [ `7zip.install` ]

</td></tr><tr><td>
Sysinternals Suite
</td><td>

[Sysinternals 2015.07.20](https://chocolatey.org/packages/sysinternals) [ `sysinternals` ]

</td></tr><tr><td>
Microsoft Web Platform Installer
</td><td>

[WebPI (Platform Installer) 5.0](https://chocolatey.org/packages/webpi) [ `webpi` ]

</td></tr><tr><td>
cwRsync
</td><td>

[cwRsync Free edition 5.4.1](https://chocolatey.org/packages/cwrsync) [ `cwrsync` ]

</td></tr><tr><td>
Git (for Windows)
</td><td>

[Git (Install) 1.9.5.20150320](https://chocolatey.org/packages/git.install) [ `git.install` ]

This package will not install the **Git Bash** shortcut from the original distribution on Windows 10. The shortcut target is `"%ProgramFiles(x86)%\Git\bin\sh.exe" --login -i`.
</td></tr><tr><td>
Node JS
</td><td>

[Node JS (Install) 0.12.7](https://chocolatey.org/packages/nodejs.install) [ `nodejs.install` ]

</td></tr><tr><td>
<span style="text-decoration:line-through;">CloudBerry Explorer</span>
</td><td>
[<span style="text-decoration:line-through;">CloudBerry Explorer for Microsoft Azure Cloud Storage 2.1.2.58</span>](https://chocolatey.org/packages/CloudBerryExplorer.AzureStorage)<span style="text-decoration:line-through;"> [ </span>``<span style="text-decoration:line-through;">]</span>

This package did not install correctly (for me) and it has not been approved by moderators.
</td></tr><tr><td>
Notepad++
</td><td>

[Notepad++ 6.8](https://chocolatey.org/packages/notepadplusplus) [ `notepadplusplus` ]

</td></tr><tr><td>
FileZilla
</td><td>

[FileZilla 3.12.0.2](https://chocolatey.org/packages/filezilla) [ `filezilla` ]

</td></tr><tr><td>
WinMerge
</td><td>

[winmerge 2.14.0](https://chocolatey.org/packages/winmerge) [ `winmerge` ]

</td></tr><tr><td>
IrfanView
</td><td>

[IrfanView 4.38](https://chocolatey.org/packages/irfanview) [ `irfanview` ]

</td></tr><tr><td>
NAnt
</td><td>

[NAnt—A .NET Build Tool 0.92.1](https://chocolatey.org/packages/NAnt) [ `nant` ]

</td></tr></table>

## ‘Unmanaged’ Utilities

Here’s a short list of applications that I had to install (or consider installing) by hand:

**ExpanDrive2.** As of this writing there is [a version 3](http://www.expandrive.com/) of this retail product but I’ll hold out for the time being.

**OpenXML SDK2.5 Productivity Tool.** This is an old set of tools used with my <acronym title="Visual Studio Tools for the Microsoft Office System">VSTO</acronym> work.

**Visual Studio 2015 Professional.** This manual install came from an `*.iso` of my MSDN subscription among my employee benefits of the moment.
[<img alt="My VS2015 install failed to install Win10 SDK" src="https://farm1.staticflickr.com/462/20147602842_82db9429ef_z_d.jpg">](https://www.flickr.com/photos/wilhite/20147602842/in/dateposted-public/ "My VS2015 install failed to install Win10 SDK")

**Windows Software Development Kit (SDK) for Windows 10.** My successful install left me with a “[this installer failed message](https://www.flickr.com/photos/wilhite/20147602842/in/dateposted-public/)” for Windows 10 SDK. So, after not finding the Windows 10 SDK via the Web Platform Installer, I went to Bing and found it [on dev.windows.com](https://dev.windows.com/en-US/downloads/windows-10-sdk).

**Office 365!** A previous employer “gave” me a copy of Microsoft Office that I’ve been using for quite some time. I did not realize *then* that I was using Office 365. So now I have my “personal edition” of Office 365—and all of my old VSTO stuff just works.

@[BryanWilhite](https://twitter.com/BryanWilhite)
