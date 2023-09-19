---json
{
  "documentId": 0,
  "title": "Implementing INavigationContentLoader with an abstract class…",
  "documentShortName": "2012-04-23-implementing-inavigationcontentloader-with-an-abstract-class",
  "fileName": "index.html",
  "path": "./entry/2012-04-23-implementing-inavigationcontentloader-with-an-abstract-class",
  "date": "2012-04-23T15:33:00Z",
  "modificationDate": "2012-04-23T15:33:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-04-23-implementing-inavigationcontentloader-with-an-abstract-class",
  "tag": "{\r\n  \"extract\": \"You’ve read the title. So, let me back up… In “Opening up Silverlight 4 Navigation: Introduction to INavigationContentLoader,” David Poll explains:If you haven’t noticed by now (or been following my previous blog posts), I happen to really enjoy explorin...\"\r\n}"
}
---

# Implementing `INavigationContentLoader` with an abstract class…

You’ve read the title. So, let me back up… In “[Opening up Silverlight 4 Navigation: Introduction to INavigationContentLoader](http://www.davidpoll.com/2009/11/30/opening-up-silverlight-4-navigation-introduction-to-inavigationcontentloader/),” David Poll explains:

<blockquote>

If you haven’t noticed by now (or been following my previous blog posts), I happen to really enjoy exploring the Navigation feature in Silverlight. A while back, I [posted a number of workarounds and tips](http://www.davidpoll.com/tag/navigation) for some desirable scenarios using the Navigation feature in Silverlight 3. Then… I went silent. And the reason: I’ve been waiting for an extensibility point to be opened up in Silverlight navigation. In the [Silverlight 4 beta](http://www.silverlight.net/getstarted/silverlight-4-beta/), that extensibility point has arrived as the INavigationContentLoader.

</blockquote>

Unlike David Poll, I was not in-the-loop-enough to “wait” for [Silverlight Navigation](http://msdn.microsoft.com/en-us/library/cc838245(v=vs.95).aspx) to open up. I just noticed that I was unable to define `UriMapper` programmatically—this discovery is reinforced by [the documentation](http://msdn.microsoft.com/en-us/library/system.windows.navigation.urimapper(v=vs.95).aspx)—notice that:

* `UriMapper.UriMappings` is read-only.
* The `UriMapper` constructor takes no arguments (like, say, a collection of `UriMappings`).

This effectively implies that you *must* define `UriMapper` in <acronym title="Extensible Application Markup Language">XAML</acronym>. Losing precious hours of my time, I notice that:

* You ‘should’ define `UriMapper` in `App.xaml` so it can recognize pages that might be loaded after initialization of the application domain.
* You can’t define `UriMapper` in `App.xaml` when you are using a generic application loader (because the *generic* loader is *not* supposed to know about the pages it is loading).[<img alt="Silverlight Deep Linking with MEF" src="http://farm9.staticflickr.com/8141/6958975678_778010bf8e.jpg">](http://www.flickr.com/photos/wilhite/6958975678/in/photostream "Silverlight Deep Linking with MEF")

It turns out that I need to implement `INavigationContentLoader` because it has no dependency on `UriMapper` (and its associated conventions) and because it is friendly to my <acronym title="Managed Exensibility Framework">MEF</acronym>-based composition. By wildly misinterpreting the work of David Poll (and, perhaps, the life’s work of Jeffrey Richter), I actually find it useful to implement an interface with an abstract class. I call it `NavigationContentLoader`. My reasons for doing this is because the `CancelLoad()` and `EndLoad()` members of `INavigationContentLoader` can have a default implementation (copied directly from David Poll). I mark methods `BeginLoad()` and `CanLoad()` abstract—declaring the intent that these members *must* be implemented. This intent becomes content in `BiggestBoxNavigationContentLoader`.

## Concerns of `BiggestBoxNavigationContentLoader…`

The `INavigationContentLoader` interface brings us the concept of the “current URI,” the current [fragment identifier](http://en.wikipedia.org/wiki/Fragment_identifier) representing a resource in the Silverlight application and the “target URI,” the next fragment identifier. It follows that the `BiggestBoxNavigationContentLoader` is concerned with:

* Mapping the “target URI” (of `INavigationContentLoader`) to type names of pages (to be used by `BiggestBoxCompositionHost.MefHost.GetPage()`).
* Parsing the “target URI” to map to type names of pages—and to extract parameters (user-control or packed-XAML sample names).
* ‘Caching’ “target URI” parameter (user-control or packed-XAML sample name) to be inspected by the current page during the `OnNavigatedTo()` call (when the page finds a name it can use then the page loads a sample into a child window).

## Supporting Deep Linking in a MEF-Composed Silverlight Application

This ‘caching’ behavior is very important because of the need to support “[deep linking](http://en.wikipedia.org/wiki/Deep_linking)” into the Silverlight application. This support is challenging because a deep link can indicate a resource in the Silverlight application that is not currently available because of the asynchrony of <acronym title="Managed Exensibility Framework">MEF</acronym> Composition. It follows that such an indicator has to be ‘cached’ until the application is composed.

It was tempting to try a simpler approach to solving this problem but these issues made such ease impossible:

* Reloading the same URI with `HtmlPage.Window.Navigate()` is ignored by the current instance of `Frame.ContentLoader` (which would be my `BiggestBoxNavigationContentLoader`).
* Silverlight does not call the `Page.OnNavigatedTo()` method when `Page` is setting `Frame.Content` programmatically. I threw together the `IComposableView` interface, with its `DoNavigateFrom()` and `DoNavigateTo()` methods in direct response to this issue by design.

<https://github.com/BryanWilhite/>
