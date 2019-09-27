---json
{
  "author": null,
  "content": "the day job brings some new Angular research topicsDo rxjs observables invoke for every subscriber? The answer to this question (at work) looks like it’s yes which means HttpClient.post() will invoke post() for every subscriber. This default behavior is ...",
  "inceptDate": "2019-01-28T15:01:04.8973912-08:00",
  "isPublished": true,
  "itemCategory": "\"year\":2019,\"month\":\"01\",\"day\":\"28\",\"dateGroup\":\"2019\\/01\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2019-01-28-studio-status-report",
  "sortOrdinal": 0,
  "tag": null,
  "title": "studio status report: 2019-01"
}
---

## studio status report: 2019-01

### the day job brings some new Angular research topics

Do `rxjs` observables invoke for every subscriber? The answer to this question (at work) looks like it’s _yes_ which means `HttpClient.post()` will invoke `post()` for every subscriber. This default behavior is _not_ what I would expect and the `shared()` method [[docs](https://github.com/ReactiveX/rxjs/blob/01a09789a0a9484c368b7bd6ed37f94d25490a00/doc/operators.md#multicasting-operators)] is supposed to meet my expectations. A [StackBlitz example](https://stackblitz.com/edit/rxjs-observable-share?file=app%2Fapp.component.ts) out there is not really helping me at the moment.

I have yet to release my flippant remarks on `BehaviorSubject` which is the core of the observable store service (which is kind of like the Angular answer to WPF event aggregation?). This is kind of a big deal for me as this topic addresses the bigger topic of Redux as an intermediate step towards robust, full-featured state management.

### NPM packaging research still underway

[Research](https://github.com/BryanWilhite/nodejs/tree/master/npm-package) on NPM packaging and modules has led up to the need to include TypeScript in the mix. Ideally, “[Step by step: Building and publishing an NPM Typescript package](https://itnext.io/step-by-step-building-and-publishing-an-npm-typescript-package-44fe7164964c)”  or “[The 30-second guide to publishing a TypeScript package to NPM](https://medium.com/cameron-nokes/the-30-second-guide-to-publishing-a-typescript-package-to-npm-89d93ff7bccd)” will get me moving.

### Azure spending rate crisis apparently over

Moving an App Service without its [App Service Plan](https://docs.microsoft.com/en-us/azure/app-service/overview-hosting-plans) to another Resource Group can force Microsoft to silently change the plan of the service. This change can cost money.

### outstanding issues

Microsoft’s Edward Thomson [did not get back to me](https://twitter.com/ethomson/status/1063003088569753600) for the YAML issue I was having so I lodged an issue on GitHub and [got some not-so-great news](https://github.com/Microsoft/azure-pipelines-tasks/issues/9235#issuecomment-451982478). But, according to the rules of the game, this matter is resolved-by-workaround.

The ‘git on Windows is not working with GitHub credentials’ error is still alive and well:

```console
git push <shows GitHub authentication prompt>
fatal: MissingMethodException encountered.
   Method not found: 'System.Threading.Tasks.Task`1<System.Net.Http.HttpResponseMessage> Microsoft.Alm.Authentication.INetwork.HttpPostAsync(Microsoft.Alm.Authentication.TargetUri, System.Net.Http.HttpContent, Microsoft.Alm.Authentication.NetworkRequestOptions)'.
```

@[BryanWilhite](https://twitter.com/bryanwilhite)
