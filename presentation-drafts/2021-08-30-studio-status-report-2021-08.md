---json
{
  "documentId": 0,
  "title": "studio status report: 2021-08",
  "documentShortName": "2021-08-30-studio-status-report-2021-08",
  "fileName": "index.html",
  "path": "./entry/2021-08-30-studio-status-report-2021-08",
  "date": "2021-08-30T16:20:32.555Z",
  "modificationDate": "2021-08-30T16:20:32.555Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2021-08-30-studio-status-report-2021-08",
  "tag": "{\n  \"extract\": \"month 08 of 2021 was about SpecFlow (day job), F# notes and losing hits data for kintespace.com First, the horrible news: my forced migration to a new server for kintespace.com led to the loss of hits data for month 7 and pieces of month 8 (I think). This…\"\n}"
}
---

# studio status report: 2021-08

## month 08 of 2021 was about SpecFlow (day job), F# notes and losing hits data for kintespace.com

First, the horrible news: my forced migration to a new server for kintespace.com led to the loss of hits data for month 7 and pieces of month 8 (I think). This came from my incorrect assumption that my provider would automatically set up Apache with a default `logrotate` configuration, erroring on the side of using up too much disk space.

By default, a log file is made `daily` and then rotated every `14` days or two weeks. I have changed `/etc/logrotate.d/apache2` to:

- `monthly`
- `rotate 24`
- `dateext` with `dateformat -%Y-%m-%d.gz`

The intent is to:

- rotate logs monthly
- delete archives after 24 months

The change is followed by:

```shell
sudo logrotate -f /etc/logrotate.d/apache2
```

I have learned that modern Apache uses `logrotate` on Ubuntu a bit too late.

### successfully using SpecFlow

[SpecFlow](https://specflow.org/) is a framework for building behavior-driven ordered tests. The order of the tests is mapped to [Gherkin](https://cucumber.io/docs/gherkin/reference/) language prose.

A SpecFlow stack requires NuGet packages like these:

```xml
<ItemGroup>
  <PackageReference Include="BoDi" Version="1.5.0" /> 
  <PackageReference Include="Cucumber.Messages" Version="6.0.1" /> 
  <PackageReference Include="Gherkin" Version="6.0.0" /> 
  <PackageReference Include="Google.Protobuf" Version="3.7.0" /> 
  <PackageReference Include="NUnit" Version="3.11.0" /> 
  <PackageReference Include="Selenium.Support" Version="3.141.0" /> 
  <PackageReference Include="Selenium.WebDriver" Version="3.141.0" /> 
  <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="92.0.4515.4300" /> 
  <PackageReference Include="SpecFlow" Version="3.7.38" /> 
  <PackageReference Include="SpecFlow.NUnit" Version="3.7.38" /> 
  <PackageReference Include="SpecFlow.Tools.MsBuild.Generation" Version="3.7.38" /> 
  <PackageReference Include="System.Reflection.Emit" Version="4.3.0" /> 
  <PackageReference Include="System.Reflection.Emit.Lightweight" Version="4.3.0" /> 
  <PackageReference Include="System.Threading.Tasks.Extensions" Version="4.4.0" /> 
  <PackageReference Include="System.ValueTuple" Version="4.4.0" /> 
  <PackageReference Include="Utf8Json" Version="1.3.7" /> 
  <PackageReference Include="WebDriverManager" Version="2.11.3" /> 
</ItemGroup>
```

Today, I am not sure whether these packages were installed manually or do the plugins for [JetBrains Rider](https://www.jetbrains.com/rider/) and Visual Studio handle this auto-magically. The [SpecFlow docs](https://docs.specflow.org/projects/getting-started/en/latest/) might provide the answers and may not require me to do the research myself.

My takeaway right now is that SpecFlow requires:

- a `*.feature` file with the Gherkin (a companion code file is auto-generation on compilation)
- a steps `*.cs` file that is targeted by the content of the `*.feature` file (each Gherkin line maps to a steps method via attributes)
- optional `*Page.cs` files that represent reusable Web-page behaviors, making step files easier to read

### F# notes on the Issac Abraham book

I have started [taking notes](https://github.com/BryanWilhite/jupyter-central/tree/master/get-programming-with-f-sharp) on Issac Abraham book, _Get Programming with F#_. This represents a breakthrough in my F# research as the approach of this book is toward C# programmers like myself!

I think reserving time for this reading is important even though it is competing with the development schedule (below). But this competition is miniscule compared to the monstrous amount of time demanded by the day job of late.

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
