using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Markdig;
using Newtonsoft.Json.Linq;
using Songhay.Extensions;
using Songhay.Publications.Extensions;
using Songhay.Publications.Models;
using Xunit;
using Xunit.Abstractions;

namespace Songhay.Publications.Tests
{
    public class MarkdownEntryTests
    {
        internal static string GetExtractFromMarkdown(MarkdownEntry entry, int length)
        {
            var content = entry.ToParagraphs().Skip(1).Aggregate((a, i) => $"{a} {i}");
            content = Markdown.ToPlainText(content);
            return (content.Length > length) ?
                string.Concat(content.Substring(0, length), "…") :
                content;
        }

        internal static string ProcessParagraph(string p, ITestOutputHelper helper)
        {
            MatchEvaluator ReplaceMatchGroupOneWithEmptyString = (Match m) =>
            {
                var group = m.Groups[1];
                return m.Value.Replace(group.Value, string.Empty);
            };

            MatchEvaluator ReplaceMatchGroupOneWithOneSpace = (Match m) =>
            {
                var group = m.Groups[1];
                return m.Value.Replace(group.Value, " ");
            };

            helper.WriteLine($"`{p}`");

            p = Regex.Replace(p, @"^(\#+) {2,}", // header with too many spaces
                m =>
                {
                    return $"{m.Groups[1].Value} ";
                });

            p = Regex.Replace(p, @"^\#+([\r\n]+ +)", // header with line break and any spaces
                ReplaceMatchGroupOneWithOneSpace);

            p = Regex.Replace(p, @"^\* {2,}", "* "); // unordered list items with too many spaces [first item]

            p = Regex.Replace(p, @"([\r,\n])\* {2,}", // unordered list items with too many spaces
                m =>
                {
                    var group = m.Groups[1];
                    return $"{group.Value}* ";
                });

            p = Regex.Replace(p, @"\!\[\]\([^(]+\)", // image without alt text
                m => m.Value.Replace("![]", "![blog image]"));

            p = Regex.Replace(p, @"\[\!\[[^[]+(\s+)\]\(", // link with image with trailing space(s)
                ReplaceMatchGroupOneWithEmptyString);

            p = Regex.Replace(p, @"\]\(http[^)]+\)(\s+)\]\(http", // link with image with trailing space(s)
                ReplaceMatchGroupOneWithEmptyString);

            p = Regex.Replace(p, @"\[\[[^\]]+](\s+)]", // link with brackets with space(s)
                ReplaceMatchGroupOneWithEmptyString);

            p = Regex.Replace(p, @"\[(\s+)\[[^\]]+]]", // link with brackets with space(s)
                ReplaceMatchGroupOneWithEmptyString);

            p = Regex.Replace(p, @"\[(\s+)\!\[[^[]+\]", // link with image with leading space(s)
                m =>
                {
                    var group = m.Groups[1];
                    return m.Value.Remove(1, group.Length);
                });

            p = Regex.Replace(p, @"\[(\s+)<img", // link with image with leading space(s)
                m =>
                {
                    var group = m.Groups[1];
                    return m.Value.Remove(1, group.Length);
                });

            p = Regex.Replace(p, @">(\s+)\]", // link with image (or any HTML element) with trailing space(s)
                ReplaceMatchGroupOneWithEmptyString);

            p = Regex.Replace(p, @"\[(\s+)\!\[[^\]]+\]\]\([^\)]+(\)\s+\])",
                // link with Twitter image and handle with leading space(s)
                m =>
                {
                    var group = m.Groups[1];
                    var s = m.Value.Remove(1, group.Length);
                    group = m.Groups[2];
                    return s.Replace(group.Value, ")]");
                });

            p = p.Replace("\t", "    "); // replace tabs with spaces

            p = Regex.Replace(p, @"\s+$", string.Empty); // trailing spaces after paragraph

            p = Regex.Replace(p, @"[\d]+\.( {2,})", // number mark with too many spaces
                ReplaceMatchGroupOneWithOneSpace);

            return p.Trim();
        }

        internal static void ValidateFrontMatter(FileInfo entry)
        {
            var markdownEntry = entry.ToMarkdownEntry();
        }

        public MarkdownEntryTests(ITestOutputHelper helper)
        {
            this._testOutputHelper = helper;
        }

        [Theory, InlineData(
            "../../../../../presentation/entry/2019/2019-10-23-studio-status-report-2019-10.md")]
        public void ShouldAddBlogEntryExtract(string entryPath)
        {
            entryPath = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryPath);

            var entryPathInfo = new FileInfo(entryPath);

            this._testOutputHelper.WriteLine($"Root {entryPathInfo.FullName}...");

            var finalEdit = entryPathInfo
                .ToMarkdownEntry()
                .WithEdit(i =>
                {
                    string GetUpdatedTagExtract(string s, string e)
                    {
                        var jO = JObject.Parse(s);
                        jO["extract"] = e;
                        return jO.ToString();
                    }

                    var extract = GetExtractFromMarkdown(i, 255);
                    var tagToken = i.FrontMatter["tag"];
                    i.FrontMatter["tag"] = tagToken.HasValues ?
                        GetUpdatedTagExtract(tagToken.GetValue<string>(), extract) :
                        JObject.FromObject(new { extract }).ToString();
                })
                .ToFinalEdit();

            File.WriteAllText(entryPathInfo.FullName, $"{finalEdit}");
        }

        [Theory, InlineData("../../../../../presentation/entry")]
        public void ShouldEditBlogEntries(string entryRoot)
        {
            // arrange
            entryRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryRoot);

            var entryRootInfo = new DirectoryInfo(entryRoot);

            this._testOutputHelper.WriteLine($"Root {entryRootInfo.FullName}...");

            // act
            entryRootInfo
                .GetFiles("*.md", SearchOption.AllDirectories)
                .ForEachInEnumerable(ShouldEditOneBlogEntry);
        }

        [Theory, InlineData("../../../../../presentation/entry/2019/2019-01-15-dynamic-nested-reactive-forms-in-angular-and-other-tweeted-links.md")]
        public void ShouldEditBlogEntry(string entryPath)
        {
            // arrange
            entryPath = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryPath);

            var entryPathInfo = new FileInfo(entryPath);

            this._testOutputHelper.WriteLine($"Root {entryPathInfo.FullName}...");

            // act
            ShouldEditOneBlogEntry(entryPathInfo);
        }

        [Theory, InlineData(
            "../../../../../presentation-drafts",
            "studio status report: 2019-11")]
        public void ShouldGenerateEntry(string entryRoot, string title)
        {
            // arrange
            entryRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryRoot);

            // act
            var entry = new MarkdownEntry()
                .WithNew11tyFrontMatter(title, DateTime.Now, path: "./entry/", tag : null);

            // assert
            File.WriteAllText($"{entryRoot}/{entry.FrontMatter["clientId"]}.md", entry.ToFinalEdit());
        }

        [Theory, InlineData("../../../../../presentation/entry", "*.md")]
        public void ShouldValidateFrontMatter(string entryRoot, string filter)
        {
            // arrange
            entryRoot = FrameworkAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryRoot);
            this._testOutputHelper.WriteLine($"Root {entryRoot}...");

            var entryRootInfo = new DirectoryInfo(entryRoot);

            // act
            entryRootInfo
                .GetFiles(filter, SearchOption.AllDirectories)
                .ForEachInEnumerable(i =>
                {
                    this._testOutputHelper.WriteLine($"validating {i.Name}...");
                    ValidateFrontMatter(i);
                });
        }

        void ShouldEditOneBlogEntry(FileInfo entryInfo)
        {
            this._testOutputHelper.WriteLine($"Entry {entryInfo.Name}...");

            var finalEdit = entryInfo
                .ToMarkdownEntry()
                .WithEdit(i => // frontmatter and h1
                    {
                        var content = i.Content;

                        var inceptDate = i.FrontMatter.GetValue<DateTime>("inceptDate", throwException : false);
                        if (inceptDate == default(DateTime))
                        {
                            this._testOutputHelper.WriteLine($"WARNING {nameof(inceptDate)} is not found. Skipping edit.");
                            return;
                        }

                        // convert to standard frontmatter:
                        var title = i.FrontMatter.GetValue<string>("title");
                        var path = "./entry/";
                        var tag = JObject.FromObject(new { extract = i.FrontMatter.GetValue<string>("content") }).ToString();
                        i.WithNew11tyFrontMatter(title, inceptDate, path, tag);

                        var clientId = entryInfo.Name.Replace(".md", string.Empty);
                        i.FrontMatter["clientId"] = clientId;
                        i.FrontMatter["documentShortName"] = clientId;

                        i.Content = (new Regex(@"[\r\n]\# "))
                            .IsMatch(content) ? content : string.Concat(i.Content.Replace("## ", "# "), content);
                    })
                .WithEdit(i => // content line breaks
                    {
                        i.Content = Regex.Replace(i.Content, // ensure html block line breaks
                            @"[\r\n]*<\/*(blockquote|div|iframe)[^>]*>[\r\n]*", m =>
                            {
                                return string.Concat(
                                    MarkdownEntry.NewLine,
                                    MarkdownEntry.NewLine,
                                    m.Value.Trim(),
                                    MarkdownEntry.NewLine,
                                    MarkdownEntry.NewLine);
                            });
                        i.Content = Regex.Replace(i.Content, // html block [start] with only one new line
                            $@"([^\r\n<>]){MarkdownEntry.NewLine}<", m =>
                            {
                                var group = m.Groups[1];
                                return string.Concat(m.Value, MarkdownEntry.NewLine);
                            });
                        i.Content = Regex.Replace(i.Content, @"( +)[\r\n]+", m => // line of one or more spaces
                            {
                                var group = m.Groups[1];
                                return m.Value.Replace(group.Value, string.Empty);
                            });
                        i.Content = Regex.Replace(i.Content,
                            $@"{MarkdownEntry.NewLine}{MarkdownEntry.NewLine}({MarkdownEntry.NewLine}+)",
                            m => // too many line breaks
                            {
                                var group = m.Groups[1];
                                return m.Value.Replace(group.Value, string.Empty);
                            });
                    })
                .WithEdit(i => // paragraphs
                    {
                        var paragraphs = i.ToParagraphs();
                        this._testOutputHelper.WriteLine($"# of paragraphs: {paragraphs.Count()}");

                        i.Content = paragraphs
                            .Aggregate(
                                string.Empty,
                                (a, p) => string.Concat(
                                    a,
                                    $"{MarkdownEntry.NewLine}{MarkdownEntry.NewLine}",
                                    ProcessParagraph(p, this._testOutputHelper)
                                ));
                    })
                .ToFinalEdit();

            this._testOutputHelper.WriteLine($"Writing {entryInfo.FullName}...");
            File.WriteAllText(entryInfo.FullName, $"{finalEdit}");
        }

        ITestOutputHelper _testOutputHelper;
    }
}