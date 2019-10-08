---json
{
  "documentId": 0,
  "title": "Angular JS 1.x: code-penning my way to a new Blog layout",
  "documentShortName": "2015-07-23-angular-js-1-x-code-penning-my-way-to-a-new-blog-layout",
  "fileName": "index.html",
  "path": "./entry/2015-07-23-angular-js-1-x-code-penning-my-way-to-a-new-blog-layout",
  "date": "2015-07-23T20:26:13.917Z",
  "modificationDate": "2015-07-23T20:26:13.917Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-07-23-angular-js-1-x-code-penning-my-way-to-a-new-blog-layout",
  "tag": "{\r\n  \"extract\": \"There are three CodePen presentations I have written that take me step-by-step to a new layout for this Blog. First, I start with the basic layout (something just beyond Photoshop):See the Pen Songhay Studio: Day Path Index Layout by Bryan Wilhite (@rasx...\"\r\n}"
}
---

# Angular JS 1.x: code-penning my way to a new Blog layout

There are three CodePen presentations I have written that take me step-by-step to a new layout for this Blog. First, I start with [the basic layout](http://codepen.io/rasx/pen/raVaxL) (something just beyond Photoshop):

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="Songhay Studio: Day Path Index Layout" src="https://codepen.io/rasx/embed/raVaxL?height=265&theme-id=0&default-tab=html,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
See the Pen <a href='https://codepen.io/rasx/pen/raVaxL'>Songhay Studio: Day Path Index Layout</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

Then, I [‘pen’ the live JSON payload](http://codepen.io/rasx/pen/XJYJye) that will drive the Blog index:

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="Songhay Studio: Day Path Index JSON" src="https://codepen.io/rasx/embed/XJYJye?height=265&theme-id=0&default-tab=js,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
See the Pen <a href='https://codepen.io/rasx/pen/XJYJye'>Songhay Studio: Day Path Index JSON</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

This second CodePen effectively shows what I decided upon after writing “[Songhay Studio: Web Index Design Study](http://songhayblog.azurewebsites.net/Entry/Show/songhay-studio-web-index-design-study)”: I’ve decided to use the [Accordion from Angular UI](https://angular-ui.github.io/bootstrap/) to visually group index data (one might call this a UX capitulation for a cliché instead of trying something new).

Finally, I take the learnings from the first and second CodePen presentations to make [the third and final CodePen presentation](http://codepen.io/rasx/pen/rVMJVW):

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="Songhay Studio: Day Path Index Layout with Grouping" src="https://codepen.io/rasx/embed/rVMJVW?height=265&theme-id=0&default-tab=css,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
See the Pen <a href='https://codepen.io/rasx/pen/rVMJVW'>Songhay Studio: Day Path Index Layout with Grouping</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

So what I am seeing here is an ‘armadillo’ index grouping (each collapsed Accordion reminds me of the scales of an armadillo or a pill bug). This grouping summary defines the first feature of the Index HTML5 App to be standardized across all Songhay System web sites indexing content. Literally, for my health, I will make the concept count that gets me to this new moment in Internet time:

First, I had to work with NBlog (to actually see MVC in real life) and see the need to generate an index offline instead of generating one on the fly (especially from static JSON data). Second, I had to choose an HTML5 App platform which left me stuck with Angular 1.x (with no plans/desire to move to Angular 2.x, respecting [the public observations of Rob Eisenberg](http://eisenbergeffect.bluespire.com/leaving-angular/)). Third was my move away from [960.gs](http://960.gs/) to Bootstrap (it took me quite some time to realize that Bootstrap is not just a grid system but a *responsive* [grid system](http://getbootstrap.com/css/)). Fourth, I had to choose CodePen.io over jsFiddle. Sixth is surely a bunch of personal-life issues not worth mentioning here…

@[BryanWilhite](https://twitter.com/BryanWilhite)
