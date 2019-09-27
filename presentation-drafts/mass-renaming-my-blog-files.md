# mass-renaming my Blog files

In Powershell:

```ps1
Get-ChildItem -Filter *twinks*.json | Rename-Item -NewName { $_.Name -replace 'twinks', 'tweeted-links' }
```

See “[Use PowerShell to Rename Files in Bulk](https://blogs.technet.microsoft.com/heyscriptingguy/2013/11/22/use-powershell-to-rename-files-in-bulk/).”

In Visual Studio Code:

* find: `-twinks` [match case] change: `-tweeted-links`
* find: `Twinks` [match case] change: `Tweeted Links`
