using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Html2Markdown.Replacement;
using Html2Markdown.Scheme;
using HtmlAgilityPack;

namespace Html2MarkdownHacks
{

    public class SonghayMarkdownScheme : IScheme
    {
        public SonghayMarkdownScheme() { }

        public SonghayMarkdownScheme(Func<IReplacerIdentifier, bool> replacerPredicate)
        {
            this._replacerPredicate = replacerPredicate;
        }

        public IList<IReplacer> Replacers()
        {
            return (this._replacerPredicate == null) ?
                _replacers
                .OfType<IReplacer>()
                .ToList()
                :
                _replacers.Where(this._replacerPredicate)
                .OfType<IReplacer>()
                .ToList();
        }

        private Func<IReplacerIdentifier, bool> _replacerPredicate;

        private readonly IList<IReplacerIdentifier> _replacers = new List<IReplacerIdentifier>
        {
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.strong,
            HtmlGroup = HtmlGroups.Inline,
            Pattern = @"</?(strong|b)>",
            Replacement = @"**"
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.em,
            HtmlGroup = HtmlGroups.Inline,
            Pattern = @"</?(em|i)>",
            Replacement = @"*"
            },
            new SonghayPatternReplacer
            {
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"</h[1-6]>",
            Replacement = Environment.NewLine + Environment.NewLine
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.h1,
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"<h1[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "# "
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.h2,
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"<h2[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "## "
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.h3,
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"<h3[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "### "
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.h4,
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"<h4[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "#### "
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.h5,
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"<h5[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "##### "
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.h6,
            HtmlGroup = HtmlGroups.BlockHeader,
            Pattern = @"<h6[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "###### "
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.hr,
            HtmlGroup = HtmlGroups.Block,
            Pattern = @"<hr[^>]*>",
            Replacement = Environment.NewLine + Environment.NewLine + "* * *" + Environment.NewLine
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.unspecified,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"<!DOCTYPE[^>]*>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.html,
            HtmlGroup = HtmlGroups.Block,
            Pattern = @"</?html[^>]*>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.head,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"</?head[^>]*>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.body,
            HtmlGroup = HtmlGroups.Block,
            Pattern = @"</?body[^>]*>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.title,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"<title[^>]*>.*?</title>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.meta,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"<meta[^>]*>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.link,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"<link[^>]*>",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.comment,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"<!--[^-]+-->",
            Replacement = string.Empty
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.unspecified,
            HtmlGroup = HtmlGroups.Infrastructure,
            Pattern = @"</?script[^>]*>",
            Replacement = string.Empty
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.blockquote,
            HtmlGroup = HtmlGroups.Block,
            CustomAction = HtmlParser.ReplaceBlockquote
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.img,
            HtmlGroup = HtmlGroups.Inline,
            CustomAction = HtmlParser.ReplaceImg
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.unspecified,
            HtmlGroup = HtmlGroups.BlockList,
            CustomAction = HtmlParser.ReplaceLists
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.a,
            HtmlGroup = HtmlGroups.Inline,
            CustomAction = HtmlParser.ReplaceAnchor
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.code,
            HtmlGroup = HtmlGroups.Inline,
            CustomAction = HtmlParser.ReplaceCode
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.pre,
            HtmlGroup = HtmlGroups.Block,
            CustomAction = HtmlParser.ReplacePre
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.p,
            HtmlGroup = HtmlGroups.Block,
            CustomAction = HtmlParser.ReplaceParagraph
            },
            new SonghayPatternReplacer
            {
            HtmlElement = HtmlElements.br,
            HtmlGroup = HtmlGroups.Inline,
            Pattern = @"<br[^>]*>",
            Replacement = @"  " + Environment.NewLine
            },
            new SonghayCustomReplacer
            {
            HtmlElement = HtmlElements.unspecified,
            HtmlGroup = HtmlGroups.InlineEntities,
            CustomAction = HtmlParser.ReplaceEntities
            }
        };
    }

    // why is this internal? <https://github.com/baynezy/Html2Markdown/blob/master/src/Html2Markdown/Replacement/PatternReplacer.cs>
    public class SonghayPatternReplacer : IReplacer, IReplacerIdentifier
    {
        public HtmlElements HtmlElement { get; set; }

        public HtmlGroups HtmlGroup { get; set; }

        public string Pattern { get; set; }

        public string Replacement { get; set; }

        public string Replace(string html)
        {
            var regex = new Regex(Pattern);

            return regex.Replace(html, Replacement);
        }
    }

    // why is this internal? <https://github.com/baynezy/Html2Markdown/blob/master/src/Html2Markdown/Replacement/CustomReplacer.cs>
    public class SonghayCustomReplacer : IReplacer, IReplacerIdentifier
    {
        public string Replace(string html)
        {
            return CustomAction.Invoke(html);
        }

        public Func<string, string> CustomAction { get; set; }

        public HtmlElements HtmlElement { get; set; }

        public HtmlGroups HtmlGroup { get; set; }
    }

    // why is this internal? <https://github.com/baynezy/Html2Markdown/blob/master/src/Html2Markdown/Replacement/HtmlParser.cs>
    public static class HtmlParser
    {
        private static readonly Regex NoChildren = new Regex(@"<(ul|ol)\b[^>]*>(?:(?!<ul|<ol)[\s\S])*?<\/\1>");

        internal static string ReplaceLists(string html)
        {
            var finalHtml = html;
            while (HasNoChildLists(finalHtml))
            {
                var listToReplace = NoChildren.Match(finalHtml).Value;
                var formattedList = ReplaceList(listToReplace);
                finalHtml = finalHtml.Replace(listToReplace, formattedList);
            }

            return finalHtml;
        }

        private static string ReplaceList(string html)
        {
            var list = Regex.Match(html, @"<(ul|ol)\b[^>]*>([\s\S]*?)<\/\1>");
            var listType = list.Groups[1].Value;
            var listItems = list.Groups[2].Value.Split(new [] { "</li>" }, StringSplitOptions.None);

            var counter = 0;
            var markdownList = new List<string>();
            listItems.ToList().ForEach(listItem =>
            {
                var listPrefix = (listType.Equals("ol")) ? string.Format("{0}.  ", ++counter) : "*   ";
                var finalList = Regex.Replace(listItem, @"<li[^>]*>", string.Empty);

                if (finalList.Trim().Length == 0)
                {
                    return;
                }

                finalList = Regex.Replace(finalList, @"^\s+", string.Empty);
                finalList = Regex.Replace(finalList, @"\n{2}", string.Format("{0}{1}    ", Environment.NewLine, Environment.NewLine));
                // indent nested lists
                finalList = Regex.Replace(finalList, @"\n([ ]*)+(\*|\d+\.)", string.Format("{0}$1    $2", "\n"));
                markdownList.Add(string.Format("{0}{1}", listPrefix, finalList));
            });

            return Environment.NewLine + Environment.NewLine + markdownList.Aggregate((current, item) => current + Environment.NewLine + item);
        }

        private static bool HasNoChildLists(string html)
        {
            return NoChildren.Match(html).Success;
        }

        internal static string ReplacePre(string html)
        {
            var doc = GetHtmlDocument(html);
            var nodes = doc.DocumentNode.SelectNodes("//pre");
            if (nodes == null)
            {
                return html;
            }

            nodes.ToList().ForEach(node =>
            {
                var tagContents = node.InnerHtml;
                var markdown = ConvertPre(tagContents);

                ReplaceNode(node, markdown);
            });

            return doc.DocumentNode.OuterHtml;
        }

        private static string ConvertPre(string html)
        {
            var tag = TabsToSpaces(html);
            tag = IndentNewLines(tag);
            return Environment.NewLine + Environment.NewLine + tag + Environment.NewLine;
        }

        private static string IndentNewLines(string tag)
        {
            return tag.Replace(Environment.NewLine, Environment.NewLine + "    ");
        }

        private static string TabsToSpaces(string tag)
        {
            return tag.Replace("\t", "    ");
        }

        internal static string ReplaceImg(string html)
        {
            var doc = GetHtmlDocument(html);
            var nodes = doc.DocumentNode.SelectNodes("//img");
            if (nodes == null)
            {
                return html;
            }

            nodes.ToList().ForEach(node =>
            {

                var src = node.Attributes.GetAttributeOrEmpty("src");
                var alt = node.Attributes.GetAttributeOrEmpty("alt");
                var title = node.Attributes.GetAttributeOrEmpty("title");

                var markdown = string.Format(@"![{0}]({1}{2})", alt, src, (title.Length > 0) ? string.Format(" \"{0}\"", title) : "");

                ReplaceNode(node, markdown);
            });

            return doc.DocumentNode.OuterHtml;
        }

        public static string ReplaceAnchor(string html)
        {
            var doc = GetHtmlDocument(html);
            var nodes = doc.DocumentNode.SelectNodes("//a");
            if (nodes == null)
            {
                return html;
            }

            nodes.ToList().ForEach(node =>
            {
                var linkText = node.InnerHtml;
                var href = node.Attributes.GetAttributeOrEmpty("href");
                var title = node.Attributes.GetAttributeOrEmpty("title");

                var markdown = string.Empty;

                if (!IsEmptyLink(linkText, href))
                {
                    markdown = string.Format(@"[{0}]({1}{2})", linkText, href,
                        (title.Length > 0) ? string.Format(" \"{0}\"", title) : "");
                }

                ReplaceNode(node, markdown);
            });

            return doc.DocumentNode.OuterHtml;
        }

        public static string ReplaceCode(string html)
        {
            var finalHtml = html;
            var singleLineCodeBlocks = new Regex(@"<code>([^\n]*?)</code>").Matches(finalHtml);
            singleLineCodeBlocks.Cast<Match>().ToList().ForEach(block =>
            {
                var code = block.Value;
                var content = GetCodeContent(code);
                finalHtml = finalHtml.Replace(code, string.Format("`{0}`", content));
            });

            var multiLineCodeBlocks = new Regex(@"<code>([^>]*?)</code>").Matches(finalHtml);
            multiLineCodeBlocks.Cast<Match>().ToList().ForEach(block =>
            {
                var code = block.Value;
                var content = GetCodeContent(code);
                content = IndentLines(content).TrimEnd() + Environment.NewLine + Environment.NewLine;
                finalHtml = finalHtml.Replace(code, string.Format("{0}    {1}", Environment.NewLine, TabsToSpaces(content)));
            });

            return finalHtml;
        }

        public static string ReplaceBlockquote(string html)
        {
            var finalHtml = html;
            var doc = GetHtmlDocument(finalHtml);
            var nodes = doc.DocumentNode.SelectNodes("//blockquote");
            if (nodes == null)
            {
                return finalHtml;
            }

            nodes.ToList().ForEach(node =>
            {
                var quote = node.InnerHtml;
                var lines = quote.TrimStart().Split(new [] { Environment.NewLine }, StringSplitOptions.None);
                var markdown = string.Empty;

                lines.ToList().ForEach(line =>
                {
                    markdown += string.Format("> {0}{1}", line.TrimEnd(), Environment.NewLine);
                });

                markdown = Regex.Replace(markdown, @"(>\s\r\n)+$", "");

                markdown = Environment.NewLine + Environment.NewLine + markdown + Environment.NewLine + Environment.NewLine;

                ReplaceNode(node, markdown);
            });

            return doc.DocumentNode.OuterHtml;
        }

        public static string ReplaceEntities(string html)
        {
            return WebUtility.HtmlDecode(html);
        }

        public static string ReplaceParagraph(string html)
        {
            var doc = GetHtmlDocument(html);
            var nodes = doc.DocumentNode.SelectNodes("//p");
            if (nodes == null)
            {
                return html;
            }

            nodes.ToList().ForEach(node =>
            {
                var text = node.InnerHtml;
                var markdown = Regex.Replace(text, @"\s+", " ");
                markdown = markdown.Replace(Environment.NewLine, " ");
                markdown = Environment.NewLine + Environment.NewLine + markdown + Environment.NewLine;
                ReplaceNode(node, markdown);
            });

            return doc.DocumentNode.OuterHtml;
        }

        private static bool IsEmptyLink(string linkText, string href)
        {
            var length = linkText.Length + href.Length;
            return length == 0;
        }

        private static HtmlDocument GetHtmlDocument(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }

        private static void ReplaceNode(HtmlNode node, string markdown)
        {
            var markdownNode = HtmlNode.CreateNode(markdown);
            if (string.IsNullOrEmpty(markdown))
            {
                node.ParentNode.RemoveChild(node);
            }
            else
            {
                node.ParentNode.ReplaceChild(markdownNode.ParentNode, node);
            }

        }

        private static string IndentLines(string content)
        {
            var lines = content.Split(new [] { Environment.NewLine }, StringSplitOptions.None);

            return lines.Aggregate("", (current, line) => current + IndentLine(line));
        }

        private static string IndentLine(string line)
        {
            if (line.Trim().Equals(string.Empty))
            {
                return "";
            }
            return line + Environment.NewLine + "    ";
        }

        private static string GetCodeContent(string code)
        {
            var match = Regex.Match(code, @"<code[^>]*?>([^<]*?)</code>");
            var groups = match.Groups;
            return groups[1].Value;
        }
    }

    // <https://github.com/baynezy/Html2Markdown/blob/master/src/Html2Markdown/HtmlAgilityPackExtensions.cs>
    public static class HtmlAgilityPackExtensions
    {
        public static string GetAttributeOrEmpty(this HtmlAttributeCollection collection, string attributeName)
        {
            return (collection[attributeName] == null) ? string.Empty : collection[attributeName].Value;
        }
    }

    public interface IReplacerIdentifier
    {
        HtmlElements HtmlElement { get; set; }
        HtmlGroups HtmlGroup { get; set; }
    }

    public enum HtmlGroups
    {
        Inline,
        InlineEntities,
        Block,
        BlockHeader,
        BlockList,
        Infrastructure
    }

    public enum HtmlElements
    {
        unspecified,
        comment,
        a,
        b,
        strong,
        i,
        em,
        img,
        br,
        code,
        ol,
        ul,
        blockquote,
        pre,
        p,
        h1,
        h2,
        h3,
        h4,
        h5,
        h6,
        hr,
        body,
        link,
        meta,
        title,
        head,
        html
    }

}