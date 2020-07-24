---json
{
  "documentId": 0,
  "title": "studio status report: 2020-07",
  "documentShortName": "2020-07-24-studio-status-report-2020-07",
  "fileName": "index.html",
  "path": "./entry/2020-07-24-studio-status-report-2020-07",
  "date": "2020-07-24T18:16:45.212Z",
  "modificationDate": "2020-07-24T18:16:45.212Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-07-24-studio-status-report-2020-07",
  "tag": "{\n  \"extract\": \"month 7 of 2020 has been about building the lunr experience into the rasx() context The lunr index UX is now a fact of life in the Songhay Studio. The Blog-entry index for the rasx() context is so large that a 1000-entry partition threshold has to added i…\"\n}"
}
---

# studio status report: 2020-07

## month 7 of 2020 has been about building the `lunr` experience into _the rasx() context_

The `lunr` index UX is now a fact of life in the Songhay Studio. The Blog-entry index for _the rasx() context_ is so large that [a 1000-entry partition threshold](https://github.com/BryanWilhite/Songhay.Publications/issues/19) was added in `Songhay.Publications`. My [comment from June](https://github.com/BryanWilhite/Songhay.Publications/issues/16#issuecomment-648441162) should be revised a bit:

- `lunr` indices will be partitioned by entry count
- the Shadow-DOM, document-centric `lunr` experience uses the latest partition only
- the SPA-based experience should load/unload multiple indices, paging through by time and supporting break-out by category/tag

This SPA-based (Angular) experience, the ‘side-car app’ listed below, was pushed down a bit in the development schedule sketch. I expect that adding category/tag support to the entry index—and updating the ‘side-car app’—will not be trivial. A [task](https://github.com/BryanWilhite/Songhay.Publications/issues/22) has been added to start addressing this issue.

## confronting the Stills API

My little development schedule is now prioritizing the Stills API. The `lunr` stuff is big but the still API is _huge_. Without a backend supporting responsive images in a data-driven way, I will continue to refuse to use images for Web design in this Studio. This refusal prevents me from building a portfolio. Not having a portfolio prevents me from courting entire work-for-hire markets.

Success here could be so effective that the need for Flickr or a Google Photos (which I do not use) will be profoundly optional. It could also be so ineffective that it is only a small stepping stone toward yet another larger goal (like how to incorporate third-party CDNs into the Studio). [Cloudflare](https://www.cloudflare.com/cdn/)? [Just Azure](https://azure.microsoft.com/en-us/services/cdn/)?

What is quite clear is that the Stills API has been needed for quite some time. This little block of HTML that is over five-years old tells the tale:

```html
    <div class="col-xs-3">
        <a class="hidden-sm hidden-xs" href="{{ root }}#/index">
            <img alt="the kinté space logo" class="IndexLogo" src="{{ root }}images/klogo160.png" width="160" height="160" />
        </a>
        <a class="visible-sm visible-xs" href="{{ root }}#/index">
            <img alt="the kinté space logo" class="IndexLogo" src="{{ root }}images/klogo160.png" width="64" height="64" />
        </a>
    </div>
```

I assume a Stills API (with `srcset` and `sizes`) would eliminate the redundant `img` declarations above. Eleventy could call the Stills at render time.

## another big step: bringing `webpack` to kintespace.com

One great side effect of bringing `lunr` to the kintespace.com repo was the introduction of `webpack`. Before this introduction, I assumed that _multiple_ `webpack` config files would be needed for every bundling solution needed for kintespace.com. As of now, there are two bundles needed: one for the main site and one for _the rasx() context_. I see now that one `webpack.config.js` file can support _both_ (and more) of these bundles by moving from this:

```javascript
module.exports = { … };
```

to this:

```javascript
module.exports = [
    {...sharedConfig,...indexConfig},
    {...sharedConfig,...rasxlogConfig},
];
```

In other words, `webpack` supports an _array_ of configurations as well as just one configuration [📖[docs](https://webpack.js.org/concepts/targets/#multiple-targets)]. This is great news!

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
