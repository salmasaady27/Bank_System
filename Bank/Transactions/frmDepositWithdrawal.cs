using Bank.Global_Classes;
using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Transactions
{
    public partial class frmDepositWithdrawal : Form
    {
        clsTransaction.enTransactionType _TransactionType;
        clsTransaction _Transaction;

        string _AccountNo;
        clsAccount _Account;
        public frmDepositWithdrawal(clsTransaction.enTransactionType TransactionType)
        {
            InitializeComponent();
            _TransactionType = TransactionType;
            txtAmount.KeyPress += TypeOnlyNumbers;
        }
        private void frmDepositWithdrawal_Load(object sender, EventArgs e)
        {
            if(_TransactionType == clsTransaction.enTransactionType.Deposit)
                btnProcess.Text = "Deposit";
            else
                btnProcess.Text = "Withdrawal";

            clsUtility.SetPlaceholder(txtAccountNo, "Enter Account No");
            clsUtility.SetPlaceholder(txtAmount, "Amount");
        }
        private void frmDepositWithdrawal_Shown(object sender, EventArgs e)
        {
            txtAccountNo.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountNo.Text) || txtAccountNo.ForeColor == Color.Gray)
                return;

            ctrlAccountInfoTransactionCard1.LoadAccountInfo(txtAccountNo.Text);

            if (ctrlAccountInfoTransactionCard1.SelectedAccountInfo == null)
            {
                txtAmount.Enabled = false;
                btnProcess.Enabled = false;
                txtAccountNo.Focus();
                return;
            }

            _Account = ctrlAccountInfoTransactionCard1.SelectedAccountInfo;
            _AccountNo = _Account.AccountNumber;
            
            if(!_Account.AccountIsActive())
            {
                MessageBox.Show("This account is not active.", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAmount.Enabled = false;
                btnProcess.Enabled = false;
                txtAccountNo.Focus();
                return;
            }

            _Transaction = new clsTransaction();

            txtAmount.Enabled = true;
            txtAmount.Focus();
            btnProcess.Enabled = true;
        }
        private void TypeOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // For int
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if(_TransactionType == clsTransaction.enTransactionType.Withdrawal)
            {
                if (decimal.Parse(txtAmount.Text) > _Account.Balance)
                {
                    e.Cancel = true;
                    Error.SetError(txtAmount, "Your current balance is not enough to complete this withdrawal.");
                    return;
                }
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            _Transaction.AccountID = _Account.AccountID;
            _Transaction.TransactionTypeID = (int)_TransactionType;
            _Transaction.Amount = decimal.Parse(txtAmount.Text);
            _Transaction.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!_Transaction.Save())
            {
                MessageBox.Show("Transaction failed. Please check the account balance and try again.", "Transaction Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_TransactionType == clsTransaction.enTransactionType.Deposit)
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Deposit,
                    $"Processed deposit of {_Transaction.Amount:N2}");
                
                MessageBox.Show("Deposit completed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Withdrawal,
                    $"Processed withdrawal of {_Transaction.Amount:N2}");

                MessageBox.Show("Withdrawal completed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            clsGlobalEvents.RaiseTransactionCompleted();

            this.Close();
        }
    }
}
