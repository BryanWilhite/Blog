---json
{
  "documentId": 0,
  "title": "Chocolatey GUI is the way to go…",
  "documentShortName": "2017-02-10-chocolatey-gui-is-the-way-to-go",
  "fileName": "index.html",
  "path": "./entry/2017-02-10-chocolatey-gui-is-the-way-to-go",
  "date": "2017-02-10T23:59:30.757Z",
  "modificationDate": "2017-02-10T23:59:30.757Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-02-10-chocolatey-gui-is-the-way-to-go",
  "tag": "{\r\n  \"extract\": \"My experience with choco.exe—especially my frustration with updating Chocolatey packages from the command line—goes away with ChocolateyGUI.I would like to find out what ChocolateyGUI is doing on the command line when I do this:I notice that that this WP...\"\r\n}"
}
---

# Chocolatey GUI is the way to go…

My experience with `choco.exe`—especially my frustration with [updating Chocolatey packages](http://songhayblog.azurewebsites.net/entry/installed-choco-exe-on-the-azure-vm) from the command line—goes away with [`ChocolateyGUI`](https://chocolatey.org/packages/ChocolateyGUI).

I *would* like to find out what ChocolateyGUI is doing on the command line when I do this:

<div style="text-align:center">

<img src="https://farm3.staticflickr.com/2030/32013324403_24d4c9f869_o_d.png" alt="ChocolateyGUI doing an update" title="!*m82">

</div>

I notice that that this WPF application is a bit rough around the edges (I am considering [contributing to the GitHub project](https://github.com/chocolatey/ChocolateyGUI) myself). But I would like to see a log of what is going on when the GUI calls out to the “Chocolatey Service.” It would be a valiant effort to teach dummies like me how to go directly to the command line.

@[BryanWilhite](https://twitter.com/BryanWilhite)
