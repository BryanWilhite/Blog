---json
{
  "documentId": 0,
  "title": "flippant remarks about CSS animations",
  "documentShortName": "2022-04-15-flippant-remarks-about-css-animations",
  "fileName": "index.html",
  "path": "./entry/2022-04-15-flippant-remarks-about-css-animations",
  "date": "2022-04-16T04:57:45.543Z",
  "modificationDate": "2022-04-16T04:57:45.543Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-04-15-flippant-remarks-about-css-animations",
  "tag": "{\n  \"extract\": \"These flippant remarks are biased toward my experience with Angular animations which kept me away from working with CSS animations directly. My 21st century return to CSS animations is laced with disappointment. What should be found here in this document…\"\n}"
}
---

# flippant remarks about CSS animations

These flippant remarks are biased toward my experience with [Angular animations](https://angular.io/guide/animations) which kept me away from working with CSS animations directly. My 21<sup>st</sup> century return to CSS animations is laced with disappointment. What should be found here in this document is confirmation that CSS animations are _not_ here to replace JavaScript-based animation.

## fading is fundamental

At the turn of the century, [Brendan Dawes](https://brendandawes.com/about/) wrote a book called _Drag Slide Fade_ and the title of this book indicates just how fundamental _fading_ a visual element is.

## fading is complicated in Web design

In the world of Web design, fading depends on whether you want `display: none;` or `visibility: hidden;` because `display` is not among the “[Animatable CSS properties](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_animated_properties).”

When you are not sure about the differences between `display` and `visibility`, then review the 2021 classic, “[Hiding Content Responsibly](https://css-tricks.com/hiding-content-responsibly/)” by Chris Coyier.

## do not involve `display` in your CSS animations

The following `@keyframes` at-rule would probably be a trick question for a job interview:

```css
@keyframes fadeout {
  from {
    display: block;
    opacity: 1;
  }
  to {
    display: none;
    opacity: 0;
  }
```

The trick question might be something like, “Would the block under the control of `fadeout` collapse?” The answer should be _no_ because `display` will be completely ignored. I wrote myself [a little CodePen example](https://codepen.io/rasx/pen/ExoeGvJ) in case things change as the browsers/standards change.

One very subtle point I am likely to forget: setting `display` outside of an animation will not be overridden by an animation (because `display` will be completely ignored). Ignorance of this is likely a leading reason why newbies to CSS animations (like me) will erroneously assume they are setting up animations incorrectly when the non-animatable CSS is set up incorrectly.

## approximate `display: none` by animating `width` and `height`

When fading in your design implies that the faded element must _not_ take up space (making empty whitespace) then consider animating `width` and `height`. I wrote myself [a little CodePen example](https://codepen.io/rasx/pen/ExoeGvJ) to explore this.

What is often desired is a fade without any resizing animation. I think what is needed here is a `setTimeout` hack involving a race condition between a CSS animation and a bit of JavaScript setting `display` _after_ the CSS animation completes. I made [a fork of the previously mentioned CodePen](https://codepen.io/rasx/pen/yLpRYRb) to demonstrate this kind of race.

Instead of resorting to race conditions, there have been folks out there that seem sure something like this works:

```css
@keyframes fadeout {
  0% {
    opacity: 1;
  }
  99% {
    opacity: 0;
  }
  100% {
    opacity: 0;
    display: none;
  }
}
```

I have tested this on Firefox and Chrome and am _not_ seeing the desired effect.

Yet another possibility (in theory) is to poll `animation-play-state` [📖 [docs](https://developer.mozilla.org/en-US/docs/Web/CSS/animation-play-state)] until the state is `paused`. That [CodePen example](https://codepen.io/rasx/pen/ExoeGvJ) mentioned above dabbles into this with no promise at the moment.

### `visibility: collapsed` only works the way I expect for items in a flex grid

The people at [Mozilla have news](https://developer.mozilla.org/en-US/docs/Web/CSS/visibility) that is _shocking_ to me:

>Support for `visibility: collapse` is missing or partially incorrect in some modern browsers. It may not be correctly treated like `visibility: hidden` on elements other than table rows and columns.

`visibility: collapse` does not work the same for all elements which is, again, shocking and explains why advanced Web designers cannot get rid of JavaScript to help with _basic_, drag-slide-fade animations.

With respect to my current level of ignorance, this is the recommended way to animate the collapse of a block:

```css
@keyframes fadeout {
  0% {
    opacity: 1;
  }
  99% {
    opacity: 0;
    width: 480px;
    height: 320px;
  }
  100% {
    width: 0;
    height: 0;
  }
}
```

[Yet another fork of the previously mentioned CodePen](https://codepen.io/rasx/pen/yLpRvMr) has more details.

## two-frame `@keyframes` at-rule might be replaced by `transition`

This might be more a matter of style after we review the details. See:

- “[CSS Animations vs CSS Transitions: Difference and Similarities](https://imjignesh.com/css-transition-vs-animations/)”
- “[Transitions vs Animations](https://cssanimation.rocks/transition-vs-animation/)”

## the animation system I saw in Angular looks like a few granules of sugar sprinkled on top of the standard Web Animations API for JavaScript

At first glance, the [Web Animations API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Animations_API/Using_the_Web_Animations_API) is just a way to load CSS animations in JavaScript:

>This API was designed to underlie implementations of both [CSS Animations](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Animations) and [CSS Transitions](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_Transitions), and leaves the door open to future animation effects. It is one of the most performant ways to animate on the Web, letting the browser make its own internal optimizations without hacks, coercion, or `Window.requestAnimationFrame()` [📖 [docs](https://developer.mozilla.org/en-US/docs/Web/API/window/requestAnimationFrame)].

The same contents of a CSS `@keyframes` at-rule can be passed as an array to the `animate` method [📖 [docs](https://developer.mozilla.org/en-US/docs/Web/API/Element/animate)] of a DOM element:

```javascript
document.getElementById("alice").animate(
  [
    { transform: 'rotate(0) translate3D(-50%, -50%, 0)', color: '#000' },
    { color: '#431236', offset: 0.3 },
    { transform: 'rotate(360deg) translate3D(-50%, -50%, 0)', color: '#000' }
  ], {
    duration: 3000,
    iterations: Infinity
  }
);
```

It might be useful to compare this standard API with [Angular animations](https://angular.io/guide/animations) out of curiosity.

## selected CodePen samples

| title | remarks |
|- |-
| [Jquery Fade vs CSS Fade](https://codepen.io/bryanbraun/pen/YXxoBY) | after pressing the **Animate** button for the CSS Fade, the I-beam cursor will persist because the `div` containing text does not collapse |
| [Fade-In/Fade-Out Menu - Pure CSS](https://codepen.io/pseudosocial/pen/yJLjLL) | lots to learn here like the use of `:target` |
| [CSS: fade in down sequence](https://codepen.io/gabrieleromanato/pen/xVYdRp) | an excellent use case for `animation-delay`
| [Looping text with CSS fade animation](https://codepen.io/bekahmcdonald/pen/vYBXMOZ) | this approach, with all those `span` elements declared would do well in a data-driven rendering scenario (e.g. Blazor) |

<https://github.com/BryanWilhite/>
