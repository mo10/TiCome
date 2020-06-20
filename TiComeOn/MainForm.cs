using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private GithubSearcher searcher;
        private const int TIMEOUT = 10;

        // 节点
        private Dictionary<string, List<NodeConfig>> nodeConfigs;
        // 服务器订阅
        private Dictionary<string, List<ServerSubscribe>> serverSubcribes;

        public MainForm()
        {
            InitializeComponent();

            searcher = new GithubSearcher();

            nodeConfigs = new Dictionary<string, List<NodeConfig>>();
            serverSubcribes = new Dictionary<string, List<ServerSubscribe>>();
            nodeConfigs.Add("未分组", new List<NodeConfig>());
            serverSubcribes.Add("未分组", new List<ServerSubscribe>());

            // 初始化树
            GroupTree.Nodes.Clear();
            GroupTree.Nodes.Add("ShadowsocksR", "ShadowsocksR");
            GroupTree.Nodes["ShadowsocksR"].Nodes.Add("未分组", "未分组");
            GroupTreeEventRegist();
        }
        /// <summary>
        /// GroupTree 事件注册
        /// </summary>
        private void GroupTreeEventRegist()
        {
            // GroupTree
            // 鼠标按下选择
            GroupTree.MouseDown += new MouseEventHandler((sender, e) =>
            {
                GroupTree.SelectedNode = GroupTree.GetNodeAt(e.X, e.Y);
            });
            // 刷新列表
            GroupTree.AfterSelect += new TreeViewEventHandler((sender, e) =>
            {
                NodeList.Items.Clear();
                SubsList.Items.Clear();
                foreach(var nodeConfig in GetAllNodeConfigs(GroupTree.SelectedNode))
                {
                    if(nodeConfig.Tag != null)
                    {
                        NodeList.Items.Add((ListViewItem)nodeConfig.Tag);
                    }
                }
                foreach (var serverSubscribe in GetAllServerSubscribes(GroupTree.SelectedNode))
                {
                    if (serverSubscribe.Tag != null)
                    {
                        SubsList.Items.Add((ListViewItem)serverSubscribe.Tag);
                    }
                }
            });
            // TreeMenu
            // 菜单打开
            TreeMenu.Opening += new CancelEventHandler((sender, e) =>
            {
                if (GroupTree.SelectedNode != null)
                {
                    TreeMenu_SelectNode.Text = GroupTree.SelectedNode.Text;
                    TreeMenu_SelectNode.Tag = GroupTree.SelectedNode;
                }
                else
                {
                    e.Cancel = true;
                }
            });
            // 保存订阅与节点
            TreeMenu_Save.Click += new EventHandler((sender, e) =>
            {
                GuiConfig guiConfig = new GuiConfig();
                guiConfig.configs = GetAllNodeConfigs((TreeNode)TreeMenu_SelectNode.Tag);
                guiConfig.serverSubscribes = GetAllServerSubscribes((TreeNode)TreeMenu_SelectNode.Tag);

                SaveJsonDialog("ShadowsocksR GUI Config|*.json", "保存 ShadowsocksR 配置文件", "gui-config.json", guiConfig);
            });
            // 仅保存节点
            TreeMenu_SaveNode.Click += new EventHandler((sender, e) =>
            {
                GuiConfig guiConfig = new GuiConfig();
                guiConfig.configs = GetAllNodeConfigs((TreeNode)TreeMenu_SelectNode.Tag);

                SaveJsonDialog("ShadowsocksR GUI Config|*.json", "保存 ShadowsocksR 配置文件", "gui-config.json", guiConfig);
            });
            // 仅保存订阅
            TreeMenu_SaveSubs.Click += new EventHandler((sender, e) =>
            {
                GuiConfig guiConfig = new GuiConfig();
                guiConfig.serverSubscribes = GetAllServerSubscribes((TreeNode)TreeMenu_SelectNode.Tag);

                SaveJsonDialog("ShadowsocksR GUI Config|*.json", "保存 ShadowsocksR 配置文件", "gui-config.json", guiConfig);
            });
            // 复制节点链接
            TreeMenu_CopyNode.Click += new EventHandler((sender, e) =>
            {
                var nodeConfigs = GetAllNodeConfigs((TreeNode)TreeMenu_SelectNode.Tag);
                string ssrUrls = string.Empty;
                foreach (var nodeConfig in nodeConfigs)
                {
                    ssrUrls += Server.GetSSRLinkForServer(nodeConfig) + "\r\n";
                }
                if (!string.IsNullOrEmpty(ssrUrls))
                {
                    Clipboard.SetText(ssrUrls);
                }
            });
            // 复制订阅地址
            TreeMenu_CopySubs.Click += new EventHandler((sender, e) =>
            {
                var serverSubscribes = GetAllServerSubscribes((TreeNode)TreeMenu_SelectNode.Tag);
                string subsUrls = string.Empty;
                foreach (var serverSubscribe in serverSubscribes)
                {
                    subsUrls += serverSubscribe.URL + "\r\n";
                }
                if (!string.IsNullOrEmpty(subsUrls))
                {
                    Clipboard.SetText(subsUrls);
                }
            });
            // Ping测试
            TreeMenu_TestPing.Click += new EventHandler(async (sender, e) =>
            {
                foreach(var nodeConfig in GetAllNodeConfigs((TreeNode)TreeMenu_SelectNode.Tag))
                {
                    var item = (ListViewItem)nodeConfig.Tag;
                    if(nodeConfig.ping == -2)
                    {
                        // 在测试中，跳过
                        continue;
                    }
                    // Ping
                    nodeConfig.ping = -2;
                    item.SubItems[item.SubItems.Count - 1 - 1].Text = "测试中";

                    nodeConfig.ping = await GetPingAsync(nodeConfig.server);
                    if(nodeConfig.ping == -3)
                    {
                        item.SubItems[item.SubItems.Count - 1 - 1].Text = "失败";
                    }
                    if (nodeConfig.ping >= 0)
                    {
                        item.SubItems[item.SubItems.Count - 1 - 1].Text = nodeConfig.ping.ToString();
                    }
                }
            });
            // Geo测试
            TreeMenu_TestGeo.Click += new EventHandler(async (sender, e) =>
            {
                foreach (var nodeConfig in GetAllNodeConfigs((TreeNode)TreeMenu_SelectNode.Tag))
                {
                    var item = (ListViewItem)nodeConfig.Tag;
                    if (nodeConfig.country != string.Empty)
                    {
                        // 跳过
                        continue;
                    }
                    item.SubItems[item.SubItems.Count - 1].Text = "测试中";

                    var geoIP = await GetGeoIPAsync(nodeConfig.server);
                    if (geoIP == null)
                    {
                        item.SubItems[item.SubItems.Count - 1].Text = "失败";
                        nodeConfig.country = "失败";
                        continue;
                    }
                    nodeConfig.country = geoIP.country;
                    item.SubItems[item.SubItems.Count - 1].Text = geoIP.country;
                }
            });
        }
        public void SetCookie(string cookie)
        {
            searcher.userSession = cookie;
        }
        public string GetCookie()
        {
            return searcher.userSession;
        }
        /// <summary>
        /// 显示保存对象对话框
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <param name="filename"></param>
        /// <param name="value"></param>
        private void SaveJsonDialog(string filter, string title, string filename, object value)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            saveFileDialog.Title = title;
            saveFileDialog.FileName = filename;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter file = File.CreateText(saveFileDialog.FileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, value);
                }
            }
        }
        /// <summary>
        /// 获取TreeNode下所有节点配置
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        private List<NodeConfig> GetAllNodeConfigs(TreeNode treeNode)
        {
            var nodeConfigs = new List<NodeConfig>();
            // 遍历子节点
            if (this.nodeConfigs.ContainsKey(treeNode.Text) && this.nodeConfigs[treeNode.Text].Count > 0)
            {
                foreach (var nodeConfig in this.nodeConfigs[treeNode.Text])
                {
                    nodeConfigs.Add(nodeConfig);
                }
            }
            if (treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode subTreeNode in treeNode.Nodes)
                {
                    nodeConfigs.AddRange(GetAllNodeConfigs(subTreeNode));
                }
            }
            return nodeConfigs;
        }
        /// <summary>
        /// 获取TreeNode下所有订阅配置
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        private List<ServerSubscribe> GetAllServerSubscribes(TreeNode treeNode)
        {
            var subscribes = new List<ServerSubscribe>();
            // 遍历子节点
            if (serverSubcribes.ContainsKey(treeNode.Text) && nodeConfigs[treeNode.Text].Count > 0)
            {
                foreach (var nodeConfig in serverSubcribes[treeNode.Text])
                {
                    subscribes.Add(nodeConfig);
                }
            }
            if (treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode subTreeNode in treeNode.Nodes)
                {
                    subscribes.AddRange(GetAllServerSubscribes(subTreeNode));
                }
            }
            return subscribes;
        }
        /// <summary>
        /// 如果组不存在则添加组
        /// </summary>
        /// <param name="name"></param>
        private void AddGroupIfnExist(string name)
        {
            if (!serverSubcribes.ContainsKey(name))
            {
                serverSubcribes.Add(name, new List<ServerSubscribe>());
                GroupTree.Invoke(new Action(() =>
                {
                    GroupTree.Nodes["ShadowsocksR"].Nodes.Add(name, name);
                }));
            }
            if (!nodeConfigs.ContainsKey(name))
            {
                nodeConfigs.Add(name, new List<NodeConfig>());
            }
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

            var ping = new ListViewItem.ListViewSubItem();
            ping.Name = "PingItem";
            ping.Text = "未测试";
            ping.Tag = false;

            var geoip = new ListViewItem.ListViewSubItem();
            geoip.Name = "GeoIPItem";
            geoip.Text = "未测试";
            geoip.Tag = false;

            item.SubItems.Add(ping);
            item.SubItems.Add(geoip);

            item.Tag = node;
            return item;
        }
        private Task<long> GetPingAsync(string address)
        {

            return Task.Run(() =>
            {
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
                        val = -3;
                    }
                }
                catch (Exception)
                {
                    val = -3;
                }
                return val;
            });
        }
        private Task<IPSBObject> GetGeoIPAsync(string address) 
        {
            return Task.Run(async () =>
            {
                try
                {
                    IPAddress ip;
                    if(!IPAddress.TryParse(address, out ip)){
                        IPHostEntry hostEntry = Dns.GetHostEntry(address);
                        if (hostEntry.AddressList.Length > 0)
                        {
                            return null;
                        }
                        ip = hostEntry.AddressList[0];
                    }
                    using (var cli = new FlurlClient().EnableCookies())
                    {
                        var resultJson = await cli.Request($"https://api.ip.sb/geoip/{ip}").WithTimeout(TIMEOUT).GetAsync().ReceiveJson<IPSBObject>();
                        return resultJson;
                    }
                }
                catch (Exception)
                {
                }

                return null; // return error result
            });
            
        }

        private void SetCookie_Click(object sender, EventArgs e)
        {
            EditCookieForm editCookie = new EditCookieForm(this);
            editCookie.ShowDialog();
        }

        private async void PingTest_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            //PingBtn.Enabled = false;

            foreach (ListViewItem item in NodeList.Items)
            {
                NodeConfig node = (NodeConfig)item.Tag;
                var pingItem = item.SubItems["PingItem"];
                // 跳过已ping
                if ((bool)pingItem.Tag == true)
                {
                    continue;
                }
                pingItem.Text = "测试中";
                var result = await GetPingAsync(node.server);
                NodeList.Invoke(new Action(() =>
                {
                    if (result == -1)
                    {
                        pingItem.Text = "失败";
                    }
                    else if (result < -1)
                    {
                        pingItem.Text = "错误";

                    }
                    else if (result >= 0)
                    {
                        pingItem.Text = result.ToString();
                    }
                    // 完成ping
                    pingItem.Tag = true;
                }));
            }
            StartBtn.Enabled = true;
            //PingBtn.Enabled = true;
        }
        private async void GeoIPTest_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            //GeoIPBtn.Enabled = false;
            foreach (ListViewItem item in NodeList.Items)
            {
                NodeConfig node = (NodeConfig)item.Tag;
                var geoipItem = item.SubItems["GeoIPItem"];
                // 跳过已ping
                if ((bool)geoipItem.Tag == true)
                {
                    continue;
                }
                geoipItem.Text = "测试中";
                IPSBObject GeoIPResult = await GetGeoIPAsync(node.server); // Request country
                if (GeoIPResult == null || GeoIPResult.country == string.Empty)
                {
                    geoipItem.Text = "失败";
                }
                else
                {
                    geoipItem.Text = GeoIPResult.country; // update node
                }
                geoipItem.Tag = true;
            }
            StartBtn.Enabled = true;
            //GeoIPBtn.Enabled = true;
        }
        /// <summary>
        /// 梯来 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Start_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            StartBtn.Text = "加载中...";

            try
            {
                // 请求一页 gui-config.json 下载链接
                var configFileUrls = await searcher.NextPageAsync();
                if (configFileUrls == null)
                {
                    MessageBox.Show("没有搜索到任何结果，可能是由于Cookie无效。");
                    StartBtn.Enabled = true;
                    StartBtn.Text = "再来点";
                    return;
                }
                using (var cli = new FlurlClient())
                {
                    foreach (var configFileUrl in configFileUrls)
                    {
                        // 遍历文件
                        try
                        {
                            var resultText = await cli.Request(configFileUrl).WithTimeout(TIMEOUT).GetAsync().ReceiveString();
                            var guiConfig = JsonConvert.DeserializeObject<GuiConfig>(resultText);

                            if (guiConfig == null)
                            {
                                continue;
                            }
                            if (guiConfig.serverSubscribes != null && guiConfig.serverSubscribes.Count > 0)
                            {
                                // 遍历服务器订阅
                                foreach (var serverSubscribe in guiConfig.serverSubscribes)
                                {
                                    if (serverSubscribe.URL == string.Empty)
                                    {
                                        continue;
                                    }
                                    // 添加对应树节点
                                    AddGroupIfnExist(serverSubscribe.Group);
                                    // 创建ListViewItem对象
                                    ListViewItem item = new ListViewItem(serverSubscribe.Group);
                                    item.SubItems.Add(serverSubscribe.URL);
                                    item.Tag = serverSubscribe;

                                    serverSubscribe.Tag = item;
                                    // 追加列表
                                    serverSubcribes[serverSubscribe.Group].Add(serverSubscribe);
                                }
                            }
                            if (guiConfig.configs != null && guiConfig.configs.Count > 0)
                            {
                                // 遍历节点
                                foreach (var nodeConfig in guiConfig.configs)
                                {
                                    if (nodeConfig.server == string.Empty)
                                    {
                                        continue;
                                    }
                                    if (nodeConfig.server.IndexOf("0.0.0") >= 0 || nodeConfig.server == "127.0.0.1")
                                    {
                                        continue;
                                    }

                                    // 创建ListViewItem对象
                                    ListViewItem item = new ListViewItem(nodeConfig.server);

                                    item.SubItems.Add(nodeConfig.server_port.ToString());
                                    item.SubItems.Add(nodeConfig.password);
                                    item.SubItems.Add(nodeConfig.method);
                                    item.SubItems.Add(nodeConfig.protocol);
                                    item.SubItems.Add(nodeConfig.protocolparam);
                                    item.SubItems.Add(nodeConfig.obfs);
                                    item.SubItems.Add(nodeConfig.obfsparam);
                                    item.SubItems.Add(nodeConfig.remarks);
                                    // ping & geo
                                    item.SubItems.Add("");
                                    item.SubItems.Add("");
                                    item.Tag = nodeConfig;

                                    nodeConfig.Tag = item;
                                    // 追加列表
                                    if (nodeConfig.group != string.Empty)
                                    {
                                        AddGroupIfnExist(nodeConfig.group);
                                        nodeConfigs[nodeConfig.group].Add(nodeConfig);
                                    }
                                    else
                                    {
                                        nodeConfigs["未分组"].Add(nodeConfig);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            // do noting
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            StartBtn.Enabled = true;
            StartBtn.Text = "再来点";
        }
        
        private void NodeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedNode = ((ListView)sender).SelectedItems[0];
            
        }
    }
}
 