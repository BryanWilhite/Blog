---json
{
  "documentId": 0,
  "title": "studio status report: 2022-03",
  "documentShortName": "2022-03-30-studio-status-report-2022-03",
  "fileName": "index.html",
  "path": "./entry/2022-03-30-studio-status-report-2022-03",
  "date": "2022-03-30T19:54:04.929Z",
  "modificationDate": "2022-03-30T19:54:04.929Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2022-03-30-studio-status-report-2022-03",
  "tag": "{\n  \"extract\": \"month 3 of 2022 was about learning how to use Elmish components and quitting the day-job I did not quit my day job in order to work on the project that I have been working on for the last five months. That would not be a wise financial decision. And there…\"\n}"
}
---

# studio status report: 2022-03

## month 3 of 2022 was about learning how to use Elmish components and quitting the day-job

I did _not_ quit my day job in order to work on the [project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) that I have been working on for the last five months. That would not be a wise financial decision. And there really is no need for me go into detail about why I quit. The essentialist question to ask is, Did my day job have anything to do with current Studio work? And my answer is, Not really. Nevertheless, the gig was a great learning experience until is wasn’t.

Meanwhile back in the Studio, I made [a commit](https://github.com/BryanWilhite/Songhay.Dashboard/commit/2af72056000847aece9a82e503f3ea793131b5b5) that represents a new understanding of not just how to use `Bolero.ElmishComponent<_,_>` but how to package `Bolero.ElmishComponent<_,_>` types in a separate F# project for the sake of reusability. I intend to write about this hard-won revelation soon but, in the mean time, let us remind ourselves that an [Elmish](https://elmish.github.io/) program defines a conventional `update`-`view` cycle with an expression like this:

```fsharp
Program.mkProgram init update view
```

This may seem obvious to every other Elmish developer on Earth but it was not clear to me that `Bolero.ElmishComponent<_,_>` does not have its own `update`-`view` cycle. Hey Bryan: there is only one `update`-`view` cycle and it is on the Elmish `Program` level. What this means (super-obviously) is that, yes, we can define a `view` function on the Elmish Component level but it must be ‘chained’ to the `Program`-level `view` function. However, trying to make an `update` function on the Elmish Component level held me up for _days_. The elegant simplicity was overwhelming! This [commit](https://github.com/BryanWilhite/Songhay.Dashboard/commit/2af72056000847aece9a82e503f3ea793131b5b5) I made represents the realization that an `updateModel` function was needed (for my design) instead of a child `update` function—again, I’ll explain why later.

## month 3 of 2022 was also about learning how to use `webpack` to release JavaScript libraries for CDNs

Retrospectively, is makes sense that _first thing_ most `webpack` users would do is bundle a JavaScript library for <acronym title="Content Delivery Network">CDN</acronym> usage with, say, [unpkg](https://unpkg.com/). Here in Bryan-world, this is like the _last_ thing I am doing with `webpack`. For example, my `songhay` [library](https://www.npmjs.com/package/songhay), was originally intended to be compiled/bundled in a TypeScript project. So `webpack` was originally needed for its generation of `*.d.ts` files for the Typescript-project IDE experience. My secondary need for `webpack` is to bundle the output of these Typescript projects into _one_ minimized file for production release.

It was not until _this month_ that I realized the super obvious: I could not use `songhay` on a site like CodePen—and I needed CodePen to help me with my Bolero work, prototyping the responsive thumbnail experience for the b-roll player. On CodePen, I modified this experience by starting with:

1. [thumbnails](https://codepen.io/rasx/pen/rNYQowe) with jQuery
2. [thumbnails](https://codepen.io/rasx/pen/popzXxm) with modern, native JavaScript
3. [thumbnails](https://codepen.io/rasx/pen/mdpdqwW) with the `songhay` [library](https://www.npmjs.com/package/songhay)

Now I can experiment with #3 by translating it into Bolero. CodePen can finally see `songhay` with this URI: <https://unpkg.com/songhay@0.3.1/dist/songhay.js>. This was all made possible with [the following](https://github.com/BryanWilhite/songhay-core/blob/8456414e4dc135c13d714ea0502e2fbdd250f1f6/webpack.config.js#L35) `webpack.config.js` setting:

```javascript
const outputLibraryConfig = {
    library: {
        name: 'rx',
        type: 'var',
    },
};
```

As of this writing, the `webpack` folks document `output.library` under [the configuration section of their documentation](https://webpack.js.org/configuration/output/#outputlibrary). When a novice first uses `webpack`, they might read the [concepts section of the documentation](https://webpack.js.org/concepts/#output) and never see `output.library` (which is what I did).

## selected Studio notes from month 3

### Bolero: more examples of `Bolero.ElmishComponent<_,_>`

Search: <https://github.com/search?l=F%23&p=2&q=ElmishComponent&type=Code>

The Elmish `update`-`view` calls are top-level only. I have not found an example of some kind of nested `update`-`view` cycle on the `Bolero.ElmishComponent<_,_>` level.

`MovingLineSvg.fs` [[GitHub](https://github.com/weebs/HomeBase/blob/d116a7addd0c399bd70d92283c129fbaa5b9b6bf/Launcher/Programs/MovingLineSvg.fs)]: top-level `view` pushes top-level `model` to two `Bolero.ElmishComponent<_,_>` types. Very straight forward.

`fsharp-wasm-static-demo/src/GitHubUser/Main.fs ` [[GitHub](https://github.com/srid/fsharp-wasm-static-demo/blob/b9f40dca62d759505f892b39e1f9c57fc2010a63/src/GitHubUser/Main.fs)]: `ecomp<_,_,_>` is being called from top-level `view`.

`StatsBot/src/StatsBot.Client/Components.Main.fs` [[GitHub](https://github.com/Liminiens/StatsBot/blob/6759bf9ce91f4a3db5ce16ad9495a34b990a211e/src/StatsBot.Client/Components.Main.fs)]: an interesting use of components.

`EsBankAccount/View/Notify.fs` [[GitHub](https://github.com/akhansari/EsBankAccount/blob/d9a92b6ef8fae93f2b160ce753eee422ef793600/EsBankAccount/View/Notify.fs)]: top-level view calls child, `Bolero.ElmishComponent<_,_>` `view` functions.

### Typescript in the Studio is not professional

Precious hours were lost yesterday because I failed to step back and determine whether the Typescript pipelines/stacks were _professional_: there appears to be no coherent, organized usage of Typescript.

It appears that my primary Typescript goals is to expose a JavaScript library with TypeScript types for consumption in Angular (TypeScript) projects (which is kind of weird because Typescript is being compiled to JavaScript to be consumed in Typescript projects). My usage of `unpkg.com` exposes the fact that I am not packaging bundles (minimized and not) with `webpack`.

Wow. There are over 94 `tsconfig*.json` files (which I find hard to believe), [according to GitHub](https://github.com/search?q=user%3ABryanWilhite+filename%3Atsconfig.json&type=Code). I can start with ignoring `tsconfig.spec.json` and `tsconfig.e2e.json` for the time being and first look at my latest `tsconfig*.json` files:

- `tsconfig.json` [in](https://github.com/BryanWilhite/songhay-core/blob/ef73310d309eee3c22eb52acaa8f9a1d63074741/tsconfig.json) `songhay-core` (`"module": "es2015",`, `"target": "es5"`)
- `tsconfig.json` [in](https://github.com/BryanWilhite/day-path/blob/e5c6b1ae0d43a2fdbe6e3d7fecdf27491cd3b316/tsconfig.json) `day-path` (`"module": "ES2015",`, `"target": "ES2015",`)

## sketching out a development schedule (revision 20)

The schedule of the month:

- complete [project](https://github.com/BryanWilhite/Songhay.Dashboard/projects/2) associated with new version of SonghaySystem.com 📜🚜🔨
- generate Publication indices from LiteDB for `Songhay.Publications.KinteSpace`
- use the learnings of previous work in Bolero to upgrade and re-release the kinté space 🚀
- convert Day Path Blog and SonghaySystem.com to HTTPs by default 🔐

<https://github.com/BryanWilhite/>
