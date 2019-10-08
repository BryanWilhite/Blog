---json
{
  "documentId": 0,
  "title": "DAR: Backing Up My Blog Blob Storage",
  "documentShortName": "2013-03-03-dar-backing-up-my-blog-blob-storage",
  "fileName": "index.html",
  "path": "./entry/2013-03-03-dar-backing-up-my-blog-blob-storage",
  "date": "2013-03-04T00:00:00.000Z",
  "modificationDate": "2013-03-04T00:00:00.000Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2013-03-03-dar-backing-up-my-blog-blob-storage",
  "tag": "{\r\n  \"extract\": \"Cheers! As of today, this Blog we are reading is backed up with the following cmd shell command: dar2_azure_download songhayblog-azurewebsites-net The command dar2_azure_download uses this Data Activity Runner (DAR) command: …\\\\Songhay.v2\\\\DataAccessRunner...\"\r\n}"
}
---

# DAR: Backing Up My Blog Blob Storage

[<img alt="DAR - Backing Up My Azure-Based Blog" src="http://farm9.staticflickr.com/8252/8529449766_e9e94a8c64.jpg">](http://www.flickr.com/photos/wilhite/8529449766/in/photostream/ "DAR - Backing Up My Azure-Based Blog")

Cheers! As of today, this Blog we are reading is backed up with the following `cmd` shell command:

```console
dar2_azure_download songhayblog-azurewebsites-net
```

The command `dar2_azure_download` uses this Data Activity Runner (DAR) command: `…\Songhay.v2\DataAccessRunner.exe" -n AzureBlobDownloader -nvp BlobContainerName %1` …where `%1` would be `songhayblog-azurewebsites-net`—this is a folder in a conventional root on my local machine.

For the historical record, the version of DAR mentioned in this article is not yet released to CodePlex.com.

@[BryanWilhite](https://twitter.com/BryanWilhite)
