using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Mash.HelperMethods.NET.ExtensionMethods
{
    public static class HtmlDocumentExtension
    {
        private static readonly IEnumerable<char> InvalidChars = new List<char> { '@', '(', ')' };
        private static char[] _separators = new char[] { ' ', ',', ':', ';', '\t', '?', '!', '"' };


        public static bool IsValid(this HtmlDocument document)
        {
            bool isValid = document.DocumentNode.SelectSingleNode("html/head") != null
                           && document.DocumentNode.SelectSingleNode("html/body") != null;

            return isValid;

        }

        public static void SanitizeContent(this HtmlDocument document)
        {
            document.DocumentNode.Descendants()
                .Where(n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Comment)
                .ToList()
                .ForEach(n => n.Remove());
        }
        public static string GetBodyText(this HtmlDocument document)
        {
            var body = document.DocumentNode.SelectSingleNode("//body");
            return body.InnerText.RemoveRepeatingWhiteSpace();
        }

        private static string RemoveRepeatingWhiteSpace(this string text)
        {
            StringBuilder sb = new StringBuilder();

            bool lastCharWhiteSpace = false;
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                bool isWhiteSpace = ch == ' ' || ch == '\t' || ch == '\n' || ch == '\r';
                if (!isWhiteSpace || !lastCharWhiteSpace)
                {
                    sb.Append(isWhiteSpace?' ':ch);
                }

                lastCharWhiteSpace = isWhiteSpace;

            }

            return sb.ToString();
        }

        public static string[] GetMetaKeywords(this HtmlDocument document)
        {
            var keywordsContent = string.Empty;
            var sb = new StringBuilder();

            //HtmlNode metaNode = document.DocumentNode.SelectSingleNode("//meta[contains(@name, 'keyword')]");
            var metaNodes = document.DocumentNode.SelectNodes("//meta/@content");
            //var metaNodes = document.DocumentNode.SelectNodes("/html/head/meta[contains(@name,\"keyword\")|contains(@name,\"description\") ]");
            if (metaNodes != null)
            {
                foreach (var metaNode in metaNodes)
                {
                    sb.Append(metaNode.GetAttributeValue("content", string.Empty));
                }

            }

            keywordsContent = sb.ToString();
            if (!string.IsNullOrEmpty(keywordsContent))
            {
                return keywordsContent.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            }

            return new string[] { };
        }

        public static Dictionary<string, int> GetExternalLinksCountFoundInHtml(this HtmlDocument document, Uri url)
        {
            Dictionary<string, int> externalLinksCount = new Dictionary<string, int>();
            var domain = url.Host;
            var body = document.DocumentNode.SelectSingleNode("//body");
            var links = body.SelectNodes("//a").Select(h => h.GetAttributeValue("href", "#"));
            foreach (var anchor in links)
            {
                if (!anchor.Contains(domain) && !InvalidChars.Any(anchor.Contains) && anchor.IndexOf('/') != 0 && anchor.IndexOf('#') != 0 && ValidDomainName(anchor))
                {

                    externalLinksCount.IncrementValueBy1(anchor);
                }
            }

            return externalLinksCount;
        }

        private static bool ValidDomainName(string url)
        {
            if (url.StartsWith("http") || url.StartsWith("ftp") || url.StartsWith("file"))
            {
                return true;
            }
            for (int i = 0; i < url.Length; i++)
            {
                if (url[i] == '.') return true;
                if (url[i] == '/')
                {
                    return false;
                }
            }

            return false;

        }
    }
}
