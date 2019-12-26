---json
{
  "documentId": 0,
  "title": "You can’t effectively replace *.cmd scripts with *.ps1 scripts without these key Powershell ingredients…",
  "documentShortName": "2015-06-16-you-can-t-effectively-replace-cmd-scripts-with-ps1-scripts-without-these-key-powershell-ingredients",
  "fileName": "index.html",
  "path": "./entry/2015-06-16-you-can-t-effectively-replace-cmd-scripts-with-ps1-scripts-without-these-key-powershell-ingredients",
  "date": "2015-06-16T07:00:00Z",
  "modificationDate": "2015-06-16T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-06-16-you-can-t-effectively-replace-cmd-scripts-with-ps1-scripts-without-these-key-powershell-ingredients",
  "tag": "{\r\n  \"extract\": \"I stopped experimenting with PowerShell years ago because I was ignorant of the following (or the following was not released around 2007–08): #1: The $PSScriptRoot automatic variable. Without this variable it is very difficult to make flexible, generic scr...\"\r\n}"
}
---

# You can’t effectively replace *.cmd scripts with *.ps1 scripts without these key Powershell ingredients…

I stopped experimenting with PowerShell years ago because I was ignorant of the following (or the following was not released around 2007–08):

## #1:

The `$PSScriptRoot` automatic variable. Without this variable it is very difficult to make flexible, *generic* scripts, using relative paths (especially for dot-sourcing). There are workarounds that do not use this automatic variable but I never ran across them in introductory talks about PowerShell from the early 2000s. One caveat: `$PSScriptRoot` will be empty when inspected from the Shell or in ISE—it only has a value while running from a script.

## #2

The `$env:` drive as a direct replacement of CMD console environment variables. I am sure the `$env:` drive was around since PowerShell 1.0 but it took me way too long to see that, say, `$env:USERPROFILE` is the same as `%USERPROFILE%`—*and* it can be easily interpolated in a string.

## #3

The line continuation character ```. Few know about the `*.cmd` file line continuation character, `^` and, once it’s in play, I could not leave it behind in PowerShell—so I’m glad to see the `*.ps1` equivalent.

## #4

Apparently undocumented `New-Object` constructor syntax. As of this writing, this form of `-TypeName` syntax is not documented (by MSDN—excluding some Blog or forum post):

```powershell
$uri = New-Object System.Uri("./", [System.UriKind]::Relative)

#or:

$uri = New-Object -TypeName System.Uri("./", [System.UriKind]::Relative)
```

What is apparently encouraged is this syntax:

```powershell
New-Object `
        -TypeName System.Uri `
        -ArgumentList ("./", [System.UriKind]::Relative)
```

As a C# guy struggling to relate to PowerShell, I take the first form.

## #5

The `&` operator. Here is a function from [my IIS functions](https://gist.github.com/BryanWilhite/e54408801bc9bef3fc83) that uses PowerShell to call TAKEOWN and ICACLS:

```powershell
function Restore-PermissionsForWebServerGroup($Path)
{
    if(-not(Test-Path $Path))
    {
        Write-Warning "Path $Path was not found. Unable to restore permissions."
        return
    }
    & TAKEOWN /f $Path /a
    & ICACLS $Path /reset /t
    & ICACLS $Path `
        /grant IIS_IUSRS:(CI)(OI)(IO)(RX) `
        /t /l /q
}
```

I really should have listed this as #1. This `&` operator is the bridge to the CMD past on the way to a PowerShell future!

@[BryanWilhite](https://twitter.com/BryanWilhite)
