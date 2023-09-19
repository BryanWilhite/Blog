---json
{
  "documentId": 0,
  "title": "Loading .NET configuration files as XDocument instances",
  "documentShortName": "2016-05-18-loading-net-configuration-files-as-xdocument-instances",
  "fileName": "index.html",
  "path": "./entry/2016-05-18-loading-net-configuration-files-as-xdocument-instances",
  "date": "2016-05-19T05:35:27.425Z",
  "modificationDate": "2016-05-19T05:35:27.425Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-05-18-loading-net-configuration-files-as-xdocument-instances",
  "tag": "{\r\n  \"extract\": \"There is the general-purpose ConfigurationManager but there is also the HTTP-context-specific WebConfigurationManager. An answer on StackOverflow.com strongly suggests that WebConfigurationManager.OpenWebConfiguration() will be needed to read settings fr...\"\r\n}"
}
---

# Loading .NET configuration files as XDocument instances

There is the general-purpose `ConfigurationManager` but there is also the HTTP-context-specific `WebConfigurationManager`. An [answer on StackOverflow.com](http://stackoverflow.com/a/6618933/22944) strongly suggests that `WebConfigurationManager.OpenWebConfiguration()` will be needed to read settings from any other `Web.config` file than the site default. This is not the case: settings appear in memory hierarchically. So a child Web app has already loaded the settings of its parent (all the way down to `machine.config`). This fact can explain why all of the [MSDN samples](https://msdn.microsoft.com/en-us/library/ms151456(v=vs.110).aspx) for `WebConfigurationManager.OpenWebConfiguration()` load `Web.config` from a *child* web app as child `Web.config` data would not already be loaded in a parent context.

Now it *is* possible to use `WebConfigurationManager.OpenWebConfiguration()` to load a config file on a remote server. But this operation is technically in the context of Remote Administration and requires enabling this feature in IIS. So this single statement requires a lot of work:

```cs
var config = WebConfigurationManager.OpenWebConfiguration(null, "dev.site.com", null, "REMOTE.ONE.AD");
```

…when all you want to do is this:

```cs
var d = XDocument.Load(@"\\REMOTE.ONE.AD\www\Web.config");
```

…which loads a remote `Web.config` file as an `XDocument` (works fine for development while running Visual Studio as Administrator as long as your account has the file permissions). This statement can be used as a last resort or a fallback when, say, `appSettings` returns null for a particular key. So your Web app can first look at the settings loaded in memory from any parent `Web.config` with the option of falling back to an `XDocument`.

This `XDocument` fallback technique looks like a replacement for the `file` attribute declaration:

```xml
<appSettings file="\\REMOTE.ONE.AD\fragments\appSettings.config" />
```

…where `appSettings.config` is *not* a full configuration file—it would have a root element `appSettings`). The [documentation](https://msdn.microsoft.com/en-us/library/ms228154(v=vs.100).aspx) for this declaration insists that the path must be relative but experience shows me that absolute paths work—even UNCs. To further summarize, distract and confuse, it must be mentioned that `file` declaration is not the same as `configSource` attribute declaration ([see MSDN](https://msdn.microsoft.com/en-us/library/system.configuration.sectioninformation.configsource(v=vs.110).aspx)).

<https://github.com/BryanWilhite/>
