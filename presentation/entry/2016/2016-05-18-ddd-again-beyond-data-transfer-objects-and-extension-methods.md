---json
{
  "documentId": 0,
  "title": "DDD again: Beyond Data Transfer Objects and Extension Methods",
  "documentShortName": "2016-05-18-ddd-again-beyond-data-transfer-objects-and-extension-methods",
  "fileName": "index.html",
  "path": "./entry/2016-05-18-ddd-again-beyond-data-transfer-objects-and-extension-methods",
  "date": "2016-05-19T05:31:16.388Z",
  "modificationDate": "2016-05-19T05:31:16.388Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2016-05-18-ddd-again-beyond-data-transfer-objects-and-extension-methods",
  "tag": "{\r\n  \"extract\": \"The overwhelming majority of my .NET classes are Data Transfer Objects (DTOs), primarily for JSON or Entity Framework transfer. It has occurred to me informally that a static business rule can be handled in an Extension Method over a DTO. This informal ‘...\"\r\n}"
}
---

# DDD again: Beyond Data Transfer Objects and Extension Methods

The overwhelming majority of my .NET classes are Data Transfer Objects (DTOs), primarily for JSON or Entity Framework transfer. It has occurred to me informally that a static business rule can be handled in an Extension Method over a DTO. This informal ‘style’ has worked very well for me for the last five or more years. This implies that I have yet to run into the problem of needing stateful business rules—which might be due to my bias toward sneaking in functional programming styles in C#.

I have no informal approach toward stateful business rules. This is actually great because I have been aware for a few years about formal approaches—I just did not know it until now. In the world of Domain Driven Design, an “anemic object” is one that quacks like a DTO but it actually contains stateful business rules. I used to assume that an “anemic object” *is* a DTO—which could be true to hard-core DDD folks.

## Related Links

* “[Getters/Setters. Evil. Period.](http://www.yegor256.com/2014/09/16/getters-and-setters-are-evil.html)”
* “[Doing it wrong: getters and setters](http://typicalprogrammer.com/doing-it-wrong-getters-and-setters/)”
* “[Songhay Studio: UX and DDD, my new acronym umbrella…](http://songhayblog.azurewebsites.net/entry/songhay-studio-ux-and-ddd-my-new-acronym-umbrella)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
