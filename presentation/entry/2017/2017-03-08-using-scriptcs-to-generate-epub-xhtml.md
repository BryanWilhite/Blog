---json
{
  "author": "@BryanWilhite",
  "content": "I am embarrassed to admit that I was unaware that EPUB is a highly successful application of XHTMLoutside of the Web browser. It has been a standard of the IDPF for over a decade. My entry into the .NET Framework around 2003 was driven by XPathDocument.a...",
  "inceptDate": "2017-03-08T18:10:04.0213247-08:00",
  "isPublished": true,
  "itemCategory": "\"year\":2017,\"month\":\"03\",\"day\":\"08\",\"dateGroup\":\"2017\\/03\",\"topic-enterprise-data\":\"Enterprise Solutions\",\"topic-digital-production-dtp\":\"Digital Production: Desktop Publishing\",\"topic-digital-production-web\":\"Digital Production: Web\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2017-03-08-using-scriptcs-to-generate-epub-xhtml",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Using scriptcs to Generate EPUB XHTML"
}
---

<h2>Using scriptcs to Generate EPUB XHTML</h2>

I am embarrassed to admit that I was unaware that [EPUB](https://en.wikipedia.org/wiki/EPUB) is a highly successful application of [XHTML](https://en.wikipedia.org/wiki/XHTML) _outside_ of the Web browser. It has been a standard of the [IDPF](https://en.wikipedia.org/wiki/International_Digital_Publishing_Forum) for over a decade. My entry into the .NET Framework around 2003 was driven by [`XPathDocument`](https://msdn.microsoft.com/en-us/library/system.xml.xpath.xpathdocument(v=vs.110).aspx) which gave way to `XDocument` under [LINQ to XML](https://msdn.microsoft.com/en-us/library/mt693062.aspx) (around 2007). My document-centric approach to the .NET Framework (coupled with my [Desktop publishing](https://en.wikipedia.org/wiki/Desktop_publishing) background) makes me more than suited to develop a publishing pipeline for EPUB.

For my design, there were two critical elements missing for this pipeline: (i) [markdown](https://code.visualstudio.com/Docs/languages/markdown) (in the Visual Studio Code environment) and (ii) [scriptcs](http://scriptcs.net). Visual Studio Code can be regarded as a “gateway drug” to the cross-platform editing culture of Atom which inspired me (along with Git cultural influences) to see markdown as the most primitive (archival) document format for general-purpose XHTML applications (under the shadow of [SGML](https://en.wikipedia.org/wiki/Standard_Generalized_Markup_Language)). I now understand that [markdown](https://daringfireball.net/projects/markdown/syntax) is a subset of HTML, making its relationship to EPUB direct (and, by the way, I now regard EPUB as the ‘open source’ alternative to [PDF](https://en.wikipedia.org/wiki/Portable_Document_Format)).

My chosen technology to apply the XML-processing power of the .NET Framework in an open-source, cross-platform-ish way, is scriptcs. (Currently the scriptcs story on Linux is not quite there as we wait for .NET Standard and .NET Core develop.) [Glenn Block](https://github.com/glennblock) of .NET MEF fame is the main dude behind scriptcs. You can listen to Glenn talk about “The Future of ScriptCS” in [show #1110 of .NET Rocks!](https://www.dotnetrocks.com/?show=1110). One of the key takeaways from this show is seeing scriptcs as an application of [Roslyn](https://en.wikipedia.org/wiki/.NET_Compiler_Platform).

<h3>My Generate-EPUB `*.csx` script</h3>

My EPUB pipeline starts with an EPUB “seed” based on the handmade set of files from [Eric Muss-Barnes](http://www.ericmuss-barnes.com/). His video, “[How to Make an eBook EPUB File](https://www.youtube.com/watch?v=EiUMb7bgYeQ),” was an instrumental _technical_ introduction to EPUB, in full view of the real-world publishing market. Since this introduction, I do see [a GitHub repository](https://github.com/IDPF/epub3-samples), from the IDPF, full of EPUB samples. I will explore these samples and look for ways to build upon the Muss-Barnes base.

My scriptcs approach therefore is a combination of reading and editing the EPUB seed using publication metadata in a JSON file and a collection of XHTML templates. This automation starts with `generate-epub.csx`, intending to summarize the automation:

``` c#

#load "scriptcs-epub-utility.csx"
#load "scriptcs-environment-utility.csx"
#load "scriptcs-markdown-utility.csx"
#load "publication-namespaces.csx"
#load "publication-context.csx"
#load "publication-chapter.csx"
#load "publication-daisy-consortium-ncx.csx"
#load "publication-idpf-package.csx"
#load "publication-oebps-text-biography.csx"
#load "publication-oebps-text-copyright.csx"
#load "publication-oebps-text-dedication.csx"
#load "publication-oebps-text-toc.csx"

var csxRoot = EnvironmentUtility.GetScriptFolder();
var pubContext = new PublicationContext(csxRoot);
pubContext.GenerateMeta();
pubContext.GenerateChapters();
pubContext.WriteTitle();
pubContext.WriteToc();
pubContext.WriteCopyright();
pubContext.WriteBiography();
pubContext.WriteDedication();

Console.WriteLine("End of script.");

```

The screenshot below shows the layout of the EPUB assets (along with the print-publication assets) with respect to `generate-epub.csx` (in the `\scriptcs` folder) in my free, _private_ Git repository hosted by Microsoft:

<div style="text-align:center">

[![EPUB pipeline in Git repository](https://farm4.staticflickr.com/3716/32775732780_9e4cca30be_z_d.jpg "EPUB pipeline in Git repository")](https://www.flickr.com/photos/wilhite/32775732780/in/dateposted-public/)

</div>

Assuming that I have a future, I will go into detail about this intent and this layout for the EPUB pipeline in subsequent Blog posts.