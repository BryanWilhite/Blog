---json
{
  "documentId": 0,
  "title": "Silverlight 4: Poor Man’s Task Wait-All",
  "documentShortName": "2012-03-02-silverlight-poor-mans-task-wait-all",
  "fileName": "index.html",
  "path": "./entry/2012-03-02-silverlight-4-poor-man-s-task-wait-all",
  "date": "2012-03-02T23:51:00Z",
  "modificationDate": "2012-03-02T23:51:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-03-02-silverlight-poor-mans-task-wait-all",
  "tag": "{\r\n  \"extract\": \"Silverlight 4 does not have the Task Parallel Library. According to Danny Shih (and what I see in MSDN documentation) it is now in Silverlight 5. For SL4, you can, however, download a NuGet Package (translated from Mono) to compensate—or you can: Make a B...\"\r\n}"
}
---

# Silverlight 4: Poor Man’s Task Wait-All

Silverlight 4 does not have the Task Parallel Library. [According to Danny Shih](http://blogs.msdn.com/b/pfxteam/archive/2011/09/01/10204554.aspx) (and what I see in <acronym title="Microsoft Developer Network">MSDN</acronym> documentation) it is now in Silverlight 5. For SL4, you can, however, [download a NuGet Package](http://nuget.org/packages/System.Threading.Tasks) (translated from Mono) to compensate—or you can:

* Make a Boolean array of `false` items equal to the number of asynchronous tasks.
* In the complete-handler for each task, mark one item in the Boolean array `true` and check to see whether all items in the array are `true`.
* When all items in the array are true the wait is over.

My scribble looks like this:

```cs
var asyncOperationsList = new bool[] { false, false };
var asyncOperationsComplete = new Action(() =>
{
    if(asyncOperationsList.Count(i => i) != asyncOperationsList.Count()) return;
    /* wait is over! */
});

//Catalog the XAP downloaded by the Application Loader, the BiggestBox Index:
uri = new Uri(Application.Current.
    Host.InitParams["LoaderInfoXapPath"], UriKind.Relative);
this.AddToAggregateCatalog(CompositionUtility.DownloadCatalog(uri,
    new Action<object, AsyncCompletedEventArgs>(
    (o, args) =>
    {
        asyncOperationsList[0] = true;
        asyncOperationsComplete();
    })));
//Catalog the XAP with the BiggestBox Index Part:
uri = new Uri(Application.Current
    .Host.InitParams["BiggestBoxIndexXapPath"], UriKind.Relative);
this.AddToAggregateCatalog(
    CompositionUtility.DownloadCatalog(uri,
        new Action<object, AsyncCompletedEventArgs>(
        (o, args) =>
        {
            asyncOperationsList[1] = true;
            asyncOperationsComplete();
        })));
```

I then formalized my hack with this limited-edition, commemorative class:

```cs
/// <summary>
/// Defines the grouping and completion-tracking of asynchronous operations.
/// </summary>
/// <remarks>
/// This class is a poor substitute for what is lacking in Silverlight 4
/// (and older) with regard to features in the Task Parallel Library.
/// </remarks>
public class AsyncOperationGroup
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncOperationGroup"/> class.
    /// </summary>
    /// <param name="numberOfOperations">The number of operations.</param>
    /// <param name="completionAction">The completion action.</param>
    public AsyncOperationGroup(byte numberOfOperations, Action completionAction)
    {
        if(completionAction == null) throw new ArgumentNullException("completionAction", "The completion action is null.");
        this._completionAction = completionAction;
        this._asyncOperationCompletionList = new bool[numberOfOperations];
    }
    /// <summary>
    /// Marks the operation complete.
    /// </summary>
    /// <param name="operationOrdinal">The zero-based operation ordinal.</param>
    public void MarkOperationComplete(byte operationOrdinal)
    {
        if(operationOrdinal >= this._asyncOperationCompletionList.Length)
            throw new ArgumentException("The ordinal is not in the completion list.", "operationOrdinal");
        this._asyncOperationCompletionList[operationOrdinal] = true;
        if(this._asyncOperationCompletionList.Count(i => i) != this._asyncOperationCompletionList.Count()) return;
        this._completionAction.Invoke();
    }
    Action _completionAction;
    bool[] _asyncOperationCompletionList;
}
```

So now my code-smell wafts like this:

```cs
byte numberOfOperations = 2;
var catalogs = new DeploymentCatalog[numberOfOperations];
var operations = new AsyncOperationGroup(numberOfOperations,
() =>
{
    this.AddToAggregateCatalog(catalogs[0]);
    this.AddToAggregateCatalog(catalogs[1]);
    base.Compose();
    this.AddToCompositionBatch(this);
    //etc…
});

//Catalog the XAP downloaded by the Application Loader, the BiggestBox Index:
var uri0 = new Uri(Application.Current.
    Host.InitParams["LoaderInfoXapPath"], UriKind.Relative);
catalogs[0] = CompositionUtility.DownloadCatalog(uri0,
(s, args) =>
{
    operations.MarkOperationComplete(0);
});

//Catalog the XAP with the BiggestBox Index Part:
var uri1 = new Uri(Application.Current
    .Host.InitParams["BiggestBoxIndexXapPath"], UriKind.Relative);
catalogs[1] = CompositionUtility.DownloadCatalog(uri1,
(s, args) =>
{
    operations.MarkOperationComplete(1);
});
```

So, now I have my first real-world reason why Silverlight 5 is desirable.

@[BryanWilhite](https://twitter.com/BryanWilhite)
