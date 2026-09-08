using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace Rehab.EndPoint.Web.Helpers;

public static class TextHighlighter
{
    public static MarkupString Highlight(string? text, string? term)
    {
        if (string.IsNullOrEmpty(text))
            return new MarkupString(string.Empty);

        // Security: encode raw text first, so nothing except our own <mark> tags is ever raw HTML
        var encoded = WebUtility.HtmlEncode(text);

        if (string.IsNullOrWhiteSpace(term))
            return new MarkupString(encoded);

        // Support multi-word search: highlight each word separately
        var words = term.Trim()
                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                         .Select(w => Regex.Escape(WebUtility.HtmlEncode(w)))
                         .ToArray();

        if (words.Length == 0)
            return new MarkupString(encoded);

        var pattern = string.Join("|", words);

        var highlighted = Regex.Replace(
            encoded,
            pattern,
            match => $"<mark>{match.Value}</mark>",
            RegexOptions.IgnoreCase);

        return new MarkupString(highlighted);
    }
}