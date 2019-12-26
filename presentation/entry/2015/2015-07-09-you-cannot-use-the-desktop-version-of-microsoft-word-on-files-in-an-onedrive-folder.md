---json
{
  "documentId": 0,
  "title": "You cannot use the desktop version of Microsoft Word on files in an OneDrive folder…",
  "documentShortName": "2015-07-09-you-cannot-use-the-desktop-version-of-microsoft-word-on-files-in-an-onedrive-folder",
  "fileName": "index.html",
  "path": "./entry/2015-07-09-you-cannot-use-the-desktop-version-of-microsoft-word-on-files-in-an-onedrive-folder",
  "date": "2015-07-09T16:39:19.66Z",
  "modificationDate": "2015-07-09T16:39:19.66Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-07-09-you-cannot-use-the-desktop-version-of-microsoft-word-on-files-in-an-onedrive-folder",
  "tag": "{\r\n  \"extract\": \"Here’s the statement: the current release of OneDrive conflicts with the Desktop version of Word (and probably any other desktop Office product) because these 2013-era applications lock files while they are being edited.When OneDrive ‘decides’ to perform...\"\r\n}"
}
---

# You cannot use the desktop version of Microsoft Word on files in an OneDrive folder…

Here’s the statement: the current release of OneDrive conflicts with the Desktop version of Word (and probably any other desktop Office product) because these 2013-era applications lock files while they are being edited.

When OneDrive ‘decides’ to perform a sync operation it often fails to “merge” a locked office document. OneDrive will then generate multiple copies of the Office document, terrifying the user who is unsure which version is the correct version.

This file-locking issue has always been a problem—even in the SkyDrive era. And it must be understood that this issue will emerge when Office is opening the document from a cloud URL or when opening from local disk (under an OneDrive root). As soon as the document is saved (uploaded) the problem looms.

So I see two ways to work around this issue. One way is through a PowerShell script that copies my Word document to a temporary location outside of the OneDrive root folder, opens Office Word, waits for Word to close and then moves the edited file on top of the original under the OneDrive root:

The other way is to somehow have the ability to temporarily turn off OneDrive synching, edit my Office document and turn it back on again. I am flippantly certain that [the OneDrive API](https://blog.onedrive.com/the-new-onedrive-api/) does not provide this facility:

```powershell
$path = $args[0]
if(($path -eq $null) -or -not(Test-Path $path))
{
    Write-Warning "Cannot find file $path. Exiting script."
    exit
}
$root = $PWD.Path
$document = [System.IO.Path]::GetFileName($path)
Write-Output "Opening $document [at $root]..."
Copy-Item -Destination "$env:USERPROFILE\Desktop" -Path $path
Push-Location -Path "$env:USERPROFILE\Desktop"
Start-Process -FilePath $document -Verb open -Wait
Write-Warning "Waiting for Office Application to close/unlock the $document…"
Start-Sleep -Seconds 5
Move-Item -Confirm -Destination $root -Path $document
```

@[BryanWilhite](https://twitter.com/BryanWilhite)
