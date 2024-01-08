---json
{
  "documentId": 0,
  "title": "my Studio feature set for 2024",
  "documentShortName": "2024-01-07-my-studio-feature-set-for-2024",
  "fileName": "index.html",
  "path": "./entry/2024-01-07-my-studio-feature-set-for-2024",
  "date": "2024-01-08T03:16:47.337Z",
  "modificationDate": "2024-01-08T03:16:47.337Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2024-01-07-my-studio-feature-set-for-2024",
  "tag": "{\n  \"extract\": \"Here, in my Studio, a “technical Blog” is simply a series of posts about a set of interests. Traditionally this set of interests is focused and coherent—but oftentimes too broad. I recall sending an email to Carl Franklin last century (before the inventio…\"\n}"
}
---

# my Studio feature set for 2024

Here, in my Studio, a “technical Blog” is simply a series of posts about a set of interests not explicitly related to politics. Traditionally this set of interests is coherent but oftentimes too broad. I recall sending an email to [Carl Franklin](http://carlfranklin.net/about/) last century (before the invention of “social media”) where I confidently and calmly proclaimed my intent to ‘master’ the .NET Framework. I am sure Carl knew that the .NET Framework is too big for a single person to master—and, had I been explicitly confronted, I would have agreed.

In this century, after several decades, I now understand what I _really_ meant about this quest for mastery. I now understand that I need to make a commitment to a _finite_ set of interests that is _explicitly_ stated and tracked year over year. This very similar to having a watch-list of stocks because the _value_ of these interests should be analyzed in a (job) _market_. Also, since stock picks can be grouped into larger sectors, I should similarly start with a handful of bullet points—let’s call it a _shortlist_—that is grouping the full set. Every year going forward I should publish a report of these breakdowns, yielding a set of _features_ that should be appealing to a market of buyers. The challenge is to remain true to myself while selling these features to the market.

Effectively, I have been behaving this way for about 28 years. Now is the time to make this behavior explicit.

## the feature set shortlist

I am not going to memorize my full feature set. What I _can_ do is try to group my full set into some top-level categories. Today these are:

1. data-driven declarative (and semantic) <acronym title="User Interface">UI</acronym> development 🍱 defined by <acronym title="User Experience">UX</acronym> documentation and maintained by automated testing 🔬
2. cloud-based <acronym title="Representational State Transfer">REST</acronym> 🌩️ <acronym title="Application Programming Interface">API</acronym> development with transparent resource scaling 🌩️🌩️ (optionally serverless) maintained by automated testing 🔬
3. cloud-based distributed event/command publishing and subscribing 🌩️📧
4. domain data development and management from small-scale static <acronym title="JavaScript Object Notation">JSON</acronym> to large-scale cloud-based relational and/or document-hierarchical systems maintained by automated testing 🔬

My “full stack” developer career began with items _1_ and _4_. Years of work with ‘personal’ practice in my Studio led to item _2_ (before it could be sold in the marketplace). Item 3 is ‘under development’ as it is relatively new. These are the tech buzzwords used above (in order of appearance):

- declarative <acronym title="User Interface">UI</acronym>
- <acronym title="User Experience">UX</acronym>
- automated testing
- cloud-based
- <acronym title="Representational State Transfer">REST</acronym>
- domain data
- <acronym title="JavaScript Object Notation">JSON</acronym>

Most these buzzwords are out of current fashion. I have to write the previous sentence to remind a reader of my awareness of this.

In “[The 3 budgets](https://swizec.com/blog/the-3-budgets/),” Swizec Teller lists the three places where the money comes from to pay people like me:

>The 3 budgets are:
>
> - sales/marketing
> - research and development
> - maintenance

It follows that the challenge laid before me is to use buzzwords in my feature list that should appeal to people from _all_ three places listed above. I will likely _not_ be immediately successful in this endeavor because my bias toward “research and development” people has historically been very, very high. Nevertheless, the market must be respected and each new year should provide me with room for improvement!

### the full feature set

1. Service-provider-based app design with `IHost` (in `Microsoft.Extensions.Hosting` 📦) 🔨✨
2. Automated unit testing with xUnit 🔬 and <acronym title="YAML Ain’t Markup Language">YAML</acronym>-based <acronym title="Continuous Integration">CI</acronym>/<acronym title="Continuous Deployment">CD</acronym> pipelines
3. Declarative <acronym title="User Interface">UI</acronym> with semantic <acronym title="HyperText Markup Language">HTML</acronym>, Sass, <acronym title="Scalable Vector Graphics">SVG</acronym> and/or Razor and Typescript 🔨🍱🐎
4. Declarative <acronym title="User Interface">UI</acronym> with Bolero over WebAssembly and Typescript 🔨🍱🐎✨
5. Declarative <acronym title="User Interface">UI</acronym> with Avalonia over <acronym title="Extensible Application Markup Language">XAML</acronym>🔨🍱🐎🚧
6. Data-driven declarative <acronym title="User Interface">UI</acronym> layout with Sass and <acronym title="Cascading Style Sheets">CSS</acronym> custom properties 📇💄
7. <acronym title="Representational State Transfer">REST</acronym>ful Web <acronym title="Application Programming Interface">API</acronym> with ASP.NET or Azure Functions 🌩✨
8. Distributed user session management with `StackExchange.Redis` 📇🕸✨
9. Domain-data reading/validating and writing with Entity Framework and/or Dapper and `FluentValidation` 📇✅
10. Structured logging and monitoring 🖋🚧
11. Secrets management with Azure Key Vault 🌩🔐🚧
12. Code-first migrations with Entity Framework and Microsoft SQL Server or SQLite 📇🚀🚧
13. Recursive traversal of hierarchical data structures with <acronym title="Common Table Expression">CTE</acronym>s in Microsoft SQL Server 🔨✨
14. <acronym title="JavaScript Object Notation">JSON</acronym>-based projections and relations with Microsoft SQL Server 🔨✨
15. Integration testing with xUnit fixtures, exposing the <acronym title="System under Test">SUT</acronym> service provider 🔬✨
16. Ordered integration testing to capture domain-data snapshots and copy test samples from the production environment✋🔬✨
17. Architectural layer packaging and reuse with NuGet and `npm` 📦🚀
18. Ordered integration testing ✋🔬 to check for regression with domain-data snapshots 🚧
19. Automated unit testing (with English-language hooks into product stories) 🚧
20. Automated ordered integration testing (with English-language hooks into product stories) 🚧
21. Intra-domain event/command publishing and subscribing ❓
22. Distributed event/command publishing and subscribing ❓
23. Product-owner-audience-focused and QA-focused documentation written in markdown and/or Jupyter notebooks 🖊️ to be published in desired formats

The use of the 🚧 emoticon indicates that this feature is under development while the use of ❓ indicates I have not even started building 😐

These 23 ‘features’ can serve as a table of contents for this technical Blog. The number 23 might imply that I would have to publish at least two articles per month to mark progress with _all_ 23 items _every_ year. I would be very surprised to see my level of ‘mastery’ have me so effective with time management!

<https://github.com/BryanWilhite/>
