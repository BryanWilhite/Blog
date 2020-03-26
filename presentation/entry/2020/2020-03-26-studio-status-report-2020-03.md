---json
{
  "documentId": 0,
  "title": "studio status report: 2020-03",
  "documentShortName": "2020-03-26-studio-status-report-2020-03",
  "fileName": "index.html",
  "path": "./entry/2020-03-26-studio-status-report-2020-03",
  "date": "2020-03-26T18:00:20.237Z",
  "modificationDate": "2020-03-26T18:00:20.237Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-03-26-studio-status-report-2020-03",
  "tag": "{\r\n  \"extract\": \"month 3 of 2020 is about a deep dive into re-factoring for the cloud Last month I called this a “O(n) problem” which I now realize is the same thing as saying it is a time complexity problem. This has not been a time complexity problem. It has been more o…\"\r\n}"
}
---

# studio status report: 2020-03

## month 3 of 2020 is about a deep dive into re-factoring for the cloud

Last month [I called](http://songhayblog.azurewebsites.net/entry/2020-02-23-studio-status-report-2020-02) this a “_O_(_n_) problem” which I now realize is the same thing as saying it is a [_time complexity_](https://en.wikipedia.org/wiki/Time_complexity) problem. This has _not_ been a time complexity problem. It has been more of a resource-request saturation problem.

The clear and present error message was:

```console
A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond
```

The error came from a single Azure Activity Function looping through a sizable amount of `async` calls to external resources (Azure Storage containers). Making a large amount of `async` calls in a small amount of time is possible in the Azure cloud as long as each `async` call is to a separate Activity Function.

What this means for my Studio is that _one_ `IActivityWithTask<TInput, TOutput>` had to be re-factored to support _multiple_, serverless Activity Function calls. By the way, I am _not_ working out this problem in public on GitHub. The only public piece out there is [a small-scale sketch](https://github.com/BryanWilhite/LinqPad/blob/master/Queries/funkyKB/Dictionary%20-%20treating%20method%20IO%20like%20data.linq) I threw together on LINQPad.

I do look forward to writing in more detail about my findings:

- defining `IActivityWithTask<JObject, JObject>` for the Azure flavor of serverless recognizes that `Newtonsoft.Json` is the first-class choice for serialization in Azure Functions 2.x
- the `public async Task<JObject> StartAsync(JObject input)` façade will stay in place which means the complexity of mapping function-call I/O explodes (I am mapping input to a specific `internal` member in the Activity through a data-driven layer of indirection to prevent tight coupling)
- the extensive use of `JObject` required many overloads of `internal` members that could handle `JObject` I/O

`IActivityWithTask<JObject, JObject>` reminds me of the SOAP days when an entire API was single endpoint that accepted XML and returned XML. It _appears_ that all I am doing is replacing XML with JSON. Today, I can only push back against this flippant accusation by saying _yes_ it _does_ look like that shit but the granularity is much higher (or, inversely, the surface area of the JSON endpoint if much smaller).

As of today, my first `IActivityWithTask<JObject, JObject>` class supports five clearly-defined types of `JObject` input, mapping to eight clearly-defined types of `JObject` output. This I/O is designed to be testable because the I/O is tracked in C# dictionaries. And “the whole point” of doing this of course is to write business logic that can run in the cloud, on a dedicated server and on the desktop _by default_. This is the practice of the Studio.

## yes, the lunr index issue is still open

[Issue #25](https://github.com/BryanWilhite/Blog/issues/25) for this Blog is _still_ open. The cloud stuff above has been literally crowding it out. This is the next this on the list below:

## sketching out a development schedule (revision 7)

Today, the studio development schedule looks like this:

* ~~build out `Songhay.Player.Activities` and plug into Azure Functions~~ ✔
* ~~build out `Songhay.Social.Activities` (automated social-media posting) and plug into Azure Functions~~ 🤖🌩
* ~~address `Songhay.Player.Activities` _O_(_n_) problem 🤖🌩~~
* build lunr index experience 🏗
* use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
* add Stills API to `Songhay.Player` (b-roll player) 🕸🌩
* use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
* modernize the kinté hits page into a progressive web app 💄✨
* convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
* use the learnings of previous work to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
