<h2>WPF Prism: Migrating from MEF to Unity</h2>

The Songhay System made historical, Desktop, investments in [Glenn Block’s MEF](https://www.hanselminutes.com/148/mef-managed-extensibility-framework-with-glenn-block) that must be converted over to Prism. This move is primarily under the influence of [Brian Lagunas](https://github.com/brianlagunas), his work on the open source manifestation of Prism. Lagunas made a simple, technical statement that I cannot ignore: [MEF is not an IoC container](http://stackoverflow.com/questions/216565/why-exactly-isnt-mef-a-di-ioc-container). Additionally, when you examine [the code samples for Prism 6.x](https://github.com/PrismLibrary/Prism-Samples-Wpf) we can see that MEF does not exist in the present of Prism (even though there is a ‘polite’ [NuGet package for MEF under Prism 6](https://www.nuget.org/packages/Prism.Mef/)). It must also be mentioned that the only MEF supporter I can see today is [Piotr Włodek](https://github.com/pwlodek). He is a powerhouse behind [MEFContrib](https://github.com/pwlodek/MefContrib) but I am not seeing .NET Core or .NET Standard teams _at Microsoft_ packing up MEF for a NuGet cross-platform future.

<h3>Migrating from `BiggestBox` to `StudioFloor`</h3>

You can see the results of this migration in [my `Songhay.StudioFloor` GitHub repo](https://github.com/BryanWilhite/Songhay.StudioFloor). This `StudioFloor` project is renamed from the `BiggestBox` project I had on CodePlex for several years.

<h3>Migration Step 0: Switch to .NET 4.6.1 for .NET Standard 1.4</h3>

My first step of migration has nothing to do with MEF. The .NET Standard initiative is relatively new compared to my MEF-era WPF work. The aggressively optimistic assumption here is that PCL will be replaced _entirely_ by .NET Standard. By staring at a chart via Immo Landwerth I saved [in a previous Blog post](http://songhayblog.azurewebsites.net/entry/songhay-studio-net-standard-with-songhay-standard-core), I can see that I need to start with .NET Standard 1.4 and look forward to .NET Standard 2.0. Version 1.4 supports the latest version of the Universal Windows Platform (UWP) and the UWP support is still a goal here in the Songhay System. This goal ‘forces’ the Songhay System to move from .NET 4.5.2 to 4.6.1.

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

<h3>Migration Step 3: Use `RegisterInstance()` in View-First, Shared-View-Model Scenarios</h3>