## remembering the CLI and the multi-tasking OS

I have literally paid the price for forgetting about the wonders of a [multitasking](https://en.wikipedia.org/wiki/Computer_multitasking) Operating System and how the [Common Language Infrastructure](https://en.wikipedia.org/wiki/Common_Language_Infrastructure) (CLI) takes advantage of such a thing for my benefit. And when I mean “literally paid” I am talking about the intricacies of the job interview. I have failed to take the time to sit down, draw a picture and wax poetic about the whole reason why the execution of my code is possible, leaving extremely busy hiring managers to assume that I care little about such a wondrous thing.

First, according to the academic custom, I must empty the universe of almost everything and begin with a single statement:

### thread scheduling

>A multitasking Operating System can _schedule_ a CLI Task with its Thread.

[Scheduling](https://en.wikipedia.org/wiki/Scheduling_(computing)) is fundamental to computation itself. It crosses the boundary between abstract logic and real computing resources under the control of a multitasking [Operating System](https://en.wikipedia.org/wiki/Operating_system) (OS).

Both the _Task_ and the _Thread_ (coincidentally?) exist in the abstract logic of the computer [programming language(s) of the CLI](https://en.wikipedia.org/wiki/List_of_CLI_languages) and in the OS. The confusion may start when we must see that:

* in the OS, the Task or [Process](https://en.wikipedia.org/wiki/Process_(computing)) is an _entire_ computer program, composed of one or more [threads](https://en.wikipedia.org/wiki/Thread_(computing))
* in the CLI, the [Task](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=netstandard-2.0) is a grouping of [statements and/or expressions](https://en.wikipedia.org/wiki/Statement_(computer_science)), running on a [Thread](https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?redirectedfrom=MSDN&view=netstandard-2.0) (usually asynchronously)

### threads of the AppDomain

>The CLI groups threads together in an isolated environment called the `AppDomain` [[docs](https://docs.microsoft.com/en-us/dotnet/api/system.appdomain?redirectedfrom=MSDN&view=netcore-2.1)]; the OS can see several AppDomain instances in a single process.

One leading benefit of the CLI insinuating itself between OS processes and threads is to reduce the cost of [context switching](https://en.wikipedia.org/wiki/Context_switch), especially in the traditional, [single core](https://en.wikipedia.org/wiki/Single-core) processor system.

Another benefit, is the single [execution model](https://en.wikipedia.org/wiki/Execution_model) implemented in the [Common Language Runtime](https://en.wikipedia.org/wiki/Common_Language_Runtime) (CLR), featuring its [Just-in-Time (JIT) compilation](https://en.wikipedia.org/wiki/Just-in-time_compilation). The CLR can be thought of as one throat to choke when it comes to security issues around the successful isolation of the `AppDomain`.

### threads of the thread pool

Most threads for most programmers come from a [thread pool](https://en.wikipedia.org/wiki/Thread_pool) which is a [task queue](https://en.wikipedia.org/wiki/Task_queue) related to the all-important scheduling mentioned above. Windows programmers who are familiar with [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2017?&OCID=AID739534_SEM_RNDRbyuB) or [Internet Information Server](https://www.iis.net/) (IIS) will have been introduced to the thread pool concept. According to Joe Duffy, in _[Concurrent Programming on Windows](https://www.amazon.com/Concurrent-Programming-Windows-Joe-Duffy/dp/032143482X?SubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=032143482X)_:

>Both Windows and the CLR offer different variants of the thread pool idea that are entirely different components and provide different APIs.

On the [client side](https://en.wikipedia.org/wiki/Client-side), Windows Windows Presentation Foundation (WPF) is [designed with two default threads](https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/threading-model), one for handling rendering and another for “managing the UI”—this latter thread borrows from the tradition of the [event loop](https://en.wikipedia.org/wiki/Event_loop), leading developers down into the often slippery slope of [event driven programming](https://en.wikipedia.org/wiki/Event-driven_programming) for the [Graphical User Interface](https://en.wikipedia.org/wiki/Graphical_user_interface) (GUI).

### thread safety

[Thread safety](https://en.wikipedia.org/wiki/Thread_safety) is about preventing [race conditions](https://en.wikipedia.org/wiki/Race_condition#Computing) and [deadlocks](https://en.wikipedia.org/wiki/Deadlock). Chapter 11 of Joe Duffy’s book, “Concurrency Hazards,” groups race conditions and deadlocks under “correctness hazards” and “liveness hazards,” respectively.

### thread memory allocation and the Garbage Collector

Chapter three of Duffy’s book, “Threads,” states:

>Coincidentally, each .NET program is actually multithreaded from the start because the [CLR garbage collector](https://msdn.microsoft.com/en-us/library/ms973837.aspx?f=255&MSPPError=-2147217396) uses a separate _finalizer_ thread to reclaim resources.

We could say then that the CLR uses/provides a thread to remove memory allocations generated by _other_ managed threads. These allocations are partitioned in the Garbage Collector (GC) into _generations_. The older (higher-number) generations are more likely to be ‘finalized’ than younger ones.

There are two leading disadvantages to the use of the GC:

1) several times more memory is required (as much as five times, according to [Matthew Hertz and Emery D. Berger (2005)](https://en.wikipedia.org/wiki/Garbage_collection_(computer_science)#cite_note-5))
2) noticeable delays when generations reach millions

### type safety

Before threads can be scheduled at runtime, the compile time of the Common Language Infrastructure ensures [type safety](https://en.wikipedia.org/wiki/Type_safety), starting with the [Common Type System](https://en.wikipedia.org/wiki/Common_Type_System) (CTS) and leading into well-typed rules of [covariance and contravariance](https://en.wikipedia.org/wiki/Covariance_and_contravariance_(computer_science)).

@[BryanWilhite](https://twitter.com/bryanwilhite)
