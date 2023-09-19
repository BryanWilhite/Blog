---json
{
  "documentId": 0,
  "title": "My Current, Aurelia-Inspired, Web-App Technology Road Map",
  "documentShortName": "2017-10-12-my-current-aurelia-inspired-web-app-technology-road-map",
  "fileName": "index.html",
  "path": "./entry/2017-10-12-my-current-aurelia-inspired-web-app-technology-road-map",
  "date": "2017-10-12T20:09:37.595Z",
  "modificationDate": "2017-10-12T20:09:37.595Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2017-10-12-my-current-aurelia-inspired-web-app-technology-road-map",
  "tag": "{\r\n  \"extract\": \"This is Q4 2017. It has taken me this long to formally explore the Web-app landscape. My personal desire for formality and relatively deep reflection has left my company web site and this Blog stuck in Angular 1.x and outside of ASP.NET Core. From a “tim...\"\r\n}"
}
---

# My Current, Aurelia-Inspired, Web-App Technology Road Map

This is Q4 2017. It has taken me this long to *formally* explore the Web-app landscape. My personal desire for formality and relatively deep reflection has left [my company web site](http://songhaysystem.com) and this Blog stuck in Angular 1.x and outside of ASP.NET Core. From a “time-to-market” point of view this has been a colossal “failure” for 2017. My career as a software developer has been centered around building UI/UX and from my point of view I have little to show that this centering ever existed—let alone raged like a fire for the last 20 years.

The next phase of my development will be the final attempt to begin to clearly express focus on UI/UX. 2017 was my time to get comfortable with GitHub. I started with “dragging” my legacy load of [*core* .NET code](https://github.com/BryanWilhite/SonghayCore) and then evacuated [my WPF work](https://github.com/BryanWilhite/Songhay.StudioFloor) out of CodePlex. My legacy load is significant and still relevant. I do not “waste time” on this work—this legacy stuff *still* has “day job” written all over it.

The [SonghayCore project](https://github.com/BryanWilhite/SonghayCore) is now ready for the new .NET Standard 2.0 regime. The StudioFloor project is ready and waiting for expansion into [Xamarin](https://www.xamarin.com/) and [UWP](https://docs.microsoft.com/en-us/windows/uwp/get-started/universal-application-platform-guide) XAML technologies.

Take a peek today at [my GitHub repository activity](https://github.com/BryanWilhite?tab=repositories) and you will see two projects with a warm heartbeat: [nodejs](https://github.com/BryanWilhite/nodejs) and [dotnet-core](https://github.com/BryanWilhite/dotnet-core). These repositories expose my self-education investments in Node.js and .NET Core (featuring ASP.NET Core). This work has provided me with an opinionated approach to how I plan to do my non-XAML-related UI/UX work.

## my commitment to Aurelia and angular.io

My work on [nodejs](https://github.com/BryanWilhite/nodejs) should betray a commitment to [Aurelia](https://github.com/BryanWilhite/nodejs/tree/master/aurelia-official) and [angular.io](https://github.com/BryanWilhite/nodejs/tree/master/angular.io-official). The gumbo of technologies that make up Aurelia are then broken into subtopics of study:

**jQuery.** jQuery still plays a role in the current life of Aurelia. It also is needed because of my current commitment to [Bootstrap](http://getbootstrap.com/) which might be replaced by [Semantic UI](https://semantic-ui.com/). It must be mentioned that angular.io has no default jQuery dependencies. We can also see (today) that there are 10 `jquery-*` folders in [nodejs](https://github.com/BryanWilhite/nodejs) showing more of my legacy load. I do see the possibility that “vanilla JavaScript” will replace all of this jQuery work.

**karma and jasmine.** The `karma-and-jasmine-minimal`[folder](https://github.com/BryanWilhite/nodejs/tree/master/karma-and-jasmine-minimal) is there because [Karma](https://karma-runner.github.io/) and [Jasmine](https://jasmine.github.io/) are used in Aurelia. It follows that these technologies will be the testing tools of choice for my frontend work. Now there are some limitations with these tools that calls for an investigation of `selenium-webdriver` [[package](https://www.npmjs.com/package/selenium-webdriver)].

**Typescript.** The `typescript-minimal`[folder](https://github.com/BryanWilhite/nodejs/tree/master/typescript-minimal) is also a spin-off from my Aurelia investment. This study is based on the assertion that Typescript is the best language to preserve intent for all JavaScript-based applications. There is a possibility that [WebSharper](https://websharper.com/) will allow me to confidently replace TypeScript with C#/F#.

**Gulp.** Yes, Aurelia is dependent on [Gulp](https://gulpjs.com/) as well. This encourages me to continue my investment in this technology. My `gulp-and-css-handling`[folder](https://github.com/BryanWilhite/nodejs/tree/master/gulp-and-css-handling) reinforces this intent.

## my commitment to ASP.NET Core and Hugo

[Hugo](https://gohugo.io/) is retro-revolution back to static-file web sites. It can be used with [Netlify](https://www.netlify.com/) to replace the venerable WordPress. The intention here is to investigate Hugo with view to use this technology as the primary way to present content on the Web. My `md-hugo`[folder](https://github.com/BryanWilhite/nodejs/tree/master/md-hugo) is the first step in this direction.

The SEO story for ASP.NET Core supporting Aurelia or Angular is stellar. My `dotnet-spa-services`[folder](https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-spa-services) was nothing short of a revelation to me, going a long way toward preventing non-Google Web crawlers from ignoring [SPA](https://en.wikipedia.org/wiki/Single-page_application) content. This SPA-oriented approach to ASP.NET Core is the *second* reason why the investment in ASP.NET Core will be deep. The first is the REST-service story in the time-frame of .NET Standard 2.0.

## my reduced use of Visual Studio and increased use of Visual Studio Code

I see the need for full-blown Visual Studio for all of my XAML applications and most of my REST-based services. Everything else will be in cross-platform, shell-oriented workflows under Visual Studio Code. Moreover, the REST solutions will be compatible with Visual Studio and Code.

## the functional-language bias looming in the background

My self-education work in the `dotnet-fable-minimal`[folder](https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-fable-minimal), the `dotnet-giraffe-template`[folder](https://github.com/BryanWilhite/dotnet-core/tree/master/dotnet-giraffe-template) and the `elm-minimal`[folder](https://github.com/BryanWilhite/nodejs/tree/master/elm-minimal) indicate my desire to transition some (perhaps most) of my C# investments to F#. The main reasoning for this is to formally control complexity.

## Q4 2018

I actually will consider it failure: finding myself in Q4 2018 having moved not very far from my current location, still presenting Angular 1.x to the Web. The preparation has been quite substantial and the professional introspection quite deep. I am optimistic that, barring tragedy, my next moves on the Web will be quite satisfying.

<https://github.com/BryanWilhite/>
