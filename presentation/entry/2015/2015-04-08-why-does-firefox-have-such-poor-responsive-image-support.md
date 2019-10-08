---json
{
  "documentId": 0,
  "title": "Why does Firefox have such poor responsive image support?",
  "documentShortName": "2015-04-08-why-does-firefox-have-such-poor-responsive-image-support",
  "fileName": "index.html",
  "path": "./entry/2015-04-08-why-does-firefox-have-such-poor-responsive-image-support",
  "date": "2015-04-08T07:00:00.000Z",
  "modificationDate": "2015-04-08T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-04-08-why-does-firefox-have-such-poor-responsive-image-support",
  "tag": "{\r\n  \"extract\": \"Based on my research of a less than an hour, there are three ways to approach responsive image support:What Chris Coyier recommended last year: “If you’re just changing resolutions, use srcset.”Use the picture element (but Chris warns, “…if you go down t...\"\r\n}"
}
---

# Why does Firefox have such poor responsive image support?

Based on my research of a less than an hour, there are three ways to approach responsive image support:

* What Chris Coyier recommended last year: “[If you’re just changing resolutions, use srcset.](https://css-tricks.com/responsive-images-youre-just-changing-resolutions-use-srcset/)”
* Use the `picture` element (but Chris warns, “…if you go down the `&lt;picture&gt;` with explicit sources, the browser **has to do exactly what you say** and not make choices for itself”).
* Use a polyfill (Chris recommends [Picturefill](http://scottjehl.github.io/picturefill/)—with a caveat: “[To Picturefill, or not to Picturefill](http://www.filamentgroup.com/lab/to-picturefill.html)”).

So, yeah, my information is from last year. However, the `srcset` page from [today’s caniuse.com](https://caniuse.com/#feat=srcset) is still telling a bleak story of corporate-sponsored “innovation.” Try out `srcset` with my Code Pen:

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="img srcset with Picturefill" src="https://codepen.io/rasx/embed/Ggbgxw?height=265&theme-id=0&default-tab=html,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
See the Pen <a href='https://codepen.io/rasx/pen/Ggbgxw'>img srcset with Picturefill</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

@[BryanWilhite](https://twitter.com/BryanWilhite)
