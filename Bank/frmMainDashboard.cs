using System;
using System.Windows.Forms;
using Bank.Clients;
using Bank.Accounts;
using Bank.Transactions;
using Bank.Users;
using Bank.Audit_Logs;
using Bank.Global_Classes;
using Bank_BusinessLayer;
using System.Data;


namespace Bank
{
    public partial class frmMainDashboard : Form
    {
        frmLogin _frmLogin;

        private static DataTable _dtTodayTransactions = clsTransaction.GetTodayTransactions();
        public frmMainDashboard(frmLogin _from)
        {
            InitializeComponent();
            _frmLogin = _from;
        }
        public void LoadForm(object form)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.Clear();

            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(f);
            this.panelMain.Tag = f;
            f.Show();
        }


        private void btnClients_Click(object sender, EventArgs e)
        {
            LoadForm(new frmClients());
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            LoadForm(new frmAccounts());
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            LoadForm(new frmTransactions());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadForm(new frmUsers());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            LoadForm(new frmEmployees());

        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            LoadForm(new frmLogs());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Logout, $"Successful logout");
            
            clsGlobalEvents.RaiseActionCompleted();

            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void _RefreshTodayTransactions()
        {
            _dtTodayTransactions = clsTransaction.GetTodayTransactions();
            dgvTodayTransactions.DataSource = _dtTodayTransactions;

            if (dgvTodayTransactions.Rows.Count >= 0)
            {
                dgvTodayTransactions.Columns[0].HeaderText = "Transaction ID";
                dgvTodayTransactions.Columns[0].Width = 110;

                dgvTodayTransactions.Columns[1].HeaderText = "Client Name";
                dgvTodayTransactions.Columns[1].Width = 110;

                dgvTodayTransactions.Columns[2].HeaderText = "Transaction Type";
                dgvTodayTransactions.Columns[2].Width = 120;

                dgvTodayTransactions.Columns[3].HeaderText = "Amount";
                dgvTodayTransactions.Columns[3].Width = 80;

                dgvTodayTransactions.Columns[4].HeaderText = "Note";
                dgvTodayTransactions.Columns[4].Width = 100;

                dgvTodayTransactions.Columns[5].HeaderText = "Date";
                dgvTodayTransactions.Columns[5].Width = 110;

                dgvTodayTransactions.Columns[6].HeaderText = "Username";
                dgvTodayTransactions.Columns[6].Width = 80;
            }
            clsGlobalEvents.TransactionCompleted += (s, args) => _RefreshTodayTransactions();
        }
       
        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            lblUsername.Text = clsGlobal.CurrentUser.UserName;

            lblTotalClients.Text = clsClient.GetTotalClients().ToString();
            lblTotalAccounts.Text = clsAccount.GetTotalAccounts().ToString();
            lblTotalActiveUsers.Text = clsUser.GetTotalActiveUsers().ToString();
            lblTodayTransactions.Text = clsTransaction.CountTodayTransactions().ToString();

            _RefreshTodayTransactions();

            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToString("ddd, dd MMM yyyy, hh:mm:ss tt");
        }
    }
}
