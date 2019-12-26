---json
{
  "documentId": 0,
  "title": "Underscore.js Grouping in Angular JS",
  "documentShortName": "2015-03-16-underscore-js-grouping",
  "fileName": "index.html",
  "path": "./entry/2015-03-16-underscore-js-grouping-in-angular-js",
  "date": "2015-03-16T07:00:00Z",
  "modificationDate": "2015-03-16T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-03-16-underscore-js-grouping",
  "tag": "{\r\n  \"extract\": \"This codepen.io sample does not reveal that _.groupBy() produces an object with properties (as group names) and a second property that’s an array, representing the named group. In Chrome, I’ve seen a strong suggestion that the property names are in ascen...\"\r\n}"
}
---

# Underscore.js Grouping in Angular JS

This [codepen.io sample](http://codepen.io/rasx/pen/BjCkH) does *not* reveal that `_.groupBy()` produces *an object* with properties (as group names) and a second property that’s an array, representing the named group. In Chrome, I’ve seen a *strong suggestion* that the property names are in ascending order by default so Angular JS can display them in this ‘order’ with the object-property syntax.

```html
<div ng-repeat="(key, value) in myObj"> ... </div>
```

But, [Angular people warn](https://docs.angularjs.org/api/ng/directive/ngRepeat) that Angular JS `orderBy` has no effect on this form:

<blockquote>

We now rely on the order returned by the browser when running for key in myObj. It seems that browsers generally follow the strategy of providing keys in the order in which they were defined, although there are exceptions…If this is not desired, the recommended workaround is to convert your object into an array that is sorted into the order that you prefer before providing it to ngRepeat. You could do this with a filter such as toArrayFilter or implement a $watch on the object yourself.

</blockquote>

To me this effectively means that Underscore JS `_.groupBy()` output is incompatible with Angular JS. So I might have rolled out of bed this morning with the assumption that I can do this:

```javascript
$scope.groups = _($scope.vm.data)
        .groupBy(this.indexGroupingSelected.value);

…when, in fact (after a many, *many* hours of experimenting), I retreat to this:

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
```

So, instead of that cool object-property syntax, we have plain-old Angular verbosity (that’s easier for me to understand six months from now):

```html
<div data-ng-repeat="i in groups | orderBy: 'groupName' : true ">
    <h2>{{ i.groupName }}</h2>
    <ul>
        <li data-ng-repeat="j in i.group">
            {{ j.DisplayText }}
        </li>
    </ul>
</div>
```

@[BryanWilhite](https://twitter.com/BryanWilhite)
