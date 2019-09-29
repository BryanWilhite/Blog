---json
{
  "author": "@BryanWilhite",
  "content": "Went with .NET Standard 1.2. These are the consequences:The System.Security.Cryptography namespace is not supported in .NET Standard 1.2. The System.Security.Cryptography.Algorithms NuGet package is supported from .NET Standard 1.3 (.NET 4.6) onwards.The...",
  "inceptDate": "2016-10-12T21:50:27.4713391-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "songhay-studio-net-standard-with-songhay-standard-core",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Songhay Studio: .NET Standard with Songhay.Standard.Core"
}
---

[<img alt="Introducing .NET Standard" src="https://farm6.staticflickr.com/5519/29639839953_5f0fe95381_z_d.jpg">](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/ "Introducing .NET Standard")

Went with .NET Standard 1.2. These are the consequences:

*   The `System.Security.Cryptography` namespace is not supported in .NET Standard 1.2. The `System.Security.Cryptography.Algorithms` NuGet [package](https://www.nuget.org/packages/System.Security.Cryptography.Algorithms/) is supported from .NET Standard 1.3 (.NET 4.6) onwards.
*   The `TraceSource` object is not supported in .NET Standard 1.2. The `System.Diagnostics.TraceSource `NuGet [package](https://www.nuget.org/packages/System.Diagnostics.TraceSource/) is supported from .NET Standard 1.3 (.NET 4.6) onwards.
*   The XPath concept and the `XPathNavigator` regime is over in .NET Standard.

I have been listening to Immo Landwerth (and [corresponding with him](https://twitter.com/BryanWilhite/status/785944202525814784) over Twitter) and the highlights are these:

*   To support .NET 4.5 (without `System.Security.Cryptography`, `System.Diagnostics.TraceSource`, etc.) use .NET Standard 1.2.
*   To support .NET 4.6.1 (with packages for `System.Security.Cryptography`, `System.Diagnostics.TraceSource`, etc. but no Windows Desktop (UWP only)) use .NET Standard 1.4.

According to [Channel 9](https://channel9.msdn.com/Blogs/Seth-Juarez/What-is-NET-Standard) and [YouTube](https://www.youtube.com/watch?v=eCEczPk0qkc) videos I’ve watched from Microsoft, we should skip over 1.5 and 1.6 (to avoid breaking changes) to .NET Standard 2.0 when we need to go beyond .NET Standard 1.4. Immo Landwerth says that .NET Standard 1.x is a subset of .NET Core and 2.0 represents “taking a step back” and incorporating as many platforms (including Xamarin) into a standard.
