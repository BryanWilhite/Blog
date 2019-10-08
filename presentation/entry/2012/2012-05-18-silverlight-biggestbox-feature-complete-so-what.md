---json
{
  "documentId": 0,
  "title": "Silverlight BiggestBox Feature Complete “…So what!”",
  "documentShortName": "2012-05-18-silverlight-biggestbox-feature-complete-so-what",
  "fileName": "index.html",
  "path": "./entry/2012-05-18-silverlight-biggestbox-feature-complete-so-what",
  "date": "2012-05-18T18:13:00.000Z",
  "modificationDate": "2012-05-18T18:13:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2012-05-18-silverlight-biggestbox-feature-complete-so-what",
  "tag": "{\r\n  \"extract\": \"All of the features for my Silverlight BiggestBox are now running in the application. This means that the only expected changes to this application will be related to adding new samples to the application—these additions largely come from my current W2 l...\"\r\n}"
}
---

# Silverlight BiggestBox Feature Complete “…So what!”

[<img alt="Microsoft BUILD conference in Anaheim 9/13/11." src="http://farm7.staticflickr.com/6064/6144570321_b374f0b3a5.jpg">](http://www.flickr.com/photos/buildwindows/6144570321/ "Microsoft BUILD conference in Anaheim 9/13/11.")

All of the features for my [Silverlight BiggestBox](http://wordwalkingstick.com/silverlightbiggestbox/) are now running in the application. This means that the only expected changes to this application will be related to adding new samples to the application—these additions largely come from my current W2 labor in arguably the biggest Silverlight shop in Southern California: 20<sup>th</sup> Century Fox Filmed Entertainment.
[<img alt="TransitioningContentControl with UserControl Collection Sample" src="http://farm6.staticflickr.com/5034/7065171509_b2503321d3_n.jpg" style="float:right;margin:16px;">](http://wordwalkingstick.com/silverlightbiggestbox/#/sample/usercontrol/TransitioningContentControlSample "TransitioningContentControl with UserControl Collection Sample")

Now that I’m finished, I can commend [Scott Hanselman](http://www.hanselman.com/blog/ShouldIUseHTML5OrSilverlightOneMansOpinion.aspx) for graciously not complaining about Tweets I’ve sent him regarding the subject of Silverlight after he’s told me politely on *two* occasions that he is not a Silverlight guy. [John Papa](http://johnpapa.net/) is no longer a Silverlight guy. [Brian Noyes](http://briannoyes.net/) is no longer a Silverlight guy. [Jesse Liberty](http://jesseliberty.com/) is effectively out of the Silverlight business—especially when he’s hanging out with [Jon Galloway](http://weblogs.asp.net/jgalloway/). Sorry guys, for the last six months I’ve been in the Silverlight business…
[<img alt="SL BiggestBox - Rolling Analog Digit Sample" src="http://farm8.staticflickr.com/7067/6997315441_279bb52ef1_n.jpg" style="float:left;margin:16px;">](http://wordwalkingstick.com/silverlightbiggestbox/#/sample/usercontrol/AnalogDigitControlSample "SL BiggestBox - Rolling Analog Digit Sample")

Jon, by the way, is an ASP.NET MVC guy—and I can relate to that because my Silverlight BiggestBox runs on top of ASP.NET MVC 3 with Razor. In fact, over the last few days I’ve updated my MVC plans in Visual Studio by insisting that my JavaScript libraries *must* be maintained by NuGet (check my `packages.config`[on pastebin.com](http://pastebin.com/Y7vVpnM5)). I will no longer try to maintain, say, jQuery UI by hand. More on my MVC stuff later… (And, yes, I adore knockout.js—but this I fear has been abandoned…)

So: the final feature that made the Silverlight BiggestBox so complete has to do with a rather nasty cross-cutting concern: Navigation. What I was rambling about in “[Implementing INavigationContentLoader with an abstract class…](http://wordwalkingstick.com/DayPath/post/2012/04/23/Implementing-INavigationContentLoader-with-an-abstract-class….rasx)” has to do with a Navigation system that defines more than just frame pages as Bookmark locations—it resources child windows as “deep-link” indicators as well. When I did all that `INavigationContentLoader` stuff and pushed the code out, I thought I was done. But what I really did was cover how to navigate *to* my resources—not properly handling navigating *from* a resource. When I close my ‘special’ child window (used to display one of the BiggestBox samples), the application needs to navigate *back* in history.

With MVVM Light Messaging this seemed like a simple fix (I could send a message about a child window closing and then have message “listener” call the `Frame.GoBack`[method](http://msdn.microsoft.com/en-us/library/system.windows.controls.frame.goback.aspx)). However, the <acronym title="User Interface">UI</acronym> would sometimes appear (and be) disabled after the child window closed and the messaging did its work. It took more than couple of hours to figure out that my “listener” needs to call `Frame.GoBack` about *one second* after the child window closed. This one-second interval would give the UI time to perform its snazzy animations associated with opening and closing a child window. This one-second delay was handled by a `System.Threading.DispatcherTimer`.

I can exclaim with confidence that there are few people *on earth* who know how to handle Silverlight Navigation with such fine detail (and I’m even including the folks who built Silverlight itself). But Scott Hanselman might rightfully say, “So what. Who would umm…. be around to care? Hey, Bryan, we have this thing called WinRT now. Didn’t you watch the [Build Conference videos](http://channel9.msdn.com/Events/BUILD/BUILD2011?sort=sequential&direction=desc&term=&t=xaml)?”

Even before details Windows 8 were made public, I knew *for years* that Silverlight jobs were hard to find. At first I thought it was an emerging technology that will catch on later… then I began to see that it was more like a technology in need of a non-Microsoft evangelist (like how [Jesse James Garrett](http://en.wikipedia.org/wiki/Jesse_James_Garrett) of Google fame turned Microsoft’s Dynamic HTML into <acronym title="Asynchronous JavaScript and XML">AJAX</acronym>). Silverlight is the concept car of user-experience design. The name *Silverlight* might fade away but the declarative UI technology represented by it will never go away (it clearly lives on in Windows 8).

My Silverlight BiggestBox is full of little UX snippets that will stand as the gold standard against which all other technologies will be measured. I will use my [Silverlight BiggestBox](http://wordwalkingstick.com/silverlightbiggestbox/) as a guide—a specification as to how something should be built in WinRT Metro-style, HTML 5 or even MXHTML. There is no other mix of tooling and framework features that come close to what Microsoft is offering here. So I’m not going to delete all of my Silverlight files just to keep a few iPhone app millionaires from not laughing at the concept of me and my devotion to Microsoft.

From a Steve-Ballmeresque point of view, Silverlight was unleashed on the world to destroy Adobe Flash. But the mismanagement of brilliant C++ programmers *at* Adobe is destroying Flash—one security flaw at a time. When Steve Jobs came out against Flash to save iPhone batteries from burning down, it was only a matter of time to start questioning the “strategic importance” of Silverlight. The blunders of Netflix, bearers of the brightest Silverlight flame, didn’t help matters either…

Now that I’m really, *really* rambling it may not hurt to mention that being ‘finished’ with my Silverlight BiggestBox “kind of” means that I should be “ready” to move on to the next thing… but, I protest: I would like to have enjoyed a few years of living in a well-respected (well-paid) Silverlight world (with a strong kit like the one I’ve just finished backing me up) before moving on… The political/technical situation pressures me to run on to the next thing without taking professional care to pay my respects to the thing I’m working with now…

And now… my exclamation of confidence:

Meh.

@[BryanWilhite](https://twitter.com/BryanWilhite)
