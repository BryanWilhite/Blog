---json
{
  "author": "Bryan Wilhite",
  "content": "The layout. My latest design of kintespace.com will still be green (I would like to transition into more earth tones later—assuming there will be a “later.”) I assumed that this design would have to abandon the BiggestBox concept that I promoted years ag...",
  "inceptDate": "2015-07-23T14:10:01.5877854-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "songhay-studio-kintespace-com-design-notes",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Songhay Studio: kintespace.com design notes"
}
---

**The layout.** My latest design of kintespace.com will still be green (I would like to transition into more earth tones later—assuming there will be a “later.”) I assumed that this design would have to abandon [the BiggestBox concept](http://kintespace.com/rasxlog/?p=2474) that I promoted years ago. But it is now obvious to me that Bootstrap has a `max-width` ‘concept’ of 1170 px (for `.container`—which why we would need `.container-fluid` to avoid this limitation). By specifying a height in pixels for my `.container`, I get the box effect in the world of Bootstrap:


<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="kintespace.com index layout" src="https://codepen.io/rasx/embed/dPoPbV?height=265&theme-id=0&default-tab=js,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
  See the Pen <a href='https://codepen.io/rasx/pen/dPoPbV'>kintespace.com index layout</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

**The background “splash” image.** I am using flickr.com to get [a wide image](https://www.flickr.com/search/?advanced=1&orientation=landscape,panorama&license=2,3,4,5,6,9&dimension_search_mode=min&height=1024&width=1024&media=photos&text=plants%20africa). I have decided upon “[Forest near Village of Ngon](https://www.flickr.com/photos/cifor/8002340637/in/photolist-dc965i-e3Vpno-qXHqki-h7FhTx-qNtSyH-bURFJF-bxwbwX-oc1SoG-4ExBny-qxEKTJ-a9nPsX-6vhAEg-4VcFAD-bxwrsa-5Gb2vR-qA9zCm-9FEMnS-8cxZDR-35p4Sd-kkDFzW-dJ5gaD-cPS16J-baG1qe-97cMCZ-nHuJ3P-cVw1Am-r51Q4T-dbwXNY-pF9mGv-8GNgG1-nHQoYg-qMwx7L-7UHybd-hfRH9i-9jbtyV-ixhzcR-nXQoRd-qjKoQH-tAKh8u-uvrGf7-5VJe4U-rby4ki-r6VxJm-iikcGV-s3r2u-cPRWe9-pDc3ZD-4GUgGb-9EdNns-r5xvdp)” from [CIFOR](http://www.cifor.org/). I experimented with [a tall image](https://www.flickr.com/search/?advanced=1&orientation=portrait&license=2,3,4,5,6,9&dimension_search_mode=min&height=640&width=640&media=photos&text=plants%20africa) for mobile devices—but I could not find a suitable portrait equivalent of the Ngon landscape (the colors particularly). The image I have selected (which is a kintespace.com policy) is of the Creative Commons. This moves me to find some cool widget that can display the attribution. I could go directly [to creativecommons.org](https://creativecommons.org/choose/) but the context there is for “content creators”—not respectful third parties (also it could be confusing to show a Creative Commons logo on the splash page because it might allow one to assume that all of kintespace.com is Creative Commons).

**Responsively dropping out of the box layout.** What is quite a pleasant move at the moment is what happens in the browser because this chunk of SCSS:

```css
@media all and (min-width: 768px) /* Small devices Tablets (≥768px) */
{
    #IndexBox
    {
        background-image: url('#{$backgroundUri}');
    }
}
@media all and (max-width: 768px) /* Small devices Tablets (&lt;768px) */
{
    body
    {
        background-image: url('#{$backgroundUriSmall}');
    }
}
```

The intent here is to make the background image fill a box by default and fill the entire screen on “small devices.”
