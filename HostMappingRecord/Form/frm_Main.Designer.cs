
namespace HostMappingRecord
{
    partial class frm_Main
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
            this.btn_Record = new System.Windows.Forms.Button();
            this.txt_HostAddress = new System.Windows.Forms.TextBox();
            this.txt_HostName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Ping = new System.Windows.Forms.Button();
            this.grp_NewHost = new System.Windows.Forms.GroupBox();
            this.tv_HostMapping = new System.Windows.Forms.TreeView();
            this.grp_NewHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Record
            // 
            this.btn_Record.Location = new System.Drawing.Point(279, 22);
            this.btn_Record.Name = "btn_Record";
            this.btn_Record.Size = new System.Drawing.Size(75, 40);
            this.btn_Record.TabIndex = 0;
            this.btn_Record.Text = "记录";
            this.btn_Record.UseVisualStyleBackColor = true;
            // 
            // txt_HostAddress
            // 
            this.txt_HostAddress.Location = new System.Drawing.Point(93, 32);
            this.txt_HostAddress.Name = "txt_HostAddress";
            this.txt_HostAddress.Size = new System.Drawing.Size(166, 23);
            this.txt_HostAddress.TabIndex = 1;
            // 
            // txt_HostName
            // 
            this.txt_HostName.Location = new System.Drawing.Point(93, 83);
            this.txt_HostName.Name = "txt_HostName";
            this.txt_HostName.Size = new System.Drawing.Size(166, 23);
            this.txt_HostName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "映射地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "主机名";
            // 
            // btn_Ping
            // 
            this.btn_Ping.Location = new System.Drawing.Point(279, 74);
            this.btn_Ping.Name = "btn_Ping";
            this.btn_Ping.Size = new System.Drawing.Size(75, 40);
            this.btn_Ping.TabIndex = 5;
            this.btn_Ping.Text = "ping";
            this.btn_Ping.UseVisualStyleBackColor = true;
            this.btn_Ping.Click += new System.EventHandler(this.btn_Ping_Click);
            // 
            // grp_NewHost
            // 
            this.grp_NewHost.Controls.Add(this.btn_Ping);
            this.grp_NewHost.Controls.Add(this.btn_Record);
            this.grp_NewHost.Controls.Add(this.label2);
            this.grp_NewHost.Controls.Add(this.label1);
            this.grp_NewHost.Controls.Add(this.txt_HostName);
            this.grp_NewHost.Controls.Add(this.txt_HostAddress);
            this.grp_NewHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_NewHost.Location = new System.Drawing.Point(0, 0);
            this.grp_NewHost.Name = "grp_NewHost";
            this.grp_NewHost.Size = new System.Drawing.Size(384, 127);
            this.grp_NewHost.TabIndex = 6;
            this.grp_NewHost.TabStop = false;
            this.grp_NewHost.Text = "新节点设置";
            // 
            // tv_HostMapping
            // 
            this.tv_HostMapping.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tv_HostMapping.Location = new System.Drawing.Point(0, 133);
            this.tv_HostMapping.Name = "tv_HostMapping";
            this.tv_HostMapping.Size = new System.Drawing.Size(384, 328);
            this.tv_HostMapping.TabIndex = 7;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.tv_HostMapping);
            this.Controls.Add(this.grp_NewHost);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_Main";
            this.Text = "主机映射记录";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.grp_NewHost.ResumeLayout(false);
            this.grp_NewHost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Record;
        private System.Windows.Forms.TextBox txt_HostAddress;
        private System.Windows.Forms.TextBox txt_HostName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Ping;
        private System.Windows.Forms.GroupBox grp_NewHost;
        private System.Windows.Forms.TreeView tv_HostMapping;
    }
}

