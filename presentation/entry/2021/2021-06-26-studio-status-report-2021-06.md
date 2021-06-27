---json
{
  "documentId": 0,
  "title": "studio status report: 2021-06",
  "documentShortName": "2021-06-26-studio-status-report-2021-06",
  "fileName": "index.html",
  "path": "./entry/2021-06-26-studio-status-report-2021-06",
  "date": "2021-06-26T23:34:45.938Z",
  "modificationDate": "2021-06-26T23:34:45.938Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-06-26-studio-status-report-2021-06",
  "tag": "{\n  \"extract\": \"month 06 of 2021 was about bringing b-roll Activities to center stage Month 06 saw two releases of SonghayCore 📦, 5.2.0 and 5.2.1. These releases were about absorbing studio-wide patterns mostly from Songhay.Player (the b-roll player), advancing IActivit…\"\n}"
}
---

# studio status report: 2021-06

## month 06 of 2021 was about bringing b-roll Activities to center stage

Month 06 saw two releases of `SonghayCore` 📦, [5.2.0](https://www.nuget.org/packages/SonghayCore/5.2.0) and [5.2.1](https://www.nuget.org/packages/SonghayCore/5.2.1). These releases were about absorbing studio-wide patterns mostly from `Songhay.Player` (the b-roll player), advancing `IActivity` concerns and putting the finishing touches on the new [Azure Storage REST API](https://docs.microsoft.com/en-us/rest/api/storageservices/) support introduced last month.

### the `IActivity` subset of `SonghayCore`

The following table will summarize the `IActivity`-related types in `SonghayCore`, indicating recent changes:

| name | remarks |
|- |-
| `IActivity` | Defines an Activity with `ProgramArgs` input. |
| `IActivityConfigurationSupport` | Adds `IConfigurationRoot` [📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfigurationroot?view=dotnet-plat-ext-5.0)] support to an Activity. |
| `IActivityWithOutput<TInput, TOutput>` | Extends `IActivity` with synchronous I/O. ✨ See issue [#122](https://github.com/BryanWilhite/SonghayCore/issues/122). |
| `IActivityWithTask` | Extends `IActivity` with asynchronous invocation. |
| `IActivityWithTask<TInput>` | Extends `IActivity` with asynchronous invocation, accepting input. |
| `IActivityWithTaskOutput<TOutput>` | Extends `IActivity` with asynchronous invocation, returning output. |
| `IActivityWithTask<TInput, TOutput>` | Extends `IActivity` with asynchronous invocation, accepting input and returning output. |
| `ActivitiesGetter` | Defines the in-memory storage and getting of `IActivity` types. |
| `ActivityOutput` | Defines the conventional output of `IActivityWithTask` types. |
| `IActivityExtensions` | Extensions of `IActivity`. ✨ See issue [#120](https://github.com/BryanWilhite/SonghayCore/issues/120). |
| `ProgramArgs` | Defines conventional command-line arguments. ✨ See issues [#121](https://github.com/BryanWilhite/SonghayCore/issues/121) and [#123](https://github.com/BryanWilhite/SonghayCore/issues/123). |

### Azure Storage REST API support in `SonghayCore`

Issues [#118](https://github.com/BryanWilhite/SonghayCore/issues/118) and [#125](https://github.com/BryanWilhite/SonghayCore/issues/125) (a bug 🐛) mark the advent of [Azure Storage REST API](https://docs.microsoft.com/en-us/rest/api/storageservices/) support in `SonghayCore`. This is huge news! It is my introduction to [Shared Key Authorization](https://docs.microsoft.com/en-us/rest/api/storageservices/authorize-with-shared-key) which I currently refuse to believe is a Microsoft-only technique. I assume that this form of REST authorization is a gateway to industry-wide practices that a “friendly” SDK can hide.

One file, `HttpRequestMessageExtensions.AzureStorage.cs` [[GitHub](https://github.com/BryanWilhite/SonghayCore/blob/master/SonghayCore/Extensions/HttpRequestMessageExtensions.AzureStorage.cs)] of less than 200 lines of code (excluding XML docs), replaces the _entire_ `Songhay.Cloud.BlobStorage` 📦 package! (This is largely because there was never a need for that much functionality in the [Azure Storage SDK](https://www.nuget.org/packages/Azure.Storage.Blobs/).) The `Songhay.Cloud.BlobStorage` repo will drift at sea for a while and will be archived later. This move lines up with [my previous statement](http://songhayblog.azurewebsites.net/entry/2021-03-30-studio-status-report-2021-03/) about moving away from ‘repository-patterning as an ongoing study.’

### bringing b-roll Activities to center stage

Just a few months ago, b-roll player logic sat in an ASP.NET Core API and in `Songhay,Player.Activities`. This is an undesired arrangement as an API layer should call logic _inside_ of `Songhay,Player.Activities`. The development schedule sketch (below) is revised to show this work (“centralize all `Songhay.Player` logic under Activities”) as done.

Much of this work was made possible by the Azure Storage REST API support added to the Core and increasing my understanding of [progressive download](https://en.wikipedia.org/wiki/Progressive_download), specifically my understanding of the `Stream.CopyTo` method [[📖 docs](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.copyto?view=net-5.0)]. I admit that there _was_ the ignorant temptation to load MP3 files into server memory in a `byte` array but such extravagant and naïve allocations _not_ scalable.

This work on progressive download via explicit use of `Stream` brings b-roll player functionality completely inside of Activities instead of depending on a server layer’s underlying `Stream`.

## what i learned about explicit use of `Stream`

The intent of `IActivity` and the interfaces that descend from it is to brightly and clearly define how to process _input_ and _output_.

However, when a `Stream` is either input or output, it will likely be closed (unusable) at runtime when crossing the boundary where it was allocated. Unless I am deeply mistaken, `Stream` is the only type that is totally devoted to *throughput*. Unless I am deeply mistaken again, my intent to handle throughput is indicated by passing around the strategy `Action<Stream>`.

There is the temptation to stay devoted to existing `IActivity`-based contracts and express this:

```csharp
public class ProgressiveAudioActivity : IActivityWithTask<(ProgramArgs args, streamAction Action<Stream>)>
{
}
```

But this tuple input will not work (conveniently) on the command-line level. Another approach is to avoid `Stream` I/O entirely and return the object ‘hosting’ the stream:

```csharp
public class PresentationStorageActivity : IActivityWithTask<ProgramArgs, HttpResponseMessage>
{
}
```

But I think this approach is failure to understand that [passing around](https://stackoverflow.com/questions/4085939/who-should-call-dispose-on-idisposable-objects-when-passed-into-another-object) an `IDisposable` is only possible when `using` is never used and I think this delicate handling is a recipe for a memory-leak disaster.

So my interim solution is to define `public async Task DownloadStreamAsync(string presentationKey, string fileName, Action<Stream> streamAction)` as a quick and dirty way to make *throughput* available in Activities _not_ running from the command line.

Later, this could be formalized in contracts like:

```csharp
public interface IActivityWithThroughput<IDisposable> : IActivity
{
    void Start(Action<IDisposable> throughputAction)
}

public interface IActivityWithTaskThroughput<IDisposable> : IActivity
{
    Task StartAsync(Action<IDisposable> throughputAction)
}
```

By chaining `IActivity` contracts, command-line support should be possible. And, yes, I was deeply mistaken: _any_ class implementing `IDisposable` should be regarded as *throughput*.

BTW, this is what I mean by ‘chaining `IActivity` contracts’:

```csharp
    class MyActivityWithOutput : IActivityWithOutput<ProgramArgs, string>
    {
        static MyActivityWithOutput() => traceSource = TraceSources.Instance.GetConfiguredTraceSource().WithSourceLevels();
        static TraceSource traceSource;

        public string DisplayHelp(ProgramArgs args) => "There is no help.";

        public void Start(ProgramArgs args) =>
            traceSource?.WriteLine(this.StartForOutput(args));

        public string StartForOutput(ProgramArgs args)
        {
            var output = $"output: {this.DoMyOtherRoutine(this.DoMyRoutine())}";

            traceSource?.WriteLine(output);

            return output;
        }
        internal string DoMyOtherRoutine(string input) =>
            $"The other routine is done. [{nameof(input)}: {input ?? "[null]"}]";

        internal string DoMyRoutine() => "The routine is done.";
    }
```

We see `IActivity.Start()` is _chained_ to `IActivityWithOutput<ProgramArgs, string>.StartForOutput()`. The code above is in a `SonghayCore` [test file](https://github.com/BryanWilhite/SonghayCore/blob/f6341930c74238c0a734c544fb937a5f4ceac58c/SonghayCore.Tests/Extensions/IActivityExtensionsTests.cs) as of this writing.

## sketching out a development schedule (revision 17)

The schedule of the month:

- ~~centralize all `Songhay.Player` logic under Activities~~
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- build Web components required for new version of SonghaySystem.com 🖼
- upgrade [`songhay-ng-workspace`](https://github.com/BryanWilhite/songhay-ng-workspace) to Angular latest 📦↑
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
