using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenTableLayout
{
    public partial class frmMain : Form
    {
        string strErrMsg;
        StringBuilder strContent;

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 開啟資料庫連線的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            DatabaseConn objDb = new DatabaseConn(txtConnection.Text);
            DataTable objDt = objDb.GetTableList(out strErrMsg);

            for (int i = 0; i < objDt.Rows.Count; i++)
                cbxlTable.Items.Add(objDt.Rows[i]["Table_Name"].ToString(), true);
        }

        /// <summary>
        /// 匯出Word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            DatabaseConn objDb = new DatabaseConn(txtConnection.Text);

            strContent = new StringBuilder();

            CheckedListBox.CheckedItemCollection checked_items = cbxlTable.CheckedItems;


            for (int i = 0; i < checked_items.Count; i++)
            {
                string strTableName = checked_items[i].ToString();
                DataTable objColumn = objDb.GetTableColumn(strTableName);
                this.AppendTable(strContent, strTableName, objColumn, objDb);
            }

            // 寫入檔案
            diaSave.ShowDialog();
        }

        /// <summary>
        /// 放入欄位內容
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="strTableName"></param>
        /// <param name="objColumn"></param>
        private void AppendTable(StringBuilder strContent, string strTableName, DataTable objColumn, DatabaseConn objDb)
        {
            strContent.Append("<table border=\"1\">");
            strContent.Append("    <tr>");
            strContent.Append("        <td colspan=\"7\">資料表名稱:" + strTableName + "</td>");
            strContent.Append("    </tr>");
            strContent.Append("    <tr>");
            strContent.Append("        <td>欄位名稱</td>");
            strContent.Append("        <td>資料型態</td>");
            strContent.Append("        <td>長度</td>");
            strContent.Append("        <td>空值?</td>");
            strContent.Append("        <td>主鍵</td>");
            strContent.Append("        <td>外部鍵</td>");
            strContent.Append("        <td>欄位說明</td>");
            strContent.Append("    </tr>");

            for (int i = 0; i < objColumn.Rows.Count; i++)
            {
                string strConstraintName = (objColumn.Rows[i]["CONSTRAINT_NAME"].ToString() != "") ? "YES" : "";
                string strColumnName = objColumn.Rows[i]["COLUMN_NAME"].ToString();

                strContent.Append("    <tr>");
                strContent.Append("        <td>"+strColumnName+"</td>");
                strContent.Append("        <td>" + objColumn.Rows[i]["DATA_TYPE"].ToString() + "</td>");
                strContent.Append("        <td>" + objColumn.Rows[i]["Character_maximum_length"].ToString() + "</td>");
                strContent.Append("        <td>" + objColumn.Rows[i]["IS_NULLABLE"].ToString() + "?</td>");
                strContent.Append("        <td>" + strConstraintName + "</td>");
                strContent.Append("        <td></td>");
                strContent.Append("        <td>" + objDb.GetColumnDescription(strTableName, strColumnName) + "</td>");
                strContent.Append("    </tr>");

            }

            strContent.Append("</table><br><br>");
        }

        /// <summary>
        /// 選好檔案的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void diaSave_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string strFile = diaSave.FileName;
                System.IO.File.WriteAllText(strFile, strContent.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
