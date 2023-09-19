---json
{
  "documentId": 0,
  "title": "studio status report: 2021-04",
  "documentShortName": "2021-04-28-studio-status-report-2021-04",
  "fileName": "index.html",
  "path": "./entry/2021-04-28-studio-status-report-2021-04",
  "date": "2021-04-28T23:28:20.866Z",
  "modificationDate": "2021-04-28T23:28:20.866Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-04-28-studio-status-report-2021-04",
  "tag": "{\n  \"extract\": \"month 04 of 2021 was about prepping a Core Release and ripping the guts out of Songhay.Player The SonghayCore version 5.1.0 release is almost complete. According to me, this release is mainly about addressing System.Text.Json support but there are other m…\"\n}"
}
---

# studio status report: 2021-04

## month 04 of 2021 was about prepping a Core Release and ripping the guts out of `Songhay.Player`

The `SonghayCore` [version 5.1.0](https://github.com/BryanWilhite/SonghayCore/projects/20) release is almost complete. According to me, this release is mainly about addressing `System.Text.Json` support but there are other major improvements such as:

- [the return](https://github.com/BryanWilhite/SonghayCore/issues/54) of `ConfigurationManagerExtensions`
- moving `Songhay.Publications` discoveries down to the Core
- modernizing certain patterns (e.g. [using](https://github.com/BryanWilhite/SonghayCore/issues/114) `nameof` with `ArgumentNullException` statements)

[Last month](http://songhayblog.azurewebsites.net/entry/2021-03-30-studio-status-report-2021-03) strongly suggested that I would be working on Publications, specifically the LiteDB stuff. The herding cats bit 🐈 about software developers is a 🐈🐈 real thing! Instead, I have been stuck under the b-roll repo, `Songhay.Player`, experiencing revelations:

- most YouTube index Activities is about *querying* JSON files
- dependencies on the file-system and `Songhay.Cloud*` libraries should be removed/reduced and replaced by scripting
- `async` Activities can work from the console with an `async main` method [[docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.1/async-main)]

These revelations slightly overwhelm me with new (or previously shelved) investigations:

**The use of the [Azure Storage REST API](https://docs.microsoft.com/en-us/rest/api/storageservices/) instead of my previous `Songhay.Cloud*` work.** I see the REST API as cleaner and simpler than me taking the time to understand how Microsoft deprecated `WindowsAzure.Storage` and replaced it with `Azure.Storage.Blobs` [[GitHub](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs)] based on the assumption that this will never happen again.

**The possible use of [JMESPath](https://github.com/jdevillard/JmesPath.Net).** JMESPath looks to be better than a LINQ-based approach to projecting from JSON. [JmesPath.Net](https://github.com/jdevillard/JmesPath.Net) with `System.Text.Json` might be an immutable (functional-style), higher-performance replacement for the editing features in `Newtonsoft.Json`. Additionally, the entire `az` CLI uses the `--query` argument to [implement JMESPath](https://docs.microsoft.com/en-us/cli/azure/query-azure-cli).

## .NET 5 came to Azure Functions last month but…

>A .NET 5 function app runs in an isolated worker process. Instead of building a .NET library loaded by our host, you build a .NET console app that references a worker SDK. This brings immediate benefits: you have full control over the application’s startup and the dependencies it consumes. The new programming model also adds support for custom middleware which has been a frequently requested feature.
>
>While this isolated model for .NET brings the above benefits, it’s worth noting ==there are some features you may have utilized in previous versions that aren’t yet supported.== While the .NET isolated model supports most Azure Functions triggers and bindings, Durable Functions and rich types support are currently unavailable. Take a blob trigger for example, you are limited to passing blob content using data types that are supported in the out-of-process language worker model, which today are string, byte[], and POCO. You can still use Azure SDK types like CloudBlockBlob, but you’ll need to instantiate the SDK in your function process.
>
>[Anthony Chu](https://techcommunity.microsoft.com/t5/apps-on-azure/net-on-azure-functions-roadmap/ba-p/2197916)

## sketching out a development schedule (revision 16)

The schedule of the month:

- rebuild `Songhay.Player` Activities with zero dependencies on the file-system and `Songhay.Cloud*` libraries
- incorporate LiteDB [🐙🐈 [GitHub](https://github.com/mbdavid/litedb)] into `Songhay.Publications.KinteSpace`
- build Web components required for new version of SonghaySystem.com 🖼
- upgrade [`songhay-ng-workspace`](https://github.com/BryanWilhite/songhay-ng-workspace) to Angular latest 📦↑
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- modernize the kinté hits page into a progressive web app 💄✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- use the learnings of previous work to upgrade and re-release the kinté space 🚀

<https://github.com/BryanWilhite/>
