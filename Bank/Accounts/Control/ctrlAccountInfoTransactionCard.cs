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

namespace Bank.Accounts.Control
{
    public partial class ctrlAccountInfoTransactionCard : UserControl
    {
        string _AccountNo;
        clsAccount _Account;

        public string AccountNo { get { return _AccountNo; } }
        public clsAccount SelectedAccountInfo { get { return _Account; } }
        public ctrlAccountInfoTransactionCard()
        {
            InitializeComponent();
        }

        private void _FillAccountInfo()
        {
            _AccountNo = _Account.AccountNumber;
            lblFullName.Text = _Account.ClientInfo.FullName;
            lblAccountType.Text = _Account.AccountTypeInfo.TypeName;
            lblAvailableBalance.Text = _Account.Balance.ToString();
        }

        private void _ResetDefaultValues()
        {
            lblFullName.Text = "Full Name";
            lblAccountType.Text = "Account Type";
            lblAvailableBalance.Text = "Balance";
        }
        public void LoadAccountInfo(string AccountNo)
        {
            _Account = clsAccount.Find(AccountNo);
            if (_Account == null)
            {
                _ResetDefaultValues();
                MessageBox.Show($"No Account with Number = {AccountNo}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillAccountInfo();
        }
    }
}
