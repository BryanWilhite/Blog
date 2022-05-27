---json
{
  "documentId": 0,
  "title": "studio status report: 2021-12",
  "documentShortName": "2021-12-26-studio-status-report-2021-12",
  "fileName": "index.html",
  "path": "./entry/2021-12-26-studio-status-report-2021-12",
  "date": "2021-12-26T17:52:57.659Z",
  "modificationDate": "2021-12-26T17:52:57.659Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-12-26-studio-status-report-2021-12",
  "tag": "{\n  \"extract\": \"month 12 of 2021 was about working the development schedule No new distractions for month 12: most of the non-day-job time was spent on the project associated with new version of SonghaySystem.com. This project of massive change has progressed quite smoot…\"\n}"
}
---

# studio status report: 2021-12

## month 12 of 2021 was about working the development schedule

No new distractions for month 12: most of the non-day-job time was spent on the [project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) associated with new version of SonghaySystem.com. This project of [massive change](http://songhayblog.azurewebsites.net/entry/2021-11-28-studio-status-report-2021-11) has progressed quite smoothly with only one serious challenge out there looming: running ASP.NET Kestrel as a reverse-proxy server behind Apache. This Apache stuff would be needed for that new version of kintespace.com listed in the development schedule below.

## “How To Install An ASP.NET Core In .NET 5 App On Ubuntu 20.04”

“[How To Install An ASP.NET Core In .NET 5 App On Ubuntu 20.04](https://www.roundthecode.com/dotnet/asp-net-core-web-hosting/how-to-install-an-asp-net-core-in-net-5-app-on-ubuntu-20-04)” [see companion [YouTube video](https://www.youtube.com/watch?v=fX3Lh3Y91_M) 🎥] is the Ubuntu-and-A2-hosting-specific rendention of [the official Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-6.0) around setting up that reverse proxy in Apache I have been hearing about but never *thinking* about since ASP.NET Core was released.

### first challenge: most reverse-proxy examples assume you do not want Apache to handle *any* content

>…everything under the root URL (`/`) should be mapped to the backend server at the given address…

## OBS Studio: HDMI Video Capture

In other Studio news, most of my collection of VHS tapes from mostly the 1990s is finally ready for the recycling center as [OBS Studio](https://obsproject.com/), an [HDMI Video Capture device](https://www.newegg.com/p/2CX-00AY-00001?Item=9SIAPVNBRE6028&Description=hdmi%20video%20capture&cm_re=hdmi_video%20capture-_-9SIAPVNBRE6028-_-Product&cm_sp=SP-_-213127-_-0-_-2-_-9SIAPVNBRE6028-_-hdmi%20video%20capture-_-capture|hdmi|video-_-3) and a used VCR from E-Bay worked together to digitize some content that is simply not available. I _should_ be able to write a short article around this topic somewhere in 2022.

## sketching out a development schedule (revision 20)

The schedule of the month:

- ~~build SonghaySystem.com as a first Bolero project for my Studio 🖼~~
- complete [project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) associated with new version of SonghaySystem.com 📜🚜🔨
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

@[BryanWilhite](https://twitter.com/BryanWilhite)
