using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiCome.Data;

namespace TiCome
{
    public partial class MainForm : Form
    {
        private GithubSearch searcher;
        private int pageIndex;

        public MainForm()
        {
            InitializeComponent();
            searcher = new GithubSearch();
            pageIndex = 0;
        }

        public void SetCookie(string cookie)
        {
            searcher.SetCookie(cookie);
        }
        public string GetCookie()
        {
            return searcher.Cookie;
        }

        private ListViewItem ToListViewItem(NodeConfig node)
        {
            ListViewItem item = new ListViewItem(node.server);
            item.SubItems.Add(node.server_port.ToString());
            item.SubItems.Add(node.server_udp_port.ToString());
            item.SubItems.Add(node.password);
            item.SubItems.Add(node.method);
            item.SubItems.Add(node.obfs);
            item.SubItems.Add(node.obfsparam);
            item.SubItems.Add(node.remarks);
            item.SubItems.Add(node.protocol);
            item.SubItems.Add(node.protocolparam);
            item.SubItems.Add("未测试");
            item.SubItems.Add(node.geoip);
            item.Tag = node;
            return item;
        }

        private async Task<IPSBObject> RequestIPSBAPI(string ip) 
        {
            bool flag = false; // dns resolve ok flag

            try
            {
                IPAddress ipTry = IPAddress.Parse(ip); // detect if ip address
            }
            catch
            {
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(ip); // try to resolve domain
                }
                catch
                {
                    flag = true;
                }
                if (!flag)
                {
                    ip = Dns.GetHostEntry(ip).ToString(); // save resolve result
                }
            }

            HttpClient client = new HttpClient();

            try
            {                
                HttpResponseMessage response = await client.GetAsync("https://api.ip.sb/geoip/" + ip); // call IP.SB API
                if (response.IsSuccessStatusCode)
                {
                    var resultJSONText = response.Content.ReadAsStringAsync().Result;
                    IPSBObject resultJSONObj = JsonConvert.DeserializeObject<IPSBObject>(resultJSONText);
                    return resultJSONObj; // returl oj8k result
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null; // return error result
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "加载中...";

            pageIndex++;
            try
            {
                List<string> list = await searcher.AsyncLoadPage(pageIndex);
                foreach (string s in list)
                {
                    string jsonText = await searcher.AsyncGetUrl(s);
                    var configs = JsonConvert.DeserializeObject<GuiConfig>(jsonText);
                    // Load NodeConfigs
                    if (configs != null && configs.configs != null && configs.configs.Count > 0)
                    {
                        nodeList.BeginUpdate();
                        foreach (var node in configs.configs)
                        {
                            if (node.server == null || node.server == string.Empty)
                                continue;
                            if (node.server.IndexOf("0.0.0") >= 0 || node.server == "127.0.0.1")
                                continue;
                            IPSBObject GeoIPResult = await RequestIPSBAPI(node.server); // Request country
                            if (GeoIPResult == null || GeoIPResult.country == string.Empty) // detect if null result
                                continue;
                            node.geoip = GeoIPResult.country; // update node
                            nodeList.Items.Add(ToListViewItem(node));
                        }
                        nodeList.EndUpdate();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            nodeList.EndUpdate();
            button1.Enabled = true;
            button1.Text = "再来点";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditCookieForm editCookie = new EditCookieForm(this);
            editCookie.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GuiConfig guiConfig = new GuiConfig();
            guiConfig.configs = new List<NodeConfig>();

            foreach (ListViewItem item in nodeList.Items)
            {
                guiConfig.configs.Add((NodeConfig)item.Tag);
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = false;
            foreach(ListViewItem item in nodeList.Items)
            {
                NodeConfig config = (NodeConfig)item.Tag;
                var pingItem = item.SubItems[item.SubItems.Count - 1];
                pingItem.Text = "测试中";

                var result = await AsyncSend(config.server);
                if (result == -1)
                {
                    pingItem.Text = "失败";
                }
                else if (result < -1)
                {
                    pingItem.Text = "错误";
                }
                else if(result >= 0)
                {
                    pingItem.Text = result.ToString();
                }
                
            }
            button1.Enabled = true;
            button4.Enabled = true;
        }
        private Task<long> AsyncSend(string address)
        {
            
            return Task.Run(() => {
                long val = -1;
                try
                {
                    var ping = new Ping();
                    var ret = ping.Send(address);
                    if (ret.Status == IPStatus.Success)
                    {
                        val = ret.RoundtripTime;
                    }
                    else
                    {
                        val = -1;
                    }
                }
                catch (Exception)
                {
                    val = -2;
                }
                return val;
                });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GuiConfig guiConfig = new GuiConfig();
            guiConfig.configs = new List<NodeConfig>();

            foreach(ListViewItem item in nodeList.Items)
            {
                NodeConfig config = (NodeConfig)item.Tag;
                var pingItem = item.SubItems[item.SubItems.Count - 1];

                try
                {
                    int ping = int.Parse(pingItem.Text);
                    guiConfig.configs.Add(config);
                }
                catch(Exception)
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
