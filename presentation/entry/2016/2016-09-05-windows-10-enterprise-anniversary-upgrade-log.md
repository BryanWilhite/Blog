---json
{
  "documentId": 0,
  "title": "Windows 10 Enterprise “Anniversary” Upgrade Log",
  "documentShortName": "2016-09-05-windows-10-enterprise-anniversary-upgrade-log",
  "fileName": "index.html",
  "path": "./entry/2016-09-05-windows-10-enterprise-anniversary-upgrade-log",
  "date": "2016-09-06T01:03:17.38Z",
  "modificationDate": "2016-09-06T01:03:17.38Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-09-05-windows-10-enterprise-anniversary-upgrade-log",
  "tag": "{\r\n  \"extract\": \"Manual InstallSQL Server 2016 with R Standalone ServerOffice 365Visual Studio 2016 Professional (with Blend)Microsoft SQL Server Management StudioMicrosoft Visual Studio Team Foundation Server 2015 Power Tools (there is a Chocolatey package for this, tfs...\"\r\n}"
}
---

# Windows 10 Enterprise “Anniversary” Upgrade Log

## Manual Install

* SQL Server 2016 with R Standalone Server
* Office 365
* Visual Studio 2016 Professional (with Blend)
* Microsoft SQL Server Management Studio
* Microsoft Visual Studio Team Foundation Server 2015 Power Tools (there is a Chocolatey package for this, `tfs2015powertools`, but it does not install PowerShell SnapIn, `Microsoft.TeamFoundation.PowerShell` by default)

## PowerShell Package Manager Install

The PowerShell script:

```powershell
$providerName = "Chocolatey"
$provider = Get-PackageProvider -ListAvailable | Where-Object { $_.Name -eq $providerName }
if($provider -eq $null) { Install-PackageProvider -Name $providerName }
$a = (
"7zip.install",
"ccleaner",
"cloudberryexplorer.azurestorage",
"defraggler",
"filezilla",
"git",
"irfanview",
"nant",
"notepadplusplus",
"sysinternals",
"winmerge"
)
$a | ForEach-Object  { Find-Package -Name $_; Install-Package -Name $_ -ProviderName $providerName }
```

The `winmerge` package failed to install:

```powershell
Install-Package : The file or directory is corrupted and unreadable
At line:1 char:1
+ Install-Package "winmerge"
```

The `cloudberryexplorer.azurestorage` package also failed to install with the irresponsibly cryptic:

```console
Install-Package : Process Exited with non-successful exit code cmd.exe : 1

At line:5 char:47
+ ... kage -Name $_; Install-Package -Name $_ -ProviderName $providerName }
+                    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
```

After the `git` (Git for Windows) package is installed, the Git Bash icon will not be available in the Start menu. Find `%ProgramFiles%\Git\git-bash.exe`, right click to run **Pin to Start** and/or **Pin to taskbar**.

I did notice that `Install-Package` supports a `-Destination` parameter for *some* providers (not Chocolatey). I would have been great to have this support to avoid installing packages on the C: drive by default.

## Linux Subsystem Install

The [installation of the Linux subsystem](http://www.howtogeek.com/249966/how-to-install-and-use-the-linux-bash-shell-on-windows-10/) is standard.

```console
sudo apt-get update
sudo apt-get autoremove
sudo aptitude safe-upgrade
sudo apt-get install git
git config --global user.name "Bryan Wilhite"
git config --global user.email "rasx@songhaysystem.net"
sudo apt-get install nodejs
sudo npm install -g bower
sudo npm install -g gulp
sudo ln -s /usr/bin/nodejs /usr/bin/node
sudo apt-get install ruby
sudo gem install sass
history -c && history -w && exit
```

It may not be necessary to *manually* install these for gulp:

```console
sudo npm install gulp-concat
sudo npm install gulp-minify-css
sudo npm install gulp-sass
sudo npm install map-stream
sudo npm install vinyl-fs
```

@[BryanWilhite](https://twitter.com/BryanWilhite)
