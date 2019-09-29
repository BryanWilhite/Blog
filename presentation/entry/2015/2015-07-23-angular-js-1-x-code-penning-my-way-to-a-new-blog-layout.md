---json
{
  "author": "Bryan Wilhite",
  "content": "There are three CodePen presentations I have written that take me step-by-step to a new layout for this Blog. First, I start with the basic layout (something just beyond Photoshop):See the Pen Songhay Studio: Day Path Index Layout by Bryan Wilhite (@rasx...",
  "inceptDate": "2015-07-23T13:26:13.9170446-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "angular-js-1-x-code-penning-my-way-to-a-new-blog-layout",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Angular JS 1.x: code-penning my way to a new Blog layout"
}
---

There are three CodePen presentations I have written that take me step-by-step to a new layout for this Blog. First, I start with [the basic layout](http://codepen.io/rasx/pen/raVaxL) (something just beyond Photoshop):

See the Pen [Songhay Studio: Day Path Index Layout](http://codepen.io/rasx/pen/raVaxL/) by Bryan Wilhite ([@rasx](http://codepen.io/rasx)) on [CodePen](http://codepen.io).

Then, I [‘pen’ the live JSON payload](http://codepen.io/rasx/pen/XJYJye) that will drive the Blog index:

See the Pen [Songhay Studio: Day Path Index JSON](http://codepen.io/rasx/pen/XJYJye/) by Bryan Wilhite ([@rasx](http://codepen.io/rasx)) on [CodePen](http://codepen.io).

This second CodePen effectively shows what I decided upon after writing “[Songhay Studio: Web Index Design Study](http://songhayblog.azurewebsites.net/Entry/Show/songhay-studio-web-index-design-study)”: I’ve decided to use the [Accordion from Angular UI](https://angular-ui.github.io/bootstrap/) to visually group index data (one might call this a UX capitulation for a cliché instead of trying something new).

Finally, I take the learnings from the first and second CodePen presentations to make [the third and final CodePen presentation](http://codepen.io/rasx/pen/rVMJVW):

See the Pen [Songhay Studio: Day Path Index Layout with Grouping](http://codepen.io/rasx/pen/rVMJVW/) by Bryan Wilhite ([@rasx](http://codepen.io/rasx)) on [CodePen](http://codepen.io).

So what I am seeing here is an ‘armadillo’ index grouping (each collapsed Accordion reminds me of the scales of an armadillo or a pill bug). This grouping summary defines the first feature of the Index HTML5 App to be standardized across all Songhay System web sites indexing content. Literally, for my health, I will make the concept count that gets me to this new moment in Internet time:

First, I had to work with NBlog (to actually see MVC in real life) and see the need to generate an index offline instead of generating one on the fly (especially from static JSON data). Second, I had to choose an HTML5 App platform which left me stuck with Angular 1.x (with no plans/desire to move to Angular 2.x, respecting [the public observations of Rob Eisenberg](http://eisenbergeffect.bluespire.com/leaving-angular/)). Third was my move away from [960.gs](http://960.gs/) to Bootstrap (it took me quite some time to realize that Bootstrap is not just a grid system but a *responsive* [grid system](http://getbootstrap.com/css/)). Fourth, I had to choose CodePen.io over jsFiddle. Sixth is surely a bunch of personal-life issues not worth mentioning here…
