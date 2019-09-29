---json
{
  "author": "Bryan Wilhite",
  "content": "Silverlight 4 does not have the Task Parallel Library. According to Danny Shih (and what I see in MSDN documentation) it is now in Silverlight 5. For SL4, you can, however, download a NuGet Package (translated from Mono) to compensate—or you can:Make a B...",
  "inceptDate": "2012-03-02T15:51:00",
  "isPublished": true,
  "slug": "silverlight-poor-mans-task-wait-all",
  "title": "Silverlight 4: Poor Man’s Task Wait-All"
}
---

Silverlight 4 does not have the Task Parallel Library. [According to Danny Shih](http://blogs.msdn.com/b/pfxteam/archive/2011/09/01/10204554.aspx) (and what I see in <acronym title="Microsoft Developer Network">MSDN</acronym> documentation) it is now in Silverlight 5. For SL4, you can, however, [download a NuGet Package](http://nuget.org/packages/System.Threading.Tasks) (translated from Mono) to compensate—or you can:

*   Make a Boolean array of `false` items equal to the number of asynchronous tasks.
*   In the complete-handler for each task, mark one item in the Boolean array `true` and check to see whether all items in the array are `true`.
*   When all items in the array are true the wait is over.

My scribble looks like this:


var asyncOperationsList = new bool[] { false, false };
var asyncOperationsComplete = new Action(() =&gt;
{
    if(asyncOperationsList.Count(i =&gt; i) != asyncOperationsList.Count()) return;
    /* wait is over! */
});
//Catalog the XAP downloaded by the Application Loader, the BiggestBox Index:
uri = new Uri(Application.Current.
    Host.InitParams["LoaderInfoXapPath"], UriKind.Relative);
this.AddToAggregateCatalog(CompositionUtility.DownloadCatalog(uri,
    new Action&lt;object, AsyncCompletedEventArgs&gt;(
    (o, args) =&gt;
    {
        asyncOperationsList[0] = true;
        asyncOperationsComplete();
    })));
//Catalog the XAP with the BiggestBox Index Part:
uri = new Uri(Application.Current
    .Host.InitParams["BiggestBoxIndexXapPath"], UriKind.Relative);
this.AddToAggregateCatalog(
    CompositionUtility.DownloadCatalog(uri,
        new Action&lt;object, AsyncCompletedEventArgs&gt;(
        (o, args) =&gt;
        {
            asyncOperationsList[1] = true;
            asyncOperationsComplete();
        })));


I then formalized my hack with this limited-edition, commemorative class:


/// &lt;summary&gt;
/// Defines the grouping and completion-tracking of asynchronous operations.
/// &lt;/summary&gt;
/// &lt;remarks&gt;
/// This class is a poor substitute for what is lacking in Silverlight 4
/// (and older) with regard to features in the Task Parallel Library.
/// &lt;/remarks&gt;
public class AsyncOperationGroup
{
    /// &lt;summary&gt;
    /// Initializes a new instance of the &lt;see cref="AsyncOperationGroup"/&gt; class.
    /// &lt;/summary&gt;
    /// &lt;param name="numberOfOperations"&gt;The number of operations.&lt;/param&gt;
    /// &lt;param name="completionAction"&gt;The completion action.&lt;/param&gt;
    public AsyncOperationGroup(byte numberOfOperations, Action completionAction)
    {
        if(completionAction == null) throw new ArgumentNullException("completionAction", "The completion action is null.");
        this._completionAction = completionAction;
        this._asyncOperationCompletionList = new bool[numberOfOperations];
    }
    /// &lt;summary&gt;
    /// Marks the operation complete.
    /// &lt;/summary&gt;
    /// &lt;param name="operationOrdinal"&gt;The zero-based operation ordinal.&lt;/param&gt;
    public void MarkOperationComplete(byte operationOrdinal)
    {
        if(operationOrdinal &gt;= this._asyncOperationCompletionList.Length)
            throw new ArgumentException("The ordinal is not in the completion list.", "operationOrdinal");
        this._asyncOperationCompletionList[operationOrdinal] = true;
        if(this._asyncOperationCompletionList.Count(i =&gt; i) != this._asyncOperationCompletionList.Count()) return;
        this._completionAction.Invoke();
    }
    Action _completionAction;
    bool[] _asyncOperationCompletionList;
}


So now my code-smell wafts like this:


byte numberOfOperations = 2;
var catalogs = new DeploymentCatalog[numberOfOperations];
var operations = new AsyncOperationGroup(numberOfOperations,
() =&gt;
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
(s, args) =&gt;
{
    operations.MarkOperationComplete(0);
});
//Catalog the XAP with the BiggestBox Index Part:
var uri1 = new Uri(Application.Current
    .Host.InitParams["BiggestBoxIndexXapPath"], UriKind.Relative);
catalogs[1] = CompositionUtility.DownloadCatalog(uri1,
(s, args) =&gt;
{
    operations.MarkOperationComplete(1);
});


So, now I have my first real-world reason why Silverlight 5 is desirable.
