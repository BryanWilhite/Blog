# Generating a Junction (not technically a symbolic link) in Windows 10

Rarely, I ran into the 260-character limit on Windows paths. According to Microsoft’s summer of 2016, [I will _never_ run into this limit again](https://mspoweruser.com/ntfs-260-character-windows-10/). For the other billion non-Windows-10, Windows machines, I may need this:

``` powershell
Set-Location C:\

$junction = "my-junction"
$target = "C:\my-really-really-really-long-path"

if(Test-Path $junction)
{
    Write-Output "$junction junction already exists."
    return
}

& cmd /c mklink /J $junction $target
Get-ChildItem -Path $junction

```

I will note that I attempted to use the `mklink /d` switch (on a pre-summer-of-2016 version of Windows 10) for a directory Symbolic Link but this failed silently.

## Relevant Links

* [Mklink](https://technet.microsoft.com/en-us/library/cc753194.aspx) [TechNet]
* “[Creating a Symbolic Link using PowerShell](http://learn-powershell.net/2013/07/16/creating-a-symbolic-link-using-powershell/)”
* “[How to Create and Use Links with MKLINK in Windows](http://www.sevenforums.com/tutorials/278262-mklink-create-use-links-windows.html)”
