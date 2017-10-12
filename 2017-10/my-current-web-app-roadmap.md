# my current web-app technology road map

This is Q4 2017. It has taken me this long to `formally` explore the Web-app landscape. My personal desire for formality and relatively deep reflection has left [my company web site](http://songhaysystem.com) and this Blog stuck in Angular 1.x and outside of ASP.NET Core. From a “time-to-market” point of view this has been a colossal “failure” for 2017. My career as a software developer has been centered around building UI/UX and from my point of view I have little to show that this centering ever existed—let alone raged like a fire for the last 20 years.

The next phase of my development will be the final attempt to begin to clearly express focus on UI/UX. 2017 was my time to get comfortable with GitHub. I started with “dragging” my legacy load of [_core_ .NET code](https://github.com/BryanWilhite/SonghayCore) and then evacuated [my WPF work](https://github.com/BryanWilhite/Songhay.StudioFloor) out of CodePlex. My legacy load is significant and still relevant. I do not “waste time” on this work—this legacy stuff _still_ has “day job” written all over it.

The [SonghayCore project](https://github.com/BryanWilhite/SonghayCore) is now ready for the new .NET Standard 2.0 regime. The StudioFloor project is ready and waiting for expansion into [Xamarin](https://www.xamarin.com/) and [UWP](https://docs.microsoft.com/en-us/windows/uwp/get-started/universal-application-platform-guide) XAML technologies.

Take a peek today at [my GitHub repository activity](https://github.com/BryanWilhite?tab=repositories) and you will see two projects with a warm heartbeat: [nodejs](https://github.com/BryanWilhite/nodejs) and [dotnet-core](https://github.com/BryanWilhite/dotnet-core). These repositories expose my self-education investments in Node.js and .NET Core (featuring ASP.NET Core). This work has provided me with an opinionated approach to how I plan to do my non-XAML-related UI/UX work.

## my commitment to Aurelia and angular.io

My work on [nodejs](https://github.com/BryanWilhite/nodejs) should betray a commitment to [Aurelia](https://github.com/BryanWilhite/nodejs/tree/master/aurelia-official) and [angular.io](https://github.com/BryanWilhite/nodejs/tree/master/angular.io-official). The gumbo of technologies that make up Aurelia are then broken into subtopics of study:

**jQuery.** jQuery still plays a role in the current life of Aurelia. It also is needed because of my current commitment to [Bootstrap](http://getbootstrap.com/) which might be replaced by [Semantic UI](https://semantic-ui.com/). It must be mentioned that angular.io has no default jQuery dependencies. We can also see (today) that there are 10 `jquery-*` folders in [nodejs](https://github.com/BryanWilhite/nodejs) showing more of my legacy load. I do see the possibility that “vanilla JavaScript” will replace all of this jQuery work.

**karma and jasmine.** The `karma-and-jasmine-minimal` [folder](https://github.com/BryanWilhite/nodejs/tree/master/karma-and-jasmine-minimal) is there because [Karma](https://karma-runner.github.io/) and [Jasmine](https://jasmine.github.io/) are used in Aurelia. It follows that these technologies will be the testing tools of choice for my frontend work.

## my commitment to ASP.NET Core and Hugo

## my reduced use of Visual Studio and increased use of Visual Studio Code

## the functional-language bias looming in the background