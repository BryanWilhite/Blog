---json
{
  "author": null,
  "content": "Going forward from here my passive-voice intention is to keep track of myself monthly. My work habits have always included keeping a private journal. In the “early years,” one Microsoft Word document per year was enough. As my software-development surfac...",
  "inceptDate": "2018-08-10T10:25:50.0396698-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "studio-status-report-2018-08",
  "sortOrdinal": 0,
  "tag": null,
  "title": "studio status report: 2018-08"
}
---

Going forward from here my passive-voice intention is to keep track of myself monthly. My work habits have always included keeping a private journal. In the “early years,” one Microsoft Word document per year was enough. As my software-development surface area grew, Microsoft OneNote became my secondary journal tool. From Microsoft OneNote, Markdown and GitHub-based cultural habits sinks in. This journal file is part my latest journal tooling.

### the work on the new SonghaySystem.com has started

GitHub is [tracking the progress](https://github.com/BryanWilhite/Songhay.Dashboard/issues) with a level detail designed to handle the possibility of short-term memory loss from a guy that is not in his twenties with lots of spare time.

[Issue #7](https://github.com/BryanWilhite/Songhay.Dashboard/issues/7) is the first (?) public mention of the B-Roll player (its YouTube-related features) running on modern Angular. This is a studio milestone. Insert dramatic film-score music here. It looks likes the last time I mentioned this product under development was [in 2016](http://songhayblog.azurewebsites.net/blog/entry/my-autofac-packages-drama).

### I have turned off CI on VSTS

After discovering that adding Node-based builds to an ASP.NET Core Solution skyrocketed to 11 minutes, I started turning off Continuous Integration (CI) on VSTS. Moreover, I finally see that `dotnet test` tasks can specify multiple test projects like this:

        **/*Tests.csproj
    !**/Songhay.GenericWeb.Mvvm*/*.csproj

This discovery allows me to remove all of those `IgnoreAttribute` declarations and target more precisely.

The new [VSTS UI looks great](https://twitter.com/BryanWilhite/status/1024687355158884354) but it still does not allow me to see at a glance the CI state of builds.

### Flickr seems to allow uploads again

[Triangulation 351: SmugMug and Flickr](https://www.youtube.com/watch?v=pIboZj-gb7Q) features Don MacAskill, Founder of SmugMug, detailing their commitment to keep the brand and continue to develop the existing base.

The studio currently depends on Flickr to archive and serve screenshots. I suspect that there is another more dedicated service that is much better suited for screenshots. The social sharing site, [Imgur](https://imgur.com/), is not that service.

[SNAGGY](https://snag.gy/) is closer to what I am thinking about but there is this caveat: “If you make an account, your images will be stored as long as they have been viewed at least once in the last 6 months. Pro accounts, an upcoming feature, will have unlimited storage lifetime.”

The guidance in “ [Share and save screenshots with Dropbox](https://www.dropbox.com/help/photos-videos/screenshots)” look like it’s worth a try *but* my use of [Greenshot](https://chocolatey.org/packages/greenshot) clashes with the workflow.

### an Azure-based screenshot solution?

What might be a great, simple, *central* solution to sharing screenshots involves throwing images (using the new [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)) on a BLOB container. All legacy screenshots can be moved there.

@ [BryanWilhite](https://twitter.com/bryanwilhite)
