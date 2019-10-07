---json
{
  "author": "Bryan Wilhite",
  "content": "There are three areas where Cross-origin resource sharing (CORS) must be configured in the Songhay System:Azure Blob StorageWeb APIApache .htaccessAzure Blob StorageCurrently I am calling CloudBlobClient.SetServiceProperties() to allow selected origins f...",
  "inceptDate": "2015-03-04T00:00:00",
  "isPublished": true,
  "slug": "songhay-studio-cors-coverage",
  "title": "Songhay Studio: CORS Coverage"
}
---

There are three areas where Cross-origin resource sharing ([CORS](http://en.wikipedia.org/wiki/Cross-origin_resource_sharing)) must be configured in the Songhay System:

1.  Azure Blob Storage
2.  Web API
3.  Apache `.htaccess`

## Azure Blob Storage

Currently I am calling `CloudBlobClient.SetServiceProperties()` to allow selected origins from a typical integration test. I suppose that can be a Web Job from [Songhay Index](http://songhayindex.azurewebsites.net/) but it’s not really a pressing issue.

CORS for blob storage is currently needed to expose a very small Web font collection (which is quite exciting for me since I’ve been a font lover since before the meme “desktop publishing” was spoken is cutting-edge seriousness).

## Web API

The NuGet [package](http://www.nuget.org/packages/Microsoft.AspNet.WebApi.Cors/) `Microsoft.AspNet.WebApi.Cors` allows me to declare the `EnableCors` attribute on my `ApiController` to allow selected origins. My [Songhay Index](http://songhayindex.azurewebsites.net/) Web API controllers stand in front of the content in Azure Blob Storage.

CORS for Web API is currently needed to expose JSON blobs (specifically, `DisplayItemModel` indices) for Web-based clients.

## Apache .htaccess

I had the choice of configuring CORS in the `httpd.config` file(s) (I use XAMPP on Ubuntu) or simply with `.htaccess`. I went with `.htaccess` like this:

    SetEnvIfNoCase Origin "https?://(www\.)?(mysite1\.com|songhaysystem\.com|mysite2\.io)(:\d+)?$" AccessControlAllowOrigin=$0
    Header add Access-Control-Allow-Origin %{AccessControlAllowOrigin}e env=AccessControlAllowOrigin
    Header add Access-Control-Allow-Methods: "GET,POST,OPTIONS,DELETE,PUT"

I am currently experimenting with CORS as I continue the work toward re-releasing kintespace.com. It’s interesting [to see](http://codepen.io/rasx/pen/ykDGi) that Angular JS, its `$sce.trustAsResourceUrl()` method, can be used to load XHTML5 files directly into another web page. Simultaneously, Web API can be used to load static XHTML5 files, shred them into JSON and (Redis?) cache them for repurposing.
