---json
{
  "documentId": 0,
  "title": "PowerShell: Remove-WebVirtualDirectory notes",
  "documentShortName": "2016-04-29-powershell-remove-webvirtualdirectory-notes",
  "fileName": "index.html",
  "path": "./entry/2016-04-29-powershell-remove-webvirtualdirectory-notes",
  "date": "2016-04-30T04:46:34.009Z",
  "modificationDate": "2016-04-30T04:46:34.009Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-04-29-powershell-remove-webvirtualdirectory-notes",
  "tag": "{\r\n  \"extract\": \"The Remove-WebVirtualDirectory cmdlet of the WebAdministration module seems to be designed to remove a ‘sub-virtual directory’ of an application by default. Consider the following: $site = Get-Website | Where-Object -Property ID -Value 1 -EQ $app = @{   ...\"\r\n}"
}
---

# PowerShell: `Remove-WebVirtualDirectory` notes

The `Remove-WebVirtualDirectory` cmdlet of the `WebAdministration` module seems to be designed to remove a ‘sub-virtual directory’ of an application by default. Consider the following:

```powershell
$site = Get-Website | Where-Object -Property ID -Value 1 -EQ
$app =
@{
    AppName="my_app";
    AppPool="Net40AppPool";
    PhysicalRoot="f:\www\my_app";
}
Remove-WebVirtualDirectory -Name "myVFolder" -Application $app.AppName -Site $site.name -Verbose
```

…where `Get-Website` is also from the `WebAdministration` module. The `Remove-WebVirtualDirectory` cmdlet will remove the ‘sub-virtual directory’ `mVFolder` under `my_app`. This is something I’ve yet to do. What I’ve actually needed is the removal `my_app` itself. It turns out that “dotting” to the current scope works:

```powershell
Remove-WebVirtualDirectory -Name . -Application $app.AppName -Site $site.name -Verbose
```

This is super-non-intuitive to me. Also it may help to mention that, as of this writing, the `-Name` and the `-Application` parameters are required (which implies a mistake in the documentation or something else non-intuitive that has to be memorized involving the `-Name` parameter).

<https://github.com/BryanWilhite/>
