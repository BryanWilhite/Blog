---json
{
  "documentId": 0,
  "title": "Songhay System: the conventional way to derive a file location…",
  "documentShortName": "2016-09-29-songhay-system-the-conventional-way-to-derive-a-file-location",
  "fileName": "index.html",
  "path": "./entry/2016-09-29-songhay-system-the-conventional-way-to-derive-a-file-location",
  "date": "2016-09-30T06:18:12.242Z",
  "modificationDate": "2016-09-30T06:18:12.242Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-09-29-songhay-system-the-conventional-way-to-derive-a-file-location",
  "tag": "{\r\n  \"extract\": \"In general-purpose programming frameworks there is often not one “right” way of doing things—which can be another way of saying: we can make our own conventions. Today I am putting in writing the conventional way to derive a file “path” from a declared l...\"\r\n}"
}
---

# Songhay System: the conventional way to derive a file location…

In general-purpose programming frameworks there is often not one “right” way of doing things—which can be another way of saying: we can make our own conventions. Today I am putting in writing the conventional way to derive a file “path” from a declared location:

* Verify that the declared location is not null or empty.
* Verify that the declared location exists. When the path exists there is no need to derive a path. End.
* When the path does not exist—and the declared location is a relative path—then attempt to derive the location based on the present working directory of a specified assembly.
* Verify that the derived location exists.

Here is a C# sketch:

```cs
traceSource.TraceVerbose("looking for file: {0}...", myPath);
if (!File.Exists(myPath))
{
    var dll = Assembly.GetEntryAssembly();
    myPath = FrameworkAssemblyUtility.GetPathFromAssembly(dll, myPath);
    traceSource.TraceVerbose("looking for file (again): {0}...", myPath);
}
if (!File.Exists(myPath)) throw new FileNotFoundException("The expected file is not here.");
```

Where `FrameworkAssemblyUtility.GetPathFromAssembly()` method is part of my `SonghayCore` source code [on GitHub](https://github.com/BryanWilhite/SonghayCore/blob/master/Songhay/FrameworkAssemblyUtility.cs). It may help to mention that this utility method supports relative paths like this:

```plaintext
..\..\foo\bar\my-file.json
```

…as well as the typical ones like this:

```plaintext
\foo\bar\my-file.json
```

…and the ‘properly-formatted’ ones like this:

```plaintext
foo\bar\my-file.json
```

The parent directory characters (`..\`) are telling my utility method to move to the parent directory of the targeted assembly.

Also, should a non-relative path (a *rooted* path) be passed to `FrameworkAssemblyUtility.GetPathFromAssembly()`, an exception will be thrown so this will not work:

```plaintext
c:\foo\bar\my-file.json
```

By the way, I’ve noticed that paths like this actually work in Windows:

```plaintext
c:\foo\bar\..\..\parent\my-file.json
```

…as long as there is a folder called `\parent` *two directories* above `\bar`. I assume this must have come to Windows sometime after Windows NT. My code currently does not support this format.

<https://github.com/BryanWilhite/>
