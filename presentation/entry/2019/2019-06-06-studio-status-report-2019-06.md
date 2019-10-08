---json
{
  "documentId": 0,
  "title": "studio status report: 2019-06",
  "documentShortName": "2019-06-06-studio-status-report-2019-06",
  "fileName": "index.html",
  "path": "./entry/2019-06-06-studio-status-report-2019-06",
  "date": "2019-06-06T18:35:09.842Z",
  "modificationDate": "2019-06-06T18:35:09.842Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2019-06-06-studio-status-report-2019-06",
  "tag": "{\r\n  \"extract\": \"I missed last month 😒🤷‍️😁month-4 was all about upgrading SonghayCore 🐰🕳I have started using GitHub projects to batch issues together to mark a NuGet release. My first project, version 3.1.3 release, records the miserable but compelling details aroun...\"\r\n}"
}
---

# studio status report: 2019-06

I missed last month 😒🤷‍️😁

## month-4 was all about upgrading `SonghayCore` 🐰🕳

I have started using GitHub projects to batch issues together to mark a NuGet release. My first project, [version 3.1.3 release](https://github.com/BryanWilhite/SonghayCore/projects/1), records the miserable but compelling details around moving [`SonghayCore`](https://github.com/BryanWilhite/SonghayCore) into [the .NET Core multi-targeting space](https://github.com/BryanWilhite/SonghayCore/issues/20#issuecomment-489815352).

The feeling around doing this work is that of optimistic relief that [`SonghayCore`](https://github.com/BryanWilhite/SonghayCore) has never been more stable and it should be far easier to maintain going forward. This should prevent me from falling into a costly rabbit hole while trying to dig pits of success. Too much of my time *on this planet* has been spent on building infrastructure instead of publications and presentations for *people*.

## WebJobs *and* Azure durable functions

Month 5 was about understanding that the main reason why one would continue to use WebJobs instead of dropping everything and running to [Azure Durable Functions](https://mikhail.io/2018/12/making-sense-of-azure-durable-functions/) (for its *orchestration* feature), is the need for a local file system. I have assigned myself to [a GitHub issue](https://github.com/BryanWilhite/Songhay.Feeds/issues/14) that will explore this matter further.

The plan is to move the YouTube player WebJob to Azure durable functions (because it should *not* depend on a local file system) but the steps toward this goal start with [yet another issue](https://github.com/BryanWilhite/Songhay.HelloWorlds.Activities/issues/1) I have self assigned.

More Azure function links:

* [https://docs.microsoft.com/en-us/azure/azure-functions/functions-best-practices](https://docs.microsoft.com/en-us/azure/azure-functions/functions-best-practices)
* [https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-vs-code](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-vs-code)
* [https://azure.microsoft.com/en-us/blog/introducing-azure-functions-2-0/](https://azure.microsoft.com/en-us/blog/introducing-azure-functions-2-0/) [2.0 does not support full framework]

## the `songhay-ng-workspace` is considered awesome

[`songhay-ng-workspace`](https://github.com/BryanWilhite/songhay-ng-workspace) is the *best* UI/UX work this studio has to offer. There is quite a long way to go but this repo makes a strong statement around core data access with the Observable Data Store, the Index experience and introduces the YouTube portion of our b-roll player.

## `the-funky-knowledge-base` is the first 11ty experiment

[`the-funky-knowledge-base`](https://github.com/BryanWilhite/the-funky-knowledge-base) should find its final home on GitHub. It will be converted from JSON static files to markdown. It is likely that it will replace most of my use Microsoft OneNote. Some OneNote issues:

* there is no “pro” command to paste plain text
* there is no “pro” command to purge previous versions of a page; I assume this purging will prevent certain syncing errors
* there is no concept of a *character* style (from Microsoft Word) there are only *paragraph* styles

Success with 11ty will place this technology at the center of Songhay Publications: the static web site will be the go-to publication format of this studio. kintespace.com will deliberately be a patchwork mosaic of static websites (tracked by gen-web-based analytics).

## proposing Microsoft Sway as a publication solution for kintespace.com

Yes, the 11ty-based static web site is the go-to publication format but Microsoft Sway might do well as a replacement for the PDF-based presentations of visual artists (on kintespace.com).

My renewed interest in Sway was announced [in a month-5 tweet](https://twitter.com/BryanWilhite/status/1123661538437390336).

## how to download an MP3 file from Azure BLOB Storage with ASP.NET Core 2.2

<div class="sourceCode">

<code class="sourceCode cs"><span class="co">/// </span><span class="kw">&lt;summary&gt;</span><span class="co">/// Gets the presentation BLOB for progressive audio.</span><span class="co">/// </span><span class="kw">&lt;/summary&gt;</span><span class="co">/// </span><span class="kw">&lt;param</span><span class="ot"> name=</span><span class="dt">"presentationKey"</span><span class="kw">&gt;</span><span class="co">The presentation key.</span><span class="kw">&lt;/param&gt;</span><span class="co">/// </span><span class="kw">&lt;param</span><span class="ot"> name=</span><span class="dt">"subFolder"</span><span class="kw">&gt;</span><span class="co">The sub folder.</span><span class="kw">&lt;/param&gt;</span><span class="co">/// </span><span class="kw">&lt;param</span><span class="ot"> name=</span><span class="dt">"blobName"</span><span class="kw">&gt;</span><span class="co">Name of the BLOB.</span><span class="kw">&lt;/param&gt;</span><span class="co">/// </span><span class="kw">&lt;returns&gt;&lt;</span><span class="ot">/returns</span><span class="kw">&gt;</span>
[HttpGet]
[<span class="fu">Route</span>(<span class="st">"audio/{presentationKey}/{subFolder}/{blobName}"</span>)]
<
span class="kw">public</span> async Task&lt;IActionResult&gt; <span class="fu">GetPresentationBlobForProgressiveAudio</span>(<span class="dt">string</span> presentationKey, <span class="dt">string</span> subFolder, <span class="dt">string</span> blobName)
{
            <span class="dt">var</span> repo = <span class="kw">this</span>._blobRepositoryForProgressiveAudioContent;
            <span class="dt">var</span> id = repo.<span class="fu">GetPresentationBlobId</span>(presentationKey, subFolder, blobName);
            <span class="dt">var</span> result = await repo.<span class="fu">GetBlobAsync</span>(id);
            <span class="kw">if</span> (result?.<span class="fu">BlobStream</span> == <span class="kw">null</span>) <span class="kw">return</span><span class="kw">this</span>.<span class="fu">NotFound</span>();
            <span class="kw">if</span> (result.<span class="fu">BlobStream</span>.<span class="fu">Position</span> &gt; <span class="dv">0</span>) result.<span class="fu">BlobStream</span>.<span class="fu">Seek</span>(<span class="dv">0</span>, SeekOrigin.<span class="fu">Begin</span>);

<span class="kw">return</span><span class="kw">this</span>.<span class="fu">File</span>(result.<span class="fu">BlobStream</span>, result.<span class="fu">BlobContentType</span>, result.<span class="fu">BlobFileName</span>);
}</code>

</div>

The most important line here is:

<div class="sourceCode">

<code class="sourceCode cs"><span class="kw">if</span> (result.<span class="fu">BlobStream</span>.<span class="fu">Position</span> &gt; <span class="dv">0</span>) result.<span class="fu">BlobStream</span>.<span class="fu">Seek</span>(<span class="dv">0</span>, SeekOrigin.<span class="fu">Begin</span>);</code>

</div>

Without this line, a file of 0-bytes will be saved by callers of this API.

## the wonderful return of Daz3D to regular studio work

Month 5 saw the return of [Daz3D](https://www.daz3d.com/) to my studio work. The manga-publication production pipeline is revived which is almost the whole point of my existence. Using my kintespace account on InstaGram, I reminded myself that I have not touched Daz since 2003! Here are some points:

* My developer-honed journal-writing skills really help here (not my thing that much in 2003)
* Daz technology has improved: [DForm](http://docs.daz3d.com/doku.php/artzone/pub/software/dform/start) and [Puppeteer](http://docs.daz3d.com/doku.php/artzone/pub/software/puppeteer/start) did not exist in 2003
* the availability of comic-book-style shaders, like [Visual-Style](https://www.daz3d.com/visual-style-shaders) and [Manga-Style](https://www.daz3d.com/manga-style-shaders), (and my mature appreciation of them)
* Daz has been helped tremendously by YouTube folks like [WP Guru](https://www.youtube.com/user/wphosting) and [esha](https://www.youtube.com/channel/UCuk28jyQ5x2MZl0_k2-gXJg)—which helps me tremendously.
* the gulf between Daz and Blender is almost gone—definitely not the case in 2003.

Most importantly, I have matured tremendously when it comes to this kind of production. After being beaten to death by multi-hundred-million-dollar, photorealistic CGI for a decade, I am no longer fascinated by replicating reality. I now see that tweening and animating can inform and produce *stills* meant for a Manga publication. So stills an animation is not necessarily an either-or thing—it is a both-and thing.

And, by the way, OneNote really, really helps here because it is the best at handing a bunch of screenshots.🤷‍

## sketching out a development schedule (revision 1)

Today the studio development schedule looks like this:

* update SonghaySystem.com with my new `@songhay/player-video-you-tube` and `@songhay/index`
* get 11ty pipelines running with the FunkyKB
* consider converting the Day Path blog to 11ty (with `@songhay/index` as a side-car app) and convert to HTTPs by default
* use the learnings from existing npm packages to build `@songhay/player-audio-???`
* move the kinté space blog to an 11ty pipeline (this has been another emergency *for years*)
* set up automated social-media posting with Azure logic apps (and Azure functions orchestration)
* modernize the kinté hits page into a progressive web app
* use the learnings of previous work to upgrade and re-release the kinté space

@[BryanWilhite](https://twitter.com/bryanwilhite)

@[BryanWilhite](https://twitter.com/BryanWilhite)
