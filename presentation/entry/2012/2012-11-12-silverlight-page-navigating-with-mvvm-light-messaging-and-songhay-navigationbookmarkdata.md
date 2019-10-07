---json
{
  "author": "Bryan Wilhite",
  "content": "While Silverlight was deep in the cryogenic freezer in Redmond in the Windows-8-summer of 2012, I was working on my minimalist masterpiece, GenericWeb Editor (see screenshot). This editor (an internal tool) replaces the work I sold (by work-for-hire) to ...",
  "inceptDate": "2012-11-12T16:00:00-08:00",
  "isPublished": true,
  "slug": "silverlight-page-navigating-with-mvvm-light-messaging-and-songhay-navigationbookmarkdata",
  "title": "Silverlight Page Navigating with MVVM Light Messaging and Songhay NavigationBookmarkData"
}
---

While Silverlight was deep in the cryogenic freezer in Redmond in the Windows-8-summer of 2012, I was working on my minimalist masterpiece, GenericWeb Editor ([see screenshot](http://www.flickr.com/photos/wilhite/7654180068/in/photostream)). This editor (an internal tool) replaces the work I sold (by work-for-hire) to UCLA, [dating back to before 2009](http://kintespace.com/rasxlog/?p=1775)—when I was not using Silverlight in any serious way. In those days, I was web-page centric—so the Silverlight/WPF concept of the Navigation Page was very welcome. The problem is that, apart from the default “[Silverlight Navigation Application](http://msdn.microsoft.com/en-us/library/cc838245(v=vs.95).aspx),” there is not much guidance in this area.

My design goals center around this strong point: any Navigation Application has to know about the locations/indicators in its domain. This implies that there are *known* Navigation locations and *unknown* locations. There are two types of known indicators: keys and patterns. My intent is to make Navigation data-centric—data-driven… So I’ve made for myself the `NavigationBookmarkData` class to express this intent. This class defines the following conventions:
<table class="WordWalkingStickTable"><tr><td>

Get Data Format
</td><td>

A pattern for getting data by a unique identifier: `"#/{0}/{1}"`.
</td></tr><tr><td>

New Data Format
</td><td>

A pattern for adding data: `"#/{0}/New"`
</td></tr><tr><td>

Delete Confirmation Key
</td><td>

A key for the conventional application Delete Confirmation: `"DeleteConfirmation"`
</td></tr><tr><td>

Entity Association Selection Key
</td><td>

A key for the conventional application Entity Association Selection: `"EntityAssociationSelection"`
</td></tr><tr><td>

Entity Associations Key
</td><td>

A key for the conventional application Entity Associations: `"EntityAssociations"`
</td></tr><tr><td>

Error Message Key
</td><td>

A key for the conventional application Error Message : `"ErrorMessage"`
</td></tr><tr><td>

Index Key
</td><td>

A key for the conventional application Index: `"#/"`.
</td></tr><tr><td>

Information Message Key
</td><td>

A key for the conventional application Information Message : `"InformationMessage"`
</td></tr><tr><td>

Search Key
</td><td>

A key for the conventional application Search: `"Search"`
</td></tr></table>

## Using NavigationBookmarkData

All Navigation commands are ‘tested’ by `NavigationBookmarkData` to determine whether the Navigation location exists. Passing `NavigationBookmarkData` tests means that a Bookmark is found and a call to `HtmlPage.Window.NavigateToBookmark(bookmark)` can be made. In my early designs, I would have considered a call to `NavigateToBookmark` as ‘indirect’—why can’t I touch the Navigation Frame directly? Calling out to the `HtmlPage.Window` is indeed the start of round trip from the internals of the Silverlight application out to the hosting Web browser and then back to the Silverlight application. Why do this? I do this because this design makes “deep linking” in Silverlight possible. This design has only one way to handle Navigation commands: through changing the “hash tag” of the browser location—classic, Web 2.0, single-page-app navigation.

## Navigation Frame Eventing

My Generic Web Editor Navigation Frame handles the `Frame.Navigating` event by sending an MVVM Light message of type `LightNavigationMessage&lt;NavigatingCancelEventArgs&gt;`. This event is fired by typing in a hash location in the browser or by an internal Navigation command. My conventional `LightNavigationMessage&lt;T&gt;` checks the location to determine whether it is “well formed”; when it is well-formed then the location is parsed. The message is received in the Client View Model like this:

    Messenger.Default.Register&lt;LightNavigationMessage&lt;NavigatingCancelEventArgs&gt;&gt;(this,
        message =&gt;
        {
            if(!message.IsExpectedMessage(LightMessageSource.View, "ClientFrame")) return;
            this.HandleClientNavigating(message);
        });

The `HandleClientNavigating()` routine uses `LightNavigationMessage&lt;NavigatingCancelEventArgs&gt;` to either cancel the navigation (with the reference to `NavigatingCancelEventArgs`) or use the parsed data in the message to invoke a command in the application. It is important to point out that the code I am writing is still not doing any explicit Navigation Page handling. When a Navigation message is received, a command (like a RIA operation, calling the server) is invoked. It is the Silverlight `UriMapper` that handles Navigation. My `UriMapper` looks like this:

    &lt;navigation:Frame.UriMapper&gt;
        &lt;uriMapper:UriMapper&gt;
            &lt;uriMapper:UriMapping Uri="" MappedUri="/Views/IndexPage.xaml"/&gt;
            &lt;uriMapper:UriMapping Uri="/" MappedUri="/Views/IndexPage.xaml"/&gt;
            &lt;uriMapper:UriMapping Uri="/{key}/{id}" MappedUri="/Views/{key}Page.xaml"/&gt;
            &lt;uriMapper:UriMapping Uri="/{key}" MappedUri="/Views/{key}Page.xaml"/&gt;
        &lt;/uriMapper:UriMapper&gt;
    &lt;/navigation:Frame.UriMapper&gt;

The `UriMapper` has a conventional relationship with the `NavigationBookmarkData` Bookmark keys thought the declaration of the `{key}` placeholder above. It follows that the same key is used to display a page and invoke an application command thought this loose convention.

## Yes, it can get more complicated…

In the spring of 2012, I was working on the [Silverlight BiggestBox](http://slbiggestbox.azurewebsites.net/), my personal teaching/practice tool for Silverlight. Because of <acronym title="Managed Exensibility Framework">MEF</acronym> (and inexperience) I developed a more complication Navigation strategy. I touched upon this in “[Implementing INavigationContentLoader with an abstract class…](http://songhayblog.azurewebsites.net/entry/show/implementing-inavigationcontentloader-with-an-abstract-class)” I would like to take some the ideas shared here and revisit the BiggestBox.

## Related Resources

<table class="WordWalkingStickTable"><tr><td>

“[The Silverlight Navigation Framework](http://www.silverlightshow.net/items/The-Silverlight-3-Navigation-Framework.aspx)”
</td><td>

Some history from Martin Mihaylov (2009)… There’s a very well-done explanation of `JournalOwnership`: “If you don't want your Frame to integrate with the browser, to use the built-in history journal and to implement your own logic around the go-back and go-forward actions, this property allows you to do so.” 
</td></tr><tr><td>

“[Animated page navigation in SL3](http://firstfloorsoftware.com/blog/animated-page-navigation-in-sl3/)”
</td><td>

“While working recently on a navigation application, there was this requirement for animated page transitions. Moving from one page to another must look pretty and if possible should include advanced animations with pages flying in, fading out, etc.”

“So I started investigating if and how this was possible with the navigation framework. And the answer is that it is very, very easy and it does not require a single line of code.”

This solution uses the `TransitionalContentControl` by the way…
</td></tr><tr><td>

“[Page.OnNavigatedTo Method](http://msdn.microsoft.com/en-us/library/system.windows.controls.page.onnavigatedto(v=VS.95).aspx)”
</td><td>

“Typically, you use the `OnNavigatedTo` method instead of creating an event handler for the Loaded event. The `OnNavigatedTo` method is preferable because it is only called once for each time the page becomes active. The Silverlight framework raises the `Loaded` event each time the element is added to the visual tree, which potentially can happen more than once when activating a page.”
</td></tr><tr><td>

“[NavigationService Class](http://msdn.microsoft.com/en-us/library/system.windows.navigation.navigationservice(v=vs.95).aspx)”
</td><td>

Thanks for asking, yes, I use `NavigationService` in my GenericWeb Editor at the `Page` level: “You use the NavigationService class from within a Silverlight page. It enables you to access the navigation service used by the hosting frame and launch new navigation requests. You can retrieve the navigation service through the NavigationService property of the Page class.”
</td></tr><tr><td>

“[The DataForm Control in Silverlight 3](http://dotnetslackers.com/articles/silverlight/The-DataForm-Control-in-Silverlight-3-Revisited.aspx)”
</td><td>

This 2009 Dino Esposito is a great overview of this Silverlight Toolkit control. I mention it here because I notice that a `DataForm` control loading in a Navigation Page sometimes appears disabled. I thought that Dino h could show me an event or a property I could set to stop this annoying thing from happening.
</td></tr><tr><td>

“[Silverlight 3 Navigation: Navigating to Pages in referenced assemblies](http://www.davidpoll.com/2009/07/12/silverlight-3-navigation-navigating-to-pages-in-referenced-assemblies/)”
</td><td>

“Dividing your pages across multiple assemblies doesn’t have to degrade user experience, and once you’re familiar with the style of URI that the navigation framework expects for such pages, it’s no more complex than standard navigation within your Silverlight application.”
</td></tr><tr><td>

“[Silverlight 3 Navigation framework with on demand assemblies](http://forums.silverlight.net/forums/t/91029.aspx)”
</td><td>

“The Silverlight 3 Beta of Navigation does not support on-demand loaded assemblies. You could load data, services, and things like that, but XAML pages must be in the DLLs that are packaged in the XAP for the Frame control to find them.”
</td></tr><tr><td>

“[HtmlWindow.Navigate and enableHtmlAccess](http://wildermuth.com/2008/04/05/HtmlWindow_Navigate_and_enableHtmlAccess)”
</td><td>

Shawn Wildermuth in 2008: “So the lesson learned here is to use `HtmlPage.IsEnabled` to test to see if your particular host allows access to the HTML of the page (including support for `HtmlWindow.Navigate`).”
</td></tr><tr><td>

“[HtmlPage.PopupWindow vs. HtmlWindow.Navigate](http://www.wintellect.com/CS/blogs/rrobinson/archive/2009/02/03/htmlpage-popupwindow-vs-htmlwindow-navigate.aspx)”
</td><td>

This might have changed since Silverlight 2: “…I decided to have another look at `HtmlWindow.Navigate()` which seems to more accurately mirror the behavior that I would expect out of something that purports to wrap `window.open()`. Going this route, we lose the strong typing of the `HtmlPopupWindowOptions`, but in exchange we get exactly what we are expecting when calling `window.open()`.”
</td></tr></table>
