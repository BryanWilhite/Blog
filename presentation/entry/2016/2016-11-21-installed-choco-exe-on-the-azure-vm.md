---json
{
  "author": "@BryanWilhite",
  "content": "The internet tells me that choco.exe supports updating packages (while the standard PowerShell PackageManagement from Microsoft—formerly OneGet—does not). So the experiment is around the question, Can I use choco.exe with previously installed OneGet pack...",
  "inceptDate": "2016-11-21T21:36:12.2703118-08:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "installed-choco-exe-on-the-azure-vm",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Installed choco.exe on the Azure VM…"
}
---

The internet tells me that `choco.exe` supports *updating* packages (while the standard PowerShell `PackageManagement` from Microsoft—formerly OneGet—does not). So the experiment is around the question, Can I use `choco.exe` with previously installed OneGet packages from the Chocolatey Provider?

Install choice:


iwr https://chocolatey.org/install.ps1 -UseBasicParsing | iex
    

First of all, the install process of `choco.exe` threatens to move the old packages from `C:\Chocolatey` to `C:\ProgramData\chocolatey` as this excerpt from the installation warns:


Creating Chocolatey folders if they do not already exist.
WARNING: You can safely ignore errors related to missing log files when upgrading from a version of Chocolatey less than 0.9.9.
'Batch file could not be found' is also safe to ignore.
 'The system cannot find the file specified' - also safe.
chocolatey.nupkg file not installed in lib.
Attempting to locate it from bootstrapper.
PATH environment variable does not have C:\ProgramData\chocolatey\bin in it. Adding...
Attempting to upgrade 'C:\Chocolatey' to 'C:\ProgramData\chocolatey'.
WARNING: Copying the contents of 'C:\Chocolatey' to 'C:\ProgramData\chocolatey'.
This step may fail if you have anything in this folder running or locked.
If it fails, just manually copy the rest of the items out and then delete the folder.
WARNING: !!!! ATTN: YOU WILL NEED TO CLOSE AND REOPEN YOUR SHELL !!!!
WARNING: Not setting tab completion: Profile file does not exist at
'C:\Users\rasx\Documents\WindowsPowerShell\Microsoft.PowerShell_profile.ps1'.
Chocolatey (choco.exe) is now ready.
You can call choco from anywhere, command line or powershell by typing choco.
Run choco /? for a list of functions.
You may need to shut down and restart powershell and/or consoles first prior to using choco.
WARNING: This action will result in Log Errors, you can safely ignore those.
 You may need to finish removing 'C:\Chocolatey' manually.
Attempting to remove 'C:\Chocolatey'. This may fail if something in the folder is being used or locked.
Ensuring chocolatey commands are on the path
Ensuring chocolatey.nupkg is in the lib folder
    

Here is the punch line: I never had a `C:\Chocolately` folder! My machine has a OneGet `C:\Packages `folder. However, the `choco.exe` installation appears to have successfully moved all Chocolatey packages from the folder to `C:\ProgramData\chocolatey`.

I find this command super-useful:


choco upgrade all -y --whatif
    

This what-if mode report gives me option to upgrade everything or be a bit extra-careful and upgrade packages one by one. Today, I am seeing this:


Chocolatey can upgrade 10/18 packages. 0 packages failed.
See the log for details (C:\ProgramData\chocolatey\logs\chocolatey.log).
Can upgrade:
 - git v2.10.2
 - chocolatey-fosshub.extension v0.4.0
 - notepadplusplus v7.2
 - irfanview v4.42.0.20161101
 - mm-choco.extension v0.0.4
 - cloudberryexplorer.azurestorage v2.5.0.21
 - chocolatey-uninstall.extension v1.2.0
 - filezilla v3.22.2.2
 - git.install v2.10.2
 - notepadplusplus.install v7.2
    

This is the other command that is super-useful:


choco list -localonly –all
    

This displays output like this:


Chocolatey v0.10.3
7zip.install 16.02.0.20160811
autohotkey.portable 1.1.24.02
autoit.commandline 3.3.14.2
ccleaner 5.24.5841
ccleaner 5.23.5808
chocolatey 0.10.3
chocolatey-core.extension 1.0
chocolatey-fosshub.extension 0.2.0
chocolatey-uninstall.extension 1.1.0
CloudBerryExplorer.AzureStorage 2.5.0.21
CloudBerryExplorer.AzureStorage 2.5.0.11
defraggler 2.21.993
filezilla 3.22.2.2
filezilla 3.22.1
git 2.10.2
git 2.10.1
git.install 2.10.2
git.install 2.10.1
irfanview 4.42.0.20160616
mm-choco.extension 0.0.3
NAnt 0.92.2
notepadplusplus 7.2
notepadplusplus.install 7.2
sysinternals 2016.08.29
24 packages installed.
    

There two things I am seeing in this output. First, I see that the upgrade functionality of `choco.exe` is not much better than the standard (OneGet) stuff because an update simply stacks a new version of the package next to the old one. This implies that I still have to manually uninstall the old package by version number (unless there is some kind of cool command-line option to avoid this) with this:


choco uninstall git git.install --version 2.10.1
    

The results I am seeing from this command does not make me feel great:


Chocolatey v0.10.3
Uninstalling the following packages:
git;git.install
git v2.10.1
Skipping auto uninstaller - No registry snapshot.
git.install not uninstalled. An error occurred during uninstall:
Unable to uninstall 'git.install 2.10.1' because 'git 2.10.1' depends on it.
Chocolatey uninstalled 1/2 packages. 1 packages failed.
See the log for details (C:\ProgramData\chocolatey\logs\chocolatey.log).
Failures
 - git.install (exited 1) - git.install not uninstalled. An error occurred during uninstall:
 Unable to uninstall 'git.install 2.10.1' because 'git 2.10.1' depends on it.
    

I see now that I should have used the `--force` command-line option. To make matters worse, my uninstall command above apparently installed *all* versions of `git`. So I was forced to reinstall `git` to see it listed as a locally-installed package.

Today, Chocolatey is not a sweet experience—especially for any package paired with an `*.install `package. All of the unpaired packages were uninstalled as expected and this is list of locally installed packages:


Chocolatey v0.10.3
7zip.install 16.02.0.20160811
autohotkey.portable 1.1.24.02
autoit.commandline 3.3.14.2
ccleaner 5.23.5808
chocolatey 0.10.3
chocolatey-core.extension 1.0
chocolatey-fosshub.extension 0.2.0
chocolatey-uninstall.extension 1.1.0
CloudBerryExplorer.AzureStorage 2.5.0.11
defraggler 2.21.993
filezilla 3.22.1
git 2.10.2
git.install 2.10.2
irfanview 4.42.0.20160616
mm-choco.extension 0.0.3
NAnt 0.92.2
notepadplusplus 7.2
notepadplusplus.install 7.2
sysinternals 2016.08.29
19 packages installed.
    

Finally, I am assuming for the moment that I need to make sure that there is only *one* version of these packages *at all times* to avoid getting another class of errors:


chocolatey-core.extension 1.0
chocolatey-fosshub.extension 0.2.0
chocolatey-uninstall.extension 1.1.0
mm-choco.extension 0.0.3
    

### Related Links

*   [Commands Reference](https://chocolatey.org/docs/commands-reference)
*   [PowerShellGet and PackageManagement in PowerShell Gallery and GitHub](https://blogs.msdn.microsoft.com/powershell/2016/09/29/powershellget-and-packagemanagement-in-powershell-gallery-and-github/)
