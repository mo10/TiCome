namespace TiCome
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("未分组");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("订阅1");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("订阅2");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("订阅3");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("ShadowsocksR", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SetCookieBtn = new System.Windows.Forms.Button();
            this.statusText = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GroupTree = new System.Windows.Forms.TreeView();
            this.TreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TreeMenu_SelectNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.TreeMenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenu_SaveSubs = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenu_SaveNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TreeMenu_CopySubs = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenu_CopyNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TreeMenu_TestPing = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenu_TestGeo = new System.Windows.Forms.ToolStripMenuItem();
            this.SubsList = new System.Windows.Forms.ListView();
            this.GroupHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UrlHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SubsMenu_CopySelectedSubs = new System.Windows.Forms.ToolStripMenuItem();
            this.SubsMenu_SaveSelectedSubs = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeList = new System.Windows.Forms.ListView();
            this.ServerHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerPortHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PasswordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MethodHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProtocolHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProtocolParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObfsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObfsParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemarkHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PingHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GeoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NodeMenu_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.NodeMenu_CopySelectedNode = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeMenu_SaveSelectedNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.NodeMenu_TestPing = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeMenu_TestGeo = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TreeMenu.SuspendLayout();
            this.SubsMenu.SuspendLayout();
            this.NodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(12, 12);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "梯来!";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 1;
            // 
            // SetCookieBtn
            // 
            this.SetCookieBtn.Location = new System.Drawing.Point(99, 12);
            this.SetCookieBtn.Name = "SetCookieBtn";
            this.SetCookieBtn.Size = new System.Drawing.Size(75, 23);
            this.SetCookieBtn.TabIndex = 3;
            this.SetCookieBtn.Text = "Cookie设置";
            this.SetCookieBtn.UseVisualStyleBackColor = true;
            this.SetCookieBtn.Click += new System.EventHandler(this.SetCookie_Click);
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Location = new System.Drawing.Point(93, 17);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 12);
            this.statusText.TabIndex = 5;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 477);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(185, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/mo10/TiCome";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GroupTree);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SubsList);
            this.splitContainer1.Panel2.Controls.Add(this.NodeList);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(1071, 433);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 11;
            // 
            // GroupTree
            // 
            this.GroupTree.ContextMenuStrip = this.TreeMenu;
            this.GroupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupTree.HideSelection = false;
            this.GroupTree.Location = new System.Drawing.Point(0, 0);
            this.GroupTree.Name = "GroupTree";
            treeNode6.Name = "节点2";
            treeNode6.Text = "未分组";
            treeNode7.Name = "节点5";
            treeNode7.Text = "订阅1";
            treeNode8.Name = "节点6";
            treeNode8.Text = "订阅2";
            treeNode9.Name = "节点7";
            treeNode9.Text = "订阅3";
            treeNode10.Name = "节点0";
            treeNode10.Text = "ShadowsocksR";
            this.GroupTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.GroupTree.PathSeparator = "/";
            this.GroupTree.Size = new System.Drawing.Size(199, 433);
            this.GroupTree.TabIndex = 10;
            // 
            // TreeMenu
            // 
            this.TreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeMenu_SelectNode,
            this.toolStripMenuItem5,
            this.TreeMenu_Save,
            this.TreeMenu_SaveSubs,
            this.TreeMenu_SaveNode,
            this.toolStripMenuItem1,
            this.TreeMenu_CopySubs,
            this.TreeMenu_CopyNode,
            this.toolStripMenuItem2,
            this.TreeMenu_TestPing,
            this.TreeMenu_TestGeo});
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(173, 198);
            // 
            // TreeMenu_SelectNode
            // 
            this.TreeMenu_SelectNode.Enabled = false;
            this.TreeMenu_SelectNode.Name = "TreeMenu_SelectNode";
            this.TreeMenu_SelectNode.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_SelectNode.Text = "{SelectedNode}";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(169, 6);
            // 
            // TreeMenu_Save
            // 
            this.TreeMenu_Save.Name = "TreeMenu_Save";
            this.TreeMenu_Save.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_Save.Text = "保存订阅与节点";
            // 
            // TreeMenu_SaveSubs
            // 
            this.TreeMenu_SaveSubs.Name = "TreeMenu_SaveSubs";
            this.TreeMenu_SaveSubs.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_SaveSubs.Text = "仅保存订阅地址";
            // 
            // TreeMenu_SaveNode
            // 
            this.TreeMenu_SaveNode.Name = "TreeMenu_SaveNode";
            this.TreeMenu_SaveNode.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_SaveNode.Text = "仅保存节点";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 6);
            // 
            // TreeMenu_CopySubs
            // 
            this.TreeMenu_CopySubs.Name = "TreeMenu_CopySubs";
            this.TreeMenu_CopySubs.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_CopySubs.Text = "复制订阅地址";
            // 
            // TreeMenu_CopyNode
            // 
            this.TreeMenu_CopyNode.Name = "TreeMenu_CopyNode";
            this.TreeMenu_CopyNode.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_CopyNode.Text = "复制节点链接";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 6);
            // 
            // TreeMenu_TestPing
            // 
            this.TreeMenu_TestPing.Name = "TreeMenu_TestPing";
            this.TreeMenu_TestPing.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_TestPing.Text = "Ping测试";
            // 
            // TreeMenu_TestGeo
            // 
            this.TreeMenu_TestGeo.Name = "TreeMenu_TestGeo";
            this.TreeMenu_TestGeo.Size = new System.Drawing.Size(172, 22);
            this.TreeMenu_TestGeo.Text = "Geo查询节点位置";
            // 
            // SubsList
            // 
            this.SubsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupHeader,
            this.UrlHeader});
            this.SubsList.ContextMenuStrip = this.SubsMenu;
            this.SubsList.FullRowSelect = true;
            this.SubsList.GridLines = true;
            this.SubsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SubsList.HideSelection = false;
            this.SubsList.Location = new System.Drawing.Point(0, 0);
            this.SubsList.Name = "SubsList";
            this.SubsList.Size = new System.Drawing.Size(864, 117);
            this.SubsList.TabIndex = 4;
            this.SubsList.UseCompatibleStateImageBehavior = false;
            this.SubsList.View = System.Windows.Forms.View.Details;
            // 
            // GroupHeader
            // 
            this.GroupHeader.Text = "组名";
            this.GroupHeader.Width = 200;
            // 
            // UrlHeader
            // 
            this.UrlHeader.Text = "订阅地址";
            this.UrlHeader.Width = 400;
            // 
            // SubsMenu
            // 
            this.SubsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubsMenu_CopySelectedSubs,
            this.SubsMenu_SaveSelectedSubs});
            this.SubsMenu.Name = "SubsMenu";
            this.SubsMenu.Size = new System.Drawing.Size(173, 48);
            // 
            // SubsMenu_CopySelectedSubs
            // 
            this.SubsMenu_CopySelectedSubs.Name = "SubsMenu_CopySelectedSubs";
            this.SubsMenu_CopySelectedSubs.Size = new System.Drawing.Size(172, 22);
            this.SubsMenu_CopySelectedSubs.Text = "复制所选订阅地址";
            // 
            // SubsMenu_SaveSelectedSubs
            // 
            this.SubsMenu_SaveSelectedSubs.Name = "SubsMenu_SaveSelectedSubs";
            this.SubsMenu_SaveSelectedSubs.Size = new System.Drawing.Size(172, 22);
            this.SubsMenu_SaveSelectedSubs.Text = "保存所选订阅地址";
            // 
            // NodeList
            // 
            this.NodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerHeader,
            this.ServerPortHeader,
            this.PasswordHeader,
            this.MethodHeader,
            this.ProtocolHeader,
            this.ProtocolParamHeader,
            this.ObfsHeader,
            this.ObfsParamHeader,
            this.RemarkHeader,
            this.PingHeader,
            this.GeoHeader});
            this.NodeList.ContextMenuStrip = this.NodeMenu;
            this.NodeList.FullRowSelect = true;
            this.NodeList.GridLines = true;
            this.NodeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.NodeList.HideSelection = false;
            this.NodeList.Location = new System.Drawing.Point(0, 123);
            this.NodeList.Name = "NodeList";
            this.NodeList.Size = new System.Drawing.Size(864, 310);
            this.NodeList.TabIndex = 2;
            this.NodeList.UseCompatibleStateImageBehavior = false;
            this.NodeList.View = System.Windows.Forms.View.Details;
            this.NodeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NodeList_MouseDoubleClick);
            // 
            // ServerHeader
            // 
            this.ServerHeader.Text = "服务器";
            this.ServerHeader.Width = 100;
            // 
            // ServerPortHeader
            // 
            this.ServerPortHeader.Text = "端口";
            // 
            // PasswordHeader
            // 
            this.PasswordHeader.Text = "密码";
            this.PasswordHeader.Width = 100;
            // 
            // MethodHeader
            // 
            this.MethodHeader.Text = "加密方式";
            // 
            // ProtocolHeader
            // 
            this.ProtocolHeader.Text = "协议";
            // 
            // ProtocolParamHeader
            // 
            this.ProtocolParamHeader.Text = "协议参数";
            // 
            // ObfsHeader
            // 
            this.ObfsHeader.Text = "混淆";
            // 
            // ObfsParamHeader
            // 
            this.ObfsParamHeader.Text = "混淆参数";
            // 
            // RemarkHeader
            // 
            this.RemarkHeader.Text = "节点备注";
            this.RemarkHeader.Width = 100;
            // 
            // PingHeader
            // 
            this.PingHeader.Text = "延迟";
            // 
            // GeoHeader
            // 
            this.GeoHeader.Text = "位置";
            // 
            // NodeMenu
            // 
            this.NodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NodeMenu_Show,
            this.toolStripMenuItem3,
            this.NodeMenu_CopySelectedNode,
            this.NodeMenu_SaveSelectedNode,
            this.toolStripMenuItem4,
            this.NodeMenu_TestPing,
            this.NodeMenu_TestGeo});
            this.NodeMenu.Name = "NodeMenu";
            this.NodeMenu.Size = new System.Drawing.Size(173, 126);
            // 
            // NodeMenu_Show
            // 
            this.NodeMenu_Show.Name = "NodeMenu_Show";
            this.NodeMenu_Show.Size = new System.Drawing.Size(172, 22);
            this.NodeMenu_Show.Text = "详细信息";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 6);
            // 
            // NodeMenu_CopySelectedNode
            // 
            this.NodeMenu_CopySelectedNode.Name = "NodeMenu_CopySelectedNode";
            this.NodeMenu_CopySelectedNode.Size = new System.Drawing.Size(172, 22);
            this.NodeMenu_CopySelectedNode.Text = "复制所选节点链接";
            // 
            // NodeMenu_SaveSelectedNode
            // 
            this.NodeMenu_SaveSelectedNode.Name = "NodeMenu_SaveSelectedNode";
            this.NodeMenu_SaveSelectedNode.Size = new System.Drawing.Size(172, 22);
            this.NodeMenu_SaveSelectedNode.Text = "保存所选节点";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(169, 6);
            // 
            // NodeMenu_TestPing
            // 
            this.NodeMenu_TestPing.Name = "NodeMenu_TestPing";
            this.NodeMenu_TestPing.Size = new System.Drawing.Size(172, 22);
            this.NodeMenu_TestPing.Text = "Ping测试";
            // 
            // NodeMenu_TestGeo
            // 
            this.NodeMenu_TestGeo.Name = "NodeMenu_TestGeo";
            this.NodeMenu_TestGeo.Size = new System.Drawing.Size(172, 22);
            this.NodeMenu_TestGeo.Text = "Geo查询节点位置";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 501);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.SetCookieBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "梯来";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TreeMenu.ResumeLayout(false);
            this.SubsMenu.ResumeLayout(false);
            this.NodeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView NodeList;
        private System.Windows.Forms.Button SetCookieBtn;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TreeView GroupTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip TreeMenu;
        private System.Windows.Forms.ContextMenuStrip NodeMenu;
        private System.Windows.Forms.ListView SubsList;
        private System.Windows.Forms.ColumnHeader GroupHeader;
        private System.Windows.Forms.ColumnHeader UrlHeader;
        private System.Windows.Forms.ColumnHeader ServerHeader;
        private System.Windows.Forms.ColumnHeader ServerPortHeader;
        private System.Windows.Forms.ColumnHeader PasswordHeader;
        private System.Windows.Forms.ColumnHeader MethodHeader;
        private System.Windows.Forms.ColumnHeader ProtocolHeader;
        private System.Windows.Forms.ColumnHeader ProtocolParamHeader;
        private System.Windows.Forms.ColumnHeader ObfsHeader;
        private System.Windows.Forms.ColumnHeader ObfsParamHeader;
        private System.Windows.Forms.ColumnHeader RemarkHeader;
        private System.Windows.Forms.ColumnHeader PingHeader;
        private System.Windows.Forms.ColumnHeader GeoHeader;
        private System.Windows.Forms.ContextMenuStrip SubsMenu;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_Save;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_SaveSubs;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_SaveNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_CopySubs;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_CopyNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_TestPing;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_TestGeo;
        private System.Windows.Forms.ToolStripMenuItem NodeMenu_Show;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem NodeMenu_CopySelectedNode;
        private System.Windows.Forms.ToolStripMenuItem NodeMenu_SaveSelectedNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem NodeMenu_TestPing;
        private System.Windows.Forms.ToolStripMenuItem NodeMenu_TestGeo;
        private System.Windows.Forms.ToolStripMenuItem SubsMenu_CopySelectedSubs;
        private System.Windows.Forms.ToolStripMenuItem SubsMenu_SaveSelectedSubs;
        private System.Windows.Forms.ToolStripMenuItem TreeMenu_SelectNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    }
}

