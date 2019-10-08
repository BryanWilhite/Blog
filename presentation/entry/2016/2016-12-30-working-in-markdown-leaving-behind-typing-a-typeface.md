---json
{
  "documentId": 0,
  "title": "Working in markdown, leaving behind typing a typeface…",
  "documentShortName": "2016-12-30-working-in-markdown-leaving-behind-typing-a-typeface",
  "fileName": "index.html",
  "path": "./entry/2016-12-30-working-in-markdown-leaving-behind-typing-a-typeface",
  "date": "2016-12-30T21:38:46.899Z",
  "modificationDate": "2016-12-30T21:38:46.899Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-12-30-working-in-markdown-leaving-behind-typing-a-typeface",
  "tag": "{\r\n  \"extract\": \"Markdown has been around since 2004. GitHub has been around since 2009. Visual Studio Code has been around since 2015. So it kind of makes sense to me that I can take these three things and finally decide I have enough stuff to move out of Microsoft Word...\"\r\n}"
}
---

# Working in markdown, leaving behind typing a typeface…

[Markdown](https://en.wikipedia.org/wiki/Markdown#History) has been around since 2004. [GitHub](https://en.wikipedia.org/wiki/GitHub#History) has been around since 2009. [Visual Studio Code](https://en.wikipedia.org/wiki/Visual_Studio_Code#History) has been around since 2015. So it kind of makes sense to me that I can take these three things and finally decide I have enough stuff to move out of Microsoft Word in 2017.

From an aesthetic point of view, Microsoft Word gave me the beauty of typing a typeface in real time, giving me the 1980s-era, grand illusion of laying out a *print document*. This would be the first pleasurable thing lost when moving to a typical Markdown editor. From a technical point of view, there may be edge cases where Microsoft Word towers over a typical Markdown editor. In 2017, I look forward to finding them.

Microsoft Word falls down flat when it comes to long-term archival storage. The [Office Open XML](https://en.wikipedia.org/wiki/Office_Open_XML) format is profoundly verbose—and, again, I look forward to finding out that Markdown cannot effectively replace it. Right off the bat, Markdown does not natively support the concept of attributes. My work with Microsoft Word for example shows how Word styles can be used to generate `class` attribute in HTML. The Daring Fireball crew themselves [say](https://daringfireball.net/projects/markdown/syntax#html), “For any markup that is not covered by Markdown’s syntax, you simply use HTML itself.”

Marius Schulz [reminds me](https://blog.mariusschulz.com/2015/10/11/parsing-markdown-in-net) that the .NET framework has `CommonMark.NET`, a [NuGet package](https://www.nuget.org/packages/CommonMark.NET/) (from 2014) ready for me translate a folder full of `*.md` files into HTML (it does not convert HTML into Markdown—which make sense *by definition* since Markdown is a *subset* of HTML). This encourages me to set up Git repos for my blog posts and other writing projects (the popular e-reader formats out there are HTML formats so working from Markdown positions closer to these formats).

[Pandoc](http://pandoc.org/MANUAL.html), by the way, provides this command:

<code class="language-bash">pandoc test.html -o test.md --parse-raw
<
/code>

This is an attempt to convert HTML to Markdown. I have not tried this bit yet. As of this writing, the HTML you see in [this post is generated from markdown in my GitHub repository](https://github.com/BryanWilhite/Blog/blob/master/2016-12/Working%20in%20markdown%2C%20leaving%20behind%20typing%20a%20typeface.md).

@[BryanWilhite](https://twitter.com/BryanWilhite)
