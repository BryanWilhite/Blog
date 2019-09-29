---json
{
  "author": "Bryan Wilhite",
  "content": "I’ve invested the time. I’m walking away with a Code Pen that represents my strategy for handling layout for the single-page Web apps I’ll be building for at least the next three years (or when I move the Songhay System out of the ECMAScript-5 timeframe)...",
  "inceptDate": "2015-07-20T21:23:38.4855569-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "my-angular-js-1-x-single-page-layout",
  "sortOrdinal": 0,
  "tag": null,
  "title": "My Angular JS 1.x single-page layout"
}
---

I’ve invested the time. I’m walking away with [a Code Pen](http://codepen.io/rasx/pen/gpjaoZ) that represents my strategy for handling layout for the single-page Web apps I’ll be building for at least the next three years (or when I move the Songhay System out of the ECMAScript-5 timeframe).

As usual, my layout is simple:


&lt;body data-ng-app="rxApp"&gt;
    &lt;div data-ng-controller="clientController"&gt;
        &lt;rx-header&gt;&lt;/rx-header&gt;
        &lt;div data-ng-view=""&gt;&lt;/div&gt;
        &lt;rx-footer&gt;&lt;/rx-footer&gt;
    &lt;/div&gt;
&lt;/body&gt;
    

So it’s quite clear that `rx-header` and `rx-footer` are the Angular directives I’ll be building and certainly reusing. The big breakthrough with this simplicity is my use of a container-level controller, `clientController`, that observes (and automatically becomes the `$parent` of) any controllers loaded under `ng-view`.

I’ve run some experiments with this strategy and saved them:

See the Pen [Angular: Multiple Templates w/ ngRoute, ngAnimate and a Directive](http://codepen.io/rasx/pen/gpjaoZ/) by Bryan Wilhite ([@rasx](http://codepen.io/rasx)) on [CodePen](http://codepen.io).

### Related Links

<table class="WordWalkingStickTable"><tr><td>

“[AngularJS: Communication Between Controllers](http://www.theroks.com/angularjs-communication-controllers/)”
</td><td>

Event-aggregation with `$broadcast` in an Angular Service.
</td></tr><tr><td>

“[Animating AngularJS Apps: ngView](https://scotch.io/tutorials/animating-angularjs-apps-ngview)”
</td><td>

I could not get the animations to work *well*. Not the UX I’m looking for…
</td></tr><tr><td>

“[UI-Router: Why many developers don’t use AngularJS’s built-in router](http://www.funnyant.com/angularjs-ui-router/)”
</td><td>

My solution is simpler, Angular-native and I do not expect to outgrow it.
</td></tr><tr><td>

“[AngularJS: Views vs. Directives](http://jan.varwig.org/archive/angularjs-views-vs-directives)”
</td><td>

Is not `ng-view` a Directive?
</td></tr><tr><td>

“[Mastering the Scope of the Directives in AngularJS](http://www.undefinednull.com/2014/02/11/mastering-the-scope-of-a-directive-in-angularjs/)”
</td><td>

The few written works on Angular JS that help me understand the deep innards of this beast.
</td></tr><tr><td>

“[Angular.js directives—Difference between controller and link](http://jasonmore.net/angular-js-directives-difference-controller-link/)”
</td><td>

Another one of those *aha!* articles.
</td></tr></table>
