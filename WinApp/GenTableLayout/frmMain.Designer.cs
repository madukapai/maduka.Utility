namespace GenTableLayout
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cbxlTable = new System.Windows.Forms.CheckedListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.diaSave = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // txtConnection
            // 
            this.txtConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnection.Location = new System.Drawing.Point(12, 12);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(488, 22);
            this.txtConnection.TabIndex = 0;
            this.txtConnection.Text = "server=172.20.25.40;uid=admin;password=adminMgr!@#$;database=edoc";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(506, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cbxlTable
            // 
            this.cbxlTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxlTable.CheckOnClick = true;
            this.cbxlTable.FormattingEnabled = true;
            this.cbxlTable.Location = new System.Drawing.Point(12, 40);
            this.cbxlTable.MultiColumn = true;
            this.cbxlTable.Name = "cbxlTable";
            this.cbxlTable.Size = new System.Drawing.Size(488, 242);
            this.cbxlTable.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(506, 259);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // diaSave
            // 
            this.diaSave.Filter = "Word檔|*.doc";
            this.diaSave.Title = "另存新檔";
            this.diaSave.FileOk += new System.ComponentModel.CancelEventHandler(this.diaSave_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 301);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cbxlTable);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtConnection);
            this.Name = "frmMain";
            this.Text = "匯出Table Layout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.CheckedListBox cbxlTable;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog diaSave;
    }
}

