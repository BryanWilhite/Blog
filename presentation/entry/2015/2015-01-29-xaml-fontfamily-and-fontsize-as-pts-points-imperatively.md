---json
{
  "author": "Bryan Wilhite",
  "content": "In XAML we see property declarations of FontFamily and FontSize like this:\r\nFontFamily=\"/MyApp;component/Resources/Fonts/#MyFont\"\r\nFontSize=\"96pt\"\r\n    We can express the above imperatively (or “programmatically”) in C#:\r\nmyInstance.FontFamily = new Font...",
  "inceptDate": "2015-01-29T00:00:00",
  "isPublished": true,
  "slug": "xaml-fontfamily-and-fontsize-as-pts-points-imperatively",
  "title": "XAML: FontFamily and FontSize as Pts (points) imperatively"
}
---

In <acronym title="Extensible Application Markup Language">XAML</acronym> we see property declarations of `FontFamily` and `FontSize` like this:

    FontFamily="/MyApp;component/Resources/Fonts/#MyFont"
    FontSize="96pt"

We can express the above imperatively (or “programmatically”) in C#:

    myInstance.FontFamily = new FontFamily(new Uri("pack://application:,,,/", UriKind.Absolute), "/MyApp;component/Resources/Fonts/#MyFont");

    myInstance.FontSize = (double)(new FontSizeConverter()).ConvertFrom("96pt");

The overload for the `FontFamily` constructor is taking a “Pack URI” that is basically saying, “Look for the font at the relative path inside the assembly of the current application.” I’ll have to experiment a bit with Pack URI syntax to point at another assembly.

The `FontSizeConverter` is new to me—which is kind of sad because it’s been around since .NET 3.0 (c. 2006).
