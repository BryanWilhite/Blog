---json
{
  "documentId": 0,
  "title": "Tip: How to quickly format someone else’s XAML",
  "documentShortName": "2014-05-27-tip-how-to-quickly-format-someone-else-s-xaml",
  "fileName": "index.html",
  "path": "./entry/2014-05-27-tip-how-to-quickly-format-someone-else-s-xaml",
  "date": "2014-05-27T07:00:00Z",
  "modificationDate": "2014-05-27T07:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2014-05-27-tip-how-to-quickly-format-someone-else-s-xaml",
  "tag": "{\r\n  \"extract\": \"In “The Fat-Getter and other MVVM Anti-Patterns” my little ‘Eagerly Disregarding Design-Time Concerns’ section complains about how developers (especially C++ dudes falling into C#/XAML) fail to appreciate the power of declarative programming. This is oft...\"\r\n}"
}
---

# Tip: How to quickly format someone else’s XAML

In “[The Fat-Getter and other MVVM Anti-Patterns](http://songhayblog.azurewebsites.net/Entry/Show/the-fat-getter-and-other-mvvm-anti-patterns)” my little ‘Eagerly Disregarding Design-Time Concerns’ section complains about how developers (especially C++ dudes falling into C#/<acronym title="Extensible Application Markup Language">XAML</acronym>) fail to appreciate the power of declarative programming. This is often demonstrated by having crappy markup files that are write-only, read-never. Often (in righteous protest against the lack of DRY principles baked into XAML) there is cutting and pasting going on the XAML file with crazy indentations.

My instinctive move is to start prettying up the file by hand (because I’m usually in some corporation’s Visual Studio without some awesome plugin that can take care of this stuff for me). My instinct was wrong. I now bite the bullet and go to **Options > XAML > Spacing** and set **Attribute Spacing** to **Insert a single space between attributes** and **Element Spacing** to **Collapse multiple empty lines in content to a single line**.
[<img alt="How to quickly format someone else’s XAML" src="https://farm3.staticflickr.com/2932/14127061603_d7772dd018_z_d.jpg">](https://www.flickr.com/photos/wilhite/14127061603/ "How to quickly format someone else’s XAML")

This brute force will minimize the lines of markup used and force all attributes to one line (unless there is a line break inside of an attribute value). This is most hostile to top-level (namespace) attributes. This is a trade-off when there’s no fancy, third-party plugins around.

<https://github.com/BryanWilhite/>
