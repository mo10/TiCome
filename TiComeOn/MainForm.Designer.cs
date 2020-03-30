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
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeList = new System.Windows.Forms.ListView();
            this.serverHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.udpPortHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.passHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.methodHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.obfsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.obfsParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remarksHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.protocolHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.protocolParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pingHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GeoIPHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetCookieBtn = new System.Windows.Forms.Button();
            this.SaveAllBtn = new System.Windows.Forms.Button();
            this.statusText = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.PingBtn = new System.Windows.Forms.Button();
            this.SavePassBtn = new System.Windows.Forms.Button();
            this.GeoIPBtn = new System.Windows.Forms.Button();
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
            // nodeList
            // 
            this.nodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serverHeader,
            this.udpPortHeader,
            this.portHeader,
            this.passHeader,
            this.methodHeader,
            this.obfsHeader,
            this.obfsParamHeader,
            this.remarksHeader,
            this.protocolHeader,
            this.protocolParamHeader,
            this.pingHeader,
            this.GeoIPHeader});
            this.nodeList.FullRowSelect = true;
            this.nodeList.GridLines = true;
            this.nodeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.nodeList.HideSelection = false;
            this.nodeList.Location = new System.Drawing.Point(12, 41);
            this.nodeList.MultiSelect = false;
            this.nodeList.Name = "nodeList";
            this.nodeList.Size = new System.Drawing.Size(959, 417);
            this.nodeList.TabIndex = 2;
            this.nodeList.UseCompatibleStateImageBehavior = false;
            this.nodeList.View = System.Windows.Forms.View.Details;
            // 
            // serverHeader
            // 
            this.serverHeader.Text = "服务器地址";
            this.serverHeader.Width = 104;
            // 
            // udpPortHeader
            // 
            this.udpPortHeader.Text = "UDP端口";
            // 
            // portHeader
            // 
            this.portHeader.Text = "端口";
            // 
            // passHeader
            // 
            this.passHeader.Text = "密码";
            this.passHeader.Width = 93;
            // 
            // methodHeader
            // 
            this.methodHeader.Text = "加密";
            this.methodHeader.Width = 102;
            // 
            // obfsHeader
            // 
            this.obfsHeader.Text = "混淆";
            this.obfsHeader.Width = 95;
            // 
            // obfsParamHeader
            // 
            this.obfsParamHeader.Text = "混淆参数";
            this.obfsParamHeader.Width = 102;
            // 
            // remarksHeader
            // 
            this.remarksHeader.Text = "备注";
            // 
            // protocolHeader
            // 
            this.protocolHeader.Text = "协议";
            // 
            // protocolParamHeader
            // 
            this.protocolParamHeader.Text = "协议参数";
            // 
            // pingHeader
            // 
            this.pingHeader.Text = "延迟";
            // 
            // GeoIPHeader
            // 
            this.GeoIPHeader.Text = "地理位置";
            // 
            // SetCookieBtn
            // 
            this.SetCookieBtn.Location = new System.Drawing.Point(740, 12);
            this.SetCookieBtn.Name = "SetCookieBtn";
            this.SetCookieBtn.Size = new System.Drawing.Size(75, 23);
            this.SetCookieBtn.TabIndex = 3;
            this.SetCookieBtn.Text = "饼干设置";
            this.SetCookieBtn.UseVisualStyleBackColor = true;
            this.SetCookieBtn.Click += new System.EventHandler(this.SetCookie_Click);
            // 
            // SaveAllBtn
            // 
            this.SaveAllBtn.Location = new System.Drawing.Point(659, 12);
            this.SaveAllBtn.Name = "SaveAllBtn";
            this.SaveAllBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveAllBtn.TabIndex = 4;
            this.SaveAllBtn.Text = "保存所有";
            this.SaveAllBtn.UseVisualStyleBackColor = true;
            this.SaveAllBtn.Click += new System.EventHandler(this.SaveAll_Click);
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
            this.linkLabel1.Location = new System.Drawing.Point(13, 461);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(185, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/mo10/TiCome";
            // 
            // PingBtn
            // 
            this.PingBtn.Location = new System.Drawing.Point(443, 12);
            this.PingBtn.Name = "PingBtn";
            this.PingBtn.Size = new System.Drawing.Size(75, 23);
            this.PingBtn.TabIndex = 7;
            this.PingBtn.Text = "Ping测试";
            this.PingBtn.UseVisualStyleBackColor = true;
            this.PingBtn.Click += new System.EventHandler(this.PingTest_Click);
            // 
            // SavePassBtn
            // 
            this.SavePassBtn.Location = new System.Drawing.Point(524, 12);
            this.SavePassBtn.Name = "SavePassBtn";
            this.SavePassBtn.Size = new System.Drawing.Size(129, 23);
            this.SavePassBtn.TabIndex = 8;
            this.SavePassBtn.Text = "保存可连通服务器";
            this.SavePassBtn.UseVisualStyleBackColor = true;
            this.SavePassBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // GeoIPBtn
            // 
            this.GeoIPBtn.Location = new System.Drawing.Point(362, 12);
            this.GeoIPBtn.Name = "GeoIPBtn";
            this.GeoIPBtn.Size = new System.Drawing.Size(75, 23);
            this.GeoIPBtn.TabIndex = 9;
            this.GeoIPBtn.Text = "GeoIP";
            this.GeoIPBtn.UseVisualStyleBackColor = true;
            this.GeoIPBtn.Click += new System.EventHandler(this.GeoIPTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 485);
            this.Controls.Add(this.GeoIPBtn);
            this.Controls.Add(this.SavePassBtn);
            this.Controls.Add(this.PingBtn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.SaveAllBtn);
            this.Controls.Add(this.SetCookieBtn);
            this.Controls.Add(this.nodeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "梯来";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView nodeList;
        private System.Windows.Forms.ColumnHeader serverHeader;
        private System.Windows.Forms.ColumnHeader portHeader;
        private System.Windows.Forms.ColumnHeader udpPortHeader;
        private System.Windows.Forms.ColumnHeader passHeader;
        private System.Windows.Forms.ColumnHeader methodHeader;
        private System.Windows.Forms.ColumnHeader obfsHeader;
        private System.Windows.Forms.ColumnHeader obfsParamHeader;
        private System.Windows.Forms.ColumnHeader remarksHeader;
        private System.Windows.Forms.ColumnHeader protocolHeader;
        private System.Windows.Forms.Button SetCookieBtn;
        private System.Windows.Forms.ColumnHeader protocolParamHeader;
        private System.Windows.Forms.Button SaveAllBtn;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button PingBtn;
        private System.Windows.Forms.ColumnHeader pingHeader;
        private System.Windows.Forms.Button SavePassBtn;
        private System.Windows.Forms.ColumnHeader GeoIPHeader;
        private System.Windows.Forms.Button GeoIPBtn;
    }
}

