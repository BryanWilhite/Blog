---json
{
  "documentId": 0,
  "title": "Songhay Studio: getting back to tf.exe",
  "documentShortName": "2015-03-24-songhay-studio-getting-back-to-tf-exe",
  "fileName": "index.html",
  "path": "./entry/2015-03-24-songhay-studio-getting-back-to-tf-exe",
  "date": "2015-03-24T07:00:00.000Z",
  "modificationDate": "2015-03-24T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-03-24-songhay-studio-getting-back-to-tf-exe",
  "tag": "{\r\n  \"extract\": \"I’ve not used tf.exe, of the “Command-line tools for TFS,” since I lost my virtual machines in 2012. So I’ll leave a note-to-self so it won’t take so long, having taken some time today to think about and need this. For my custom shell, I need to add a pa...\"\r\n}"
}
---

# Songhay Studio: getting back to tf.exe

I’ve not used tf.exe, of the “[Command-line tools for TFS](https://msdn.microsoft.com/en-us/library/ms253088.aspx),” since I lost my virtual machines [in 2012](http://songhayblog.azurewebsites.net/Entry/Show/the-songhay-home-drive-on-a-new-vm). So I’ll leave a note-to-self so it won’t take so long, having taken some time today to think about and need this. For my custom shell, I need to add a path to TFS:

```plaintext
@set PATH=^
    …
    %ProgramFiles(x86)%\Microsoft Visual Studio 12.0\Common7\IDE;^
    …;
```

These are the commands I’ll need (as I tend to forget them for lack of daily use):

* The equivalent to **Pending Changes** in Visual Studio Team Explorer: `tf status`.
* Check-in with comment: `tf checkin /comment:"my comment"`.
* MSDN support: `tf msdn [command]`.

I did notice today that `tf status` makes no distinction between promoted/un-promoted items. I do recall doing some TFS management/reporting from (strangely enough) Visual Studio integration tests (`vstest`). In those days, I had to hunt around for TFS libraries. Now [we have NuGet](http://www.nuget.org/packages/Microsoft.TeamFoundation.Common/) Package `Microsoft.TeamFoundation.Common`.

I do remind myself that there exists [Microsoft Visual Studio Team Foundation Server 2013 Power Tools](https://visualstudiogallery.msdn.microsoft.com/f017b10c-02b4-4d6d-9845-58a06545627f). I’ve used earlier versions of such “Power Tools”; I’ve no call for this right now.

I’ll need another note for my [Slick SVN](https://sliksvn.com/support-category/sliksvn-client/) hooks into my CodePlex stuff!

@[BryanWilhite](https://twitter.com/BryanWilhite)
