using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Security.Principal;

namespace ChangePassword
{
    public partial class frmMain : Form
    {
        DirectoryEntry objEntry;
        int intInitHeight = 130;
        int intLoginHeight = 200;
        int intDefaultFontSize = 9;

        public frmMain()
        {
            InitializeComponent();

             // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;

            // 96 corresponds to 100% font scaling (smaller), 
            // 120 corresponds to 125% scaling (medium)
            // 144 corresponds to 150%

            int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150;

            // 針對字體變更Form的大小
            intInitHeight = intInitHeight * intPercent / 100;
            intLoginHeight = intLoginHeight * intPercent / 100;

            this.Height = intInitHeight;
        }

        /// <summary>
        /// 表單讀取的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // 將認證的Domain資料放入下拉式選單之中
            cbxDomain.Items.Clear();
            DomainListObj objList = new DomainListObj();
            for (int i = 0; i < objList.Items.Count; i++)
                cbxDomain.Items.Add(objList.Items[i]);
            if (objList.Items.Count > 0)
                cbxDomain.SelectedIndex = 0;
            else
            {
                MessageBox.Show("程式中未登錄任何網域內容,請聯絡系統管理員,程式即將關閉", "未登入任何網域記錄", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        /// <summary>
        /// 登入的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserName = txtUserName.Text;
            string strPassword = txtPassword.Text;

            // 取得網域資訊
            string strAdmin = "";
            string strPwd = "";
            string strDomain = this.GetDomain(out strAdmin, out strPwd);
            string strPath = string.Format(@"WinNT://{0}/{1}, user", strDomain, strUserName);
            objEntry = new DirectoryEntry(strPath, strUserName, strPassword);

            bool blflag = true;

            try
            {
                string objectSid = (new SecurityIdentifier((byte[])objEntry.Properties["objectSid"].Value, 0).Value);
            }
            catch// (DirectoryServicesCOMException)
            {
                blflag = false;
            }
            finally
            {
                objEntry.Dispose();
            }

            if (blflag)
            {
                MessageBox.Show("登入成功", "網域登入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Height = intLoginHeight;
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtUserName.BackColor = Color.LightGray;
                txtPassword.BackColor = Color.LightGray;
                btnLogin.Visible = false;
                cbxDomain.Enabled = false;
            }
            else
            {
                MessageBox.Show("登入失敗,帳號密碼有誤", "網域登入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Height = intInitHeight;
            }
        }

        /// <summary>
        /// 變更密碼的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            // 取得網域資訊
            string strAdmin = "";
            string strPwd = "";
            string strDomain = this.GetDomain(out strAdmin, out strPwd);

            if (txtNewPassword.Text != txtNewPasswordConfirm.Text)
            {
                MessageBox.Show("新密碼確認不符,請重新輸入", "密碼變更", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool blflag = false;

                try
                {
                    // objEntry = new DirectoryEntry("LDAP://ceec.intranet/dc=ceec,dc=intranet", "Administrator", "P@ssw0rd");
                    objEntry = new DirectoryEntry("LDAP://" + strDomain, strAdmin, strPwd);
                    DirectorySearcher ADSearcher = new DirectorySearcher(objEntry);
                    ADSearcher.Filter = "(&(objectClass=user)(sAMAccountName=" + txtUserName.Text + "))";
                    SearchResult Result = ADSearcher.FindOne();
                    DirectoryEntry user = (Result != null) ? Result.GetDirectoryEntry() : null;
                    // user.Invoke("ChangePassword", new object[] { txtPassword.Text, txtNewPassword.Text }); //設密碼用"setPassword" , new object[] { pwd}   
                    user.Invoke("setPassword", new object[] { txtNewPassword.Text });
                    user.CommitChanges();
                    blflag = true;
                }
                catch (Exception ex)
                {
                    strErrMsg = ex.Message;
                    blflag = false;
                }
                finally
                {
                    objEntry.Dispose();
                }

                if (blflag)
                {
                    MessageBox.Show("密碼變更成功,程式將會自動關閉", "密碼變更", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("密碼變更失敗" + strErrMsg, "密碼變更", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 取得網域的資訊
        /// </summary>
        /// <param name="strAdmin">管理者帳號</param>
        /// <param name="strAdminPwd">管理者密碼</param>
        /// <returns></returns>
        private string GetDomain(out string strAdmin, out string strAdminPwd)
        {
            // 從下拉式選單取得值
            DomainListObj.DomainListItem objItem = (DomainListObj.DomainListItem)cbxDomain.SelectedItem;

            strAdmin = objItem.DomainAdmin;
            strAdminPwd = objItem.DomainAdminPwd;

            return objItem.DomainIP;
        }

    }
}
