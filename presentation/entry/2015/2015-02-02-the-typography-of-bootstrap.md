---json
{
  "documentId": 0,
  "title": "The typography of bootstrap…",
  "documentShortName": "2015-02-02-the-typography-of-bootstrap",
  "fileName": "index.html",
  "path": "./entry/2015-02-02-the-typography-of-bootstrap",
  "date": "2015-02-02T08:00:00Z",
  "modificationDate": "2015-02-02T08:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-02-02-the-typography-of-bootstrap",
  "tag": "{\r\n  \"extract\": \"The bootstrap folks depend on Normalize CSS to, ahem, normalize font sizes. According to Harry Roberts of csswizardry.com, Normalize CSS is stating correctly, font-size:100%;, making the default font size 16px. According to Brian Cray of pxtoem.com, 16px...\"\r\n}"
}
---

# The typography of bootstrap…

The bootstrap folks depend on [Normalize CSS](http://necolas.github.io/normalize.css/) to, ahem, *normalize* font sizes. [According to Harry Roberts of csswizardry.com](http://csswizardry.com/2011/05/font-sizing-with-rem-could-be-avoided/), Normalize CSS is stating correctly, `font-size:100%;`, making the default font size 16px. According to Brian Cray of [pxtoem.com](http://pxtoem.com/), 16px ≈ 12pt—which is very traditional for a default font size. Harry has plenty to say about my pre-bootstrap use of `font-size:62.5%;`:

<blockquote>

The main reason people reset the font-size to 10px is point one; to make maths easier. If your quasi-base is 10px and you want an actual base of 12px it’s simply 1.2em. The maths is easier, we can work with units of ten more easily, but that comes at the cost of maintainability.

The main reason, I feel, behind using the 62.5% method is laziness, and that’s a good thing. Good developers are lazy. However that laziness is misguided; it’s actually causing you more work. You have to define font-sizes on all elements rather than just once and letting them inherit and you have to tackle those horrible inheritance issues when an explicitly sized element is placed inside another one.

</blockquote>

Brian Cray insists that `(points per inch / pixels per inch) = (72pt / 96px)` which sounds right to me for Microsoft Windows (and maybe Linux); he also suggests to me that `(96px / 16px) = 6em`. So, when Cray writes `16px * (72pt / 96px) = 12pt`, I can also assert that `72pt / 6em = 12pt / 1em`.

So, for `font-size:100%;`, we have a relationship between em values (`Xem`) and points values(`Ypt`): `Xem = (1em / 12pt) * Ypt`. The following table summarizes:
<table class="WordWalkingStickTable"><tr><td>
**Points**
</td><td>
**Ems**
</td></tr><tr><td>
6pt
</td><td>
.5em
</td></tr><tr><td>
7pt
</td><td>
.563em
</td></tr><tr><td>
8pt
</td><td>
.625em
</td></tr><tr><td>
9pt
</td><td>
.75em
</td></tr><tr><td>
10pt
</td><td>
.813em
</td></tr><tr><td>
11pt
</td><td>
.875em
</td></tr><tr><td>
12pt
</td><td>
1em
</td></tr><tr><td>
14pt
</td><td>
1.125em
</td></tr><tr><td>
16pt
</td><td>
1.313em
</td></tr><tr><td>
18pt
</td><td>
1.5em
</td></tr><tr><td>
20pt
</td><td>
1.667em
</td></tr><tr><td>
22pt
</td><td>
1.83em
</td></tr><tr><td>
24pt
</td><td>
2em
</td></tr><tr><td>
26pt
</td><td>
2.167em
</td></tr><tr><td>
28pt
</td><td>
2.333em
</td></tr><tr><td>
36pt
</td><td>
3em
</td></tr><tr><td>
48pt
</td><td>
4em
</td></tr><tr><td>
72pt
</td><td>
6em
</td></tr><tr><td>
96pt
</td><td>
8em
</td></tr></table>

## Bootstrap encourages the use of font classes for sizing

The table above looks great and it suggests a clean, crisp relationship between ems and points. But I have found that fuzzy type and weird line-height problems (that can cause unwanted drop shadows in boxes with border radius) when I explicitly set small font sizes (below 1em). Moreover, setting these values can get in the way of the responsive intentions baked into the Bootstrap framework. The assumption here is that [Bootstrap would rather have us use classes](http://getbootstrap.com/css/) like `.small` or `.h4` to specify font size:

<blockquote>

For de-emphasizing inline or blocks of text, use the `<small>` tag to set text at 85% the size of the parent. Heading elements receive their own `font-size` for nested `<small>` elements.

You may alternatively use an inline element with .small in place of any `<small>`.

</blockquote>

@[BryanWilhite](https://twitter.com/BryanWilhite)
