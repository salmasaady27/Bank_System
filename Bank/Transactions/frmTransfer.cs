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
    public partial class frmTransfer : Form
    {

        string _SenderAccountNo;
        clsAccount _SenderAccount;
        string _ReceiverAccountNo;
        clsAccount _ReceiverAccount;


        clsTransfer _Transfer;
        public frmTransfer()
        {
            InitializeComponent();
            txtAmount.KeyPress += TypeOnlyNumbers;
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            clsUtility.SetPlaceholder(txtSenderAccountNo, "Enter Account Number");
            clsUtility.SetPlaceholder(txtReceiverAccountNo, "To Account Number");
            clsUtility.SetPlaceholder(txtAmount, "Amount");
        }
        
        private void TypeOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // For int
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtReceiverAccountNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtReceiverAccountNo.Text == txtSenderAccountNo.Text)
            {
                e.Cancel = true;
                Error.SetError(txtReceiverAccountNo, "Receiver account cannot be the same as sender account.");
                return;

            }

            _ReceiverAccountNo = txtReceiverAccountNo.Text.Trim();

            _ReceiverAccount = clsAccount.Find(_ReceiverAccountNo);
           
            if(_ReceiverAccount == null)
            {
                e.Cancel = true;
                Error.SetError(txtReceiverAccountNo, "Invalid receiver account number.");
                return;
            }

            if (!_ReceiverAccount.AccountIsActive())
            {
                e.Cancel = true;
                Error.SetError(txtReceiverAccountNo, "This account is not active.");
                return;
            }

        }
        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.Parse(txtAmount.Text) > _SenderAccount.Balance)
            {
                e.Cancel = true;
                Error.SetError(txtAmount, "Your current balance is not enough to complete this transfer.");
                return;
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSenderAccountNo.Text) || txtSenderAccountNo.ForeColor == Color.Gray)
                return;

            ctrlAccountInfoTransactionCard1.LoadAccountInfo(txtSenderAccountNo.Text);
            
            if (ctrlAccountInfoTransactionCard1.SelectedAccountInfo == null)
            {
                txtReceiverAccountNo.Enabled = false;
                txtAmount.Enabled = false;
                btnTransfer.Enabled = false;
                txtSenderAccountNo.Focus();
                return;
            }

            _SenderAccount = ctrlAccountInfoTransactionCard1.SelectedAccountInfo;
            _SenderAccountNo = _SenderAccount.AccountNumber;

            if (!_SenderAccount.AccountIsActive())
            {
                MessageBox.Show("This account is not active.", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAmount.Enabled = false;
                btnTransfer.Enabled = false;
                txtSenderAccountNo.Focus();
                return;
            }

            _Transfer = new clsTransfer();

            txtReceiverAccountNo.Enabled = true;
            txtReceiverAccountNo.Focus();

            btnTransfer.Enabled = true;
            
            txtAmount.Enabled = true;
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            _Transfer.SenderAccountID = _SenderAccount.AccountID;
            _Transfer.ReceiverAccountID = _ReceiverAccount.AccountID;
            _Transfer.Amount = decimal.Parse(txtAmount.Text);
            _Transfer.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if(_Transfer.Save())
            {
               MessageBox.Show("Transfer successful.", "Success",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Transfer,
                    $"Processed transfer of {_Transfer.Amount:N2}");

                clsGlobalEvents.RaiseTransactionCompleted();

                this.Close();
            }
            else
            {
                MessageBox.Show("Transfer failed. Please check the account balance and try again.", "Transfer Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
