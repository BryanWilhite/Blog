---json
{
  "documentId": 0,
  "title": "studio status report: 2019-07",
  "documentShortName": "2019-07-22-studio-status-report-2019-07",
  "fileName": "index.html",
  "path": "./entry/2019-07-22-studio-status-report-2019-07",
  "date": "2019-07-22T18:54:32.513Z",
  "modificationDate": "2019-07-22T18:54:32.513Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2019-07-22-studio-status-report-2019-07",
  "tag": "{\r\n  \"extract\": \"month-6 was about switching to Hyper-V, being 134% behind and 11tyMy studio notes on setting up Ubuntu on Hyper-V boil down to this: Install OS (minimal install) from *.ISO on Generation 2 VM without RemoteFX 3D Video Adapter (with Checkpoints Disabled)Co...\"\r\n}"
}
---

# studio status report: 2019-07

## month-6 was about switching to Hyper-V, being 134% behind and 11ty

My studio notes on setting up Ubuntu on Hyper-V boil down to this:

* Install OS (minimal install) from *.ISO on Generation 2 VM without RemoteFX 3D Video Adapter (with Checkpoints Disabled)
* Configure `hyperv_fb` to support max-res (`1920x1080`): [https://www.sysnettechsolutions.com/en/hyperv/change-screen-resolution-in-ubuntu-on-hyper-v/](https://www.sysnettechsolutions.com/en/hyperv/change-screen-resolution-in-ubuntu-on-hyper-v/)
* Use Ubuntu Software to install Bing Wallpaper Changer, Chromium and Visual Studio Code
* Install `ucaresystem-core`: [https://www.utappia.org/2016/03/ucaresystem-core-v30-released-and.html](https://www.utappia.org/2016/03/ucaresystem-core-v30-released-and.html)
* Move the Home folder to a separate virtual disk: [https://www.maketecheasier.com/move-home-folder-ubuntu/](https://www.maketecheasier.com/move-home-folder-ubuntu/)
* Install curl
* Run ssh-keygen for git SSH
* Install git with `git config --global user.name "Bryan Wilhite"` and `git config --global user.email "rasx@songhaysystem.com"`
* Clone `Songhay.Shell` and install Monoid Font
* Install current .NET Core SDK
* Install Node.JS and NPM

Even though this studio is divesting in VMWare, it is now clear that VMWare has one advantage: its host-guest software *feels* superior to that of Hyper-V but this superiority *feels* like it comes at a cost—and Microsoft by design might *prefer* to limit guest desktop resolution and the clipboard (but [depending on XOrg and prompt for an “enhanced” session](https://www.tenforums.com/virtualization/127999-hyper-v-windows-linux-rdc-rdp-no-connection-after-xorg-loging.html)*feels* a bit cynical).

*Being 134% behind.* This switch to Hyper-V (as well as the revival of Daz3D Studio) coupled with [the buzz around the “return” of AMD via Ryzen](https://www.youtube.com/watch?v=0GjSiLbCtHU) has inspired research into just how behind my studio hardware is to the state of the art. Answer: [134% percent behind](https://cpu.userbenchmark.com/Compare/AMD-Ryzen-7-2700X-vs-AMD-Phenom-II-X6-1055T/3958vs2003).

*The FunkyKB runs on 11ty.* This is success: [https://bryanwilhite.github.io/the-funky-knowledge-base/](https://bryanwilhite.github.io/the-funky-knowledge-base/) The 11ty-based pipeline brings together the preference in this studio for working with static JSON and static site generation (which I have been messing about with since the late 1990s). 11ty will allow this studio to:

* formally replace ancient XSLT-based templates
* eliminate the need for recognizing XHTML as a core architectural element
* allow APIs returning static JSON to fuel static site generation

That last bullet point is huge: `Songhay.Publications` and `GenericWeb` can shed *all* document-generating responsibilities because of a tool like 11ty.

I have updated my sketchy TODO list below to assert that `Songhay.Blog`*can* make the switch to an 11ty-based pipeline *and* use Angular as a supplement to the static site (a different take on “progressive enhancement”).

## sketching out a development schedule (revision 2)

Today the studio development schedule looks like this:

* ~~get 11ty pipelines running with the FunkyKB~~ ✔
* migrate Thunderbird email to new Hyper-V Ubuntu VM 🚜🚛🚛
* update SonghaySystem.com with my new `@songhay/player-video-you-tube` and `@songhay/index` 📦
* convert the Day Path blog to 11ty (with `@songhay/index` as a side-car app) 💪💡
* convert SonghaySystem.com to HTTPs by default 🔐
* convert Day Path Blog to HTTPs by default 🔐
* use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
* move the kinté space blog to an 11ty pipeline (this has been another emergency *for years*) 🔥🔥🔥😬
* set up automated social-media posting with Azure logic apps (and Azure functions orchestration) ☁🤖
* modernize the kinté hits page into a progressive web app 💄✨
* use the learnings of previous work to upgrade and re-release the kinté space 🚀

<https://github.com/BryanWilhite/>
