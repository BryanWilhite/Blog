<h2>WPF Prism: Migrating from MEF to Unity</h2>

The Songhay System made historical, Desktop, investments in [Glenn Block’s MEF](https://www.hanselminutes.com/148/mef-managed-extensibility-framework-with-glenn-block) that must be converted over to Prism. This move is primarily under the influence of [Brian Lagunas](https://github.com/brianlagunas), his work on the open source manifestation of Prism. Lagunas made a simple, technical statement that I cannot ignore: [MEF is not an IoC container](http://stackoverflow.com/questions/216565/why-exactly-isnt-mef-a-di-ioc-container). Additionally, when you examine [the code samples for Prism 6.x](https://github.com/PrismLibrary/Prism-Samples-Wpf) we can see that MEF does not exist in the present of Prism (even though there is a ‘polite’ [NuGet package for MEF under Prism 6](https://www.nuget.org/packages/Prism.Mef/)). It must also be mentioned that the only prominent MEF supporter I can see today is [Piotr Włodek](https://github.com/pwlodek). He is a powerhouse behind [MEFContrib](https://github.com/pwlodek/MefContrib) but I am not seeing .NET Core or .NET Standard teams _at Microsoft_ packing up MEF _in NuGet_ for a cross-platform future.

<a href="https://www.flickr.com/photos/wilhite/34415141695/in/dateposted-public/"><img src="https://farm3.staticflickr.com/2848/34415141695_8456bc59ef_m_d.jpg" style="float:right;margin:16px;" /></a>
(**Sidebar:** the [System.Composition 1.0.31 package](https://www.nuget.org/packages/System.Composition/) from Microsoft _is_ MEF in a NuGet package. However, crack open this package and you will find it kind of empty. [My screenshot shows](https://www.flickr.com/photos/wilhite/34415141695/in/dateposted-public/) that this package calls out to GAC dependencies which is an automation convenience but shows no sign of movement toward .NET Standard.)

<h3>Migrating from `BiggestBox` to `StudioFloor`</h3>

You can see the results of this migration in [my `Songhay.StudioFloor` GitHub repo](https://github.com/BryanWilhite/Songhay.StudioFloor). This `StudioFloor` project is renamed from the `BiggestBox` project I had on CodePlex for several years.

<h3>Migration Step 0: Switch to .NET 4.6.1 for .NET Standard 1.4</h3>

My first step of migration has nothing to do with MEF. The .NET Standard initiative is relatively new compared to my MEF-era WPF work. The aggressively optimistic assumption here is that PCL will be replaced _entirely_ by .NET Standard.

<div style="text-align:center">

<a href="https://twitter.com/migueldeicaza/status/853754791972962304"><img alt="Miguel de Icaza on .NET Standard 2.0" src="https://farm5.staticflickr.com/4185/33571835814_7cb660074d_o_d.png" /></a>

</div>

By staring at a chart via [Immo Landwerth](https://twitter.com/terrajobst) I saved [in a previous Blog post](http://songhayblog.azurewebsites.net/entry/songhay-studio-net-standard-with-songhay-standard-core), I can see that I need to start with .NET Standard 1.4 and look forward to .NET Standard 2.0. Version 1.4 supports the latest version of the Universal Windows Platform (UWP) and the UWP support is still a goal here in the Songhay System. This goal ‘forces’ the Songhay System to move from .NET 4.5.2 to 4.6.1.

<h3>Migration Step 1: Replace MEF `[Export]` Attributes for Non-Views with Unity Statements</h3>

The equivalent of the MEF `[Export(IFoo)]` declaration for type `Foo` is this statement:

``` C#

this._container.RegisterType<IFoo, Foo>(new ContainerControlledLifetimeManager());

```

It is important to use `ContainerControlledLifetimeManager` to match the static-ish nature of the `[Export]` attributes. This step applies to non-views, primarily Prism services and View-Model-first View models.

<h3>Migration Step 2: Replace MEF `[Export]` Attributes for Navigation Views with Prism Statement</h3>

With Unity in play, there is a need to register a view for navigation in `IModule.Initialize()`:

``` C#

this._container.RegisterTypeForNavigation<FooView>();

```

<h3>Migration Step 3: Use Prism XAML Declarations for View-First Patterns</h3>

This is this Prism XAML declarations for a View-first scenario:

``` XAML

<UserControl x:Class="MyApp.Views.FooView"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    xmlns:prism="http://prismlibrary.com/"
    prism:ViewModelLocator.AutoWireViewModel="True">

```

My experience informs me that there is no special Prism code needed in the View and the View Model to get this scenario working. This is where Unity has a clear, conventions-based advantage over MEF.

Now, there was a time when I preferred the C#-equivalent of this XAML declaration (stated in the constructor of the View):

``` C#

ViewModelLocator.SetAutoWireViewModel(this, true);

```

BTW: Brian Lagunas has written [a code sample to show how to change the default conventions](https://github.com/PrismLibrary/Prism-Samples-Wpf/blob/master/9-ChangeConvention/ViewModelLocator/Bootstrapper.cs) around `ViewModelLocator`.

<h3>Migration Step 4: Use the `GetInstance()` Anti-Pattern for View-Model-First Scenarios</h3>

Like an animal, [I have written `GetInstance()` extension methods](https://github.com/BryanWilhite/Songhay.Mvvm/blob/master/Songhay.Mvvm/Extensions/IViewExtensions.cs) intended to be used to a View that needs to find its View Model in the IoC container Microsoft calls `ServiceLocator.Current`. So, when the View Model (say `IFooViewModel`) is instanced first I make this statement in the constructor of the View:

``` C#

this.GetInstance<IFooViewModel>();

```

Sometimes several View models are grouped in the IoC container under one interface (say `IEditorViewModel`). I can now use `nameof` to get the right View-Model instance for the right View.


``` C#

this.GetInstance<IEditorViewModel>($"{nameof(FooView)}Model");

```

Or, to reduce performance for the sake of copy-and-paste, I have done this:


``` C#

this.GetInstance<IEditorViewModel>($"{this.GetType().Name}Model");

```

And yes, my `GetInstance()` extension methods are based on `ServiceLocator.Current.GetInstance()` which has been considered for years [an anti-pattern](http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/). It has also been considered for years [_not_ an anti-pattern](http://blog.gauffin.org/2012/09/service-locator-is-not-an-anti-pattern/).

My only concerns are these:

* Injecting something like `IUnityContainer` into the constructor of a WPF View to avoid using `ServiceLocator.Current.GetInstance()` should break the Visual Studio design-time experience which has been dependent on a parameter-less constructor in every View.

* My real-world experience with [strangulation](http://agilefromthegroundup.blogspot.com/2011/03/strangulation-pattern-of-choice-for.html) of some rather horrifying WPF applications absolutely requires the use of this anti-pattern when I use Prism to run legacy crap next to the new crap.