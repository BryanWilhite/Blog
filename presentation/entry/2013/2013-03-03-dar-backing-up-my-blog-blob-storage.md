---json
{
  "author": "Bryan Wilhite",
  "content": "Cheers! As of today, this Blog we are reading is backed up with the following cmd shell command: dar2_azure_download songhayblog-azurewebsites-net The command dar2_azure_download uses this Data Activity Runner (DAR) command: …\\Songhay.v2\\DataAccessRunner...",
  "inceptDate": "2013-03-03T16:00:00-08:00",
  "isPublished": true,
  "itemCategory": null,
  "modificationDate": "0001-01-01T00:00:00",
  "slug": "dar-backing-up-my-blog-blob-storage",
  "sortOrdinal": 0,
  "tag": null,
  "title": "DAR: Backing Up My Blog Blob Storage"
}
---

[<img alt="DAR - Backing Up My Azure-Based Blog" src="http://farm9.staticflickr.com/8252/8529449766_e9e94a8c64.jpg">](http://www.flickr.com/photos/wilhite/8529449766/in/photostream/ "DAR - Backing Up My Azure-Based Blog")

Cheers! As of today, this Blog we are reading is backed up with the following `cmd` shell command:


dar2_azure_download songhayblog-azurewebsites-net


The command `dar2_azure_download` uses this Data Activity Runner (DAR) command:


…\Songhay.v2\DataAccessRunner.exe" -n AzureBlobDownloader -nvp BlobContainerName %1


…where `%1` would be `songhayblog-azurewebsites-net`—this is a folder in a conventional root on my local machine.

For the historical record, the version of DAR mentioned in this article is not yet released to CodePlex.com.
