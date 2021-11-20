using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HostMappingRecord
{
    public partial class frm_Main : Form
    {

        #region Properties
        private cls_Config config;
        private string hostsPath;
        private string regexSplit;
        private string beforeText;
        private int selectedRow;
        private int selectedColumn;
        private bool editing;
        private bool changed;
        private List<string> activation;
        private List<string> deactivation;
        #endregion

        #region Constructor
        public frm_Main()
        {
            InitializeComponent();
        }
        #endregion

        #region FormEvent
        private void frm_Main_Load(object sender, EventArgs e)
        {
            InitHostsFile();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                DialogResult dr = MessageBox.Show("存在未保存的项，是否关闭?", "Q", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    e.Cancel = true;
            }
        }
        #endregion

        #region Event
        private void dgv_HostMapping_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell cell = (sender as DataGridView).SelectedCells[0];
            selectedRow = cell.RowIndex;
            selectedColumn = cell.ColumnIndex;
            if (cell.Value == null)
                beforeText = "";
            else
                beforeText = cell.Value.ToString();
            editing = true;
        }

        private void dgv_HostMapping_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            editing = false;
            string afterText = "";
            DataGridViewCell cell = dgv_HostMapping.Rows[selectedRow].Cells[selectedColumn];
            if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
            {
                MessageBox.Show("修改结果为空!", "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgv_HostMapping.Rows[selectedRow].Cells[selectedColumn].Value = beforeText;
                return;
            }
            afterText = cell.Value.ToString();
            Match m = Regex.Match(afterText, @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");
            if (selectedColumn == 1 && !m.Success)
            {
                MessageBox.Show("修改的IP不符合规则!", "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgv_HostMapping.Rows[selectedRow].Cells[selectedColumn].Value = beforeText;
                return;
            }

            if (!afterText.Equals(beforeText))
                changed = true;
        }

        private void dgv_HostMapping_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editing)
                return;

            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    (sender as DataGridView).CurrentRow.Selected = false;
                    (sender as DataGridView).Rows[e.RowIndex].Selected = true;
                }
                else
                    dgv_HostMapping.ClearSelection();
            }
        }

        private void tsmi_DeleteNode_Click(object sender, EventArgs e)
        {
            if (dgv_HostMapping.SelectedRows != null && dgv_HostMapping.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("确认要删除选中行?", "Q", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;

                int index = dgv_HostMapping.SelectedRows[0].Index;
                dgv_HostMapping.Rows.RemoveAt(index);
                changed = true;
            }
        }

        /*private void lv_HostMapping_DoubleClick(object sender, EventArgs e)
        {
            if (lv_HostMapping.SelectedItems.Count <= 0)
                return;

            lv_HostMapping.SelectedItems[0].BeginEdit();
        }*/

        private void btn_SaveHosts_Click(object sender, EventArgs e)
        {
            //判断文件是否存在
            if (!File.Exists(hostsPath))
            {
                MessageBox.Show("config中指定的hosts路径不存在!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("确认要保存信息?", "Q", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            //检测文件是否只读
            FileAttributes fa = File.GetAttributes(hostsPath);
            if (fa.ToString().IndexOf("readonly", StringComparison.OrdinalIgnoreCase) != -1)
            {
                //去除文件的只读属性
                fa ^= FileAttributes.ReadOnly;
                File.SetAttributes(hostsPath, fa);
            }

            //覆盖写入hosts
            //第一种方法
            using (StreamWriter sw = new StreamWriter(hostsPath, false))
            {
                //先写注释和其他的部分
                int datcnt = deactivation.Count;
                for (int m = 1; m < datcnt; m++)
                {
                    sw.WriteLine(deactivation[m]);
                }

                //再写hostname和address
                //int mapcnt = lv_HostMapping.Items.Count;
                int mapcnt = dgv_HostMapping.Rows.Count;
                for (int n = mapcnt - 1; n >= 0; n--)
                {
                    //读进来的时候hostname就是空字符或者null的情况就不写入到hosts
                    if (string.IsNullOrWhiteSpace(dgv_HostMapping.Rows[n].Cells[0].Value.ToString()))
                        continue;
                    /*if (string.IsNullOrEmpty(lv_HostMapping.Items[n].Text))
                        continue;*/

                    string name = dgv_HostMapping.Rows[n].Cells[0].Value.ToString();
                    string ip = dgv_HostMapping.Rows[n].Cells[1].Value.ToString();
                    sw.WriteLine(ip + "    " + name);

                    //sw.WriteLine(lv_HostMapping.Items[n].SubItems[1].Text + "    " + lv_HostMapping.Items[n].Text);
                }
                sw.Flush();
                sw.Close();
            }

            changed = false;

            //第二种方法
            /*File.WriteAllLines(hostsPath, deactivation.ToArray());
            int mapcnt = lv_HostMapping.Items.Count;
            for (int n = 0; n < mapcnt; n++)
            {
                //读进来的时候hostname就是空字符或者null的情况就不写入到hosts
                if (string.IsNullOrEmpty(lv_HostMapping.Items[n].Text))
                    continue;
                File.AppendAllText(hostsPath, lv_HostMapping.Items[n].SubItems[1].Text + "    " + lv_HostMapping.Items[n].Text+ System.Environment.NewLine);
            }*/

            //恢复文件的只读属性
            if (fa.ToString().IndexOf("readonly", StringComparison.OrdinalIgnoreCase) == -1)
            {
                fa &= FileAttributes.ReadOnly;
                File.SetAttributes(hostsPath, fa);
            }

        }

        private void btn_Record_Click(object sender, EventArgs e)
        {
            string address = txt_HostAddress.Text;
            string name = txt_HostName.Text;

            try
            {
                //如果能解析就解析，不能解析就说明是自定义的
                Uri uri = new Uri(name);
                name = uri.Host;
                txt_HostName.Text = name;
            }
            catch
            {

            }

            Match m = Regex.Match(address, @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");
            if (!m.Success || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("输入的ip或主机名不符合规则!", "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            address = m.Value;

            bool reply = PingIP(address);
            if (!reply)
            {
                MessageBox.Show(string.Format("IP:{0}侦测失败!", address), "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dgvCnt = dgv_HostMapping.Rows[0].Cells.Count;
            for (int i = 0; i < dgvCnt; i++)
            {
                if (dgv_HostMapping.Rows[0].Cells[i].Value.ToString().Equals(name))
                {
                    MessageBox.Show(string.Format("列表中已存在此主机名:{0}!", name), "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataGridViewRow dgvr = new DataGridViewRow();
            DataGridViewTextBoxCell hnCell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell ipCell = new DataGridViewTextBoxCell();
            hnCell.Value = name;
            ipCell.Value = address;
            dgvr.Cells.Add(hnCell);
            dgvr.Cells.Add(ipCell);
            dgv_HostMapping.Rows.Add(dgvr);

            txt_HostName.Text = "";
            changed = true;

            /*int cnt = lv_HostMapping.Items.Count;
            for (int i = 0; i < cnt; i++)
            {
                if (lv_HostMapping.Items[i].Text.Equals(name))
                {
                    MessageBox.Show(string.Format("列表中已存在此主机名:{0}!", name), "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ListViewItem item = new ListViewItem();
            item.Text = name;
            item.SubItems.Add(address);
            lv_HostMapping.Items.Add(item);*/
        }
        #endregion

        #region Function
        /// <summary>
        /// 初始化listview
        /// </summary>
        private void InitHostsFile()
        {
            /*lv_HostMapping.Columns.Add("HostName", lv_HostMapping.Width / 2);
            lv_HostMapping.Columns.Add("IPAddress", lv_HostMapping.Width / 2);*/

            activation = new List<string>();
            deactivation = new List<string>();
            string configPath = Application.StartupPath + @"\parameter\config.ini";
            config = cls_Config.getInstance(configPath);
            hostsPath = config.IniReadValue("SystemConfig", "HostsPath", @"C:\Windows\System32\drivers\etc\hosts");
            regexSplit = config.IniReadValue("SystemConfig", "RegexSplit", "^");

            //防止文件一开始不存在，将默认值写入到config中
            config.IniWriteValue("SystemConfig", "HostsPath", hostsPath);
            config.IniWriteValue("SystemConfig", "RegexSplit", regexSplit);

            //判断文件是否存在
            if (!File.Exists(hostsPath))
            {
                MessageBox.Show("config中指定的hosts路径不存在!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamReader sr = new StreamReader(hostsPath);
            while (!sr.EndOfStream)
            {
                activation.Add(sr.ReadLine());
            }

            for (int i = activation.Count - 1; i >= 0; i--)
            {
                string txt = activation[i];

                //判断本行是否被注释
                if (txt.StartsWith("#"))
                {
                    deactivation.Add(txt);
                    activation.Remove(txt);
                    continue;
                }

                //判断本行是否为空或者null
                if (string.IsNullOrWhiteSpace(txt))
                {
                    activation.Remove(txt);
                    continue;
                }

                //判断本行内容是否不存在ip
                MatchCollection ms = Regex.Matches(txt, @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");
                if (ms.Count <= 0)
                {
                    deactivation.Add(txt);
                    activation.Remove(txt);
                    continue;
                }

                for (int j = 0; j < ms.Count; j++)
                {
                    txt = txt.Replace(ms[j].Value, regexSplit + ms[j].Value + regexSplit);
                }

                string[] splitStr = { regexSplit };
                string[] result = txt.Split(splitStr, StringSplitOptions.None);

                for (int m = 1; m < result.Length; m += 2)
                {
                    string ip = result[m].Trim();
                    string hostName = result[m + 1].Trim();
                    if (string.IsNullOrWhiteSpace(hostName))
                        hostName = "";
                    /*ListViewItem item = new ListViewItem();
                    item.Text = hostName;
                    item.SubItems.Add(ip);
                    lv_HostMapping.Items.Add(item);*/

                    DataGridViewRow dgvr = new DataGridViewRow();
                    DataGridViewTextBoxCell hnCell = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell ipCell = new DataGridViewTextBoxCell();
                    hnCell.Value = hostName;
                    ipCell.Value = ip;
                    dgvr.Cells.Add(hnCell);
                    dgvr.Cells.Add(ipCell);
                    dgv_HostMapping.Rows.Add(dgvr);
                }
            }

            //翻转读取到的无效信息
            deactivation.Reverse();
            dgv_HostMapping.ClearSelection();
            sr.Close();
        }

        /// <summary>
        /// ping指定主机
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <returns></returns>
        private bool PingIP(string ip)
        {
            bool ret = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(ip, 1000);
                if (reply.Status == IPStatus.Success)
                    ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        #endregion

    }
}
