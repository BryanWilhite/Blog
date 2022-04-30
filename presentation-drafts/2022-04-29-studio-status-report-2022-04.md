---json
{
  "documentId": 0,
  "title": "studio status report: 2022-04",
  "documentShortName": "2022-04-29-studio-status-report-2022-04",
  "fileName": "index.html",
  "path": "./entry/2022-04-29-studio-status-report-2022-04",
  "date": "2022-04-30T01:04:23.409Z",
  "modificationDate": "2022-04-30T01:04:23.409Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-04-29-studio-status-report-2022-04",
  "tag": "{\r\n  \"extract\": \"month 4 of 2022 was about the greatest weakness of Blazor and more day-job learnings There are no more known technical blockers in the way of completing the  project associated with new version of SonghaySystem.com. This is great news! However, the unders…\"\r\n}"
}
---

# studio status report: 2022-04

## month 4 of 2022 was about the greatest weakness of Blazor and more day-job learnings

There are no more known _technical_ blockers in the way of completing the  [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com. This is great news! However, the underside of this news is my discovery of the greatest weakness (to me) of Blazor: [Blazor only has one thread](https://github.com/dotnet/aspnetcore/issues/14253#issuecomment-534118256) even though [WebAssembly has more](https://web.dev/webassembly-threads/).

As of seven days ago, [Dan Roth is optimistic](https://github.com/dotnet/aspnetcore/issues/17730#issuecomment-1106583704) that Blazor will support multi-threading in a near-future release. This should prevent me from looking into things like BlazorWorker [[GitHub](https://github.com/Tewr/BlazorWorker)].

This threading weakness makes me write Bolero code like this:

```fsharp
on.click (fun _ ->
    if model.YtSetIndex.IsNone && model.YtSet.IsNone then
        YouTubeMessage.CallYtIndexAndSet |> dispatch
    else
        YouTubeMessage.OpenYtSetOverlay |> dispatch)
```

What this `click` handler is trying to say is that Blazor cannot handle playing a CSS animation, opening an overlay, and retrieve cached data near-simultaneously. Before the data is cached, `model.YtSetIndex.IsNone` and `model.YtSet.IsNone` are both `true` and this click handler is gambling that it will take at least one second to retrieve the data remotely. Why one second? That is the duration of my CSS animation. When I am wrong about the one-second data-retrieval floor, then Blazor innards will block the CSS animation.

### day-job learning?

Yes, I have a new day-job after quitting the old one last month. Of course we all say this but for me it is true: this new job is better than the last one. It has allowed me to revisit _validation_ which is the bread and butter of full-stack forms building. Enter FluentValidation [[GitHub](https://github.com/FluentValidation/FluentValidation)].

The ‘horrible’ truth about the built-in system featuring `System.ComponentModel.DataAnnotations.ValidationContext` [📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationcontext?view=net-6.0)] starts with its `ObjectInstance` property (which is boxed as `object`). this property effectively associates any Validation Results with the object they come from. This implies that there one Validation Context per validation. It follows that recursively validating child objects (or collections of child objects) is not supported.

The response to issue [#1133](https://github.com/FluentValidation/FluentValidation/issues/1133) introduces FluentValidation [[GitHub](https://github.com/FluentValidation/FluentValidation)] to me as the solution to this limitation:

```csharp
public class ProductValidator : AbstractValidator<Product> {
   public ProductValidator() {
      RuleForEach(x => x.ProductVariants).SetValidator(new ProductVariantValidator());
   }
}

public class ProductVariantValidator : AbstractValidator<ProductVariant> {
  public ProductVariantValidator() {
     RuleForEach(x => x.Prices).SetValidator(new PriceValidator());
  }
}

public class PriceValidator : AbstractValidator<Price> {
   public PriceValidator() {
      RuleFor(x => x.Price).GreaterThan(0);
   }
}
```

`RuleForEach` coupled with `SetValidator` in FluentValidation [is documented](https://docs.fluentvalidation.net/en/latest/collections.html#collections-of-complex-types).

For more background on the limitations of default .NET validation, see “[Recursive Validation Using DataAnnotations](http://www.technofattie.com/2011/10/05/recursive-validation-using-dataannotations.html).”

### to avoid validation, use change tracking

I admit that I am a bit embarrassed to have taken so so long to take FluentValidation seriously which implies that I never thought about the problem of recursive validation in depth for _years_—what kind of day jobs was I working? (The kind of day jobs with too much legacy code with legacy problems in the way of working something relatively new.)

After FluentValidation is taken seriously, my next serious move is toward Compare-Net-Objects [[GitHub](https://github.com/GregFinzer/Compare-Net-Objects)]. How did I stay alive so long without this thing! When validation is considered a performance issue then it can be avoided by verifying that the object is unchanged when compared to its last-saved version. Compare-Net-Objects works well in this scenario and is my lightweight answer to a full-blown change tracking system like the one I have enjoyed in years past in Entity Framework.

## selected month 04 Studio notes

### Change-tracking in .NET

- The `IChangeTracking` Component Model interface is foundational in .NET [📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.ichangetracking?view=net-6.0)].
- `IRevertibleChangeTracking` extends `IChangeTracking` by adding support for rolling back the changes [📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.irevertiblechangetracking?view=net-6.0)].
- Entity Framework has its own [change tracking](https://docs.microsoft.com/en-us/ef/core/change-tracking/) subsystem.
- TrackerDog [[GitHub](https://github.com/mfidemraizer/trackerdog)] depends on declaring all public properties as `virtual` [📖 [docs](http://mfidemraizer.github.io/trackerdog/html/52e40f26-3dfe-47e0-adf1-09233e98f42e.htm#objects2trackable)]. This project has not been touched for years.
- ChangeTracking [[GitHub](https://github.com/joelweiss/ChangeTracking)] also depends on `public virtual` properties but has been touched more recently than TrackerDog.
- `PropertyChanged.Fody` [[GitHub](https://github.com/Fody/PropertyChanged)] depends on implementing `INotifyPropertyChanged`.
- `PropertyChanging.Fody` [[GitHub](https://github.com/Fody/PropertyChanging)] depends on implementing `INotifyPropertyChanging` [📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanging?redirectedfrom=MSDN&view=net-6.0)].
- TrackChange [[GitHub](https://github.com/jrt324/TrackChange)] is built on top of Fody and only requires the attribute, `[Tracking]`.

>You can also implement a change tracker to keep track of everything for more complex scenarios. The change tracker might have a list of the changes—listing property names, values, and timestamps as needed—internally. You can than query this list for the information you need. Think of something like the [[Event Sourcing](https://martinfowler.com/eaaDev/EventSourcing.html)] pattern.
>
><https://stackoverflow.com/a/57492261/22944>

### I will need AutoMapper primarily for tests

[AutoMapper](https://docs.automapper.org/en/latest/index.html) supports cloning: <https://stackoverflow.com/a/34279923/22944>

### Bogus is a simple fake data generator for .NET

Bogus [GitHub](https://github.com/bchavez/Bogus) is unit-test companion for shipping code with validation logic. By the way, I did have the day-job opportunity to compare Bogus to [AutoFixture](https://autofixture.github.io/). The only advantage AutoFixture has over Bogus is its ability to generate random data by default. Bogus requires a rules engine to generate anything but this is better out of the box than what AutoFixture presents because the rules work well with validation unit tests.

Once AutoBogus [[GitHub](https://github.com/nickdodd79/AutoBogus)] is coupled with Bogus then I am pretty much set.

## roll up of my .NET forms-building tools

When the day-job folks turn down some third-party vertical like [Forms.io](https://forms.io/), then I will immediately need these:

| package name | Nuget URI | GitHub URI
|- |- |-
| FluentValidation | <https://nuget.org/packages/FluentValidation> | <https://github.com/FluentValidation/FluentValidation> |
| FluentValidation.AspNetCore | <https://nuget.org/packages/FluentValidation.AspNetCore> | <https://github.com/FluentValidation/FluentValidation> |
| Compare-Net-Objects | <https://www.nuget.org/packages/CompareNETObjects> | <https://github.com/GregFinzer/Compare-Net-Objects> |
| Bogus | <https://www.nuget.org/packages/Bogus/> | <https://github.com/bchavez/Bogus> |
| AutoBogus | <https://www.nuget.org/packages/AutoBogus/> | <https://github.com/nickdodd79/AutoBogus> |
| AutoMapper | <https://www.nuget.org/packages/AutoMapper/> | <https://github.com/AutoMapper/AutoMapper> |

## sketching out a development schedule (revision 20)

The schedule of the month:

- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com 📜🚜🔨
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
