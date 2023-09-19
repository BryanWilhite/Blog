---json
{
  "documentId": 0,
  "title": "Songhay Project Down to Four Code-Analysis Warnings!",
  "documentShortName": "2012-02-08-songhay-project-down-to-four-code-analysis-warnings",
  "fileName": "index.html",
  "path": "./entry/2012-02-08-songhay-project-down-to-four-code-analysis-warnings",
  "date": "2012-02-09T00:00:00Z",
  "modificationDate": "2012-02-09T00:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-02-08-songhay-project-down-to-four-code-analysis-warnings",
  "tag": "{\r\n  \"extract\": \"My Songhay project was started before .NET 2.0 (probably in the .NET 1.1 timeframe). It’s a dependency in all of my CodePlex.com projects. I started the day with over 60 warnings and whittled them down to four. Here are my notes along the way: Jeremy Jame...\"\r\n}"
}
---

# Songhay Project Down to Four Code-Analysis Warnings!

[<img alt="Songhay Project Down to Four Code-Analysis Warnings!" src="http://farm8.staticflickr.com/7039/6843864037_152398c6e7.jpg">](http://www.flickr.com/photos/wilhite/6843864037/in/photostream/ "Songhay Project Down to Four Code-Analysis Warnings!")

My `Songhay` project was started before .NET 2.0 (probably in the .NET 1.1 timeframe). It’s a dependency in *all* of [my CodePlex.com projects](http://www.codeplex.com/site/users/view/rasx). I started the day with over 60 warnings and whittled them down to *four*. Here are my notes along the way:

* Jeremy Jameson in “[CA1704 Code Analysis Warning and Using Custom Dictionaries in Visual Studio](http://blogs.msdn.com/b/jjameson/archive/2009/04/02/ca1704-code-analysis-warning-and-using-custom-dictionaries-in-visual-studio.aspx)” led me to [using a custom dictionary](http://msdn.microsoft.com/en-us/library/bb514188.aspx) for Code Analysis.
* I got a whole boat load of “[CA1059: Members should not expose certain concrete types](http://msdn.microsoft.com/en-us/library/ms182160.aspx)” errors because I return `XPathDocument` quite a bit in the `Songhay.Xml` namespace. I suppressed these using the justification directly from Microsoft: “It is safe to suppress a message from this rule if the specific functionality provided by the concrete type is required.”
* I got a metric ton of “[CA1305: Specify IFormatProvider](http://msdn.microsoft.com/en-us/library/ms182190.aspx)” warnings because I’m an ugly American (in recovery). This leads me to the topic of “[Culture-Insensitive String Operations](http://msdn.microsoft.com/en-us/library/kzwcbskc.aspx)” which is rather funny when taken out of context.
* I got one “[CA1815: Override equals and operator equals on value types](http://msdn.microsoft.com/en-us/library/ms182276.aspx)” warning. This one was awesome because it helped me learn about why `struct` types can be costly. To escape the wrath of my warning, I just changed my struct into a `static class`—this may not be the proper solution to the problem.
* Because `Songhay` is targeting .NET 2.0, I removed all of the `var` keywords in the Project. The `var` keyword came out in .NET 3.0—and I’m still nervous about compatibility with Mono (which is totally irrational). Keeping `Songhay` at .NET 2.0 is a defensive move against being economically forced into a situation where I have to work in a shop stuck in .NET 2.0—it’s a cold, cold world, baby…

Yes, `Songhay` is targeting .NET 2.0. I have another core-dependency project, `SonghayCore` (named after Microsoft’s `System.Core`) that will move ahead with the latest RTM of the .NET Framework. I’ve just ran Code Analysis on `SonghayCore`: 147 warnings—strewth!

The fresh, clean `Songhay` Project should be up on CodePlex.com in a few days—likely nestled in my [Silverlight BiggestBox](http://slbiggestbox.codeplex.com/). I have to give [a presentation](http://www.meetup.com/LA-SLUG/events/50686142/) on this ‘box’ this month so having a more solid core can’t hurt.

<https://github.com/BryanWilhite/>
