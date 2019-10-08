---json
{
  "documentId": 0,
  "title": "Embedding Code Pen and GitHub Content in an Angular Template",
  "documentShortName": "2015-07-23-embedding-code-pen-and-github-content-in-an-angular-template",
  "fileName": "index.html",
  "path": "./entry/2015-07-23-embedding-code-pen-and-github-content-in-an-angular-template",
  "date": "2015-07-23T21:13:13.284Z",
  "modificationDate": "2015-07-23T21:13:13.284Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-07-23-embedding-code-pen-and-github-content-in-an-angular-template",
  "tag": "{\r\n  \"extract\": \"My desire to make my notes public and still useful (to me) led me to embedding Code Pen and GitHub “gists” in my entries. This embedding stuff used to be drop-dead simple on every other Blog platform—but now, since I am building my own thing, my technolo...\"\r\n}"
}
---

# Embedding Code Pen and GitHub Content in an Angular Template

My desire to make my notes public and still useful (to me) led me to embedding Code Pen and GitHub “gists” in my entries. This embedding stuff used to be drop-dead simple on every other Blog platform—but now, since I am building my own thing, my technology mix (yet again) has hit a bit of a brick wall. My current Blog platform is based on Angular JS—and by default Angular “sanitizes” the HTML it displays. This means it will not, by default, display embedding.

The solution to this problem is in [my Code Pen](http://codepen.io/rasx/pen/xGaXrN) below:

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="Embedding Code Pen and GitHub Content in an Angular Template" src="https://codepen.io/rasx/embed/xGaXrN?height=265&theme-id=0&default-tab=js,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
See the Pen <a href='https://codepen.io/rasx/pen/xGaXrN'>Embedding Code Pen and GitHub Content in an Angular Template</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

See the Pen [Embedding Code Pen and GitHub Content in an Angular Template](http://codepen.io/rasx/pen/xGaXrN/) by Bryan Wilhite ([@rasx](http://codepen.io/rasx)) on [CodePen](http://codepen.io).

K. Scott Allen covers the Angular theory behind this issue quite well in, “[A Journey With Trusted HTML in AngularJS](http://odetocode.com/blogs/scott/archive/2014/09/10/a-journey-with-trusted-html-in-angularjs.aspx).” I am using `angular-embed-codepen` [by Jurgen Van de Moere](https://github.com/jvandemo/angular-embed-codepen) and `angular-gist` [by Scott Corgan](https://github.com/scottcorgan/angular-gist). Both of these projects are bower packages and I must point out that there are other GitHub projects similar to `angular-gist` but the ones I’ve seen take a dependency on jQuery.

@[BryanWilhite](https://twitter.com/BryanWilhite)
