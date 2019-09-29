---json
{
  "author": "Bryan Wilhite",
  "content": ".NET 4.5.2 is the last .NET 4.5.x release before 4.6.x. It helps to remind myself that 4.5.1 and 4.5.2 were about async debugging support in the Visual Studio 2013 timeframe. Moreover, .NET 4, 4.5 and 4.5.1 are no longer supported by Microsoft.This decis...",
  "inceptDate": "2016-03-25T22:21:44.5274765-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "moving-songhay-system-to-net-4-5-2-with-serious-powershell",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Moving Songhay System to .NET 4.5.2 (with Serious PowerShell)"
}
---

.NET 4.5.2 is [the last .NET 4.5.x release](https://en.wikipedia.org/wiki/.NET_Framework_version_history) before 4.6.x. It helps to remind myself that 4.5.1 and 4.5.2 were about [async debugging support in the Visual Studio 2013 timeframe](https://blogs.msdn.microsoft.com/dotnet/2013/10/17/net-framework-4-5-1-rtm-start-coding/). Moreover, .NET 4, 4.5 and 4.5.1 are [no longer supported](https://blogs.msdn.microsoft.com/dotnet/2015/12/09/support-ending-for-the-net-framework-4-4-5-and-4-5-1/) by Microsoft.

This decision *not* to move to 4.6.x is based on the idea of moving to the latest version of .NET that is at least two years old.

In order to force NuGet package re-installs on a mass scale, I’ve written this in the Package Manager Console:


Get-Project -All | Where-Object { $_.Name -match "Songhay.BiggestBox.Desktop" } | ForEach-Object { Update-Package Microsoft.Bcl -ProjectName $_.Name -Reinstall }
    

Another little trick is piling up packages in a PowerShell array and reinstalling:


("CommonServiceLocator","Microsoft.Bcl.Build","Prism.Composition","Prism.Mvvm") | ForEach-Object { Update-Package $_ –Reinstall –ProjectName Songhay.BiggestBox.Desktop.Shared }
    

When you want to reinstall all of the packages in a Project try this:


Get-Package -ProjectName Songhay.DataAccess.Tests | ForEach-Object { Update-Package $_.Id -Reinstall -ProjectName Songhay.DataAccess.Tests }
    

Now, this one searches all projects looking to reinstall `EntityFramework`:


Get-Project -All | ForEach-Object { Get-Package -ProjectName $_.ProjectName | Where-Object { $_.Id -eq "EntityFramework" } | ForEach-Object { Update-Package $_.Id -Reinstall } }
    

Why do these spit out `No packages installed.`?

Searching the entire solution for `targetFramework="net45"` shows me where packages were not updated to `net452` in the **Manage NuGet Packages for Solution…** GUI.
