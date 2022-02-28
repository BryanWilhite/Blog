---json
{
  "documentId": 0,
  "title": "studio status report: 2022-02",
  "documentShortName": "2022-02-28-studio-status-report-2022-02",
  "fileName": "index.html",
  "path": "./entry/2022-02-28-studio-status-report-2022-02",
  "date": "2022-02-28T19:12:57.606Z",
  "modificationDate": "2022-02-28T19:12:57.606Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-02-28-studio-status-report-2022-02",
  "tag": "{\n  \"extract\": \"\"\n}"
}
---

# studio status report: 2022-02

## month 2 of 2022 was about day-job Azure Functions and Studio Blazor

For the day-job, I had the privilege of revisiting Azure Functions. Basically, this ‘allowed’ me to write a research/recommendations document based on two Studio READMEs:

1. <https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-azure-functions-quickstart#readme>
2. <https://github.com/BryanWilhite/Songhay.HelloWorlds.Activities/tree/master/Songhay.HelloWorlds.Functions#readme>

This effort was a real help to me professionally as a developer (which _can_ be a red-flag in the politics of the day-job). Now I am able to:

- understand why we need Azure _Durable_ Functions even though plain-old Azure Functions can do _some_ things without the need to be _Durable_
- understand why I _erroneously_ abandoned Azure Durable Functions in my own Studio work (because I failed to distinguish `Task.WhenAll(IEnumerable<Task<T>>)` from `Task.WhenAll(Task<T>[])`)

### Studio Blazor

Most of my Studio notes are too preliminary and scattered to post here. But the focus (and lack of focus) for this month was on:

- how to reference an Elmish Component in a separate project without it clashing with the main Component of the Blazor/Bolero project
- how to use `IMemoryCache` in a Blazor/Bolero project

What follows are other, slightly more coherent notes:

#### Blazor and Web Components

“[Initializing Web Components in Blazor via JS Interop](https://www.thomasclaudiushuber.com/2020/02/14/initializing-web-components-in-blazor-via-js-interop/)” _should_ do well in the world of Bolero. Here are relevent Bolero issues that explore this area:

- <https://github.com/fsbolero/Bolero/issues/221>

### Bolero: Why not create nodes by List.map?

<https://github.com/fsbolero/Bolero/issues/224>

>It's a bit complicated, but it's due to the way Blazor's rendering algorithm works. In short, each insertion is associated with a sequence number. These numbers must be consistent between two consecutive renders for the algorithm to work. If you insert items using something like `List.map`, then as soon as the list has changed length between two consecutive renders, the sequence numbers will be inconsistent. `forEach` fixes the issue by wrapping the content in a `RenderFragment` with a sequence that resets for each item.
>
>—Loïc Denuzière

Bolero also has `cond` to address:

>…the way that Blazor compares the rendered DOM when a change is applied, the returned HTML must always have the same structure: conditional elements can't be simply added. For example, the following may cause runtime errors:

```fsharp
// May fail at runtime.
let myButton (label: option<string>) =
    button [] [
        if label.IsSome then
            yield text label.Value
    ]
```

With `cond:`

```fsharp
let myButton (label: option<string>) =
    button [] [
        cond label <| function
            | Some l -> text l
            | None -> empty
    ]
```

But it is very, very possible that this works just as well:

```fsharp
let myButton (label: option<string>) =
    button [] [
        match label with
        | Some l -> text l
        | None -> empty
    ]
```

## sketching out a development schedule (revision 20)

The schedule of the month:

- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com 📜🚜🔨
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
