---json
{
  "documentId": 0,
  "title": "When in bower doubt, delete all of your components and reinstall?",
  "documentShortName": "2015-08-19-when-in-bower-doubt-delete-all-of-your-components-and-reinstall",
  "fileName": "index.html",
  "path": "./entry/2015-08-19-when-in-bower-doubt-delete-all-of-your-components-and-reinstall",
  "date": "2015-08-20T03:10:10.187Z",
  "modificationDate": "2015-08-20T03:10:10.187Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-08-19-when-in-bower-doubt-delete-all-of-your-components-and-reinstall",
  "tag": "{\r\n  \"extract\": \"When you have the bandwidth just delete everything in your \\\\bower_components folder and run bower install. Why resort to this? The output of my reinstall displayed this warning: Please note that,     angular-embed-codepen#1.1.1 depends on angular#~1.2.21...\"\r\n}"
}
---

# When in bower doubt, delete all of your components and reinstall?

When you have the bandwidth just delete everything in your `\bower_components` folder and run `bower install`. Why resort to this? The output of my reinstall displayed this warning:Please note that,
    angular-embed-codepen#1.1.1 depends on angular#~1.2.21 which resolved to angular#1.2.28
    angular-ui-sortable#0.13.4 depends on angular#&gt;=1.2.x which resolved to angular#1.2.28
    angular-animate#1.4.4, angular-loader#1.4.4, angular-mocks#1.4.4, angular-route#1.4.4, angular-sanitize#1.4.4 depends on angular#1.4.4 which resolved to angular#1.4.4
    angulike#1.2.0 depends on angular#&gt;=1.2.16 which resolved to angular#1.4.4
    angular-seed#a50f4c8a7a depends on angular#~1.4.0 which resolved to angular#1.4.4
    angular-ui-bootstrap-bower#0.13.3 depends on angular#&gt;=1.3.0 which resolved to angular#1.4.4
Resort to using angular#&gt;=1.4.x which resolved to angular#1.4.4
Code incompatibilities may occur.I recently installed a bower package that downgraded my `angular` package from 1.4.x to 1.2.x. I do not know why this is possible by default in bower—so this drastic move is the only way I know how to deal with this issue (today).

@[BryanWilhite](https://twitter.com/BryanWilhite)
