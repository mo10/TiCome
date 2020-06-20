using Flurl.Http;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TiCome
{
    class GithubSearcher
    {
        public string userSession;
        public int pageIdx;

        // 超时时间
        private const int timeout = 10;
        public GithubSearcher()
        {
            userSession = string.Empty;
            pageIdx = 1;
        }
        /// <summary>
        /// 获取一页gui-config.json链接
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> NextPageAsync()
        {
            List<string> configFileUrls = new List<string>();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            using (var cli = new FlurlClient().EnableCookies())
            {
                cli.Cookies.Add("user_session", new System.Net.Cookie("user_session", userSession));
                cli.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");

                // 请求第 pageIdx 页结果
                var resultText = await cli.Request($"https://github.com/search?q=filename%3Agui-config.json&s=indexed&type=Code&p={pageIdx}").WithTimeout(timeout).GetAsync().ReceiveString();

                // 解析 DOM
                var resultDoc = new HtmlAgilityPack.HtmlDocument();
                resultDoc.LoadHtml(resultText);

                HtmlNodeCollection htmlNodes = resultDoc.DocumentNode.SelectNodes("//*[@id=\"code_search_results\"]/div/div/div/p/a/@href");
                if (htmlNodes == null)
                {
                    return null;
                }
                if (htmlNodes.Count > 0)
                {
                    foreach (HtmlNode node in htmlNodes)
                    {
                        if (Path.GetFileName(node.Attributes["href"].Value).Equals("gui-config.json"))
                            configFileUrls.Add("https://raw.githubusercontent.com" + node.Attributes["href"].Value.Replace("/blob/", "/"));
                    }
                }
            }
            pageIdx++;
            return configFileUrls;
        }
    }
}
