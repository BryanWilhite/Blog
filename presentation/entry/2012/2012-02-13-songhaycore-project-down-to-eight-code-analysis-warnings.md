---json
{
  "documentId": 0,
  "title": "SonghayCore Project Down to Eight Code Analysis Warnings!",
  "documentShortName": "2012-02-13-songhaycore-project-down-to-eight-code-analysis-warnings",
  "fileName": "index.html",
  "path": "./entry/2012-02-13-songhaycore-project-down-to-eight-code-analysis-warnings",
  "date": "2012-02-13T16:33:00.000Z",
  "modificationDate": "2012-02-13T16:33:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-02-13-songhaycore-project-down-to-eight-code-analysis-warnings",
  "tag": "{\r\n  \"extract\": \"The SonghayCore Project is essentially the .NET 4+ version of the Songhay Project. As we’ve seen in a previous episode, SonghayCore started this week with 147 Code Analysis warnings. Now, most of them have gone away. Here are the highlights: “CA1032: Impl...\"\r\n}"
}
---

# SonghayCore Project Down to Eight Code Analysis Warnings!

[<img alt="SonghayCore Project Down to Eight Code Analysis Warnings!" src="http://farm8.staticflickr.com/7055/6864575675_53809bbdc6.jpg">](http://www.flickr.com/photos/wilhite/6864575675/in/photostream/ "SonghayCore Project Down to Eight Code Analysis Warnings!")

The `SonghayCore` Project is essentially the .NET 4+ version of the Songhay Project. As we’ve seen in a previous episode, `SonghayCore` started this week with 147 Code Analysis warnings. Now, most of them have gone away. Here are the highlights:

* “[CA1032: Implement standard exception constructors](http://msdn.microsoft.com/en-us/library/ms182151.aspx)” is straightforward common sense—my ignorance deserves this warning.
* “[CA2104: Do not declare read only mutable reference types](http://msdn.microsoft.com/en-us/library/ms182302.aspx)”—this warning in my code is indicative of my lack of experience with certain embarrassingly intermediate topics. It inspires me to stay in shape with renewing study! “A mutable type is a type whose instance data can be modified. The `System.Text.StringBuilder` class is an example of a mutable reference type. It contains members that can change the value of an instance of the class.”
* “[CA1819: Properties should not return arrays](http://msdn.microsoft.com/en-us/library/0fss9skc.aspx)” came for my code because I have types (like my <acronym title="Outline Processor Markup Language">OPML</acronym> types) that need to be serialized into <acronym title="Extensible Markup Language">XML</acronym>. I suppressed this warning. This is one of these intimate topics that someone relevant from Microsoft should address. “[XmlSerialization and CA1819 Warning](http://social.msdn.microsoft.com/Forums/is/asmxandxml/thread/c29ec71d-52da-4a37-9291-fb95e28018f4)” is indicative of such intimacy.
* “[CA1056: URI properties should not be strings](http://msdn.microsoft.com/en-us/library/ms182175.aspx)” came (again) because of my OPML library and because of my support for Open Packaging Conventions <acronym title="Universal Resource Identifier">URI</acronym>s (used in Silverlight, <acronym title="Windows Presentation Foundation">WPF</acronym> and other <acronym title="Extensible Application Markup Language">XAML</acronym>-based technologies). I suppressed these.
* “[CA1308: Normalize strings to uppercase](http://msdn.microsoft.com/en-us/library/bb386042.aspx)” was suppressed because of my `ToTitleCase()` method in `Songhay.Globalization.TextInfoUtility`. My official Justification: “This member is not making a security decision based on the result.”
* “[CA1006: Do not nest generic types in member signatures](http://msdn.microsoft.com/en-us/library/ms182144.aspx)” comes a warning to me as Microsoft saying “you have bas taste”—I agree. So in shame I wrote a Collection class to avoid such nesting.

By the way, folks, that collection I wrote looks like this:

```c#
using System.Collections.ObjectModel;
namespace Songhay.Collections
{
    using Models;
    /// <summary>
    /// Wrapper Collection for <see cref="Songhay.Models.RemoteResource"/>.
    /// </summary>
    public class RemoteResourceCollection : Collection<RemoteResource>
    {
    }
}
```

Based on precious hours of research, I assume that these, scant 13 lines of code is the appropriate alternative to the quite serious business dating back to 2009 in “[Implementing IEnumerable and IEnumerator](http://brendan.enrick.com/post/Implementing-IEnumerable-and-IEnumerator.aspx).” Even farther back on the timeline, in 2007, a Microsoft MVP from Skopje, Macedonia wrote “[DecimalCollection](http://sharpsource.blogspot.com/2007/05/decimalcollection.html).” This post shows how a custom collection should be based on `CollectionBase`. However, in this part of the 21<sup>st</sup> century, `CollectionBase` is considered [obsolete](http://stackoverflow.com/questions/5704776/is-the-collectionbase-class-still-supported) under the influence of generics.

@[BryanWilhite](https://twitter.com/BryanWilhite)
