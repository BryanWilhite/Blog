---json
{
  "author": "@BryanWilhite",
  "content": "One of Glenn Block’s post-MEF, post-Microsoft projects is scriptcs. I am currently using scriptcs as the engine of my epub publication pipeline in an effort to use my C# skills and delay (again) the need for me to learn/use Python.scriptcs is useful to m...",
  "inceptDate": "2017-01-25T19:01:43.8300043-08:00",
  "isPublished": true,
  "itemCategory": "\"year\":2017,\"month\":\"01\",\"day\":\"25\",\"dateGroup\":\"2017\\/01\",\"topic-enterprise-data\":\"Enterprise Solutions\"",
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "2017-01-25-first-encounter-with-scriptcs-scriptcsnet",
  "sortOrdinal": 0,
  "tag": null,
  "title": "First Encounter with scriptcs =&gt; @scriptcsnet"
}
---

# First Encounter with scriptcs => @scriptcsnet

One of [Glenn Block’s](https://www.dotnetrocks.com/?show=1110) post-MEF, post-Microsoft projects is [scriptcs](http://scriptcs.net/). I am currently using scriptcs as the engine of my epub publication pipeline in an effort to use my C# skills and delay (again) the need for me to learn/use Python.

scriptcs is useful to me when it just works on Windows _and_ Linux. I understand now that I am asking for a tall order because _my_ Linux world is split between mono and .NET Core (in serious need of .NET Standard compliance) and scriptcs is trying to live in this world.

**The current scriptcs release has no concept of “present working directory.”** Glenn (?) let me know [via @scriptcsnet](https://twitter.com/scriptcsnet/status/822746581761859584) that “it’s coming in 0.17.0, avail in our dev branch…” I wrote a workaround that Glenn is _not_ impressed with `EnvironmentUtilities.GetScriptFolder()`, interrogating command-line arguments:

```c#
using System.IO;

public static class EnvironmentUtilities
{
    public static void ExitWithError(string errorMessage, int errorNumber=1)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
        }
        finally
        {
            Console.ResetColor();
            Environment.Exit(errorNumber);
        }
    }

    public static string GetScriptFolder()
    {
        var pathToScript = Environment
            .GetCommandLineArgs()
            .FirstOrDefault(i => i.EndsWith(".csx"));
        if(pathToScript == null)
            throw new Exception("GetScriptFolder(): The expected command-line argument is not here.");

        pathToScript = Path.GetFullPath(pathToScript);
        var folder = Path.GetDirectoryName(pathToScript);
        Console.WriteLine("GetScriptFolder(): script folder: {0}", folder);

        return folder;
    }
}

```

**The current scriptcs release cannot handle NuGet 3.x.** Glenn informed me [via @scriptcsnet](https://twitter.com/scriptcsnet/status/824083354249105412) that a fix for this should be on the dev branch. This issue exists for me on both Windows and Linux (and I am using the dev branch on Linux.) I have a horrible workaround for this that involves raiding NuGet package folders (under C# projects) for .NET Standard-ish DLLs and shoving them into a `\scriptcs-bin` folder, allowing me to use the Rosyln-derived `#r` directive. Here is my ‘loader’ script, chock full of these directives:

```c#
#r "Newtonsoft.Json.dll"
#r "System.IO"
#r "System.Runtime.dll"
#r "Markdig.dll"

#load "scriptcs-environment-utilities.csx"
#load "publication-context.csx"
#load "publication-chapter.csx"

var csxRoot = EnvironmentUtilities.GetScriptFolder();
var pubContext = new PublicationContext(csxRoot);
pubContext.GenerateChapters();

```

**scriptcs or Rosyln cannot properly parse classes with private members on Linux.** A class as simple as the following will not ‘compile’ (or interpret) properly on Linux:

```c#
public class Foo
{
    public string Fubar { get; set; }

    string _foo;
}

```

I kept getting an `ArgumentOutOfRangeException` error message that can easily make one think of a simple runtime array index problem. But the catch is the error throws during initialization/interpretation time (which suggests to me that Rosyln is having trouble parsing something).

I saw the error go away when I did this:

```c#
public class Foo
{
    public string Fubar { get; set; }

    internal string _foo;
}

```

but _not_ this:

```c#
public class Foo
{
    public string Fubar { get; set; }

    private string _foo;
}

```

I want to say that the Rosyln I am using on Linux is from mono.

## Related Links

* “[Building on Mac and Linux](https://github.com/scriptcs/scriptcs/wiki/Building-on-Mac-and-Linux)”
* “[Installing svm on Linux](https://github.com/scriptcs-contrib/svm/wiki/Installing%20svm%20on%20Linux)”
* “[Recently the decision was made to aim for a 1.0 release including… [possibly] Running on .NET core](https://github.com/scriptcs/scriptcs/wiki/1.0)”
* “[Roslyn scripting on CoreCLR (.NET CLI and DNX) and in memory assemblies](http://www.strathweb.com/2016/03/roslyn-scripting-on-coreclr-net-cli-and-dnx-and-in-memory-assemblies/)”
* “[Running C# scripts and snippets in Visual Studio Code with scriptcs](http://www.strathweb.com/2015/11/running-c-scripts-and-snippets-in-visual-studio-code-with-scriptcs/)”