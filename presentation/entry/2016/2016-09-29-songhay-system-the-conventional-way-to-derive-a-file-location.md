---json
{
  "author": "@BryanWilhite",
  "content": "In general-purpose programming frameworks there is often not one “right” way of doing things—which can be another way of saying: we can make our own conventions. Today I am putting in writing the conventional way to derive a file “path” from a declared l...",
  "inceptDate": "2016-09-29T23:18:12.2427275-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "songhay-system-the-conventional-way-to-derive-a-file-location",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Songhay System: the conventional way to derive a file location…"
}
---

In general-purpose programming frameworks there is often not one “right” way of doing things—which can be another way of saying: we can make our own conventions. Today I am putting in writing the conventional way to derive a file “path” from a declared location:

*   Verify that the declared location is not null or empty.
*   Verify that the declared location exists. When the path exists there is no need to derive a path. End.
*   When the path does not exist—and the declared location is a relative path—then attempt to derive the location based on the present working directory of a specified assembly.
*   Verify that the derived location exists.

Here is a C# sketch:


traceSource.TraceVerbose("looking for file: {0}...", myPath);
if (!File.Exists(myPath))
{
    var dll = Assembly.GetEntryAssembly();
    myPath = FrameworkAssemblyUtility.GetPathFromAssembly(dll, myPath);
    traceSource.TraceVerbose("looking for file (again): {0}...", myPath);
}
if (!File.Exists(myPath)) throw new FileNotFoundException("The expected file is not here.");
    

Where `FrameworkAssemblyUtility.GetPathFromAssembly()` method is part of my `SonghayCore` source code [on GitHub](https://github.com/BryanWilhite/SonghayCore/blob/master/Songhay/FrameworkAssemblyUtility.cs). It may help to mention that this utility method supports relative paths like this:


..\..\foo\bar\my-file.json
    

…as well as the typical ones like this:


\foo\bar\my-file.json
    

…and the ‘properly-formatted’ ones like this:


foo\bar\my-file.json
    

The parent directory characters (`..\`) are telling my utility method to move to the parent directory of the targeted assembly.

Also, should a non-relative path (a *rooted* path) be passed to `FrameworkAssemblyUtility.GetPathFromAssembly()`, an exception will be thrown so this will not work:


c:\foo\bar\my-file.json
    

By the way, I’ve noticed that paths like this actually work in Windows:


c:\foo\bar\..\..\parent\my-file.json
    

…as long as there is a folder called `\parent` *two directories* above `\bar`. I assume this must have come to Windows sometime after Windows NT. My code currently does not support this format.
