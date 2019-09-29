---json
{
  "author": "@BryanWilhite",
  "content": "Manual InstallSQL Server 2016 with R Standalone ServerOffice 365Visual Studio 2016 Professional (with Blend)Microsoft SQL Server Management StudioMicrosoft Visual Studio Team Foundation Server 2015 Power Tools (there is a Chocolatey package for this, tfs...",
  "inceptDate": "2016-09-05T18:03:17.3808199-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "windows-10-enterprise-anniversary-upgrade-log",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Windows 10 Enterprise “Anniversary” Upgrade Log"
}
---

### Manual Install

*   SQL Server 2016 with R Standalone Server
*   Office 365
*   Visual Studio 2016 Professional (with Blend)
*   Microsoft SQL Server Management Studio
*   Microsoft Visual Studio Team Foundation Server 2015 Power Tools (there is a Chocolatey package for this, `tfs2015powertools`, but it does not install PowerShell SnapIn, `Microsoft.TeamFoundation.PowerShell` by default)

### PowerShell Package Manager Install

The PowerShell script:


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
    

The `winmerge` package failed to install:


Install-Package : The file or directory is corrupted and unreadable
At line:1 char:1
+ Install-Package "winmerge"
    

The `cloudberryexplorer.azurestorage` package also failed to install with the irresponsibly cryptic:


Install-Package : Process Exited with non-successful exit code cmd.exe : 1 
At line:5 char:47
+ ... kage -Name $_; Install-Package -Name $_ -ProviderName $providerName }
+                    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    

After the `git` (Git for Windows) package is installed, the Git Bash icon will not be available in the Start menu. Find `%ProgramFiles%\Git\git-bash.exe`, right click to run **Pin to Start** and/or **Pin to taskbar**.

I did notice that `Install-Package` supports a `-Destination` parameter for *some* providers (not Chocolatey). I would have been great to have this support to avoid installing packages on the C: drive by default.

### Linux Subsystem Install

The [installation of the Linux subsystem](http://www.howtogeek.com/249966/how-to-install-and-use-the-linux-bash-shell-on-windows-10/) is standard.


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
history -c &amp;&amp; history -w &amp;&amp; exit
    

It may not be necessary to *manually* install these for gulp:


sudo npm install gulp-concat
sudo npm install gulp-minify-css
sudo npm install gulp-sass
sudo npm install map-stream
sudo npm install vinyl-fs
