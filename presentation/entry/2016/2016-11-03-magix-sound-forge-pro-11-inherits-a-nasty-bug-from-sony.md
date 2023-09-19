---json
{
  "documentId": 0,
  "title": "MAGIX Sound Forge Pro 11 inherits a nasty bug from Sony",
  "documentShortName": "2016-11-03-magix-sound-forge-pro-11-inherits-a-nasty-bug-from-sony",
  "fileName": "index.html",
  "path": "./entry/2016-11-03-magix-sound-forge-pro-11-inherits-a-nasty-bug-from-sony",
  "date": "2016-11-04T02:53:58.49Z",
  "modificationDate": "2016-11-04T02:53:58.49Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-11-03-magix-sound-forge-pro-11-inherits-a-nasty-bug-from-sony",
  "tag": "{\r\n  \"extract\": \"I eagerly look forward to an upgrade to MAGIX Sound Forge Pro assuming that they will fix a longstanding bug around this “Registration of Sound Forge Pro 11.0 requires elevated privileges” dialog: This dialog shows after you have successfully installed an...\"\r\n}"
}
---

# MAGIX Sound Forge Pro 11 inherits a nasty bug from Sony

I eagerly look forward to an upgrade to [MAGIX Sound Forge Pro](http://www.magix-audio.com/us/sound-forge/) assuming that they will fix a longstanding bug around this “Registration of Sound Forge Pro 11.0 requires elevated privileges” dialog:
[<img alt="“Registration of Sound Forge Pro 11.0 requires elevated privileges” dialog" src="https://farm6.staticflickr.com/5476/30503921021_a3741768d5_o_d.png">](https://www.flickr.com/photos/wilhite/30503921021/in/dateposted-public/ "“Registration of Sound Forge Pro 11.0 requires elevated privileges” dialog")

This dialog shows *after* you have successfully installed and registered Sound Forge. It usually shows up *after* you turn on your computer (from a powered-off state) and run Sound Forge *once*. This error state indicates that the registration system of Sound Forge is broken on Windows 10 64-bit machines. This issue does not exist for Vegas Video on Windows 10 x64 (including the latest version from MAGIX) or ACID Pro on Windows 10 x64.

There are two workarounds for this issue. The first workaround is to run Sound Forge Pro as Administrator at all times. This “solution” could be considered opening a security hole on your machine. From a practical workflow point of view, I find I am unable to drag and drop files into Sound Forge when running it as Administrator (which suggests to me that most users of Sound Forge are running their entire Desktop session as an Administrator).

The second workaround is to play around with the Compatibility Mode of the Shortcut running Sound Forge. I set it to Windows 7:
[<img alt="Compatibility Mode of the Shortcut running Sound Forge" src="https://farm6.staticflickr.com/5654/30503920961_d7f8b7a466_o_d.png">](https://www.flickr.com/photos/wilhite/30503920961/in/dateposted-public/ "Compatibility Mode of the Shortcut running Sound Forge")

After making the change and clicking on the Shortcut of the Program Compatibility Assistant *should* run:
[<img alt="the Shortcut of the Program Compatibility Assistant" src="https://farm6.staticflickr.com/5500/29958085263_8cd5e82006_o_d.png">](https://www.flickr.com/photos/wilhite/29958085263/in/dateposted-public/ "the Shortcut of the Program Compatibility Assistant")

Clicking **No, launch the troubleshooter** should invoke the Program Compatibility Troubleshooter:
[<img alt="the Program Compatibility Troubleshooter" src="https://farm6.staticflickr.com/5683/29958085413_19e0f45661_o_d.png">](https://www.flickr.com/photos/wilhite/29958085413/in/dateposted-public/ "the Program Compatibility Troubleshooter")

Click the **Test the program…** button to run Sound Forge without elevated privileges.

## Related Links

* MAGIX Support: “[My program will not start](https://support2.magix.com/customer/en/faq/my-program-will-not-start-2)”
* “[Sony have sold ACID, Sound Forge, more to MAGIX](http://cdm.link/2016/06/sony-just-sold-acid-sound-forge-magix/)”

<https://github.com/BryanWilhite/>
