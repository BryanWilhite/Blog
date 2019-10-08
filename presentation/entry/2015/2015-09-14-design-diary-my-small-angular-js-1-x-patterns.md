---json
{
  "documentId": 0,
  "title": "Design Diary: my small Angular JS 1.x patterns",
  "documentShortName": "2015-09-14-design-diary-my-small-angular-js-1-x-patterns",
  "fileName": "index.html",
  "path": "./entry/2015-09-14-design-diary-my-small-angular-js-1-x-patterns",
  "date": "2015-09-14T20:41:02.783Z",
  "modificationDate": "2015-09-14T20:41:02.783Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-09-14-design-diary-my-small-angular-js-1-x-patterns",
  "tag": "{\r\n  \"extract\": \"My recent work with the redesign/upgrade of kintespace.com leaves me with a few Angular JS patterns that must be memorialized here, literally for my own (mental) health.Using a data Service with dirt-simple caching based on $q‘Dirt-simple’ caching is a s...\"\r\n}"
}
---

# Design Diary: my small Angular JS 1.x patterns

My recent work with [the redesign/upgrade of kintespace.com](http://codepen.io/rasx/pen/dPoPbV) leaves me with a few Angular JS patterns that must be memorialized here, literally for my own (mental) health.

## Using a data Service with dirt-simple caching based on $q

‘Dirt-simple’ caching is a system that loads data once and stores the data until the system restarted. I am sure there is a more academic name for this design—nevertheless, this is what ‘dirt-simple’ caching looks like as an Angular service:

<script src="https://gist.github.com/BryanWilhite/22c7416b5bba10873546.js"></script>

What we see in the gist is an Angular service with three methods: `cacheData()`, `getDataFromCache()`, and `loadIndex()`. This service is from an Angular app displays Index data so `loadIndex()` is called every time the App is loaded—and every time the Index partial View is requested.

These two lines of code represent the “secret sauce” of this dirt-simple design:

```javascript
var cachedResponse = this.getDataFromCache(uri);
return cachedResponse? $q.when(cachedResponse) : $http.get(uri).then(…);
```

That last line—that ternary operation featuring `$q.when()` ([from Angular JS](https://docs.angularjs.org/api/ng/service/$q)) makes things dirt simple.

## Using ngView *and* custom directives

I started using `ngView` to *avoid* delving into building my own directives. In “[My Angular JS 1.x single-page layout](http://songhayblog.azurewebsites.net/),” I am making myself familiar with the need to use *very* simple custom directives—typically header and footer directives, wrapping `ngView`—to give me a little headroom in layout expressiveness. Here’s an example of a header Directive:

```javascript
var doHeaderDirective = function () {
    return {
        restrict: "E",
        scope: false,
        templateUrl: "./app/partials/headerFlow.html"
    };
};
```

## Using a Client View Model to provide binding for a Directive outside of ngView scope

The header Directive shown above, has its scope option set to `false` (which means it will inherit its Controller scope). But when the header is loaded outside of `ngView` what controller is associated with it? To answer this question, I’ve developed this pattern using `ngController`:

&lt;!DOCTYPE html&gt;
&lt;html data-ng-app="rxApp"&gt;
&lt;head&gt;…&lt;/head&gt;
&lt;body&gt;
&lt;div class="container" data-ng-controller="clientController"&gt;
    &lt;rx-header /&gt;
    &lt;div class="row" data-ng-view=""&gt;…&lt;/div&gt;
&lt;/div&gt;
&lt;rx-footer /&gt;
&lt;/body&gt;
&lt;/html&gt;

I can define View Model inside of `clientController` that can be used for data binding, etc. *outside* of `ngView`. This may be obvious to many Angular folks but I can see how a beginner can fall in the trap of thinking one should use `ngView` *or* `ngController` instead of *both* of them.

## Using Angular UI pagination with Underscore-JS sorting

My little [gist about paging and sorting](https://gist.github.com/BryanWilhite/5a634fd6ce237d6d0107) shows key fragments of the design, featuring a Pagination Service driven by a Controller that uses [Underscore JS](http://underscorejs.org/) to sort the data before passing it to this service. We of course *see* the pagination through the markup in the partial, [documented on GitHub](http://angular-ui.github.io/bootstrap/).

The Pagination Service has only one expectation for the data it uses: the data must be an array. The `start()` method starts pagination and it called from the controller:

```javascript
$scope.clientVM.dataService.loadData("index-" + indexMetaId).then(function (response) {
    that.data = _(response.data.ChildDocuments)
        .chain()
        .filter(function (i) {
            return (!_.isUndefined(i) &amp;&amp; !_.isNull(i));
        }).sortBy(function (i) {
            return i.CreateDate;
        })
        .value()
        .reverse();
    that.pagination.start(that.data);
    that.pagination.isVisible = true;
    $scope.clientVM.isDataLoaded = true;
    $scope.clientVM.isSplash = false;
});
```

## Using ngClass, $parent, $first and the Client View Model with ngRepeat

The import discovery for me here is `ngClass`. I feel like I should have learned about `ngClass` before I started building Angular JS sites—this is a super-easy way to associate CSS class names with Controller logic (it is effectively the equivalent of `.addClass()`, `.hasClass()`, `.removeClass()`, `.toggleClass()` in jQuery).

[This gist](https://gist.github.com/BryanWilhite/0b0484102980acf5ccb2) sketches out how a repeated set of headers, associated with `ngView` routes, changes CSS classes based on the route:

<script src="https://gist.github.com/BryanWilhite/0b0484102980acf5ccb2.js"></script>

The use of `$parent` in the partial implies that the partial is loaded in `ngView` and `ClientVM` is the Client View Model of the `$parent` scope ‘above’ the controller of the `ngView`. (See “Using a Client View Model to provide binding for a Directive outside of `ngView` scope” above.)

The use of `$first` in the markup is passed to the `isFirst` parameter of `clientVM.isIndexSubsetHeaderSelected()`. It is used to make a default selection for initial load.

## Using a custom function for a filter with nqRepeat

This declaration refers to a function, `vm.filterGroups()`:

```plaintext
data-ng-repeat="i in groups | filter:vm.filterGroups
```

In this particular case, the filter function is part of a View Model that is entirely devoted to filtering:

```javascript
$scope.vm = {
    filterExpression: null,
    filterGroup: function (data) {
        var filterExpression = $scope.vm.filterExpression;
        if (!filterExpression) {
            return true;
        }
        filterExpression = filterExpression.toLowerCase();
        var title = data.Title;
        var isContainedInTitle = (title &amp;&amp; title.toLowerCase().indexOf(filterExpression) === -1) ? false : true;
        return isContainedInTitle;
    },
    filterGroups: function (data) {
        if (!data.group) {
            return true;
        }
        var filteredItems = _(data.group).filter($scope.vm.filterGroup);
        var hasGroupItems = (filteredItems &amp;&amp; (filteredItems.length &gt; 0)) ? true : false;
        return hasGroupItems;
    },
};
```

The `filterExpression` property is bound to an `input[type="text"]` element:

&lt;input data-ng-model="vm.filterExpression" type="text" class="form-control" placeholder="search"&gt;

The Angular documentation clearly specifies the use of a “[predicate function](https://docs.angularjs.org/api/ng/filter/filter)” for filter expressions.

@[BryanWilhite](https://twitter.com/BryanWilhite)
