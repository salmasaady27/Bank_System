namespace Bank.Accounts.Control
{
    partial class ctrlAccountInfoTransactionCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpAccountInfo = new System.Windows.Forms.GroupBox();
            this.lblAvailableBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.gpAccountInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpAccountInfo
            // 
            this.gpAccountInfo.Controls.Add(this.lblAvailableBalance);
            this.gpAccountInfo.Controls.Add(this.label1);
            this.gpAccountInfo.Controls.Add(this.lblAccountType);
            this.gpAccountInfo.Controls.Add(this.lblFullName);
            this.gpAccountInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpAccountInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gpAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.gpAccountInfo.Name = "gpAccountInfo";
            this.gpAccountInfo.Size = new System.Drawing.Size(349, 77);
            this.gpAccountInfo.TabIndex = 0;
            this.gpAccountInfo.TabStop = false;
            this.gpAccountInfo.Text = "Account Info";
            // 
            // lblAvailableBalance
            // 
            this.lblAvailableBalance.AutoSize = true;
            this.lblAvailableBalance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAvailableBalance.Location = new System.Drawing.Point(245, 49);
            this.lblAvailableBalance.Name = "lblAvailableBalance";
            this.lblAvailableBalance.Size = new System.Drawing.Size(69, 23);
            this.lblAvailableBalance.TabIndex = 3;
            this.lblAvailableBalance.Text = "Balance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(216, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available Balance";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccountType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAccountType.Location = new System.Drawing.Point(7, 49);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(98, 20);
            this.lblAccountType.TabIndex = 1;
            this.lblAccountType.Text = "Account Type";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFullName.Location = new System.Drawing.Point(7, 26);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(87, 23);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Full Name";
            // 
            // ctrlAccountInfoTransactionCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpAccountInfo);
            this.Name = "ctrlAccountInfoTransactionCard";
            this.Size = new System.Drawing.Size(349, 77);
            this.gpAccountInfo.ResumeLayout(false);
            this.gpAccountInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpAccountInfo;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAvailableBalance;
    }
}
