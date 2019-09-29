using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Html2Markdown;
using Html2MarkdownHacks;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
using Songhay.Publications.Extensions;
using Songhay.Publications.Models;
using Songhay.Xml;
using Xunit;
using Xunit.Abstractions;

namespace Songhay.Publications.Tests
{
    public class LegacyMigrationTests
    {
        public static JObject ConvertToCamelCase(JObject jObject)
        {
            var jProperties = jObject.Properties();
            return new JObject(jProperties.Select(i =>
            {
                var propertyName = string.Concat(i.Name.Substring(0, 1).ToLower(), i.Name.Substring(1));
                return new JProperty(propertyName, i.Value);
            }));
        }

        public static string GetExtract(string content)
        {
            content = HtmlUtility.ConvertToXml(content);
            content = content.Replace("&nbsp;", string.Empty); // TODO: this should be in HtmlUtility.ConvertToXml().
            var rootElement = XElement.Parse(string.Format("<root>{0}</root>", content));
            content = XObjectUtility.JoinFlattenedXTextNodes(rootElement);
            var limit = 255;
            return (content.Length > limit) ? string.Format("{0}...", content.Trim().Substring(0, limit - 1)) : content;
        }

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
                    try
                    {
                        var html = legacyEntry.GetValue<string>("Content");
                        Func<IReplacerIdentifier, bool> filter =
                            replacer =>
                            (replacer.HtmlGroup != HtmlGroups.InlineEntities) &&
                            (replacer.HtmlElement != HtmlElements.blockquote) &&
                            (replacer.HtmlElement != HtmlElements.img);
                        var scheme = new SonghayMarkdownScheme(filter);
                        var converter = new Converter(scheme);
                        var markdown = converter.Convert(html);

                        var entry = new MarkdownEntry().WithEdit(e =>
                        {
                            legacyEntry["Content"] = GetExtract(legacyEntry.GetValue<string>("Content"));
                            e.FrontMatter = ConvertToCamelCase(legacyEntry);
                            e.Content = markdown;
                        });

                        var path = Path.Combine(
                            presentationEntryRootInfo.GetDirectories(inceptDate.Year.ToString()).First().FullName,
                            $"{inceptDate:yyyy-MM-dd}-{slug}.md"
                        );
                        File.WriteAllText(path, entry.ToFinalEdit());
                    }
                    catch (Exception ex)
                    {
                        this._testOutputHelper.WriteLine($"EXCEPTION: {ex.Message}");
                        this._testOutputHelper.WriteLine(ex.StackTrace);
                    }
                }
            });
        }

        readonly ITestOutputHelper _testOutputHelper;
    }
}