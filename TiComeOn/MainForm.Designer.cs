namespace TiComeOn
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeList = new System.Windows.Forms.ListView();
            this.serverHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.udpPortHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.passHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.methodHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.obfsHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.obfsParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remarksHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.protocolHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.protocolParamHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "梯来!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.portHeader,
            this.udpPortHeader,
            this.passHeader,
            this.methodHeader,
            this.obfsHeader,
            this.obfsParamHeader,
            this.remarksHeader,
            this.protocolHeader,
            this.protocolParamHeader});
            this.nodeList.FullRowSelect = true;
            this.nodeList.GridLines = true;
            this.nodeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.nodeList.Location = new System.Drawing.Point(12, 41);
            this.nodeList.MultiSelect = false;
            this.nodeList.Name = "nodeList";
            this.nodeList.Size = new System.Drawing.Size(868, 415);
            this.nodeList.TabIndex = 2;
            this.nodeList.UseCompatibleStateImageBehavior = false;
            this.nodeList.View = System.Windows.Forms.View.Details;
            // 
            // serverHeader
            // 
            this.serverHeader.Text = "服务器地址";
            this.serverHeader.Width = 82;
            // 
            // portHeader
            // 
            this.portHeader.Text = "端口";
            // 
            // udpPortHeader
            // 
            this.udpPortHeader.Text = "UDP端口";
            // 
            // passHeader
            // 
            this.passHeader.Text = "密码";
            // 
            // methodHeader
            // 
            this.methodHeader.Text = "加密";
            // 
            // obfsHeader
            // 
            this.obfsHeader.Text = "混淆";
            // 
            // obfsParamHeader
            // 
            this.obfsParamHeader.Text = "混淆参数";
            this.obfsParamHeader.Width = 70;
            // 
            // remarksHeader
            // 
            this.remarksHeader.Text = "备注";
            // 
            // protocolHeader
            // 
            this.protocolHeader.Text = "协议";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "换个饼干";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // protocolParamHeader
            // 
            this.protocolParamHeader.Text = "协议参数";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 468);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.nodeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "梯来！！！";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader protocolParamHeader;
    }
}

