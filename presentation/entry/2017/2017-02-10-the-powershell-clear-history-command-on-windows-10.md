---json
{
  "author": "@BryanWilhite",
  "content": "The PowerShell Clear-History command seems to have no effect. According to Vimes on StackOverflow, this command works:\r\nRemove-Item (Get-PSReadlineOption).HistorySavePath\r\nI see that HistorySavePath leads here:\r\n%APPDATA%\\Microsoft\\Windows\\PowerShell\\PSR...",
  "inceptDate": "2017-02-10T15:26:08.6682218-08:00",
  "isPublished": true,
  "itemCategory": "\"year\":2017,\"month\":\"02\",\"day\":\"10\",\"dateGroup\":\"2017\\/02\",\"topic-digital-production-OS\":\"Digital Production: OS\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2017-02-10-the-powershell-clear-history-command-on-windows-10",
  "sortOrdinal": 0,
  "tag": null,
  "title": "The PowerShell Clear-History Command on Windows 10"
}
---

# The PowerShell Clear-History Command on Windows 10

The PowerShell `Clear-History` command seems to have no effect. According to [Vimes](http://stackoverflow.com/users/316760/vimes) on StackOverflow, [this command](http://stackoverflow.com/a/36900056/22944) works:

``` ps1

Remove-Item (Get-PSReadlineOption).HistorySavePath

```

I see that `HistorySavePath` leads here:

``` plaintext

%APPDATA%\Microsoft\Windows\PowerShell\PSReadline\ConsoleHost_history.txt

```

Opening this file and deleting the contents does what `Clear-History` is supposed to do—and it gives me the opportunity to make notes on any commands I might have entered in the heat of the moment for future, cooler use.
