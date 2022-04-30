---json
{
  "documentId": 0,
  "title": "studio status report: 2022-04",
  "documentShortName": "2022-04-29-studio-status-report-2022-04",
  "fileName": "index.html",
  "path": "./entry/2022-04-29-studio-status-report-2022-04",
  "date": "2022-04-30T01:04:23.409Z",
  "modificationDate": "2022-04-30T01:04:23.409Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-04-29-studio-status-report-2022-04",
  "tag": "{\r\n  \"extract\": \"\"\r\n}"
}
---

# studio status report: 2022-04

## month 4 of 2022 was about the greatest weakness of Blazor and more day-job learnings

There are no more known _technical_ blockers in the way of completing the  [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com. This is great news! However, the underside of this news is my discovery of the greatest weakness (to me) of Blazor: [Blazor only has one thread](https://github.com/dotnet/aspnetcore/issues/14253#issuecomment-534118256) even though [WebAssembly has more](https://web.dev/webassembly-threads/).

As of seven days ago, [Dan Roth is optimistic](https://github.com/dotnet/aspnetcore/issues/17730#issuecomment-1106583704) that Blazor will support multi-threading in a near-future release. This should prevent me from looking into things like BlazorWorker [[GitHub](https://github.com/Tewr/BlazorWorker)].

### day-job learning?

Yes, I have a new day-job after quitting the old one last month.

## sketching out a development schedule (revision 20)

The schedule of the month:

- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com 📜🚜🔨
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
