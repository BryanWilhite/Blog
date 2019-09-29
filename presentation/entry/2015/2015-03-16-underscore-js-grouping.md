---json
{
  "author": "Bryan Wilhite",
  "content": "This codepen.io sample does not reveal that _.groupBy() produces an object with properties (as group names) and a second property that’s an array, representing the named group. In Chrome, I’ve seen a strong suggestion that the property names are in ascen...",
  "inceptDate": "2015-03-16T00:00:00",
  "isPublished": true,
  "slug": "underscore-js-grouping",
  "title": "Underscore.js Grouping in Angular JS"
}
---

This [codepen.io sample](http://codepen.io/rasx/pen/BjCkH) does *not* reveal that `_.groupBy()` produces *an object* with properties (as group names) and a second property that’s an array, representing the named group. In Chrome, I’ve seen a *strong suggestion* that the property names are in ascending order by default so Angular JS can display them in this ‘order’ with the object-property syntax.

    &lt;div ng-repeat="(key, value) in myObj"&gt; ... &lt;/div&gt;

But, [Angular people warn](https://docs.angularjs.org/api/ng/directive/ngRepeat) that Angular JS `orderBy` has no effect on this form:
<blockquote>

We now rely on the order returned by the browser when running for key in myObj. It seems that browsers generally follow the strategy of providing keys in the order in which they were defined, although there are exceptions…If this is not desired, the recommended workaround is to convert your object into an array that is sorted into the order that you prefer before providing it to ngRepeat. You could do this with a filter such as toArrayFilter or implement a $watch on the object yourself.
</blockquote>

To me this effectively means that Underscore JS `_.groupBy()` output is incompatible with Angular JS. So I might have rolled out of bed this morning with the assumption that I can do this:

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

So, instead of that cool object-property syntax, we have plain-old Angular verbosity (that’s easier for me to understand six months from now):

    &lt;div data-ng-repeat="i in groups | orderBy: 'groupName' : true "&gt;
        &lt;h2&gt;{{ i.groupName }}&lt;/h2&gt;
        &lt;ul&gt;
            &lt;li data-ng-repeat="j in i.group"&gt;
                {{ j.DisplayText }}
            &lt;/li&gt;
        &lt;/ul&gt;
    &lt;/div&gt;
