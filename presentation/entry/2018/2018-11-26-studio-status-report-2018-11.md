---json
{
  "documentId": 0,
  "title": "studio status report: 2018-11",
  "documentShortName": "2018-11-26-studio-status-report-2018-11",
  "fileName": "index.html",
  "path": "./entry/2018-11-26-studio-status-report-2018-11",
  "date": "2018-11-26T20:18:14.956Z",
  "modificationDate": "2018-11-26T20:18:14.956Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2018-11-26-studio-status-report-2018-11",
  "tag": "{\r\n  \"extract\": \"SonghaySystem.com is fully covered by Azure Web JobsIt would awesome to celebrate without reservation that my Songhay Dashboard will now update itself via an Azure Web Job. This is great news and the first tangible evidence of a system for the Songhay Sy...\"\r\n}"
}
---

# studio status report: 2018-11

## SonghaySystem.com is fully covered by Azure Web Jobs

It would awesome to celebrate without reservation that my Songhay Dashboard will now update itself via an Azure Web Job. This is great news and the first tangible evidence of a *system* for the Songhay System. However, as soon as I got this working, [the most bizarre, edge-case-worthy PowerShell error](https://github.com/BryanWilhite/Songhay.Dashboard/issues/43) popped up to meet my accomplishment. More to come on this as two Blog-entry issues have been proposed:

* [https://github.com/BryanWilhite/Blog/issues/4](https://github.com/BryanWilhite/Blog/issues/4)
* [https://github.com/BryanWilhite/Blog/issues/5](https://github.com/BryanWilhite/Blog/issues/5)

## Azure DevOps is cool but leaves me wanting

I would like to express my appreciation for the great work Donovan Brown and Edward Thomsonâ€”and the rest of the [extraordinary Azure DevOps team](https://abelsquidhead.com/index.php/2017/06/05/league-of-extraordinary-devops-cloud-developer-advocates/) for the recent improvements. But because of their great work I am left wanting:

* [path exclusion](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=vsts&tabs=schema#trigger) does not appear to be working with variables
* path exclusion does not appear to be working with root files and wildcards

I have [tweeted to Edward Thomson about this](https://twitter.com/BryanWilhite/status/1062869855492169728) and he says he is looking into it.

## git on Windows is not working with GitHub credentials

I am currently working around this issue by deleting old GitHub entries from the Credential Manager and using the git experience from GitHub Desktop and Visual Studio Community. From the command line, the experience looks like this:

```shell
git push
fatal: MissingMethodException encountered.
   Method not found: 'System.Threading.Tasks.Task`1<System.Net.Http.HttpResponseMessage> Microsoft.Alm.Authentication.INetwork.HttpGetAsync(Microsoft.Alm.Authentication.TargetUri, Microsoft.Alm.Authentication.NetworkRequestOptions)'.
fatal: MissingMethodException encountered.
   Method not found: 'System.Threading.Tasks.Task`1<System.Net.Http.HttpResponseMessage> Microsoft.Alm.Authentication.INetwork.HttpGetAsync(Microsoft.Alm.Authentication.TargetUri, Microsoft.Alm.Authentication.NetworkRequestOptions)'.
Username for 'https://github.com':
```

Searching the web for these error messages brings back very little. I currently assume that the ultimate solution is to switch to SSH on Windows.

<https://github.com/BryanWilhite/>
