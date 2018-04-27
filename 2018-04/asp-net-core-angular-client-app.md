# ASP.NET Core Angular Client App Q2 2018

The intention here is to examine how `dotnet new` templates “wire up” a Node.js-based Angular project with a Visual Studio project. This wiring appears to be handled by `JavaScriptServices` [[GitHub](https://github.com/aspnet/javascriptservices)] via the .NET Foundation.

In the Q2 2018 time frame, we have `Microsoft.DotNet.Web.Spa.ProjectTemplates` [[NuGet](https://www.nuget.org/packages/Microsoft.DotNet.Web.Spa.ProjectTemplates/)] or we have [this command](https://docs.microsoft.com/en-us/aspnet/core/spa/index?view=aspnetcore-2.1#installation):

```console
dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0
```

The assumption here is that any another `Spa` package from Microsoft is out of date or, worse, overlapping with what is aforementioned.

The `dotnet new angular -o my-new-app` command generates an ASP.NET Core project that for the first time respects the existence of the [Angular CLI](https://docs.microsoft.com/en-us/aspnet/core/spa/angular?view=aspnetcore-2.1&tabs=visual-studio#run-ng-commands) and improves the relationship between the Visual Studio project and Node.js.

## how the Visual Studio project is customized for Angular

A Visual Studio project—specifically the `*.csproj` file—is made up of a bunch of `PropertyGroup` and `ItemGroup` elements, punctuated with optional `Target` elements.

The `dotnet new` command for angular adds these elements to the first `PropertyGroup`:

* `SpaRoot`
* `DefaultItemExcludes`
* `BuildServerSideRenderer`

Following these declarations, is this `ItemGroup`:

```xml
<ItemGroup>
    <!-- Don't publish the SPA source files, but do show them in the project files list -->
    <Content Remove="$(SpaRoot)**" />
    <None Include="$(SpaRoot)**" Exclude="$(SpaRoot)node_modules\**" />
</ItemGroup>

```

Finally, two `Target` elements are declared:

* `<Target Name="DebugEnsureNodeEnv"…`
* `<Target Name="PublishRunWebpack"…`

## the `ClientApp` under the `SpaRoot`

The XML declarations in the `*.csproj` file make several references to the `SpaRoot` (single-page application root). The `SpaRoot` declaration refers to a folder called `ClientApp`:

```xml
<SpaRoot>ClientApp\</SpaRoot>
```

The `ClientApp` folder sits outside of (next to) the `\wwwroot` folder but the `IServiceCollection.AddSpaStaticFiles()` call generated in `Startup.cs` clearly states that `ClientApp/dist` folder will be exposed to the live server just like the conventions around `\wwwroot`.

The `<Target Name="PublishRunWebpack"…` declaration in `*.csproj` refers to `$(SpaRoot)dist\` (and `$(SpaRoot)dist-server\`) which leads back to `ClientApp/dist`.

This arrangement completely separates the contents of `ClientApp` from the rest of the Visual Studio “world” around it. The aforementioned `DefaultItemExcludes` declaration in `*.csproj` prevents Visual Studio from “reaching” into `ClientApp`:

```xml
<DefaultItemExcludes>$(DefaultItemExcludes);$(SpaRoot)node_modules\**</DefaultItemExcludes>
```