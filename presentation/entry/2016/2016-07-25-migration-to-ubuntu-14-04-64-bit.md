---json
{
  "author": "Bryan Wilhite",
  "content": "This machine is set up with 14.04 LTS 64-bit on a single 32GB virtual drive. I do not see the need to split into separate disks because of my impatience and my feeling that my Linux ambitions are scaled down a bit.These are the initial command line thing...",
  "inceptDate": "2016-07-25T21:39:41.1574474-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "migration-to-ubuntu-14-04-64-bit",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Migration to Ubuntu 14.04 64-bit"
}
---

This machine is set up with 14.04 LTS 64-bit on a single 32GB virtual drive. I do not see the need to split into separate disks because of my impatience and my feeling that my Linux ambitions are scaled down a bit.

These are the initial command line things done:

```console
sudo apt-get install unity-tweak-tool
gsettings set org.gnome.desktop.interface cursor-size 48
gedit ~/.Xresources
```

The `.Xresources` file has one line: `Xcursor.size: 48`. The Unity Tweak Tool allows me to set a global font size in the UI. And, speaking of fonts, I am in need of this:

```console
sudo apt-get install ttf-mscorefonts-installer
```

It’s a Scribus thing.

The first Unity thing I did was turn `/home/myUbuntuUser` into a share with the Unity **Local Network Share** dialog. I copied about 80 of files over to the new machine with no issues—but there were permissions issues. In my brutish impatience I ran `chmod -R 775` which can be a security problem—especially for web site files. I’ll fix this later.

The Ubuntu Software Center installed: Chromium, Firefox, Thunderbird, Blender, Gimp, Inkscape and Audacity. From the command line I ran `thunderbird /profilemanager` and `firefox /profilemanager` to “create” a profile with the existing ones copied over to my conventional data root folder.

## Server “Mirror” Setup

To mirror the A2 Hosting server, I start with these commands:

```console
sudo apt-get install tasksel
sudo tasksel
```

Then I use `tasksel` to setup a LAMP server. I then setup [a MySQL database for my WordPress](https://codex.wordpress.org/Installing_WordPress) site, starting with `mysql --prompt="\v\\h\\d\_(\U)&gt;" -u root -p`. Then `apache2` is groomed with these:

```console
sudo a2enmod actions
sudo a2enmod headers
sudo gedit /etc/apache2/apache2.conf
sudo gedit /etc/apache2/sites-available/000-default.conf
sudo service apache2 restart
```

I do notice that I am not editing `apache2.conf` and `000-default.conf` with vim and that it is not installed by default. Instead, I am using `gedit`. The purpose for editing `apache2.conf` is to whitelist my home web root directory; and editing `000-default.conf` is to direct port 80 to my home web root directory away from the default `/var/www/html/`.

## No VMWare Tools for 64-bit Ubuntu 14.04?

The typical VMWare Workstation indicators for VMWare Tools are simply not present for the 64-bit Ubuntu 14.04 VM. The **VM &gt; Reinstall VMWare Tools…** menu item is disabled and there are no VMWare pop-up offers to install it in the first place.

However, I do notice that I am able to cut and paste between VMWare Host and Guest. The Guest Desktop is properly resized as well. Moreover, the Unity Desktop can browse the network and find Host network shares. All of these features suggest to me that perhaps VMWare Tools are no longer needed for 64-bit Ubuntu.

## Mounting the Host with CIFS

I am told that the [Common Internet File System](https://technet.microsoft.com/en-us/library/cc939973.aspx) (CIFS) is the improvement over the Server Message Block (SMB) protocol. So I need to use this to mount (under `/mnt`) host shares, following “Mounting Windows Share on Ubuntu 14.04”:

```console
sudo apt-get install cifs-utils
sudo mount //Windows10/foo -t cifs -o uid=1000,gid=1000,username=winUser /mnt/foo
```

I notice that I need to `sudo mkdir /mnt/foo` first. (Also the user `winUser` is a “classic” **Computer Management** generated user).

## Mounting the Guest from my Windows 10 VM

“[How to Share Folders in Ubuntu &amp; Access them from Windows 7](http://www.digitalcitizen.life/how-access-ubuntu-shared-folders-windows-7)” is a decent introduction to mounting Ubuntu from Windows. I found these shell commands necessary:

```console
apt-get install -y samba samba-common python-glade2 system-config-samba
sudo apt-get install libpam-smbpass
```

It is important to not enable anonymous access to your share—say, `/foo`. So in Windows it will be found at [\\UBUNTU\foo](file://ubuntu/foo) after filling in the credentials.
