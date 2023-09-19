---json
{
  "documentId": 0,
  "title": "Angular JS and checkbox array support",
  "documentShortName": "2015-09-21-angular-js-and-checkbox-array-support",
  "fileName": "index.html",
  "path": "./entry/2015-09-21-angular-js-and-checkbox-array-support",
  "date": "2015-09-22T04:23:38.345Z",
  "modificationDate": "2015-09-22T04:23:38.345Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-09-21-angular-js-and-checkbox-array-support",
  "tag": "{\r\n  \"extract\": \"What I am seeing so far is Angular JS supporting one-way checkbox arrays—from the Model to the View via ngRepeat. There seems to be no support the other way around. So when we declare, <input name=\\\"checkSelections[]\\\" type=\\\"checkbox\\\" ng-model=\\\"foo\\\">...\"\r\n}"
}
---

# Angular JS and checkbox array support

What I am seeing so far is Angular JS supporting one-way `checkbox` arrays—from the Model to the View via `ngRepeat`. There seems to be no support the other way around. So when we declare, `<input name="checkSelections[]" type="checkbox" ng-model="foo">`, Angular JS does not see the `checkSelection[]` array syntax and assumes `foo` is an array.

To further confuse ourselves, we could do something like this:

```html
<input name="checkSelections[]" type="checkbox" ng-model="foo[0]">
<input name="checkSelections[]" type="checkbox" ng-model="foo[1]">
<input name="checkSelections[]" type="checkbox" ng-model="foo[2]">
```

Clicking on the second `checkbox`, would give us something almost useless: `foo = {"1" : true }`. To declare `ngTrueValue` or `ngFalseValue`, by the way, would cause an error. Any traditional `value="bar"` declarations are ignored.

Apart from the confusion mentioned, it looks like Angular JS 1.x has no support for checkbox arrays (groups)—which has had server-side support for decades. It would not surprise me to find that none of the client-side frameworks has support for it out of the box.

## Related Links

* `ng-true-value` and `ng-false-value` for Angular check boxes [[docs.angularjs.org](https://docs.angularjs.org/api/ng/input/input[checkbox])]
* AngularJS Form Validation with `ngMessages` [[scotch.io]](https://scotch.io/tutorials/angularjs-form-validation-with-ngmessages)
* Handling Checkboxes and Radio Buttons in Angular Forms [[scotch.io]](https://scotch.io/tutorials/handling-checkboxes-and-radio-buttons-in-angular-forms)

<https://github.com/BryanWilhite/>
