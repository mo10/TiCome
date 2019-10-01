
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TiCome
{
    public partial class MainForm : Form
    {
        private GithubSearch search;
        private int currentPage;

        private GuiConfig loadedConfig;
        
        public MainForm()
        {
            InitializeComponent();
            search = new GithubSearch();
            loadedConfig = new GuiConfig();
            loadedConfig.configs = new List<SSRConfig>();
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
            button1.Text = "加载中...";
            try
            {
                List<string> list = await search.AsyncLoadPage(currentPage);
                currentPage++;
                foreach(string s in list)
                {
                    string jsonText = await search.AsyncGetUrl(s);
                   

                    var configs = JsonConvert.DeserializeObject<GuiConfig>(jsonText);
                    if (configs != null && configs.configs != null && configs.configs.Count > 0)
                    {
                        nodeList.BeginUpdate();
                        foreach (var config in configs.configs)
                        {
                            ListViewItem item = new ListViewItem(config.server);
                            item.SubItems.Add(config.server_port.ToString());
                            item.SubItems.Add(config.server_udp_port.ToString());
                            item.SubItems.Add(config.password);
                            item.SubItems.Add(config.method);
                            item.SubItems.Add(config.obfs);
                            item.SubItems.Add(config.obfsparam);
                            item.SubItems.Add(config.remarks);
                            item.SubItems.Add(config.protocol);
                            item.SubItems.Add(config.protocolparam);
                            item.SubItems.Add("-");
                            item.Tag = config;

                            nodeList.Items.Add(item);

                            loadedConfig.configs.Add(config);
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
            nodeList.EndUpdate();
            button1.Enabled = true;
            button1.Text = "梯来!";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditCookieForm editCookie = new EditCookieForm(this);
            editCookie.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Config|*.json";
            saveFileDialog1.Title = "Save node config";
            saveFileDialog1.FileName = "gui-config.json";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter file = File.CreateText(saveFileDialog1.FileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, loadedConfig);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EditCookieForm editCookie = new EditCookieForm(this);
            editCookie.ShowDialog();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = false;
            foreach(ListViewItem item in nodeList.Items)
            {
                SSRConfig config = (SSRConfig)item.Tag;
                var pingItem = item.SubItems[item.SubItems.Count - 1];
                pingItem.Text = "测试中";
                try
                {
                    var result = await AsyncSend(config.server);
                    if (result.Status != IPStatus.Success)
                    {
                        pingItem.Text = "失败";
                    }
                    else
                    {
                        pingItem.Text = result.RoundtripTime.ToString();
                    }
                }catch(Exception ex)
                {
                    pingItem.Text = "错误";
                }
            }
            button1.Enabled = true;
            button4.Enabled = true;
        }
        private Task<PingReply> AsyncSend(string address)
        {
            var ping = new System.Net.NetworkInformation.Ping();
            return Task.Run(() => ping.Send(address));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GuiConfig guiConfig = new GuiConfig();
            guiConfig.configs = new List<SSRConfig>();

            foreach(ListViewItem item in nodeList.Items)
            {
                SSRConfig config = (SSRConfig)item.Tag;
                var pingItem = item.SubItems[item.SubItems.Count - 1];

                try
                {
                    int ping = int.Parse(pingItem.Text);
                    guiConfig.configs.Add(config);
                }
                catch(Exception ex)
                {
                    // do nothing
                }
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Config|*.json";
            saveFileDialog1.Title = "Save node config";
            saveFileDialog1.FileName = "gui-config.json";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter file = File.CreateText(saveFileDialog1.FileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, guiConfig);
                }
            }
        }
    }
}
