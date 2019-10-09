---json
{
  "documentId": 0,
  "title": "Tip: Temporarily Converting a WPF Library Project to an Executable (WinExe) Project",
  "documentShortName": "2014-05-20-tip-temporarily-converting-a-wpf-library-project-to-an-executable-winexe-project",
  "fileName": "index.html",
  "path": "./entry/2014-05-20-tip-temporarily-converting-a-wpf-library-project-to-an-executable-winexe-project",
  "date": "2014-05-20T07:00:00.000Z",
  "modificationDate": "2014-05-20T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-05-20-tip-temporarily-converting-a-wpf-library-project-to-an-executable-winexe-project",
  "tag": "{\r\n  \"extract\": \"Developers that pattern after Prism can find themselves generating “modules” as Class Library projects. In Visual Studio 2012 (or earlier), when the Application > Output type: is Class Library it will not be possible to add a new WindowXAML file to th...\"\r\n}"
}
---

# Tip: Temporarily Converting a WPF Library Project to an Executable (WinExe) Project

Developers that pattern after Prism can find themselves generating “modules” as Class Library projects. In Visual Studio 2012 (or earlier), when the **Application > Output type:** is **Class Library** it will not be possible to add a new `Window`<acronym title="Extensible Application Markup Language">XAML</acronym> file to the project. The **New Item…** dialog (with the WPF node selected) will only contain the **User Control** option.

To work around this situation, select **Edit Project File** and change `OutputType` to `WinExe` (from `Library`). You may also need to add a `<ProjectTypeGuids>` element shown below:

<script src="https://gist.github.com/BryanWilhite/1dfd94aa4dd80de3decd.js"></script>

Surely this issue is fixed in Visual Studio 2013? Right?

@[BryanWilhite](https://twitter.com/BryanWilhite)
