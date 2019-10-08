---json
{
  "documentId": 0,
  "title": "Moving Songhay System to .NET 4.5.2 (with Serious PowerShell)",
  "documentShortName": "2016-03-25-moving-songhay-system-to-net-4-5-2-with-serious-powershell",
  "fileName": "index.html",
  "path": "./entry/2016-03-25-moving-songhay-system-to-net-4-5-2-with-serious-powershell",
  "date": "2016-03-26T05:21:44.527Z",
  "modificationDate": "2016-03-26T05:21:44.527Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-03-25-moving-songhay-system-to-net-4-5-2-with-serious-powershell",
  "tag": "{\r\n  \"extract\": \".NET 4.5.2 is the last .NET 4.5.x release before 4.6.x. It helps to remind myself that 4.5.1 and 4.5.2 were about async debugging support in the Visual Studio 2013 timeframe. Moreover, .NET 4, 4.5 and 4.5.1 are no longer supported by Microsoft.This decis...\"\r\n}"
}
---

# Moving Songhay System to .NET 4.5.2 (with Serious PowerShell)

.NET 4.5.2 is [the last .NET 4.5.x release](https://en.wikipedia.org/wiki/.NET_Framework_version_history) before 4.6.x. It helps to remind myself that 4.5.1 and 4.5.2 were about [async debugging support in the Visual Studio 2013 timeframe](https://blogs.msdn.microsoft.com/dotnet/2013/10/17/net-framework-4-5-1-rtm-start-coding/). Moreover, .NET 4, 4.5 and 4.5.1 are [no longer supported](https://blogs.msdn.microsoft.com/dotnet/2015/12/09/support-ending-for-the-net-framework-4-4-5-and-4-5-1/) by Microsoft.

This decision *not* to move to 4.6.x is based on the idea of moving to the latest version of .NET that is at least two years old.

In order to force NuGet package re-installs on a mass scale, I’ve written this in the Package Manager Console:Get-Project -All | Where-Object { $_.Name -match "Songhay.BiggestBox.Desktop" } | ForEach-Object { Update-Package Microsoft.Bcl -ProjectName $_.Name -Reinstall }Another little trick is piling up packages in a PowerShell array and reinstalling:("CommonServiceLocator","Microsoft.Bcl.Build","Prism.Composition","Prism.Mvvm") | ForEach-Object { Update-Package $_ –Reinstall –ProjectName Songhay.BiggestBox.Desktop.Shared }When you want to reinstall all of the packages in a Project try this:Get-Package -ProjectName Songhay.DataAccess.Tests | ForEach-Object { Update-Package $_.Id -Reinstall -ProjectName Songhay.DataAccess.Tests }Now, this one searches all projects looking to reinstall `EntityFramework`:Get-Project -All | ForEach-Object { Get-Package -ProjectName $_.ProjectName | Where-Object { $_.Id -eq "EntityFramework" } | ForEach-Object { Update-Package $_.Id -Reinstall } }Why do these spit out `No packages installed.`?

Searching the entire solution for `targetFramework="net45"` shows me where packages were not updated to `net452` in the **Manage NuGet Packages for Solution…** GUI.

@[BryanWilhite](https://twitter.com/BryanWilhite)
