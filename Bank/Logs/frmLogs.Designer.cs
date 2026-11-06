namespace Bank.Audit_Logs
{
    partial class frmLogs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.cmsLogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDeposit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmWithdrawal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowAccountInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterDescription = new System.Windows.Forms.TextBox();
            this.btnExportLogs = new System.Windows.Forms.Button();
            this.cbDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.cmsLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AllowUserToResizeColumns = false;
            this.dgvLogs.AllowUserToResizeRows = false;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.ContextMenuStrip = this.cmsLogs;
            this.dgvLogs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLogs.Location = new System.Drawing.Point(12, 122);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 26;
            this.dgvLogs.Size = new System.Drawing.Size(783, 493);
            this.dgvLogs.TabIndex = 22;
            // 
            // cmsLogs
            // 
            this.cmsLogs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeposit,
            this.toolStripSeparator1,
            this.tsmWithdrawal,
            this.toolStripSeparator2,
            this.tsmTransfer,
            this.toolStripSeparator3,
            this.tsmShowAccountInfo});
            this.cmsLogs.Name = "cmsEmployee";
            this.cmsLogs.Size = new System.Drawing.Size(203, 118);
            // 
            // tsmDeposit
            // 
            this.tsmDeposit.Name = "tsmDeposit";
            this.tsmDeposit.Size = new System.Drawing.Size(202, 24);
            this.tsmDeposit.Text = "Deposit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmWithdrawal
            // 
            this.tsmWithdrawal.Name = "tsmWithdrawal";
            this.tsmWithdrawal.Size = new System.Drawing.Size(202, 24);
            this.tsmWithdrawal.Text = "Withdrawal";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmTransfer
            // 
            this.tsmTransfer.Name = "tsmTransfer";
            this.tsmTransfer.Size = new System.Drawing.Size(202, 24);
            this.tsmTransfer.Text = "Transfer";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmShowAccountInfo
            // 
            this.tsmShowAccountInfo.Name = "tsmShowAccountInfo";
            this.tsmShowAccountInfo.Size = new System.Drawing.Size(202, 24);
            this.tsmShowAccountInfo.Text = "Show Account Info";
            // 
            // txtFilterDescription
            // 
            this.txtFilterDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFilterDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtFilterDescription.Location = new System.Drawing.Point(12, 81);
            this.txtFilterDescription.Name = "txtFilterDescription";
            this.txtFilterDescription.Size = new System.Drawing.Size(276, 34);
            this.txtFilterDescription.TabIndex = 24;
            this.txtFilterDescription.Text = "Search description...";
            this.txtFilterDescription.TextChanged += new System.EventHandler(this.txtFilterDescription_TextChanged);
            // 
            // btnExportLogs
            // 
            this.btnExportLogs.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExportLogs.FlatAppearance.BorderSize = 0;
            this.btnExportLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnExportLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnExportLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportLogs.ForeColor = System.Drawing.Color.White;
            this.btnExportLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportLogs.Location = new System.Drawing.Point(661, 12);
            this.btnExportLogs.Name = "btnExportLogs";
            this.btnExportLogs.Size = new System.Drawing.Size(134, 49);
            this.btnExportLogs.TabIndex = 23;
            this.btnExportLogs.Text = "Export Logs";
            this.btnExportLogs.UseVisualStyleBackColor = false;
            this.btnExportLogs.Click += new System.EventHandler(this.btnExportLogs_Click);
            // 
            // cbDate
            // 
            this.cbDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Items.AddRange(new object[] {
            "All",
            "Today",
            "Yesterday",
            "Last Week",
            "Last Month",
            "Last Year"});
            this.cbDate.Location = new System.Drawing.Point(304, 80);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(109, 36);
            this.cbDate.TabIndex = 25;
            this.cbDate.Text = "Date";
            this.cbDate.SelectedIndexChanged += new System.EventHandler(this.cbDate_SelectedIndexChanged);
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(807, 675);
            this.ControlBox = false;
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.txtFilterDescription);
            this.Controls.Add(this.btnExportLogs);
            this.Controls.Add(this.cbDate);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogs";
            this.Text = "frmLogs";
            this.Load += new System.EventHandler(this.frmLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.cmsLogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.ContextMenuStrip cmsLogs;
        private System.Windows.Forms.ToolStripMenuItem tsmDeposit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmWithdrawal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmTransfer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmShowAccountInfo;
        private System.Windows.Forms.TextBox txtFilterDescription;
        private System.Windows.Forms.Button btnExportLogs;
        private System.Windows.Forms.ComboBox cbDate;
    }
}