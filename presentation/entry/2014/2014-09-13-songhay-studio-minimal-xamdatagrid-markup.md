---json
{
  "documentId": 0,
  "title": "Songhay Studio: minimal XamDataGrid markup…",
  "documentShortName": "2014-09-13-songhay-studio-minimal-xamdatagrid-markup",
  "fileName": "index.html",
  "path": "./entry/2014-09-13-songhay-studio-minimal-xamdatagrid-markup",
  "date": "2014-09-13T07:00:00Z",
  "modificationDate": "2014-09-13T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-09-13-songhay-studio-minimal-xamdatagrid-markup",
  "tag": "{\r\n  \"extract\": \"I lost a bit of time with a “Can’t set the DataSource on a DataPresenter that has items added explicitly through the DataItems collection…” error because of failing to wrap FieldLayout tags with FieldLayouts tags (what?)… so this is the minimal XAML for ...\"\r\n}"
}
---

# Songhay Studio: minimal XamDataGrid markup…

I lost a bit of time with a “Can’t set the `DataSource` on a `DataPresenter` that has items added explicitly through the `DataItems` collection…” error because of failing to wrap `FieldLayout` tags with `FieldLayouts` tags (what?)… so this is the minimal XAML for the `XamDataGrid`:

```xml
<igDP:XamDataGrid
    DataSource="{Binding RowsCollectionView}"
    VirtualizingStackPanel.VirtualizationMode="Recycling"
    VirtualizingStackPanel.IsVirtualizing="True">
    <igDP:XamDataGrid.FieldLayouts>
        <igDP:FieldLayout>
        </igDP:FieldLayout>
    </igDP:XamDataGrid.FieldLayouts>
</igDP:XamDataGrid>
```

This Control is so complex, it’s worth my time to list a few highlights:

* Declare `XamDataGrid.RecordLoadMode="PreloadRecords"` to improve scrolling performance.
* Consider declaring a `XamDataGrid.SuppressedEvents` collection to improve performance.
* Consider declarations for `FieldLayoutSettings` for `SelectionTypeCell`, `SelectionTypeField` and `SelectionTypeRecord` (all set to `Extended`) when trying to allow selecting grid rows over editing data.
* Declare `FieldLayoutSettings.SortEvaluationMode="UseCollectionView"` to drive sorting from an `ICollectionView` instance in the View Model.

@[BryanWilhite](https://twitter.com/BryanWilhite)
