namespace Bank.Transactions
{
    partial class frmTransactions
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
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.cmsTransactions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDeposit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmWithdrawal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowAccountInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilterClientName = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.cbTransactionType = new System.Windows.Forms.ComboBox();
            this.btnWithdrawal = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.cmsTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AllowUserToResizeColumns = false;
            this.dgvTransactions.AllowUserToResizeRows = false;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.ContextMenuStrip = this.cmsTransactions;
            this.dgvTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 122);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 26;
            this.dgvTransactions.Size = new System.Drawing.Size(783, 493);
            this.dgvTransactions.TabIndex = 16;
            // 
            // cmsTransactions
            // 
            this.cmsTransactions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTransactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeposit,
            this.toolStripSeparator1,
            this.tsmWithdrawal,
            this.toolStripSeparator2,
            this.tsmTransfer,
            this.toolStripSeparator3,
            this.tsmShowAccountInfo});
            this.cmsTransactions.Name = "cmsEmployee";
            this.cmsTransactions.Size = new System.Drawing.Size(203, 118);
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
            // txtFilterClientName
            // 
            this.txtFilterClientName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFilterClientName.ForeColor = System.Drawing.Color.Gray;
            this.txtFilterClientName.Location = new System.Drawing.Point(12, 81);
            this.txtFilterClientName.Name = "txtFilterClientName";
            this.txtFilterClientName.Size = new System.Drawing.Size(276, 34);
            this.txtFilterClientName.TabIndex = 18;
            this.txtFilterClientName.Text = "Enter client name...";
            this.txtFilterClientName.TextChanged += new System.EventHandler(this.txtFilterClientName_TextChanged);
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTransfer.FlatAppearance.BorderSize = 0;
            this.btnTransfer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnTransfer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfer.Location = new System.Drawing.Point(661, 12);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(134, 49);
            this.btnTransfer.TabIndex = 17;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // cbTransactionType
            // 
            this.cbTransactionType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbTransactionType.FormattingEnabled = true;
            this.cbTransactionType.Items.AddRange(new object[] {
            "All",
            "Deposit",
            "Withdrawal",
            "Transfer"});
            this.cbTransactionType.Location = new System.Drawing.Point(304, 80);
            this.cbTransactionType.Name = "cbTransactionType";
            this.cbTransactionType.Size = new System.Drawing.Size(147, 36);
            this.cbTransactionType.TabIndex = 19;
            this.cbTransactionType.Text = "Transaction Type";
            this.cbTransactionType.SelectedIndexChanged += new System.EventHandler(this.cbTransactionType_SelectedIndexChanged);
            // 
            // btnWithdrawal
            // 
            this.btnWithdrawal.BackColor = System.Drawing.Color.Red;
            this.btnWithdrawal.FlatAppearance.BorderSize = 0;
            this.btnWithdrawal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnWithdrawal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnWithdrawal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdrawal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnWithdrawal.ForeColor = System.Drawing.Color.White;
            this.btnWithdrawal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWithdrawal.Location = new System.Drawing.Point(521, 12);
            this.btnWithdrawal.Name = "btnWithdrawal";
            this.btnWithdrawal.Size = new System.Drawing.Size(134, 49);
            this.btnWithdrawal.TabIndex = 20;
            this.btnWithdrawal.Text = "Withdrawal";
            this.btnWithdrawal.UseVisualStyleBackColor = false;
            this.btnWithdrawal.Click += new System.EventHandler(this.btnWithdrawal_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.BackColor = System.Drawing.Color.Green;
            this.btnDeposit.FlatAppearance.BorderSize = 0;
            this.btnDeposit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnDeposit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeposit.ForeColor = System.Drawing.Color.White;
            this.btnDeposit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeposit.Location = new System.Drawing.Point(381, 12);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(134, 49);
            this.btnDeposit.TabIndex = 21;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // frmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(807, 675);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdrawal);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.txtFilterClientName);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.cbTransactionType);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTransactions";
            this.Text = "frmTransactions";
            this.Load += new System.EventHandler(this.frmTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.cmsTransactions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.TextBox txtFilterClientName;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ComboBox cbTransactionType;
        private System.Windows.Forms.Button btnWithdrawal;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.ContextMenuStrip cmsTransactions;
        private System.Windows.Forms.ToolStripMenuItem tsmDeposit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmWithdrawal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmTransfer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmShowAccountInfo;
    }
}