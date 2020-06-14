---json
{
  "documentId": 0,
  "title": "Seriously Needing async and await in Silverlight 5",
  "documentShortName": "2013-03-24-seriously-needing-async-and-await-in-silverlight-5",
  "fileName": "index.html",
  "path": "./entry/2013-03-24-seriously-needing-async-and-await-in-silverlight-5",
  "date": "2013-03-25T00:00:00Z",
  "modificationDate": "2013-03-25T00:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2013-03-24-seriously-needing-async-and-await-in-silverlight-5",
  "tag": "{\r\n  \"extract\": \"In the “long forgotten,” “dead,” Silverlight projects I work with every day these days. I establish a pattern featuring a huge “main” View Model I call ClientViewModel. This monstrosity is a partial class of files like these:  ClientViewModel._.cs  Clien...\"\r\n}"
}
---

# Seriously Needing async and await in Silverlight 5

In the “long forgotten,” “dead,” Silverlight projects I work with every day these days. I establish a pattern featuring a huge “main” View Model I call `ClientViewModel`. This monstrosity is a partial class of files like these:

```console
ClientViewModel._.cs
ClientViewModel.Commanding.cs
ClientViewModel.Eventing.cs
ClientViewModel.Messaging.cs
ClientViewModel.Navigating.cs
ClientViewModel.RiaOperations.cs
```

We can see why this class can be so huge when it concerns itself with the Commands, Events, Messages, Navigation and RIA Operations of an entire application. To answer an imaginary question—yes, I do expect to have other View Models classes, respecting the Single Responsibility Principle (usually these other View Models appear at or below the Page level of the application. When `ClientViewModel` is considered too big then it’s time to get “fast and fluid” and break the entire application up into smaller apps.

Inside of `ClientViewModel.RiaOperations.cs` are a bunch of RIA Services calls. My tendency these days is to centralize *all* RIA service calls in this file. My service calls are private methods with the prefix `DoRiaOperationFor`. So for “classic” Silverlight at the beginning of the Visual Studio 2010 timeframe, we would have this:

```cs
void DoRiaOperationForCustomerApproval(IEnumerable<Customer> data)
{
    var operation = context.DoCustomerApprovals(data);
    operation.Completed += (s, args) =>
    {
        //Handle any errors or nulls...
        //reload Customers:
        this.DoRiaOperationForCustomerStatus();
    }
}
```

We see that `DoRiaOperationForCustomerApproval()` approves customers. After the customers are approved, the Customer data is refreshed by `DoRiaOperationForCustomerStatus()`—the naming here suggests that there must be some kind of “Customer Status” view (where customers can be marked “approved”).

Since `DoRiaOperationForCustomerApproval()` is not run in parallel with other operations, we can see that using the Task Parallel Library is not very helpful:

```cs
void DoRiaOperationForCustomerApproval(IEnumerable<Customer> data)
{
    context.DoCustomerApprovals(data).AsTask()
        .ContinueWith(
            completedTask =>
            {
                //Handle any errors or nulls...
                //reload Customers:
                this.DoRiaOperationForCustomerStatus();
            });
}
```

The syntax looks almost the same as the event-based pattern out of the box. But what’s this `.AsTask()` method? This is an extension method from [Kyle McClellan](http://blogs.msdn.com/b/kylemc/archive/2010/11/02/using-the-visual-studio-async-ctp-with-ria-services.aspx) (from the year 2010).

After installing the NuGet package, `Microsoft.CompilerServices.AsyncTargetingPack`, I can use Kyle’s extension method to obtain this pattern:

```cs
async void DoRiaOperationForCustomerApproval(IEnumerable<Customer> data)
{
    var task = await context.DoCustomerApprovals(data).AsTask();
    //Handle any errors or nulls...
    //reload Customers:
    this.DoRiaOperationForCustomerStatus();
}
```

What `async` and `await` gives me is a *flat* representation of my intentions. Without `async` and `await` I run the risk of nesting `OperationBase.Completed` calls, making my intent confusing. I seriously need `async` and `await`.

Welcome to 2012 in the year 2013. Silverlight is dead. Long live Silverlight.

@[BryanWilhite](https://twitter.com/BryanWilhite)
