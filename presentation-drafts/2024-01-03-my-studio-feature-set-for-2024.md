---json
{
  "documentId": 0,
  "title": "my Studio feature set for 2024",
  "documentShortName": "2024-01-03-my-studio-feature-set-for-2024",
  "fileName": "index.html",
  "path": "./entry/2024-01-03-my-studio-feature-set-for-2024",
  "date": "2024-01-04T03:47:44.907Z",
  "modificationDate": "2024-01-04T03:47:44.907Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2024-01-03-my-studio-feature-set-for-2024",
  "tag": "{\n  \"extract\": \"Here, in my Studio, a “technical Blog” is simply a series of posts about a set of interests. Traditionally this set of interests is focused and coherent—but oftentimes too broad. I recall sending an email to Carl Franklin last century (before the inventio…\"\n}"
}
---

# my Studio feature set for 2024

Here, in my Studio, a “technical Blog” is simply a series of posts about a set of interests. Traditionally this set of interests is focused and coherent—but oftentimes too broad. I recall sending an email to [Carl Franklin](http://carlfranklin.net/about/) last century (before the invention of “social media”) where I confidently and calmly proclaimed my intent to ‘master’ the .NET Framework. I am sure Carl knew that the .NET Framework is too big for a single person to master—and, had I been explicitly confronted, I would have agreed.

In this century, after several decades, I now understand what I _really_ meant about this quest for mastery. I now understand that I need to make a commitment to a _finite_ list of interests that is _explicitly_ stated. I should start with a handful of bullet points and then break this handful down and that breakdown can be broken down further. Every year going forward I should publish a report of these breakdowns, yielding a set of _features_ that should be appealing to a market of buyers. The challenge is to remain true to myself while selling these features to the market.

Effectively, I have been behaving this way for about 28 years. Now is the time to make this behavior explicit.

## the feature set shortlist

I am not going to memorize my full feature set. What I _can_ do is try to group my full set into some top-level categories. Today these are:

1. data-driven declarative <acronym title="User Interface">UI</acronym> development 🍱 defined by <acronym title="User Experience">UX</acronym> documentation and maintained by automated testing 🔬
2. cloud based <acronym title="Representational State Transfer">REST</acronym> 🌩️ <acronym title="Application Programming Interface">API</acronym> development with optional serverless scaling 🌩️🌩️ maintained by automated testing 🔬
3. cloud based distributed event/command publishing and subscribing 🌩️📧
4. domain data development and management from static <acronym title="JavaScript Object Notation">JSON</acronym> to cloud-based relational and/or document systems maintained by automated testing 🔬

My “full stack” developer career began with items _1_ and _4_. Years of work with ‘personal’ practice in my Studio led to item _2_ (before it could be sold in the marketplace). Item 3 is ‘under development’ as it is relatively new.

### the full feature set

1. Service-provider-based app design with `IHost` (in `Microsoft.Extensions.Hosting` 📦) 🔨✨
2. Automated unit testing with xUnit 🔬
3. Declarative <acronym title="User Interface">UI</acronym> with Sass, <acronym title="HyperText Markup Language">HTML</acronym>5, <acronym title="Scalable Vector Graphics">SVG</acronym> and/or Razor and Typescript 🔨🍱🐎
4. Declarative <acronym title="User Interface">UI</acronym> with Bolero over WebAssembly and Typescript 🔨🍱🐎✨
5. Declarative <acronym title="User Interface">UI</acronym> with Avalonia over <acronym title="Extensible Application Markup Language">XAML</acronym>🔨🍱🐎🚧
6. Data-driven declarative <acronym title="User Interface">UI</acronym> layout with Sass and <acronym title="Cascading Style Sheets">CSS</acronym> custom properties 📇💄
7. <acronym title="Representational State Transfer">REST</acronym>ful Web <acronym title="Application Programming Interface">API</acronym> with ASP.NET or Azure Functions 🌩✨
8. Distributed-caching with `StackExchange.Redis` 📇🕸✨
9. Domain-data reading and writing with Entity Framework and/or Dapper and `FluentValidation` 📇✅
10. Structured logging and monitoring 🖋🚧
11. Secrets management with Azure Key Vault 🌩🔐🚧
12. Code-first migrations with Entity Framework and Microsoft SQL Server or SQLite 📇🚀🚧
13. Recursive traversal of hierarchical data structures with <acronym title="Common Table Expression">CTE</acronym>s in Microsoft SQL Server 🔨✨
14. <acronym title="JavaScript Object Notation">JSON</acronym>-based projections and relations with Microsoft SQL Server 🔨✨
15. Integration testing with xUnit fixtures, exposing the <acronym title="System under Test">SUT</acronym> service provider 🔬✨
16. Ordered integration testing to capture domain-data snapshots and copy test samples from the production environment✋🔬✨
17. Architectural layer packaging and reuse with NuGet 📦🚀
18. <acronym title="YAML Ain’t Markup Language">YAML</acronym>-based <acronym title="Continuous Integration">CI</acronym> pipeline declaration with Azure DevOps ❄🚀
19. Ordered integration testing ✋🔬 to check for regression with domain-data snapshots 🚧
20. Automated unit testing (with English-language hooks into product stories) 🚧
21. Automated ordered integration testing (with English-language hooks into product stories) 🚧
22. Intra-domain event/command publishing and subscribing ❓
23. Distributed event/command publishing and subscribing ❓

With this feature set is the ongoing effort to avoid the worship of technical buzz words. My intent is to use words that the business trying to invest in these features use. The use of the 🚧 emoticon indicates that this feature is under development while the use of ❓ indicates I have not even started building 😐

These 23 ‘features’ can serve as a table of contents for this technical Blog. The number 23 might imply that I would have to publish at least two articles per month to mark progress with _all_ 23 items _every_ year. I would be very surprised to see my level of ‘mastery’ have me so effective with time management!

<https://github.com/BryanWilhite/>
