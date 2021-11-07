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
            return body.InnerText;
        }
        public static string[] GetMetaKeywords(this HtmlDocument document)
        {
            var keywordsContent = string.Empty;
            //HtmlNode metaNode = document.DocumentNode.SelectSingleNode("//meta[contains(@name, 'keyword')]");
            HtmlNode metaNode = document.DocumentNode.SelectSingleNode("/html/head/meta[@name='description' OR contains(@name,'keyword')]");
            if (metaNode != null)
            {
                keywordsContent = metaNode.GetAttributeValue("content", string.Empty);
            }

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
                if (!anchor.Contains(domain) && !InvalidChars.Any(anchor.Contains) && anchor.IndexOf('/') != 0 && anchor.IndexOf('#') != 0)
                {
                    externalLinksCount.IncrementValueBy1(anchor);
                }
            }

            return externalLinksCount;
        }


    }
}
