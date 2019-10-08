---json
{
  "documentId": 0,
  "title": "The PowerShell Clear-History Command on Windows 10",
  "documentShortName": "2017-02-10-the-powershell-clear-history-command-on-windows-10",
  "fileName": "index.html",
  "path": "./entry/2017-02-10-the-powershell-clear-history-command-on-windows-10",
  "date": "2017-02-10T23:26:08.668Z",
  "modificationDate": "2017-02-10T23:26:08.668Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-02-10-the-powershell-clear-history-command-on-windows-10",
  "tag": "{\r\n  \"extract\": \"The PowerShell Clear-History command seems to have no effect. According to Vimes on StackOverflow, this command works: Remove-Item (Get-PSReadlineOption).HistorySavePath I see that HistorySavePath leads here: %APPDATA%\\\\Microsoft\\\\Windows\\\\PowerShell\\\\PSRead...\"\r\n}"
}
---

# The PowerShell Clear-History Command on Windows 10

The PowerShell `Clear-History` command seems to have no effect. According to [Vimes](http://stackoverflow.com/users/316760/vimes) on StackOverflow, [this command](http://stackoverflow.com/a/36900056/22944) works:

<code class="lang-ps1">
Remove-Item (Get-PSReadlineOption).HistorySavePath
<
/code>

I see that `HistorySavePath` leads here:

<code class="lang-plaintext">
%APPDATA%\Microsoft\Windows\PowerShell\PSReadline\ConsoleHost_history.txt
<
/code>

Opening this file and deleting the contents does what `Clear-History` is supposed to do—and it gives me the opportunity to make notes on any commands I might have entered in the heat of the moment for future, cooler use.

@[BryanWilhite](https://twitter.com/BryanWilhite)
