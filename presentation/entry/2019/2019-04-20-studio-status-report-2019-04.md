---json
{
  "author": null,
  "content": "getting this Index App into songhay-ng-workspaceThis month saw the archiving of angular.io-index-app [GitHub] because it is being moved to songhay-ng-workspace. This was quite a forehead slapping moment and should be reflected in this month’s version of ...",
  "inceptDate": "2019-04-20T20:09:16.1285336-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "studio-status-report-2019-04",
  "sortOrdinal": 0,
  "tag": null,
  "title": "studio status report: 2019-04"
}
---

## getting this Index App into `songhay-ng-workspace`

This month saw the archiving of `angular.io-index-app` [[GitHub](https://github.com/BryanWilhite/angular.io-index-app)] because it [is being moved](https://github.com/BryanWilhite/songhay-ng-workspace/issues/11) to `songhay-ng-workspace`. This was quite a forehead slapping moment and should be reflected in this month’s version of ‘sketching out a development schedule (revision 1)’ (below).

## making `MenuDisplayItemModel` grouping and sorting framework agnostic

Another huge slap (that apparently has been over a decade in the making), is the studio-realization that `MenuDisplayItemModel` grouping and sorting can be done in pure Typescript without regard to Angular, Vue, React, etc.

I developed the `DisplayItemUtility` [[GitHub](https://github.com/BryanWilhite/songhay-core/blob/master/src/utilities/display-item.utility.ts)] to establish what should have super obvious to me at least 10 years ago. My company name is Songhay System—not *systems*—because here we see *one* concept that can be implemented in a *diverse* array of technologies. Once the `DisplayItemUtility` shows up in C#, it will be the realization of this ideal. (The `DisplayItemModel` and `MenuDisplayItemModel`, by the way, are already here: [in C#](https://github.com/BryanWilhite/SonghayCore/tree/master/SonghayCore/Models) and [in TypeScript](https://github.com/BryanWilhite/songhay-core/tree/master/src/models)).

## really thinking about display text the Songhay System way

Another huge cognitive step around my late arrival to this thinking party compels me [to raise the issue](https://github.com/BryanWilhite/songhay-core/issues/12) about the limitations of having the display text concept represented by the `string`. The display text concept should start at plain text and advance through markdown—and *optionally* store HTML. This introduction of markdown as a super-fine line between plain text and HTML is a subtlety that has escaped me for at least a decade (I am just throwing decades left and right).

For my sanity, I should remind myself that `ngx-markdown` did not [start](https://github.com/jfcere/ngx-markdown/graphs/contributors) until 2017/2 but the underlying `marked` was [around in 2011](https://github.com/markedjs/marked/graphs/contributors).

## sketching out a development schedule (revision 1)

Today the studio development schedule looks like this:

*   finish modernizing `@songhay/player-video-you-tube` and `@songhay/index` into a ready state [[#11](https://github.com/BryanWilhite/songhay-ng-workspace/issues/11)]
*   introduce splash page(s) to the Day Path blog (an SEO emergency—*for years*) and convert to HTTPs by default
*   use the learnings from existing npm packages to build `@songhay/player-audio-???`
*   convert the kinté space blog to Hexo (this has been an emergency *for years*)
*   set up automated social-media posting with Azure logic apps (and a queue of some kind?)
*   modernize the kinté hits page into a progressive web app
*   use the learnings of previous work to upgrade and re-release the kinté space

The Day Path Blog bullet was moved up because many of the later bullets will not be trackable via public GitHub issues.

@[BryanWilhite](https://twitter.com/bryanwilhite)
