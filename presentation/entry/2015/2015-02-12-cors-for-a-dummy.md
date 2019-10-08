---json
{
  "documentId": 0,
  "title": "CORS for a dummy",
  "documentShortName": "2015-02-12-cors-for-a-dummy",
  "fileName": "index.html",
  "path": "./entry/2015-02-12-cors-for-a-dummy",
  "date": "2015-02-12T08:00:00.000Z",
  "modificationDate": "2015-02-12T08:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-02-12-cors-for-a-dummy",
  "tag": "{\r\n  \"extract\": \"I’ve asked this StackOverflow.com question: “Is it possible to verify CORS headers from a Visual Studio Integration Test?” (It would be nice to have the time to read “Network Programming in the .NET Framework.”) This StackOverflow.com question is based o...\"\r\n}"
}
---

# CORS for a dummy

I’ve asked this StackOverflow.com question: “[Is it possible to verify CORS headers from a Visual Studio Integration Test?](http://stackoverflow.com/questions/28439961/is-it-possible-to-verify-cors-headers-from-a-visual-studio-integration-test)” (It would be nice to have the time to read “[Network Programming in the .NET Framework](https://msdn.microsoft.com/en-us/library/4as0wz7t(v=vs.110).aspx).”) This StackOverflow.com question is based on a failed attempt to write an integration test using code from “[Cross-origin resource sharing in ASP.NET Web Api](http://gik.firetrot.com/index.php/2014/05/15/cross-origin-resource-sharing-in-asp-net-web-api/).” This failure leaves me with new assertions:

* .NET Security should prevent spoofing/mocking requests: the `Origin` header has to match a live server actually at the origin.
* You should be able to use `OPTIONS` http requests to obtain response headers that provide information—like CORS information.

## Related Links

* “[An Introduction to Content Security Policy](http://www.html5rocks.com/en/tutorials/security/content-security-policy/)”
* “[Wei Lu: HTTP Headers—The Simplest Security—JSConf.Asia 2014](https://www.youtube.com/watch?v=rWZXn_Krg38&feature=youtube_gdata_player)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
