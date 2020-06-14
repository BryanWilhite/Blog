---json
{
  "documentId": 0,
  "title": "Using gulp-ruby-sass on an Ubuntu virtual machine with some ‘history’",
  "documentShortName": "2015-07-31-using-gulp-ruby-sass-on-an-ubuntu-virtual-machine-with-some-history",
  "fileName": "index.html",
  "path": "./entry/2015-07-31-using-gulp-ruby-sass-on-an-ubuntu-virtual-machine-with-some-history",
  "date": "2015-08-01T02:54:07.115Z",
  "modificationDate": "2015-08-01T02:54:07.115Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-07-31-using-gulp-ruby-sass-on-an-ubuntu-virtual-machine-with-some-history",
  "tag": "{\r\n  \"extract\": \"My Ubuntu virtual machine (VM) is older than Node JS, grunt or gulp. Years ago I actually installed ruby-based sass and used it with many discomforts from the command line—without the benefit of any automated workflow. I cannot remember exactly but I rec...\"\r\n}"
}
---

# Using gulp-ruby-sass on an Ubuntu virtual machine with some ‘history’

My Ubuntu virtual machine (VM) is older than Node JS, grunt or gulp. Years ago I actually installed [ruby-based sass](http://wylbur.us/2014-06-12-installing-sass-on-ubuntu-1404) and used it with many discomforts from the command line—without the benefit of *any* automated workflow. I cannot remember exactly but I recall choosing the ruby flavor of sass over what is now called [libsass](https://github.com/sass/libsass) because (I think) the ruby version had more features in spite of it being slower.

Because my VM is so old (even though it is now upgraded to the latest LTS version of Ubuntu), when I went to install `gulp-ruby-sass`, just like any node-loving kid, I ignored one innocent [comment on the website](https://www.npmjs.com/package/gulp-ruby-sass):

<blockquote>

You must have Sass >=3.4.

</blockquote>

Of course it took me hours to figure this out (in part because no errors our any output appeared) but I needed to [run two commands](http://askubuntu.com/questions/92468/how-do-i-update-to-the-latest-version-of-sass/92471?stw=2) to get `gulp-ruby-sass` to work properly:

```bash
sudo gem uninstall -Iax haml-edge
sudo gem install sass --pre
```

I’ve saved my `gulpfile.js` as a GitHub Gist, showing use of `gulp-rename` and `gulp-sourcemaps`:

<script src="https://gist.github.com/BryanWilhite/c453a5b91f87ad8641eb.js"></script>

This, by the way, is the Gulp file for a future version of kintespace.com.

@[BryanWilhite](https://twitter.com/BryanWilhite)
