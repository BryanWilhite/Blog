---json
{
  "documentId": 0,
  "title": "studio status report: 2021-10",
  "documentShortName": "2021-10-30-studio-status-report-2021-10",
  "fileName": "index.html",
  "path": "./entry/2021-10-30-studio-status-report-2021-10",
  "date": "2021-10-30T17:10:00.151Z",
  "modificationDate": "2021-10-30T17:10:00.151Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-10-30-studio-status-report-2021-10",
  "tag": "{\n  \"extract\": \"month 10 of 2021 was about using BenchmarkDotNet at the day job The day job is still kicking my ass. However, the beating was more self-inflicted and about adding a second, desired skill to my ridiculously-long resume. It took almost a decade at UCLA to a…\"\n}"
}
---

# studio status report: 2021-10

## month 10 of 2021 was about using `BenchmarkDotNet` at the day job

The day job is _still_ kicking my ass. However, the beating was more self-inflicted and about adding a second, _desired_ skill to my ridiculously-long resume. It took almost a decade at UCLA to add a handful of new skills. At this latest gig, I have two _desired_ skills in less than one year:

1. [SpecFlow](https://specflow.org/)
2. `BenchmarkDotNet` [[GitHub](https://github.com/dotnet/BenchmarkDotNet)] [📚 [docs](https://benchmarkdotnet.org/articles/guides/getting-started.html)]

For the sake of organization and retention, the need to write an article about `BenchmarkDotNet` on this Blog is right thing to do, making a total of _four_ writing tasks for 2021:

1. Songhay Publications and the Concept of the Index (2021) [in draft since 6/2021]
2. the Songhay Timed-Text Motion Graphics Player
3. flippant remarks about `BenchmarkDotNet`
4. flippant remarks about SpecFlow [maybe]

## my public notes on F# clearly led to an email from Manning

The Isaac Abraham book on F# that is the focus of [my public study](https://github.com/BryanWilhite/jupyter-central/tree/master/get-programming-with-f-sharp) is published by [Manning Publications Co](https://www.manning.com/). It is clear to me that [Dr. Heather Tucker](https://www.linkedin.com/in/heather-tucker-phd-she-her-54658b103/) sent me an email this month because of this activity.

This is quite a pleasant surprise! I have not been addressed in this way since [Chris Sells](https://channel9.msdn.com/Blogs/funkyonex/Happy-Birthday-NET-with-Chris-Sells) wanted reviewers for his turn-of-the-century, WPF books over 15 years ago. Sadly, I had to reject Chris, his invitation, because of (here we go again) day-job rabbit holes, time sinks, proletarian trap doors!

I do not want to treat Dr. Tucker and Manning the same way but it _feels_ like it will go in that direction. My instinct strongly suggests that 20<sup>th</sup>-century style face-to-face interviews/chats (with, say, Zoom) and the perfunctory need for hour-plus readings of strange prose will be the Manning relationship expectation.

I do not have the time for such 20<sup>th</sup>-century stuff. The very reason why I write in public (using 21<sup>st</sup> century technology) is to be contacted for _specific_ things I have written about—not to chat in the context of general inquiry and open-ended exploration for commercial purposes (in effective secrecy). This general and open-ended place requires a presentational self that resembles the performance desired in a job interview. My contempt for the job interview is profound while its rituals have become cultural norms—such that one does not even know they are asking another to submit to a job interview while simply being thoughtful and friendly.

Now there are highly-technical people who have had the privilege of spending _years_ honing and refining their presentational self. When I was young and open to this self-promotional training, I was very interested in becoming one of these people. These are the people who most often possess and maintain commercial <abbr title="Most Valuable Professional">MVP</abbr> honors and, yes, these evangelicals have devoted years to multiple editions of books, used as business cards.

But now, I am “old” (by “industry standards”) and I have watched quite carefully how these evangelicals age. The intimate power of the podcast has allowed me to _respect_ these people and actually _listen_ to what has happened to them instead of being caught up in the fantasy of how I imagined they lived their lives. These people include:

- [Douglas Crockford](https://www.crockford.com/books.html)
- [Steven Skiena](https://www.cs.stonybrook.edu/people/faculty/StevenSkiena)
- [Jeffrey Richter](https://www.wintellect.com/author/jeffreyr/)
- [Joe Duffy](https://channel9.msdn.com/shows/Going+Deep/Joe-Duffy-Perspectives-on-Concurrent-Programming-and-Parallelism/)

I have read many, many more technical books by many, many other authors but most of those books age rapidly and are disposable while the authors above have written works that have endured (especially those of Steven Skiena). Also, what is common among the names above is publicized financial backing by large educational and/or commercial institutions. I am just a self-financing obscure hobo with some keyboards and a GitHub account.

My imagination of how things _should_ be is vastly superior to what has happened. It is _exactly_ like dreaming of being a respected musician only to find that you are wanted for your ability to sell drinks in bars and little else.

## month 10 studio notes digest

Here is a quick walk through my studio notes (currently done in [Joplin](https://joplinapp.org/)) for the current month:

### Audio and Video Production 🎵🎥

I am playing around with [DaVinci Resolve](https://www.blackmagicdesign.com/products/davinciresolve/whatsnew). It looks like a way to include Linux in production pipelines (but my little Linux box does not have an [OpenCL](https://en.wikipedia.org/wiki/OpenCL)-capable GPU).

### hardware status 🖥

My little Linux box is now supported by an APC UPS. It also has a new USB BlueTooth adapter, primarily to send audio signals to the FarmTuff wagon PC.

### JetBrains status 🚜🔨🚀

Rider cannot save Markdown settings. This means that Markdown support in Rider is limited. There is an [issue](https://youtrack.jetbrains.com/issue/RIDER-67953?clearDraft=true&description=Version:%20RD-212.4746.113Timezone:%20America%2FLos_AngelesEvaluation:%20falseEnvironment:%20RD-212.4746.113,%20JRE%2011.0.11%209-b1504.13x64%20JetBrains%20s.r.o.,%20OS%20Linux(amd64)%20v5.11.0-34-generic,%20screens%202400.0x1350.0.NET%205.0.7&c=Affected%20versions%202021.2%20(212.4746.113)) out there, recognizing the problem.

### Python status 🐍

This month was the month I discovered that my installation of Python 3.9 cannot be a replacement for 3.8 because 3.9 cannot be used to run the preferred/default Ubuntu Terminal program. I then learned that Anaconda’s `jupyterlab` had to reinstalled to stop it from pointing at Python 3.9 which I removed. It was a mess. It could still be a mess.

### VS Code Status 🚜🔨🚀

Microsoft’s Azure Storage extension uploaded 0-length files! A copy-and-paste operation produced unintended results with the [Azure Storage extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurestorage). There is a reason why that, as of this writing, this product is still in preview.

## sketching out a development schedule (revision 18)

The schedule of the month:

- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- build Web components required for new version of SonghaySystem.com 🖼
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- modernize the kinté hits page into a progressive web app 💄✨
- use the learnings of previous work to upgrade and re-release the kinté space 🚀
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

<https://github.com/BryanWilhite/>
