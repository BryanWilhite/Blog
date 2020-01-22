---json
{
  "documentId": 0,
  "title": "flippant remarks about my use of design patterns",
  "documentShortName": "2020-01-22-flippant-remarks-about-my-use-of-design-patterns",
  "fileName": "index.html",
  "path": "./entry/2020-01-22-flippant-remarks-about-my-use-of-design-patterns",
  "date": "2020-01-22T23:32:16.041Z",
  "modificationDate": "2020-01-22T23:32:16.041Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2020-01-22-flippant-remarks-about-my-use-of-design-patterns",
  "tag": "{\n  \"extract\": \"Seasoned YouTuber Derek Banas has a design patterns series that I think I should watch at least once a year to stay in shape. This exercise should inspire me to answer these very healthy questions: - What design patterns am I using regularly?\\nWhat design �\"\n}"
}
---

# flippant remarks about my use of design patterns

Seasoned YouTuber Derek Banas has [a design patterns series](https://www.youtube.com/playlist?list=PLF206E906175C7E07) that I think I should watch at least once a year to stay in shape. This exercise should inspire me to answer these very healthy questions:

- What design patterns am I using regularly?
- What design patterns am I _not_ using regularly?

The last question is harder than the first question, making this professional introspection quite difficult. All of this babble, by the way, can be blamed on Eric, Richard, Ralph and John—[the Gang of Four](https://en.wikipedia.org/wiki/Design_Patterns).

## What design patterns am I using regularly?

- Singleton Pattern
- Template Method Pattern
- Strategy Pattern (with the Command Pattern)
- Façade Pattern

It feels like the number-one design pattern that I _know_ I am using regularly is the [Singleton Pattern](https://www.youtube.com/watch?v=NZaXM67fxbs&list=PLF206E906175C7E07&index=8&t=0s). My `TraceSources` [class](https://github.com/BryanWilhite/SonghayCore/blob/master/SonghayCore/Diagnostics/TraceSources.cs) in `SonghayCore` is a singleton.

The number-one design pattern that I continually _do not know_ that I am using regularly is the [Template Method Pattern](https://www.youtube.com/watch?v=aR1B8MlwbRI&list=PLF206E906175C7E07&index=17&t=0s) as [this pattern comes closest](https://stackoverflow.com/a/6936197/22944) to my frequent use of extension methods. My `SonghayCore` repo has [over 60 class definitions](https://github.com/BryanWilhite/SonghayCore/tree/master/SonghayCore/Extensions) devoted to extension methods.

The the number-two design pattern that I _know_ I am using regularly is the [Strategy Pattern](https://www.youtube.com/watch?v=-NCgRD9-C6o&list=PLF206E906175C7E07&index=4&t=0s). My dictionary of `Lazy<IActivity>` [field](https://github.com/BryanWilhite/SonghayCore/blob/master/SonghayCore/Models/ActivitiesGetter.cs#L74) in my `ActivitiesGetter` can hold several different _strategies_ for what happens when `IActivity.Start()` is called. (And I argue that the [Command Pattern](https://www.youtube.com/watch?v=7Pj5kAhVBlg&list=PLF206E906175C7E07&index=13&t=0s) is used via `ProgramArgs` to select these strategies). What is definitely controversial (because OOP is not in use) features my use of `Action<T>` or `Func<T>` in some of my `SonghayCore` utility methods (like `Action<string> fileAction` in the `FrameworkFileUtility.ReadZipArchiveEntries()` [method](https://github.com/BryanWilhite/SonghayCore/blob/master/SonghayCore/FrameworkFileUtility.Compression.cs#L25)). I asser today that any use of `Action<T>` or `Func<T>` is ‘a kind’ of Strategy Pattern.

The the number-three design pattern that I _know_ I am using regularly is the [Façade Pattern](https://www.youtube.com/watch?v=B1Y8fcYrz5o&list=PLF206E906175C7E07&index=15&t=0s). This pattern is synonymous with the acronym _API_ and, in my world, largely in use in my ASP.NET Core projects.

## What design patterns am I _not_ using regularly?

- Decorator Pattern
- Visitor Pattern
- Flyweight Pattern

The number one design pattern I am _not_ using is the [Decorator Pattern](https://www.youtube.com/watch?v=j40kRwSm4VE&list=PLF206E906175C7E07&index=12&t=0s). This is important because have been one of those people that have confused the use of extension methods as ‘a kind’ of decorator pattern. There is [a StackOverflow question](https://stackoverflow.com/questions/4888116/the-decorator-pattern-extension-methods-in-c-sharp) posed almost a decaded ago around making this mistake.

The number two design pattern I am not using is the [Visitor Pattern](https://www.youtube.com/watch?v=pL4mOUDi54o&list=PLF206E906175C7E07&index=27&t=0s) because this pattern [has also been confused](https://stackoverflow.com/a/6935609/22944) (by me) with the use of extension methods.

My limited research suggests that Decorator Pattern and the Visitor Pattern came from needs around trees of objects. This flippantly makes me associate these two patterns with the pattern related to addressing large numbers of objects, the [Flyweight Pattern](https://www.youtube.com/watch?v=0vV-R2926ss&list=PLF206E906175C7E07&index=20&t=0s).

The following table summarizes my ignorance of the remaining patterns covered by Derek Banas:

pattern | flippant remarks
-- | --
[Adapter Pattern](https://www.youtube.com/watch?v=qG286LQM6BU&list=PLF206E906175C7E07&index=14&t=0s) | To date, after almost two decades, I have failed to see an “incompatible interface” problem. It is just possible that I am not aware that I was using something like this when strangling legacy WPF code into Prism services.
[Bridge Pattern](https://www.youtube.com/watch?v=9jIgSsIfh_8&list=PLF206E906175C7E07&index=16&t=0s) | Today, [this sentence](https://en.wikipedia.org/wiki/Bridge_pattern) is beyond my comprehension: “The class itself can be thought of as the abstraction and what the class can do as the implementation.”
[Builder Pattern](https://www.youtube.com/watch?v=9XnsOpjclUg&list=PLF206E906175C7E07&index=9&t=0s) | I assume that my use of `StringBuilder` and any other .NET Standard class with the suffix `*Builder` has been at my disposal for years.
[Chain of Responsibility Pattern](https://www.youtube.com/watch?v=jDX6x8qmjbA&list=PLF206E906175C7E07&index=23&t=0s) | Today, my ignorance suggests that this pattern is associated with the need to avoid using `if` structures in the design of a ‘rules engine.’ Alternatively, I may find that this pattern is used for [ASP.NET Core middleware](https://weblogs.asp.net/ricardoperes/dynamically-loading-middleware-in-asp-net-core).
[Composite Pattern](https://www.youtube.com/watch?v=2HUnoKyC9l0&list=PLF206E906175C7E07&index=19&t=0s) | [This sentence](https://en.wikipedia.org/wiki/Composite_pattern#Motivation), sadly, has no meaning for me at this time: “When dealing with Tree-structured data, programmers often have to discriminate between a leaf-node and a branch.”
[Factory Pattern](https://www.youtube.com/watch?v=ub0DXaeV6hA&list=PLF206E906175C7E07&index=6&t=0s) and [Abstract Factory Pattern](https://www.youtube.com/watch?v=xbjAsdAK4xQ&list=PLF206E906175C7E07&index=7&t=0s) | I have spent most of my Microsoft-biased career as a _consumer_ of factories (e.g. `DbProviderFactory`). A Factory is intended to centralize the instantiation of objects via method returning an interface or abstract class. An abstract factory uses the same method to return objects that can instantiate other objects.
[Interpreter Pattern](https://www.youtube.com/watch?v=6CVymSJQuJE&list=PLF206E906175C7E07&index=24&t=0s) | This pattern relates to Domain Specific Languages and feels like it leads into the linguistics of artificial intelligence.
[Iterator Pattern](https://www.youtube.com/watch?v=VKIzUuMdmag&list=PLF206E906175C7E07&index=18&t=0s) | [This sentence](https://en.wikipedia.org/wiki/Iterator_pattern#Overview) is telling me that .NET data structures have been quite sufficient: “The elements of an aggregate object should be accessed and traversed without exposing its representation (data structures).”
[Mediator Pattern](https://www.youtube.com/watch?v=8DxIpdKd41A&list=PLF206E906175C7E07&index=25&t=0s) | Traditional approaches to WPF event aggregation introduced this pattern to me.
[Memento Pattern](https://www.youtube.com/watch?v=jOnxYT8Iaoo&list=PLF206E906175C7E07&index=26&t=0s) | My ignorance of this pattern betrays the fact that I have never built a professional “undo” feature in my career so far.
[Prototype Pattern](https://www.youtube.com/watch?v=AFbZhRL0Uz8&list=PLF206E906175C7E07&index=10&t=0s) | Wow, [this sentence](https://en.wikipedia.org/wiki/Prototype_pattern#Rules_of_thumb) shows that I am nowhere near a Java architect: “Often, designs start out using Factory Method (less complicated, more customizable, subclasses proliferate) and evolve toward abstract factory, prototype, or builder (more flexible, more complex) as the designer discovers where more flexibility is needed.”
[Proxy Pattern](https://www.youtube.com/watch?v=cHg5bWW4nUI&list=PLF206E906175C7E07&index=22&t=0s) | The need to use a smaller, more obscure object in place of the real one has definitely been in my life. The [Azure Storage Blobs client library](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs) has loads of proxy patterns.
[State Pattern](https://www.youtube.com/watch?v=MGEx35FjBuo&list=PLF206E906175C7E07&index=21&t=0s) | “This pattern is close to the concept of finite-state machines.” [[wikipedia](https://en.wikipedia.org/wiki/State_pattern)] And feels related to the [Chain of Responsibility Pattern](https://www.youtube.com/watch?v=jDX6x8qmjbA&list=PLF206E906175C7E07&index=23&t=0s) as both patterns should reduce or eliminate the use of `if`.

## outside of the Gang of Four: the producer-consumer problem

The [producer-consumer problem](https://en.wikipedia.org/wiki/Producer%E2%80%93consumer_problem) is not a pattern. It’s a problem. I list this here with a bunch of design patterns because, once a pattern like the Mediator is implemented asynchronously, this problem needs to be known.

Decoupling asynchronously in my life implies that I am building for the cloud. And, sadly, there is a whole new bag of [cloud design patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/#catalog-of-patterns).

@[BryanWilhite](https://twitter.com/BryanWilhite)
