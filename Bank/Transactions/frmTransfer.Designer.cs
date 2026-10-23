namespace Bank.Transactions
{
    partial class frmTransfer
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtSenderAccountNo = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtReceiverAccountNo = new System.Windows.Forms.TextBox();
            this.ctrlAccountInfoTransactionCard1 = new Bank.Accounts.Control.ctrlAccountInfoTransactionCard();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAmount.ForeColor = System.Drawing.Color.Gray;
            this.txtAmount.Location = new System.Drawing.Point(12, 179);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(312, 34);
            this.txtAmount.TabIndex = 31;
            this.txtAmount.Text = "Amount";
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount_Validating);
            // 
            // txtSenderAccountNo
            // 
            this.txtSenderAccountNo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSenderAccountNo.ForeColor = System.Drawing.Color.Gray;
            this.txtSenderAccountNo.Location = new System.Drawing.Point(12, 12);
            this.txtSenderAccountNo.Name = "txtSenderAccountNo";
            this.txtSenderAccountNo.Size = new System.Drawing.Size(312, 34);
            this.txtSenderAccountNo.TabIndex = 29;
            this.txtSenderAccountNo.Text = "Enter Account Number";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTransfer.Enabled = false;
            this.btnTransfer.FlatAppearance.BorderSize = 0;
            this.btnTransfer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnTransfer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfer.Location = new System.Drawing.Point(269, 219);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(146, 36);
            this.btnTransfer.TabIndex = 28;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(175, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 36);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(330, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtReceiverAccountNo
            // 
            this.txtReceiverAccountNo.Enabled = false;
            this.txtReceiverAccountNo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReceiverAccountNo.ForeColor = System.Drawing.Color.Gray;
            this.txtReceiverAccountNo.Location = new System.Drawing.Point(12, 139);
            this.txtReceiverAccountNo.Name = "txtReceiverAccountNo";
            this.txtReceiverAccountNo.Size = new System.Drawing.Size(312, 34);
            this.txtReceiverAccountNo.TabIndex = 33;
            this.txtReceiverAccountNo.Text = "To Account Number";
            this.txtReceiverAccountNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtReceiverAccountNo_Validating);
            // 
            // ctrlAccountInfoTransactionCard1
            // 
            this.ctrlAccountInfoTransactionCard1.Location = new System.Drawing.Point(12, 58);
            this.ctrlAccountInfoTransactionCard1.Name = "ctrlAccountInfoTransactionCard1";
            this.ctrlAccountInfoTransactionCard1.Size = new System.Drawing.Size(312, 75);
            this.ctrlAccountInfoTransactionCard1.TabIndex = 32;
            // 
            // frmTransfer
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(428, 267);
            this.ControlBox = false;
            this.Controls.Add(this.txtReceiverAccountNo);
            this.Controls.Add(this.ctrlAccountInfoTransactionCard1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSenderAccountNo);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtSenderAccountNo;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider Error;
        private System.Windows.Forms.TextBox txtReceiverAccountNo;
        private Accounts.Control.ctrlAccountInfoTransactionCard ctrlAccountInfoTransactionCard1;
        private System.Windows.Forms.Button btnSearch;
    }
}