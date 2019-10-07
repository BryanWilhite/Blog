---json
{
  "author": "Bryan Wilhite",
  "content": "The original, default tagline for Chris Fulstow’s NBlog was, “A blog platform for the discerning .NET developer…” My translation of this is, “This Blog platform does not have a complex administration backend so you have to be a developer to properly cust...",
  "inceptDate": "2012-10-14T17:00:00-07:00",
  "isPublished": true,
  "slug": "i-ve-moved-to-nblog-away-from-blogengine-net",
  "title": "I’ve moved to NBlog, away from BlogEngine.NET"
}
---

The original, default tagline for Chris Fulstow’s [NBlog](https://github.com/ChrisFulstow/NBlog) was, “A blog platform for the discerning .NET developer…” My translation of this is, “This Blog platform does not have a complex administration backend so you have to be a developer to properly customize NBlog.” NBlog is also called “light”—it has about 360 files (for the `*.Web` project). I mention all of these things not to be what they call “snarky.” I mention these things out of true appreciation. NBlog is what I turned to when I got pissed off with the state of .NET blogging platforms and wanted to ‘build my own’—instead of starting with nothing I started with NBlog and it has a lot to teach me (especially the [OpenID](http://openid.net/) stuff).

360 files sounds like a hell of a lot but take a count of [BlogEngine.NET](http://dotnetblogengine.net/)—which I consider small (one of the smallest)—and this “innovative open source blogging platform” takes us well above a thousand. So NBlog by comparison is profoundly minimalist. These are some of the things that I immediately notice are missing from NBlog:

*   The concept of “tagging” in particular and “taxonomy” in general.
*   The ability to schedule posts.
*   Full support for HTML *and*[MarkDown](http://daringfireball.net/projects/markdown/) at the same time.

On the other hand, Chris Fulstow introduces me to some solutions that I may find useful:

*   [Squishit](https://github.com/jetheredge/SquishIt) might be the way to go when I am unable to run MVC on .NET 4.5.
*   I’ve got to see how Chris is using [Autofac](http://code.google.com/p/autofac/)—it might be doing some things <acronym title="Managed Exensibility Framework">MEF</acronym> is not giving to ASP.NET MVC.
*   And what is “[HTML5 Boilerplate](http://html5boilerplate.com/)”?

BTW: NBlog supports [DISQUS](http://disqus.com/). I don’t have is enabled for my Blog right now.

## Stuff I might take out of my copy of NBlog

I will definitely take [Quartz.net](http://quartznet.sourceforge.net/) support out of NBlog (which implies that I won’t need [SharpBox](http://sharpbox.codeplex.com/)). I actually use Quartz.net and don’t see it as “core” functionality. The [AntiXSS](http://wpl.codeplex.com/) support from Microsoft for NBlog is known to be [nothing short of a minor failure](http://eksith.wordpress.com/2012/02/13/antixss-4-2-breaks-everything/) for Microsoft. I noticed that it was mangling my <acronym title="Extensible Hypertext Markup Language">XHTML</acronym> output. I’m curious as why Chris chose Google’s [Prettify](http://code.google.com/p/google-code-prettify/) over other JavaScript syntax-highlighting solutions.

## Awesome Azure Blog Storage Support for NBlog

What is totally awesome about NBlog is its support for Windows Azure Blob Storage. “[Running NBlog on Windows Azure](http://blog.spontaneouspublicity.com/running-nblog-on-windows-azure)” from Spontaneous Publicity is a short, straight-forward note about how to set it up. This message is key:
<blockquote>

NBlog uses a repository pattern for persisting settings and blob entries. Currently it offers providers for Json file storage, Sql database, and MongoDb. I could have opted to attempt to use the Sql repository to use Sql Azure—but I like the simplicity of storing data as .json files so I chose to use Azure Blob Storage. … Getting NBlog up and running on Azure really was as simple as replacing the repository by creating one class: AzureBlobRepository. … And that is basically all of the changes needed to run NBlog on Windows Azure. I think the simplicity of this change speaks to the power of the repository pattern when used correctly.
</blockquote>

It is because NBlog is so perfectly devoted to the [Repository Pattern](http://blog.lowendahl.net/?p=249) that blob support comes so easily. This is the first time in my near-20-year career that another programmer actually made my life easier because they refused to bend the rules around a formal design pattern.

It must be mentioned that BlogEngine.NET supports Windows Azure but almost all of the documentation around this assume that we mean to use SQL Azure, which is an extravagant expense as far as I’m concerned.

## JSON-encoding snarky-ness

When I uploaded `Config.json` to Azure Blob Storage, I got Json.NET exceptions complaining about “line 1, position 1.” The fix for me was saving the JSON file in what Notepad++ calls “ANSI as UTF-8” (this format is obtained in Notepad++ via the **Encoding &gt; Encode in UTF without BOM** command). Evidently Json.NET was having BOM (Byte Order Mark) problems. I also noticed that `Config.json` was formatted with UNIX line endings—a side-effect of using GitHub.com without Phil Haack—so the BOM madness might be related to Git “goodness.”

To my typographic horror by the way, I noticed that the default, NBlog entry files were JSON in the ancient ANSI format! This explains why I had no BOM madness with these.

## NBlog is pro-MarkDown

By default NBlog assumes that you are going to write posts in MarkDown. This is the correct assumption because this engine is designed for programmers—and the typical programmer does not require the advanced typographic features of HTML that MarkDown does not support.

I had to change NBlog to use MarkDown *or* HTML—not both. [Research tells me](http://blog.stackoverflow.com/2008/06/three-markdown-gotcha/) that the people behind MarkDown made a conscious choice to only support a subset of HTML:
<blockquote>

I think this is a symptom of Markdown’s being designed for blog posts. You can paste in big chunks of foreign HTML verbatim without having to double-check them, but it’s pretty much impossible to write whole pages in Markdown. Again Gruber’s not interested; dunno about Fortin.
</blockquote>

## A brief list of changes I made to NBlog:

For my benefit (because I’m not forking on GitHub.com right about now), here are my changes:

*   I added to two configuration settings to `Web.config`: `NBlogTenantRoot` and `NBlogCloudStorage`. This was done to favor configuration over conventions about how NBlog, by default, sets up repository names/locations.
*   I refactored the Name getter in `HttpTenantSelector` to prefer the setting `NBlogTenantRoot` before falling back to defaults.
*   I refactored the constructor of `AzureBlobRepository` to use the setting `NBlogCloudStorage` for a connection string. The connection string concept may not have been available to early adopters of Windows Azure Blob Storage—and the `RoleEnvironment` concept was there instead.
*   I made a small change to `AzureBlobRepository.Save()` to explicitly set the MIME type `application/json`.

BTW: “[BlogEngine.NET and Windows Azure Web Sites](http://blogs.msdn.com/b/webdev/archive/2012/10/12/blogengine-net-and-windows-azure-web-sites.aspx)”—I find the timing of this news hilarious…
