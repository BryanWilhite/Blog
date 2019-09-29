---json
{
  "author": "Bryan Wilhite",
  "content": "Some younger people in Pasadena working for JPL interviewed me for a Web developer position. Even though the drive from Mar Vista to Pasadena would have been just as horrible as driving from Mar Vista to Newport Beach (a commute I did for over a year and...",
  "inceptDate": "2016-06-11T00:06:04.1187361-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "a-2015-meeting-with-jpl-when-i-started-using-linq-in-interviews",
  "sortOrdinal": 0,
  "tag": null,
  "title": "A 2015 meeting with JPL when I started using LINQ in interviews…"
}
---

Some younger people in Pasadena working for JPL interviewed me for a Web developer position. Even though the drive from Mar Vista to Pasadena would have been just as horrible as driving from Mar Vista to Newport Beach (a commute I did for over a year and a half)—and even though it is clear that JPL is not a Microsoft .NET shop—, I could not pass up the chance to work with such an historical and interplanetary organization.

I like the fact that JPL gave me a take-home “test” which has two coding questions that I will reflect on here. The take-home “test” is different from live coding in that I am allowed to work like I work most of the time; whereas the live coding is more of social performance that I have almost no opportunity to practice in real life. I would have to start a YouTube channel and record myself live coding to immediately do something about developing this ceremonial skill which sounds right now a bit time-consuming.

So here is the first JPL question:
<blockquote>

1. Write a program that prints the numbers from 1 to 100. But for multiples of three print “JPL” instead of the number and for the multiples of five print “NASA”. For numbers which are multiples of both three and five print “JPL NASA”. Implement in the language of your choice, or in pseudo-code.
</blockquote>

This is my answer (written in LINQPad):


Enumerable
    .Range(1, 100)
    .Select(i =&gt;
    {
        string JPL = "JPL", NASA = "NASA";
        
        Func&lt;bool&gt; isMultipleOf3 = () =&gt; ((i % 3) == 0);
        Func&lt;bool&gt; isMultipleOf5 = () =&gt; ((i % 5) == 0);
        
        if(isMultipleOf3() &amp;&amp; isMultipleOf5()) return string.Format("{0} {1}", JPL, NASA);
        else if(isMultipleOf3()) return JPL;
        else if(isMultipleOf5()) return NASA;
        else return i.ToString();
    })
    .Dump();
    

This answer is an attempt to show the interviewers that I am interested in solving problems with a traditional imperative language—but I am using the functional programming aspects of this language. This is an effort to demonstrate my ability to find compromise between two worlds: the functional and the imperative.

Next question:
<blockquote>

2. You have some data stored in a potentially infinite tree structure. You need to traverse and pull out a piece of data in each node within the tree and put that into a list or an array. How would you go about doing this?
</blockquote>

The first issue is to flatten the tree structure. This can be done with recursion. In C#, we can define an extension method like this:


public static IEnumerable&lt;TSource&gt; Flatten&lt;TSource&gt;(this IEnumerable&lt;TSource&gt; source, Func&lt;TSource, IEnumerable&lt;TSource&gt;&gt; childGetter)
{
    if (source == null) return Enumerable.Empty&lt;TSource&gt;();
    var flattenedList = new List&lt;TSource&gt;(source);
    source.ForEachInEnumerable(i =&gt;
    {
        var children = childGetter(i);
        if (children != null) flattenedList.AddRange(children.Flatten(childGetter));
    });
    return flattenedList;
}
    

I suppose with a near-infinite tree, we can use `Lazy&lt;TSource&gt;` instead of just `TSource` denoted above. `TSource` is, of course, the type of the tree structure. Let's say `TSource` is `MenuDisplayItemModel`:


var tree = new []
{
    new MenuDisplayItemModel
    {
        ItemName = "item-1-1",
        ChildItems = new []
        {
            new MenuDisplayItemModel { ItemName = "item-2-1" },
            new MenuDisplayItemModel { ItemName = "item-2-2" },
            new MenuDisplayItemModel
            {
                ItemName = "item-2-3",
                ChildItems = new[]
                { 
                    new MenuDisplayItemModel { ItemName = "item-3-1" },
                    new MenuDisplayItemModel { ItemName = "item-3-2" },
                }
            },
        }
    },
    new MenuDisplayItemModel { ItemName = "item-1-2" },
};
tree.Flatten(i =&gt; i.ChildItems).Select(i =&gt;i.ItemName).Dump();
    

The folks interviewing me at JPL were ‘too impressed’ with what I am trying to do here—‘impressed’ with the answer to the first question but the second question is incomplete (I really did not handle the “infinite” nature of the data source—some kind of read-only, forward-only, paging deal? I crammed too much into this Microsoft-specific `Lazy&lt;T&gt;` thing…). They responded to my work with questions about whether my fellow, JPL coworkers would understand the “style” of programming here. This reaction told me that functional programming was not a “thing” with these interviewers—in addition to their non-investment in Microsoft. The JPL job I applied for was specified as an ASP.NET MVC job—but when you actually look at what web technology is currently in play (and when you ask about the history) you should find very little Microsoft-based work.

This interview was the first time I took the opportunity to use LINQ. I plan to take this opportunity again and again. I prefer to openly celebrate the relative freedom of using LINQPad on the fly (over working more formally in Visual Studio). This flagrant preference of mine will not work in all situations:

*   I will be dismissed as one who is Microsoft-biased.
*   I will be dismissed as one who is too dependent on one programming language instead of pseudo-coding the suggestion that I am “open” to multiple programming languages.
*   I will be dismissed as one who is using functional programming techniques “unnecessarily” instead of respecting the traditional, C++ imperative approach.

All of these dismissals work in my favor (even though such a thing is not pleasant) it allows me to truly escape a “bad cultural fit.”
