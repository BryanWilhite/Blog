## studio status report: 2018-11

### SonghaySystem.com is fully covered by Azure Web Jobs

It would awesome to celebrate without reservation that my Songhay Dashboard will now update itself via an Azure Web Job. This is great news and the first tangible evidence of a _system_ for the Songhay System. However, as soon as I got this working, [the most bizarre, edge-case-worthy PowerShell error](https://github.com/BryanWilhite/Songhay.Dashboard/issues/43) popped up to meet my accomplishment. More to come on this as two Blog-entry issues have been proposed:

* https://github.com/BryanWilhite/Blog/issues/4
* https://github.com/BryanWilhite/Blog/issues/5

### Azure DevOps is cool but leaves me wanting

I would like to express my appreciation for the great work Donovan Brown and Edward Thomson—and the rest of the [extraordinary Azure DevOps team](https://abelsquidhead.com/index.php/2017/06/05/league-of-extraordinary-devops-cloud-developer-advocates/) for the recent improvements. But because of their great work I am left wanting:

* [path exclusion](https://docs.microsoft.com/en-us/azure/devops/pipelines/yaml-schema?view=vsts&tabs=schema#trigger) does not appear to be working with variables
* path exclusion does not appear to be working with root files and wildcards

I have [tweeted to Edward Thomson about this](https://twitter.com/BryanWilhite/status/1062869855492169728) and he says he is looking into it.

### git on Windows is not working with GitHub credentials

I am currently working around this issue by deleting old GitHub entries from the Credential Manager and using the git experience from GitHub Desktop and Visual Studio Community. From the command line, the experience looks like this:

```console:
git push
fatal: MissingMethodException encountered.
   Method not found: 'System.Threading.Tasks.Task`1<System.Net.Http.HttpResponseMessage> Microsoft.Alm.Authentication.INetwork.HttpGetAsync(Microsoft.Alm.Authentication.TargetUri, Microsoft.Alm.Authentication.NetworkRequestOptions)'.
fatal: MissingMethodException encountered.
   Method not found: 'System.Threading.Tasks.Task`1<System.Net.Http.HttpResponseMessage> Microsoft.Alm.Authentication.INetwork.HttpGetAsync(Microsoft.Alm.Authentication.TargetUri, Microsoft.Alm.Authentication.NetworkRequestOptions)'.
Username for 'https://github.com':
```

Searching the web for these error messages brings back very little. I currently assume that the ultimate solution is to switch to SSH on Windows.

@[BryanWilhite](https://twitter.com/bryanwilhite)