---json
{
  "author": "Bryan Wilhite",
  "content": "The Remove-WebVirtualDirectory cmdlet of the WebAdministration module seems to be designed to remove a ‘sub-virtual directory’ of an application by default. Consider the following: $site = Get-Website | Where-Object -Property ID -Value 1 -EQ $app = @{   ...",
  "inceptDate": "2016-04-29T21:46:34.0093623-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "powershell-remove-webvirtualdirectory-notes",
  "sortOrdinal": 0,
  "tag": null,
  "title": "PowerShell: Remove-WebVirtualDirectory notes"
}
---

The `Remove-WebVirtualDirectory` cmdlet of the `WebAdministration` module seems to be designed to remove a ‘sub-virtual directory’ of an application by default. Consider the following:


$site = Get-Website | Where-Object -Property ID -Value 1 -EQ
$app =
@{
    AppName="my_app";
    AppPool="Net40AppPool";
    PhysicalRoot="f:\www\my_app";
}
Remove-WebVirtualDirectory -Name "myVFolder" -Application $app.AppName -Site $site.name -Verbose
    

…where `Get-Website` is also from the `WebAdministration` module. The `Remove-WebVirtualDirectory` cmdlet will remove the ‘sub-virtual directory’ `mVFolder` under `my_app`. This is something I’ve yet to do. What I’ve actually needed is the removal `my_app` itself. It turns out that “dotting” to the current scope works:


Remove-WebVirtualDirectory -Name . -Application $app.AppName -Site $site.name -Verbose
    

This is super-non-intuitive to me. Also it may help to mention that, as of this writing, the `-Name` and the `-Application` parameters are required (which implies a mistake in the documentation or something else non-intuitive that has to be memorized involving the `-Name` parameter).
