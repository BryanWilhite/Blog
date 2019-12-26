---json
{
  "documentId": 0,
  "title": "Customizing XAML Buttons? Prepare to Repeat Yourself!",
  "documentShortName": "2012-07-25-customizing-xaml-buttons-prepare-to-repeat-yourself",
  "fileName": "index.html",
  "path": "./entry/2012-07-25-customizing-xaml-buttons-prepare-to-repeat-yourself",
  "date": "2012-07-25T23:11:00Z",
  "modificationDate": "2012-07-25T23:11:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-07-25-customizing-xaml-buttons-prepare-to-repeat-yourself",
  "tag": "{\r\n  \"extract\": \"Customizing XAML buttons in particular and XAML Controls in general almost immediately lead to violating the Don’t Repeat Yourself (DRY) principle. I am glad that I did not try to seriously customize buttons earlier in my Silverlight/WPF journey because ...\"\r\n}"
}
---

# Customizing XAML Buttons? Prepare to Repeat Yourself!

[<img alt="Vector Based Button Violating the DRY Principle" src="http://farm9.staticflickr.com/8425/7645847590_b981cb2316.jpg">](http://www.flickr.com/photos/wilhite/7645847590/in/photostream "Vector Based Button Violating the DRY Principle")

Customizing <acronym title="Extensible Application Markup Language">XAML</acronym> buttons in particular and XAML Controls in general almost immediately lead to violating the [Don’t Repeat Yourself](http://en.wikipedia.org/wiki/Don't_repeat_yourself) (DRY) principle. I am glad that I did not try to seriously customize buttons earlier in my Silverlight/<acronym title="Windows Presentation Foundation">WPF</acronym> journey because the by-design depth of this problem would have seriously discouraged me from continuing with this technology.

This violation of DRY is, to me, due to the fact that the `ControlTemplate` cannot be completely composed out of smaller, reusable resources because:

* Any Visual State Manager `Storyboard` elements cannot be shared with the `StaticResource` markup extension (and Silverlight does not support `DynamicResource`).
* The `vsm:VisualStateManager.VisualStateGroups` element cannot be shared in a `Style` (even though you can see `Setter Property="vsm:VisualState…"` in IntelliSense).
* I thought declaring `<Grid VisualStateManager.CustomVisualStateManager …>` would help but nothing came from this.

What’s long-term educational about this unpleasantness is using this experience to really, *really* learn about the differences among `Control`, `ControlTemplate`, `ContentControl` and `ContentPresenter`. So as of this morning I understand that:

* `Control` is a “useless” XAML element in Silverlight because it cannot be used (it’s an abstract class in Silverlight).
* `ContentControl` has `ContentTemplate` and `Template` properties. Explaining the differences between these two properties makes a smashing interview question (hint: one of these properties uses a `DataTemplate` for its type).
* `ControlTemplate` lives to fill the `Control.Template` property.
* `ContentControl` represents a “single piece” of visualized data—a metaphorical ‘picture’ for the `ContentPresenter` picture frame.

## Related Resources

* “[Applying VisualStateManager to both ControlTemplate and Content](http://stackoverflow.com/questions/10408788/applying-visualstatemanager-to-both-controltemplate-and-content/11642968)”
* “[Button Styles and Templates](http://msdn.microsoft.com/en-us/library/cc278069(v=vs.95).aspx)”
* “[Flat Button Styles in Silverlight](http://www.c-sharpcorner.com/Blogs/6660/flat-button-styles-in-silverlight.aspx)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
