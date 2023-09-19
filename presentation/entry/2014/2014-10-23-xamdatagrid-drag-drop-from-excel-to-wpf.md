---json
{
  "documentId": 0,
  "title": "XamDataGrid: Drag-Drop from Excel to WPF",
  "documentShortName": "2014-10-23-xamdatagrid-drag-drop-from-excel-to-wpf",
  "fileName": "index.html",
  "path": "./entry/2014-10-23-xamdatagrid-drag-drop-from-excel-to-wpf",
  "date": "2014-10-23T07:00:00Z",
  "modificationDate": "2014-10-23T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-10-23-xamdatagrid-drag-drop-from-excel-to-wpf",
  "tag": "{\r\n  \"extract\": \"The point of this post is to reintroduce System.Windows.DataObject.OleConverter (which I assume is an old, Don-Box-era friend in a relatively new .NET wrapper) and not to confirm that the XamDataGrid supports Excel and/or Object Linking and Embedding (OL...\"\r\n}"
}
---

# XamDataGrid: Drag-Drop from Excel to WPF

The point of this post is to reintroduce `System.Windows.DataObject.OleConverter` (which I assume is an old, Don-Box-era friend in a relatively new .NET wrapper) and not to confirm that the `XamDataGrid` supports Excel and/or Object Linking and Embedding (OLE) by default. This is what happens to the `XamDataGrid` I currently work with (which does have custom, Excel-related behaviors attached):
[<img alt="Drag-Drop from Excel to WPF" src="https://farm4.staticflickr.com/3918/15102737718_6c3e809013_o_d.png">](https://www.flickr.com/photos/wilhite/15102737718/ "Drag-Drop from Excel to WPF")

Debug is shows that the Range of cells selected for Drag is boxed in a `System.Windows.DataObject`, which has a `_innerData` field of type `System.Windows.DataObject.OleConverter`. Meanwhile, back in Excel we have this message:
[<img alt="Drag-Drop from Excel to WPF" src="https://farm3.staticflickr.com/2941/15289318885_f108490185_o_d.png">](https://www.flickr.com/photos/wilhite/15289318885/ "Drag-Drop from Excel to WPF")

Eventually, I see that I need to call `System.Windows.DataObject.GetFormats()` which returns:

```console
{string[25]}
    [0]: "EnhancedMetafile"
    [1]: "System.Drawing.Imaging.Metafile"
    [2]: "MetaFilePict"
    [3]: "Bitmap"
    [4]: "System.Drawing.Bitmap"
    [5]: "System.Windows.Media.Imaging.BitmapSource"
    [6]: "Biff12"
    [7]: "Biff8"
    [8]: "Biff5"
    [9]: "SymbolicLink"
    [10]: "DataInterchangeFormat"
    [11]: "XML Spreadsheet"
    [12]: "HTML Format"
    [13]: "Text"
    [14]: "UnicodeText"
    [15]: "System.String"
    [16]: "CSV"
    [17]: "Hyperlink"
    [18]: "Rich Text Format"
    [19]: "Embed Source"
    [20]: "Object Descriptor"
    [21]: "Link Source"
    [22]: "Link Source Descriptor"
    [23]: "Link"
    [24]: "Format129"
```

This, then, allows me to call `System.Windows.DataObject.GetData("CSV")` which returns:

```console
",MKT_VAL,PORTFOLIO_MANAGER,ACCOUNT_NAME\r\nXXXX,\" $224,679,351,495.25 \", Gross , XXXX Total Return Fund \r\n701,, Cudzil , XXXX Mortgage-Backed Securities Fund \r\nXXXX,\" $3,769,059,862.42 \", Kiesel , XXXX Investment Grade Corporate Portfolio \r\n"
```

…where `XXXX` is added for this public demonstration.

<https://github.com/BryanWilhite/>
