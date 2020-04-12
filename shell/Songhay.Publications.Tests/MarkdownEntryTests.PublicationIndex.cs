using System.IO;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
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
    }
}