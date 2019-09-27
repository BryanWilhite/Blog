---json
{
  "author": "@BryanWilhite",
  "content": "My experience with choco.exe—especially my frustration with updating Chocolatey packages from the command line—goes away with ChocolateyGUI.I would like to find out what ChocolateyGUI is doing on the command line when I do this:I notice that that this WP...",
  "inceptDate": "2017-02-10T15:59:30.7579483-08:00",
  "isPublished": true,
  "itemCategory": "\"year\":2017,\"month\":\"02\",\"day\":\"10\",\"dateGroup\":\"2017\\/02\",\"topic-digital-production-OS\":\"Digital Production: OS\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2017-02-10-chocolatey-gui-is-the-way-to-go",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Chocolatey GUI is the way to go…"
}
---

# Chocolatey GUI is the way to go…

My experience with `choco.exe`—especially my frustration with [updating Chocolatey packages](http://songhayblog.azurewebsites.net/entry/installed-choco-exe-on-the-azure-vm) from the command line—goes away with [`ChocolateyGUI`](https://chocolatey.org/packages/ChocolateyGUI).

I _would_ like to find out what ChocolateyGUI is doing on the command line when I do this:

<div style="text-align:center">

![ChocolateyGUI doing an update](https://farm3.staticflickr.com/2030/32013324403_24d4c9f869_o_d.png "ChocolateyGUI doing an update")

</div>

I notice that that this WPF application is a bit rough around the edges (I am considering [contributing to the GitHub project](https://github.com/chocolatey/ChocolateyGUI) myself). But I would like to see a log of what is going on when the GUI calls out to the “Chocolatey Service.” It would be a valiant effort to teach dummies like me how to go directly to the command line.
