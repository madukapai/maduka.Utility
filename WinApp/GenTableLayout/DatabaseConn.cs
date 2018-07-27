using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GenTableLayout
{
    public class DatabaseConn
    {
        public string ConnectionString { get; set; }

        /// <summary>
        /// 建立資料庫連線物件的動作
        /// </summary>
        /// <param name="strConnection">連線字串</param>
        public DatabaseConn(string strConnection)
        {
            this.ConnectionString = strConnection;
        }

        /// <summary>
        /// 取得資料表清單
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableList(out string strErrMsg)
        {
            strErrMsg = "";

            string strSql = "Select * From Information_Schema.Tables where table_type = 'BASE TABLE' Order by Table_Name";
            DataTable objDt = new DataTable();

            SqlConnection SqlConn = new SqlConnection(this.ConnectionString);
            SqlCommand SqlCmd = new SqlCommand(strSql, SqlConn);
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);

            try
            {
                SqlAdp.Fill(objDt);
            }
            catch (Exception e)
            {
                strErrMsg = e.Message;
            }
            finally
            {
                SqlConn = null;
                SqlCmd = null;
                SqlAdp = null;
            }

            return objDt;
        }

        /// <summary>
        /// 取得欄位的中文說明
        /// </summary>
        /// <param name="strTable">資料表名稱</param>
        /// <param name="strColumn">欄位名稱</param>
        /// <returns></returns>
        public string GetColumnDescription(string strTable, string strColumn)
        {
            string strSql = @"Select ep.value AS PropertyValue 
            from sys.objects o INNER JOIN sys.extended_properties ep
            ON o.object_id = ep.major_id
            INNER JOIN sys.schemas s
            ON o.schema_id = s.schema_id
            LEFT JOIN syscolumns c
            ON ep.minor_id = c.colid
            AND ep.major_id = c.id
            WHERE o.type IN ('V', 'U', 'P') And c.name = @ColumnName And o.name = @TableName";

            SqlConnection SqlConn = new SqlConnection(this.ConnectionString);
            SqlCommand SqlCmd = new SqlCommand(strSql, SqlConn);
            SqlCmd.Parameters.AddWithValue("@ColumnName", strColumn);
            SqlCmd.Parameters.AddWithValue("@TableName", strTable);

            SqlCmd.Connection.Open();
            object objDesc = SqlCmd.ExecuteScalar();
            SqlCmd.Connection.Close();

            string strDescription = (objDesc != null) ? objDesc.ToString() : "";

            return strDescription;
        }

        /// <summary>
        /// 取得資料表的欄位
        /// </summary>
        /// <param name="strTableName">資料表的名稱</param>
        /// <returns></returns>
        public DataTable GetTableColumn(string strTableName)
        {
            string strSql = @"Select c.COLUMN_NAME, c.Character_maximum_length, c.ORDINAL_POSITION, c.IS_NULLABLE, c.DATA_TYPE, cu.CONSTRAINT_NAME
            from INFORMATION_SCHEMA.COLUMNS c LEft Outer Join INFORMATION_SCHEMA.KEY_COLUMN_USAGE cu
            On c.COLUMN_NAME = cu.COLUMN_NAME
            And c.TABLE_NAME = cu.TABLE_NAME
            And c.TABLE_CATALOG = cu.TABLE_CATALOG
            and c.TABLE_SCHEMA = cu.TABLE_SCHEMA
            Where c.TABLE_NAME = @TableName";

            DataTable objDt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(this.ConnectionString);
            SqlCommand SqlCmd = new SqlCommand(strSql, SqlConn);
            SqlCmd.Parameters.AddWithValue("@TableName", strTableName);
            SqlDataAdapter SqlAdp = new SqlDataAdapter(SqlCmd);

            try
            {
                SqlAdp.Fill(objDt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                SqlCmd = null;
                SqlConn = null;
                SqlAdp = null;
            }

            // 放入說明描述
            objDt.Columns.Add("Description");
            DatabaseConn objDb = new DatabaseConn(this.ConnectionString);
            for (int i = 0; i < objDt.Rows.Count; i++)
            {
                string strDescription = objDb.GetColumnDescription(strTableName, objDt.Rows[i]["COLUMN_NAME"].ToString());
                objDt.Rows[i]["Description"] = (strDescription == "") ? objDt.Rows[i]["COLUMN_NAME"].ToString() : strDescription;
            }

            objDb = null;

            return objDt;
        }
    }
}
