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