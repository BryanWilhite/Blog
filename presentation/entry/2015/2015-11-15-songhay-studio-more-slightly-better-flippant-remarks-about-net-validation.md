---json
{
  "author": "Bryan Wilhite",
  "content": "My previous breakthrough note about validation in .NET was written under the influence of the client-side need to implement INotifyDataErrorInfo without really paying proper respect for System.ComponentModel.DataAnnotations.Validator. I had to pay my res...",
  "inceptDate": "2015-11-15T21:55:05.7160073-08:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "songhay-studio-more-slightly-better-flippant-remarks-about-net-validation",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Songhay Studio: more, slightly-better, flippant remarks about .NET validation…"
}
---

My previous breakthrough [note about validation](http://songhayblog.azurewebsites.net/) in .NET was written under the influence of the client-side need to implement `INotifyDataErrorInfo` without really paying proper respect for `System.ComponentModel.DataAnnotations.Validator`. I had to pay my respects eventually.

Here’s my big, respectful, swaggering, flippant remark about .NET validation: a `ValidationContext` is needed to pass to `Validator.TryValidate*()` methods to yield `IEnumerable&lt;ValidationResult&gt;`. This flippant remark reveals intent. I attempted to express this intent in my new `ValidationContextExtensions` class:


<iframe class="rx-inline-frame" onload="this.style.height=this.contentDocument.body.scrollHeight +'px';" height="100%" width="100%" frameborder="0" border="0" scrolling="no" src="./Inline/GitHubGist/45b731536dbdd3938cde">
</iframe>



The `ToValidationResults()` extension methods (that yield `IEnumerable&lt;ValidationResult&gt;`) should—I repeat *should*—work with `INotifyDataErrorInfo.GetErrors()` (which works fine with `IEnumerable&lt;string&gt;`). Once I get a bit of time to verify this, it will confirm that my new `ValidationContextExtensions` class is the final piece of my Validation puzzle that works with .NET Data Annotations on the server side as well as the Client side.

I placed this new class in my Core library instead of my Data Access library because this is devoted to Model (or View Model) validation *in memory*, having nothing to do with the *access* of data across a boundary.
