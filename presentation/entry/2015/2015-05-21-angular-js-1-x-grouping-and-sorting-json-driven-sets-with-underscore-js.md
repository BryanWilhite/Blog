---json
{
  "documentId": 0,
  "title": "Angular JS 1.x: grouping and sorting JSON-driven sets with Underscore JS",
  "documentShortName": "2015-05-21-angular-js-1-x-grouping-and-sorting-json-driven-sets-with-underscore-js",
  "fileName": "index.html",
  "path": "./entry/2015-05-21-angular-js-1-x-grouping-and-sorting-json-driven-sets-with-underscore-js",
  "date": "2015-05-21T07:00:00Z",
  "modificationDate": "2015-05-21T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-05-21-angular-js-1-x-grouping-and-sorting-json-driven-sets-with-underscore-js",
  "tag": "{\r\n  \"extract\": \"The Angular JS documentation on orderBy surprisingly has all the information I need to sort data. It even shows how the reverse argument can be assigned to a variable. This allowed me to write markup like this:\"\r\n}"
}
---

# Angular JS 1.x: grouping and sorting JSON-driven sets with Underscore JS

The [Angular JS documentation](https://docs.angularjs.org/api/ng/filter/orderBy) on `orderBy` surprisingly has all the information I need to sort data. It even shows how the `reverse` argument can be assigned to a variable. This allowed me to write markup like this:

```html
<div data-ng-repeat="i in groups | orderBy: 'groupName' : vm.indexGroupingSelected.sortDescending ">…</div>
```

When I use the variable `vm`, I am conventionally telling myself (because I’m a Microsoft, *MVVM* guy) that I am using my Angular *View Model* in Controller Scope (`$scope.vm`). Since I would like to follow my conventions, it would make sense to have `data-ng-repeat="i in vm.groups… "` but I’ve found that Angular does not see “dotted” objects in `ng-repeat` (there may be some 1.x release after `1.2.6 taco-salsafication` that fixes this)—so I have no choice but to use `$scope.groups`.

Now, the angular documentation does *not* talk about how to fill `$scope.groups`—to me this is an Underscore thing. I use `_.chain()` (with `pairs()` and `map()`) in `$scope.vm.setGroups()` to fill `$scope.groups`:

```js
setGroups: function() {
    $scope.groups = _($scope.vm.data)
        .chain()
        .groupBy(this.indexGroupingSelected.value)
        .pairs()
        .map(function(i) {
            return {
                groupName: i[0],
                group: i[1]
            };
        })
        .value();
}
```

I need to use `pairs()` and `map()`) because the Underscore `_.groupBy()` function does *not* return an array; it returns a new object (which is weird to me—but I’m not a JavaScript scientist—see “[Underscore.js Grouping in Angular JS](http://songhayblog.azurewebsites.net/Entry/Show/underscore-js-grouping)” for more details). So, `pairs()` gives me an array that I `map()` into an object that most compatible with Angular.

My two code blocks above use `$scope.vm.indexGroupingSelected`. My use of *Selected* in the name of this View Model property makes sense when we see this Angular declaration:

<select
    data-ng-change='vm.setGroups()'
    data-ng-model="vm.indexGroupingSelected"
    data-ng-options="i as i.label for i in options">
</select>

Declaring `ng-model` in a `select` element binds the currently selected option in `$scope.options`. Again, I notice that I cannot use `$scope.vm.options`—I *have to* use `$scope.options`. In my Angular Controller, I fill my options like this:

```js
$scope.options = [{
    label: 'by Date',
    sortDescending: true,
    value: 'dateGroup'
}, {
    label: 'by Topic',
    sortDescending: false,
    value: 'topic'
}];
```

This use of `sortDescending` in the options is awesome to me. Because the Angular `orderBy` expression supports not only variables but also “dotting down” objects used as variables my life was made a bit easier. This Angular feature allows me to control sorting data in ascending or descending order *with *data.

Check out [the full CodePen](http://codepen.io/rasx/pen/XJYJye):

<!-- cSpell:disable -->

<iframe height="265" style="width: 100%;" scrolling="no" title="Songhay Studio: Day Path Index JSON" src="https://codepen.io/rasx/embed/XJYJye?height=265&theme-id=0&default-tab=js,result" frameborder="no" allowtransparency="true" allowfullscreen="true">

See the Pen <a href='https://codepen.io/rasx/pen/XJYJye'>Songhay Studio: Day Path Index JSON</a> by Bryan Wilhite
  (<a href='https://codepen.io/rasx'>@rasx</a>) on <a href='https://codepen.io'>CodePen</a>.

</iframe>

<!-- cSpell:enable -->

Or get [the GitHub gist](https://gist.github.com/BryanWilhite/4dfb1564fe88dba16625):

<script src="https://gist.github.com/BryanWilhite/4dfb1564fe88dba16625.js"></script>

My ideas about Angular grouping owe their existence to “[Group and Display Data with Underscore and AngularJS](http://odetocode.com/blogs/scott/archive/2013/08/08/group-and-display-data-with-underscore-and-angularjs.aspx)” by K. Scott Allen. I wrote a [basic grouping CodePen](http://codepen.io/rasx/pen/BjCkH) to understand what was going on there. Then, I added the ability to change the grouping with a select element in an [‘intermediate’ grouping CodePen](http://codepen.io/rasx/pen/XJJKYX?editors=101).

@[BryanWilhite](https://twitter.com/BryanWilhite)
