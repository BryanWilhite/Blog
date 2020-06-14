---json
{
  "documentId": 0,
  "title": "Songhay Studio: PowerShell revival!",
  "documentShortName": "2014-10-01-songhay-studio-powershell-revival",
  "fileName": "index.html",
  "path": "./entry/2014-10-01-songhay-studio-powershell-revival",
  "date": "2014-10-01T07:00:00Z",
  "modificationDate": "2014-10-01T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-10-01-songhay-studio-powershell-revival",
  "tag": "{\r\n  \"extract\": \"Jeffrey Snover is awesome but my sad reality for a number of years with PowerShell is cognitive load and unload: since I do not use PowerShell regularly enough I tend to forget how write PowerShell in spite of all of its friendly semantic consistency. Bo...\"\r\n}"
}
---

# Songhay Studio: PowerShell revival!

[Jeffrey Snover](http://www.jsnover.com/index.html) is awesome but my sad reality for a number of years with PowerShell is cognitive load and unload: since I do not use PowerShell regularly enough I tend to forget how write PowerShell in spite of all of its friendly semantic consistency. Bottom line: I’m going to need many PowerShell revivals and I’m going to need to write down what was revived.

Here’s what I have of late:

## How to Display Free Memory: <code>(Get-WMIObject Win32_OperatingSystem)|Get-Member|Out-Host –Paging</code>

```powershell
(Get-WMIObject Win32_OperatingSystem).FreePhysicalMemory.ToString("#,###,000")

(Get-WMIObject Win32_OperatingSystem).TotalVisibleMemorySize.ToString("#,###,000")

("{0}/{1}" –f (Get-WMIObject Win32_OperatingSystem).FreePhysicalMemory.ToString("#,###,000"), (Get-WMIObject Win32_OperatingSystem).TotalVisibleMemorySize.ToString("#,###,000"))## Package Manager Console MovesPM> Get-Package -Updates | Out-GridView

PM> Get-Package -Updates | ConvertTo-Html | Out-File ("{0}\Desktop" -f (Get-Item Env:\USERPROFILE).Value)*   Use tab key for IntelliSense (can be mixed up with ctrl+space).
```

* Enter `Get-Package -Updates` to see what’s out of date in Solution.
* Use `Install-Package -IgnoreDependencies` to prevent ‘excessive’ dependencies from being added to a project.
* Package Manager Reference: [http://docs.nuget.org/docs/reference/package-manager-console-powershell-reference](http://docs.nuget.org/docs/reference/package-manager-console-powershell-reference)[<img alt="Things to do at the Microsoft Store with my youngest son" src="https://farm3.staticflickr.com/2828/9217848637_7dc13155ff_z_d.jpg">](https://www.flickr.com/photos/wilhite/9217848637/in/set-72157625087343217 "Things to do at the Microsoft Store with my youngest son")

@[BryanWilhite](https://twitter.com/BryanWilhite)
