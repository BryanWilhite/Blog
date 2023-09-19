---json
{
  "documentId": 0,
  "title": "Replacing my NBlog with a read-only Angular JS seed over Web API…",
  "documentShortName": "2015-06-29-replacing-my-nblog-with-a-read-only-angular-js-seed-over-web-api",
  "fileName": "index.html",
  "path": "./entry/2015-06-29-replacing-my-nblog-with-a-read-only-angular-js-seed-over-web-api",
  "date": "2015-06-29T07:00:00Z",
  "modificationDate": "2015-06-29T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-06-29-replacing-my-nblog-with-a-read-only-angular-js-seed-over-web-api",
  "tag": "{\r\n  \"extract\": \"I’m going to move away from “powering” this Blog with NBlog. Don’t get me wrong. Chris Fulstow’s NBlog was and is a powerful educational tool for ASP.NET MVC. So when I write about replacing it, it is not because of NBlog in particular. It is because of ...\"\r\n}"
}
---

# Replacing my NBlog with a read-only Angular JS seed over Web API…

I’m going to move away from “powering” this Blog with NBlog. Don’t get me wrong. [Chris Fulstow’s NBlog](https://github.com/ChrisFulstow/NBlog) was and *is* a powerful educational tool for ASP.NET MVC. So when I write about replacing it, it is not because of NBlog in particular. It is because of the CMS-application concept in general.

[Route("Entry/Show/{id}")]
    public ActionResult RedirectToAngularSeed(string id)
    {
        return RedirectPermanent(string.Format("~/#/entry/{0}", id));
    }

The CMS can be thought of as a user-super-friendly way to uphold one of the original, Berners-Lee-ist ideals of a read-write Web. So my move can be regarded (poorly) as a failure to celebrate these ideals for the sake of “oversimplification.”

My real-world experience with WordPress has taught me to separate the *reading* concern from the *writing* concern in a CMS solution. Further, I am convinced and giddy that the typical CMS design violates the DRY Principle in bulk when we start to treat our Blogging platform(s) “like cattle instead of like pets.”

More than a few pro-level bloggers out there have more than one Blog and (assuming they use a standard CMS) they have to maintain *multiple* editing interfaces for *multiple* blogs. I would rather have the option of using *one* editing interface for *multiple* Blog sites. The near-insane amount of security patches for WordPress almost always have *nothing* to do with *reading* a Blog (which is what most people do to a Blog).

Working with NBlog has taught me that JSON is a first-class Web resource: it represents a document—including an HTML document. So in the near future my Blog will use an Angular JS seed to *read* JSON documents from Azure Blob storage, using a similar repository pattern featured in NBlog. I will go slightly beyond the version of NBlog I’m using, and add my own JSON-based *indexing* solution with some primitive taxonomy support (compared to WordPress). This is not a fork of NBlog.

So how will I “publish” to my new `Songhay.Blog`—and how will the index be updated? Well, my Blog may fall silent (again) for a while but I’ll be sure to, ahem, Blog about this in future.

<https://github.com/BryanWilhite/>
