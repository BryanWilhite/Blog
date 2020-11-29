---json
{
  "documentId": 0,
  "title": "studio status report: 2020-11",
  "documentShortName": "2020-11-28-studio-status-report-2020-11",
  "fileName": "index.html",
  "path": "./entry/2020-11-28-studio-status-report-2020-11",
  "date": "2020-11-29T03:32:01.111Z",
  "modificationDate": "2020-11-29T03:32:01.111Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-11-28-studio-status-report-2020-11",
  "tag": "{\r\n  \"extract\": \"month 11 of 2020 was about squeezing very little schedule progress between day-job pressures The ‘schedule progress’ (see “development schedule” below) was miniscule but progress toward being modern and professional about Web design and development is sig…\"\r\n}"
}
---

# studio status report: 2020-11

## month 11 of 2020 was about squeezing very little schedule progress between day-job pressures

The ‘schedule progress’ (see “development schedule” below) was miniscule but progress toward being modern and professional about Web design and development is significant, starting with [my responsive layout work](https://github.com/BryanWilhite/nodejs/tree/master/responsive-layouts).

This work is related to the Still API because it would allow me to generate responsive image data that actually are useful in real layouts. This work left me with the following takeaways:

- `image-set` (and `-webkit-image-set`) is _still_ not supported in Firefox which means `@media` queries are _still_ needed for responsive background images (see the 2017 article, “[Responsive Images in CSS](https://css-tricks.com/responsive-images-css/)” by Chris Coyier)—this will have significant impact on Stills API data formats
- `lit-html` replaces the HTML templates I was using in JQuery; I will keep repeating this to myself until I no longer have to
- I can begin to form a list of design goals for Index layouts

## a list of design goals for Index layouts

The Index layout will recognize ‘modern’ HTML five with this top-level layout:

```html
<body>
  <header>
    <div class="mdc-top-app-bar">
    </div>
  </header>
  <main>
    <section class="main"></section>
    <section class="sidebar"></section>
  </main>
  <footer>
    <section></section>
    <section></section>
  </footer>
</body>
```

where `body`, `section.main` and `footer` are selecting [CSS grid](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Grid_Layout) features.

`div.mdc-top-app-bar` will have a `fixed` position which causes its height to collapse to `0`. One way to avoid this collapse is to select identical `min-height` pixel values for `header` and `mdc-top-app-bar`.

`div.mdc-top-app-bar` will have to support transparency which led me into studying the difference between `hsla()` and `#rrggbbaa`.

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

@[BryanWilhite](https://twitter.com/BryanWilhite)
