---json
{
  "author": "Bryan Wilhite",
  "content": "Before my usual self-critiquing ensues, let me first say that I am pleased that the days have finally come to find me actively addressing contemporary Web design issues. From the beginning of my IT career I considered myself conservative but current with...",
  "inceptDate": "2012-11-28T16:00:00-08:00",
  "isPublished": true,
  "slug": "design-notes-xhtml5-responsive-gallery",
  "title": "Design Notes: XHTML5 Responsive Gallery"
}
---

Before my usual self-critiquing ensues, let me first say that I am pleased that the days have finally come to find me actively addressing *contemporary* Web design issues. From the beginning of my IT career I considered myself conservative but current with what was useful in my HTML-based practice. However, over the last three years (or more probably), since my dedication to Silverlight (and WPF) my Web design skills have aged.

My live sample, “[XHTML5 Responsive Gallery](http://songhay.blob.core.windows.net/samples-jquery/960GsGallery.html),” represents a fresh, bold way of being expressive with what I consider are the ‘new’ fundamentals of Web design. These fundamentals include:

*   A CSS grid system
*   CSS media queries
*   jQuery templating with JSON

## Stacking image panel on thumbnails with absolute positioning…

My Responsive Gallery is essentially three pieces: the main panel that shows gallery images (of course), a “contact sheet” of thumbnails and a ‘command bar’ (button panel). My main panel should lie on top of the contact sheet—and a command-bar button, by the way, hides the main panel to allow access to the thumbnails.

This panel stacking with respect to the *z*-axis is obtained with these points:

*   The panels to stack have to be in a container with `position: relative`.
*   The panels to stack have `position: absolute` and z-ordering.
*   The panels and their container have the same height.

The idea of absolute positioning in a relative block is one of my CSS fundamentals and recorded for my education in a sample I call “[Block Alignment: Absolute Positioning in a Relative Block](http://songhay.blob.core.windows.net/samples-css/block-relative-positioning.html).” It feels great to see that these fundamentals can be reused here. Fewer tricks to memorize… simple variations on a primal core…

An alternative, relatively-old, hacky strategy is to use negative margins. This negative-margin technique goes back to [before 2004](http://www.alistapart.com/articles/negativemargins/) but, by 2008, folks like Ben Nadel regard them as “[not cool](http://www.bennadel.com/blog/1174-Negative-CSS-Margins-Are-Not-Cool.htm)”:
<blockquote>

Instead of using a negative margin, maybe try floating an element? Or perhaps positioning it absolutely to its parent? Before you even consider a negative margin, please consider what would happen if other elements on the page changed height or width. My guess is that your negative margin depends way too much on other parts of the page in a way that is not necessary.
</blockquote>

## Responding in the vertical dimension with CSS media queries…

Two other CSS samples out of my studio, “[XHTML5 Responsive Client](http://songhay.blob.core.windows.net/samples-css/960-gs-fluid-12.html)” and “[XHTML5 Responsive Client with 6-Tile Panel](http://songhay.blob.core.windows.net/samples-css/960-gs-fluid-12-panel.html),” are a wild celebration of ‘tiles’—inline blocks that respond to horizontal-dimension change by reflowing with respect to a minimum width. These samples have no concern for the vertical dimension outside of default flow.

The“[XHTML5 Responsive Gallery](http://songhay.blob.core.windows.net/samples-jquery/960GsGallery.html)” is my first attempt to respond to vertical-dimension change by rendering the height as a multiple of gallery-thumbnail height. The height of the gallery changes incrementally not continuously—and the response in height is limited (no endless vertical scroll). The height of the gallery is limited to expected height of the images in the gallery shown. This implies that the container holding the thumbnails have `overflow: hidden`.

## Paging thumbnails based on hidden overflow and ‘visible tile count’…

Hiding the thumbnails means a “paging” mechanism is required to see the thumbnails that can fit in the current view. The number of pages must change responsively—responding to the `$(window).resize()` event. But the resize event fires like crazy—almost continuously—while dragging a mouse on the desktop for some browsers. I needed a way to ‘slow down’ the resize event—what I found was a word I do not claim to fully understand: “debounce.” So now I have `$(window).debounce('resize', …)` from a jQuery plugin called “[.delayed()—A jQuery plug-in for delaying and debouncing events](http://www.theloveofcode.com/jquery/delayed/).”

With my “debounce” issues taken care of I had to write a paging solution that was based on the visible items shown in their parent container. The jQuery-based JavaScript describing this solution is viewable in the [sample](http://songhay.blob.core.windows.net/samples-jquery/960GsGallery.html). The visible items shown in their parent container have width and height dimensions that are multiples of the width and height of the parent container respectively. Without this ‘multiples’ relationship, I would have no way to count how many items were visible (and would probably end up trying to write some more complicated stuff based on each and every item trying to determine whether it is visible).

## Determining image orientation and doing resizing with jQuery…

When an image is shown in a gallery, whatever is showing the image has to know whether it is landscape or portrait. This knowledge is used to find the largest dimension of the image. With the largest dimension, the image can then be resized to fit within its parent container. The resizing has to be done based on aspect ratio. The jQuery-based JavaScript describing this resizing is viewable in the [sample](http://songhay.blob.core.windows.net/samples-jquery/960GsGallery.html).

## Related Links

*   “[Using Viewport to create a mobile friendly version](http://stackoverflow.com/questions/6293511/using-viewport-to-create-a-mobile-friendly-version)”
*   “[Fluid 960 Grid System](http://www.designinfluences.com/fluid960gs/)”
*   “[62.5% font size?](http://css-tricks.com/forums/discussion/17027/62-5-font-size/p1)”
*   “[How to Size Text in CSS](http://www.alistapart.com/articles/howtosizetextincss)”
*   “[5 Useful CSS Tricks for Responsive Design](http://webdesignerwall.com/tutorials/5-useful-css-tricks-for-responsive-design)” —new CSS for me: `word-wrap: break-word`
*   “[How to Center Anything With CSS](http://designshack.net/articles/css/how-to-center-anything-with-css/)”
*   “[Crossfading Images](http://css3.bradshawenterprises.com/cfimg/)” —CSS 3 stuff… might want to add in later…
