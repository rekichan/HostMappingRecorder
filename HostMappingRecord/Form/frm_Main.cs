using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace HostMappingRecord
{
    public partial class frm_Main : Form
    {

        #region Properties
        private cls_Config config;
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
            config = cls_Config.getInstance();
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
