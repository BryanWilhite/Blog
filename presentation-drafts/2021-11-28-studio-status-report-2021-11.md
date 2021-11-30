---json
{
  "documentId": 0,
  "title": "studio status report: 2021-11",
  "documentShortName": "2021-11-28-studio-status-report-2021-11",
  "fileName": "index.html",
  "path": "./entry/2021-11-28-studio-status-report-2021-11",
  "date": "2021-11-28T18:40:01.543Z",
  "modificationDate": "2021-11-28T18:40:01.543Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-11-28-studio-status-report-2021-11",
  "tag": "{\n  \"extract\": \"month 11 of 2021 was about discovering why F# is a core Publication language This is my third month of making mention of my public study of F#. For the last two months I assumed that my study of F# would be a background, far-flung-future thing, helping me…\"\n}"
}
---

# studio status report: 2021-11

## month 11 of 2021 was about discovering why F# is a core Publication language

This is my third month of making mention of [my public study of F#](https://github.com/BryanWilhite/jupyter-central/tree/master/get-programming-with-f-sharp). For the last two months I assumed that my study of F# would be a background, far-flung-future thing, helping me to _think_ about how to get “real” work done (better). Then [I learned about F# discriminated unions](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/21-modeling-relationships-in-f-sharp.ipynb) (DUs) and yet another layer of proverbial of scales fell from my eyes. Trying to explain DUs to the c-like language world (which is effectively “everyone” who “codes”) is like trying to explain why a ‘dialect’ of regular-expression syntax is useful for expressing class hierarchies. What? _Exactly._

This huge revelation leads me in a few directions:

- i have decided to rewrite/upgrade `Songhay.Desktop` in an F# flavor of Blazor called [Bolero](https://fsbolero.io/); a [new GitHub project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) is opened and underway
- i am investigating the F# equivalent of eleventy, [Fornax](https://github.com/ionide/Fornax)

These F#-based moves have the following repercussions:

- generating HTML with Bolero/Blazor will delay or eliminate the use of Web components—like the proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- the kinté hits page will likely be done in Bolero
- the `@songhay/index` work in Angular will likely be translated into Bolero and NuGet-packaged
- plans for `@songhay/player-audio-???` will likely be moved toward Bolero

I had no idea that my study of F# would be so disruptive! I am not sure that my relatively new `songhay-core` [[GitHub](https://github.com/BryanWilhite/songhay-core)] project will _not_ be deleted.

## i have learned that my Python work with `pyo` on Linux is not possible by default

On Ubuntu, we have PulseAudio for general audio needs and JACK for high-performance, professional applications. `pyo` requires JACK but it is not installed by default the version of Ubuntu in use in my studio (20.04). The Linux audio-production world is [eagerly watching](https://www.youtube.com/watch?v=3Z_b8VayU4g) the release of [Pipewire](https://pipewire.org/) as the solution for running PulseAudio and JACK side by side.

I have started [a Python-based study of audio](https://github.com/BryanWilhite/jupyter-central/tree/master/python-audio) that basically starts off with stuff we can do with PulseAudio.

## sketching out a development schedule (revision 19)

The schedule of the month:

- build SonghaySystem.com as a first Bolero project for my Studio 🖼
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
