using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Songhay.Cloud.BlobStorage.Extensions;
using Songhay.Extensions;
using Songhay.Models;
using Songhay.Publications.Extensions;
using Songhay.Tests;
using Xunit;

namespace Songhay.Publications.Tests
{
    public partial class MarkdownEntryTests
    {
        [Theory]
        [ProjectFileData(typeof(MarkdownEntryTests), "../../../json/index.json")]
        public void ShouldCompressIndex(FileInfo indexInfo)
        {
            using(FileStream fileStream = indexInfo.OpenRead())
            {
                using(FileStream compressedFileStream = File.Create(indexInfo.FullName.Replace(".json", ".c.json")))
                {
                    using(GZipStream gZipStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        fileStream.CopyTo(gZipStream);
                    }
                }
            }
        }

        [Theory, InlineData(
            "../../../../../presentation/entry", "../../../json", "index.json")]
        public void ShouldGenerateIndex(string entryRoot, string jsonRoot, string indexFileName)
        {
            entryRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryRoot);
            var entryRootInfo = new DirectoryInfo(entryRoot);

            jsonRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, jsonRoot);
            Assert.True(Directory.Exists(jsonRoot));
            var jsonRootInfo = new DirectoryInfo(jsonRoot);

            this._testOutputHelper.WriteLine($"Root {entryRootInfo.FullName}...");

            var frontMatterDocuments = entryRootInfo
                .GetFiles("*.md", SearchOption.AllDirectories)
                .Select(fileInfo => fileInfo.ToMarkdownEntry().FrontMatter)
                .Select(jO => JObject.FromObject(new
                {
                    extract = JObject.Parse(jO.GetValue<string>("tag")).GetValue<string>("extract"),
                        clientId = jO.GetValue<string>("clientId"),
                        inceptDate = jO.GetValue<string>("date"),
                        modificationDate = jO.GetValue<string>("modificationDate"),
                        title = jO.GetValue<string>("title")
                }))
                .ToArray();

            var jA = new JArray(frontMatterDocuments);
            File.WriteAllText(jsonRootInfo.FindFile(indexFileName).FullName, jA.ToString());
        }

        [Theory]
        [ProjectFileData(typeof(MarkdownEntryTests),
            new object[] { "day-path-blog" },
            "../../../json/index.c.json")]
        public async Task ShouldUploadCompressedIndex(string blobContainerName, FileInfo compressedIndexInfo)
        {
            var basePath = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, "../../../");
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("app-settings.songhay-system.json", optional : false, reloadOnChange : true);

            var meta = new ProgramMetadata();
            builder.Build().Bind(nameof(ProgramMetadata), meta);
            var cloudStorageAccount = meta.GetCloudStorageAccount("SonghayCloudStorage", "general-purpose-v1");

            await cloudStorageAccount.UploadBlobAsync(compressedIndexInfo.FullName, blobContainerName, blobContainerPath : string.Empty);

            var containerReference = cloudStorageAccount.GetContainerReference(blobContainerName);
            var blobReference = containerReference.GetBlockBlobReference(compressedIndexInfo.Name);

            Assert.NotNull(blobReference);

            blobReference.Properties.CacheControl = "max-age=864000,public,must-revalidate";
            blobReference.Properties.ContentEncoding = "gzip";
            blobReference.Properties.ContentType = MimeTypes.ApplicationJson;

            await blobReference.SetPropertiesAsync();
        }
    }
}