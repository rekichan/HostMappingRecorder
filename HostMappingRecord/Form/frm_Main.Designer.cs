
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.btn_Record = new System.Windows.Forms.Button();
            this.txt_HostAddress = new System.Windows.Forms.TextBox();
            this.txt_HostName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grp_NewHost = new System.Windows.Forms.GroupBox();
            this.btn_SaveHosts = new System.Windows.Forms.Button();
            this.lv_HostMapping = new System.Windows.Forms.ListView();
            this.cms_Tv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_DeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.grp_NewHost.SuspendLayout();
            this.cms_Tv.SuspendLayout();
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
            this.btn_Record.Click += new System.EventHandler(this.btn_Record_Click);
            // 
            // txt_HostAddress
            // 
            this.txt_HostAddress.Location = new System.Drawing.Point(93, 32);
            this.txt_HostAddress.Name = "txt_HostAddress";
            this.txt_HostAddress.Size = new System.Drawing.Size(166, 27);
            this.txt_HostAddress.TabIndex = 1;
            // 
            // txt_HostName
            // 
            this.txt_HostName.Location = new System.Drawing.Point(93, 83);
            this.txt_HostName.Name = "txt_HostName";
            this.txt_HostName.Size = new System.Drawing.Size(166, 27);
            this.txt_HostName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "映射地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "主机名";
            // 
            // grp_NewHost
            // 
            this.grp_NewHost.Controls.Add(this.btn_SaveHosts);
            this.grp_NewHost.Controls.Add(this.btn_Record);
            this.grp_NewHost.Controls.Add(this.label2);
            this.grp_NewHost.Controls.Add(this.label1);
            this.grp_NewHost.Controls.Add(this.txt_HostName);
            this.grp_NewHost.Controls.Add(this.txt_HostAddress);
            this.grp_NewHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_NewHost.Location = new System.Drawing.Point(0, 0);
            this.grp_NewHost.Name = "grp_NewHost";
            this.grp_NewHost.Size = new System.Drawing.Size(382, 127);
            this.grp_NewHost.TabIndex = 6;
            this.grp_NewHost.TabStop = false;
            this.grp_NewHost.Text = "新节点设置";
            // 
            // btn_SaveHosts
            // 
            this.btn_SaveHosts.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveHosts.Location = new System.Drawing.Point(279, 76);
            this.btn_SaveHosts.Name = "btn_SaveHosts";
            this.btn_SaveHosts.Size = new System.Drawing.Size(75, 40);
            this.btn_SaveHosts.TabIndex = 5;
            this.btn_SaveHosts.Text = "保存Hosts";
            this.btn_SaveHosts.UseVisualStyleBackColor = true;
            this.btn_SaveHosts.Click += new System.EventHandler(this.btn_SaveHosts_Click);
            // 
            // lv_HostMapping
            // 
            this.lv_HostMapping.ContextMenuStrip = this.cms_Tv;
            this.lv_HostMapping.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lv_HostMapping.HideSelection = false;
            this.lv_HostMapping.Location = new System.Drawing.Point(0, 127);
            this.lv_HostMapping.MultiSelect = false;
            this.lv_HostMapping.Name = "lv_HostMapping";
            this.lv_HostMapping.Size = new System.Drawing.Size(382, 328);
            this.lv_HostMapping.TabIndex = 7;
            this.lv_HostMapping.UseCompatibleStateImageBehavior = false;
            this.lv_HostMapping.View = System.Windows.Forms.View.Details;
            // 
            // cms_Tv
            // 
            this.cms_Tv.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_Tv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_DeleteNode});
            this.cms_Tv.Name = "cms_Tv";
            this.cms_Tv.Size = new System.Drawing.Size(139, 28);
            // 
            // tsmi_DeleteNode
            // 
            this.tsmi_DeleteNode.Name = "tsmi_DeleteNode";
            this.tsmi_DeleteNode.Size = new System.Drawing.Size(138, 24);
            this.tsmi_DeleteNode.Text = "删除本项";
            this.tsmi_DeleteNode.Click += new System.EventHandler(this.tsmi_DeleteNode_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 455);
            this.Controls.Add(this.lv_HostMapping);
            this.Controls.Add(this.grp_NewHost);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 500);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主机映射工具";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.grp_NewHost.ResumeLayout(false);
            this.grp_NewHost.PerformLayout();
            this.cms_Tv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Record;
        private System.Windows.Forms.TextBox txt_HostAddress;
        private System.Windows.Forms.TextBox txt_HostName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grp_NewHost;
        private System.Windows.Forms.ListView lv_HostMapping;
        private System.Windows.Forms.Button btn_SaveHosts;
        private System.Windows.Forms.ContextMenuStrip cms_Tv;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteNode;
    }
}

