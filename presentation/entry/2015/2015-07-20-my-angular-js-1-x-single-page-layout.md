---json
{
  "documentId": 0,
  "title": "My Angular JS 1.x single-page layout",
  "documentShortName": "2015-07-20-my-angular-js-1-x-single-page-layout",
  "fileName": "index.html",
  "path": "./entry/2015-07-20-my-angular-js-1-x-single-page-layout",
  "date": "2015-07-21T04:23:38.485Z",
  "modificationDate": "2015-07-21T04:23:38.485Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-07-20-my-angular-js-1-x-single-page-layout",
  "tag": "{\r\n  \"extract\": \"I’ve invested the time. I’m walking away with a Code Pen that represents my strategy for handling layout for the single-page Web apps I’ll be building for at least the next three years (or when I move the Songhay System out of the ECMAScript-5 timeframe)...\"\r\n}"
}
---

# My Angular JS 1.x single-page layout

I’ve invested the time. I’m walking away with [a Code Pen](http://codepen.io/rasx/pen/gpjaoZ) that represents my strategy for handling layout for the single-page Web apps I’ll be building for at least the next three years (or when I move the Songhay System out of the ECMAScript-5 timeframe).

As usual, my layout is simple:

```html
<body data-ng-app="rxApp">
    <div data-ng-controller="clientController">
        <rx-header></rx-header>
        <div data-ng-view=""></div>
        <rx-footer></rx-footer>
    </div>
</body>
```

So it’s quite clear that `rx-header` and `rx-footer` are the Angular directives I’ll be building and certainly reusing. The big breakthrough with this simplicity is my use of a container-level controller, `clientController`, that observes (and automatically becomes the `$parent` of) any controllers loaded under `ng-view`.

I’ve run some experiments with this strategy and saved them:

<!-- cSpell:disable -->
<iframe height="265" style="width: 100%;" scrolling="no" title="Angular: Multiple Templates w/ ngRoute, ngAnimate and a Directive" src="https://codepen.io/rasx/embed/gpjaoZ?height=265&theme-id=0&default-tab=js,result" frameborder="no" allowtransparency="true" allowfullscreen="true">
See the Pen <a href='https://codepen.io/rasx/pen/gpjaoZ'>Angular: Multiple Templates w/ ngRoute, ngAnimate and a Directive</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.
</iframe>
<!-- cSpell:enable -->

## Related Links

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

@[BryanWilhite](https://twitter.com/BryanWilhite)
