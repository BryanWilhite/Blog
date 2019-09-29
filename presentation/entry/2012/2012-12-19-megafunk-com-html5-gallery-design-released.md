---json
{
  "author": "Bryan Wilhite",
  "content": "I can find two other HTML-5, responsive, “Gallery” designs out there. One is for sale and the other is for WordPress. Neither addresses paging thumbnails (visuals covered in “Design Notes: XHTML5 Responsive Gallery”)—but both of them look much better tha...",
  "inceptDate": "2012-12-19T16:00:00-08:00",
  "isPublished": true,
  "slug": "megafunk-com-html5-gallery-design-released",
  "title": "MegaFunk.com HTML5 Gallery Design Released"
}
---

[<img alt="Apple iPad Mini MD531LL/A (16GB, Wi-Fi, White)" src="http://ecx.images-amazon.com/images/I/317qBBOVKJL.jpg" style="float:right;margin:16px;">](http://www.amazon.com/Apple-iPad-MD531LL-Wi-Fi-White/dp/B00746W9F2%3FSubscriptionId%3D1SW6D7X6ZXXR92KVX0G2%26tag%3Dthekintespacec00%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3DB00746W9F2 "Apple iPad Mini MD531LL/A (16GB, Wi-Fi, White)")

I can find two other HTML-5, responsive, “Gallery” designs out there. [One is for sale](http://codecanyon.net/item/html5-responsive-slider-gallery/2994539) and [the other is for WordPress](http://wpmu.org/responsive-wordpress-gallery-plugin/). Neither addresses paging thumbnails (visuals covered in “[Design Notes: XHTML5 Responsive Gallery](http://songhayblog.azurewebsites.net/entry/show/design-notes-xhtml5-responsive-gallery)”)—but both of them look much better than [what I’ve done so far](http://songhay.blob.core.windows.net/design-megafunk/gallery.html)…

Nevertheless, I should be pleased at the relative improvement over my earlier work. I was walking around a shopping mall in Century City today—going from the Apple Store to the Sony Store—testing my work on iPad and Android tablets and the design responded well with only one naked failure: the character I am using for an “up arrow” (▲) shows up as a box on a Sony Android tablet.

### Setting a large “view port”…

Overriding my preference for using `device-width`, this `meta` element is in play:

    &lt;meta name="viewport" content="width=528; height=device-height;" /&gt;

Instead of making the MegaFunk.com menu responsive, a minimum width of `528px` is set to prevent the menu items from stacking. This causes pan-and-scan swiping and zooming on smartphones and even a little on the iPad.

What I don’t like my design’s response to the iPad is the lack of centering as it feels like it’s drifting out of view…

### Translating the View Model concept to JavaScript

I have already fallen deeply in love with [Knockout.js](http://knockoutjs.com/) back in the summer of 2011, so I am aware of its Silverlight-like, <acronym title="Model">MVVM</acronym> design possibilities (what gets us super-close is the relatively new [breeze.js](http://www.breezejs.com/)*plus* Knockout). What I failed to do with Knockout was formally establish when *not* to use it—*and* prepare my Javascript/jQuery to be “progressively enhanced” with Knockout just in case it’s needed later.

My deliberate use of the View Model concept is this formal preparation. My JavaScript View Model is just an object that is concerned with a visual container (or two) and its name has the suffix `ViewModel`. It should follow that the complexity in a Single Page Application (SPA) can be measured by how many `*ViewModel` objects there are.

Once these View Model objects are adorned with Knockout observables, then we are in what we Silverlight folks called a “two-way binding” world…

### The ‘Ready’ function with jQuery

A very powerful concept (for me at the moment) that allows me to break blocks of jQuery into smaller logical groups is the *ready* concept. Back in the old <acronym title="Asynchronous JavaScript and XML">AJAX</acronym> days, I used the *format* concept. But with the advent of jQuery, we’re setting events, animations and visual formatting. So I’ve rolled these tasks up (per visual) into *ready* functions.

In the case of my gallery, I use `readyMegaGallery``()`. This is called inside of `$(window.document).ready(``)` like this:

    $(window.document).ready(function () {
        var flow = $('#GalleryContainer');
        if (flow.length &gt; 0) {
            $.getJSON('./data/browse.json').then(function (data) {
                galleryViewModel.setGalleries(data);
                readyMegaGallery(data);
            });
        }
    });

We can see that this *ready* concept is in line with `jQuery.ready`.

### New jQuery tricks (for me)…

I mistakenly thought that `jQuery.next()` would select the next sibling matching its selector without regard for its contiguity. I was wrong: what we must use is `jQuery.nextAll('.MyClass:first')` where the class, `.MyClass`, in the selector may indicate contiguous sibling or not.

Another awesome first for me is `jQuery.index()`. My approach to responsive design is to build a grid system out of *tiles*. Locating these arrays of tiles by an *index* is solved by `jQuery.index()`. I will need more tile tricks that are inspired by classic file explorers that group, sort and filter.
