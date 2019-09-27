---json
{
  "author": null,
  "content": "month-7 was about moving the kinté space Blog into an 11ty pipeline11ty pipeline for kintespace.com Blog. I am almost certain that end-of-month-8 or early month 9 will see the re-launch of the kintespace.com Blog without WordPress! Success here will make...",
  "inceptDate": "2019-08-24T21:16:23.113443-07:00",
  "isPublished": true,
  "itemCategory": "\"year\":2019,\"month\":\"08\",\"day\":\"24\",\"dateGroup\":\"2019\\/08\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2019-08-24-studio-status-report",
  "sortOrdinal": 0,
  "tag": null,
  "title": "studio status report: 2019-08"
}
---

## studio status report: 2019-08

### month-7 was about moving the kinté space Blog into an 11ty pipeline

_11ty pipeline for kintespace.com Blog._ I am almost certain that end-of-month-8 or early month 9 will see the re-launch of the kintespace.com Blog _without_ WordPress! Success here will make _the rasx() context_ a standalone Songhay Publication on an 11ty production pipeline. This implies that I finally see the way to use 11ty to write to a sibling folder or a folder of another parent—this means every presentation/publication can have its own repo👍 This implies I can make _some_ presentations/publications public on GitHub and use them as a guide for any sophisticated, 3<sup>rd</sup>-party contributors in future💪💡

### month-8 is about SSD and/or motherboard failure and Daz3D AppHangTransient errors

_SSD and/or motherboard failure._ My internal hardware journal is packed full of a miserable adventure that all started with me falsely accusing myself of letting studio hardware age over five years. It turns out that the eldest piece, a Western Digital Black (Scorpio?) 320 GB 2.5" drive from 2011, did _not_ fail. Either my Samsung EVO SSD from 2017 dropped into a read-only-mode coma or my Asus M5A97 motherboard from 2015 independently decided there was no operating system volume. This drama left me with a few takeaways:

- consider [customizing the Windows 10 paging-file strategy](https://www.howto-connect.com/tweak-paging-file-for-better-windows-10-performance/) to encourage the OS to beat up a mechanical drive with a huge paging-file allocation
- MSI motherboard RAM slots ship with LEDs that glow _red_ when everything is apparently fine
- consider adding calendar events for studio-hardware, five-year birthdays

_Daz3D AppHangTransient errors._ After serious suffering with the hardware woes above, I was very much looking forward to seeing Daz3D Studio 4.11.x running on this new hardware. Nope. 😶 Here are/were the suspicious issues that could be preventing Daz from running:

- the PostgreSQL CMS is not starting
- ~~the Radeon Virtual Super Resolution settings being on~~
- ~~the default paging file is too small for Daz3D (on the new system)~~
- my old-ass Radeon R9 270X is not really working properly on the new MSI AMD X470 motherboard

Until this issue is resolved, I can fall back to my Sager laptop (and an HDMI cable) to work with Daz3D there.😬😒

### sketching out a development schedule (revision 2)

Today the studio development schedule looks like this:

- ~~get 11ty pipelines running with the FunkyKB~~ ✔
- ~~migrate Thunderbird email to new Hyper-V Ubuntu VM~~ ✔
- move the kinté space blog to an 11ty pipeline (this has been another emergency _for years_) 🔥🚜🔨
- update SonghaySystem.com with my new `@songhay/player-video-you-tube` and `@songhay/index` 📦
- convert the Day Path blog to 11ty (with `@songhay/index` as a side-car app) 💪💡
- convert SonghaySystem.com to HTTPs by default 🔐
- convert Day Path Blog to HTTPs by default 🔐
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- set up automated social-media posting with Azure logic apps (and Azure functions orchestration) ☁🤖
- modernize the kinté hits page into a progressive web app 💄✨
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/bryanwilhite)
