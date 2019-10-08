---json
{
  "documentId": 0,
  "title": "Delicious Dumper: Old Silverlight Links",
  "documentShortName": "2014-07-07-delicious-dump-old-silverlight-links",
  "fileName": "index.html",
  "path": "./entry/2014-07-07-delicious-dumper-old-silverlight-links",
  "date": "2014-07-07T07:00:00.000Z",
  "modificationDate": "2014-07-07T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-07-07-delicious-dump-old-silverlight-links",
  "tag": "{\r\n  \"extract\": \"Here lies a collection of Silverlight links I used for my research in years past. My research technique depends heavily on my Delicious ‘Funky KB’- or ‘Blog’-tagged link collections. These collections are eventually processed into a document like this an...\"\r\n}"
}
---

# Delicious Dumper: Old Silverlight Links

Here lies a collection of Silverlight links I used for my research in years past. My research technique depends heavily on my Delicious ‘[Funky KB](https://delicious.com/rasx/funkykb)’- or ‘[Blog](https://delicious.com/rasx/blog)’-tagged link collections. These collections are eventually processed into a document like this and deleted from Delicious (to ensure that my data is not in the hands of a potentially non-helpful third party—as of this writing, you can see by the thousands of links still with Delicious, that I still need Delicious to “do no evil”).
<
table class="WordWalkingStickTable"><tr><td>

“[CollectionViewSource as ItemSource problem](http://www.telerik.com/community/forums/silverlight/combobox/collectionviewsource-as-itemsource-problem.aspx)”
<
/td><td>

“`RadComboBox` treats all items sources as `IEnumerable`, hence it does not automatically update `ICollectionView` if such is provided. This looks like a nice feature, so I will add it to the product backlog. We will include it in the upcoming major release Q3 2009, scheduled after less than two months.” — Valeri Hristov, Telerik
<
/td></tr><tr><td>

“[5+ Ways to Reduce your .Xap Size](http://blogs.telerik.com/miromiroslavov/posts/10-09-15/5-ways-to-reduce-your-xap-size.aspx)”
<
/td><td>

“In the Telerik’s Silverlight world the solution is called [Assembly Minifier](http://minifier.telerik.com/). It reduces the compiled [assembly’s] size by removing the controls (code and resources) that your application doesn't need during run-time. The result is smaller assemblies, smaller xap, which results in faster download time and faster application loading. You can read [my post](http://blogs.telerik.com/miromiroslavov/posts/10-07-15/telerik_assembly_minifier_-_official_release.aspx) for more information on how to use the tool.”
<
/td></tr><tr><td>

“[Free UI Controls &amp; Components](http://www.telerik.com/community/download-free-products.aspx)”
<
/td><td>

I’m noticing that the Silverlight freebies are being updated. It’s been about two years.
<
/td></tr><tr><td>

“[Why no LoadSize?](http://www.telerik.com/community/forums/silverlight/domain-datasource/why-no-loadsize.aspx)”
<
/td><td>

“Unfortunately, the `LoadSize` feature is the only feature that `RadDomainDataSource` lacks compared to the stock `DomainDataSource`.”

The “stock” `DomainDataSource`. Surely refers to the control in the Silverlight Toolkit. I wasted more than two hours thinking that the “stock” control was better than Telerik’s. I need to use the Telerik `RadDomainDataSource` because it supports the paging and sorting features of the Telerik grid. The `GridView` will behave strangely when it’s backed by the “stock” `DomainDataSource`.
<
/td></tr><tr><td>

“[Introducing RadDomainDataSource for Silverlight](http://blogs.telerik.com/xamlteam/posts/10-12-24/introducing-raddomaindatasource-for-silverlight.aspx)”
<
/td><td>

`RadDomainDataSource` is a Silverlight control that provides the missing link between [Telerik Data Controls](http://demos.telerik.com/silverlight/) and [WCF RIA Services](http://www.silverlight.net/getstarted/riaservices/).
<
/td></tr><tr><td>

“[Not all the cells available in e.Row.Cells of RowLoaded event](http://www.telerik.com/community/forums/silverlight/gridview/not-all-the-cells-available-in-e-row-cells-of-rowloaded-event.aspx)”
<
/td><td>

This problem is the slippery slope into the performance over maintainability chasm that makes the Telerik grid a “challenge” to work with… To support performance-enhancing row virtualization features you can’t just walk up to a Telerik grid and ask it about its rows.
<
/td></tr><tr><td>

“[DataForm in User Control](http://www.telerik.com/community/forums/silverlight/data-form/dataform-in-user-control.aspx)”
<
/td><td>

“The first problem we encountered was that data annotations are not passed through when the `RadDataForm` is in mode `AutoGenerateFields = False`.”

I got around this problem by sending MVVM Light messaging around the `DataForm.AutoGeneratingField` event.
<
/td></tr><tr><td>

“[How to use Genreric AggregateFunction?](http://www.telerik.com/community/forums/silverlight/gridview/how-to-use-genreric-aggregatefunction.aspx)”
<
/td><td>

“Can anyone provide a simple example on how to use Generic `AggregateFunction` for a `GridViewExpressionColumn`?”

I wrote [an extension method](http://pastebin.com/Pbvchtdw) to send `GridViewExpressionColumn` visuals to a View Model (yet another violation of MVVM).
<
/td></tr><tr><td>

“[GridView filtering with distinct values and converter](http://www.telerik.com/community/forums/silverlight/gridview/gridview-filtering-with-distinct-values-and-converter.aspx)”
<
/td><td>

A reminder (for me): “One of the most common pitfalls is thinking that an `IValueConverter` defined on the `DataMemberBinding` of the column will affect the data operations in any way. It will not. The `DataMemberBinding` `IValueConverter` and the `DataFormatString` of the column are used for UI purposes only. They can only change the appearance of data into something more user-friendly such as $ 2.22, but they do not play any role in the data engine.”
<
/td></tr><tr><td>

“[Task continuation on UI thread](http://stackoverflow.com/questions/4331262/task-continuation-on-ui-thread)”
<
/td><td>

Another reminder: “Call the continuation with `TaskScheduler.FromCurrentSynchronizationContext()`”
<
/td></tr><tr><td>

“[Silverlight 4—Copy/Paste From Clipboard](http://www.dreamincode.net/forums/topic/197214-silverlight-4-copypaste-from-clipboard/)”
<
/td><td>

News with a low learning curve: “For security purposes, access to the clipboard is only allowed through a user-initialed event. For example, you couldn’t have a timer running in the background to constantly get text from the clipboard.”
<
/td></tr><tr><td>

“[Can Silverlight initiate Page Refreshes?](http://stackoverflow.com/questions/552756/can-silverlight-initiate-page-refreshes)”
<
/td><td>

Interesting but currently not recommended: “Why not simply stay on the Silverlight side and call `System.Windows.Browser.HtmlPage.Document.Submit();` This works if the page has a `&lt;form/&gt;` element on it (e.g. any Web Forms page). Without a `&lt;form/&gt;` element (e.g. many ASP.NET MVC pages), there is nothing to submit, and you get an `InvalidOperationException`.”–Richard Beier
<
/td></tr><tr><td>

“[Silverlight 5: beautifying fonts](http://netpalantir.it/news/index/silverlight-5-fonts-and-typography)”
<
/td><td>

“`TextFormattingMode`: this option controls the way glyphs are generated. You have two possible settings: Ideal or Display. Ideal will generate nicer text then fonts size is large enough. Display will generate full-pixel glyphs which are not so nice when font is large, but are better for small text. `TextHintingMode`: this option controls the text hinting, and its main purpose is to allow the developer to disable text optimization when animating a text, to vastly improve performance at the expense of readability. Always set to Fixed to improve readability, set to Animated only when animating text. `TextRenderingMode`: this option controls font antialiasing settings. You have several options here: Aliased means to turn off antialiasing altogether. ClearType will enable the ClearType technology, which will employ full color antialiasing to the fonts. Grayscale will antialias fonts using grayscale only. Auto will try to guess the best setting for you.”
<
/td></tr><tr><td>

“[Why am I not getting keyboard input events when in full screen mode?](http://stackoverflow.com/questions/709019/why-am-i-not-getting-keyboard-input-events-when-in-full-screen-mode)”
<
/td><td>

“When a Silverlight plug-in is in full-screen mode, it disables most keyboard events. This limitation of keyboard input during full-screen mode is a security feature, and is intended to minimize the possibility of unintended information being entered by a user. In full-screen mode, the only input allowed is through the following keys. UP ARROW, DOWN ARROW, LEFT ARROW, RIGHT ARROW, SPACEBAR, TAB, PAGE UP, PAGE DOWN, HOME, END, ENTER…”
<
/td></tr><tr><td>

“[DomainDataSource Error Handling](http://jeffhandley.com/archive/2009/11/19/domaindatasource-error-handling-again.aspx)”
<
/td><td>

This Jeff Handley article is not about Telerik’s `RadDomainDataSource` but it did introduce me (probably) to the `SubmittedChanges` event.
<
/td></tr><tr><td>

“[Text Trimming in Silverlight 4](http://weblogs.asp.net/dwahlin/archive/2010/05/05/text-trimming-in-silverlight-4.aspx)”
<
/td><td>

“The `TextBlock` control contains a new property in Silverlight 4 called `TextTrimming` that can be used to add an ellipsis (…) to text that doesn’t fit into a specific area on the user interface.”
<
/td></tr><tr><td>

“[How can I share a VisualStateManager between two (or more) XAML files?](http://stackoverflow.com/questions/4367332/how-can-i-share-a-visualstatemanager-between-two-or-more-xaml-files)”
<
/td><td>

“The above appears possible within WPF however it is not possible in SL. As of current it does not appear the [ability] to reuse a Storyboard or `VisualState` is possible in SL. You should still be able to achieve what you are trying to do by encapsulating the `VisualStateManager` behavior within a style applied to a custom control. This would provide you the single point of failure you are looking for…”
<
/td></tr><tr><td>

“[Using the Visual Studio Async CTP with RIA Services](http://blogs.msdn.com/b/kylemc/archive/2010/11/02/using-the-visual-studio-async-ctp-with-ria-services.aspx)”
<
/td><td>

A 2010 introduction to RIA Services by Kyle McClellan.
<
/td></tr><tr><td>

“[Ensuring That Your Silverlight Applications Work with Silverlight 5](http://msdn.microsoft.com/en-us/library/hh397894(v=VS.95).aspx)”
<
/td><td>

Introduces Silverlight “quirks mode”…
<
/td></tr><tr><td>

“[Silverlight RIA Services and Basic, Anonymous Authentication](http://blog.virtual-olympus.com/blog/post/2010/12/12/Silverlight-RIA-Services-and-Basic-Anonymous-Authentication.aspx)”
<
/td><td>

I’m not sure that this one helped me use NTLM under Silverlight.
<
/td></tr><tr><td>

“[WCF Data Services vs. WCF RIA Services—Making the Right Choice](http://lennilobel.wordpress.com/2012/02/19/wcf-data-services-vs-wcf-ria-services-making-the-right-choice/)”
<
/td><td>

This article is actually from 2012.
<
/td></tr><tr><td>

“[WCF, Data Services and RIA Services Alignment Questions and Answers](http://blogs.msdn.com/b/endpoint/archive/2010/01/04/wcf-data-services-ria-services-alignment-questions-and-answers.aspx)”
<
/td><td>

Okay this one is from 2010.
<
/td></tr><tr><td>

“[Silverlight and WCF RIA Services (6–Validation)](http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2010/07/27/silverlight-and-wcf-ria-services-6-validation.aspx)”
<
/td><td>

“If I want to get validation problems for the ‘whole object’ displayed in the UI then (AFAIK) I need to have a binding that is interested in the ‘whole object’…”
<
/td></tr><tr><td>

“[RIA Services Validation: Using ValidationContext (Cross-Entity Validation)](http://jeffhandley.com/archive/2010/10/25/CrossEntityValidation.aspx)”
<
/td><td>

It helps (me) to point out that Jeff’s “cross-entity” validation example is confined to entities of the same type and does not include an asynchronous call to a server layer.
<
/td></tr><tr><td>

“[Understanding the Silverlight Dispatcher](http://stackoverflow.com/questions/2581647/understanding-the-silverlight-dispatcher)”
<
/td><td>

“If you use the MVVM light toolkit you could use the `DispatcherHelper` class in the `Galasoft.MvvmLight.Threading` namespace in the Extras `dll`. It checks the access and uses a static property for the dispatcher, similar to the `SmartDispatcher`.”
<
/td></tr><tr><td>

“[Custom Dependency Objects and Dependency Properties](http://msdn.microsoft.com/en-us/library/cc903933(v=vs.95).aspx)”
<
/td><td>

“When Should You Implement a Dependency Property? …You want the property to be settable in a style. …You want the property to be a property target that supports data binding. …You want the property to support an animated value, using the Silverlight animation system…”
<
/td></tr><tr><td>

“[Dependency Properties in XAML for Windows 8 Apps](http://www.informit.com/articles/article.aspx?p=1960912)”
<
/td><td>

More evidence that all this “dead” Silverlight stuff I’m learning here lives on in Windows 8 apps.
<
/td></tr><tr><td>

“[Common mistakes while using ObservableCollection](http://updatecontrols.net/doc/tips/common_mistakes_observablecollection)”
<
/td><td>

“A common misconception is that data binding [for collections] requires `ObservableCollection`. This is not true. Data binding works against anything that implements `IEnumerable`. You can data bind a list box directly to a List, if you want.”
<
/td></tr><tr><td>

“[Multiple-Selection ComboBox for Silverlight](http://www.codeproject.com/Articles/42133/Multiple-Selection-ComboBox-for-Silverlight)”
<
/td><td>

This sample has some ‘issues’: it uses `ItemContainerStyle` instead of `ItemTemplate` for binding to data; also, it provides no way to sync ticking the check box with selecting an item…
<
/td></tr><tr><td>

“[Rich Data Forms in Silverlight 4 Beta](http://www.wintellect.com/blogs/jlikness/rich-data-forms-in-silverlight-4-beta)”
<
/td><td>

“With support for `IDataErrorInfo` as well as `INotifyDataErrorInfo`, you no longer have to raise exceptions just to validate your classes.”
<
/td></tr><tr><td>

“[Inheritance in Data Models](http://msdn.microsoft.com/en-us/library/ee707366(v=vs.91).aspx)”
<
/td><td>

“On the root class, you must include in the `KnownTypeAttribute` attribute any of the derived types that you want to expose.”
<
/td></tr><tr><td>

“[DomainDataSource Filters and Parameters](http://jeffhandley.com/archive/2010/03/15/filters-parameters.aspx)”
<
/td><td>

The Telerik `RadDomainDataSource` uses similar filtering patterns to this Silverlight Toolkit control.
<
/td></tr><tr><td>

“[VS 2012 XML Design time error](http://mvvmlight.codeplex.com/workitem/7594)”
<
/td><td>

“When using this with VS 2012 I get this design time error: "The type 'EventToCommand' from assembly 'GalaSoft.MvvmLight.Extras.SL5' is built with an older version of the Blend SDK, and is not supported in a Silverlight 5 project." I installed the 4.0.23.4 package, but My assemblies are still versioned 4.0.23.35578....did I miss something?”
<
/td></tr></table>

@[BryanWilhite](https://twitter.com/BryanWilhite)
