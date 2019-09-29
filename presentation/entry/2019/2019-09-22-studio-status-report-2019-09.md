---json
{
  "author": null,
  "content": "month-9 has been about actually using @songhay/player-video-you-tubeThe NPM package @songhay/player-video-you-tube is installed and compiling into the build for SonghaySystem.com.👏 (BTW: it was editorial error to mention @songhay/index for the last few ...",
  "inceptDate": "2019-09-22T11:03:05.6230344-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "studio-status-report-2019-09",
  "sortOrdinal": 0,
  "tag": null,
  "title": "studio status report: 2019-09"
}
---

### month-9 has been about actually using `@songhay/player-video-you-tube`

The NPM package `@songhay/player-video-you-tube` is installed and compiling into the build for SonghaySystem.com.👏 (BTW: it was editorial error to mention `@songhay/index` for the last few months as this package is not in use for the Songhay Dashboard 😒). The following GitHub issues detail the transition:

*   [https://github.com/BryanWilhite/Songhay.Dashboard/issues/53](https://github.com/BryanWilhite/Songhay.Dashboard/issues/53)
*   [https://github.com/BryanWilhite/Songhay.Dashboard/issues/54](https://github.com/BryanWilhite/Songhay.Dashboard/issues/54)
*   [https://github.com/BryanWilhite/Songhay.Dashboard/issues/55](https://github.com/BryanWilhite/Songhay.Dashboard/issues/55)
*   [https://github.com/BryanWilhite/Songhay.Dashboard/issues/59](https://github.com/BryanWilhite/Songhay.Dashboard/issues/59)

### Daz3D Studio is stabilized

The ultimate fix for my recent Daz3D problems was to reinstall Windows 10 (the 1903 build) which was painful and time consuming. It was important to install MSI drivers [the old-fashioned way](https://www.arduino.cc/en/Guide/DriverInstallation) (with the **Browse my computer for driver software** command) and not trust any default suite installs from any optical media.

The [Nahimic service](https://forums.tomshardware.com/threads/nahimic-audio-service.3396247/) (installed by MSI optical media) was found to be directly correlated to causing Daz3D studio to crash with the white view ports. This trial-and-error process with the [Services Manager](https://www.howtogeek.com/school/using-windows-admin-tools-like-a-pro/lesson8/) and `MSCONFIG.EXE` was also painful and time consuming.

### `@songhay/index` and lunr and/or Bing Web Search API

Converting the Day Path Blog to 11ty has some back-end implications. The 11ty pipeline will be based on markdown, eliminating JSON as the storage format. This implies that [Azure Search over JSON in Azure Storage](http://songhayblog.azurewebsites.net/blog/entry/setting-up-an-azure-search-json-blob-indexer-with-api-version-2015-02-28-preview) can no longer be used to drive Index App search.

I think the Index App should be based on [lunr](https://lunrjs.com/) and [Bing Web Search](https://azure.microsoft.com/en-us/services/cognitive-services/bing-web-search-api/) (or some open source equivalent). This new thinking should be made coherent with the old thinking of this issue: [https://github.com/BryanWilhite/songhay-ng-workspace/issues/13](https://github.com/BryanWilhite/songhay-ng-workspace/issues/13)

### sketching out a development schedule (revision 3)

Today the studio development schedule looks like this:

*   <del>get 11ty pipelines running with the FunkyKB</del> ✔
*   <del>migrate Thunderbird email to new Hyper-V Ubuntu VM</del> ✔
*   <del>move the kinté space blog to an 11ty pipeline (this has been another emergency *for years*)</del> ✔
*   <del>update SonghaySystem.com with my new `@songhay/player-video-you-tube`</del> ✔
*   convert the Day Path blog to 11ty (with `@songhay/index` as a side-car app) 💪💡
*   convert SonghaySystem.com to HTTPs by default 🔐
*   convert Day Path Blog to HTTPs by default 🔐
*   use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
*   set up automated social-media posting with Azure logic apps (and Azure functions orchestration) ☁🤖
*   modernize the kinté hits page into a progressive web app 💄✨
*   use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/bryanwilhite)
