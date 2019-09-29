---json
{
  "author": "Bryan Wilhite",
  "content": "I lost a bit of time with a “Can’t set the DataSource on a DataPresenter that has items added explicitly through the DataItems collection…” error because of failing to wrap FieldLayout tags with FieldLayouts tags (what?)… so this is the minimal XAML for ...",
  "inceptDate": "2014-09-13T00:00:00",
  "isPublished": true,
  "slug": "songhay-studio-minimal-xamdatagrid-markup",
  "title": "Songhay Studio: minimal XamDataGrid markup…"
}
---

I lost a bit of time with a “Can’t set the `DataSource` on a `DataPresenter` that has items added explicitly through the `DataItems` collection…” error because of failing to wrap `FieldLayout` tags with `FieldLayouts` tags (what?)… so this is the minimal XAML for the `XamDataGrid`:

    &lt;igDP:XamDataGrid
        DataSource="{Binding RowsCollectionView}"
        VirtualizingStackPanel.VirtualizationMode="Recycling"
        VirtualizingStackPanel.IsVirtualizing="True"&gt;
        &lt;igDP:XamDataGrid.FieldLayouts&gt;
            &lt;igDP:FieldLayout&gt;
            &lt;/igDP:FieldLayout&gt;
        &lt;/igDP:XamDataGrid.FieldLayouts&gt;
    &lt;/igDP:XamDataGrid&gt;

This Control is so complex, it’s worth my time to list a few highlights:

*   Declare `XamDataGrid.RecordLoadMode="PreloadRecords"` to improve scrolling performance.
*   Consider declaring a `XamDataGrid.SuppressedEvents` collection to improve performance.
*   Consider declarations for `FieldLayoutSettings` for `SelectionTypeCell`, `SelectionTypeField` and `SelectionTypeRecord` (all set to `Extended`) when trying to allow selecting grid rows over editing data.
*   Declare `FieldLayoutSettings.SortEvaluationMode="UseCollectionView"` to drive sorting from an `ICollectionView` instance in the View Model.
