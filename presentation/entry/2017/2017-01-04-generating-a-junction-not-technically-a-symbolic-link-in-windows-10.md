---json
{
  "documentId": 0,
  "title": "Generating a Junction (not technically a symbolic link) in Windows 10",
  "documentShortName": "2017-01-04-generating-a-junction-not-technically-a-symbolic-link-in-windows-10",
  "fileName": "index.html",
  "path": "./entry/2017-01-04-generating-a-junction-not-technically-a-symbolic-link-in-windows-10",
  "date": "2017-01-04T23:28:55.566Z",
  "modificationDate": "2017-01-04T23:28:55.566Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-01-04-generating-a-junction-not-technically-a-symbolic-link-in-windows-10",
  "tag": "{\r\n  \"extract\": \"Rarely, I ran into the 260-character limit on Windows paths. According to Microsoft’s summer of 2016, I will never run into this limit again. For the other billion non-Windows-10, Windows machines, I may need this:Set-Location C:\\\\ $junction = \\\"my-junctio...\"\r\n}"
}
---

# Generating a Junction (not technically a symbolic link) in Windows 10

Rarely, I ran into the 260-character limit on Windows paths. According to Microsoft’s summer of 2016, [I will *never* run into this limit again](https://mspoweruser.com/ntfs-260-character-windows-10/). For the other billion non-Windows-10, Windows machines, I may need this:

<code class="lang-powershell">Set-Location C:\
$junction = "my-junction"
$target = "C:\my-really-really-really-long-path"
if(Test-Path $junction)
{
    Write-Output "$junction junction already exists."
    return
}
&amp; cmd /c mklink /J $junction $target
Get-ChildItem -Path $junction
<
/code>

I will note that I attempted to use the `mklink /d` switch (on a pre-summer-of-2016 version of Windows 10) for a directory Symbolic Link but this failed silently.

## Relevant Links

* [Mklink](https://technet.microsoft.com/en-us/library/cc753194.aspx) [TechNet]
* “[Creating a Symbolic Link using PowerShell](http://learn-powershell.net/2013/07/16/creating-a-symbolic-link-using-powershell/)”
* “[How to Create and Use Links with MKLINK in Windows](http://www.sevenforums.com/tutorials/278262-mklink-create-use-links-windows.html)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
