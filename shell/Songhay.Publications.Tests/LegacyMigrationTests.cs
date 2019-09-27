using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
using Songhay.Publications.Extensions;
using Songhay.Publications.Models;
using Songhay.Tests;
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
            var jsonRootInfo = new DirectoryInfo(jsonRoot);

            var jAIndex = JArray.Parse(File.ReadAllText(jsonRootInfo.GetFiles().First(i => i.Name == indexName).FullName));

            shellRootInfo.Parent.GetDirectories("20*").ForEachInEnumerable(i =>
            {
                this._testOutputHelper.WriteLine(i.Name);
                var a = i.Name.Split('-');
                var year = a.First();
                var month = a.Last();

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

                i.GetFiles("*.md").ForEachInEnumerable(j =>
                {
                    var titleOrSlug = GetTitleOrSlug(j);
                    this._testOutputHelper.WriteLine($"looking for `{titleOrSlug}` in index...");

                    // search index by title
                    var entry = jAIndex.FirstOrDefault(k => ContainsOrStartsWith(k["title"].Value<string>(), titleOrSlug));
                    if (entry != null)
                    {
                        this._testOutputHelper.WriteLine($"found {entry["slug"]}");
                        return;
                    }

                    // search index by slug
                    entry = jAIndex.FirstOrDefault(k => ContainsOrStartsWith(k["slug"].Value<string>(), titleOrSlug));
                    if (entry != null)
                    {
                        this._testOutputHelper.WriteLine($"found {entry["slug"]}");
                        return;
                    }

                    this._testOutputHelper.WriteLine($"WARNING: {titleOrSlug} not found!");
                });
            });
        }

        readonly ITestOutputHelper _testOutputHelper;
    }
}