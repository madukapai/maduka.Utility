namespace WindowsAccountGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.gvAccount = new System.Windows.Forms.DataGridView();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gvGroup = new System.Windows.Forms.DataGridView();
            this.btnBatchReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResetPwd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DONTEXPIRE = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComputerName
            // 
            this.txtComputerName.Location = new System.Drawing.Point(93, 12);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(97, 22);
            this.txtComputerName.TabIndex = 0;
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(273, 40);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "取得資料";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // gvAccount
            // 
            this.gvAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ResetPwd,
            this.DONTEXPIRE});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAccount.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvAccount.Location = new System.Drawing.Point(12, 68);
            this.gvAccount.Name = "gvAccount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvAccount.RowTemplate.Height = 24;
            this.gvAccount.Size = new System.Drawing.Size(591, 226);
            this.gvAccount.TabIndex = 5;
            this.gvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAccount_CellClick);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(288, 12);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(100, 22);
            this.txtAccount.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(487, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(116, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // gvGroup
            // 
            this.gvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvGroup.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvGroup.Location = new System.Drawing.Point(12, 300);
            this.gvGroup.Name = "gvGroup";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvGroup.RowTemplate.Height = 24;
            this.gvGroup.Size = new System.Drawing.Size(591, 243);
            this.gvGroup.TabIndex = 2;
            // 
            // btnBatchReset
            // 
            this.btnBatchReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchReset.Location = new System.Drawing.Point(354, 40);
            this.btnBatchReset.Name = "btnBatchReset";
            this.btnBatchReset.Size = new System.Drawing.Size(249, 23);
            this.btnBatchReset.TabIndex = 4;
            this.btnBatchReset.Text = "批次重置為密碼不得永久有效且馬上過期";
            this.btnBatchReset.UseVisualStyleBackColor = true;
            this.btnBatchReset.Click += new System.EventHandler(this.btnBatchReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "網域控制站IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aministrator帳號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Aministrator密碼";
            // 
            // ResetPwd
            // 
            this.ResetPwd.HeaderText = "強制過期";
            this.ResetPwd.Name = "ResetPwd";
            this.ResetPwd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ResetPwd.Text = "";
            this.ResetPwd.ToolTipText = "強制過期";
            this.ResetPwd.Width = 60;
            // 
            // DONTEXPIRE
            // 
            this.DONTEXPIRE.HeaderText = "設定帳號密碼不得為永久有效";
            this.DONTEXPIRE.Name = "DONTEXPIRE";
            this.DONTEXPIRE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DONTEXPIRE.ToolTipText = "設定帳號密碼不得為永久有效";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 555);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBatchReset);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.gvGroup);
            this.Controls.Add(this.gvAccount);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtComputerName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "網域帳號過期重置工具";
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DataGridView gvAccount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridView gvGroup;
        private System.Windows.Forms.Button btnBatchReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn ResetPwd;
        private System.Windows.Forms.DataGridViewButtonColumn DONTEXPIRE;
    }
}

