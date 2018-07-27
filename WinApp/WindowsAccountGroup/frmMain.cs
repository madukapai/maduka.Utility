using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;

namespace WindowsAccountGroup
{
    public partial class frmMain : Form
    {
        DataTable objUser;
        DataTable objGroup;
        DataSet objDs;

        public frmMain()
        {
            InitializeComponent();
            objUser = new DataTable();
            objUser.Columns.Add("User");
            objUser.Columns.Add("State");
            objUser.Columns.Add("Expired");
            objUser.Columns.Add("DONTEXPIRE");
            objUser.Columns.Add("Description");

            objGroup = new DataTable();
            objGroup.Columns.Add("Group");
            objGroup.Columns.Add("Users");

            objDs = new DataSet();
            objDs.Tables.Add(objUser);
            objDs.Tables.Add(objGroup);
        }

        /// <summary>
        /// 取得指定的電腦帳號與群組資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGet_Click(object sender, EventArgs e)
        {
            objGroup.Rows.Clear();
            objUser.Rows.Clear();

            string strQuery = "WinNT://" + txtComputerName.Text;
            DirectoryEntry objAD = new DirectoryEntry(strQuery, txtAccount.Text, txtPassword.Text);

            DirectorySearcher ds = new DirectorySearcher(objAD);

            string strOutput = "";

            foreach (DirectoryEntry objChildDE in objAD.Children)
            {
                if (objChildDE.SchemaClassName == "User")
                {
                    int intFlag = (int)objChildDE.Properties["UserFlags"].Value;
                    string strState = (!Convert.ToBoolean(intFlag & 0x2)) ? "" : "停用";
                    string strExpired = objChildDE.Properties["PasswordExpired"].Value.ToString();                    
                    string strDONTEXPIRE = (!Convert.ToBoolean(intFlag & 0x10000)) ? "" : "密碼永久有效";
                    string strDescription = objChildDE.Properties["Description"].Value.ToString(); 

                    DataRow objDr = objUser.NewRow();
                    objDr["User"] = objChildDE.Name;
                    objDr["State"] = strState;
                    objDr["Expired"] = strExpired;
                    objDr["DONTEXPIRE"] = strDONTEXPIRE;
                    objDr["Description"] = strDescription;
                    objUser.Rows.Add(objDr);
                }

                if (objChildDE.SchemaClassName == "Group")
                {
                    string strGroupName = objChildDE.Name;

                    using (DirectoryEntry groupEntry = new DirectoryEntry("WinNT://" + txtComputerName.Text + "/" + strGroupName + ",group"))
                    {
                        foreach (object member in (IEnumerable)groupEntry.Invoke("Members"))
                        {
                            using (DirectoryEntry memberEntry = new DirectoryEntry(member))
                            {
                                DataRow objDr = objGroup.NewRow();
                                objDr["Group"] = strGroupName;
                                objDr["Users"] = memberEntry.Name;
                                objGroup.Rows.Add(objDr);
                            }
                        }
                    }
                }
            }

            gvAccount.DataSource = objDs.Tables[0];
            gvGroup.DataSource = objDs.Tables[1];
        }

        /// <summary>
        /// 點選Button的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                string strAccount = gvAccount.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (e.ColumnIndex == 0)
                {
                    using (DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + txtComputerName.Text + "/" + strAccount + ",user", txtAccount.Text, txtPassword.Text))
                    {
                        // 先設定帳號密碼不得為永久有效
                        int intFlag = (int)userEntry.Properties["UserFlags"].Value;
                        if (Convert.ToBoolean(intFlag & 0x10000))
                            userEntry.Properties["UserFlags"].Value = (int)userEntry.Properties["UserFlags"].Value - 65536;

                        // 設定密碼過期
                        userEntry.Invoke("Put", "PasswordExpired", 1);
                        userEntry.CommitChanges();
                    }

                    MessageBox.Show(strAccount + "重設成功");
                }

                if (e.ColumnIndex == 1)
                {
                    using (DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + txtComputerName.Text + "/" + strAccount + ",user", txtAccount.Text, txtPassword.Text))
                    {
                        // 設定帳號密碼不得為永久有效
                        int intFlag = (int)userEntry.Properties["UserFlags"].Value;
                        if (Convert.ToBoolean(intFlag & 0x10000))
                        {
                            userEntry.Properties["UserFlags"].Value = (int)userEntry.Properties["UserFlags"].Value - 65536;
                            userEntry.CommitChanges();
                        }
                    }

                    MessageBox.Show(strAccount + "已更改帳號密碼過期設定");
                }
            }
        }

        /// <summary>
        /// 整批重設的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvAccount.Rows.Count - 1; i++)
            {
                string strAccount = gvAccount.Rows[i].Cells[2].Value.ToString();

                // 如果帳號是啟用狀態
                if (gvAccount.Rows[i].Cells[3].Value.ToString() == "")
                {
                    using (DirectoryEntry userEntry = new DirectoryEntry("WinNT://" + txtComputerName.Text + "/" + strAccount + ",user", txtAccount.Text, txtPassword.Text))
                    {
                        // 先設定帳號密碼不得為永久有效
                        int intFlag = (int)userEntry.Properties["UserFlags"].Value;
                        if (Convert.ToBoolean(intFlag & 0x10000))
                            userEntry.Properties["UserFlags"].Value = (int)userEntry.Properties["UserFlags"].Value - 65536;

                        // 設定密碼過期
                        userEntry.Invoke("Put", "PasswordExpired", 1);
                        userEntry.CommitChanges();
                    }
                }
            }

            MessageBox.Show("完成整批密碼重置");
        }
    }
}
