---json
{
  "documentId": 0,
  "title": "Songhay Studio: MenuItemDatum Revisited",
  "documentShortName": "2014-08-16-songhay-studio-menuitemdatum-revisited",
  "fileName": "index.html",
  "path": "./entry/2014-08-16-songhay-studio-menuitemdatum-revisited",
  "date": "2014-08-16T07:00:00Z",
  "modificationDate": "2014-08-16T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-08-16-songhay-studio-menuitemdatum-revisited",
  "tag": "{\r\n  \"extract\": \"A PIMCO/TEKsystems colleague makes a great point: datum refers to a scalar value—as suggested by the oracle.sql.Datum class definition and its uses. This implies that the thinking behind my class name MenuItemDatum is deeply flawed (it was based on the a...\"\r\n}"
}
---

# Songhay Studio: MenuItemDatum Revisited

[<img alt="Songhay Display Item Models" src="https://farm6.staticflickr.com/5590/14935062741_b8219f22b1_z_d.jpg" style="float:right;margin:16px;">](https://www.flickr.com/photos/wilhite/14935062741/ "Songhay Display Item Models")

A PIMCO/TEKsystems colleague makes a great point: *datum* refers to a *scalar* value—as suggested by the `oracle.sql.Datum` [class definition](http://docs.oracle.com/database/121/JAJDB/oracle/sql/Datum.html) and its [uses](http://docs.oracle.com/database/121/JAJDB/oracle/sql/class-use/Datum.html). This implies that the thinking behind my class name `MenuItemDatum` is deeply flawed (it was based on the assumption that *datum* can be fractal—so the definition of singular and plural would be relativistic and fluid—but *datum* is a Latin word—and the Romans were all about locking things up in the absolutism of concrete [see “[MenuItemDatum, NameValuePair and ChartDataPoints](http://songhayblog.azurewebsites.net/Entry/Show/menuitemdatum-namevaluepair-and-chartdatapoints)”]!). Also, the use the word *Menu* is coupled too tightly to a particular visual.

Let’s sketch out something new:

* There should be interfaces called `ISortable`, `IColorable`, `ISelectable`.
* The core definition should be called `DisplayItemModel`, implementing `ISortable`.
* Then `ColorDisplayItemModel`, implementing `IColorable` and extending `DisplayItemModel`.
* Then, the ‘too-tight’ definition: `MenuDisplayItemModel` (which allows nesting children), implementing `ISelectable` and extending `ColorDisplayItemModel`.
* Finally, we can have `MediaMenuDisplayItemModel` and `MediaDisplayItemModel` (to hold members based on types from `System.Windows.Media`—more on this later).

The foundational change is replacing *datum* with *model*—which is incredibly obvious. This move coheres with the names used for the <acronym title="Model">MVVM</acronym> acronym. This effort should pack all of what I find beautiful about object-oriented and interface-based programming in one logical place! …can I get a bit more functional now?

<https://github.com/BryanWilhite/>
