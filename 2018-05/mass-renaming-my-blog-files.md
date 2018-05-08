# mass-renaming my Blog files

In Powershell:

```ps1
Get-ChildItem -Filter *twinks*.json | Rename-Item -NewName { $_.Name -replace 'twinks', 'tweeted-links' }
```

In Visual Studio Code:

* find: `-twinks` [match case] change: `-tweeted-links`
* find: `Twinks` [match case] change: `Tweeted Links`
