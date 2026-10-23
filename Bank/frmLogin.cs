using System;
using System.Windows.Forms;
using Bank.Global_Classes;
using Bank_BusinessLayer;

namespace Bank
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbShowHidePassword_Click(object sender, EventArgs e)
        {
            bool isPasswordVisible = txtPassword.UseSystemPasswordChar;
            
            if (isPasswordVisible) 
            {
                pbShowHidePassword.Image = Bank.Properties.Resources.eye_open_32;
                txtPassword.UseSystemPasswordChar = false;
                isPasswordVisible = txtPassword.UseSystemPasswordChar;
            }
            else
            {
                pbShowHidePassword.Image = Bank.Properties.Resources.eye_close_32;
                txtPassword.UseSystemPasswordChar = true;
                isPasswordVisible = txtPassword.UseSystemPasswordChar;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUser User = clsUser.Find(txtUsername.Text.Trim());

            if (User == null)
            {
                MessageBox.Show("Invalid username.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!clsPasswordHashing.VerifyPassword(txtPassword.Text.Trim(), User.PasswordHash, User.PasswordSalt))
            {
                MessageBox.Show("Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Incase the user is not active
            if (!User.Status)
            {
                txtUsername.Focus();
                MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(chkRememberMe.Checked) 
                clsGlobal.RememberUsernameWithRegistry(txtUsername.Text.Trim());
            else
                clsGlobal.RememberUsernameWithRegistry("");


            clsGlobal.CurrentUser = User;
            
            clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Login, $"Successful login");
            clsGlobalEvents.RaiseActionCompleted();
            
            this.Hide();
            frmMainDashboard frm = new frmMainDashboard(this);
            frm.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "";
            

            if (clsGlobal.GetStoredCredentialWithRegistry(ref Username))
            {
                txtUsername.Text = Username;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUsername.Text))
                txtPassword.Focus();
            else
                txtUsername.Focus();
        }
    }
}
