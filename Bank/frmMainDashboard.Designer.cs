namespace Bank
{
    partial class frmMainDashboard
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAuditLogs = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTodayTransactions = new System.Windows.Forms.DataGridView();
            this.fuiPanel4 = new FastUI.FastUILibrary.Components.FuiPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalActiveUsers = new System.Windows.Forms.Label();
            this.fuiPanel3 = new FastUI.FastUILibrary.Components.FuiPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTodayTransactions = new System.Windows.Forms.Label();
            this.fuiPanel2 = new FastUI.FastUILibrary.Components.FuiPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAccounts = new System.Windows.Forms.Label();
            this.fuiPanel1 = new FastUI.FastUILibrary.Components.FuiPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panelSide.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayTransactions)).BeginInit();
            this.fuiPanel4.SuspendLayout();
            this.fuiPanel3.SuspendLayout();
            this.fuiPanel2.SuspendLayout();
            this.fuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.panelSide.Controls.Add(this.btnLogout);
            this.panelSide.Controls.Add(this.btnAuditLogs);
            this.panelSide.Controls.Add(this.btnEmployees);
            this.panelSide.Controls.Add(this.btnUsers);
            this.panelSide.Controls.Add(this.btnTransactions);
            this.panelSide.Controls.Add(this.btnAccounts);
            this.panelSide.Controls.Add(this.btnClients);
            this.panelSide.Controls.Add(this.splitter2);
            this.panelSide.Controls.Add(this.panelInfo);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(240, 730);
            this.panelSide.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::Bank.Properties.Resources.logout_32;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 676);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(240, 51);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAuditLogs
            // 
            this.btnAuditLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnAuditLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuditLogs.FlatAppearance.BorderSize = 0;
            this.btnAuditLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditLogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAuditLogs.ForeColor = System.Drawing.Color.White;
            this.btnAuditLogs.Image = global::Bank.Properties.Resources.login_registration_32;
            this.btnAuditLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLogs.Location = new System.Drawing.Point(0, 355);
            this.btnAuditLogs.Name = "btnAuditLogs";
            this.btnAuditLogs.Size = new System.Drawing.Size(240, 51);
            this.btnAuditLogs.TabIndex = 6;
            this.btnAuditLogs.Text = "Audit Logs";
            this.btnAuditLogs.UseVisualStyleBackColor = false;
            this.btnAuditLogs.Click += new System.EventHandler(this.btnAuditLogs_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Image = global::Bank.Properties.Resources.people_32;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(0, 304);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(240, 51);
            this.btnEmployees.TabIndex = 5;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Image = global::Bank.Properties.Resources.users_321;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 253);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(240, 51);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTransactions.ForeColor = System.Drawing.Color.White;
            this.btnTransactions.Image = global::Bank.Properties.Resources.transactions_32;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(0, 202);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(240, 51);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = false;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccounts.FlatAppearance.BorderSize = 0;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccounts.ForeColor = System.Drawing.Color.White;
            this.btnAccounts.Image = global::Bank.Properties.Resources.account_32;
            this.btnAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.Location = new System.Drawing.Point(0, 151);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(240, 51);
            this.btnAccounts.TabIndex = 2;
            this.btnAccounts.Text = "Accounts";
            this.btnAccounts.UseVisualStyleBackColor = false;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(17)))), ((int)(((byte)(79)))));
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = global::Bank.Properties.Resources.clients_32;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(0, 100);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(240, 51);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Clients";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(14)))), ((int)(((byte)(63)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 727);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(240, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelInfo.Controls.Add(this.lblCurrentDate);
            this.panelInfo.Controls.Add(this.lblUsername);
            this.panelInfo.Controls.Add(this.splitter1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(240, 100);
            this.panelInfo.TabIndex = 0;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCurrentDate.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDate.Location = new System.Drawing.Point(3, 55);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(123, 28);
            this.lblCurrentDate.TabIndex = 2;
            this.lblCurrentDate.Text = "Current Date";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(73, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(99, 28);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(14)))), ((int)(((byte)(63)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 97);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(240, 3);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(240, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(807, 55);
            this.panelHeader.TabIndex = 2;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.dgvTodayTransactions);
            this.panelMain.Controls.Add(this.fuiPanel4);
            this.panelMain.Controls.Add(this.fuiPanel3);
            this.panelMain.Controls.Add(this.fuiPanel2);
            this.panelMain.Controls.Add(this.fuiPanel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(240, 55);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(807, 675);
            this.panelMain.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(15, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Today\'s Transactions:";
            // 
            // dgvTodayTransactions
            // 
            this.dgvTodayTransactions.AllowUserToAddRows = false;
            this.dgvTodayTransactions.AllowUserToDeleteRows = false;
            this.dgvTodayTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodayTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayTransactions.Location = new System.Drawing.Point(20, 222);
            this.dgvTodayTransactions.Name = "dgvTodayTransactions";
            this.dgvTodayTransactions.ReadOnly = true;
            this.dgvTodayTransactions.RowHeadersWidth = 51;
            this.dgvTodayTransactions.RowTemplate.Height = 26;
            this.dgvTodayTransactions.Size = new System.Drawing.Size(764, 426);
            this.dgvTodayTransactions.TabIndex = 2;
            // 
            // fuiPanel4
            // 
            this.fuiPanel4.BackColor = System.Drawing.Color.Transparent;
            this.fuiPanel4.BorderColor = System.Drawing.Color.Gray;
            this.fuiPanel4.BorderWidth = 1F;
            this.fuiPanel4.ControlHeight = 77;
            this.fuiPanel4.Controls.Add(this.label4);
            this.fuiPanel4.Controls.Add(this.lblTotalActiveUsers);
            this.fuiPanel4.ControlWidth = 165;
            this.fuiPanel4.CornerRadius = 10F;
            this.fuiPanel4.FillColor = System.Drawing.Color.White;
            this.fuiPanel4.FocusedBorderColor = System.Drawing.Color.Black;
            this.fuiPanel4.HoverBorderColor = System.Drawing.Color.Gray;
            this.fuiPanel4.HoverFillColor = System.Drawing.Color.White;
            this.fuiPanel4.Location = new System.Drawing.Point(611, 45);
            this.fuiPanel4.Name = "fuiPanel4";
            this.fuiPanel4.Size = new System.Drawing.Size(165, 77);
            this.fuiPanel4.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Active Users";
            // 
            // lblTotalActiveUsers
            // 
            this.lblTotalActiveUsers.AutoSize = true;
            this.lblTotalActiveUsers.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalActiveUsers.Location = new System.Drawing.Point(13, 16);
            this.lblTotalActiveUsers.Name = "lblTotalActiveUsers";
            this.lblTotalActiveUsers.Size = new System.Drawing.Size(29, 35);
            this.lblTotalActiveUsers.TabIndex = 1;
            this.lblTotalActiveUsers.Text = "0";
            // 
            // fuiPanel3
            // 
            this.fuiPanel3.BackColor = System.Drawing.Color.Transparent;
            this.fuiPanel3.BorderColor = System.Drawing.Color.Gray;
            this.fuiPanel3.BorderWidth = 1F;
            this.fuiPanel3.ControlHeight = 77;
            this.fuiPanel3.Controls.Add(this.label3);
            this.fuiPanel3.Controls.Add(this.lblTodayTransactions);
            this.fuiPanel3.ControlWidth = 165;
            this.fuiPanel3.CornerRadius = 10F;
            this.fuiPanel3.FillColor = System.Drawing.Color.White;
            this.fuiPanel3.FocusedBorderColor = System.Drawing.Color.Black;
            this.fuiPanel3.HoverBorderColor = System.Drawing.Color.Gray;
            this.fuiPanel3.HoverFillColor = System.Drawing.Color.White;
            this.fuiPanel3.Location = new System.Drawing.Point(414, 45);
            this.fuiPanel3.Name = "fuiPanel3";
            this.fuiPanel3.Size = new System.Drawing.Size(165, 77);
            this.fuiPanel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Today\'s Transactions";
            // 
            // lblTodayTransactions
            // 
            this.lblTodayTransactions.AutoSize = true;
            this.lblTodayTransactions.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTodayTransactions.Location = new System.Drawing.Point(13, 16);
            this.lblTodayTransactions.Name = "lblTodayTransactions";
            this.lblTodayTransactions.Size = new System.Drawing.Size(29, 35);
            this.lblTodayTransactions.TabIndex = 1;
            this.lblTodayTransactions.Text = "0";
            // 
            // fuiPanel2
            // 
            this.fuiPanel2.BackColor = System.Drawing.Color.Transparent;
            this.fuiPanel2.BorderColor = System.Drawing.Color.Gray;
            this.fuiPanel2.BorderWidth = 1F;
            this.fuiPanel2.ControlHeight = 77;
            this.fuiPanel2.Controls.Add(this.label2);
            this.fuiPanel2.Controls.Add(this.lblTotalAccounts);
            this.fuiPanel2.ControlWidth = 165;
            this.fuiPanel2.CornerRadius = 10F;
            this.fuiPanel2.FillColor = System.Drawing.Color.White;
            this.fuiPanel2.FocusedBorderColor = System.Drawing.Color.Black;
            this.fuiPanel2.HoverBorderColor = System.Drawing.Color.Gray;
            this.fuiPanel2.HoverFillColor = System.Drawing.Color.White;
            this.fuiPanel2.Location = new System.Drawing.Point(217, 45);
            this.fuiPanel2.Name = "fuiPanel2";
            this.fuiPanel2.Size = new System.Drawing.Size(165, 77);
            this.fuiPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Accounts";
            // 
            // lblTotalAccounts
            // 
            this.lblTotalAccounts.AutoSize = true;
            this.lblTotalAccounts.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalAccounts.Location = new System.Drawing.Point(13, 16);
            this.lblTotalAccounts.Name = "lblTotalAccounts";
            this.lblTotalAccounts.Size = new System.Drawing.Size(29, 35);
            this.lblTotalAccounts.TabIndex = 1;
            this.lblTotalAccounts.Text = "0";
            // 
            // fuiPanel1
            // 
            this.fuiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.fuiPanel1.BorderColor = System.Drawing.Color.Gray;
            this.fuiPanel1.BorderWidth = 1F;
            this.fuiPanel1.ControlHeight = 77;
            this.fuiPanel1.Controls.Add(this.label1);
            this.fuiPanel1.Controls.Add(this.lblTotalClients);
            this.fuiPanel1.ControlWidth = 165;
            this.fuiPanel1.CornerRadius = 10F;
            this.fuiPanel1.FillColor = System.Drawing.Color.White;
            this.fuiPanel1.FocusedBorderColor = System.Drawing.Color.Black;
            this.fuiPanel1.HoverBorderColor = System.Drawing.Color.Gray;
            this.fuiPanel1.HoverFillColor = System.Drawing.Color.White;
            this.fuiPanel1.Location = new System.Drawing.Point(20, 45);
            this.fuiPanel1.Name = "fuiPanel1";
            this.fuiPanel1.Size = new System.Drawing.Size(165, 77);
            this.fuiPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Clients";
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.AutoSize = true;
            this.lblTotalClients.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalClients.Location = new System.Drawing.Point(13, 16);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(29, 35);
            this.lblTotalClients.TabIndex = 0;
            this.lblTotalClients.Text = "0";
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // frmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1047, 730);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSide);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainDashboard";
            this.Load += new System.EventHandler(this.frmMainDashboard_Load);
            this.panelSide.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayTransactions)).EndInit();
            this.fuiPanel4.ResumeLayout(false);
            this.fuiPanel4.PerformLayout();
            this.fuiPanel3.ResumeLayout(false);
            this.fuiPanel3.PerformLayout();
            this.fuiPanel2.ResumeLayout(false);
            this.fuiPanel2.PerformLayout();
            this.fuiPanel1.ResumeLayout(false);
            this.fuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAuditLogs;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblUsername;
        private FastUI.FastUILibrary.Components.FuiPanel fuiPanel4;
        private System.Windows.Forms.Label lblTotalActiveUsers;
        private FastUI.FastUILibrary.Components.FuiPanel fuiPanel3;
        private System.Windows.Forms.Label lblTodayTransactions;
        private FastUI.FastUILibrary.Components.FuiPanel fuiPanel2;
        private System.Windows.Forms.Label lblTotalAccounts;
        private FastUI.FastUILibrary.Components.FuiPanel fuiPanel1;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTodayTransactions;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}