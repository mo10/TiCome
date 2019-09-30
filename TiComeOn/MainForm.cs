
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
namespace TiComeOn
{
    public partial class MainForm : Form
    {
        private GithubSearch search;
        private int currentPage;
        public MainForm()
        {
            InitializeComponent();
            search = new GithubSearch();
            currentPage = 1;
        }
        public void SetCookie(string cookie)
        {
            search.Cookie = cookie;
        }
        public string GetCookie()
        {
            return search.Cookie;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "加载中";
            try
            {
                List<string> list = await search.AsyncLoadPage(currentPage);
                currentPage++;
                foreach(string s in list)
                {
                    string jsonText = await search.AsyncGetUrl(s);
                    var definition = new { configs = new SSRConfig[] {} };
                    var configs = JsonConvert.DeserializeAnonymousType(jsonText, definition);
                    if(configs !=null)
                    {
                        nodeList.BeginUpdate();
                        foreach (var config in configs.configs)
                        {
                            ListViewItem item = new ListViewItem(config.server);
                            item.SubItems.Add(config.server_port);
                            item.SubItems.Add(config.server_udp_port);
                            item.SubItems.Add(config.password);
                            item.SubItems.Add(config.method);
                            item.SubItems.Add(config.obfs);
                            item.SubItems.Add(config.obfsparam);
                            item.SubItems.Add(config.remarks);
                            item.SubItems.Add(config.protocol);
                            item.SubItems.Add(config.protocolparam);

                            nodeList.Items.Add(item);
                        }
                        nodeList.EndUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("No Cookie"))
                {
                    MessageBox.Show("没有饼干，请填写饼干");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            button1.Enabled = true;
            button1.Text = "再来点!";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditCookieForm editCookie = new EditCookieForm(this);
            editCookie.ShowDialog();

        }
    }
}
