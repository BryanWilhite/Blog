---json
{
  "author": "Bryan Wilhite",
  "content": "Would you be willing to commute 100 miles a day for four months just to learn a little bit about threads? Clearly I must be willing—or maybe, as one sly fox told me, I must be “crazy.” In general, I am “crazy” about learning—mind-numbing labor while bein...",
  "inceptDate": "2013-11-30T00:00:00",
  "isPublished": true,
  "slug": "a-little-bit-about-basic-synchronization",
  "title": "A little bit about basic synchronization…"
}
---

Would you be willing to commute 100 miles a day for four months just to learn *a little bit* about threads? Clearly I must be willing—or maybe, as one sly fox told me, I must be “crazy.” In general, I am “crazy” about learning—mind-numbing labor while being self-held captive in a centrally-chilled glass barn is deadly to me. There are two kinds of publican labor in my limited-American experience: work that enhances your career growth and work that maintains income. My Herculean struggle with this 100-miles-per-day commute has revealed to me an issue that I have never before seen first-hand in the wild in over 20 years of IT work. This fact alone makes my “crazy” choices worth my while.

I’ve only *heard* about concurrency/threading issues from other (more experienced) people. In fact, I was on the phone *over two years ago* with [Lab49](http://www.lab49.com/) and I was asked a phone-screen question about the `Monitor.Pulse()` method. I had absolutely no idea what this Lab49 guy was talking about. It was liberating. I was elated. I didn’t get the job.

It wasn’t until my crazy, miserable commuting began when I had the privilege of seeing diagnostic debug log entries like these:

    INFO start Foo()
       …
    INFO end Foo()
    INFO start Foo()
       …
    INFO end Foo()
    INFO start Foo()
       …
    INFO start Foo()
       … //exception thrown here
    INFO end Foo()

The method `Foo()` would look like this:

    public void Foo()
    {
        this.LogStart();
        //do stuff…
        this.LogEnd();
    }

And the logging functions (I know I’m digressing, by the way) look like this:

    [Conditional("DEBUG")]
    void LogStart()
    {
        var methodName = new StackFrame(1).GetMethod().Name;
        YourFavoriteLogger.Info(string.Format("start {0}()", methodName));
    }
    [Conditional("DEBUG")]
    void LogEnd()
    {
        var methodName = new StackFrame(1).GetMethod().Name;
        YourFavoriteLogger.Info(string.Format("end {0}()"), methodName);
    }

There are so many ways to make this logging code more [DRY](http://en.wikipedia.org/wiki/Don't_repeat_yourself) but remember I’m losing at up to four hours of my work days to sitting on a freeway with a bunch of giant trucks hurtling by. I have to wake up at 5am! I am not quite my best folks!

Back to the main point: 

    INFO start Foo()
       …
    INFO end Foo()
    INFO start Foo()
       …
    INFO end Foo()
    INFO start Foo()
       …
    INFO start Foo()
       … //exception thrown here
    INFO end Foo()

Notice that we have two, successive `start Foo()` entries. We have more starts than stops. This implies that `Foo()` was called *from another thread*. Welcome to the hell of multithreaded programming! And, as Winston Churchill said, “If you are going *through* hell, keep going.”

Somehow two (or more) threads are competing for the same method. When I brought this up to this young guy with lots of C++ experience (his commute is about 40 minutes a day, by the way), he told me to do something like this:

    public void Foo()
    {
        this.LogStart();
        lock(Locker)
        {
            //do stuff…
        }
        this.LogEnd();
    }
    static readonly object Locker = new object();

The young C++ guy mumbled something about `lock` being shorthand for `Monitor.Enter`. When I Googled around with these terms I eventually found *the man*: Mr. LINQPad himself: [Joe Albahari](http://www.albahari.com/threading/). Joe puts it like [this](http://www.albahari.com/threading/part2.aspx):
<blockquote>

C#’s lock statement is in fact a syntactic shortcut for a call to the methods Monitor.Enter and Monitor.Exit, with a try/finally block.
</blockquote>

Remember `Monitor.Pulse()`? I do. I have finally seen *in real-world practice* the way into the world of threading. While I was being rejected by Lab49 I asked about any books that I would need to read to learn about threading. So, back in 2010, [I had the books](http://kintespace.com/rasxlog/?p=2204) but I did not have the emotional, visceral understanding of this technical subject until I started working as a consultant for PIMCO (and—what do one or two PIMCO WPF guys think of Lab49? ‘I know some folks over there. They’re a little budget-ey but Ok…’). Wow, what a crazy world we live in…

Speaking of the “real world,” it turns out that the need to log locking surfaced. So, based on some input from a Java-, server-based guy, we have something like this:

    public void Foo()
    {
        this.LogStart();
        if(!Monitor.TryEnter(Locker))
        {
            YourFavoriteLogger.Info(string.Format("Thread {0} fails to enter.",
                Thread.CurrentThread.ManagedThreadId.ToString());
        }
        lock(Locker)
        {
            YourFavoriteLogger.Info(string.Format("Thread {0} enters.",
                Thread.CurrentThread.ManagedThreadId.ToString());
            //do stuff…
            YourFavoriteLogger.Info(string.Format("Thread {0} exits.",
                Thread.CurrentThread.ManagedThreadId.ToString());
        }
        this.LogEnd();
    }
    static readonly object Locker = new object();

This pattern (I have discovered recently) can cause false positives to be logged (when we are looking for more starts than stops in our example above): should an exception occur after `this.LogStart()` but before `this.LogEnd()` a threading newbie like me will assume that multiple threads are competing instead of one thread failing. To avoid this daft oversight, this pattern should work:

    public void Foo()
    {
        this.LogStart();
        if(!Monitor.TryEnter(Locker))
        {
            YourFavoriteLogger.Info(string.Format("Thread {0} fails to enter.",
                Thread.CurrentThread.ManagedThreadId.ToString());
        }
        Monitor.Enter(Locker)
        try
        {
            YourFavoriteLogger.Info(string.Format("Thread {0} enters.",
                Thread.CurrentThread.ManagedThreadId.ToString());
            //do stuff…
            YourFavoriteLogger.Info(string.Format("Thread {0} exits.",
                Thread.CurrentThread.ManagedThreadId.ToString());
        }
        finally
        {
           Monitor.Exit(Locker);
           this.LogEnd();
        }
    }
    static readonly object Locker = new object();

This may be overkill someday but today I’m calling it educational.

### Related Links

<table class="WordWalkingStickTable"><tr><td>

“[Why is lock much slower than Monitor.TryEnter?](http://stackoverflow.com/questions/2416793/why-is-lock-much-slower-than-monitor-tryenter)”
</td><td>

“…it’s important to point out that lock and Monitor.TryEnter are not functionally equivalent.”
</td></tr><tr><td>

“[Asynchrony in C# 5: Deep Dive by Joe Albahari](http://yow.eventer.com/yow-2011-1004/asynchrony-in-c-5-deep-dive-by-joe-albahari-1067)”
</td><td>

A streaming talk from YOW 2011.
</td></tr><tr><td>

“[Threading in C#—Part 4—Advanced Threading](http://www.albahari.com/threading/part4.aspx)”
</td><td>

“Here’s how to use Wait and Pulse…”
</td></tr><tr><td>

“[Synchronization in async C# methods](http://www.dzhang.com/blog/2012/08/29/synchronization-in-async-csharp-methods)”
</td><td>

“The following results in a compile-time error because you cannot use `await` inside a `lock` block…”
</td></tr><tr><td>

“[Threading in C#—Part 2 - Basic Synchronization](http://www.albahari.com/threading/part2.aspx)”
</td><td>

“Only one thread can lock the synchronizing object (in this case, `_locker`) at a time, and any contending threads are blocked until the lock is released. If more than one thread contends the lock, they are queued on a ‘ready queue’ and granted the lock on a first-come, first-served basis (a caveat is that nuances in the behavior of Windows and the CLR mean that the fairness of the queue can sometimes be violated). ...C#’s `lock` statement is in fact a syntactic shortcut for a call to the methods `Monitor.Enter` and `Monitor.Exit`, with a try/finally block.”
</td></tr></table>
