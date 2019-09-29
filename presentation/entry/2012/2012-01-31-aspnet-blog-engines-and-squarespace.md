---json
{
  "author": "Bryan Wilhite",
  "content": "Hi wired world. This is my first entry for this new blog—so it makes a bit of sense to write about the ASP.NET-based Blog engines with which I experimented (to start this blog):Orchard CMS is an MVC application so I preferred this. The problem is with my...",
  "inceptDate": "2012-01-31T23:19:00",
  "isPublished": true,
  "slug": "aspnet-blog-engines-and-squarespace",
  "title": "ASP.NET Blog Engines (and SquareSpace.com)"
}
---

Hi wired world. This is my first entry for this new blog—so it makes a bit of sense to write about the ASP.NET-based Blog engines with which I experimented (to start this blog):

*   Orchard CMS is an MVC application so I preferred this. The problem is with my hosting service (I use the same one Phil Haack uses—and Phil is using/developing SubText). I got a bunch of permissions errors pointing to the `App_Data` folder and many of the error messages referred to file locations that were clearly on one of the Orchard developer’s machine—not a confidence builder. I also was not comfortable with the over 1900 files that “ships” with Orchard—many of them are `*.cs` files that dynamically compile.
*   Das Blog is “done” as Scott Hanselman says (which is not to be confused with abandoned). I would have been fine with using it except that Windows Live Writer no longer works with it (or *vice versa*). My hosting service installs Das Blog automatically and without incident.
*   Since Phil Haack uses SubText I installed SubText (through my hosting provider’s “beta” gallery). It got 500 errors right off the bat. I noticed that the database I assigned to it has no tables in it after the install. Phil and the other SubText guys have nothing to do with this but I’ll pass anyway because it’s not ASP.NET MVC (eventually I’ll give up on demanding ASP.NET MVC for a blog engine).
*   [Oxite](http://oxite.codeplex.com/) has an ASP.NET MVC engine but as the team confesses, “This isn’t a finished product. It has no install, it has no documentation. It is our code, exactly as we are using it.”
*   I know that SquareSpace.com is based on Java but I tried it anyway and I had only one problem most SquareSpace.com supporters would care about: when I clicked on a “sub-style” the CSS files seemed to break and my site got stuck with unformatted content (the new style only showed up after moving to another menu item and moving back). Based on the promotional aesthetic of SquareSpace.com, I expected it to be *vastly* superior to the crap I’ve been dealing with since 1998—and when I mean *vast* I mean like alien-from-outer-space-with-superior-technology *vast*. I’m finding that the SquareSpace.com folks are rather ordinary people.
*   There’s AtomSite: “AtomSite is built with extensible web standards that unleash your social website and blog…” This system runs on <acronym title="Extensible Hypertext Markup Language">XHTML</acronym>—and the latest entry in the AtomSite.net blog is from 4/2010. There is an <acronym title="Extensible Markup Language">XML</acronym> version of HTML 5—so I’m sure there’s something going on there in the future.
*   Like AtomSite, BlogEngine.NET does not require a database (I prefer this for the feeling of lightness and ease of maintenance). I installed this twice—once through my Host control panel and then again through FTP (because my host did not have an up-to-date version of BlogEngine.NET). BlogEngine.NET installed without any problems (my only challenge had to do with enabling write access to a folder because data is persisted in XML files).
