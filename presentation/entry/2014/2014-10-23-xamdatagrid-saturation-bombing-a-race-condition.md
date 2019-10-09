---json
{
  "documentId": 0,
  "title": "XamDataGrid: saturation-bombing a race condition",
  "documentShortName": "2014-10-23-xamdatagrid-saturation-bombing-a-race-condition",
  "fileName": "index.html",
  "path": "./entry/2014-10-23-xamdatagrid-saturation-bombing-a-race-condition",
  "date": "2014-10-23T07:00:00.000Z",
  "modificationDate": "2014-10-23T07:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-10-23-xamdatagrid-saturation-bombing-a-race-condition",
  "tag": "{\r\n  \"extract\": \"Everything I am going to write in this post is based on the assumption that any user interaction related to filtering the XamDataGrid grid will cause the XamDataGrid.RecordManager.FilteredInDataItems to change—but the change is not instantaneous: the cha...\"\r\n}"
}
---

# XamDataGrid: saturation-bombing a race condition

Everything I am going to write in this post is based on the assumption that any user interaction related to filtering the `XamDataGrid` grid will cause the `XamDataGrid.RecordManager.FilteredInDataItems` to change—but the change is not instantaneous: the change occurs within an unknown period of time. Send me a Tweet with some great news should you consider it known!

I can use Prism-based messaging to send the “current” `FilteredInDataItems` payload to the backing View Model for processing—in my squalid case, the ‘processing’ has to do with setting the background color of rows (by setting a View Model Boolean “flag”) based on irregular data (not on regular position). In Prism parlance we “publish” a message (or “event”—which is a questionable term to me), it follows that I have `BombFilteredInDataItems()` in my view hosting the `XamDataGrid`:

```c#
void BombFilteredInDataItems(string key)
{
    Action sendPrismMessage = () =>
    {
        if (!FrameworkDispatcherUtility.HasCurrentWindowsApplication()) return;
        var collection = this.FxGrid.RecordManager.FilteredInDataItems;
        var data = new KeyValuePair<string, ICollectionView>(string.Format("MyView:{0}", key), collection);
        this._eventAggregator.Publish<KeyValuePair<string, ICollectionView>>(data);
    };

    Task.Delay(150)
            .ContinueWith(_ => sendPrismMessage(), TaskScheduler.FromCurrentSynchronizationContext());

    Task.Delay(250)
            .ContinueWith(_ => sendPrismMessage(), TaskScheduler.FromCurrentSynchronizationContext());
}
```

This `BombFilteredInDataItems()` method contains an action (the actual intent of the method), which is fired twice around a 100ms interval. Do you not see the non-deterministic desperation here? Not the kind of post an “intelligent” developer should share in public, eh?

So I call this embarrassment ‘saturation bombing a race condition’ as (`BombFilteredInDataItems()` is in a race with the “current” state of `FilteredInDataItems`). According to Joe Albhari, stated in his excellent “[Becoming a C# Time Lord](http://channel9.msdn.com/Events/TechEd/Australia/2013/DEV422)” talk, 50ms is a “long-running operation” so this saturation bombing around 100ms is on the order of eons of computing time. This is as close to hacking as I would like to get (in the enterprise context). I would prefer that the grid would ‘know’ when its `FilteredInDataItems` payload is “current” perhaps having a throttled collection-changed event (like `ObservableCollection<T>.CollectionChanged` but mixed with Reactive Extensions).

For my sanity, I must introduce the concept of “user idle time” which suggests that this idea of waiting for inactivity is not new (see “[Detect time of last user interaction with the OS](http://stackoverflow.com/questions/1037595/c-sharp-detect-time-of-last-user-interaction-with-the-os)”). It should follow that idle time with respect to the user can be reborn as idle time with respect to an Observable Collection.

@[BryanWilhite](https://twitter.com/BryanWilhite)
