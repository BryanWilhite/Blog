---json
{
  "documentId": 0,
  "title": "For Windows 10, I have a bunch of free-as-in-baby Ubuntu bash shells to maintain…",
  "documentShortName": "2016-09-29-for-windows-10-i-have-a-bunch-of-free-as-in-baby-ubuntu-bash-shells-to-maintain",
  "fileName": "index.html",
  "path": "./entry/2016-09-29-for-windows-10-i-have-a-bunch-of-free-as-in-baby-ubuntu-bash-shells-to-maintain",
  "date": "2016-09-30T05:47:40.812Z",
  "modificationDate": "2016-09-30T05:47:40.812Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-09-29-for-windows-10-i-have-a-bunch-of-free-as-in-baby-ubuntu-bash-shells-to-maintain",
  "tag": "{\r\n  \"extract\": \"These are the bash shells of the Songhay System:Machine NameUbuntu VersionNotesUbuntu Server VM on A2 Hosting16.04 LTSLive production server (kintespace.com).Ubuntu Server VM on Azure16.04 LTS.NET Core experiments and poor-man’s backup.Ubuntu Desktop VM ...\"\r\n}"
}
---

# For Windows 10, I have a bunch of free-as-in-baby Ubuntu bash shells to maintain…

These are the bash shells of the Songhay System:

<table class="WordWalkingStickTable"><tr><td>
**Machine Name**
</td><td>
**Ubuntu Version**
</td><td>
**Notes**
</td></tr><tr><td>
Ubuntu Server VM on A2 Hosting
</td><td>
16.04 LTS
</td><td>
Live production server (kintespace.com).
</td></tr><tr><td>
Ubuntu Server VM on Azure
</td><td>
16.04 LTS
</td><td>
.NET Core experiments and poor-man’s backup.
</td></tr><tr><td>
Ubuntu Desktop VM on VMware
</td><td>
16.04 LTS
</td><td>
Desktop Publishing, Blender 3D scene-building, mirroring/syncing with *Ubuntu Server VM on **A2 Hosting*.
</td></tr><tr><td>
Ubuntu Bash Shell on Windows 10 VM on VMware
</td><td>
16.04 LTS
</td><td>
NPM/gulp/bower stack for Visual Studio.
</td></tr><tr><td>
Ubuntu Bash Shell on Windows 10 VMware Host
</td><td>
16.04 LTS
</td><td>
File backup (`scp`) source for *Ubuntu Server VM on Azure*. This is physical hardware.
</td></tr><tr><td>
Ubuntu Bash Shell on Windows 10 Studio Workstation
</td><td>
16.04 LTS
</td><td>
This is physical hardware.
</td></tr></table>

## Six bash environments to maintain, four of them critical…

The table is telling me immediately that the physical-hardware Bash shell environments are currently rarely used. This implies that I have to be some kind of Linux nerd to have two ‘extra’ environments to maintain. Or I am in need of cattle-herding tool that can help me maintain Ubuntu six times over.

Since I am *not* a Linux nerd, these are the Bash commands I know I need to run at least once a month (six times over):

```console
sudo apt-get update
sudo apt-get dist-upgrade
sudo apt-get upgrade
sudo apt-get autoremove
sudo apt-get autoclean
```

I think I have the order wrong. I should see “[Package management with APT](https://help.ubuntu.com/community/AptGet/Howto)” and “[What Kind of Maintenance Do I Need to Do On My Linux PC?](http://lifehacker.com/5817282/what-kind-of-maintenance-do-i-need-to-do-on-my-linux-pc)” for detail. According to “[How to maintain a ‘clean’ Ubuntu](https://www.howtoforge.com/tutorial/how-to-maintain-a-clean-ubuntu/)” I might want to try `ucaresystem` and just be done with it in one command—but will it break something in Windows 10?.

@[BryanWilhite](https://twitter.com/BryanWilhite)
