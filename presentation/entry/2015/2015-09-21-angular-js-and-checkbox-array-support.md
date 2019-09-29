---json
{
  "author": "Bryan Wilhite",
  "content": "What I am seeing so far is Angular JS supporting one-way checkbox arrays—from the Model to the View via ngRepeat. There seems to be no support the other way around. So when we declare, &lt;input name=\"checkSelections[]\" type=\"checkbox\" ng-model=\"foo\"&gt;...",
  "inceptDate": "2015-09-21T21:23:38.3456817-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "angular-js-and-checkbox-array-support",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Angular JS and checkbox array support"
}
---

What I am seeing so far is Angular JS supporting one-way `checkbox` arrays—from the Model to the View via `ngRepeat`. There seems to be no support the other way around. So when we declare, `&lt;input name="checkSelections[]" type="checkbox" ng-model="foo"&gt;`, Angular JS does not see the `checkSelection[]` array syntax and assumes `foo` is an array.

To further confuse ourselves, we could do something like this:


&lt;input name="checkSelections[]" type="checkbox" ng-model="foo[0]"&gt;
&lt;input name="checkSelections[]" type="checkbox" ng-model="foo[1]"&gt;
&lt;input name="checkSelections[]" type="checkbox" ng-model="foo[2]"&gt;
    

Clicking on the second `checkbox`, would give us something almost useless: `foo = {"1" : true }`. To declare `ngTrueValue` or `ngFalseValue`, by the way, would cause an error. Any traditional `value="bar"` declarations are ignored.

Apart from the confusion mentioned, it looks like Angular JS 1.x has no support for checkbox arrays (groups)—which has had server-side support for decades. It would not surprise me to find that none of the client-side frameworks has support for it out of the box.

### Related Links

*   `ng-true-value` and `ng-false-value` for Angular check boxes [[docs.angularjs.org](https://docs.angularjs.org/api/ng/input/input[checkbox])]
        
*   AngularJS Form Validation with `ngMessages` [[scotch.io]](https://scotch.io/tutorials/angularjs-form-validation-with-ngmessages)
*   Handling Checkboxes and Radio Buttons in Angular Forms [[scotch.io]](https://scotch.io/tutorials/handling-checkboxes-and-radio-buttons-in-angular-forms)
