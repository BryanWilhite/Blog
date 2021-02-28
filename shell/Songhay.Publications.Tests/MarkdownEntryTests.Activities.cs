using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Songhay.Extensions;
using Songhay.Publications.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Songhay.Publications.Tests
{
    public partial class MarkdownEntryTests
    {
        internal static void ExpandUris(string entryPath, string collapsedHost, ITestOutputHelper testOutputHelper)
        {
            if (!File.Exists(entryPath))
                throw new FileNotFoundException($"The expected file, `{entryPath},` is not here.");

            var entryInfo = new FileInfo(entryPath);

            testOutputHelper.WriteLine($"{nameof(MarkdownEntryTests)}: expanding `{collapsedHost}` URIs in `{entryInfo.Name}`...");

            var entry = entryInfo.ToMarkdownEntry();
            var matches = Regex.Matches(entry.Content, $@"https*://{collapsedHost}[^ \]\)]+");
            var uris = matches.OfType<Match>().Select(i => new Uri(i.Value)).Distinct().ToArray();
            async Task<KeyValuePair<Uri, Uri> ?> ExpandUriPairAsync(Uri expandableUri)
            {
                KeyValuePair<Uri, Uri> ? nullable = null;
                try
                {
                    testOutputHelper.WriteLine($"{nameof(MarkdownEntryTests)}: expanding `{expandableUri.OriginalString}`...");
                    nullable = await expandableUri.ToExpandedUriPairAsync();
                    testOutputHelper.WriteLine($"{nameof(MarkdownEntryTests)}: expanded `{nullable.Value.Key.OriginalString}` to `{nullable.Value.Value.OriginalString}`.");
                }
                catch (Exception ex)
                {
                    testOutputHelper.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                    testOutputHelper.WriteLine(ex.StackTrace);
                }

                return nullable;
            }

            var tasks = uris.Select(ExpandUriPairAsync).Where(i => i.Result.HasValue).ToArray();

            Task.WaitAll(tasks);

            var findChangeSet = tasks.Select(i => i.Result.Value).ToDictionary(k => k.Key, v => v.Value);

            foreach (var pair in findChangeSet)
                entry.Content = entry.Content.Replace(pair.Key.OriginalString, pair.Value.OriginalString);

            testOutputHelper.WriteLine($"{nameof(MarkdownEntryTests)}: saving `{entryInfo.Name}`...");
            File.WriteAllText(entryInfo.FullName, entry.ToFinalEdit());
        }

        [Theory, InlineData(
            "../../../../../presentation/entry/2019/2019-11-21-why-i-stopped-using-ngrx-and-other-tweeted-links.md")]
        public void ShouldAddEntryExtract(string entryPath)
        {
            entryPath = ProgramAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryPath);

            var entryPathInfo = new FileInfo(entryPath);

            this._testOutputHelper.WriteLine($"Root {entryPathInfo.FullName}...");

            var finalEdit = entryPathInfo
                .ToMarkdownEntry()
                .With11tyExtract(255)
                .ToFinalEdit();

            File.WriteAllText(entryPathInfo.FullName, $"{finalEdit}");
        }

        [Theory, InlineData(
            "../../../../../presentation/entry",
            "t.co")]
        public void ShouldExpandUris(string entryRoot, string collapsedHost)
        {
            entryRoot = ProgramAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryRoot);
            var entryRootInfo = new DirectoryInfo(entryRoot);

            this._testOutputHelper.WriteLine($"Root {entryRootInfo.FullName}...");

            entryRootInfo
                .GetFiles("*.md", SearchOption.AllDirectories)
                .ForEachInEnumerable(fileInfo => ExpandUris(fileInfo.FullName, collapsedHost, this._testOutputHelper));
        }

        [Theory, InlineData(
            "../../../../../presentation-drafts",
            "Flippant Remarks about Responsive Images")]
        public void ShouldGenerateEntry(string entryDraftRoot, string title)
        {
            // arrange
            entryDraftRoot = ProgramAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryDraftRoot);

            // act
            var entry = MarkdownEntryUtility.GenerateEntryFor11ty(entryDraftRoot, title);

            // assert
            Assert.NotNull(entry);
        }

        [Theory, InlineData(
            "../../../../../presentation-drafts",
            "../../../../../presentation/entry",
            "2019-12-23-angularjs-and-jest-and-other-tweeted-links.md")]
        public void ShouldPublishEntry(string entryRoot, string presentationRoot, string fileName)
        {
            // arrange
            entryRoot = ProgramAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, entryRoot);
            presentationRoot = ProgramAssemblyUtility.GetPathFromAssembly(this.GetType().Assembly, presentationRoot);
            presentationRoot = ProgramFileUtility.GetCombinedPath(presentationRoot, DateTime.Now.Year.ToString());

            // act
            var path = MarkdownEntryUtility.PublishEntryFor11ty(entryRoot, presentationRoot, fileName);

            // assert
            Assert.True(File.Exists(path));
        }
    }
}