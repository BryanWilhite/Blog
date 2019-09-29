---json
{
  "author": "@BryanWilhite",
  "content": "The Songhay System made historical, Desktop, investments in Glenn Block’s MEF that must be converted over to Prism. This move is primarily under the influence of Brian Lagunas, his work on the open source manifestation of Prism. Lagunas made a simple, te...",
  "inceptDate": "2017-05-02T13:35:16.4735938-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "wpf-prism-migrating-from-mef-to-unity",
  "sortOrdinal": 0,
  "tag": null,
  "title": "WPF Prism: Migrating from MEF to Unity"
}
---

The Songhay System made historical, Desktop, investments in [Glenn Block’s MEF](https://www.hanselminutes.com/148/mef-managed-extensibility-framework-with-glenn-block) that must be converted over to Prism. This move is primarily under the influence of [Brian Lagunas](https://github.com/brianlagunas), his work on the open source manifestation of Prism. Lagunas made a simple, technical statement that I cannot ignore: [MEF is not an IoC container](http://stackoverflow.com/questions/216565/why-exactly-isnt-mef-a-di-ioc-container). Additionally, when you examine [the code samples for Prism 6.x](https://github.com/PrismLibrary/Prism-Samples-Wpf) we can see that MEF does not exist in the present of Prism (even though there is a ‘polite’ [NuGet package for MEF under Prism 6](https://www.nuget.org/packages/Prism.Mef/)). It must also be mentioned that the only prominent MEF supporter I can see today is [Piotr Włodek](https://github.com/pwlodek). He is a powerhouse behind [MEFContrib](https://github.com/pwlodek/MefContrib) but I am not seeing .NET Core or .NET Standard teams *at Microsoft* packing up MEF *in NuGet* for a cross-platform future.

[<img src="https://farm3.staticflickr.com/2848/34415141695_8456bc59ef_m_d.jpg" style="float:right;margin:16px;">](https://www.flickr.com/photos/wilhite/34415141695/in/dateposted-public/) (**Sidebar:** the [System.Composition 1.0.31 package](https://www.nuget.org/packages/System.Composition/) from Microsoft *is* MEF in a NuGet package. However, crack open this package and you will find it kind of empty. [My screenshot shows](https://www.flickr.com/photos/wilhite/34415141695/in/dateposted-public/) that this package calls out to GAC dependencies which is an automation convenience but shows no sign of movement toward .NET Standard.) 

### Migrating from `BiggestBox` to `StudioFloor`

You can see the results of this migration in [my `Songhay.StudioFloor` GitHub repo](https://github.com/BryanWilhite/Songhay.StudioFloor). This `StudioFloor` project is renamed from the `BiggestBox` project I had on CodePlex for several years.

### Migration Step 0: Switch to .NET 4.6.1 for .NET Standard 1.4

My first step of migration has nothing to do with MEF. The .NET Standard initiative is relatively new compared to my MEF-era WPF work. The aggressively optimistic assumption here is that PCL will be replaced *entirely* by .NET Standard.
<div style="text-align:center">[<img alt="Miguel de Icaza on .NET Standard 2.0" src="https://farm5.staticflickr.com/4185/33571835814_7cb660074d_o_d.png">](https://twitter.com/migueldeicaza/status/853754791972962304)</div>

By staring at a chart via [Immo Landwerth](https://twitter.com/terrajobst) I saved [in a previous Blog post](http://songhayblog.azurewebsites.net/entry/songhay-studio-net-standard-with-songhay-standard-core), I can see that I need to start with .NET Standard 1.4 and look forward to .NET Standard 2.0. Version 1.4 supports the latest version of the Universal Windows Platform (UWP) and the UWP support is still a goal here in the Songhay System. This goal ‘forces’ the Songhay System to move from .NET 4.5.2 to 4.6.1.

### Migration Step 1: Replace MEF `[Export]` Attributes for Non-Views with Unity Statements

The equivalent of the MEF `[Export(IFoo)]` declaration for type `Foo` is this statement:

<code class="lang-C#">
this._container.RegisterType&lt;IFoo, Foo&gt;(new ContainerControlledLifetimeManager());
</code>

It is important to use `ContainerControlledLifetimeManager` to match the static-ish nature of the `[Export]` attributes. This step applies to non-views, primarily Prism services and View-Model-first View models.

### Migration Step 2: Replace MEF `[Export]` Attributes for Navigation Views with Prism Statement

With Unity in play, there is a need to register a view for navigation in `IModule.Initialize()`:

<code class="lang-C#">
this._container.RegisterTypeForNavigation&lt;FooView&gt;();
</code>

### Migration Step 3: Use Prism XAML Declarations for View-First Patterns

This is this Prism XAML declarations for a View-first scenario:

<code class="lang-XAML">
&lt;UserControl x:Class="MyApp.Views.FooView"
    x…mlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    x…mlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x…mlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    x…mlns:prism="http://prismlibrary.com/"
    prism:ViewModelLocator.AutoWireViewModel="True"&gt;
</code>

My experience informs me that there is no special Prism code needed in the View and the View Model to get this scenario working. This is where Unity has a clear, conventions-based advantage over MEF.

Now, there was a time when I preferred the C#-equivalent of this XAML declaration (stated in the constructor of the View):

<code class="lang-C#">
ViewModelLocator.SetAutoWireViewModel(this, true);
</code>

BTW: Brian Lagunas has written [a code sample to show how to change the default conventions](https://github.com/PrismLibrary/Prism-Samples-Wpf/blob/master/9-ChangeConvention/ViewModelLocator/Bootstrapper.cs) around `ViewModelLocator`.

### Migration Step 4: Use the `GetInstance()` Anti-Pattern for View-Model-First Scenarios

Like an animal, [I have written `GetInstance()` extension methods](https://github.com/BryanWilhite/Songhay.Mvvm/blob/master/Songhay.Mvvm/Extensions/IViewExtensions.cs) intended to be used to a View that needs to find its View Model in the IoC container Microsoft calls `ServiceLocator.Current`. So, when the View Model (say `IFooViewModel`) is instanced first I make this statement in the constructor of the View:

<code class="lang-C#">
this.GetInstance&lt;IFooViewModel&gt;();
</code>

Sometimes several View models are grouped in the IoC container under one interface (say `IEditorViewModel`). I can now use `nameof` to get the right View-Model instance for the right View.

<code class="lang-C#">
this.GetInstance&lt;IEditorViewModel&gt;($"{nameof(FooView)}Model");
</code>

Or, to reduce performance for the sake of copy-and-paste, I have done this:

<code class="lang-C#">
this.GetInstance&lt;IEditorViewModel&gt;($"{this.GetType().Name}Model");
</code>

And yes, my `GetInstance()` extension methods are based on `ServiceLocator.Current.GetInstance()` which has been considered for years [an anti-pattern](http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/). It has also been considered for years [*not* an anti-pattern](http://blog.gauffin.org/2012/09/service-locator-is-not-an-anti-pattern/).

My only concerns are these:

*   

Injecting something like `IUnityContainer` into the constructor of a WPF View to avoid using `ServiceLocator.Current.GetInstance()` should break the Visual Studio design-time experience which has been dependent on a parameter-less constructor in every View.

*   

My real-world experience with [strangulation](http://agilefromthegroundup.blogspot.com/2011/03/strangulation-pattern-of-choice-for.html) of some rather horrifying WPF applications absolutely requires the use of this anti-pattern when I use Prism to run legacy crap next to the new crap.
