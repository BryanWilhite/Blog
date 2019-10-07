---json
{
  "author": "Bryan Wilhite",
  "content": "I had to learn one very, very important thing about the software development business: green-field skills are far less valuable than brown-field skills. In the green field there are a finite number of ways to build a software solution “correctly” (accord...",
  "inceptDate": "2013-12-26T00:00:00",
  "isPublished": true,
  "slug": "the-fat-getter-and-other-mvvm-anti-patterns",
  "title": "The Fat-Getter and other MVVM Anti-Patterns"
}
---

I had to learn one very, very important thing about the software development business: green-field skills are far less valuable than brown-field skills. In the green field there are a *finite* number of ways to build a software solution “correctly” (according to widely accepted patterns and practices). However, in the brown field, there are an *infinite* number of ways of build incorrectly—it follows that brown-field skills center upon the ability to quickly see into the infinite and develop a strategy to undo what was incorrectly done *and still* add new enhancements to the solution. I do *not* have this talent. The best I can do is write down a few scraps dragged out of the bottomless pit gaping in the shadows of <acronym title="Extensible Application Markup Language">XAML</acronym>-based, <acronym title="Model">MVVM</acronym> design.

## The Fat-Getter in View Model Properties

*Do* trust the XAML binding subsystem to display the *pre-calculated contents* of your encapsulated fields. *Do not* unintentionally expect the XAML binding subsystem to call a long-running operation in your code.

By convention, the MVVM pattern expects us to bind to the public properties of a View Model. A Property has a getter and a setter. A ‘fat getter’ is one that calls a long-running operation:

    public long MyNumericProperty
    {
        get
        {
            this._myNumericProperty = this.MyLongRunningOperation();
            return this._myNumericProperty;
        }
        set { throw new NotImplementedException(); }
    }

When we bind to `MyNumericProperty` in XAML, a call to `MyLongRunningOperation()` will execute every time the binding subsystem decides to read from `MyNumericProperty`. This sort business going on in a grid with hundreds of rows can bring an application to its knees!

## Calls to RaisePropertyChanged()Leaking out of Setters

In our terrifying code sample above we can see that `MyNumericProperty` has a fat getter and essentially no setter. When a programmer new to (or unconcerned with) MVVM runs into this corner, he can get out of this mess by calling `RaisePropertyChanged("MyNumericProperty")` throughout the View Model, outside of the definition of the Property. In my opinion, this effectively makes the mess worse: *Do not* unintentionally expect the XAML binding subsystem to call a long-running operation in your code.

My years of experience with building XAML applications saw *no* need for calling `RaisePropertyChanged()` outside of its setter. This means that my bind-able properties always look like this:

    public long MyNumericProperty
    {
        get { return this._myNumericProperty; }
        set
        {
            this._myNumericProperty = value;
            base.
    RaisePropertyChanged("MyNumericProperty")
        }
    }

This implies that in order to call `RaisePropertyChanged("MyNumericProperty")` I have to set its corresponding property explicitly. It also follows that any calls to `MyLongRunningOperation()` have to be clearly defined in the right space (and time) in the View Model. These self-imposed constraints demand that `RaisePropertyChanged("MyNumericProperty")` be called only once but we may see lines like the following several times:

    this.MyNumericProperty = this.MyLongRunningOperation();

These lines are placed in the following View Model locations:

*   In the `base.PropertyChanged` handler defined in a base, MVVM View Model. This is effectively updating a property based on the change of another property.
*   In a handler for an aggregated event (Prism) or messenger (MVVM Light).
*   In a commanding handler, implementing `ICommand`.
*   In a handler for a `DomainDataSource.SubmittedChanges` event (RIA Services).
*   In an element handler for an observable sequence (`IObservable&lt;T&gt;.Subscribe&lt;T&gt;()`).

Knowing where (and when) to update data is both a science and an art. It is quite tragic when anti-patterns prevent such glorious exploration.

## No Discipline around Using a Base View Model Class

[<img alt="Amazon.com product" src="http://ecx.images-amazon.com/images/I/41ZkmDaQ%2BbL.jpg" style="float:right;margin:16px;">](http://www.amazon.com/exec/obidos/ASIN/B0038KX9FW/thekintespacec00A/ "Buy this product at Amazon.com!")

Notice how I fully-qualified the <acronym title="Object Oriented Programming">OOP</acronym> inheritance of members `base.RaisePropertyChanged` and `base.PropertyChanged`. This denotes that there is a base View Model class used by all domain-specific View Models in the application. This also strongly suggests that this base View Model in concerned with implementing `INotifyPropertyChanged`. What I am writing here seems obvious to any student of MVVM, learning from the classic 2009 <acronym title="Microsoft Developer Network">MSDN</acronym>[article](http://msdn.microsoft.com/en-us/magazine/dd419663.aspx) by Josh Smith. But, for those who are new to (or unconcerned with) MVVM, this use of a single base class explicitly concerned with MVVM may seem strange. We get such a base class for free in frameworks like [MVVM Light](http://www.galasoft.ch/mvvm/) and [Prism](http://msdn.microsoft.com/en-us/library/ff648465.aspx).

## No Discipline around Centralizing/Grouping View Model Logic into Extension Methods

One advantage of using a base View Model is the development of an entry point through which the [Open/closed Principle](http://en.wikipedia.org/wiki/Open/closed_principle)—coupled with the [DRY principle](http://en.wikipedia.org/wiki/Don't_repeat_yourself)—can be intentionally expressed. When a programmer becomes a master of deadlines often the DRY principle is sacrificed and we see the same code repeated again and again across View Models through the magic of copy-and-paste (sadly, working with XAML views kind of encourages this). Using extension methods for a base View Model discourages such a violent thrust into the realm of difficult to maintain code.

In addition to using extension methods for a base View Model, here are some other sources:

*   Extension methods for `DependencyObject` and/or `FrameworkElement` can be used to centralize event-aggregation or messaging-related procedures—it can keep View-level code ‘clean’ with regard to the particular intra-application messaging system in use.
*   Extension methods for `Client.Entity` and `ComplexObject` (RIA services).
*   Extension methods for `object` is a catch-all for domain-specific procedures.

## Overuse of Event Aggregation and/or Messaging

My very short 4/2013 article “[Inter-View-Model Communication](http://songhayblog.azurewebsites.net/Entry/Show/inter-view-model-communication)” was a self-critique about my overuse of MVVM Light messaging (which leads to some alternative extension methods exploiting `Microsoft.Practices.ServiceLocation.ServiceLocator`). In the world of Prism, I suspect the overuse of event aggregation when I see ‘too many’ event “payload” data types. This is of course a matter of opinion and, as Steve Jobs said, “Taste.”

## Failing to Design View Model Classes to be Partial Classes

The ‘failure’ to design View Model classes to be partial classes is also a matter of taste. Whenever I work with an MVVM-based project I intend to confine my View Models to these concerns:

*   Commanding
*   Eventing
*   Messaging
*   Timing (simple animations/timings using `DispatcherTimer`)
*   XAML Binding (with public, View-Model properties)
*   Design-time XAML Binding

For the sake of maintainability, each of these concerns can become a partial class of the View Model. When I see a View Model class definition file exceeding 500 lines of code, I see an opportunity to reorganize the class into its concerns and use partial classes.

## Eagerly Disregarding Design-Time Concerns

Sadly, it is very, *very* easy to find seasoned XAML developers that proudly don’t give a damn about the design-time presentation of their work in Visual Studio. Two comments around this pop out to me, “We don’t use Expression Blend…” and “I write my XAML by hand so I don’t need to see a visual layout.” The first comment is admission of poverty and limited vision (usually wrapped in airs of frugal humility). The second comment is saying, “I press Ctrl-F5 and wait at least three seconds to see the visual design of my XAML—sometimes I do this over 100 times a day. That’s only five minutes of lost productivity *for me*.”

What that last comment reveals is a lack of concern for others working with the XAML apart from the original developer of the XAML. No matter how experienced a second (or third) developer is with writing XAML by hand, it will be difficult to quickly *see* what needs to be modified in any XAML layout of reasonable complexity.

## Code Is Not Testable

One of the foundational reasons to use MVVM is to have testable code. No “clean separation” between the Model and the View Model is one surefire way to make UI code not testable. There is no MVVM-specific technique that guarantees testable code. Having testable code is a general “design pattern” topic that is beyond the scope of my MVVM anti-patterns. Whenever I see a XAML project that has no unit tests whatsoever, I cringe and wait for the inevitable pig-farm slop to fall on me! In the very least there should be data access/manipulation tests…

## Related Resources

<table class="WordWalkingStickTable"><tr><td>

“[Automatically implementing INotifyPropertyChanged](http://www.postsharp.net/model/inotifypropertychanged)”
</td><td>

“Binding objects to the UI is a large and tedious task. You must implement `INotifyPropertyChanged` on every property that needs to be bound. You need to ensure that the underlying property getter correctly raises events so that the View knows that changes have occurred. The larger your codebase, the more work there is.”
</td></tr><tr><td>

“[Writing a Testable Presentation Layer with MVVM](http://msdn.microsoft.com/en-us/magazine/dn463790.aspx)”
</td><td>

“If you want to write a testable application, it really helps to plan ahead. You’ll want to design your application’s architecture so it’s conducive to unit testing. Static methods, sealed classes, database access, and Web service calls all can make your app difficult or impossible to unit test.”
</td></tr><tr><td>

“[Maximizing the Visual Designer’s Usage with Design-Time Data](http://msdn.microsoft.com/en-us/magazine/dn169081.aspx)”
</td><td>

“The design-time `DataService` is cleanly separated from the rest of the code, in its own source file, and, as you’ll see a little later in this article, you can exclude this source file from the Release build of your application.”
</td></tr><tr><td>

“[MVVM Reference Implementation [Prism]](http://msdn.microsoft.com/en-us/library/gg405492(v=pandp.40).aspx)”
</td><td>

“Because MEF is being used to import the view models (parts), parameters (such as context) cannot be passed. If you need to pass state for an object that will be created by MEF, you need to set the value for the current state for the type of the context object.”
</td></tr><tr><td>

[EasyNetQ](http://easynetq.com/)
</td><td>

“Watch the author, Mike Hadlow, giving a [demo of EasyNetQ at QCon London](http://www.infoq.com/presentations/RabbitMQ-NET-EasyNetQ). And listen to Mike talking about EasyNetQ on [Dot Net Rocks](http://www.dotnetrocks.com/default.aspx?ShowNum=848).”
</td></tr><tr><td>

“[MVVM Multiselect Listbox](http://www.gbogea.com/2010/01/02/mvvm-multiselect-listbox)”
</td><td>

This design by Gabriel Perez should work better than a similar control I built in 2012 because is features `SelectionItem&lt;T&gt;`—a powerful use of generics.
</td></tr><tr><td>

“[Wiring up View and Viewmodel in MVVM and Silverlight 4](http://blog.roboblob.com/2010/01/17/wiring-up-view-and-viewmodel-in-mvvm-and-silverlight-4-blendability-included/)”
</td><td>

“In MVVMLight `ViewModelLocator` is [usually] defined in `App.Xaml.cs` as global resource (and therefore created on application startup). Also design-time and runtime versions of `ViewModel `instances in `ViewModelClass` are defined as static properties and therefore also created when `ViewModelLocator` class is first used. Also those static `ViewModels` are then shared between multiple views which is in my opinion simply wrong.”
</td></tr><tr><td>

“[WPF, Model-View-ViewModel (MVVM), MEF and other Acronyms](http://consultingblogs.emc.com/davidwynne/archive/2009/05/22/wpf-model-view-viewmodel-mvvm-mef-and-other-acronyms.aspx)”
</td><td>

“We wanted to have more or less the same execution, but with MEF pulling the strings. We wanted to be able to set the DataContext of a View in its XAML so Resharper can resolve it and give you IntelliSense to the associated ViewModel in XAML which is really handy. We were also quite keen to try and get rid of the ServiceLocater class if possible, which is basically continually growing boiler plate code.”
</td></tr><tr><td>

“[[Asynchronous] MVVM… Stop the Dreaded Dead GUI Problem in WPF7](http://www.codeproject.com/Articles/123183/Asynchronus-MVVM-Stop-the-Dreaded-Dead-GUI-Problem)”
</td><td>

I’m pretty sure this article was written before `Task&lt;T&gt;` was generally available.
</td></tr><tr><td>

“[NuGet packages for Mvvm Light](http://insomniacgeek.com/nuget-packages-for-mvvm-light/)”
</td><td>

I did have a issues with MVVM Light moving from SL4 to SL5.
</td></tr><tr><td>

“[How to Disable silverlight configuration dialog which appears on right click in a MVVM silverlight 4.0 application.](http://www.codeproject.com/KB/silverlight/DisableSilverlightContext.aspx)”
</td><td>

“The solution presented in this article uses the right click event handler exposed in the silverlight 4 version and will not work in the previous versions of the silverlight. The solution is to add an event handler to the mouse right button down event in the application startup method.In the event handler we set the ishandled property to true.This essentially prevents the event from bubbling up all the way to the silverlight plugin.”
</td></tr><tr><td>

“[WPF Validation with Attributes and IDataErrorInfo interface in MVVM](http://weblogs.asp.net/marianor/archive/2009/04/17/wpf-validation-with-attributes-and-idataerrorinfo-interface-in-mvvm.aspx)”
</td><td>

“WPF provides validation infrastructure for binding scenarios through `IDataErrorInfo `interface. Basically you have to implement the `Item[columnName]` property putting the validation logic for each property in your Model (or `ModelView`) requiring validation. From XAML you need to set `ValidatesOnDataErrors` to true and decide when you want the binding invoke the validation logic (through `UpdateSourceTrigger`).”
</td></tr><tr><td>

“[Walkthrough: Consuming OData with MVVM for Windows Phone](http://msdn.microsoft.com/en-us/library/windowsphone/develop/hh394007(v=vs.105).aspx)”
</td><td>

I thought this was of interest in 2011.
</td></tr><tr><td>

“[Unit Testable WCF Web Services in MVVM and Silverlight 4](http://blog.roboblob.com/2010/04/11/unit-testable-wcf-web-services-in-mvvm-and-silverlight-4/)”
</td><td>

Another 2011 thing of interest.
</td></tr><tr><td>

“[UpdateSourceTrigger Enumeration](http://msdn.microsoft.com/en-us/library/system.windows.data.updatesourcetrigger(v=vs.110).aspx)”
</td><td>

“The default `UpdateSourceTrigger` value of the binding target property. The default value for most dependency properties is `PropertyChanged`, while the [Text](http://msdn.microsoft.com/en-us/library/system.windows.controls.textbox.text(v=vs.110).aspx) property has a default value of `LostFocus`.”
</td></tr><tr><td>

“[Using CollectionViewSource in MVVM](http://social.msdn.microsoft.com/Forums/silverlight/en-US/29699048-3ecb-407e-a28c-cd826024fbb2/using-collectionviewsource-in-mvvm?forum=silverlightcontrols)”
</td><td>

This thread shows a sample that uses `CollectionViewSource` to wrap `ObservableCollection&lt;T&gt;`.
</td></tr><tr><td>

“[CollectionViewSource is crazy useful for binding to filtered Observable Collections on Windows Phone 8](http://www.hanselman.com/blog/CollectionViewSourceIsCrazyUsefulForBindingToFilteredObservableCollectionsOnWindowsPhone8.aspx)”
</td><td>

“Turns out, though, that WPF folks have been using this for YEARS. Here’s [Beth Massi talking about CollectionViewSource in 2008](http://blogs.msdn.com/b/bethmassi/archive/2008/11/07/loading-data-and-binding-controls-in-wpf-with-collectionviewsource.aspx), for crying out loud (as I discover it a half-decade later on the phone.)”
</td></tr><tr><td>

“[Deferring ListCollectionView filter updates for a responsive UI](http://www.codeproject.com/Articles/32426/Deferring-ListCollectionView-filter-updates-for-a)”
</td><td>

“The solution presented here is to defer updates to the `Filterproperty` until the user has likely finished typing. The trick is to find a simple way to guess when this is.”
</td></tr></table>
