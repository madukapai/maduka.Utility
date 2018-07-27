using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCaller
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 放上文字的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 呼叫API的動作
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strHttpMethod"></param>
        /// <param name="strPostContent"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected string CallAPI(string strUrl, string strHttpMethod, string strPostContent, out HttpStatusCode code)
        {
            HttpWebRequest request = HttpWebRequest.Create(strUrl) as HttpWebRequest;
            request.Method = strHttpMethod;
            code = HttpStatusCode.OK;

            if (strPostContent != "" && strPostContent != string.Empty && strHttpMethod.ToLower() != "get")
            {
                request.KeepAlive = true;
                request.ContentType = "application/json";

                byte[] bs = Encoding.UTF8.GetBytes(strPostContent);
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(bs, 0, bs.Length);
            }

            string strReturn = "";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    strReturn = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
            }
            catch (Exception e)
            {
                strReturn = e.Message;
                code = HttpStatusCode.NotFound;
            }

            return strReturn;
        }

        /// <summary>
        /// 呼叫API的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                var obj = JsonConvert.DeserializeObject(txtInput.Text);
                txtInput.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
            }

            HttpStatusCode code = HttpStatusCode.OK;
            string strResponse = this.CallAPI(txtUrl.Text, cbxMethod.Text, txtInput.Text, out code);
            txtSource.Text = strResponse;

            try
            {
                var output = JsonConvert.DeserializeObject(strResponse);
                txtOutput.Text = JsonConvert.SerializeObject(output, Formatting.Indented);
            }
            catch (Exception ex)
            {
                txtOutput.Text = ex.Message;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbxMethod.SelectedIndex = 0;
        }
    }
}
