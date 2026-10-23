using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank.Global_Classes;
using Bank_BusinessLayer;

namespace Bank.Users
{
    public partial class frmResetPassword : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmResetPassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            txtCurrentPassword.Tag = "Current Password";
            txtNewPassword.Tag = "New Password";
            txtConfirmPassword.Tag = "Confirm Password";

            txtCurrentPassword.Enter += ChangePasswordCharactersIntoStars;
            txtCurrentPassword.Leave += ReturnPasswordCharactersIntoOriginal;

            txtNewPassword.Enter += ChangePasswordCharactersIntoStars;
            txtNewPassword.Leave += ReturnPasswordCharactersIntoOriginal;

            txtConfirmPassword.Enter += ChangePasswordCharactersIntoStars;
            txtConfirmPassword.Leave += ReturnPasswordCharactersIntoOriginal;
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {

            clsUtility.SetPlaceholder(txtCurrentPassword, txtCurrentPassword.Tag.ToString());
            clsUtility.SetPlaceholder(txtNewPassword, txtNewPassword.Tag.ToString());
            clsUtility.SetPlaceholder(txtConfirmPassword, txtConfirmPassword.Tag.ToString());

            _LoadUserInfo();

        }

        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("User not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

        }

        private void ChangePasswordCharactersIntoStars(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.ForeColor == Color.Gray) // placeholder is showing
            {
                tb.Text = string.Empty;
                tb.ForeColor = Color.Black;
                tb.PasswordChar = '*';
            }
        }

        private void ReturnPasswordCharactersIntoOriginal(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.PasswordChar = '\0'; // turn off masking first
                clsUtility.SetPlaceholder(tb, tb.Tag.ToString());
            }
        }

        private bool isEmptyOrPlaceholder(TextBox tb)
        {
            return string.IsNullOrWhiteSpace(tb.Text) || tb.ForeColor == Color.Gray;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (isEmptyOrPlaceholder(txtCurrentPassword))
            {
                e.Cancel = true;
                Error.SetError(txtCurrentPassword, "Current Password is required!");
                return;
            }

            if (!clsPasswordHashing.VerifyPassword(txtCurrentPassword.Text.Trim(), _User.PasswordHash, _User.PasswordSalt))
            {
                e.Cancel = true;
                Error.SetError(txtCurrentPassword, "Wrong password!");
                return;
            }

            Error.SetError(txtCurrentPassword, string.Empty);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (isEmptyOrPlaceholder(txtNewPassword))
            {
                e.Cancel = true;
                Error.SetError(txtNewPassword, "New password is required!");
                return;
            }

            if (txtNewPassword.Text == txtCurrentPassword.Text)
            {
                e.Cancel = true;
                Error.SetError(txtNewPassword, "New password must differ from current!");
                return;
            }

            Error.SetError(txtNewPassword, string.Empty);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (isEmptyOrPlaceholder(txtConfirmPassword))
            {
                e.Cancel = true;
                Error.SetError(txtConfirmPassword, "Please confirm your password!");
                return;
            }

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                Error.SetError(txtConfirmPassword, "Passwords do not match!");
                return;
            }

            Error.SetError(txtConfirmPassword, string.Empty);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Please fix the highlighted fields before continuing.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Update, $"Reset password for user '{_User.UserName}'");
                clsGlobalEvents.RaiseActionCompleted();

                MessageBox.Show("Password Changed Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Error: Password did not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
