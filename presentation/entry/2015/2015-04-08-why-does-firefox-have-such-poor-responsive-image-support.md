---json
{
  "author": "Bryan Wilhite",
  "content": "Based on my research of a less than an hour, there are three ways to approach responsive image support:What Chris Coyier recommended last year: “If you’re just changing resolutions, use srcset.”Use the picture element (but Chris warns, “…if you go down t...",
  "inceptDate": "2015-04-08T00:00:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "why-does-firefox-have-such-poor-responsive-image-support",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Why does Firefox have such poor responsive image support?"
}
---

Based on my research of a less than an hour, there are three ways to approach responsive image support:

*   What Chris Coyier recommended last year: “[If you’re just changing resolutions, use srcset.](https://css-tricks.com/responsive-images-youre-just-changing-resolutions-use-srcset/)”
*   Use the `picture` element (but Chris warns, “…if you go down the `&lt;picture&gt;` with explicit sources, the browser **has to do exactly what you say** and not make choices for itself”).
*   Use a polyfill (Chris recommends [Picturefill](http://scottjehl.github.io/picturefill/)—with a caveat: “[To Picturefill, or not to Picturefill](http://www.filamentgroup.com/lab/to-picturefill.html)”).

So, yeah, my information is from last year. However, the `srcset` page from [today’s caniuse.com](https://caniuse.com/#feat=srcset) is still telling a bleak story of corporate-sponsored “innovation.” Try out `srcset` with my Code Pen:

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="img srcset with Picturefill" src="https://codepen.io/rasx/embed/Ggbgxw?height=265&theme-id=0&default-tab=html,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
  See the Pen <a href='https://codepen.io/rasx/pen/Ggbgxw'>img srcset with Picturefill</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->
