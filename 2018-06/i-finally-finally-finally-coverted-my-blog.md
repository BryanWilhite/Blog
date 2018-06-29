## I finally, finally, finally converted my Blog to Angular modern…

Meh. Blow a party whistle. And I am _far_ from “done,” by the way. I now understand why [Scott Hanselman](https://www.hanselman.com/blog/) would stay with ASP.NET Web Forms and no SPA-action for his Blog. I have been dealing with this ‘challenge’ _actively_ since the summer of 2017. These are challenges I set up for myself (not really understanding that each of these challenges had at least three challenges wrapped inside):

* maintain a private-sector day job (compared to a government or academic job)
* convert from Visual Studio web-building workflows to Visual Studio Code workflows
* convert my .NET 4.x investments to .NET Core in general and .NET Standard 2.0 in particular
* maintain a private-sector day job
* migrate from a few huge Team Foundation Server solutions to many, many Git repositories
* migrate to a Node.js based development culture
* migrate from Angular JS to Angular
* maintain a private-sector day job
* establish a Visual Studio Team Services CI/CD pipeline for multiple Git repositories

It is clear—abundantly clear—that I am not converting from Angular JS to Angular in a vacuum. I am converting multiple production pipelines over to a new paradigm as well as converting from Angular JS to Angular. This is the downside of being a developer with legacy load, struggling to stay out of technical debt.

### many, many Git repositories

I will attempt to list the Git repositories I built for this mega-conversion in the proper chronological order to explain (even to myself) what the hell I was doing. Each of these repositories contain their own histories, detailing more of my joy and pain—and pain. It may help to mention that I have been using Team Foundation Services to host a few huge Team Foundation Server (TFS) solutions that I have been building up for over a decade. Most of these GitHub repositories draw from these TFS solutions:

`[SonghayCore](https://github.com/BryanWilhite/SonghayCore)`: all my Blog sites have run on top this Core so this had to move first. [My contributions](https://github.com/BryanWilhite/SonghayCore/graphs/contributors) show I started this process in the summer of 2016. It may help to mention that I use the assets in this repository for my day job.

`[Songhay.Cloud.BlobStorage](https://github.com/BryanWilhite/Songhay.Cloud.BlobStorage)`: all of my MVC-era Blog sites have run on top Azure Storage, abstracted into a repository. [My contributions](https://github.com/BryanWilhite/Songhay.Cloud.BlobStorage/graphs/contributors) show I started this process in the autumn of 2017. For the reader who would prefer to not get into this ‘trap’ I have set up for myself, it may help to mention that this month Microsoft has announced “[Static website hosting for Azure Storage now in public preview](https://azure.microsoft.com/en-us/blog/azure-storage-static-web-hosting-public-preview/)” which _should_ do well with a [static website generator](https://www.smashingmagazine.com/2015/11/static-website-generators-jekyll-middleman-roots-hugo-review/).

`[Songhay.Social](https://github.com/BryanWilhite/Songhay.Social)`: this repository supports the Tweeted Links posts, a Blog post made of Twitter statuses which has been totally dominating my Blog posting for the last few years. [My contributions](https://github.com/BryanWilhite/Songhay.Social/graphs/contributors) show I started this process in the winter of this year.

`[Songhay.Feeds](https://github.com/BryanWilhite/Songhay.Feeds)`: this repository is the solution to generating RSS feeds in a JSON format for UI display via a back-end [Azure job](https://docs.microsoft.com/en-us/azure/app-service/web-sites-create-web-jobs). The RSS feed for my Blog is now broken as this is functionality is not running in the cloud as of this writing. [My contributions](https://github.com/BryanWilhite/Songhay.Feeds/graphs/contributors) show I started this process in the winter of this year.

`[dotnet-core](https://github.com/BryanWilhite/dotnet-core)`: I started this repository [in the fall of 2017](https://github.com/BryanWilhite/dotnet-core/graphs/contributors) to teach myself .NET Core and ASP.NET Core. I am passionate about learning in public, demystifying this process for less experienced developers.

`[nodejs](https://github.com/BryanWilhite/nodejs)`: I started this repository [in the spring of 2017](https://github.com/BryanWilhite/nodejs/graphs/contributors) to, as aforementioned, ‘migrate to a Node.js based development culture.’

`[angular.io-index-app](https://github.com/BryanWilhite/angular.io-index-app)`: this repository represents my intention to standardize my studio around an Index app for SPA solutions. This Blog as of this writing is currently running off of a ‘seed’ based on this Index app. I started this repository [in the autumn of 2017](https://github.com/BryanWilhite/angular.io-index-app/graphs/contributors) _after_ experimenting with [aurelia-index-app](https://github.com/BryanWilhite/aurelia-index-app).

`[Songhay.Blog](https://github.com/BryanWilhite/Songhay.Blog)`: as of this writing this repository is the engine behind this Blog site, started [in the spring of 2018](https://github.com/BryanWilhite/Songhay.Blog/graphs/contributors). It is quite intimidating (to me) to see that all of the repositories mentioned above made this repository possible.

Since I am clearly not as bright as Scott Hanselman, I have been laboring under the assumption that like a fictional Jedi I have to waste years of my real life trying to build my own light saber, using patterns and practices that both conform and deviate from the norm. The principle I am trying to uphold is simple but has been quite brutal (on me): my technical Blog should be built by me. When I started this Blog there was nothing in the ASP.NET MVC world for blogging on the scale of, say, WordPress. It follows quite naturally that I followed [the example of Chris Fulstow](http://songhayblog.azurewebsites.net/blog/entry/replacing-my-nblog-with-a-read-only-angular-js-seed-over-web-api) and went out on my own… I do not recommend doing this. Today, I would recommend a [static website generator](https://www.smashingmagazine.com/2015/11/static-website-generators-jekyll-middleman-roots-hugo-review/). But do understand that I make this recommendation _after_ learning about ASP.NET MVC by building my own Blog site(s).

Going forward my plan is to continue posting Tweeted Links—like [my latest one](http://songhayblog.azurewebsites.net/blog/entry/the-2018-front-end-performance-checklist-and-other-tweeted-links) as of this writing—and Blog posts detailing how I am finishing this Blog site. Writing about what I am doing motivates me to work—even when no one is reading about what I am writing. I understand this weird thing about myself so it has been quite uncomfortable to endure about three years without a technical blogging platform. I welcome myself back. I hope Bing search bots will index this thing correctly.

@[BryanWilhite](https://twitter.com/bryanwilhite)
