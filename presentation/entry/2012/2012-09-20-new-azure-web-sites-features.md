---json
{
  "documentId": 0,
  "title": "New Azure Web Sites Features",
  "documentShortName": "2012-09-20-new-azure-web-sites-features",
  "fileName": "index.html",
  "path": "./entry/2012-09-20-new-azure-web-sites-features",
  "date": "2012-09-21T02:52:00.000Z",
  "modificationDate": "2012-09-21T02:52:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-09-20-new-azure-web-sites-features",
  "tag": "{\r\n  \"extract\": \"Three days ago, in “Announcing: Great Improvements to Windows Azure Web Sites,” Scott Guthrie is making Internet history: With today’s release we are introducing a new low-cost “shared” scaling mode for Windows Azure Web Sites. A web-site running in share...\"\r\n}"
}
---

# New Azure Web Sites Features

Three days ago, in “[Announcing: Great Improvements to Windows Azure Web Sites](http://weblogs.asp.net/scottgu/archive/2012/09/17/announcing-great-improvements-to-windows-azure-web-sites.aspx),” Scott Guthrie is making Internet history:

<blockquote>

With today’s release we are introducing a new low-cost “shared” scaling mode for Windows Azure Web Sites. A web-site running in shared mode is deployed in a shared/multi-tenant hosting environment. Unlike the free tier, though, a web-site in shared mode has no quotas/upper-limit around the amount of bandwidth it can serve. The first 5 GB/month of bandwidth you serve with a shared web-site is free, and then you pay the standard “pay as you go” Windows Azure outbound bandwidth rate for outbound bandwidth above 5 GB.

A web-site running in shared mode also now supports the ability to map multiple custom DNS domain names, using both CNAMEs and A-records, to it. The new A-record support we are introducing with today’s release provides the ability for you to support “naked domains” with your web-sites (e.g. <http://microsoft.com> in addition to <http://www.microsoft.com).> We will also in the future enable SNI based SSL as a built-in feature with shared mode web-sites (this functionality isn’t supported with today’s release – but will be coming later this year to both the shared and reserved tiers).

You pay for a shared mode web-site using the standard “pay as you go” model that we support with other features of Windows Azure (meaning no up-front costs, and you pay only for the hours that the feature is enabled). A web-site running in shared mode costs only 1.3 cents/hr during the preview (so on average $9.36/month).

</blockquote>

With this announcement Microsoft is finally addressing a relatively ancient problem of how poorly Microsoft-based shared hosting competed with, say, DreamHost.com. We can complain and say that Microsoft has “over-engineered” its solution and it’s late—but plenty of people can say this about my work! In defense of Microsoft (and me)—like a multibillion dollar company actually needs defending—Microsoft has the best solution (better than Amazon offerings—and, to me, Google is just an advertising company with some custom Linux stuff that most “serious” Linux people don’t respect). Microsoft has a complete technical statement that coheres with the massive legacy load Microsoft has to carry (and I have quite a hefty legacy load too).

This news from “the Gu” allows me to tabulate my plans for Azure migration:
<
table class="WordWalkingStickTable"><tr><td>

wordwalkingstick.com
[songhayindex.azurewebsites.net]
<
/td><td>

Shared site with custom “naked” domain.
<
/td></tr><tr><td>

slbiggestbox.azurewebsites.net
<
/td><td>

Free site.
<
/td></tr><tr><td>

songhaywebformssample.azurewebsites.net
<
/td><td>

Free site.
<
/td></tr><tr><td>

daypath.wordwalkingstick.com
[songhayblog.azurewebsites.net]
<
/td><td>

Shared site with custom subdomain.
<
/td></tr><tr><td>

songhaysystem.com
[songhaysystem.azurewebsites.net]
<
/td><td>

Shared site with custom “naked” domain.
<
/td></tr></table>

## Phil Haack’s Old Hosting Service

I’m currently running wordwalkingstick.com with the same hosting company serving Phil Haack’s blog. I chose this host because I thought Phil chose this company carefully—but after using this host for a little over year it seems that Phil just said “whatever, it’s cheap and more reliable than others.” Windows Azure is special. Some of the best people in the entire IT industry are working on it. To me this is Scott Guthrie’s (and Mark Russinovich’s) master opus—never just “whatever.”

@[BryanWilhite](https://twitter.com/BryanWilhite)
