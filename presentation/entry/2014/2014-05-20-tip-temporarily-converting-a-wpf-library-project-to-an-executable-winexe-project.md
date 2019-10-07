---json
{
  "author": "Bryan Wilhite",
  "content": "Developers that pattern after Prism can find themselves generating “modules” as Class Library projects. In Visual Studio 2012 (or earlier), when the Application &gt; Output type: is Class Library it will not be possible to add a new WindowXAML file to th...",
  "inceptDate": "2014-05-20T00:00:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "tip-temporarily-converting-a-wpf-library-project-to-an-executable-winexe-project",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Tip: Temporarily Converting a WPF Library Project to an Executable (WinExe) Project"
}
---

Developers that pattern after Prism can find themselves generating “modules” as Class Library projects. In Visual Studio 2012 (or earlier), when the **Application &gt; Output type:** is **Class Library** it will not be possible to add a new `Window`<acronym title="Extensible Application Markup Language">XAML</acronym> file to the project. The **New Item…** dialog (with the WPF node selected) will only contain the **User Control** option.

To work around this situation, select **Edit Project File** and change `OutputType` to `WinExe` (from `Library`). You may also need to add a `&lt;ProjectTypeGuids&gt;` element shown below:

<script src="https://gist.github.com/BryanWilhite/1dfd94aa4dd80de3decd.js"></script>

Surely this issue is fixed in Visual Studio 2013? Right?
