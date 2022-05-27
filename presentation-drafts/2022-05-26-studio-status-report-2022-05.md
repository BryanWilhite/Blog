---json
{
  "documentId": 0,
  "title": "studio status report: 2022-05",
  "documentShortName": "2022-05-26-studio-status-report-2022-05",
  "fileName": "index.html",
  "path": "./entry/2022-05-26-studio-status-report-2022-05",
  "date": "2022-05-27T01:49:05.915Z",
  "modificationDate": "2022-05-27T01:49:05.915Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-05-26-studio-status-report-2022-05",
  "tag": "{\n  \"extract\": \"\"\n}"
}
---

# studio status report: 2022-05

## month 5 of 2022 was about releasing SonghaySystem.com and addressing my deprecated DevOps pipelines

For about eight months during 2021 I planned to release an eleventy version of SonghaySystem.com. A GitHub project at <https://github.com/BryanWilhite/songhay-dashboard/projects/1> represents this intent. This eleventy-centric focus makes 2021 sense as [I started 2020 with eleventy celebrations](http://songhayblog.azurewebsites.net/entry/2020-02-08-studio-status-report-2020-01/) and that party raged through [the summer of 2020](http://songhayblog.azurewebsites.net/entry/2020-06-11-my-blogging-workflow-for-2020-is-all-about-11ty-eleventy/), leading to [a manifesto-like Blog post](http://songhayblog.azurewebsites.net/entry/2020-10-30-a-return-to-progressive-enhancement-with-lithtml-and-11ty-eleven-ty/) in Autumn.

By the eleventh month (no pun intended) of 2021, I completely switched to Bolero, an ‘experiment’ represented by the GitHub project at <https://github.com/BryanWilhite/Songhay.Dashboard/projects/2>. This ‘experiment’ concluded about six months later, on 5/14, with the release of SonghaySystem.com.

Sadly, I _will_ understate the significance of this success. I consider this a defect of my character. As I write this, I am more concerned with the fact that I set a completely different repo for the eleventy push and forgot about it! _I will need to delete this repo ASAP._

Additionally, I was quite disappointed to find that the Azure Pipeline, supporting the release of SonghaySystem.com, was effectively deprecated by Microsoft. I have started looking into `az pipelines` [📖 [docs](https://docs.microsoft.com/en-us/cli/azure/pipelines?view=azure-cli-latest)] and `az devops` [📖 [docs](https://docs.microsoft.com/en-us/cli/azure/devops?view=azure-cli-latest)] of the Azure CLI to bypass the sluggish Portal UX as Microsoft transitions most ungracefully with poor communication.

## my continuing interest in eleventy

Yes, I admit it: my continuing interest in eleventy has taken a back seat to F#-based approaches. This would be quite an uncomfortable situation politically, from a self-marketing POV, had I somehow became an eleventy “influencer.” Yet again, I can take advantage of being almost entirely ignored by “the community” (wherever that is) and quietly consider moving to the F# equivalent of eleventy.

My original intent with eleventy was to avoid slipping into another language culture that was _not_ JavaScript/TypeScript (which is what can happen with something like [Hugo](https://gohugo.io/) or [Jekyll](https://jekyllrb.com/)—Go and Ruby, respectively). I regard JavaScript as the _conservative_ choice for static website development but I also regard using .NET (via F#) to generate static websites as the _ultra-orthodox_ conservative approach to web development.

Can Fornax [[GitHub](https://github.com/ionide/Fornax)] _replace_ eleventy? I have opened [a GitHub issue](https://github.com/BryanWilhite/dotnet-core/issues/41) to address this question.

BTW: I do not think my work with Web Components (under the [`songhay-web-components`](https://github.com/BryanWilhite/songhay-web-components) repo) was a forgettable waste of time. As long as I am into static Web site generation (which will be _forever_) I will be into Web Components!

## sketching out a development schedule (revision 21)

The schedule of the month:

- ~~complete [project](https://github.com/BryanWilhite/songhay-dashboard/projects/1) associated with new version of SonghaySystem.com~~ 📜🚜🔨
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀

@[BryanWilhite](https://twitter.com/BryanWilhite)
