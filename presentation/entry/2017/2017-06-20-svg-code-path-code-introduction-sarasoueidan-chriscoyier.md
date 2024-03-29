---json
{
  "documentId": 0,
  "title": "SVG <code>path</code> Introduction [@SaraSoueidan + @chriscoyier]",
  "documentShortName": "2017-06-20-svg-code-path-code-introduction-sarasoueidan-chriscoyier",
  "fileName": "index.html",
  "path": "./entry/2017-06-20-svg-code-path-code-introduction-sarasoueidan-chriscoyier",
  "date": "2017-06-21T00:36:58.819Z",
  "modificationDate": "2017-06-21T00:36:58.819Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-06-20-svg-code-path-code-introduction-sarasoueidan-chriscoyier",
  "tag": "{\r\n  \"extract\": \"One effective way to learn SVG is to start with the <path> element. In “The SVG path Syntax: An Illustrated Guide,” Chris Coyier writes: It can draw anything! I’ve heard that under the hood all the other drawing elements ultimately use path anyway.E...\"\r\n}"
}
---

# SVG <code>path</code> Introduction [@SaraSoueidan + @chriscoyier]

One effective way to learn SVG is to start with the `<path>` element. In “[The SVG `path` Syntax: An Illustrated Guide](https://css-tricks.com/svg-path-syntax-illustrated-guide/),” Chris Coyier writes:

<blockquote>

It can draw anything! I’ve heard that under the hood all the other drawing elements ultimately use path anyway.

</blockquote>

Even though I am a long-time CodePen user, I’ve built samples based on this introduction [in a GitHub repo](https://github.com/BryanWilhite/nodejs/tree/master/svg-path) dedicated to my self-education.

Note that this introduction stays laser-focused on the `<path>` element so all `viewBox` attributes declare `150px` squares (the use of `100px` in the Guide is an error because it crops out what we see in the images).

The external SVG files are loaded with `<img>` elements. In terms of falling back to a bitmap away from SVG, Sara Soueidan talks about [the limitations of using `<img>`](https://www.sarasoueidan.com/blog/svg-picture/). However, her general rule stands for SVG without concern for fallbacks:

<blockquote>

Unless you’re in need of interactivity or external styling, `<img>` is the standard way for loading an SVG image…

</blockquote>

The CSS in this sample is confined to styling the `<img>` container. The ‘styling’ of the SVG is done in the most primitive way: the use of `fill`, `stroke` and `stroke-width` attributes directly on `path`.

## “simple shapes” and `<path>`

Sara Soueidan, her number one tip in “[Tips for Creating and Exporting Better SVGs for the Web](http://www.sarasoueidan.com/blog/svg-tips-for-designers/)” is this:

<blockquote>

Create Simple Shapes Using Simple Shape Elements, Not `<path>`s.

</blockquote>

Even though the `<path>` element does ‘everything,’ this tip reminds us why we have: `<line>`, `<circle>`, `<rect>`, `<ellipse>`, `<polygon>` and `<polyline>`.

## resources

* “[SVG `<path>`](https://www.w3schools.com/graphics/svg_path.asp)”
* “[Better SVG Fallback and Art Direction with The `<picture>` Element](https://www.sarasoueidan.com/blog/svg-picture/)”
* 2015: “[A Complete Guide to SVG Fallbacks](https://css-tricks.com/a-complete-guide-to-svg-fallbacks/)”

<https://github.com/BryanWilhite/>
