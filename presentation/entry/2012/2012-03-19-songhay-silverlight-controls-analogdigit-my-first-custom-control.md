---json
{
  "documentId": 0,
  "title": "Songhay.Silverlight.Controls.AnalogDigit, My First Custom Control",
  "documentShortName": "2012-03-19-songhay-silverlight-controls-analogdigit-my-first-custom-control",
  "fileName": "index.html",
  "path": "./entry/2012-03-19-songhay-silverlight-controls-analogdigit-my-first-custom-control",
  "date": "2012-03-19T17:49:00Z",
  "modificationDate": "2012-03-19T17:49:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-03-19-songhay-silverlight-controls-analogdigit-my-first-custom-control",
  "tag": "{\r\n  \"extract\": \"I think I now see where the term “Layout Root” comes from…I don’t think Expression Blend is built for making custom controls—which is why the User-Control concept would be needed.I can now see how an inexperienced developer can ‘hide’ too many visuals in...\"\r\n}"
}
---

# Songhay.Silverlight.Controls.AnalogDigit, My First Custom Control

[<img alt="SL BiggestBox - Rolling Analog Digit Sample" src="http://farm8.staticflickr.com/7067/6997315441_279bb52ef1.jpg">](http://wordwalkingstick.com/silverlightbiggestbox/ "SL BiggestBox - Rolling Analog Digit Sample")

* I think I now see where the term “Layout Root” comes from…
* I don’t think Expression Blend is built for making custom controls—which is why the User-Control concept would be needed.
* I can now see how an inexperienced developer can ‘hide’ too many visuals inside styles—these folks are trapped in limbo between making a custom control and using styles economically.
* Importantly, I now see the place where the Dependency Property is the indispensable star of the show! When there is the need to use a Dependency Property in a View Model there is probably a higher need for a custom control.
* I had too much trouble understanding the purpose of the Dependency Property because I looked at them through the <acronym title="Model">MVVM</acronym> lens instead of through the needs of the `Control`.
* The `TemplateBinding` declaration that we would expect to work within the scope of a UI Element does not seem to work within the scope of a `Style` Resource. I lost most of yesterday [2012-03-15] struggling with this.
* ILSpy (or a similar tool) is essential for learning from the pros (like Telerik) how custom controls are built.
* Remember all that `System.ComponentModel` stuff for tooling custom controls for WinForms? Well, here it is for <acronym title="Extensible Application Markup Language">XAML</acronym>.

As always the source code for this stuff is [at CodePlex.com](http://slbiggestbox.codeplex.com/SourceControl/BrowseLatest).

## Related Links

* “[How to get the Nth digit of an integer with bit-wise operations?](http://stackoverflow.com/questions/203854/how-to-get-the-nth-digit-of-an-integer-with-bit-wise-operations)”
* “[Silverlight 3: Template Binding vs. Relative Binding](http://blogs.msdn.com/b/marlat/archive/2009/05/13/silverlight-3-template-binding-vs-relative-binding.aspx)”
* “[Silverlight Custom Control—Number Tumbler](http://www.codeproject.com/Articles/35930/Silverlight-Custom-Control-Number-Tumbler)”

<https://github.com/BryanWilhite/>
