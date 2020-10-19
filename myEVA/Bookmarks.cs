using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using HtmlAgilityPack;  // joplin -> nuget

namespace myEVA
{
    class Bookmarks
    {
        private string url { get; set; }
        private string htmlstring { get; set; }
        private string titel { get; set; }
        private string beschreibung { get; set; }
        private string schlagwort { get; set; }
        private string url_image { get; set; }

        public Bookmarks(string _url)
        {
            url = _url;
        }

        public bool Url_Build()
        {
            try
            {
                var webcli = new WebClient();
                htmlstring = webcli.DownloadString(url);
                Build_Bookmarks();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void Build_Bookmarks()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlstring);
            var list = doc.DocumentNode.SelectNodes("//meta");
            IEnumerable<HtmlNode> metas = doc.DocumentNode.Descendants("meta").Where(x => x.Attributes.Contains("property"));

            
            titel = titel ?? Regex.Match(htmlstring, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            url_image = url_image ?? doc.DocumentNode.SelectSingleNode("//img/@src").InnerText;
        }
        
        public string FindAttr(IEnumerable<HtmlNode> metas, string strMetaAttr, string strMetaValue)
        {
            string str = null;
            foreach (var meta in metas)
            {
                if (meta.Attributes[strMetaAttr].Value == strMetaValue)
                {
                    str = meta.Attributes["content"].Value;
                }
            }

            return str;
        }
    }
}
