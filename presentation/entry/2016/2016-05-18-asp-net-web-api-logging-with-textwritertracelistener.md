---json
{
  "author": "Bryan Wilhite",
  "content": "Update Web.config to this form: &lt;appSettings&gt;     &lt;add key=\"defaultTraceSourceName\" value=\"my-source\" /&gt; &lt;/appSettings&gt; &lt;system.diagnostics&gt;     &lt;sources&gt;         &lt;source name=\"my-source\"&gt;             &lt;listeners&gt;...",
  "inceptDate": "2016-05-18T22:05:52.4286047-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "asp-net-web-api-logging-with-textwritertracelistener",
  "sortOrdinal": 0,
  "tag": null,
  "title": "ASP.NET Web API logging with TextWriterTraceListener…"
}
---

Update `Web.config` to this form:


&lt;appSettings&gt;
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
&lt;/system.diagnostics&gt;
    

Install NuGet package `Microsoft.AspNet.WebApi.Tracing`.

Add this line to `WebApiConfig.Register()`:


config.EnableSystemDiagnosticsTracing();
    

Also the information in “[Compiling Conditionally with Trace and Debug](https://msdn.microsoft.com/en-us/library/aa983575(v=vs.71).aspx)” may apply.
