---json
{
  "author": "Bryan Wilhite",
  "content": "I am told that there are more than a few former Microsoft employees working fulltime at Google. I talked to one in fact. He was prepared to share a Google Doc with me and test me out but I had to reschedule and the second guy was clearly non-Microsoft. H...",
  "inceptDate": "2016-05-20T22:11:53.2180006-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "google-interview-cumsum-challenge",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Google Interview CUMSUM Challenge"
}
---

I am told that there are more than a few former Microsoft employees working fulltime at Google. I talked to one in fact. He was prepared to share a Google Doc with me and test me out but I had to reschedule and the second guy was clearly non-Microsoft. He works on a Google-customized version of Eclipse every day (I historically preferred NetBeans). His team officially does not recognize `git` culture as he proudly pronounced the word *Perforce*. Most importantly, when I attempted to work on his coding challenge he stopped me. He did *not* want me to use LINQ (from my point of view he wanted me to re-implement LINQ *in** addition to* working on the challenge he presented).

He presented me with the challenge of implementing the [CUMSUM function from the R programming language](https://stat.ethz.ch/R-manual/R-devel/library/base/html/cumsum.html). Long story short: after his rejection of LINQ, I refused to participate further in the interview. (It might help to mention that Google contacted *me*—I would not volunteer to run this experiment on *them*.)

Microsoft products like [Typescript](https://www.typescriptlang.org/) are being used at Google but the penetration of Microsoft cultural awareness is not as deep as I would prefer (optimism on my part). Unless I am applying for a job to work on the .NET Framework itself, I do *not* expect an interviewer to stop me from using LINQ. Should I have been able to solve the problem within the time pressure allotted, I *still *would have been taken aback by the Google-cultural distance from Microsoft technologies. Additionally, this was the second live-coding interview under my belt (my first was actually [with Microsoft](http://songhayblog.azurewebsites.net/)) and I am even more convinced that this approach is too adversarial and ultimately meaningless (I would give a take-home test and follow it up with in-depth questions about the code—*and then *resort to live coding a variation based on the take-home original—probably too time-consuming for busy, *expensive* engineers—and, yes, I have conducted developer interviews).

As is customary, after my failure during the interview, I took some time with LINQPad to solve the problem alone. The interviewer supplied me with the signature of this function and two examples of output:


//cumsum(int[] array, int startPos, int count);
var set = new[] { 4, 1, 0, 3, 2 };
cumsum(set, 3, 4) == new[] { 3, 5, 9, 10 };
cumsum(set, 4, 2) == new[] { 2, 6 };
    

He also mentioned that `count` can extend beyond the upper bound of the array, leading me to add that the logic should *wrap around* the end of the array, pulling items from the beginning. I stated *within the allotted time* of the interview that I would work on developing a generic function that can perform this ‘wrap’ operation. What I failed to do was produce this function seconds after my statement (which means that I am not worthy of Google). Anyway, this is my wrapping extension method using LINQ:


public static IEnumerable&lt;T&gt; Wrap&lt;T&gt;(this IEnumerable&lt;T&gt; enumerable, int startPos, int count)
{
    if (enumerable == null) return Enumerable.Empty&lt;T&gt;();
    var length = enumerable.Count();
    if(startPos &gt; length) throw new ArgumentException("The start position is larger than the length of the enumerable.", "startPos");
    var wrappedSet = enumerable
        .Skip(startPos)
        .Union(enumerable.Take(length - startPos));
    return wrappedSet;
}
    

In LINQPad I can run this:


var set = new[] { 4, 1, 0, 3, 2 };
set.Wrap(3, 4).Dump();
    

and `Dump()` out this:


new[] { 3, 2, 4, 1 }
    

Now, I have no idea why anyone would want to do this because I am not an R programmer or a serious student of statistics (and it has been decades since I wrote the words *Eigen values*). My ignorance does not stop me from moving to the next step in the form of another LINQ extension method:


public static IEnumerable&lt;int&gt; ToCulmulativeSum(this IEnumerable&lt;int&gt; enumerable, int startPos, int count)
{
    if (enumerable == null) return Enumerable.Empty&lt;int&gt;();
    var wrappedSet = enumerable.Wrap(startPos, count);
    wrappedSet.Dump("wrapped set");
    return wrappedSet
        .Select((x, i) =&gt; x + wrappedSet.Take(i).Sum());
}
    

This `ToCulmulativeSum()` method is the correct solution by my standards—but, as whined about earlier, it is not sufficient for Google. In order to be a “smart” developer, I would have to implement every single LINQ extension method used in the examples above. Money cannot buy everything and this is intellectually (and aesthetically) satisfying enough for me:


var set = new[] { 4, 1, 0, 3, 2 };
set.ToCulmulativeSum(3, 4).Dump();
set.ToCulmulativeSum(4, 2).Dump();
    

As soon as [Google owns a programming language that has LINQ-like syntax](http://ahmetalpbalkan.github.io/go-linq/) that most Google employees use every day, all of this stuff here will suddenly be OK. I doubt that Google will use C# in spite of its open-source status.

It may be of interest to mention that I would likely not be able to solve this problem again in another interview. I tend to fail to memorize solutions to problems that I have already written down. Programmers in the real world are experts at looking stuff up—even the stuff we’ve written down in the past. The luxury of memorizing even 5% of what we have learned comes from socializing with—and even dearly *befriending*—others who truly love to hear about these little adventures. Some of us do not have this luxury—and we literally pay for it in terms of velocity of career growth.

### Related Links

*   [The Go Programming Language](https://golang.org/)
*   `go-linq`: “[.NET's Language Integrated Query (LINQ) library for Go](http://ahmetalpbalkan.github.io/go-linq/)”
        
*   “[countless times I was refused even an interview because I didn’t have a computer science degree](http://techcrunch.com/2016/05/10/please-dont-learn-to-code/)”
*   “[Thoughts on Take Home Interviews](http://www.elidedbranches.com/2016/05/brief-thoughts-on-take-home-interviews.html)”
