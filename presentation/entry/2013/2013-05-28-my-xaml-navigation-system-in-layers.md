---json
{
  "documentId": 0,
  "title": "My XAML Navigation System in Layers",
  "documentShortName": "2013-05-28-my-xaml-navigation-system-in-layers",
  "fileName": "index.html",
  "path": "./entry/2013-05-28-my-xaml-navigation-system-in-layers",
  "date": "2013-05-29T00:00:00.000Z",
  "modificationDate": "2013-05-29T00:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2013-05-28-my-xaml-navigation-system-in-layers",
  "tag": "{\r\n  \"extract\": \"Layer 1: the FrameAt the core of my stinky onion is the Frame control, hosted in a UserControl. I prefer to have one Frame per application, which implies that the UserControl is my conventional Client control (Microsoft culture has called this Main or Ho...\"\r\n}"
}
---

# My XAML Navigation System in Layers

## Layer 1: the Frame

At the core of my stinky onion is the `Frame` control, hosted in a `UserControl`. I prefer to have one `Frame` per application, which implies that the `UserControl` is my conventional `Client` control (Microsoft culture has called this `Main` or `Home`—in the ASP.NET MVC space). Anyway, because I call my default visual “Client”, the navigation frame is called `ClientFrame`:

```xml
<navigation:Frame x:Name="ClientFrame"
    BorderThickness="0">
    <navigation:Frame.UriMapper>
        <uriMapper:UriMapper>
            <uriMapper:UriMapping Uri="" MappedUri="/Views/IndexPage.xaml"/>
            <uriMapper:UriMapping Uri="/" MappedUri="/Views/IndexPage.xaml"/>
            <uriMapper:UriMapping Uri="/{key}/{id}" MappedUri="/Views/{key}Page.xaml"/>
            <uriMapper:UriMapping Uri="/{key}" MappedUri="/Views/{key}Page.xaml"/>
        </uriMapper:UriMapper>
    </navigation:Frame.UriMapper>
</navigation:Frame>
```

This declaration comes with several implications:

* The only content to be loaded in a Frame is a `System.Windows.Controls.Page`. To need an exception to this rule suggests that the application is getting too complex.
* The default Page is `IndexPage.xaml`. This strongly suggests that this page is some kind of human-readable summary of the application domain.
* Every `Page` name in the application should end with ‘Page.’
* Visuals representing the Domain can be located by a “key” or a key with an ID.

It is my intent that all of these keys should be stored in `NavigationBookmarkData` (see below).

## Layer 2: Frame Eventing in Code Behind

My [PasteBin.com code sample](http://pastebin.com/rGsCYRsS) shows (almost) all of the eventing required for a navigation `Frame`. The table below summarizes:
<table class="WordWalkingStickTable"><tr><td>
`ClientFrame.Navigated`
</td><td>
This event is primarily used to extract the `Page.NavigationService` from the `Frame.Content`. The Navigation Service is then used by the Client to support an application-wide “back button” command. The “back button” concept lives on quite strongly in Windows Phone (and Windows 8).
</td></tr><tr><td>
`ClientFrame.Navigating`
</td><td>
This event is handled to allow the application to cancel navigation. When a service layer is built into the application, this event can be used to start service calls related to the navigation target.

The [data associated](http://msdn.microsoft.com/en-us/library/system.windows.navigation.navigatingcanceleventargs.aspx) with this event, `NavigatingCancelEventArgs`, can also be used to extract the target URI of navigation.

Because I use MVVM Light, I have written an Extension Method, `Page.SendLightNavigationMessage()`, to allow this event to be handled in a decoupled manner, using the Messaging system in MVVM Light.
</td></tr><tr><td>
`ClientFrame.NavigationFailed`
</td><td>
The conventional error “window” is used here.
</td></tr></table>

## Layer 3: `NavigationBookmarkData`

Back in 2012, in “[Silverlight Page Navigating with MVVM Light Messaging and Songhay NavigationBookmarkData](http://songhayblog.azurewebsites.net/entry/show/silverlight-page-navigating-with-mvvm-light-messaging-with-lightnavigationmessage-navigatingcanceleventargs-and-songhay-navigationbookmarkdata),” I went into detail about this class definition. [Another PasteBin.com sample](http://pastebin.com/9YN1cwEL) for this class is available.

## Layer 4: Handling `NavigatingCancelEventArgs`

It’s the `NavigationBookmarkData` that can be used to determine whether a Navigation should or should not be cancelled. My `ClientViewModel` has concerns for Messaging and Navigating. Messaging logic supports the `LightNavigationMessage<NavigatingCancelEventArgs>` sent by Client `UserControl`. Navigating logic handles this ‘light-navigation’ message by evaluating it with the `NavigationBookmarkData`. A rough sketch of the handler illustrates:

```c#
void HandleClientNavigating(LightNavigationMessage<NavigatingCancelEventArgs> message)
{
    navigationBookmarks.SetBookmarkContext(message.TargetLocation);
    string category = (message.RelativeUriSegments.Length > 1) ?
        message.RelativeUriSegments[1] : null;
    int? id = (message.RelativeUriSegments.Length > 2) ?
        FrameworkTypeUtility.ParseInt32(message.RelativeUriSegments[2]) : null;
    if(category == "category1" && id.HasValue) this.DoRiaOperationGetMyData(id.Value);
    else if(navigationBookmarks.IsBookmarkUnknown()) message.Content.Cancel = true;
    else throw new NotImplementedException("Page is not yet supported.");
}
```

First the handler puts the navigating location in ‘context’ so the `NavigationBookmarkData` can ‘validate’ it. The `LightNavigationMessage` class contains logic to split the navigating location into an array of `RelativeUriSegments` (see [PasteBin.com listing](http://pastebin.com/BErvgkt8)). This array can contain a key and/or ID, according to the conventions declared on Layer 1, the `ClientFrame`.

When we have `"category1"` and an ID we can then call the RIA service (in `DoRiaOperationGetMyData()`). The navigation system built into the .NET Framework (on Level 1) will display the page at the navigating target location. This page of course contains visuals bound to the data returned by the RIA operation.

However, when it is clear that the “bookmark” (or the navigation target location) set in context is unknown (`if(navigationBookmarks.IsBookmarkUnknown())`), then the navigation is cancelled.

## Layer 5: Actually Doing the Navigation

MVVM Commanding is what starts the funky Navigation going through each layer of our onion. The commanding eventually reaches logic that looks like this:

```c#
void DoNavigation(string category, int id)
{
    var format = this._bookmarks.GetPatternForGetDataFormat();
    var bookmark = string.Format(format, category, id);
    HtmlPage.Window.NavigateToBookmark(bookmark);
}
```

So Layer 1 uses what comes in the box with the .NET Framework and Layer 5, with its call to `HtmlPage.Window.NavigateToBookmark()`, is also using what ships from Microsoft. Or should I say what *shipped* from Microsoft?

The “death” of Silverlight in general strongly suggests that `HtmlPage.Window.NavigateToBookmark()` is dead (while the `Frame` lives on) in particular.

## Related Links

<table class="WordWalkingStickTable"><tr><td>
“[Windows 8 Metro Style Apps – Implementing Navigation with XAML](http://www.markermetro.com/2011/11/technical/windows-8-metro-style-apps-implementing-navigation-with-xaml/)”
</td><td>
This article shows that Windows 8 app design goes ‘back’ to calling `Frame.Navigate()` directly.
</td></tr><tr><td>
“[Navigation in Silverlight Without Using Navigation Framework](http://www.c-sharpcorner.com/uploadfile/37db1d/navigation-in-silverlight-without-using-navigation-framework/)”
</td><td>
“Silverlight 3 introduces Navigation Framework which takes care of this, but let's first try to achieve navigation and state management without this framework; or you can say, the way it is done in Silverlight 2.”
</td></tr><tr><td>
“[On-demand loading of assemblies with Silverlight Navigation – Revisited for Silverlight 4 Beta](http://www.davidpoll.com/2010/02/01/on-demand-loading-of-assemblies-with-silverlight-navigation-revisited-for-silverlight-4-beta/)”
</td><td>
“With Silverlight 4’s INavigationContentLoader extensibility point, we can address this scenario much more effectively, and are no longer locked into the workarounds and strict constraints that Silverlight 3’s navigation feature placed on us. In this post, I’ll walk through the use of another ContentLoader I’ve been working on and look at how it simplifies building multi-xap applications.”
</td></tr><tr><td>
“[Using MEF in Metro-style applications](http://andyonwpf.blogspot.com/2012/04/using-mef-in-metro-style-applications.html)”
</td><td>
“The good news is that MEF is included in the .Net base class libraries as part of the Metro-style application profile so is included in-the-box for all such applications. Unfortunately if you look at the documentation you will see references to ‘Assembly.GetExecutingAssembly()’ that is not available in the Metro-profile…”
</td></tr><tr><td>
“[Navigation Overview](http://msdn.microsoft.com/en-us/library/ms750478.aspx) [.NET 4.5]”
</td><td>
Introduces the `NavigationWindow` and `FragmentNavigation` concepts.
</td></tr><tr><td>
“[WinRT: MVVM Navigation and a MVVM Example App](http://mikaelkoskinen.net/winrt-mvvm-navigation-and-a-mvvm-example-app/)”
</td><td>
“If you’re using some container to create your view models, the `NavigationService`-instance can be registered into it as a singleton. If you’re using a simple `ViewModelLocator` without a container, the `NavigationService` can be added as a property to the App-class and it can be accessed when creating the view models. In either case, the `NavigationService` should be passed to the VM through the constructor, after which navigation from a view model is a straightforward task.”
</td></tr><tr><td>
“[How to I get access NavigationService in a WIndows Phone app without going through a PhoneApplicationPage?](http://stackoverflow.com/questions/8751787/how-to-i-get-access-navigationservice-in-a-windows-phone-app-without-going-throu)”
</td><td>
“You can get it from the app’s `PhoneApplicationFrame`. It will be accessible from anywhere in the app since every Windows Phone app has a Frame.”

```c#
((PhoneApplicationFrame)Application.Current
        .RootVisual).Navigate(...);
```

</td></tr><tr><td>
“[NavigationService for WinRT](http://dotnetbyexample.blogspot.com/2012/06/navigationservice-for-winrt.html)”
</td><td>
“So the string type methods allow you to specify the page to navigate by string. Before you all think I really lost my marbles this time, re-introducing weakly typed navigation just as the Windows team introduced strongly typed: I specifically added this as to allow navigation to be initiated from a `ViewModel` contained in an assembly not containing the XAML code. This also enables you to test code as well. This is the way I built my solutions for Windows Phone, and I intend to go on this way in Windows 8. ;-)”
</td></tr></table>

@[BryanWilhite](https://twitter.com/BryanWilhite)
