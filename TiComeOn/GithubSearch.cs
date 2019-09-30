using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TiComeOn
{
    class GithubSearch
    {
        public string Cookie;

        public Task<List<string>> AsyncLoadPage(int page)
        {
            return Task.Run(() => LoadPage(page));

        }
        public Task<int> AsyncGetPages()
        {
            return Task.Run(() => GetPages());

        }
        public Task<string> AsyncGetUrl(string url)
        {
            return Task.Run(() => GetUrl(url));

        }
        public GithubSearch()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Cookie = "";// 预设Cookie
        }

        public List<string> LoadPage(int page)
        {
            List<string> vs = new List<string>();
            string url = "https://github.com/search?p=" + page + "&q=filename%3Agui-config.json&s=indexed&type=Code";

            var doc = GetHtml(url);

            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//*[@id=\"code_search_results\"]/div/div/div/p/a/@href");
            if (htmlNodes.Count > 0)
            {
                foreach (HtmlNode node in htmlNodes)
                {
                    if( Path.GetFileName(node.Attributes["href"].Value).Equals("gui-config.json"))
                        vs.Add("https://raw.githubusercontent.com" + node.Attributes["href"].Value.Replace("/blob/","/"));
                }
            }
            return vs;
        }

        public  int GetPages()
        {
            var doc = GetHtml("https://github.com/search?p=page&q=filename%3Agui-config.json&s=indexed&type=Code");
            return int.Parse(doc.DocumentNode.SelectSingleNode("//*[@data-total-pages]").Attributes["data-total-pages"].Value);
        }

        private HtmlAgilityPack.HtmlDocument GetHtml(string url)
        {
            if (Cookie.Length == 0)
            {
                throw new Exception("No Cookie");
            }

            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
            client.Headers.Add("Cookie", Cookie);
            
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            //加载html
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(s);
            return doc;
        }
        public string GetUrl(string url)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            return reader.ReadToEnd();
        }
    }
}
