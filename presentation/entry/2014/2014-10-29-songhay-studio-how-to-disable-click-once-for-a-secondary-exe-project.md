---json
{
  "documentId": 0,
  "title": "Songhay Studio: How to disable Click Once for a Secondary .EXE Project",
  "documentShortName": "2014-10-29-songhay-studio-how-to-disable-click-once-for-a-secondary-exe-project",
  "fileName": "index.html",
  "path": "./entry/2014-10-29-songhay-studio-how-to-disable-click-once-for-a-secondary-exe-project",
  "date": "2014-10-29T07:00:00.000Z",
  "modificationDate": "2014-10-29T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-10-29-songhay-studio-how-to-disable-click-once-for-a-secondary-exe-project",
  "tag": "{\r\n  \"extract\": \"An automated build system can depend on a ClickOnce-configured *.csproj file—often it expects to see one ClickOnce project by convention. When it fails to see this convention there might be an error like this:  08:30:46,569 INFO  - C:\\\\Windows\\\\Microsoft.N...\"\r\n}"
}
---

# Songhay Studio: How to disable Click Once for a Secondary .EXE Project

An automated build system can depend on a ClickOnce-configured `*.csproj` file—often it expects to see one ClickOnce project by convention. When it fails to see this convention there might be an error like this:

```console
08:30:46,569 INFO  - C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft.Common.targets(4426,5): error MSB3030: Could not copy the file "bin\Release\Desktop.exe.manifest" because it was not found. [Desktop.csproj]
    08:30:46,569 INFO  -
    08:30:46,569 INFO  - 0 Warning(s)
    08:30:46,569 INFO  - 1 Error(s)
    08:30:46,569 INFO  -
    08:30:46,569 INFO  - Time Elapsed 00:00:24.44
    08:30:46,577 ERROR - ERR: BUILD FAILED. Please refer to compiler log for debug info...Exiting.
```

A secondary EXE project is causing the error. In Visual Studio its `*.csproj` file must be configured to disable ClickOnce:

Under Project Properties:

* Select **Application &gt; Icon and manifest &gt; Manifest:** Create application without a manifest
* Select **Publish &gt; Install Mode and Settings &gt; The application is available online only**
* Deselect **Publish &gt; Options… &gt; Deployment &gt; Open deployment web page after publish**
* Deselect **Publish &gt; Options… &gt; Deployment &gt; Use ".deploy" file extension**

Disable any other Deployment Publish Options.

@[BryanWilhite](https://twitter.com/BryanWilhite)
