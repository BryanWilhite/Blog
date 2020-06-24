---json
{
  "documentId": 0,
  "title": "studio status report: 2020-06",
  "documentShortName": "2020-06-23-studio-status-report-2020-06",
  "fileName": "index.html",
  "path": "./entry/2020-06-23-studio-status-report-2020-06",
  "date": "2020-06-23T23:15:58.41Z",
  "modificationDate": "2020-06-23T23:15:58.41Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-06-23-studio-status-report-2020-06",
  "tag": "{\r\n  \"extract\": \"month 6 of 2020 was about recuperation and promotion “A Return to Progressive Enhancement with LitHtml and 11ty (@eleven_ty)” marks my debut into the latest fashion trend of technical blogging from at least three years ago. My Medium.com post speaks for i…\"\r\n}"
}
---

# studio status report: 2020-06

## month 6 of 2020 was about recuperation and promotion

“[A Return to Progressive Enhancement with LitHtml and `11ty` (@eleven_ty)](https://medium.com/@bryan.wilhite/a-return-to-progressive-enhancement-with-lithtml-and-11ty-eleven-ty-e3e7e73fec9d)” marks my debut into the latest fashion trend of technical blogging from at least three years ago. My Medium.com post speaks for itself so let’s conserve space here.

The recuperation part was about moving more of my OneNote content to Joplin and seeing the next little bit of routine development upwards from `SonghayCore`:

- [ ] release next `SonghayCore` [project](https://github.com/BryanWilhite/SonghayCore/projects/17) 📦🚀
- [ ] upgrade packages dependent on `SonghayCore` 📦⬆
- [ ] release next `Songhay.Publications` [project](https://github.com/BryanWilhite/Songhay.Publications/projects/3) 📦🚀

This work is looking forward to upgrading to .NET 3.x.

## mermaid and basic image support for blogging

The rise of Joplin in the Studio has pushed me toward a basic image pipeline for my Visual-Studio-Code-based blogging. The [Paste Image extension](https://marketplace.visualstudio.com/items?itemName=mushan.vscode-paste-image) is key to this new routine:

1) compose the [Mermaid diagram](https://mermaid-js.github.io/mermaid/#/flowchart) in Joplin
2) screen-capture it with the OS
3) paste it into the active Markdown document is Visual Studio Code

These are the Paste Image settings (at the folder level) for this Blog:

```json
    "pasteImage.insertPattern": "${imageSyntaxPrefix}../presentation/image/${imageFileName}${imageSyntaxSuffix}",
    "pasteImage.namePrefix": "day-path-",
    "pasteImage.path": "${projectRoot}/presentation/image/"
```

## Studio packages dependent on `SonghayCore`

![Studio packages dependent on `SonghayCore`](../../image/day-path-2020-06-23-18-22-10.png)

- `SonghayCore.MSTest` will retire upon the move to .NET Core 3.x
- `Songhay.DataAccess` is in serious need of a revival

## sketching out a development schedule (revision 9)

The schedule of the month:

- ~~build lunr index experience~~ 🏗
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- consider upgrading to .NET 3.0
- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- add [proposed content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
