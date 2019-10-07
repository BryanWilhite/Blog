---json
{
  "author": "Bryan Wilhite",
  "content": "I developed MenuItemDatum, NameValuePair and ChartDataPoints as common data transfer objects over WCF-based technologies, including RIA Services. I’m sure this effort to develop ‘common’ objects to be shared among various enterprise solutions is not the ...",
  "inceptDate": "2013-01-13T16:00:00-08:00",
  "isPublished": true,
  "slug": "menuitemdatum-namevaluepair-and-chartdatapoints",
  "title": "MenuItemDatum, NameValuePair and ChartDataPoints."
}
---

I developed `MenuItemDatum`, `NameValuePair` and `ChartDataPoints` as common data transfer objects over <acronym title="Windows Communication Foundation">WCF</acronym>-based technologies, including RIA Services. I’m sure this effort to develop ‘common’ objects to be shared among various enterprise solutions is not the first one in the world. I came to this place because of a key limitation in RIA Services (and/or Entity Framework): ‘[By default, an EF Entity cannot be a property of another object.](http://songhayblog.azurewebsites.net/entry/show/ria-services-and-ef-entities)’ This limitation alone should inspire many of us to send a relatively large ‘meta’ dataset to the Client to “bootstrap” the application. I usually call this ‘meta’ dataset `ClientMetadata`.

Here’s a sample `ClientMetadata` class:

    public class 
    ClientMetadata
    {
        public IEnumerable&lt;NameValuePair&gt; Attributes { get; set; }
        public IEnumerable&lt;MenuItemDatum&gt; MainMenu { get; set; }
        public IEnumerable&lt;MenuItemDatum&gt; Departments { get; set; }
        public IEnumerable&lt;ChartDataPoints&gt; ChartsData { get; set; }
    }

A `ClientMetadata` object passed over “the wire” hydrates the `ClientViewModel` in my Silverlight applications. This class definition intends to imply that:

*   The Main Menu and Departments are to be represented as Menu items.
*   One set of data defines chart data for multiple charts.
*   Multiple items from multiple database entities can be “shredded” into attributes as name-value pairs.

## What is a Menu Item Datum?

We must remember that in English (and Latin) the word *data* denotes plural and *datum*, singular. So my intention is to define the *datum* referring to data of the domain (usually entities). `MenuItemDatum` is a lightweight ‘pointer’ to an Entity. When the <acronym title="User Interface">UI</acronym> displays a list box of Departments, the `MenuItemDatum` is used to ‘point’ to its respective Department Entity on the server. It is too expensive to send the entire Entity to the Client just for a stupid list box—the `MenuItemDatum` is here to represent a small ‘reference’ to the real stuff on the Server.

## Why convert a NameValuePair into a Dictionary? It’s a XAML thing…

To me, this XAML binding is very unusual but very useful: `Text = "{Binding FieldNames[MyCustomFieldName]}"`. This binding declares that there is a property within `DataContext` called `FieldNames` with a key called `MyCustomFieldName`. This `FieldNames` property is a `Dictionary&lt;string, string&gt;`.

I continually have forgotten since the release of <acronym title="Windows Communication Foundation">WCF</acronym> in 2007 that `Dictionary&lt;TKey, TValue&gt;` cannot be sent over the wire. I assume without being informed that `KeyedCollection&lt;TKey, TItem&gt;` was developed to address this issue (poorly—[because](http://msdn.microsoft.com/en-us/library/ms132438.aspx) “…unlike dictionaries, an element of `KeyedCollection&lt;TKey, TItem&gt;` is not a key/value pair; instead, the entire element is the value and the key is embedded within the value.”).

My Band-Aid is to convert a set of `NameValuePair` into `Dictionary&lt;string, string&gt;` with an extension method. This is one way to address the problem of RIA Services lack of support for serializing `Dictionary&lt;T&gt;`. Once we have a Dictionary it can be bound to directly—in <acronym title="Extensible Application Markup Language">XAML</acronym>.
