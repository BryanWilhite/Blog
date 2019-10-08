---json
{
  "documentId": 0,
  "title": "studio status report: 2018-09",
  "documentShortName": "2018-09-30-studio-status-report-2018-09",
  "fileName": "index.html",
  "path": "./entry/2018-09-30-studio-status-report-2018-09",
  "date": "2018-09-30T22:50:14.344Z",
  "modificationDate": "2018-09-30T22:50:14.344Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2018-09-30-studio-status-report-2018-09",
  "tag": "{\r\n  \"extract\": \"This report is a extremely late as this writing occurs on the last day of the month.the work on the new SonghaySystem.com continuesThe prime suspect for the lateness of this report is the work represented by Songhay.Dashboardissue #16. This single issue ...\"\r\n}"
}
---

# studio status report: 2018-09

This report is a *extremely* late as this writing occurs on the *last* day of the month.

## the work on the new SonghaySystem.com continues

The prime suspect for the lateness of this report is the work represented by `Songhay.Dashboard`[issue #16](https://github.com/BryanWilhite/Songhay.Dashboard/issues/16). This single issue got out of control, exploding to 44 comments (all made by me), spanning over 28 days. This issue essentially contains the start of the modern Angular version of the `Songhay.Player` client (the b-roll player), its curated YouTube Channel experience.

In order to make this experience possible these learnings were discovered (in issue-entry order):

* Angular Module lazy loading
* the active use of Typescript “duck typing” to ‘sketch’ out models without declaring a formal `interface`
* the Angular `@ViewChild` pattern replaces most jQuery selector patterns
* Angular’s `this.location.replaceState('/not-found')` replaces `$location.path("/not-found").replace()`
* the Angular `EventEmitter` pattern for data services
* Matias Niemelä and his `AnimationBuilder` (and the bug with `AnimationPlayer` [[Twitter](https://twitter.com/BryanWilhite/status/1038139182017724416)])
* using SASS maps to generate media queries
* `Map` should not be used with `*ngFor` [[ref](https://github.com/BryanWilhite/Songhay.Dashboard/issues/16#issuecomment-423879367)]
* the importance of `ChangeDetectionStrategy.OnPush` for improving performance [[ref](https://github.com/BryanWilhite/Songhay.Dashboard/issues/16#issuecomment-424426156)]
* using the CSS `transform` property to scale SVG icons [[ref](https://github.com/BryanWilhite/Songhay.Dashboard/issues/16#issuecomment-424499360)]

## major changes to Angular core `AppDataService`

Currently `AppDataService` [[GitHub](https://github.com/BryanWilhite/Songhay.Dashboard/blob/6e8b3f943fa837f1e6d8ae95b6839a080f9cbdc8/Songhay.Dashboard/ClientApp/src/app/songhay/core/services/songhay-app-data.service.ts)] is thrown down next to the Dashboard App source for two mutually exclusive reasons:

* the use of GraphQL has not been adopted (which promises to eliminate *all* of this code)
* the use of local NPM packages (likely with the `songhay-core`[repo](https://github.com/BryanWilhite/songhay-core)) has not been exploited

`AppDataService` was re-factored, adding the `loadJson()` method [[ref](https://github.com/BryanWilhite/Songhay.Dashboard/issues/16#issuecomment-418229660)] so it can be used like this:

@Injectable()
    export class YouTubePresentationDataServices {
        constructor(client: Http) {
            this.presentationDataService = new AppDataService(client);
            this.videosDataService = new AppDataService(client);
        }

presentationDataService: AppDataService;

videosDataService: AppDataService;

loadPresentation(id): Promise&lt;Response&gt; {
            const uri = `${YouTubeScalars.rxYouTubeApiRootUri} ${id}`;
            return this.presentationDataService.loadJson&lt;{}&gt;(uri, json =&gt; {});
        }

loadVideos(id): Promise&lt;Response&gt; {
            const uri = `${YouTubeScalars.rxYouTubeApiRootUri} ${
                YouTubeScalars.rxYouTubeApiVideosPath
            } ${id}`;

return this.videosDataService.loadJson&lt;{}&gt;(uri, json =&gt; {});
        }
    }

What this is saying most importantly is that there is only `AppDataService` per server call. This will not scale well in more sophisticated Apps, especially where there is no control over the server. The plan is to let GraphQL come to the rescue in near future.

`AppDataService` has these remaining issues (which should be added to the `songhay-core`[repo](https://github.com/BryanWilhite/songhay-core))):

* work in `Songhay.Dashboard` (including `MapObjectUtility.getMap` [[ref](https://github.com/BryanWilhite/Songhay.Dashboard/issues/16#issuecomment-418186425)]) should be migrated to `songhay-core`
* the `async`-`await` pattern should be used

One of the promises of GraphQL is the elimination of the need to have real server running in order to build a client. While this promise is deliberately prioritized to be out of my reach for the short term, I need a service running which means I need [CORS running](https://github.com/BryanWilhite/Songhay.Affiliates/commit/e92d76fef079eb06b2604e990e3cc10466df1c3b).

Got some great [help](https://twitter.com/ethomson/status/1045631647553671170) from Edward Thomson from Microsoft to get YAML-based builds working [[ref](https://github.com/BryanWilhite/Songhay.Affiliates/issues/3#issuecomment-425545706)]. This step forward is a significant move toward adding critical automation to the Songhay System.

@[BryanWilhite](https://twitter.com/bryanwilhite)

@[BryanWilhite](https://twitter.com/BryanWilhite)
