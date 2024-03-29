---json
{
  "documentId": 0,
  "title": "flippant remarks about F#",
  "documentShortName": "2022-03-30-flippant-remarks-about-f",
  "fileName": "index.html",
  "path": "./entry/2022-03-30-flippant-remarks-about-f",
  "date": "2022-03-30T19:53:02.448Z",
  "modificationDate": "2022-03-30T19:53:02.448Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-03-30-flippant-remarks-about-f",
  "tag": "{\n  \"extract\": \"F# is the end. This feels like the kind of programming language for an old Microsoft dog like me, retiring to learn new tricks. Before I go on and probably say something not very smart, let me thank the folks that helped me on my F# journey (in order of a…\"\n}"
}
---

# flippant remarks about F\#

<!-- cSpell:disable -->
<a href="https://www.manning.com/books/get-programming-with-f-sharp" target="_blank"><img alt="Get Programming with F#" src="../../image/get-programming-with-fsharp.png" style="float:right;margin:16px;" /></a>
<!-- cSpell:enable -->

F# is the end. This feels like the kind of programming language for an old Microsoft dog like me, retiring to learn new tricks. Before I go on and probably say something not very smart, let me thank the folks that helped me on my F\# journey (in order of appearance):

[Brian Beckman](https://www.linkedin.com/in/brianbeckman/) [@lorentzframe](https://twitter.com/lorentzframe): As early as 2007, I was floored by Brian Beckman’s soundbite, “Compositionality controls complexity.” The word “compositionality” is a polite reference to functional programming _style_ in general and F# in Microsoft particular. This revolutionary statement (_revolutionary_ to me) was made in what should be his famous video, “Brian Beckman: Don’t fear the Monad” [[YouTube](https://www.youtube.com/watch?v=ZhuHCtR3xq8)] (in case you are Microsoft employee and an archivist, the original link was <http://channel9.msdn.com/ShowPost.aspx?PostID=358968>).

[Don Syme](https://www.linkedin.com/in/don-syme-558b58/) [@dsyme](https://twitter.com/dsyme): Don Syme [[Wikipedia](https://en.wikipedia.org/wiki/Don_Syme)] evangelized his work on F# from the very beginning. Before Microsoft officially recognized the existence of YouTube, Don Syme was in several [MSDN Channel 9](https://en.wikipedia.org/wiki/Channel_9_%28Microsoft%29) videos such as a 2016, _On .NET_ episode, “[Don Syme on F#](https://docs.microsoft.com/en-us/shows/on-net/don-syme-on-f).”

[Jessica Kerr](https://www.linkedin.com/in/jessicakerr/) [@jessitron](https://twitter.com/jessitron): Jessica Kerr is not an F# evangelist but she is an excellent one for [Elm](https://elm-lang.org/). Her [GOTO 2016 conference talk](https://www.youtube.com/watch?v=cgXhMc8M4X4) set the stage for me to meet a flavor of [Elmish](https://elmish.github.io/) called [Bolero](https://fsbolero.io/). It took me about five years to figure this out.

[Scott Nimrod](https://www.linkedin.com/in/scott-nimrod-05995413/) [@bizmonger](https://twitter.com/bizmonger): Scott’s [YouTube channel](https://www.youtube.com/user/Bizmonger) about things-mostly-F# dates back to 2013 and I show up around 2017—and I am sure that Scott is more than a little disappointed that it has taken me over five years to officially get on the F# train! Nevertheless, Scott has been a key figure of my F# journey, introducing me to such folks as [Ody Mbegbu](https://www.linkedin.com/in/ody-mbegbu/) [@odytrice](https://twitter.com/odytrice), [Houston Haynes](https://www.linkedin.com/in/houstonhaynes/) [@h3techdev](https://twitter.com/h3techdev) and Adam Wright [@awright18](https://twitter.com/awright18).

[Isaac Abraham](https://www.linkedin.com/in/isaacabraham/) [@isaac_abraham](https://twitter.com/isaac_abraham): Isaac Abraham, his book [_Get Programming with F#_](https://www.manning.com/books/get-programming-with-f-sharp), was the final conk on the head that made the scales fall from my eyes. I was made aware of this book from a recommendation by Houston Haynes in a Twitter Space hosted by Scott Nimrod. Save yourself five years and start with this book!

With sincere thanks to the people with the names above, let me now get flippant:

## shut up and start with the `|>` operator

One of the many things Isaac Abraham does well, is let us know that we should not get intimidated by the massive “[Symbol and operator reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/).” We should start with the forward pipeline operator, `|>`, and see how it works with the last argument of a [curried function](https://swlaschin.gitbooks.io/fsharpforfunandprofit/content/posts/currying.html) (keep reading and see below).

## you are _not_ writing statements in F\#

In F# you are writing _expressions_. For the veteran C# developer, this might sound like you would be writing everything as [expression lambdas](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions), making [expression trees](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/). I recommend asking Don Syme about this but to me this sounds right except there is no clunky `Expression<TDelegate>` syntax (and your expressions can be separated by line breaks and whitespace).

To really drive home the fact that F# is expression based is the lack of a `return` keyword (except when you are using `async` or `task` blocks [ 📖 [docs](https://docs.microsoft.com/en-us/dotnet/fsharp/tutorials/async)]). The last line of your expression is the _return_ value of an F# function (when you are returning nothing—or what we call `void` in C#—we return `()`, the `unit` [ 📖 [docs](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/unit-type)] expression).

## you “hate” whitespace in Python?

Should you “hate” the importance of whitespace in Python then you will “hate” [its importance in F#](https://swlaschin.gitbooks.io/fsharpforfunandprofit/content/posts/fsharp-syntax.html).

## tuples are first-class citizens in F\#

My Isaac-Abraham-led [study of tuples in F#](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/09-shaping-data-with-tuples.ipynb) shows me that tuples are _fundamental_ to F#. The use of commas in F# is probably expressing a tuple like the two tuples in this typical, `DateTime.TryParse` expression:

```fsharp
match DateTime.TryParse dateTimeString with
| false, _ -> resultError "dc:date"
| true, dateTime -> Ok dateTime
```

All .NET `TryParse` patterns decompose into tuples in F#.

## F\# bends over backwards for .NET APIs

That `DateTime.TryParse` expression above is but one example of how much F# recognizes the existence of .NET. It would be a mistake to assume that F# wants to escape or trivialize the .NET ecosystem. It would be better to assume that F# deviates from .NET when it “has not been invented yet” for the <acronym title="Common Language Runtime">CLR</acronym> [ 📖 [docs](https://docs.microsoft.com/en-us/dotnet/standard/clr)]. For example, the [Hindley-Milner (HM) type system](https://en.wikipedia.org/wiki/Hindley%E2%80%93Milner_type_system) has not been invented yet for .NET but it is the beating heart of F# (see “many of the recent developments in C# were inspired by F\#” below).

Another great example of this dedication is the foundational `Option.ofNullable` function [ 📖 [docs](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#ofNullable)] which supports `Nullable<T>` [ 📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1?view=net-6.0)].

## before you resort to interfaces or `Func<T>`/`Action<T>` delegates, just pass a function

Again, F\# bends over backwards for .NET APIs—so it _does_ support interfaces, `Func<T>` [ 📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.func-1?view=net-6.0)] and `Action<T>` [ 📖 [docs](https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=net-6.0)]. But this great support can confuse a novice F# developer (like me).

For example, the following F# function is not necessary (when this function will only be used by F# expressions):

```fsharp
let sayHello (hf: Func<string>) = hf.Invoke() |> printfn "%s"

Func<string>(fun () -> "hi") |> sayHello //invocation prints "hi"
```

We can express an equivalent without `Func<string>`:

```fsharp
let sayHello (hf: unit -> string) = hf() |> printfn "%s"

(fun () -> "hi") |> sayHello //invocation prints "hi"
```

We see that we are passing a `unit -> string` type into `sayHello` in the latter example. This use of a type is just as effective as an interface or .NET generic delegates. F# wants us to find ways to express intent with types _before_ resorting to interfaces or classes.

## F\# does _not_ really need LINQ

Because I enjoy using [LINQ](https://en.wikipedia.org/wiki/Language_Integrated_Query) in C# so much, I made [an extensive study of why F# does not really need LINQ](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/15-working-with-collections-in-fsharp.ipynb) during my reading of [_Get Programming with F#_](https://www.manning.com/books/get-programming-with-f-sharp).

## when F\# is presented as a DSL tool, I think the HTML mini languages are downplayed

According to the great Scott Wlaschin [@ScottWlaschin](https://twitter.com/ScottWlaschin):

>Domain-specific languages (DSLs) are well recognized as a technique to create more readable and concise code. The functional approach is very well suited for this.
>
>—“[F# for Fun and Profit](https://swlaschin.gitbooks.io/fsharpforfunandprofit/content/posts/conciseness-functions-as-building-blocks.html)”

In my opinion, libraries like `Giraffe.ViewEngine` [[GitHub](https://github.com/giraffe-fsharp/Giraffe.ViewEngine#html-elements-and-attributes)] should be in _every_ presentation, showing off the DSL features of F#. (Don Syme, by the way, _does_ refer to HTML DSLs when he presents but we need more presenters with more references). When we couple these F# HTML DSLs with Microsoft’s take on [WebAssembly](https://en.wikipedia.org/wiki/WebAssembly) which is [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor), one (like me) will immediately want to see how F# is married to Blazor. Accordingly, I am currently experimenting with [Bolero](https://fsbolero.io/), a project led by [Loïc Denuzière](https://www.linkedin.com/in/tarmil/) [@_Tarmil](https://twitter.com/Tarmil_).

When we couple these HTML DSLs with an F#-to-JavaScript compiler like [Fable](https://fable.io/), we can get honest with ourselves and admit just how much we are very-seasoned-but-not-very-fond of working in an `npm`-based JavaScript ecosystem where you have to run `npm-check` [ 📦 [package](https://www.npmjs.com/package/npm-check)] every three weeks.

## many of the recent developments in C\# were inspired by F\#

Here is an incomplete list of features in C# that _clearly_ ‘come from’ F#:

- [Records](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
- [Pattern Matching](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching) (but I think C# has more features)
- [Discards](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards)
- [Tuple Deconstruction](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct)

F# also has its own take on generics (as well as supporting .NET generics) which is a key ingredient in the F# type inference system, the [Hindley-Milner (HM) type system](https://en.wikipedia.org/wiki/Hindley%E2%80%93Milner_type_system). I explore this while [reading](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/05-trusting-the-compiler.ipynb) Isaac Abraham’s “Trusting the compiler” section of his book, [_Get Programming with F#_](https://www.manning.com/books/get-programming-with-f-sharp).

## because of over 20 years of object-oriented programming, I incorrectly assumed that polymorphism was confined to OOP

While reading Isaac Abraham’s book (mentioned previously), [I was led away from the pages](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/21-modeling-relationships-in-f-sharp.ipynb) and discovered _polytypism_ and the subject of [generic programming](https://en.wikipedia.org/wiki/Generic_programming#Functional_languages). Wow.

## two words: _discriminated unions_

A long-time C-like-language developer in the Microsoft meta-verse would see nothing like the _discriminated unions_ (DUs) of F# unless one delves [into Typescript](https://medium.com/@ahsan.ayaz/understanding-discriminated-unions-in-typescript-1ccc0e053cf5). My notes on F# DUs should drag the typical C# developer through the “muck” or through progressive transformation:

- “[Modeling relationships in F#](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/21-modeling-relationships-in-f-sharp.ipynb)”
- “[Business rules as code](https://github.com/BryanWilhite/jupyter-central/blob/master/get-programming-with-f-sharp/23-business-rules-as-code.ipynb)”
- [even more notes](https://github.com/BryanWilhite/jupyter-central/tree/master/funkykb/fsharp/discriminated-unions) on DUs

Here is my cryptic-or-stupid sound bite about DUs: _Did you ever want to define class hierarchies with regular expressions?_ We do _not_ use regular expressions with DUs but the syntax might _look_ like it!

## when you love seeing your C\# class files in alphabetical order then F\# will pinch at you

F# code depends on _order_. F# modules and their contents must appear _in order of dependency_. This means an IDE supporting F# development must allow you to drag and drop files in the correct order, edit the `*.fsproj` directly or, sadly, pinch at you. I dare not dream of an IDE that can use background-compilation magic to _automatically_ reorder `*.fs*` files for you!

This limitation on the IDE experience alone may be the reason why folks just cannot switch to F# from working with C# in Visual Studio _exclusively_. This was relatively easy for me because I spent years with Visual Studio Code which brought me closer to the file system while the flagship, Visual Studio, is designed to ‘hide’ the file system from the beginner programmer in a friendly way.

## F\# will immediately eliminate at least two categories of cross-cutting unit tests

Two categories of unit tests will never have to be written for an F# project:

- testing for `null`
- testing for exceptions

Instead of having these tests cross-cutting everywhere almost randomly, these categories of tests would be implied and confined under a clearly-defined ‘input transformation layer’ which is three words I have just smashed together on the fly while writing this sentence. In other words, F# encourages us to define and confine a ‘layer’ in our application where untrusted input is processed. This layer should be relatively small compared to the rest of the Solution. Untrusted input can be `null` or throw exceptions and our input transformation code is meant to defend against this with `Option` and `Result`. Currently, I am naming a domain-specific function, `fromInput`, as a convention to express input transformation.

What is more sophisticated is how we are encouraged to use types in F# to eliminate even _more_ categories of unit tests. Isaac Abraham explores this in his book [_Get Programming with F#_](https://www.manning.com/books/get-programming-with-f-sharp).

Also, for you lovers of xUnit in the world of C#, check out [FsUnit](http://fsprojects.github.io/FsUnit/). And, as we get intimate with `Option` and `Result`, [Ody Mbegbu](https://www.linkedin.com/in/ody-mbegbu/) [@odytrice](https://twitter.com/odytrice) recommends `FsToolkit.ErrorHandling` [[GitHub](https://github.com/demystifyfp/FsToolkit.ErrorHandling)] which I find extremely helpful.

## while day-jobbing in C\#, lean toward functional style

I have spent most of the last 20 years writing in C# but I was naturally biased toward functional style. I used to think this was a personal, almost _aesthetic_ preference until [Brian Beckman](https://www.linkedin.com/in/brianbeckman/) [@lorentzframe](https://twitter.com/lorentzframe) made me realize that this is also a _strategic_ preference for the sake of professional maintainability and clarity.

In a typical C# code review, I should be looking for these functional-style corrections:

| issue | recommendation |
|- |-
| ‘tall’ methods | decompose C# methods with too many lines into [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions) or [extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods); the names of these smaller chunks of code might reduce the need for comments |
| blocks of code with nested and/or a succession of `for` loops is hard to read | consider replacing the `for` loops with LINQ `.Select()` methods to ‘pipe’ from one set of data to another |
| disruptive or hard-to-read `if` blocks | use [C# pattern-matching](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching) which is heavily influenced by F# |
| wide `if` conditions | decompose into [local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions) or [extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) |
| a class has ‘too many’ static methods that get in the way of the instance members in terms of readability | consider separating these static methods into [extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) instead of partial classes |
| it is clear that we should return more than one type from a method but defining a class or interface for these types is overkill | return a [tuple with named fields](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names) from this C# method |
| the team agrees that we should ‘inject an interface into a method’ but defining a formal interface is overkill | use `Func<>` or `Action<>` in the method signature, effectively touching upon the [Strategy Pattern](https://en.wikipedia.org/wiki/Strategy_pattern) and recognizing the concept of [higher order functions](https://en.wikipedia.org/wiki/Higher-order_function) |
| the team is actually sick of `null` | consider using a C# `Option` library, like [Optional](https://github.com/nlkl/Optional) |
| the team is uncomfortable with throwing exceptions deep in the stack and would rather use ‘railways’ to bubble them up with fine/granular control | consider using a C# implementation of `Result<>` like what is available in [Functional Extensions for C#](https://github.com/vkhorikov/CSharpFunctionalExtensions) which introduces the concept of [Railway Oriented Programming](https://swlaschin.gitbooks.io/fsharpforfunandprofit/content/posts/recipe-part2.html) which is a step above the famous [“fluent” C# style](https://www.red-gate.com/simple-talk/development/dotnet-development/fluent-code-in-c/) |
| a team member is called out for [primitive obsession](https://www.arhohuttunen.com/primitive-obsession/) | F# is actually [designed for primitive obsession](https://swlaschin.gitbooks.io/fsharpforfunandprofit/content/posts/designing-with-types-single-case-dus.html) but [there are ways to approach it constructively in C#](https://enterprisecraftsmanship.com/posts/functional-c-primitive-obsession/)

<https://github.com/BryanWilhite/>
