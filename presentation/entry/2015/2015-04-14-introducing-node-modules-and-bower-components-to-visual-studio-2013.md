---json
{
  "documentId": 0,
  "title": "Introducing node modules and bower components to Visual Studio (2013)",
  "documentShortName": "2015-04-14-introducing-node-modules-and-bower-components-to-visual-studio-2013",
  "fileName": "index.html",
  "path": "./entry/2015-04-14-introducing-node-modules-and-bower-components-to-visual-studio-2013",
  "date": "2015-04-14T07:00:00Z",
  "modificationDate": "2015-04-14T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-04-14-introducing-node-modules-and-bower-components-to-visual-studio-2013",
  "tag": "{\r\n  \"extract\": \"Node modules and bower components (with gulp) are the building blocks of building formal production pipelines for Web apps. My use of NAnt for many years is conceptually related to what can be built with node/bower. As of today’s writing you some artisan...\"\r\n}"
}
---

Node modules and bower components (with gulp) are the building blocks of building formal production pipelines for Web apps. My use of NAnt for many years is conceptually related to what can be built with node/bower. As of today’s writing you some artisanal JavaScript hipster may visit songhaysystem.com and think it a bit lacking (more than a bit)—sorry, mate, I’m back here getting my node/bower pipes flowing…

Getting node on Windows is way, *way* easier than I assumed (or saw a few years ago). We just go [nodejs.org](https://nodejs.org/), download a binary and execute and installer. The installer will give us shortcuts for the Node console and **Node.js command prompt**. I’ve not been using the command prompt because of what comes with the Windows version of Git. Yes, we’ll need to install Git (because bower has a relationship with it—where do you think all those packages are stored?). The story for Git is just like Node’s—we start with [http://git-scm.com/](http://git-scm.com/) to get our installer. After Git is installed, look for the **Git Bash** shortcut. I’ve been working in the Git Bash shell for my work with node modules and bower components.

## The System Image

Here’s a rough sketch of my basic node/bower layout:

```plaintext
%programfiles%\nodejs
%userprofile%\AppData\Roaming\npm
..\Projects\bower_components
..\Projects\node_modules
..\Projects\.bowerrc
..\Projects\bower.json
..\Projects\.tfignore
```

The first two folders, `\nodejs` and `\npm`, come by default after doing the installs mentioned above. The `\Projects` folder is where all of my Visual Studio projects and Solution files reside (btw: my solutions are not in separate folders—all of my projects sit side-by-side and all `*.sln` files are in `\Projects`). Most my manual setup takes place in `\Projects`. The first command to run (from Git bash in `\Projects`) is `touch .bowerrc`. Then write an unspectacular thing like this inside `.bowerrc`:

```json
{
    "directory": "bower_components/",
    "analytics": true
}
```

(This is a bit of overkill, but it’s a reminder that I can change the location of the default bower components folder.) Now, I can run that classic line in the “Install Bower” section of [http://bower.io/](http://bower.io/) and my other basic packages:

```console
npm install -g bower
npm install -g bower-json
npm install -g gulp
```

(I really don’t think I need the `-g` option because my `\Projects` folder should be only place bower and gulp will work.) This completes the ground floor of the node modules I’ll need to get started.

## The Bower Basics

Instead of doing the cool `bower install <package>` thing, let’s setup `bower.json` up front (as listed in the `\Projects` folder above):

```json
{
    "name": "songhay-system",
    "version": "1.0.0",
    "dependencies": {
        "angular-seed": "*",
        "angular-ui-bootstrap-bower": "*",
        "bootstrap": "*",
        "bower-breeze": "*",
        "jquery": "*",
        "jquery-legacy": "jquery#^1",
        "jquery-ui": "*",
        "moment": "*",
        "slickgrid": "*",
        "underscore": "*"
    },
    "authors": [
      { "name": "Bryan Wilhite", "email": "rasx@songhaysystem.net", "homepage": "http://songhaysystem.com" }
    ]
}
```

Now all I have to do is run `bower install` (from the `\Projects` folder) and my output looks like this:
[<img alt="songhay bower" src="https://farm9.staticflickr.com/8715/16941208490_395bdb5945_z_d.jpg">](https://www.flickr.com/photos/wilhite/16941208490/ "songhay bower")

It’s not perfect (why those “`invalid-meta`” lines?) but it’s a start.

## The Importance of .tfignore

In the same manner that Git folks have `.gitignore`, Microsoft’s TFS (finally!) has `.tfignore`. I have had at least two, useless, soul-sucking arguments with self-described “senior” Microsoft developers who resisted using NuGet packages because there was no `.tfignore`. Now there is and I can get some soul back! Here’s my `.tfignore` file:

```plaintext
# info:
# <https://msdn.microsoft.com/en-us/library/ms245454.aspx?f=255&MSPPError=-2147217396>#tfignore
\bower_components
\node_modules
\packages
!\packages\repositories.config
```

According to [a stackoverflow.com article](http://stackoverflow.com/questions/24143925/get-tfs-to-ignore-my-packages-folder), my `.tfignore` file can be overridden by NuGet. So a `NuGet.config` file has to be added to the `\.nuget` folder of your Visual Studio project root:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <solution>
    <add key="disableSourceControlIntegration" value="true" />
  </solution>
</configuration>
```

## Related Links

* “[Introducing Gulp, Grunt, Bower, and npm support for Visual Studio](http://www.hanselman.com/blog/IntroducingGulpGruntBowerAndNpmSupportForVisualStudio.aspx)” by Scott Hanselman
* “[Getting started with Grunt, SASS and Task Runner Explorer](http://www.iambacon.co.uk/blog/getting-started-with-grunt-sass-and-task-runner-explorer-visual-studio)” by Colin Bacon
* “[Crash Course in Node, Bower, and Grunt](https://www.youtube.com/watch?v=vkRv0r_tNXY&feature=youtube_gdata_player)”
* “[Gulp vs Grunt. Why one? Why the Other?](https://medium.com/@preslavrachev/gulp-vs-grunt-why-one-why-the-other-f5d3b398edc4)”
* “[Initializing Bower and NPM](https://www.youtube.com/watch?v=-_9N9aY8aNc&feature=youtube_gdata_player)”
* “[Gulp—The Basics](https://www.youtube.com/watch?v=dwSLFai8ovQ&feature=youtube_gdata_player)”
* “[Gulp.js Build System #1—Fundamentals](https://www.youtube.com/watch?v=LmdT2zhFmn4&feature=youtube_gdata_player)”
* “[How to change bower’s default components folder?](http://stackoverflow.com/questions/14079833/how-to-change-bowers-default-components-folder)”
* “[How to validate Bower files](http://enzolutions.com/articles/2014/10/24/how-to-validate-bower-files/)”
* “[Node.js as a build script](http://blog.millermedeiros.com/node-js-as-a-build-script/)”
* “[Customize which files are ignored by version control](https://msdn.microsoft.com/en-us/library/ms245454.aspx?f=255&MSPPError=-2147217396)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
