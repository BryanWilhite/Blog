# Chocolatey GUI is the way to go…

My experience with `choco.exe`—especially my frustration with [updating Chocolatey packages](http://songhayblog.azurewebsites.net/entry/installed-choco-exe-on-the-azure-vm) from the command line—goes away with [`ChocolateyGUI`](https://chocolatey.org/packages/ChocolateyGUI).

I _would_ like to find out what ChocolateyGUI is doing on the command line when I do this:

<div style="text-align:center">

![ChocolateyGUI doing an update](https://farm3.staticflickr.com/2030/32013324403_24d4c9f869_o_d.png "ChocolateyGUI doing an update")

</div>

I notice that that this WPF application is a bit rough around the edges (I am considering [contributing to the GitHub project](https://github.com/chocolatey/ChocolateyGUI) myself). But I would like to see a log of what is going on when the GUI calls out to the “Chocolatey Service.” It would be a valiant effort to teach dummies like me how to go directly to the command line.