---json
{
  "documentId": 0,
  "title": "ASP.NET Web API logging with TextWriterTraceListener…",
  "documentShortName": "2016-05-18-asp-net-web-api-logging-with-textwritertracelistener",
  "fileName": "index.html",
  "path": "./entry/2016-05-18-asp-net-web-api-logging-with-textwritertracelistener",
  "date": "2016-05-19T05:05:52.428Z",
  "modificationDate": "2016-05-19T05:05:52.428Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-05-18-asp-net-web-api-logging-with-textwritertracelistener",
  "tag": "{\r\n  \"extract\": \"Update Web.config to this form: &lt;appSettings&gt;     &lt;add key=\\\"defaultTraceSourceName\\\" value=\\\"my-source\\\" /&gt; &lt;/appSettings&gt; &lt;system.diagnostics&gt;     &lt;sources&gt;         &lt;source name=\\\"my-source\\\"&gt;             &lt;listeners&gt;...\"\r\n}"
}
---

# ASP.NET Web API logging with TextWriterTraceListener…

Update `Web.config` to this form:&lt;appSettings&gt;
    &lt;add key="defaultTraceSourceName" value="my-source" /&gt;
&lt;/appSettings&gt;
&lt;system.diagnostics&gt;
    &lt;sources&gt;
        &lt;source name="my-source"&gt;
            &lt;listeners&gt;
                &lt;add name="fileLogListener" /&gt;
                &lt;remove name="Default" /&gt;
            &lt;/listeners&gt;
        &lt;/source&gt;
    &lt;/sources&gt;
    &lt;sharedListeners&gt;
        &lt;add name="fileLogListener"
            initializeData="\\MyServer\logFiles\My.log"
            type="System.Diagnostics.TextWriterTraceListener"
            /&gt;
    &lt;/sharedListeners&gt;
&lt;/system.diagnostics&gt;Install NuGet package `Microsoft.AspNet.WebApi.Tracing`.

Add this line to `WebApiConfig.Register()`:config.EnableSystemDiagnosticsTracing();Also the information in “[Compiling Conditionally with Trace and Debug](https://msdn.microsoft.com/en-us/library/aa983575(v=vs.71).aspx)” may apply.

@[BryanWilhite](https://twitter.com/BryanWilhite)
