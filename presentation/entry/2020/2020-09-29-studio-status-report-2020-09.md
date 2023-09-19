---json
{
  "documentId": 0,
  "title": "studio status report: 2020-09",
  "documentShortName": "2020-09-29-studio-status-report-2020-09",
  "fileName": "index.html",
  "path": "./entry/2020-09-29-studio-status-report-2020-09",
  "date": "2020-09-29T16:34:36.76Z",
  "modificationDate": "2020-09-29T16:34:36.76Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-09-29-studio-status-report-2020-09",
  "tag": "{\n  \"extract\": \"month 9 of 2020 was about exploding into the world of Python It is a misunderstanding to assume that the inclusion of Python in my studio is about learning a new programming language for the sake of some kind of polyglot discipline. In my studio, Python i…\"\n}"
}
---

# studio status report: 2020-09

## month 9 of 2020 was about exploding into the world of Python

It is a misunderstanding to assume that the inclusion of Python in my studio is about learning a new programming language for the sake of some kind of polyglot discipline. In my studio, Python is a publication tool, a data visualization tool, an audio analysis and synthesis tool, a computational animation tool and an image manipulation tool.

I have been using Python as a strong wrapper, curling around [ImageMagick](https://imagemagick.org/) in order to generate images for the `Songhay.Player` Stills API. It appears that almost all of my image editing work of my internet lifetime can be automated with [Wand](https://github.com/emcconville/wand) wrapped around ImageMagick. This is a new way for me to think about scripting. Python the next level beyond PowerShell here in this studio. Based on my current level of ignorance, Python is my [AppleScript](https://en.wikipedia.org/wiki/AppleScript).

When [the issue](https://github.com/BryanWilhite/jupyter-central/issues/3) dedicated to getting up to speed with Wand closes, the `Songhay.Player` Stills API will move closer to operational status.

## Jupyter Central has become, well, _central_

Now that I consider myself a decent Python script writer, it is clear to me that interactive notebooks will be the next level beyond markdown in my studio. Today, I flippantly assume that my [Jupyter Central](https://github.com/BryanWilhite/jupyter-central) repository will be come _huge_ in the coming years.

For example, I found out quite by accident that [pandas](https://pandas.pydata.org/) is pretty much my replacement for a spreadsheet. This implies that my open source “office suite” has nothing to do with the traditional Linux Desktop offerings. Today, my office suite looks like this:

| application name | replaces which office app
|- |-
| Visual Studio Code | Microsoft Word
| Markdown ecosystem | Microsoft Word, Visio, OneNote, Access, FrontPage 😬
| Jupyter notebook ecosystem | Microsoft Word, Microsoft Excel

Although I still use Microsoft Office for personal-mostly-juvenile-adult-consumer stuff, all professional publication will be almost completely open source.

## sketching out a development schedule (revision 11)

The schedule of the month:

- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- consider upgrading to .NET Core 3.0
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

<https://github.com/BryanWilhite/>
