---json
{
  "documentId": 0,
  "title": "My Autofac Packages Drama",
  "documentShortName": "2016-08-02-my-autofac-packages-drama",
  "fileName": "index.html",
  "path": "./entry/2016-08-02-my-autofac-packages-drama",
  "date": "2016-08-02T07:06:10.641Z",
  "modificationDate": "2016-08-02T07:06:10.641Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-08-02-my-autofac-packages-drama",
  "tag": "{\r\n  \"extract\": \"The Autofac team is very busy trying to keep up with the .NET Core movement and are clearly suffering from legacy load. I understand that there are only two guys working on this hugely popular IOC ecosystem. The contrib project Autofac.Extras.Attributed ...\"\r\n}"
}
---

# My Autofac Packages Drama

The Autofac team is very busy trying to keep up with the .NET Core movement and are clearly suffering from legacy load. I understand that there are only two guys working on this hugely popular IOC ecosystem. The contrib project `Autofac.Extras.Attributed` is dragging `Autofac` (which is okay since latest stable today is 3.5.2) and `Autofac.Mef` back to versions less than 4.0. The last time I swept through my NuGet packages I forgot about this drama and broke the B-Roll Player (`Songhay.Player`) build which I flippantly pushed out to production.

The symptom of the break was CORS errors and the dreaded MVC, failed-to-load-assembly error. Until this drama is over I should remember that this `Web.config` entry is a red flag:

```xml
<dependentAssembly>
    <assemblyIdentity name="Autofac.Integration.Mef" publicKeyToken="17863af14b0044da" culture="neutral" />
    <bindingRedirect oldVersion="0.0.0.0-4.0.0.0" newVersion="4.0.0.0" />
</dependentAssembly>
```

This means `Autofac.Mef` was erroneously upgraded *by me* to version 4.0, breaking `Autofac.Extras.Attributed`.

The drama does not end there. We also have this:

```shell
'Autofac.Owin 4.0.0' is not compatible with 'Autofac.Mvc5.Owin 3.1.0 constraint: Autofac.Owin (>= 3.1.0 && < 4.0.0)', 'Autofac.WebApi2.Owin 3.3.0 constraint: Autofac.Owin (>= 3.1.0 && < 4.0.0)'. 0
```

This is basically saying that `Autofac.Mef` and `Autofac.Owin` are in the same boat. The penalty for forgetting this is breaking the B-Roll player in production (which is my fault because I should *at least* run the site locally before publishing—and then consider upgrading my Azure App to a more professional tier).

@[BryanWilhite](https://twitter.com/BryanWilhite)
