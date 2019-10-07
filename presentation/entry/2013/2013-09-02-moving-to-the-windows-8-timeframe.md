---json
{
  "author": "Bryan Wilhite",
  "content": "The move into the Windows 8 timeframe is a historical event for Microsoft. It is a decades-later collective/corporate response to a Steve Jobs comment about IBM: “IBM has no taste.” In spite of the best efforts of luminaries like Alan Cooper, Microsoft t...",
  "inceptDate": "2013-09-02T00:00:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "moving-to-the-windows-8-timeframe",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Moving to the Windows 8 Timeframe"
}
---

[<img alt="Building Windows 8 Apps with C# and XAML (Microsoft Windows Development Series)" src="http://ecx.images-amazon.com/images/I/51dkEwmW%2BRL.jpg" style="float:right;margin:16px;">](http://www.amazon.com/Building-Windows-Microsoft-Development-Series/dp/0321822161%3FSubscriptionId%3D1SW6D7X6ZXXR92KVX0G2%26tag%3Dthekintespacec00%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3D0321822161 "Building Windows 8 Apps with C# and XAML (Microsoft Windows Development Series)")

The move into the Windows 8 timeframe is a historical event for Microsoft. It is a decades-later collective/corporate response to a Steve Jobs comment about IBM: “IBM has no taste.” In spite of the best efforts of luminaries like [Alan Cooper](http://en.wikipedia.org/wiki/Alan_Cooper), Microsoft turned into IBM for a good-long-IE6-while, wrapped in blue and gun-metal grey. With the help of Swiss design culture (“metro”), embracing and extending the Steve-Jobs love for typography, Microsoft officially and professionally has taste.

## The Sager Notebook with Windows 8 Installed

Since I am relatively late to tell my Windows 8 upgrade story, I have had plenty of time to hear what the pundits had to say. I have no problem living without the Start button. This is because I have used Windows-key shortcuts since keyboards were built with the Windows key. When I need to see the Desktop, it’s `Windows-D`. When I need to shutdown it’s the old classic: `Alt-F4` (with the Desktop in focus).

The much-dreaded Start menu is *not* a distraction for me. I do notice that the experts that complain about the Start menu work at home and/or have a dedicated device (like a Surface tablet) that handles their social networking needs. I do not have this secondary device (apart from my Windows Phone 8 device, a Nokia Lumia 920). It follows that I depend on the Start menu as a sort of instrumentation panel, an executive summary of the “real” world. When I go back to Windows 7 I find myself looking for this 30,000 foot view and am left with a feeling that something is missing.

As I suggested in “[Sager NP6165 Unboxing](http://songhayblog.azurewebsites.net/Entry/Show/sager-np6165-unboxing),” what is missing in Windows 8 is a touchscreen alternative for us serious notebook users. Logitech or Wacom may have a solution for me in the form of a compelling touchpad.

What is also seriously missing in my Windows 8 experience is robust Bluetooth support. I often have to delete my device and re-add it to get expected results.
[<img alt="My New Windows 8 Start Menu" src="http://farm8.staticflickr.com/7320/8735621847_5ce568607b.jpg">](http://www.flickr.com/photos/wilhite/8735621847/ "My New Windows 8 Start Menu")

## Windows Phone 8 Has Some Noticeable Regressions

I would not go back to Windows Phone 7. Features like Internet Connection Sharing (which came out in [the 7.5 timeframe](http://www.winrumors.com/windows-phone-7-5-internet-tethering-feature-only-available-on-new-devices/)), resizable live tiles and the ability to group People are just a few of the reasons not to think about the past. But memories of better experiences flutter about when I run into issues around the audio-related features of Windows Phone 8.

First of all on my Nokia Lumia 920 the entire audio subsystem will crash ‘softly’ in a few ways. At times the volume control will have no effect on the currently playing media. A new file has to be selected for the latest volume settings to be recognized. Sometimes a reboot of the phone helps this issue. When I unplug an analog jack the audio will stop playing but will occasionally spit out a sample of sound through the phone speakers. This can be disturbing in a quiet setting. Rarely but frequently enough I will click on a play button in a List View and get a message about Windows Phone not being able to play this type of file; but when I select the file from the list, show it individually and press play it plays. With my Samsung Focus on Windows 7 I *never* had these kind of problems (by the way: I upgraded to my Nokia Lumia because the physical volume control stopped working on my Focus).

## The Microsoft Office of the Windows 8.0 Timeframe with the new SkyDrive

I am embarrassed to admit that at the beginning of this year I lost about *four months* of personal data (while, sadly, upgrading to Windows 8). Most of it were Office Documents and Visual Studio Projects. This stupid-asinine event “inspired me” to embrace SkyDrive (and Team Foundation Service) with typical, American, evangelical violence.

I, of course, assumed that SkyDrive (with the Microsoft Office Upload Center) was the ‘perfect’ solution for my needs—and when I mean *perfect* I mean Microsoft have given me plenty of headroom to move around my use cases without fear of bumping my head. I was wrong.

The first head injury came from trying to edit local Word documents from a folder recognized by SkyDrive as a sync folder. I just assumed that it would “just work” but what actually happened is a problem that goes back decades: Microsoft Word *2013* locked the open document, preventing SkyDrive from doing sync operations. So SkyDrive (and/or Office Upload Center) generated copies of the original file and began to support a scenario where multiple authors were editing the same document. But there was *one* person editing the document—and this one person did not know that his work was being saved in a copy of the file not the original. So imagine my frustration when I found out that my latest edits were ‘missing’! Strewth. I turned to the Microsoft cloud to prevent data loss and this is what I get?

So the solution (workaround) for this “issue” is to never edit a local document in a sync folder directly. We must open the SkyDrive version of the file, save changes to SkyDrive and then let SkyDrive sync change your local copy. This ‘solution,’ however, has two little issues associated with it. It depends on a live, always-on internet connection and for those of us who are habitually saving our work every five minutes may notice the “<span style="font-variant:small-caps;">uploading to SkyDrive</span>” message in the Word status bar as our edit session freezes until the cloud save completes—this interrupts the edit session placing a drag on the user experience and might encourage some to (manually) save their documents less often.

The other bump to the head came when SkyDrive would complain that “An Office Document needs your attention.” It would suggest that I should open the document but I found that *no action* could be taken to address the problem. I speculate that the problem comes from editing a cloud version of a document in, say, Word 2010 and then, later, opening the same logical file in Word 2013 on a machine running SkyDrive with a sync folder with a local copy of this logical file. Merely opening the file in 2013 “touches” the local copy such that when SkyDrive tries to sync its cloud version (from 2010) with the 2013 “touched” copy it throws a “needs your attention” error. So the solution (workaround) for this “issue” is to download the 2010 version from SkyDrive.com and overwrite the “touched” document on disk. Pathetic.

The final abrasion comes with SkyDrive “processing changes” endlessly. This is a super-edge case so I understand how the Office Team would elect not to care about this issue. You see, kids, I use Office 2013 and SkyDrive from a virtual machine (gasp!)… It would not be wise to, say, suspend my VMware Windows 8 guest while SkyDrive is “processing changes”—so I would like to stop this crap before I hit Ctrl-J. So the solution (workaround) to this “issue” is to close Microsoft Word 2013 before I suspend the virtual machine. 1990s sad. I assume that Word is, again, locking the Office document, preventing SkyDrive from doing its work. All I know is that when I close Word the spinning in System Tray under the SkyDrive notification icon stops. In fact, it’s happening right now as I write this paragraph. So let me just close Word here so 21<sup>st</sup>–century technological progress can surge forward…

## Windows 8 and VMWare Workstation

[<img alt="Building Windows 8 Apps with JavaScript" src="http://ecx.images-amazon.com/images/I/416ZIbKiJML._SL160_.jpg" style="float:left;margin:16px;">](http://www.amazon.com/Building-Windows-8-Apps-JavaScript/dp/0321861280%3FSubscriptionId%3D1SW6D7X6ZXXR92KVX0G2%26tag%3Dthekintespacec00%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3D0321861280 "Building Windows 8 Apps with JavaScript")

I was very pleased to find Windows 8 working quite well as a Guest and a Host for VMWare. Just two issues jump out at me. One was solved by disabling **Grab when cursor enters window** and turning off Windows 8 [edge-swipe support](http://superuser.com/questions/557541/changing-windows-8-edge-swipe-behavior) for my Sager’s touchpad. I am almost certain that VMware is not interpreting swipes properly.

The other problem I cannot fix: from time to time the Guest display will drop down to 800×600. All of my Guest-resizing tricks while the VM is hot do not work. I usually end up rebooting the Guest to fix the problem or, worse, reinstalling VMware Tools (which ends with a Guest reboot).

## Related Links

<table class="WordWalkingStickTable"><tr><td>

“[Windows 7 sync client for Windows Phone 8 handsets now available](http://wmpoweruser.com/windows-7-sync-client-for-windows-phone-8-handsets-now-available/)”
</td><td>

“With only a small percentage of Windows users having upgraded to Windows 8, I suspect there are quite a few looking for a sync/phone management client for their new Windows Phone 8 phone to use in Windows 7.”
</td></tr><tr><td>

“[Amazing Windows 8 Themes You Need To See](http://www.makeuseof.com/tag/amazing-windows-8-themes-you-need-to-see/)”
</td><td>

“Like previous versions of Windows, Windows 8 doesn’t support third-party desktop themes out of the box. You’ll need to patch some system files. This isn’t is scary as it sounds—all you need to do is download and run UltraUXThemePatcher. You’ll be prompted to reboot your computer after running the installer.”
</td></tr><tr><td>

“[Guide on replacing your Nokia Lumia 920 battery](http://wmpoweruser.com/guide-on-replacing-your-nokia-lumia-920-battery/)”
</td><td>

“I am sure the vast majority of us are still fully within our Nokia Lumia 920 warranty period, but I know there are many adventurous souls who do not mind violating their warranty to get things done.”
</td></tr><tr><td>

“[Nokia Lumia 920 Cell Phone Bluetooth Headsets](http://www.accessorywiz.com/shop-by-brand/nokia-1/nokia-lumia-92-1/bluetooth-headsets-3652/)”
</td><td>

My [Plantronics M50](http://www.amazon.com/Plantronics-M50-Bluetooth-Headset-Packaging/dp/B005IMB5NG%3FSubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=B005IMB5NG) headset does not pair properly with Nokia Lumia. So I’m forced to look into this…
</td></tr><tr><td>

“[Nokia Wireless Charging Pillow by Fatboy](http://www.amazon.com/Nokia-DT-901-Wireless-Charging-Pillow/dp/B00A3NCC8C%3FSubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=B00A3NCC8C)”
</td><td>

“Not sure why these things cost so much. It's basically a base Nokia charging puck inside a bag, big deal. These things should be selling for $60 max IMO. Charging time seems to be on par with when I use my USB cable but just hassle free. I wish the wall plug portion was a bit more [svelte] but whatever.”
</td></tr></table>
