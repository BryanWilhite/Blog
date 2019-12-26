---json
{
  "documentId": 0,
  "title": "XAML: FontFamily and FontSize as Pts (points) imperatively",
  "documentShortName": "2015-01-29-xaml-fontfamily-and-fontsize-as-pts-points-imperatively",
  "fileName": "index.html",
  "path": "./entry/2015-01-29-xaml-fontfamily-and-fontsize-as-pts-points-imperatively",
  "date": "2015-01-29T08:00:00Z",
  "modificationDate": "2015-01-29T08:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-01-29-xaml-fontfamily-and-fontsize-as-pts-points-imperatively",
  "tag": "{\r\n  \"extract\": \"In XAML we see property declarations of FontFamily and FontSize like this:  FontFamily=\\\"/MyApp;component/Resources/Fonts/#MyFont\\\"  FontSize=\\\"96pt\\\"      We can express the above imperatively (or “programmatically”) in C#:  myInstance.FontFamily = new Font...\"\r\n}"
}
---

# XAML: FontFamily and FontSize as Pts (points) imperatively

In <acronym title="Extensible Application Markup Language">XAML</acronym> we see property declarations of `FontFamily` and `FontSize` like this:

```xml
FontFamily="/MyApp;component/Resources/Fonts/#MyFont"
    FontSize="96pt"
```

We can express the above imperatively (or “programmatically”) in C#:

```c#
myInstance.FontFamily = new FontFamily(new Uri("pack://application:,,,/", UriKind.Absolute), "/MyApp;component/Resources/Fonts/#MyFont");

myInstance.FontSize = (double)(new FontSizeConverter()).ConvertFrom("96pt");
```

The overload for the `FontFamily` constructor is taking a “Pack URI” that is basically saying, “Look for the font at the relative path inside the assembly of the current application.” I’ll have to experiment a bit with Pack URI syntax to point at another assembly.

The `FontSizeConverter` is new to me—which is kind of sad because it’s been around since .NET 3.0 (c. 2006).

@[BryanWilhite](https://twitter.com/BryanWilhite)
