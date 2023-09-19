---json
{
  "documentId": 0,
  "title": "studio status report: 2022-01",
  "documentShortName": "2022-01-30-studio-status-report-2022-01",
  "fileName": "index.html",
  "path": "./entry/2022-01-30-studio-status-report-2022-01",
  "date": "2022-01-31T01:54:14.524Z",
  "modificationDate": "2022-01-31T01:54:14.524Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-01-30-studio-status-report-2022-01",
  "tag": "{\n  \"extract\": \"month 1 of 2022 was about staying on the development schedule but wading slowly through F# The project associated with new version of SonghaySystem.com has one issue that is supersaturated with commits. This issue represents the following highlights: - bu…\"\n}"
}
---

# studio status report: 2022-01

## month 1 of 2022 was about staying on the development schedule but wading slowly through F\#

The [project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) associated with new version of SonghaySystem.com has [one issue](https://github.com/BryanWilhite/Songhay.Dashboard/issues/76) that is supersaturated with commits. This issue represents the following highlights:

- building xUnit F# test projects
- using all the features listed on the [Bolero](https://fsbolero.io/) cereal box
- starting `Songhay.Modules` project, the Songhay ‘Core’ of my F# world
- getting a firm understanding of railway-oriented programming and `Result<'T,'TError>`

The challenge of running ASP.NET Kestrel as a reverse-proxy server behind Apache is still looming out there. Now, here is a walk through selected Studio notes from this month:

### F#: `FSharp.SystemTextJson` is *slower* than naked `System.Text.Json`

The main intent behind `FSharp.SystemTextJson` [[GitHub](https://github.com/Tarmil/FSharp.SystemTextJson)] is to convert JSON directly into F# records:

>…you take a ~60% hit by using records.
>
>—[Chet Husk](https://github.com/Tarmil/FSharp.SystemTextJson/pull/11#issuecomment-519614474)

### F#: Bolero API calls by server-side remoting, not from WebAssembly?

The Bolero docs do not recognize the possibility of calling API from WebAssembly [📖 [docs](https://docs.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-6.0&pivots=webassembly)]. They present *remoting* [📖 [docs](https://fsbolero.io/docs/Remoting)] exclusively. In my current state of ignorance, I assume that this preference is for the following architectural reasons:

- allowing the Wasm to call *any* remote location from the client side can lead HTTP infrastructure change/maintenance and even secrets adding complexity and possible security flaws exposed on the client
- Wasm-based HTTP infrastructure could compete architecturally/conceptually with using Wasm as a cache for remoting (via the Web Storage API [📖 [MDN](https://developer.mozilla.org/en-US/docs/Web/API/Web_Storage_API)])

Today, I assume that designing a “rich client” with a dependency on one server is easier to maintain than a “rich client” that knows about many, many servers (with many, many possible authentication strategies). This is my design idea of the day:

> The “rich client” should have API data designed specifically for it—at the very least this design intends to reduce the amount of remote calls needed by the client at start up to *one* call for a composite collection of data.

### F: the relationship between `async` and `task`

My service handler in Bolero shows how the output of `task` (which is a CLR `Task<T>`) can be converted to the output of `async`:

```fsharp
type DashboardServiceHandler() =
    inherit RemoteHandler<DashboardService>()
    override this.Handler =
        {
            getAppData = fun location -> (System.Threading.Tasks.Task.FromResult<string option>(Some location) |> Async.AwaitTask)
        }
```

The Bolero docs encourages us to use `async` alone:

```fsharp
type DashboardServiceHandler() =
    inherit RemoteHandler<DashboardService>()
    override this.Handler =
        {
            getAppData = fun location -> async {
                return Some location
            }
        }
```

### Blazor: Fluxor

>The aim of Fluxor is to create a multi-UI, single-state store approach to front-end development without the headaches typically associated with other implementations, such as the overwhelming amount of boiler-plate code required just to add a very basic feature.
>
><https://github.com/mrpmorris/Fluxor>

video: <https://www.youtube.com/watch?v=k_c-ErPaYa8>

## sketching out a development schedule (revision 20)

The schedule of the month:

- complete [project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) associated with new version of SonghaySystem.com 📜🚜🔨
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

<https://github.com/BryanWilhite/>
