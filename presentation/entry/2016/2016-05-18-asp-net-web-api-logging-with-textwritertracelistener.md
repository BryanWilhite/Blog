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
  "tag": "{\r\n  \"extract\": \"Update Web.config to this form: <appSettings>     <add key=\\\"defaultTraceSourceName\\\" value=\\\"my-source\\\" /> </appSettings> <system.diagnostics>     <sources>         <source name=\\\"my-source\\\">             <listeners>...\"\r\n}"
}
---

# ASP.NET Web API logging with TextWriterTraceListener…

Update `Web.config` to this form:

```xml
<appSettings>
    <add key="defaultTraceSourceName" value="my-source" />
</appSettings>
<system.diagnostics>
    <sources>
        <source name="my-source">
            <listeners>
                <add name="fileLogListener" />
                <remove name="Default" />
            </listeners>
        </source>
    </sources>
    <sharedListeners>
        <add name="fileLogListener"
            initializeData="\\MyServer\logFiles\My.log"
            type="System.Diagnostics.TextWriterTraceListener"
            />
    </sharedListeners>
</system.diagnostics>
```

Install NuGet package `Microsoft.AspNet.WebApi.Tracing`.

Add this line to `WebApiConfig.Register()`:

```c#
config.EnableSystemDiagnosticsTracing();
```

Also the information in “[Compiling Conditionally with Trace and Debug](https://msdn.microsoft.com/en-us/library/aa983575(v=vs.71).aspx)” may apply.

@[BryanWilhite](https://twitter.com/BryanWilhite)
