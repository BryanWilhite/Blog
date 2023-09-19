---json
{
  "documentId": 0,
  "title": "Some Ex-Silverlight-Guy Closure",
  "documentShortName": "2014-09-22-some-ex-silverlight-guy-closure",
  "fileName": "index.html",
  "path": "./entry/2014-09-22-some-ex-silverlight-guy-closure",
  "date": "2014-09-22T07:00:00Z",
  "modificationDate": "2014-09-22T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-09-22-some-ex-silverlight-guy-closure",
  "tag": "{\r\n  \"extract\": \"I don’t even want to bother going into the details. But last year I was unable to properly record many of my findings from working with Telerik controls and Silverlight over RIA services. All I have now are a few scraps from the past and will try to piec...\"\r\n}"
}
---

# Some Ex-Silverlight-Guy Closure

I don’t even want to bother going into the details. But last year I was unable to properly record many of my findings from working with Telerik controls and Silverlight over RIA services. All I have now are a few scraps from the past and will try to piece them together:

## Place RadControls for Silverlight Next to the Silverlight Toolkit

The assertion above is basically saying that it is possible to work with Telerik controls side-by-side with Microsoft’s “[Silverlight Toolkit](http://silverlight.codeplex.com/).” This was concern of mine because of the large XAP file sizes as a consequence—but the final product I was working on was delivered in an Intranet (in an enterprise still using many, many Windows XP machines—so using HTML 5 was seriously out of the question).

## Avoid “Unbound Mode” for the Telerik RadGridView

I’m sure Telerik has moved on over a year but it must be said that I had serious trouble trying to use the `RadGridView` like a ‘tiny’ grid without a formal data source to bind to—the idea was to add new rows from code-behind, probably from MVVM Light messages. Eventually I learned to use the ‘tiny’ DataGrid from the Silverlight toolkit.

## Do Send Messaging around DomainService SubmittedChangesEventArgs

One of the out-of-the box benefits of RIA Services was the paging data with the “Domain Service” concept. You could declare, in XAML, a `RadDataPager` with an associated `DomainDataSource` as described in “[Q1 2010 New Feature: Paging with RadGridView for Silverlight and WPF](http://blogs.telerik.com/xamlteam/posts/10-03-10/q1-2010-new-feature-paging-with-radgridview-for-silverlight-and-wpf.aspx).” (There were I vaguely recall, by the way, two different `DomainDataSource` controls—one from a Microsoft toolkit and the other from Telerik—I found out the hard way to use the one from Telerik.) This out-of-the-box stuff was at first very opaque to me until I discovered eventing around `DomainDataSource`, specifically `DomainDataSource.SubmittedChanges`. I am almost certain that I used the event data, specifically `SubmittedChangesEventArgs.ChangeSet`, to drive MVVM light messaging from View to View Model. The `EntityChangeSet` concept was the bee’s knees to me—until my ‘great discovery’ chronicled in “[Songhay Studio: UX and DDD, my new acronym umbrella….](http://songhayblog.azurewebsites.net/Entry/Show/songhay-studio-ux-and-ddd-my-new-acronym-umbrella)”

What is more is my very strong suspicion that Telerik dropped RIA services entirely for Silverlight and is [now recommending](http://demos.telerik.com/silverlight/) the `DataServiceDataSource`.

## The Desire to Experience an Elegant Solution for Many-to-Many Relations

One of the lasting issues taken away from my Silverlight project from last year is the UX around representing many-to-many relations. My ‘big discovery’ then was something like, ‘Hey! The classic master-detail visualization (one-to-many relations) is covered quite well with a grid and a form—but what about many-to-many relations? Today, there is still no satisfactory answer. But this question may be moot in the context of DDD. It may be that we are not supposed to visualize many-many relations for editing scenarios—to need to do so likely reeks of an anemic domain model.

## Pack a Visual in a Message and Send It to a View Model?

Using MVVM Light messaging or Prism eventing to send a portion of a View (e.g. a `UserControl`) to a View Model is like picking up and dropping an entire refrigerator on a guest in your home simply because he asked for a can of soda pop! Surely is this one of [my MVVM anti-patterns](http://songhayblog.azurewebsites.net/Entry/Show/the-fat-getter-and-other-mvvm-anti-patterns)?

There were a handful of cases where I struggled with `RadGridView` issues and ended up taking that piece of the grid and sending it to the View Model for processing. After working with WPF for over a year such an impasse has not emerged at all.

<https://github.com/BryanWilhite/>
