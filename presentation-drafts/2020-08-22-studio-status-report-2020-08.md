---json
{
  "documentId": 0,
  "title": "studio status report: 2020-08",
  "documentShortName": "2020-08-22-studio-status-report-2020-08",
  "fileName": "index.html",
  "path": "./entry/2020-08-22-studio-status-report-2020-08",
  "date": "2020-08-23T00:46:35.822Z",
  "modificationDate": "2020-08-23T00:46:35.822Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-08-22-studio-status-report-2020-08",
  "tag": "{\n  \"extract\": \"month 8 of 2020 has been about defining types for the b-roll player stills API, slowly At the beginning of month 8, I published “Flippant Remarks about Responsive Images” where I ask myself, What about all of those DTOs? The Songhay.Player.Models work tha…\"\n}"
}
---

# studio status report: 2020-08

## month 8 of 2020 has been about defining types for the b-roll player stills API, _slowly_

At the beginning of month 8, I published “[Flippant Remarks about Responsive Images](http://songhayblog.azurewebsites.net/entry/2020-08-04-flippant-remarks-about-responsive-images/)” where I ask myself, What about all of those DTOs? The `Songhay.Player.Models` work that followed yields these:

![`Songhay.Player.Models` DTOs](../presentation/image/day-path-2020-08-22-18-21-58.png)

The `ResponsiveImage` DTOs as JSON would look like this:

```json
[
  {
    "Description": "responsive image",
    "Key": "my-responsive-image",
    "Source": "my-responsive-image.png",
    "Candidates": [
      {
        "ImageUri": "my-responsive-image-big",
        "Width": "1920w"
      },
      {
        "ImageUri": "my-responsive-image-medium",
        "Width": "1280w"
      },
      {
        "ImageUri": "my-responsive-image-small",
        "Width": "640w"
      }
    ],
    "Sizes": [
      {
        "MediaCondition": "min-width: 600px",
        "LayoutWidth": "160px"
      },
      {
        "LayoutWidth": "320px"
      }
    ]
  },
  {
    "Description": "another responsive image",
    "Key": "my-other-responsive-image",
    "Source": "my-other-responsive-image.png",
    "Candidates": [
      {
        "ImageUri": "my-other-responsive-image-big",
        "Width": "1920w"
      },
      {
        "ImageUri": "my-other-responsive-image-medium",
        "Width": "1280w"
      },
      {
        "ImageUri": "my-other-responsive-image-small",
        "Width": "640w"
      }
    ],
    "Sizes": [
      {
        "MediaCondition": "min-width: 600px",
        "LayoutWidth": "160px"
      },
      {
        "LayoutWidth": "320px"
      }
    ]
  }
]
```

What is next for the stills API is a solution for the [Open Graph](https://ogp.me/) Image (`og:image`). This API should not require custom types. I am currently seeing a dictionary (`Dictionary<string,string>`), governed by a simple rule:

![Open Graph API flow](../presentation/image/day-path-2020-08-22-19-48-08.png)

## sketching out a development schedule (revision 10)

The schedule of the month:

- add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
- consider upgrading to .NET 3.0
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
