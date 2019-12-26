---json
{
  "documentId": 0,
  "title": "Songhay.DataAccess.Runner breakthrough…",
  "documentShortName": "2012-09-21-songhaydataaccessrunner-breakthrough",
  "fileName": "index.html",
  "path": "./entry/2012-09-21-songhay-dataaccess-runner-breakthrough",
  "date": "2012-09-22T03:19:00Z",
  "modificationDate": "2012-09-22T03:19:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-09-21-songhaydataaccessrunner-breakthrough",
  "tag": "{\r\n  \"extract\": \"Some background: in 2007 this was description I wrote for my “Songhay.Data and Data Activity Runner (DAR)” project stashed on codeplex.com: This solution leverages the System.Data.Common namespace and a brief, custom XML configuration file to accomplish d...\"\r\n}"
}
---

# Songhay.DataAccess.Runner breakthrough…

Some background: in 2007 this was description I wrote for my “[Songhay.Data and Data Activity Runner (DAR)](http://songhaydata.codeplex.com/)” project stashed on codeplex.com:

<blockquote>

This solution leverages the System.Data.Common namespace and a brief, custom XML configuration file to accomplish data-access related tasks from the command line, a web application or any .NET process loading the specified interface.

</blockquote>

I actually used this tool as [an employee of UCLA](http://kintespace.com/rasxlog/?p=1742)—but it started from my need to publish data for kintespace.com and songhaysystem.com. These are very, *very* different web sites but they are based on the same database schema—these are SQL server databases. Hosting Microsoft SQL Server online back in, say, 1998 was very, *very* difficult compared to what the Linux world generously offered. (This, by the way is why I am so genuinely [excited about](http://wordwalkingstick.com/DayPath/post/2012/09/20/New-Azure-Web-Sites-Features.rasx).) So I needed a formally defined way to export data from these databases of the same ‘GenericWeb’ schema as static <acronym title="Extensible Hypertext Markup Language">XHTML</acronym> or weird stuff like exporting to SQLite for PHP. That formally defined way was DAR 1.0.

So with multiple databases with the same schema why should I write the same stored procedures for each of these databases? Why can’t I *share* these procedures among the databases in the form of Data Access Activities (.NET assemblies)? So that’s what I’ve been doing for almost 10 years—years starting before Windows Workflow Foundation was released—and probably before [Quartz.net](http://quartznet.sourceforge.net/)).

## DAR 2.0 to dynamically resolve assemblies…

So yes: DAR 1.0 is “abandoned” on codeplex.com but I am working on DAR 2.0—which is not released to the pubic yet. One of the reasons for this is because I want DAR 2.0 to dynamically resolve assemblies declared as dependencies of the Data Access *Activity* (my use of the word “activity,” by the way, comes from what eventually became the “[Workflow Activity](http://msdn.microsoft.com/en-us/library/bb863182(v=office.12).aspx)”). In DAR 1.0 I used to cheat by loading up references in the console application project to be shared among the activities called by the console application, the Data Activity *Runner* (DAR) by the way…

It’s just sloppy to have DAR load a bunch of referenced assemblies that may or may not be used by a particular Data Access Activity. But I was stuck due to debilitating ignorance. Now my ignorance allows me to write:

The article “[How the Runtime Locates Assemblies](http://msdn.microsoft.com/en-us/library/yx7xezcf.aspx)” in the .NET 4.5 timeframe informs me that the runtime uses the following steps to resolve an assembly reference:

* After a version check, determine whether the reference is already loaded so it can be used again.
* Check the Global Assembly Cache.
* Probe by [convention and configuration](http://msdn.microsoft.com/en-us/library/15hyw9x3.aspx) (with the conventional “application base” and the `probing` element in `app.config`, respectively).
* Invoke the `AppDomain.AssemblyResolve` event when all else fails.

My ignorance of the `AppDomain.AssemblyResolve` event was the blocker. The gospel from <acronym title="Microsoft Developer Network">MSDN</acronym>:

<blockquote>

It is the responsibility of the ResolveEventHandler for this event to return the assembly that is specified by the ResolveEventArgs.Name property, or to return null if the assembly is not recognized.

</blockquote>

For me, after over 15 years of .NET, this is the first event I’ve encountered that actually has a return value. Here’s a snippet that’s kind of cool to me right about now:

```c#
AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
{
    if(assemblyDictionary == null) return null;
    if(configItem.DarConfigurationItemNameValuePairs == null) return null;
    Assembly dll = null;
    var name = e.Name;
    Console.WriteLine(string.Format("Trying to resolve dependency {0}...", name));
    if(assemblyDictionary.ContainsKey(name)) dll = assemblyDictionary[name];
    return dll;
};
```

My `assemblyDictionary` object is my data-centric style in play. This object is a `Dictionary<string, Assembly>` that is loaded by DAR like this:

```c#
if(configItem.DarConfigurationItemNameValuePairs != null)
{
    assemblyDictionary = new Dictionary<string,Assembly>();
    configItem.DarConfigurationItemNameValuePairs
        .Where(i => i.Name.StartsWith("DependencyLoadFile"))
        .ForEachInEnumerable(i =>
        {
            Console.WriteLine(string.Format("Trying to load dependency {0}...", i.Value));
            var dll = Assembly.LoadFile(i.Value);
            assemblyDictionary.Add(dll.FullName, dll);
            Console.WriteLine(string.Format("Dependency loaded: {0}.", dll.FullName));
        });
}
```

So DAR starts by finding and reading the configuration item name value pairs, looking for conventional pairs named `"DependencyLoadFile"`. All of these declared dependencies are loaded and then DAR ‘waits’ for the `AppDomain.CurrentDomain.AssemblyResolve` event to fire.

@[BryanWilhite](https://twitter.com/BryanWilhite)
