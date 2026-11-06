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

namespace Bank.Transactions
{
    public partial class frmTransactions : Form
    {
        private static DataTable _dtAllTransactions = clsTransaction.GetAllTransactions();

        public frmTransactions()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllTransactions = clsTransaction.GetAllTransactions();
            dgvTransactions.DataSource = _dtAllTransactions;

            clsUtility.SetPlaceholder(txtFilterClientName, "Enter client name...");
            cbTransactionType.SelectedIndex = 0;
        }
        private void frmTransactions_Load(object sender, EventArgs e)
        {
            clsUtility.SetPlaceholder(txtFilterClientName, "Enter client name...");
            dgvTransactions.DataSource = _dtAllTransactions;
            cbTransactionType.SelectedIndex = 0;

            if (dgvTransactions.Rows.Count > 0)
            {
                dgvTransactions.Columns[0].HeaderText = "Transaction ID";
                dgvTransactions.Columns[0].Width = 110;

                dgvTransactions.Columns[1].HeaderText = "Client Name";
                dgvTransactions.Columns[1].Width = 110;

                dgvTransactions.Columns[2].HeaderText = "Transaction Type";
                dgvTransactions.Columns[2].Width = 120;

                dgvTransactions.Columns[3].HeaderText = "Amount";
                dgvTransactions.Columns[3].Width = 90;

                dgvTransactions.Columns[4].HeaderText = "Note";
                dgvTransactions.Columns[4].Width = 100;

                dgvTransactions.Columns[5].HeaderText = "Date";
                dgvTransactions.Columns[5].Width = 110;

                dgvTransactions.Columns[6].HeaderText = "Username";
                dgvTransactions.Columns[6].Width = 70;
            }
        }

        private void _FilterData()
        {
            string TextFilter = "";
            string TransactionTypeFilter = "";

            // Text filter - Client Name
            if (!string.IsNullOrWhiteSpace(txtFilterClientName.Text) &&
                txtFilterClientName.Text != "Enter client name...")
            {
                TextFilter = string.Format("[{0}] like '{1}%'", "ClientFullName", txtFilterClientName.Text.Trim());
            }

            // ComboBox filter - Transaction Type
            if (cbTransactionType.SelectedItem != null && cbTransactionType.Text != "All")
            {
                TransactionTypeFilter = string.Format("[{0}] = '{1}'", "TransactionType", cbTransactionType.Text);
            }

            // Combine both filters
            if (!string.IsNullOrWhiteSpace(TextFilter) && !string.IsNullOrWhiteSpace(TransactionTypeFilter))
                _dtAllTransactions.DefaultView.RowFilter = string.Format("{0} AND {1}", TextFilter, TransactionTypeFilter);

            else if (!string.IsNullOrWhiteSpace(TextFilter))
                _dtAllTransactions.DefaultView.RowFilter = TextFilter;

            else if (!string.IsNullOrWhiteSpace(TransactionTypeFilter))
                _dtAllTransactions.DefaultView.RowFilter = TransactionTypeFilter;

            else
                _dtAllTransactions.DefaultView.RowFilter = "";
        }
        private void txtFilterClientName_TextChanged(object sender, EventArgs e)
        {
            _FilterData();
        }
        private void cbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterData();
        }
        
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            frmDepositWithdrawal frm = new frmDepositWithdrawal(clsTransaction.enTransactionType.Deposit);
            frm.ShowDialog();
            _RefreshList();
        }
        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            frmDepositWithdrawal frm = new frmDepositWithdrawal(clsTransaction.enTransactionType.Withdrawal);
            frm.ShowDialog();
            _RefreshList();
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            frmTransfer frm = new frmTransfer();
            frm.ShowDialog();
            _RefreshList();
        }

    }
}
