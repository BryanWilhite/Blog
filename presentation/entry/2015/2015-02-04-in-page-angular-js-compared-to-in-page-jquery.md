---json
{
  "documentId": 0,
  "title": "In-page Angular JS compared to in-page jQuery",
  "documentShortName": "2015-02-04-in-page-angular-js-compared-to-in-page-jquery",
  "fileName": "index.html",
  "path": "./entry/2015-02-04-in-page-angular-js-compared-to-in-page-jquery",
  "date": "2015-02-04T08:00:00Z",
  "modificationDate": "2015-02-04T08:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-02-04-in-page-angular-js-compared-to-in-page-jquery",
  "tag": "{\r\n  \"extract\": \"It makes sense to me to compare Angular JS to jQuery. I need to see this to literally see the way to migrate a jQuery-centric site to an Angular one. The gulf between how I’ve been doing jQuery and the Angular 1.x “seed” is huge—so this is way to bridge ...\"\r\n}"
}
---

# In-page Angular JS compared to in-page jQuery

It makes sense to me to compare Angular JS to jQuery. I need to see this to literally see the way to migrate a jQuery-centric site to an Angular one. The gulf between how I’ve been doing jQuery and the Angular 1.x “seed” is huge—so this is way to bridge the gap with an interim step.

So, in my ASP.NET MVC `*.cshtml` page, I would see something like this:

```cshtml
@section ScriptContent
{
    <script type="text/javascript">
        /*jslint browser: true, nomen: true, passfail: false, plusplus:true, vars: true, unparam: true, white: false */
        /*global window, jQuery, angular, _ */}
        (function ($) {
            "use strict";

            var loadPageData = function () {
            var uri = '@Url.Content("~/MyMvc/Data")';

            $.ajax({
                    type: 'POST',
                    url: uri
                }).done(function (data) {
                    loadPageDataCallback(data);
                });
            };

            var loadPageDataCallback = function (result) {
                                //do call-back stuff…
                            };

            $('#MyButton).click(function () {
                                //do button click stuff…
                            };

            loadPageData();
        }(jQuery));
    </script>
}
```

Before planting a full-blown angular seed with routing (yes, use `ng-controller` directly on elements) and partials, we can take this interim step:

```cshtml
@section ScriptContent
{
    <script type="text/javascript">
        /*jslint browser: true, nomen: true, passfail: false, plusplus:true, vars: true, unparam: true, white: false */
        /*global window, jQuery, angular, _ */
        (function ($) {
            "use strict";

            var rxApp = angular.module('rxApp', ['rxApp.services', 'rxApp.controllers']);

            /* Services */
            var dataService = {
                getData: function ($http) {
                    if (!$http) { return; }
                    var uri = '@Url.Content("~/MyMvc/Data")';
                    return $http.post(uri).then(
                        function (result) {
                            return result.data;
                        });
                }
            };

            var services = angular.module('rxApp.services', []);
            services
                .factory('dataService', ['$http', function ($http) { return dataService; }])
            ;

            /* Controllers */
            var doPageController = function ($scope, $http, dataService) {
                $scope.vm = {
                    data: null
                    myButtonClick: function() {
                        //do button-click stuff
                    }
                };

            dataService.getData($http).then(function (data) {
                    $scope.vm.data = data;
                });
            };

            var controllers = angular.module('rxApp.controllers', []);
            controllers
                .controller('pageController', ['$scope', '$http', 'dataService', doPageController])
                ;
        }(jQuery));
    </script>
}
```

So, for every jQuery script block we find (I assume one block per `*.cshtml` page), we can replace it with an Angular app (yes, very redundant across MVC pages), one controller and maybe one or more services. When we make a proper seed—to consolidate these multiple `rxApp` instances on every MVC page—we’ll have much better idea about the controllers (and any long-lasting jQuery dependencies). We should have a more informed plan around replacing MVC pages with Angular partials.

Writing this Blog post has allowed me to see how my jQuery patterns translate to Angular patterns. To me, it looks like the all of the jQuery code roughly translates to the Angular controller. So a hard-core jQuery person might ask about the usefulness of the extra lines of code around the Angular controller. To me, it makes sense because Angular people are building a [module-system](https://docs.angularjs.org/guide/module) around the controller that allows for code reuse and dependency injection (primarily for automated testing purposes).

Hard-core Angular (1.x) people may not tolerate my failure to use [directives](https://docs.angularjs.org/guide/directive) in my example above. Directives are the most innovative and web-evolutionary thing ever to come out of a JavaScript framework—and I’m not using them here! In fact, last year I watched a shocking video, “[Angular 2.0 Core by Igor Minar & Tobias Bosch at ng-europe 2014](https://www.youtube.com/watch?v=gNmWybAyBHI)” that ended with this slide:
[<img alt="Angular 2.0 Core by Igor Minar & Tobias Bosch at ng-europe 2014" src="https://farm8.staticflickr.com/7389/16425440926_7c219d5424_o_d.png" style="display:block;margin:16px;margin-left:auto;margin-right:auto">](https://www.youtube.com/watch?v=gNmWybAyBHI "Angular 2.0 Core by Igor Minar & Tobias Bosch at ng-europe 2014")

It looks like they are killing everything in Angular 1.x *except* directives (watch the video to get past the drama)! What might be a cool Stack Overflow question is seeing how my jQuery block translates into Angular 2.0.

@[BryanWilhite](https://twitter.com/BryanWilhite)
