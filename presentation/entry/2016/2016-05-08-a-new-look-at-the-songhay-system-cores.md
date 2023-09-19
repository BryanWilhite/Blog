---json
{
  "documentId": 0,
  "title": "A new look at the Songhay System ‘cores’",
  "documentShortName": "2016-05-08-a-new-look-at-the-songhay-system-cores",
  "fileName": "index.html",
  "path": "./entry/2016-05-08-a-new-look-at-the-songhay-system-cores",
  "date": "2016-05-09T03:24:58.517Z",
  "modificationDate": "2016-05-09T03:24:58.517Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-05-08-a-new-look-at-the-songhay-system-cores",
  "tag": "{\r\n  \"extract\": \"The Songhay System starts with SonghayCore which is the most stable ‘core’ of the Songhay System. SonghayCore will be released on GitHub just to “prove” to myself that this is the case. The next slab is DAR (Data Access Runner) which is built on a ‘core’...\"\r\n}"
}
---

# A new look at the Songhay System ‘cores’

The Songhay System starts with `SonghayCore` which is the most stable ‘core’ of the Songhay System. `SonghayCore` will be released on GitHub just to “prove” to myself that this is the case. The next slab is DAR (Data Access Runner) which is built on a ‘core’ set of projects:

<table class="WordWalkingStickTable"><tr><td>

`AmazonWebServices`
`AmazonWebServices.Tests`

</td><td>

Stable (small) but stale. This library might possibly be completely replaced by simple HTTP calls.

</td></tr><tr><td>

``

</td><td>

This is the soon-to-be-not-really-famous *Songhay Core*. I’ve groomed this code throughout my IT career for over a decade. The plan is to get this to GitHub and distributed in a bunch of NuGet packages.

</td></tr><tr><td>

`Songhay.Shell`

</td><td>

My personal stash of PowerShell scripts.

</td></tr><tr><td>

``

</td><td>

I’ve been working on this today and days before today. This is far more stable and conceptually ‘cleaner’ (built around just three concepts: account, container and blob). This *might* be released on GitHub and NuGet-packaged as well.

</td></tr><tr><td>

``

</td><td>

This is already released on CodePlex and is quite stable. I would move it to GitHub just for the NuGet support.

</td></tr><tr><td>

``

</td><td>

These are models for the GenericWeb which is stable (I worked very hard on this last year and maybe the year before that—but is always open for reorganization). My long-time relationship with Entity Framework is here.

</td></tr></table>

## Songhay DAR Activities will work as Azure Web Jobs?

I am almost certain that DAR Activities—with little re-factoring—can work as Azure Web Jobs. I’ll need to investigate and experiment. Doing this allows me to back out of Azure Web Jobs in case of vendor ‘betrayal.’ This would prove (only to me) that the Songhay System ‘core’ is designed to be flexible in the cloud and on the Desktop.

## Songhay Data Services

So DAR (eventually) feeds Songhay Data Services—built on ASP.NET Web API hosted on Azure (“App Services”). The ‘core’ of these data services is almost identical to the DAR core except for the following:
<table class="WordWalkingStickTable"><tr><td>

`Songhay.Net.WebClient`

</td><td>

The `async` HTTP calls are here (but should be sorted out later—with `HttpClient` involved).

</td></tr><tr><td>

`Songhay.Web`
`Songhay.Web.Tests`

</td><td>

ASP.NET MVC support.

</td></tr></table>

<https://github.com/BryanWilhite/>
