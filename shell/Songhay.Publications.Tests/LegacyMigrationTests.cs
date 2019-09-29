using System.Xml.Linq;
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
using Songhay.Publications.Extensions;
using Songhay.Publications.Models;
using Xunit;
using Xunit.Abstractions;

namespace Songhay.Publications.Tests
{
    public class LegacyMigrationTests
    {
        public LegacyMigrationTests(ITestOutputHelper helper)
        {
            this._testOutputHelper = helper;
        }

        [Theory]
        [InlineData("../../../../../shell", "../../../json", "index.json")]
        public void ShouldMigrateLegacy(string shellRoot, string jsonRoot, string indexName)
        {
            shellRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, shellRoot);
            Assert.True(Directory.Exists(shellRoot));

            jsonRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, jsonRoot);
            Assert.True(Directory.Exists(jsonRoot));

            var shellRootInfo = new DirectoryInfo(shellRoot);
            var presentationEntryRootInfo = shellRootInfo.Parent
                .GetDirectories("presentation").First()
                .GetDirectories("entry").First();
            var jsonRootInfo = new DirectoryInfo(jsonRoot);

            var jAIndex = JArray.Parse(File.ReadAllText(jsonRootInfo.GetFiles().First(i => i.Name == indexName).FullName));

            shellRootInfo.Parent.GetDirectories("20*").ForEachInEnumerable(i =>
            {
                this._testOutputHelper.WriteLine(i.Name);
                var a = i.Name.Split('-');
                var year = a.First();
                var month = a.Last();

                if (!presentationEntryRootInfo.GetDirectories(year).Any())
                    presentationEntryRootInfo.CreateSubdirectory(year);

                bool ContainsOrStartsWith(string input, string search)
                {
                    return input.Contains(search) || input.StartsWith(search);
                }

                string GetTitleOrSlug(FileInfo info)
                {
                    var titleLength = 53; // where did this number come from? 🤷‍
                    var titleOrSlug = info.Name.Replace(".md", string.Empty);
                    if (titleOrSlug.Length >= titleLength) titleOrSlug.Substring(0, titleLength);

                    if (titleOrSlug.StartsWith("studio-status-report"))
                    {
                        titleOrSlug = $"studio-status-report-{year}-{month}";
                    }

                    return titleOrSlug;
                }

                void WriteEntry(JToken frontMatter, FileInfo legacy)
                {
                    var entry = new MarkdownEntry().WithEdit(e =>
                    {
                        e.FrontMatter = frontMatter as JObject;
                        e.Content = File.ReadAllText(legacy.FullName);
                    });

                    var date = entry.FrontMatter["inceptDate"].Value<DateTime>();

                    var slug = $"{year}-{month}-{date.Day:00}-{entry.FrontMatter["slug"]}".Replace($"-{year}-{month}", string.Empty);
                    entry.FrontMatter["slug"] = slug;
                    var path = Path.Combine(presentationEntryRootInfo.FullName, year, $"{slug}.md");
                    File.WriteAllText(path, entry.ToFinalEdit());
                }

                i.GetFiles("*.md").ForEachInEnumerable(j =>
                {
                    var titleOrSlug = GetTitleOrSlug(j);
                    this._testOutputHelper.WriteLine($"looking for `{titleOrSlug}` in index...");

                    // search index by title
                    var indexItem = jAIndex.FirstOrDefault(k => ContainsOrStartsWith(k["title"].Value<string>(), titleOrSlug));
                    if (indexItem != null)
                    {
                        this._testOutputHelper.WriteLine($"found {indexItem["slug"]}");
                        WriteEntry(indexItem, j);
                        return;
                    }

                    // search index by slug
                    indexItem = jAIndex.FirstOrDefault(k => ContainsOrStartsWith(k["slug"].Value<string>(), titleOrSlug));
                    if (indexItem != null)
                    {
                        this._testOutputHelper.WriteLine($"found {indexItem["slug"]}");
                        WriteEntry(indexItem, j);
                        return;
                    }

                    this._testOutputHelper.WriteLine($"WARNING: {titleOrSlug} not found!");
                });
            });
        }

        [Theory]
        [InlineData("../../../../../shell",
            "../../../../../../azure-storage-accounts/songhay/songhayblog-azurewebsites-net/BlogEntry",
            "../../../json", "index.json")]
        public void ShouldMigrateLegacyFromAzS(string shellRoot, string azsRoot, string jsonRoot, string indexName)
        {
            shellRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, shellRoot);
            Assert.True(Directory.Exists(shellRoot));

            azsRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, azsRoot);
            Assert.True(Directory.Exists(azsRoot));

            jsonRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, jsonRoot);
            Assert.True(Directory.Exists(jsonRoot));

            var shellRootInfo = new DirectoryInfo(shellRoot);
            var azsRootInfo = new DirectoryInfo(azsRoot);
            var presentationEntryRootInfo = shellRootInfo.Parent
                .GetDirectories("presentation").First()
                .GetDirectories("entry").First();
            var jsonRootInfo = new DirectoryInfo(jsonRoot);

            var jAIndex = JArray.Parse(File.ReadAllText(jsonRootInfo.GetFiles().First(i => i.Name == indexName).FullName));

            azsRootInfo.GetFiles().ForEachInEnumerable(i =>
            {
                this._testOutputHelper.WriteLine(i.Name);

                var legacyEntry = JObject.Parse(File.ReadAllText(i.FullName));

                var slug = legacyEntry.GetValue<string>("Slug");
                var inceptDate = legacyEntry.GetValue<DateTime>("InceptDate");

                if (!presentationEntryRootInfo.GetDirectories(inceptDate.Year.ToString()).Any())
                {
                    presentationEntryRootInfo.CreateSubdirectory(inceptDate.Year.ToString());
                }

                if (presentationEntryRootInfo
                    .GetDirectories(inceptDate.Year.ToString()).First()
                    .GetDirectories($"*{slug}.md").Any())
                {
                    this._testOutputHelper.WriteLine($"`{slug}` already exists");
                }
                else
                {
                    this._testOutputHelper.WriteLine($"writing `{slug}`...");
                }
            });
        }

        readonly ITestOutputHelper _testOutputHelper;
    }
}