using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
using Songhay.Publications.Extensions;
using Xunit;

namespace Songhay.Publications.Tests
{
    public partial class MarkdownEntryTests
    {
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
                    title = jO.GetValue<string>("title")
                }))
                .ToArray();
            
            var jA = new JArray(frontMatterDocuments);
            File.WriteAllText(jsonRootInfo.FindFile(indexFileName).FullName, jA.ToString());
        }
    }
}