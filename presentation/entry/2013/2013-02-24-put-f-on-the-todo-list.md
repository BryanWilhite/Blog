---json
{
  "author": "Bryan Wilhite",
  "content": "Warning: I am going to knowingly ramble… so you may not want to read this… this, a note to self…According to .NET Rocks! episode #846, “Yan Cui Builds Games in F#,” I think I was given a real and present reason to use F# in the very near future. It has s...",
  "inceptDate": "2013-02-24T16:00:00-08:00",
  "isPublished": true,
  "slug": "put-f-on-the-todo-list",
  "title": "Put F# on the TODO list?"
}
---

Warning: I am going to knowingly ramble… so you may not want to read this… this, a note to self…

According to *.NET Rocks!* episode #846, “[Yan Cui Builds Games in F#](http://www.dotnetrocks.com/default.aspx?showNum=846),” I think I was given a real and present reason to use F# in the very near future. It has something to do with *tuples*. In “[Learning F# – Part 4](http://theburningmonk.com/2010/01/learning-f-part-4/),” Yan writes:
<blockquote>

A tuple (pro­nounced “two-pull”) is an ordered collection of data, and an easy way to group common pieces of data together. …A tuple type is described by a list of the tuple’s elements’ types, separated by asterisks…
</blockquote>

I am familiar with tuples from a .NET Generics point of view but what Yan is doing here is defining them from a data access point of view. So: we can see in this stackoverflow.com question, “[Return Tuple from EF select](http://stackoverflow.com/questions/2118688/return-tuple-from-ef-select),” that Entity Framework can work with tuples through LINQ to Objects. What would be interesting to me is seeing the way toward using tuples with the `SqlQuery&lt;T&gt;()` method of the Entity Framework. [Mark Zhou](http://www.markzhou.com/blog/post/2011/06/02/Use-dynamic-type-in-Entity-Framework-41-SqlQuery()-method.aspx) writes:
<blockquote>

…if you want to use the dynamic type or anonymous type as its return type, you will probably get your code compiled but receive exceptions during runtime. …The reason is that the Entity Framework does the type mapping using Reflection. Additionally, Entity Framework searches each property on your returning type, and do mapping by matching the property name and the SQL returning column name, if your type doesn’t have any public property (public fields don’t work) defined, there will be no mappings [happening].
</blockquote>

However, in the middle of writing/rambling this stuff I dropped off and ran a test:

            [TestMethod]
            public void ShouldSelectIntoTuples()
            {
                var context = new GenericWebEntities(connectionStringSonghay);
                var sql = @"
        SELECT
            [Item1] = DocumentId
        ,   [Item2] = Title
        FROM
            Document
        ORDER BY
            Title
    ";
                var data = context.Database.SqlQuery&lt;Tuple&lt;int, string&gt;&gt;(sql);
                Assert.IsNotNull(data, "The expected data is not here.");
                Assert.IsNotNull(data.Count() &gt; 0, "The expected data is not here.");
            }

It turns out that this test fails because `SqlQuery&lt;T&gt;()` requires types with parameter-less constructors. So I dropped back to this:

            [TestMethod]
            public void ShouldSelectIntoProjectionClass()
            {
                var context = new GenericWebEntities(connectionStringSonghay);
                var sql = @"
        SELECT
            [Column1] = DocumentId
        ,   [Column2] = Title
        FROM
            Document
        ORDER BY
            Title
    ";
                var data = context.Database.SqlQuery&lt;TwoColumnProjection&lt;int, string&gt;&gt;(sql);
                Assert.IsNotNull(data, "The expected data is not here.");
                Assert.IsNotNull(data.Count() &gt; 0, "The expected data is not here.");
            }

[<img alt="Programming F#: A comprehensive guide for writing simple code to solve complex problems (Animal Guide)" src="http://ecx.images-amazon.com/images/I/41DsEYWRNML._SL160_.jpg" style="float:left;margin:16px;">](http://www.amazon.com/Programming-comprehensive-writing-complex-problems/dp/0596153643%3FSubscriptionId%3D1SW6D7X6ZXXR92KVX0G2%26tag%3Dthekintespacec00%26linkCode%3Dxm2%26camp%3D2025%26creative%3D165953%26creativeASIN%3D0596153643 "Programming F#: A comprehensive guide for writing simple code to solve complex problems (Animal Guide)")

And this works! This success led me look into stuff like “[Understanding Tuples in .NET 4.0 and .NET 2.0/3.0/3.5](http://www.fidelitydesign.net/?p=71)” by Matthew Abbot, which actually shows me implementations of tuple that uses a parameter-less constructor. But what’s the advantage of this custom tuple implementation over my `TwoColumnProjection` class? I’m thinking I should just spit out `TwoColumnProjection&lt;&gt;` all the way to `FiveColumnProjection&lt;&gt;` and call it a day. These generic projection classes can be handy tools for dealing with legacy database tables that are not automatically represented by EF entities (e.g. a crappy many-to-many table without a primary key that I am unable to change for stupid-ass reasons or, more commonly, stored procedures projecting from a temporary table). It must be mentioned, however, that I am writing this without testing the level productivity of EF Complex Types—what Julie Lerman covers in “Importing Stored Procedures that Return Types Other than Entities” of the article, “[Stored Procedures in the Entity Framework](http://msdn.microsoft.com/en-us/data/gg699321.aspx).”

So what does this have to do with F#? Well, just like the [Chewbacca Defense](http://en.wikipedia.org/wiki/Chewbacca_defense), it turns out that it’s nothing… it has nothing to do with this case—because the tuples that ship from Microsoft are not currently supported by Entity Framework’s `SqlQuery&lt;T&gt;()`. This means that I can’t start using tuples as general-purpose data-transfer objects (with `SqlQuery&lt;T&gt;()`). This use of tuples would have encouraged me to use F# because tuple syntax in F# is so much simpler (but the implementation of EF in F# [looks weird](http://blogs.msdn.com/b/visualstudio/archive/2011/04/04/f-code-first-development-with-entity-framework-4-1.aspx) to me)… This crazy jaunt *did* help me see that I should use a bunch of generic projection classes.

### F# and the Linked List

I get this weird feeling that I’m going to need to take Linked Lists seriously. A stackoverlflow.com question like “[When should I use a List vs a LinkedList](http://stackoverflow.com/questions/169973/when-should-i-use-a-list-vs-a-linkedlist)[?]” is just the tip of the iceberg. In “[Why I Love F#: Lists—The Basics](http://diditwith.net/2008/03/03/WhyILoveFListsTheBasics.aspx)” Dustin Campbell reveals what’s deep at the core of F#: the *immutable* linked list:
<blockquote>

And there you have it. Believe it or not, appending two immutable lists can actually be faster and more memory efficient than appending mutable lists because fewer nodes have to be copied.
</blockquote>

This strongly suggests to me that Linked List usage is related to satisfying the need for massive, write-only, in-memory sets of data—sounds like some part of that gaming stuff Yan was talking about on *.NET Rocks!*
