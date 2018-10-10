## studio status report: 2018-10

### the new SonghaySystem.com released

[SonghaySystem.com](http://SonghaySystem.com) is released. [I tweeted about it](https://twitter.com/BryanWilhite/status/1049413752955629568) to capture the moment—which was a moment of exhaustion. I would love to say that this release captured all of the Angular-related topics I plan to study but I can’t. These major questions remain:

* is it possible to set up an Angular module as a local (folder-based) NPM module?
* do Angular 6.x projects replace or compete with nrwl workspaces?
* will my Angular builds actually need Apollo and GraphQL (on ASP.NET Core) or will converting my Promises patterns to `async`-`await` patterns do just fine?

### the job market and comp-sci theories

I have been looking for a new .NET job for _at least_ two years. The previous sentence implies a lot of things so [check me out on LinkedIn](https://www.linkedin.com/in/wilhite/) to get timings right: I resigned from my previous post two weeks before my final day, 8/31/2018.

Continually, I am asked the question, “What are you looking for in your next position?” Here is my answer in descending order of importance:

* the organization actively invests in Microsoft: no Ballmer-era products like ASP.NET Web Forms that treat .NET 4.0 (and Visual Studio 2013) as “new” technology
* the organization uses automated testing in Visual Studio solutions under source control
* the organization has _some_ kind of agile practice

These requirements of mine are the bare minimum, quite impoverished actually. I must confess that I have not worked with a team meeting these requirements. On the flip side, the requirements placed on _me_ as a candidate often involve computer-science-based questions. [I have complained about this](http://songhayblog.azurewebsites.net/blog/entry/the-three-things-i-have-done-about-failing-in-job-interviews) previously but over the last month I have come to a constructive, more refined understanding.

The social-media phenomenon has caused many fashion trends; one leading trend in my job market is an alleged interest in [graph theory](https://en.wikipedia.org/wiki/Graph_theory#Computer_science). I am authentically interested in programmatic graph traversal for my long-time interest in data visualization. Underneath (or next to) graph theory is [_combinatorics_](https://en.wikipedia.org/wiki/Combinatorics#Graph_theory) (also, see “[Combinatorics in .NET](https://trycatch.me/combinatorics-in-net-part-i-permutations-combinations-variations/)”) which is a word I’ve been throwing around for decades in relation to factorials and [permutation](https://en.wikipedia.org/wiki/Permutation) _not_ graphs (and _not_ for algorithms using [backtracking](https://cs.stackexchange.com/questions/80223/using-backtracking-to-find-all-possible-permutations-in-a-string)). So it is time for me to get graphical as well as numerical. My work with TypeScript, by the way, piques my interest in [set theory](https://en.wikipedia.org/wiki/Set_theory) and [type theory](https://en.wikipedia.org/wiki/Type_theory)—so all of these theories need to be dragged into my studio and made coherent with current study and priorities.

Another interview-related technical subject is multi-threading. It was my error to regard multi-threading as an edge-case of .NET leading down into C++ (this is my WPF-influenced point of view). It is better for my career path to view multi-threading in the context of the history of ASP.NET. These articles help:

* “[ASP.NET Multithreading Web Requests](https://stackoverflow.com/questions/23912456/asp-net-multithreading-web-requests)”
* “[Practical multithreading in ASP.NET](https://www.codeproject.com/Articles/1067678/Practical-multithreading-in-ASP-NET)”
* “[The Magic of using Asynchronous Methods in ASP.NET 4.5 plus an important gotcha](https://www.hanselman.com/blog/TheMagicOfUsingAsynchronousMethodsInASPNET45PlusAnImportantGotcha.aspx)”
* “[Using Asynchronous Methods in ASP.NET 4.5](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45)”

The most important point here is that the subject of multi-threading in ASP.NET is supposed to lead to the subject of `async`-`await` patterns in ASP.NET MVC. Ballmer-era ASP.NET multithreading uses Web Forms stuff like `Page_Load` with `RegisterAsyncTask(new PageAsyncTask(MyDelegateSignatureAsync))` (replaced by `HttpTaskAsyncHandler` in .NET >=4.5; also, .NET 4.5.2 introduced `HostingEnvironment.QueueBackgroundWorkItem` [[docs](https://docs.microsoft.com/en-us/dotnet/api/system.web.hosting.hostingenvironment.queuebackgroundworkitem?view=netframework-4.7)] for fire-and-forget scenarios which is less risky than the use of `async`-`void`).

It must be said that the subject of “[micro-services](https://en.wikipedia.org/wiki/Microservices)” should lead to the topic of multi-threading in ASP.NET. This is because one call for client data might require several `async` calls to multiple “micro” services. As of this writing, I have not encountered this scenario because I am using Azure web jobs to assemble one, static JSON file from several service calls.

And, for healthy interview prep, it is always useful to read, “[Fundamentals of Garbage Collection](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals),” at least once every six months. (Garbage collection algorithms depend on [the heap data structure](https://en.wikipedia.org/wiki/Heap_(data_structure)) which is a specialized tree structure, leading back to Graph Theory via [Dijkstra’s algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm).)

@[BryanWilhite](https://twitter.com/bryanwilhite)