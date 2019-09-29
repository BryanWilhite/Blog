---json
{
  "author": "Bryan Wilhite",
  "content": "This article is sort of the Windows 10 version of my previous note, “Using gulp-ruby-sass on an Ubuntu virtual machine with some ‘history’.”Install one of the recommended Ruby installers at rubyinstaller.org. As of this writing, the recommendation for me...",
  "inceptDate": "2016-04-26T01:17:10.1834492-07:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "using-gem-install-sass-pre-on-windows-10",
  "sortOrdinal": 0,
  "tag": null,
  "title": "Using `gem install sass --pre` on Windows 10"
}
---

This article is sort of the Windows 10 version of my previous note, “[Using gulp-ruby-sass on an Ubuntu virtual machine with some ‘history’](http://songhayblog.azurewebsites.net/).”

Install one of the recommended Ruby installers [at rubyinstaller.org](http://rubyinstaller.org/downloads/). As of this writing, the recommendation for me is [Ruby 2.2.4 (x64)](http://dl.bintray.com/oneclick/rubyinstaller/rubyinstaller-2.2.4-x64.exe).

Use the **Start Command Prompt with Ruby** shortcut and enter the same command as you would on Linux:


gem install sass --pre
    

(The `--pre` option may not be required as time has passed since that ‘previous note’ mentioned above.) Click the **Environment Variables…** button under System Properties and append this:


;C:\Ruby22-x64\bin
    

Note: you should not have to do this when you check that ‘update path option’ in the ruby installer. This appended path allows us to call sass directly (from the conventional `\styles` folder), for development:


sass _body.scss styles.css -E utf-8
    

…and production:


sass _body.scss styles.min.css --style=compressed -E utf-8
    

…where `_body.scss` is the conventional Sass file with `@import` declarations for ‘child’ `.scss` files.

Note the encoding option `-E` is needed to force UTF-8 output—evidently, [a sass-on-Windows issue](http://blog.pixelastic.com/2014/09/06/compass-utf-8-encoding-on-windows/).
