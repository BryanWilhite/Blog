---json
{
  "documentId": 0,
  "title": "studio status report: 2021-07",
  "documentShortName": "2021-07-25-studio-status-report-2021-07",
  "fileName": "index.html",
  "path": "./entry/2021-07-25-studio-status-report-2021-07",
  "date": "2021-07-25T21:08:46.211Z",
  "modificationDate": "2021-07-25T21:08:46.211Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-07-25-studio-status-report-2021-07",
  "tag": "{\n  \"extract\": \"month 07 of 2021 was about moving kintespace.com to a new server and day-job drama The hosting service for kintespace.com effectively forced me to take yet another discount and move to a new Ubuntu server. The discount went from a turn-of-the-century ~$50…\"\n}"
}
---

# studio status report: 2021-07

## month 07 of 2021 was about moving kintespace.com to a new server and day-job drama

The hosting service for kintespace.com effectively forced me to take yet another discount and move to a new Ubuntu server. This new discount takes me from a turn-of-the-century ~$50/month to mid-century ~$16/month down to about $9/month today. This forced move was documented for the first time within my ‘modern’ documentation practices, making moves like this less intimidating in future.

I did not want this move to be the high-point of the month but I had to respond (yet again) to the demands of the day job. These demands were largely around building up a decent SQL-server environment on Ubuntu (my choice of OS), featuring these experiences:

- the Jupyter Notebook with a SQL kernel in Azure Data Studio [[GitHub](https://github.com/Microsoft/azuredatastudio)] 🤠
- the Jupyter Notebook with a SQL kernel (and [.NET Interactive](https://github.com/dotnet/interactive)) in Visual Studio Code 😑
- the Jupyter Notebook with the default Python (importing `pymssql` or `pyodbc`) in Visual Studio Code 😶

The best experience in my Studio is the one provided by Azure Data Studio. But I have the following statements/observations:

- Microsoft is not (yet?) separating its SQL kernel from Azure Data Studio which makes me think it is hostile to, say, allowing its kernel to be used in the wider Jupyter ecosystem.
- The Microsoft SQL Server presence in the ‘official’ [list of Jupyter kernels](https://github.com/jupyter/jupyter/wiki/Jupyter-kernels) seems to have vanished completely (or was something of my imagination).
- Running `#r "nuget:Microsoft.DotNet.Interactive.SqlServer,*-*"` in a C# Jupyter Notebook cell clearly shows Windows-specific packages (e.g. `system.windows.extensions` or `microsoft.win32.systemevents`) being installed which suggests to me that these are early days.

Even though I have no plans to run Microsoft SQL Server in my Studio, I _need_ to be able to have intimate conversations with myself about Microsoft SQL Server within my relatively new documentation system. The need for this conversation space is for the sake of the day job.

## a new release of `Songhay.Publications`

Month 07 saw a new release of `Songhay.Publications` [[NuGet](https://www.nuget.org/packages/Songhay.Publications/) 📦] for reasons surfaced in issue [#46](https://github.com/BryanWilhite/Songhay.Publications/issues/46). This move was largely to eliminate all known barriers in front of generating Publication indices, leading to the first bullet in the list below:

## sketching out a development schedule (revision 18)

The schedule of the month:

- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- build Web components required for new version of SonghaySystem.com 🖼
- complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com ✅
- add proposed [content Web component](https://github.com/BryanWilhite/songhay-web-components/issues/10)
- modernize the kinté hits page into a progressive web app 💄✨
- use the learnings of previous work to upgrade and re-release the kinté space 🚀
- use `@songhay/index` as a side-car app for “Day Path” and “the rasx() context” 🚛📦
- use the learnings from existing npm packages to build `@songhay/player-audio-???` 📦✨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
