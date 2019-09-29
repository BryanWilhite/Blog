---json
{
  "author": "Bryan Wilhite",
  "content": "As of today I am a UX and DDD newbie. My previous 18 years in the IT field represent a dress rehearsal for a conscious performance, under my acronym umbrella of UX and DDD. In simplistic (newbie) terms UX (User eXperience design) covers my “artistic side...",
  "inceptDate": "2014-08-23T00:00:00",
  "isPublished": true,
  "slug": "songhay-studio-ux-and-ddd-my-new-acronym-umbrella",
  "title": "Songhay Studio: UX and DDD, my new acronym umbrella…"
}
---

[<img alt="Amazon.com product" src="http://ecx.images-amazon.com/images/I/51WLtI-uLcL.jpg" style="float:right;margin:16px;">](http://www.amazon.com/exec/obidos/ASIN/B00794TAUG/thekintespacec00A/ "Buy this product at Amazon.com!")

As of today I am a UX and DDD newbie. My previous *18 years* in the IT field represent a dress rehearsal for a conscious performance, under my acronym umbrella of UX and DDD. In simplistic (newbie) terms UX (*U*ser e*X*perience design) covers my “artistic side” and DDD satisfies my scientific needs. I made a possibly self-destructive but financially necessary decision to postpone my UX interests until I could stabilize my interests in hard-core tech. The analogy I would often use is the one about the painter who becomes a carpenter just so she can build her own frames (which are often too expensive to buy)—or the one about the poet who holds back the poems until he can make his own paper. For me, DDD (Domain Driven Design) is the culminating ‘conceptual container’ big enough for my technical needs—strong enough to support the “art” that I insist still simmers within me.

My house that DDD built came from one stone of an issue: immutability. When I first started “consulting” for PIMCO 12 months ago, I encountered a WPF front end built over a Java backend, served with IBM WebSphere MQ. To my newbie horror, I discovered that immutable objects were being sent into an <acronym title="Model">MVVM</acronym>-based system that is designed for two-way data-binding with *mutable* objects. I immediately rebelled under the principle that Microsoft did not design a MVVM solution to handle this scenario—and, had my savings been large enough, I would have walked out of the PIMCO offices never to deal with this issue again. That would have been a tragic mistake.

PIMCO has some of the finest WPF developers in Southern California and when I turned my problem into a team effort (instead of being “a guy in a room”—a gloomy character from Jim McCarthy’s [*Dynamics of Software Development*](http://www.amazon.com/Dynamics-Software-Development-Jim-McCarthy/dp/1556158238%3FSubscriptionId=1SW6D7X6ZXXR92KVX0G2&tag=thekintespacec00&linkCode=xm2&camp=2025&creative=165953&creativeASIN=1556158238)), these issues were resolved. (Also, by sharing my problem with others, I found out that my problem was one of the hardest on the shop floor.) Before I go on, it may help to mention that all that is written here are my opinions and assertions. I am not repeating what was taught to me or expressing the views of any third party.

First thing: MVVM as we now know it, encourages the use of what DDD folk call “[anemic domain models](http://codebetter.com/gregyoung/2009/07/15/the-anemic-domain-model-pattern/).” What we had to build at PIMCO was a gigantic workaround for this anti-pattern. I do not see the need to go into the details of this workaround (in part because the developer that built key features would not approve) because I predict that Microsoft (perhaps after Xamarin) will adopt and promote a successor to MVVM that is DDD-friendly. Also, it is very important to note that [Julie Lerman is well on the way](http://msdn.microsoft.com/en-us/magazine/dn342868.aspx) with reconciling DDD with the Entity Framework—so her work should be vital in this context as well. Anyway, here are some highlights of the workaround:

*   Build mutable, “presentation,” View Models that wrap the immutable server objects. The immutable DTOs are injected into the “presentation” View Model constructors. These presentation View Models can intercept “anemic” `RaisePropertyChanged()` events and interpret them into Domain-specific server requests (I designed and built this piece—not as hard as the other stuff)
*   Build a parent View Model that observes the “presentation” View Models and construct domain-specific requests from subsets of these “presentation” VMs (I also designed this bit).
*   Build a presentation collection based on `ObservableCollection&lt;T&gt;` to store these View Models and compare them with new DTOs (incoming as responses to my Domain-specific requests) injected via a “factory lambda” passed into the constructor of this collection.

Based on Google/Bing searches over the last 12 months, I assume that I am one of the few people in the world who took the time to write about this problem publically (electronically). I look forward to being awaken from my delusions of grandeur when someone out there is kind enough to come forward and talk about their solution to this problem. Does [Reactive UI have something](http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2011/10/10/reactive-extensions-for-net-talk-from-ddd-north.aspx) for MVVM anemia out of the box?

### Related Links

<table class="WordWalkingStickTable"><tr><td>

“[The power of immutability in a Rich Domain Model](http://www.gridshore.nl/2009/04/06/the-power-of-immutability-in-a-rich-domain-model/)”
</td><td>

“As many other developers, I’ve been used to the fat service layer and the anemic domain model of the transaction script pattern. In that programming model, immutability is pretty much as rare as a Dodo… As many other developers, I’ve been used to the fat service layer and the anemic domain model of the transaction script pattern. In that programming model, immutability is pretty much as rare as a Dodo”
</td></tr><tr><td>

“[Developing Core Business Applications with Domain-Driven Design (DDD) and Microsoft .NET](http://channel9.msdn.com/Events/TechEd/NorthAmerica/2013/DEV-B311)”
</td><td>

“Domain-driven design (DDD) has proven to be an invaluable tool when developing applications in high complexity domains. In this presentation we look at DDD in general and discuss some of the main concepts such as ubiquitous language, different architecture approaches, and strategic patterns such as bounded context….” — [@JimmyNilsson](https://twitter.com/JimmyNilsson)
</td></tr><tr><td>

“[Domain Driven Design—Eric Evans](https://www.youtube.com/watch?v=7MaYeudL9yo)”
</td><td>

Eric Evans is not wearing a hot mic during this talk so the audio is bad.
</td></tr><tr><td>

“[Unleash your Domain with CQRS + Event Sourcing (Greg Young)](https://vimeo.com/31645099)”
</td><td>

“Getters and Setters are a domain smell…” —[Greg Young](http://goodenoughsoftware.net/author/gregfyoung/)
</td></tr><tr><td>

“[‘Reactive Extensions for .NET’ talk from DDD North](http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2011/10/10/reactive-extensions-for-net-talk-from-ddd-north.aspx)”
</td><td>

“[[@mtaulty](https://twitter.com/mtaulty)] Nice work. Good introduction to Rx.”
</td></tr><tr><td>

‘[Our Legacy as Modern Media](http://kintespace.com/rasx55.html)’
</td><td>

“In his [2010 talk on the Natural User Interface](http://channel9.msdn.com/posts/TechTalk-NUI-Whats-in-a-Name), [Bill Buxton](https://twitter.com/wasbuxton) damn near begs his audience to not be impressed with the technology in the iPhone and similar mobile devices. He shows the audience a digital watch from the 1970s with a touch interface to illustrate how little has been accomplished in decades.”
</td></tr></table>
