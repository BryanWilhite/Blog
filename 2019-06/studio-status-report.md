## studio status report: 2019-06

I missed last month 😒🤷‍️😁

### month-4 was all about upgrading `SonghayCore` 🐰🕳

I have started using GitHub projects to batch issues together to mark a NuGet release. My first project, [version 3.1.3 release](https://github.com/BryanWilhite/SonghayCore/projects/1), records the miserable but compelling details around moving [`SonghayCore`](https://github.com/BryanWilhite/SonghayCore) into [the .NET Core multi-targeting space](https://github.com/BryanWilhite/SonghayCore/issues/20#issuecomment-489815352).

The feeling around doing this work is that of optimistic relief that [`SonghayCore`](https://github.com/BryanWilhite/SonghayCore) has never been more stable and it should be far easier to maintain going forward. This should prevent me from falling into a costly rabbit hole while trying to dig pits of success. Too much of my time _on this planet_ has been spent on building infrastructure instead of publications and presentations for _people_.

### the `songhay-ng-workspace` is considered awesome

[`songhay-ng-workspace`](https://github.com/BryanWilhite/songhay-ng-workspace) is the _best_ UI/UX work this studio has to offer. There is quite a long way to go but this repo makes a strong statement around core data access with the Observable Data Store, the Index experience and introduces the YouTube portion of our b-roll player.

### `the-funky-knowledge-base` is the first 11ty experiment

[`the-funky-knowledge-base`](https://github.com/BryanWilhite/the-funky-knowledge-base) should find its final home on GitHub. It will be converted from JSON static files to markdown. It is likely that it will replace most of my use Microsoft OneNote. Some OneNote issues:

- there is no “pro” command to paste plain text
- there is no “pro” command to purge previous versions of a page; I assume this purging will prevent certain syncing errors
- there is no concept of a _character_ style (from Microsoft Word) there are only _paragraph_ styles

Success with 11ty will place this technology at the center of Songhay Publications: the static web site will be the go-to publication format of this studio. kintespace.com will deliberately be a patchwork mosaic of static websites (tracked by gen-web-based analytics).

### proposing Microsoft Sway as a Presentation solution for kintespace.com

Yes, the 11ty-based static web site is the go-to publication format but Microsoft Sway might do well as a replacement for the PDF-based presentations of visual artists (on kintespace.com).

My renewed interest in Sway was announced [in a month-5 tweet](https://twitter.com/BryanWilhite/status/1123661538437390336).

### how to download an MP3 file from Azure BLOB Storage with ASP.NET Core 2.2

```c#
/// <summary>
/// Gets the presentation BLOB for progressive audio.
/// </summary>
/// <param name="presentationKey">The presentation key.</param>
/// <param name="subFolder">The sub folder.</param>
/// <param name="blobName">Name of the BLOB.</param>
/// <returns></returns>
[HttpGet]
[Route("audio/{presentationKey}/{subFolder}/{blobName}")]
public async Task<IActionResult> GetPresentationBlobForProgressiveAudio(string presentationKey, string subFolder, string blobName)
{
    var repo = this._blobRepositoryForProgressiveAudioContent;
    var id = repo.GetPresentationBlobId(presentationKey, subFolder, blobName);
    var result = await repo.GetBlobAsync(id);
    if (result?.BlobStream == null) return this.NotFound();
    if (result.BlobStream.Position > 0) result.BlobStream.Seek(0, SeekOrigin.Begin);

    return this.File(result.BlobStream, result.BlobContentType, result.BlobFileName);
}
```

The most important line here is:

```c#
if (result.BlobStream.Position > 0) result.BlobStream.Seek(0, SeekOrigin.Begin);
```

Without this line, a file of 0-bytes will be saved by callers of this API.

### the wonderful return of Daz3D to regular studio work

Month 5 saw the return of [Daz3D](https://www.daz3d.com/) to my studio work. The manga-publication production pipeline is revived which is almost the whole point of my existence. Using my kintespace account on InstaGram, I reminded myself that I have not touched Daz since 2003! Here are some points:

- My developer-honed journal-writing skills really help here (not my thing that much in 2003)
- Daz technology has improved: [DForm](http://docs.daz3d.com/doku.php/artzone/pub/software/dform/start) and [Puppeteer](http://docs.daz3d.com/doku.php/artzone/pub/software/puppeteer/start) did not exist in 2003
- the availability of comic-book-style shaders, like [Visual-Style](https://www.daz3d.com/visual-style-shaders) and [Manga-Style](https://www.daz3d.com/manga-style-shaders), (and my mature appreciation of them)
- Daz has been helped tremendously by YouTube folks like [WP Guru](https://www.youtube.com/user/wphosting) and [esha](https://www.youtube.com/channel/UCuk28jyQ5x2MZl0_k2-gXJg)—which helps me tremendously.
- the gulf between Daz and Blender is almost gone—definitely not the case in 2003.

Most importantly, I have matured tremendously when it comes to this kind of production. After being beaten to death by multi-hundred-million-dollar, photorealistic CGI for a decade, I am no longer fascinated by replicating reality. I now see that tweening and animating can inform and produce _stills_ meant for a Manga publication. So stills an animation is not necessarily an either-or thing—it is a both-and thing.

And, by the way, OneNote really, really helps here because it is the best at handing a bunch of screenshots.🤷‍

### sketching out a development schedule (revision 1)

Today the studio development schedule looks like this:

- update SonghaySystem.com with my new `@songhay/player-video-you-tube` and `@songhay/index`
- get 11ty pipelines running with the FunkyKB
- consider converting the Day Path blog to 11ty (with `@songhay/index` as a side-car app) and convert to HTTPs by default
- use the learnings from existing npm packages to build `@songhay/player-audio-???`
- move the kinté space blog to an 11ty pipeline (this has been another emergency _for years_)
- set up automated social-media posting with Azure logic apps (and Azure functions orchestration)
- modernize the kinté hits page into a progressive web app
- use the learnings of previous work to upgrade and re-release the kinté space

@[BryanWilhite](https://twitter.com/bryanwilhite)
