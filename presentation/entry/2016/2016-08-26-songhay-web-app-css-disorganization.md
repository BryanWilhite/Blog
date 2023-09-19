---json
{
  "documentId": 0,
  "title": "Songhay Web App CSS Disorganization",
  "documentShortName": "2016-08-26-songhay-web-app-css-disorganization",
  "fileName": "index.html",
  "path": "./entry/2016-08-26-songhay-web-app-css-disorganization",
  "date": "2016-08-27T05:14:52.463Z",
  "modificationDate": "2016-08-27T05:14:52.463Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-08-26-songhay-web-app-css-disorganization",
  "tag": "{\r\n  \"extract\": \"Currently Web App CSS is divided into two groups: the styles for the SPA app (/Content/app/css or /Content/apps/fooApp/css) and the styles for the MVC layout (/Content/styles). The MVC CSS is bundled by gulp from _index-*.css files. There is no bundling ...\"\r\n}"
}
---

# Songhay Web App CSS Disorganization

Currently Web App CSS is divided into two groups: the styles for the SPA app (`/Content/app/css` or `/Content/apps/fooApp/css`) and the styles for the MVC layout (`/Content/styles`). The MVC CSS is bundled by gulp from `_index-*.css` files. There is no bundling for the SPA-related CSS.

New organization would place *all* CSS files under `/Content/styles` so *all* CSS files can be bundled by gulp. The `_index-` prefix should be replaced by `_layout-` to refer to the MVC `_Layout.cshtml` page where the bundled CSS is loaded. The suffixes of the `_layout-*.css` files should refer to SPA-app and partials for easy maintenance.

A CSS folder would be filled with a set of files like these:/content/styles
    /_layout-anchors.css
    /_layout-animations.css
    /_layout-footer.css
    /_layout-foo-app-partial1.css
    /_layout-foo-app-partial2.css
    /_layout-foo-app-partial3.css
    /_layout-foo-app.css
    /_layout-nav.css
    /_layout-webfonts.css
    /_layout.css
    /styles.min.css
    /styles-foo-app.css
    /styles-foo-app.min.css
    /styles.css
    /styles.min.cssThe `styles-foo-app.*.css` files are redundant subsets of `styles.*.css` files to allow sharing CSS with external Web apps. The `_layout*.css` files can also be `_layout*.scss` files for `gulp-ruby-sass` or its equivalent.

<https://github.com/BryanWilhite/>
