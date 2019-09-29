---json
{
  "author": "Bryan Wilhite",
  "content": "There is the general-purpose ConfigurationManager but there is also the HTTP-context-specific WebConfigurationManager. An answer on StackOverflow.com strongly suggests that WebConfigurationManager.OpenWebConfiguration() will be needed to read settings fr...",
  "inceptDate": "2016-05-18T22:35:27.4255634-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "loading-net-configuration-files-as-xdocument-instances",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Loading .NET configuration files as XDocument instances"
}
---

There is the general-purpose `ConfigurationManager` but there is also the HTTP-context-specific `WebConfigurationManager`. An [answer on StackOverflow.com](http://stackoverflow.com/a/6618933/22944) strongly suggests that `WebConfigurationManager.OpenWebConfiguration()` will be needed to read settings from any other `Web.config` file than the site default. This is not the case: settings appear in memory hierarchically. So a child Web app has already loaded the settings of its parent (all the way down to `machine.config`). This fact can explain why all of the [MSDN samples](https://msdn.microsoft.com/en-us/library/ms151456(v=vs.110).aspx) for `WebConfigurationManager.OpenWebConfiguration()` load `Web.config` from a *child* web app as child `Web.config` data would not already be loaded in a parent context.

Now it *is* possible to use `WebConfigurationManager.OpenWebConfiguration()` to load a config file on a remote server. But this operation is technically in the context of Remote Administration and requires enabling this feature in IIS. So this single statement requires a lot of work:


var config = WebConfigurationManager.OpenWebConfiguration(null, "dev.site.com", null, "REMOTE.ONE.AD");
    

…when all you want to do is this:


var d = XDocument.Load(@"\\REMOTE.ONE.AD\www\Web.config");
    

…which loads a remote `Web.config` file as an `XDocument` (works fine for development while running Visual Studio as Administrator as long as your account has the file permissions). This statement can be used as a last resort or a fallback when, say, `appSettings` returns null for a particular key. So your Web app can first look at the settings loaded in memory from any parent `Web.config` with the option of falling back to an `XDocument`.

This `XDocument` fallback technique looks like a replacement for the `file` attribute declaration:


&lt;appSettings file="\\REMOTE.ONE.AD\fragments\appSettings.config" /&gt;
    

…where `appSettings.config` is *not* a full configuration file—it would have a root element `appSettings`). The [documentation](https://msdn.microsoft.com/en-us/library/ms228154(v=vs.100).aspx) for this declaration insists that the path must be relative but experience shows me that absolute paths work—even UNCs. To further summarize, distract and confuse, it must be mentioned that `file` declaration is not the same as `configSource` attribute declaration ([see MSDN](https://msdn.microsoft.com/en-us/library/system.configuration.sectioninformation.configsource(v=vs.110).aspx)).
