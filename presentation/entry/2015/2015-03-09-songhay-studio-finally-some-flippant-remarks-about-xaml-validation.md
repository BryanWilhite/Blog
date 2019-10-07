---json
{
  "documentId": 0,
  "title": "Songhay Studio: finally, some flippant remarks about XAML Validation",
  "documentShortName": "2015-03-09-songhay-studio-finally-some-flippant-remarks-about-xaml-validation",
  "fileName": "index.html",
  "path": "./entry/2015-03-09-songhay-studio-finally-some-flippant-remarks-about-xaml-validation",
  "date": "2015-03-10T01:00:00.000Z",
  "modificationDate": "2015-03-10T01:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-03-09-songhay-studio-finally-some-flippant-remarks-about-xaml-validation",
  "tag": "{\r\n  \"extract\": \"I’ve been deprioritizing a look into XAML-based Validation. Years ago I somehow got the impression that Validation was “confused” or “incomplete.” Now I can say that there are two broad categories of Validation:There is Validation for System.Windows.Cont...\"\r\n}"
}
---

## Songhay Studio: finally, some flippant remarks about XAML Validation

I’ve been deprioritizing a look into <acronym title="Extensible Application Markup Language">XAML</acronym>-based Validation. Years ago I somehow got the impression that Validation was “confused” or “incomplete.” Now I can say that there are two broad categories of Validation:

* There is Validation for `System.Windows.Controls`.
* There is Validation for `System.ComponentModel.DataAnnotations` via `INotifyDataErrorInfo`.

There are probably more categories of XAML-based Validation but I flippantly consider those ‘legacy’ alternatives. My other wild assertion is that Windows-controls Validation is mutually exclusive to Component-Model Validation. For example, as of this writing, the `Validation.ClearInvalid()` or `Validation.AddErrorHandler()` methods for Windows have no effect on Component-Model errors.

The `Validation.ValidationAdornerSite` and `Validation.ValidationAdornerSiteFor` properties are almost useless to me because they *redirect* Validation adornment from, say, a `TextBox` to a `Label`. I would like to have the option of adorning one or more “sites” *including* the original `TextBox`.

I have prepared a [basic, Component-Model Validation sample](https://wpfbiggestbox.codeplex.com/SourceControl/latest) for WPF. It’s in [my BiggestBox on CodePlex](https://wpfbiggestbox.codeplex.com/):
[<img alt="Songhay BiggestBox on the Desktop - Basic Validation Sample" src="https://farm9.staticflickr.com/8734/16741944126_2e865d2c29_z_d.jpg">](https://wpfbiggestbox.codeplex.com/SourceControl/latest#Songhay.BiggestBox.Desktop.Modules.Validation/Views/BasicValidationView.xaml "Songhay BiggestBox on the Desktop - Basic Validation Sample")

I also have a LINQPad exploration of Windows-controls Validation as a GitHub Gist:

<script src="https://gist.github.com/BryanWilhite/32afb5672824160d56de.js"></script>
