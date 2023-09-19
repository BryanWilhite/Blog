---json
{
  "documentId": 0,
  "title": "Connecting to my Ubuntu VM on Azure",
  "documentShortName": "2016-04-30-connecting-to-my-ubuntu-vm-on-azure",
  "fileName": "index.html",
  "path": "./entry/2016-04-30-connecting-to-my-ubuntu-vm-on-azure",
  "date": "2016-05-01T05:40:21.531Z",
  "modificationDate": "2016-05-01T05:40:21.531Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-04-30-connecting-to-my-ubuntu-vm-on-azure",
  "tag": "{\r\n  \"extract\": \"There are at least four (Windows) ways to connect to a Linux VM on Azure (today).PuTTY and WinSCP (over SSH)Windows Remote Desktop (to xrdp)Windows File Manager (to samba)(probably) Windows 10 Bash shell (with ssh)PuTTY and WinSCP (over SSH)I may have to...\"\r\n}"
}
---

# Connecting to my Ubuntu VM on Azure

There are at least four (Windows) ways to connect to a Linux VM on Azure (today).

* PuTTY and WinSCP (over SSH)
* Windows Remote Desktop (to `xrdp`)
* Windows File Manager (to `samba`)
* (probably) Windows 10 Bash shell (with `ssh`)

## PuTTY and WinSCP (over SSH)

I may have to come back and update these notes but I’m almost certain that Azure sets up VMs with SSH by default. So use of PuTTY and WinSCP is straightforward. (I did notice that the default, 15-second timeout of WinSCP was too fast for Azure so I had to change that—under **Connection > Timeouts > Server response timeout** with **Advanced options** checked.)

## Windows Remote Desktop (to xrdp)

For this, I followed the instructions from “[How to use xRDP for remote access to Ubuntu 14.04](http://www.tweaking4all.com/software/linux-software/use-xrdp-remote-access-ubuntu-14-04/)” or “[Running a Remote Desktop on a Windows Azure Linux VM](https://blogs.technet.microsoft.com/uktechnet/2013/11/12/running-a-remote-desktop-on-a-windows-azure-linux-vm/).” I was unable to connect using Remote Desktop. I noticed that, according to `service –status-all`, `xrdp` was not running—even after commanding it to run.

I also noticed that the Azure Portal could no longer restart or detect updates from my Linux VM. After reading “[How to update the Azure Linux Agent on a VM to the latest version from Github](https://acom-swtest-2.azurewebsites.net/en-us/documentation/articles/virtual-machines-linux-update-agent/?rnd=1),” I got `walinuxagent` restarted and fixed the problem.

## Windows File Manager (to samba)

The instructions in “[How to Share Files Between Windows and Linux](http://www.howtogeek.com/176471/how-to-share-files-between-windows-and-linux/)” did not work with Azure until I read “[Firewall Settings for Personal File Sharing](http://askubuntu.com/questions/8184/firewall-settings-for-personal-file-sharing)” and added [Inbound security rules](http://michaelsync.net/2015/09/28/where-is-the-endpoint-setting-for-vm-in-new-azure-portal) to the Azure Resource Group associated with the VM.

## Windows 10 Bash shell (with ssh)

“[How To Use SSH to Connect to a Remote Server in Ubuntu](https://www.digitalocean.com/community/tutorials/how-to-use-ssh-to-connect-to-a-remote-server-in-ubuntu)” should work *natively* on Windows 10, according to [recent news](http://www.theverge.com/2016/3/30/11331014/microsoft-windows-linux-ubuntu-bash), providing an experience similar to using PuTTY.

<https://github.com/BryanWilhite/>
