using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TvmSdk.ClientGenerator.Extensions;

public static partial class SyntaxExtensions
{
    [GeneratedRegex("`(.+?)`")]
    private static partial Regex MarkdownQuoteRegex();

    [GeneratedRegex(@"\[(.*?)\]\((.*?)\)")]
    private static partial Regex MarkdownLinkRegex();
    
    private static readonly SyntaxToken XmlNewLine = XmlTextNewLine(Environment.NewLine);

    private static readonly XmlNodeSyntax XmlPara = XmlEmptyElement(XmlName("para"))
        .WithTrailingTrivia(CarriageReturnLineFeed);

    private static readonly XmlNodeSyntax[] CommentBlockSeparator =
    [
        XmlPara.WithoutTrailingTrivia(),
        XmlPara.WithoutTrailingTrivia(),
        XmlText(XmlNewLine)
    ];
    
    public static T AddSummary<T>(this T @this, params string?[] texts)
        where T : MemberDeclarationSyntax
    {
        return @this
            .AddComment(
                XmlSummaryElement,
                texts);
    }

    public static T AddRemarks<T>(this T @this, string? text)
        where T : MemberDeclarationSyntax
    {
        return @this.AddComment(XmlRemarksElement, [text]);
    }

    private static T AddComment<T>(
        this T @this,
        Func<XmlNodeSyntax[], XmlElementSyntax> getElement,
        params string?[] commentTexts)
        where T : MemberDeclarationSyntax
    {
        var texts = commentTexts
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x!)
            .ToArray();

        if (texts.Length == 0)
            return @this;

        var formattedComments = new List<XmlNodeSyntax>();
        for (var i = 0; i < texts.Length; i++)
        {
            var formattedComment = FormatComment(texts[i]);
            formattedComments.AddRange(formattedComment);

            // If there are more text and this is not last, then add separator
            if (texts.Length > 1 && i != texts.Length - 1)
                formattedComments.AddRange(CommentBlockSeparator);
        }

        return @this
            .WithLeadingTrivia(
                Trivia(
                    DocumentationComment(
                        getElement(
                            formattedComments
                                .Concat([XmlText(XmlNewLine)])
                                .ToArray()))),
                ElasticCarriageReturnLineFeed);
    }

    private static XmlNodeSyntax[] FormatComment(string commentText)
    {
        var sentences = commentText
            .Replace("\n", " ")
            .Split(". ", StringSplitOptions.RemoveEmptyEntries)
            .Where(comment => !string.IsNullOrWhiteSpace(comment))
            .ToArray();
        var sentenceNodes = new List<XmlNodeSyntax>();

        for (var i = 0; i < sentences.Length; i++)
        {
            var sentence = sentences[i];
            var sentenceText = sentence[..1].ToUpper() + sentence[1..];
            if (!sentenceText.EndsWith('.'))
                sentenceText += ". ";

            var formatted = FormatMarkdown(sentenceText.Trim());

            sentenceNodes.Add(XmlText(XmlNewLine));
            sentenceNodes.AddRange(formatted);

            if (sentences.Length > 1 && i != sentences.Length - 1)
                sentenceNodes.Add(XmlPara.WithoutTrailingTrivia());
        }

        return sentenceNodes.ToArray();
    }

    private static XmlNodeSyntax[] FormatMarkdown(string text)
    {
        var formatted = FormatQuotes(text);
        formatted = FormatLinks(formatted);

        return formatted;
    }

    private static XmlNodeSyntax[] FormatLinks(XmlNodeSyntax[] nodes)
    {
        var xmlNodes = new List<XmlNodeSyntax>();

        foreach (var xmlNode in nodes)
        {
            if (xmlNode is not XmlTextSyntax)
            {
                xmlNodes.Add(xmlNode);
                continue;
            }

            var text = xmlNode.ToFullString();
            var startIndex = 0;
            foreach (Match match in MarkdownLinkRegex().Matches(text))
            {
                var textBeforeLength = match.Index - startIndex - 1;
                if (textBeforeLength > 0)
                {
                    var textBefore = text.Substring(startIndex, textBeforeLength + 1);
                    if (textBefore.Length > 0)
                        xmlNodes.Add(XmlText(XmlTextLiteral(textBefore)));
                }

                startIndex = match.Index + match.Value.Length;

                var linkValue = match.Groups[2].Value;
                var textValue = match.Groups[1].Value;
                var link = XmlLink(linkValue, textValue);
                xmlNodes.Add(link);
            }

            if (startIndex <= text.Length)
            {
                var ending = text[startIndex..];
                xmlNodes.Add(XmlText(XmlTextLiteral(ending)));
            }
        }

        return xmlNodes.ToArray();
    }

    private static XmlNodeSyntax[] FormatQuotes(string text)
    {
        var xmlNodes = new List<XmlNodeSyntax>();
        var startIndex = 0;
        foreach (Match match in MarkdownQuoteRegex().Matches(text))
        {
            var value = match.Groups[1].Value;
            var textBeforeLength = match.Index - startIndex - 1;
            if (textBeforeLength > 0)
            {
                var textBefore = text.Substring(startIndex, textBeforeLength + 1);
                if (textBefore.Length > 0)
                    xmlNodes.Add(XmlText(XmlTextLiteral(textBefore)));
            }

            startIndex = match.Index + match.Value.Length;
            XmlNodeSyntax xmlElement = value switch
            {
                // "true" or "false" => XmlSeeLangwordElement(value),
                _ => XmlElement(
                    "c",
                    List<XmlNodeSyntax>(new[]
                    {
                        XmlText(XmlTextLiteral(value))
                    }))
            };
            xmlNodes.Add(xmlElement);
        }

        if (startIndex <= text.Length)
        {
            var ending = text[startIndex..];
            xmlNodes.Add(XmlText(XmlTextLiteral(ending)));
        }

        return xmlNodes.ToArray();
    }

    private static XmlNodeSyntax XmlLink(string link, string text)
    {
        return XmlElement(
            XmlElementStartTag(XmlName("a"))
                .AddAttributes([
                    XmlTextAttribute("href")
                        .WithTextTokens(TokenList(Identifier(link)))
                ]),
            new SyntaxList<XmlNodeSyntax>(XmlText(XmlTextLiteral(text))),
            XmlElementEndTag(XmlName("a")));
    }

    private static XmlEmptyElementSyntax XmlSeeLangwordElement(string value)
    {
        return XmlEmptyElement("see")
            .AddAttributes([
                XmlTextAttribute("langword")
                    .WithTextTokens(TokenList(Identifier(value)))
            ]);
    }
}