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
        #endregion

        #region Event
        private void btn_Ping_Click(object sender, EventArgs e)
        {
            string address = txt_HostAddress.Text;
            bool reply = PingIP(address);
            if (!reply)
                MessageBox.Show(string.Format("IP:{0}侦测失败!", address), "warn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Function
        private void InitHostsFile()
        {
            lv_HostMapping.Columns.Add("HostName", lv_HostMapping.Width / 2);
            lv_HostMapping.Columns.Add("IPAddress", lv_HostMapping.Width / 2);

            activation = new List<string>();
            string configPath = Application.StartupPath + @"\parameter\config.ini";
            config = cls_Config.getInstance(configPath);
            hostsPath = config.IniReadValue("SystemConfig", "HostsPath", @"C:\Windows\System32\drivers\etc\hosts");
            regexSplit = config.IniReadValue("SystemConfig", "RegexSplit", "^");
            StreamReader sr = new StreamReader(hostsPath);
            while (!sr.EndOfStream)
            {
                activation.Add(sr.ReadLine());
            }

            for (int i = activation.Count - 1; i >= 0; i--)
            {
                string txt = activation[i];

                if (txt.StartsWith("#"))
                {
                    activation.Remove(txt);
                    continue;
                }


                if (string.IsNullOrEmpty(txt))
                {
                    activation.Remove(txt);
                    continue;
                }

                MatchCollection ms = Regex.Matches(txt, @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");
                if (ms.Count <= 0)
                {
                    activation.Remove(txt);
                    continue;
                }


                for (int j = 0; j < ms.Count; j++)
                {
                    txt = txt.Replace(ms[j].Value, regexSplit + ms[j].Value + regexSplit);
                }

                string[] splitStr = { regexSplit };
                string[] result = txt.Split(splitStr,StringSplitOptions.None);

                for (int m = 1; m < result.Length; m += 2)
                {
                    string ip = result[m].Trim();
                    string hostName = result[m + 1].Trim();
                    ListViewItem item = new ListViewItem();
                    item.Text = hostName;
                    item.SubItems.Add(ip);
                    lv_HostMapping.Items.Add(item);
                }
            }
            int cnt = activation.Count();
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
