using Bank.Global_Classes;
using Bank_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace Bank.Accounts
{
    public partial class frmAddAccount : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _ClientID;
        private clsClient _Client;
        private int _AccountID;
        private clsAccount _Account;
        public frmAddAccount()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

            txtClientID.KeyPress += TypeOnlyNumbers;
            txtBalance.KeyPress += TypeOnlyNumbers;
        }

        public frmAddAccount(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
            _Mode = enMode.Update;
            btnAddAccount.Text = "Update Account";

            txtClientID.KeyPress += TypeOnlyNumbers;
            txtBalance.KeyPress += TypeOnlyNumbers;

        }

        private void TypeOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // For int
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _ResetDefaultValues()
        {
            clsUtility.SetPlaceholder(txtClientID, "Enter Client ID");
            clsUtility.SetPlaceholder(txtBalance, "Balance");
            cbAccountType.SelectedIndex = 1;
        }

        private void _LoadData()
        {
            _Account = clsAccount.Find(_AccountID);
            if(_Account == null)
            {
                MessageBox.Show($"No Account with ID = {_AccountID}", "Account Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //cbAccountType.SelectedIndex = cbAccountType.FindString(_Account.AccountType.Trim());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            //if (_Mode == enMode.Update) _LoadData();
        }

        private void frmAddAccount_Shown(object sender, EventArgs e)
        {
            txtClientID.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClientID.Text) || txtClientID.ForeColor == Color.Gray)
                return;

            _ClientID = Convert.ToInt32(txtClientID.Text);
            _Client = clsClient.Find(_ClientID);

            if (_Client == null) 
            {
                MessageBox.Show($"No Client with this ID = {_ClientID}", "Client Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                _FocusOnClientIDTextBox();
                return;
            }

            _Account = new clsAccount();

            lblClientName.Text = _Client.FullName;
            lblClientName.ForeColor = Color.Green;
            gpAccountInfo.Enabled = true;


            _SetUIAfterClientVerified();

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            int AccountTypeID = clsAccountType.Find(cbAccountType.Text).AccountTypeID;

            if (clsAccount.ClientHasAccountType(_ClientID, AccountTypeID))
            {
                MessageBox.Show("This client already has an account of this type.", "Duplicate Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Account.ClientID = _ClientID;
            _Account.Balance = Convert.ToDecimal(txtBalance.Text);
            _Account.AccountTypeID = AccountTypeID;
            _Account.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Account.Save())
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.CreateAccount, $"Opened new account with ID '{_Account.AccountID}'");
                
                MessageBox.Show($"Account added successfully!\nAccount ID = {_Account.AccountID}",
                     "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
                clsGlobalEvents.RaiseActionCompleted();
                
                this.Close();
            }
            else
                MessageBox.Show("Failed to save account. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            txtClientID.Enabled = true;
            btnSearch.Enabled = true;
            btnReset.Enabled = false;

            txtClientID.Focus();
            btnAddAccount.Enabled = false;
            gpAccountInfo.Enabled = false;

            lblClientName.Text = "Client's Name";
            lblClientName.ForeColor = Color.Green;
        }

        private void _SetUIAfterClientVerified()
        {
            btnSearch.Enabled = false;
            txtClientID.Enabled = false;

            btnReset.Enabled = true;
            btnAddAccount.Enabled = true;
            gpAccountInfo.Enabled = true;
        }

        private void _FocusOnClientIDTextBox()
        {
            txtClientID.Text = string.Empty;
            txtClientID.Focus();

            gpAccountInfo.Enabled = false;

            btnAddAccount.Enabled = false;

            lblClientName.Text = "Client's Name";
            lblClientName.ForeColor = Color.Green;
        }
    }
}
