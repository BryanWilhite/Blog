---json
{
  "documentId": 0,
  "title": "studio status report: 2019-02",
  "documentShortName": "2019-02-25-studio-status-report-2019-02",
  "fileName": "index.html",
  "path": "./entry/2019-02-25-studio-status-report-2019-02",
  "date": "2019-02-26T02:52:45.909Z",
  "modificationDate": "2019-02-26T02:52:45.909Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2019-02-25-studio-status-report-2019-02",
  "tag": "{\r\n  \"extract\": \"One “pure” NPM package and two Angular packagesAfter another miserable, 20-day siege, these are the repositories I have committed to that develop Javascript code reuse in the Songhay Studio: songhay-core [GitHub]songhay-ng-workspace [GitHub]Here is a sele...\"\r\n}"
}
---

# studio status report: 2019-02

## One “pure” NPM package and two Angular packages

After another miserable, 20-day siege, these are the repositories I have committed to that develop Javascript code reuse in the Songhay Studio:

* `songhay-core` [[GitHub](https://github.com/BryanWilhite/songhay-core)]
* `songhay-ng-workspace` [[GitHub](https://github.com/BryanWilhite/songhay-ng-workspace)]

Here is a selection of GitHub issues detailing the misery:

* [https://github.com/BryanWilhite/songhay-core/issues/1](https://github.com/BryanWilhite/songhay-core/issues/1)
* [https://github.com/BryanWilhite/songhay-core/issues/2](https://github.com/BryanWilhite/songhay-core/issues/2)
* [https://github.com/BryanWilhite/songhay-core/issues/4](https://github.com/BryanWilhite/songhay-core/issues/4)
* [https://github.com/BryanWilhite/songhay-ng-workspace/issues/4](https://github.com/BryanWilhite/songhay-ng-workspace/issues/4)
* [https://github.com/BryanWilhite/Songhay.Dashboard/issues/46](https://github.com/BryanWilhite/Songhay.Dashboard/issues/46)

The bottom line: “pure” NPM packages worked out kind-of-OK while Angular packages from 6.x-era libraries are currently causing [runtime problems](https://github.com/BryanWilhite/Songhay.Dashboard/issues/48). [Ed Pelc](https://twitter.com/ed_pelc) details the other major issue: the need to [wrap library modules](https://youtu.be/nP7Yodr-WUA?t=1340) for lazy loading.

This misery has [led me to understand](https://github.com/BryanWilhite/songhay-ng-workspace/issues/4#issuecomment-465367238) why `nrwl` would still be a thing in the Angular 6.x time-frame.

## the GiHub credentials drama

The ‘git on Windows is not working with GitHub credentials’ error (mentioned [last month](http://songhayblog.azurewebsites.net/blog/entry/studio-status-report-2019-01)) is peculiar to one machine. I set up a new Windows 10 VM recently and *do not* have this issue. This leads me to wonder how to completely clean/reset the Windows 10 credentials stack.

@[BryanWilhite](https://twitter.com/bryanwilhite)
