---json
{
  "documentId": 0,
  "title": "PowerShell so far…",
  "documentShortName": "2015-06-05-powershell-so-far",
  "fileName": "index.html",
  "path": "./entry/2015-06-05-powershell-so-far",
  "date": "2015-06-05T07:00:00.000Z",
  "modificationDate": "2015-06-05T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-06-05-powershell-so-far",
  "tag": "{\r\n  \"extract\": \"I’ve finally had the opportunity to work with PowerShell full time around Internet Information Services configuration on Windows Server 2012. I would like to roll up a few PowerShell highlights glimmering over the last few weeks. I’ve been playing with P...\"\r\n}"
}
---

# PowerShell so far…

I’ve finally had the opportunity to work with PowerShell full time around Internet Information Services configuration on Windows Server 2012. I would like to roll up a few PowerShell highlights glimmering over the last few weeks. I’ve been playing with PowerShell for over ten years but now I can refresh my resume with new, sustained experience (under the influence of my extensive C# development).

## Before considering modules, look into “dot-sourcing”…

This is what the cool PowerShell kids call “dot-sourcing”:

Clear-Host
    . E:\Scripts\My-Functions.ps1

$x = Get-MyValue()

The Scripting Guy [makes it plain](http://blogs.technet.com/b/heyscriptingguy/archive/2009/12/23/hey-scripting-guy-december-23-2009.aspx), “use the dot sourcing operator to run the script so that the functions from the script are part of the calling scope. To dot source the script, you use the dot source operator (a period) followed by the path to the script containing the functions you wish to include in your current scope.”

## Use $null, $true, $false…

As a C# guy this trips me up quite a bit. These [*automatic variables*](https://technet.microsoft.com/en-us/library/hh847768.aspx), `$null`, `$true`, `$false`, are just the tip of the PowerShell iceberg.

## No ternary operations…

[Alexander Taran](http://alex-taran.blogspot.com/2014/07/ternary-operation-powershell.html) and I were looking for the same thing. It’s not there.

## No need to .Trim() PowerShell “here” strings…

The `.Length` property below will return *0*:

@"
    "@.Length

## Arrays do not sort with piping without .GetEnumerator()

The importance of `.GetEnumerator()` in PowerShell can be quite disconcerting to a C# person like me. I simply to do not use `.GetEnumerator()` explicitly in C# because I’m a LINQ guy with little need to implement `IEnumerable`.

So let’s reverse an array in PowerShell:

```powershell
$a = "A,B,C".Split(',')
    [System.Array]::Reverse($a)
    foreach ($i in $a) { $i }
```

This approach is *not* PowerShell-native because of the desperate call out to the .NET `System.Array`. The following approach is native:

```powershell
$a = "A,B,C".Split(',')
    foreach ($i in $a.GetEnumerator() | sort -Descending) { $i }
```

The piping to `sort` in `foreach` is possible only because of the rather non-obvious call to `.GetEnumerator()`. In “[Weekend Scripter: Sorting PowerShell Hash Tables](http://blogs.technet.com/b/heyscriptingguy/archive/2014/09/28/weekend-scripter-sorting-powershell-hash-tables.aspx)” the Scripting Guy kind of explains why this is an issue—his title of his article leads to my next note (below). He does a better job in this tips of the week:

<blockquote>

…in the preceding command the hash table is sent as a single object; thus there’s nothing for the Sort-Object cmdlet to sort. If we want to sort a hash table by Name we need to use the `GetEnumerator `method, which effectively sends each entry in the hash table across the pipeline as a separate object…

</blockquote>

## Generate PowerShell Objects from ordered hash tables to sort object properties…

PowerShell allows us to make objects on the fly (kind of like anonymous objects in C#) which can be piped into a CSV file for Excel. The `-Property` argument of `New-Object` takes `IDictionary` which is another way of saying *hash table*. Unless the hash table is ordered, `New-Object` will generate the properties in “random” order. In the following example (which might not be the best way), I am generating an ordered hash table from a regular hash table and passing it to `New-Object`:

```powershell
$orderedHash = [ordered]@{}
    foreach($i in $hash.Keys.GetEnumerator() | sort) { $orderedHash.Add($i, $hash[$i]) }
    $o = New-Object -Property $orderedHash -TypeName psobject
```

## Do not use ConvertTo-Csv to write a CSV file, use Export-Csv instead…

In “[Use PowerShell to Create CSV File to Open in Excel](http://blogs.technet.com/b/heyscriptingguy/archive/2014/02/04/use-powershell-to-create-csv-file-to-open-in-excel.aspx),” the Scripting Guy shows me how to send the contents of `$o` above to Excel:

```powershell
$o | Export-Csv -Path "my_excel_data.csv" -Encoding UTF8 -NoTypeInformation
```

I’ve noticed that Excel (2010) only supports encodings that are UTF8 or ASCII.

## Treat a PowerShell array like a C# List<T> by using +=…

The following function I wrote for IIS inventory reporting demonstrates how we *append* to a PowerShell array (`$paths`):

```powershell
function Get-WebApplicationPowerShellPaths()
{
    $sites = Get-Website
    $apps = Get-WebApplication
    $paths = @()
    foreach($i in $apps)
    {
        $site = $sites | where { $i.PhysicalPath.StartsWith($_.PhysicalPath) }
        $paths += "IIS:\Sites\$($site.Name)\$($i.path.Substring(1))"
    }
    return $paths
}
```

A C# person would likely use `List<string>.Add()` and might have trouble finding the PowerShell equivalent.

## String-interpolate object properties with $()…

The function above demonstrates how the `$()` syntax is used inside of a string to reach object properties and make object method calls: `"IIS:\Sites\$($site.Name)\$($i.path.Substring(1))"`.

For those familiar with the Razor syntax of ASP.NET MVC, we see that `$()` is similar to `@()` for string interpolation.

## Test-Path works on more than just ‘traditional’ drives…

The following is PowerShell-awesome to me:

```powershell
if (Test-Path "IIS:\Sites\$Site\$AppName")
{
    Write-Host -ForegroundColor Cyan "Web application $AppName already exists. Removing..."
    Remove-WebApplication -Site $Site -Name $AppName
    if (Test-Path "$PhysicalPath\Web.config") { Remove-Item "$PhysicalPath\Web.config" }
}
```

This test, `if (Test-Path "IIS:\Sites\$Site\$AppName")`, checks to see whether an IIS web app exists or not!

## Pipe a stream of hash tables with @{} and ForEach-Object…

It is easy for me to confuse a hash table with a PowerShell object because this:

```powershell
@{
    PropertyOne = "one-1";
    PropertyTwo = "one-2";
    PropertyThree = "one-3";
}
```

…or this:

```powershell
@{
    "PropertyOne" = "one-1";
    "PropertyTwo" = "one-2";
    "PropertyThree" = "one-3";
}
```

…allows me to do this:

$data[0].PropertyOne -eq $data[0]["PropertyOne"]

So it is this hash-table dot syntax, `$data[0].PropertyOne`, that makes me erroneously think I am generating “anonymous objects” on the fly. But this weirdness (from a C# perspective) is very cool when I use an array of hash tables with `ForEach-Object`:

```powershell
$data =
@{
    "PropertyOne" = "one-1";
    "PropertyTwo" = "one-2";
    "PropertyThree" = "one-3";
},
@{
    PropertyOne = "two-1";
    PropertyTwo = "two-2";
    PropertyThree = "two-3";
},
@{
    PropertyOne = "three-1";
    PropertyTwo = "three-2";
    PropertyThree = "three-3";
}
$data | ForEach-Object `
{
    $_.PropertyOne
    $_.PropertyTwo
    $_.PropertyThree
}
```

For my personal benefit, I must point out that this:

```powershell
$data | ForEach-Object `
    {
        $_.PropertyOne
        $_.PropertyTwo
        $_.PropertyThree
    }
```

…and this:

```powershell
$data | ForEach-Object { New-Object -Property $_ -TypeName psobject } | ForEach-Object `
    {
        $_.PropertyOne
        $_.PropertyTwo
        $_.PropertyThree
    }
```

…do the same thing. But the former is more efficient (and easier to read) than the latter. (By the way, I am almost certain that Jeffrey Snover (or someone else) pointed this out publically years ago in writing or in person but I failed to understand its importance. Moreover, I am under the impression that there is a *fundamental* relationship between hash tables and PowerShell objects.)

## Generate an empty text file with PowerShell…

Do this:

```powershell
"" | Set-Content "default.html" -Encoding UTF8
```

## Don’t forget about Select-Xml and XPath queries when reading XML files…

In the example below, I use `Select-Xml` with an XPath query to read a `web.config` file:

```powershell
$configPath = "$($Element.PhysicalPath)\Web.config"
    $node = (Select-Xml -Path $configPath -XPath configuration/system.web).Node
    $compilation = $node.SelectSingleNode("./compilation")
    $httpRuntime = $node.SelectSingleNode("./httpRuntime")
    "$($compilation.Name):$($compilation.Attributes['debug'].Name):$($compilation.Attributes['debug'].Value)"
    "$($compilation.Name):$($compilation.Attributes['targetFramework'].Name):$($compilation.Attributes['targetFramework'].Value)"
    "$($httpRuntime.Name):$($httpRuntime.Attributes['targetFramework'].Name):$($httpRuntime.Attributes['targetFramework'].Value)"
```

By the way, resorting to `Select-Xml` to read a value (or the value is empty/null) because `Get-WebConfigurationValue` is not working could mean that the `web.config` is not valid with respect to IIS (try browsing the site as a brute-force way to ‘validate’ `web.config`).

@[BryanWilhite](https://twitter.com/BryanWilhite)
