---json
{
  "documentId": 0,
  "title": "Songhay Studio: more, slightly-better, flippant remarks about .NET validation…",
  "documentShortName": "2015-11-15-songhay-studio-more-slightly-better-flippant-remarks-about-net-validation",
  "fileName": "index.html",
  "path": "./entry/2015-11-15-songhay-studio-more-slightly-better-flippant-remarks-about-net-validation",
  "date": "2015-11-16T05:55:05.716Z",
  "modificationDate": "2015-11-16T05:55:05.716Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-11-15-songhay-studio-more-slightly-better-flippant-remarks-about-net-validation",
  "tag": "{\r\n  \"extract\": \"My previous breakthrough note about validation in .NET was written under the influence of the client-side need to implement INotifyDataErrorInfo without really paying proper respect for System.ComponentModel.DataAnnotations.Validator. I had to pay my res...\"\r\n}"
}
---

# Songhay Studio: more, slightly-better, flippant remarks about .NET validation…

My previous breakthrough [note about validation](http://songhayblog.azurewebsites.net/) in .NET was written under the influence of the client-side need to implement `INotifyDataErrorInfo` without really paying proper respect for `System.ComponentModel.DataAnnotations.Validator`. I had to pay my respects eventually.

Here’s my big, respectful, swaggering, flippant remark about .NET validation: a `ValidationContext` is needed to pass to `Validator.TryValidate*()` methods to yield `IEnumerable&lt;ValidationResult&gt;`. This flippant remark reveals intent. I attempted to express this intent in my new `ValidationContextExtensions` class:

<script src="https://gist.github.com/BryanWilhite/45b731536dbdd3938cde.js"></script>

The `ToValidationResults()` extension methods (that yield `IEnumerable&lt;ValidationResult&gt;`) should—I repeat *should*—work with `INotifyDataErrorInfo.GetErrors()` (which works fine with `IEnumerable&lt;string&gt;`). Once I get a bit of time to verify this, it will confirm that my new `ValidationContextExtensions` class is the final piece of my Validation puzzle that works with .NET Data Annotations on the server side as well as the Client side.

I placed this new class in my Core library instead of my Data Access library because this is devoted to Model (or View Model) validation *in memory*, having nothing to do with the *access* of data across a boundary.

@[BryanWilhite](https://twitter.com/BryanWilhite)
