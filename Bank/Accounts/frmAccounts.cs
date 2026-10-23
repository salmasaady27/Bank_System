using Bank.Clients;
using Bank.Global_Classes;
using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bank_BusinessLayer.clsAccount;

namespace Bank.Accounts
{
    public partial class frmAccounts : Form
    {
        private static DataTable _dtAllAccounts = clsAccount.GetAllAccounts();

        public frmAccounts()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllAccounts = clsAccount.GetAllAccounts();
            dgvAccounts.DataSource = _dtAllAccounts;
            
            clsUtility.SetPlaceholder(txtFilterAccountNumber, "Enter your account number...");
            cbAccountType.SelectedIndex = 0;

        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            
            clsUtility.SetPlaceholder(txtFilterAccountNumber, "Enter your account number...");
            dgvAccounts.DataSource = _dtAllAccounts;
            //cbAccountType.SelectedIndex = 0;

            if (dgvAccounts.Rows.Count > 0)
            {
                dgvAccounts.Columns[0].HeaderText = "Account No";
                dgvAccounts.Columns[0].Width = 100;

                dgvAccounts.Columns[1].HeaderText = "Client Name";
                dgvAccounts.Columns[1].Width = 130;

                dgvAccounts.Columns[2].HeaderText = "Account Type";
                dgvAccounts.Columns[2].Width = 100;

                dgvAccounts.Columns[3].HeaderText = "Balance";
                dgvAccounts.Columns[3].Width = 90;

                dgvAccounts.Columns[4].HeaderText = "OpenDate";
                dgvAccounts.Columns[4].Width = 110;

                dgvAccounts.Columns[5].HeaderText = "Status";
                dgvAccounts.Columns[5].Width = 80;

                dgvAccounts.Columns[6].HeaderText = "Created By";
                dgvAccounts.Columns[6].Width = 100;

            }


            clsGlobalEvents.TransactionCompleted += (s, args) => _RefreshList();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddAccount frm = new frmAddAccount((int)dgvAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int AccountID = (int)dgvAccounts.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are you sure you want to delete account [{AccountID}]", "Confirm Delete",
                                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsAccount.Delete(AccountID))
                {
                    MessageBox.Show("Account has been deleted Successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshList();
                }
                else
                    MessageBox.Show("Account is not deleted due to data connected to it.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            frmAddAccount frm = new frmAddAccount();
            frm.ShowDialog();
            _RefreshList();
        }

        private void _FilterData()
        {
            string TextFilter = "";
            string AccountTypeFilter = "";

            // Text filter
            if (!string.IsNullOrWhiteSpace(txtFilterAccountNumber.Text) &&
                txtFilterAccountNumber.Text != "Enter your account number...")
            {
                TextFilter = string.Format("[{0}] like '{1}%'", "AccountNumber", txtFilterAccountNumber.Text.Trim());
            }

            // ComboBox filter
            if (cbAccountType.SelectedItem != null && cbAccountType.Text != "All")
            {
                AccountTypeFilter = string.Format("[{0}] = '{1}'", "AccountType", cbAccountType.Text);
            }

            // Combine both filters
            if (!string.IsNullOrWhiteSpace(TextFilter) && !string.IsNullOrWhiteSpace(AccountTypeFilter))
                _dtAllAccounts.DefaultView.RowFilter = string.Format("{0} AND {1}", TextFilter, AccountTypeFilter);

            else if (!string.IsNullOrWhiteSpace(TextFilter))
                _dtAllAccounts.DefaultView.RowFilter = TextFilter;

            else if (!string.IsNullOrWhiteSpace(AccountTypeFilter))
                _dtAllAccounts.DefaultView.RowFilter = AccountTypeFilter;

            else
                _dtAllAccounts.DefaultView.RowFilter = "";
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void cbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon!", "Show Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
