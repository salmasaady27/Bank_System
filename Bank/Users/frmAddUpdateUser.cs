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
using System.Web.WebSockets;
using System.Windows.Forms;

namespace Bank.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;


        private int _EmployeeID;
        private clsEmployee _Employee;

        private int _UserID;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            btnAddUpdateUser.Text = "Add User";

            txtEmployeeID.KeyPress += TypeOnlyNumbers;
            txtPassword.Enter += ChangePasswordCharactersIntoStars;
            txtPassword.Leave += ReturnPasswordCharactersIntoOriginal;

            txtConfirmPassword.Enter += ChangePasswordCharactersIntoStars;
            txtConfirmPassword.Leave += ReturnPasswordCharactersIntoOriginal;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
            btnAddUpdateUser.Text = "Update User";

            txtEmployeeID.KeyPress += TypeOnlyNumbers;
            
            txtPassword.Enter += ChangePasswordCharactersIntoStars;
            txtPassword.Leave += ReturnPasswordCharactersIntoOriginal;

            txtConfirmPassword.Enter += ChangePasswordCharactersIntoStars;
            txtConfirmPassword.Leave += ReturnPasswordCharactersIntoOriginal;
        }

        private void _ResetDefaultValues()
        {
            clsUtility.SetPlaceholder(txtEmployeeID, "Enter Employee ID");
            clsUtility.SetPlaceholder(txtUsername, "Username");

            txtPassword.PasswordChar = '\0';
            txtConfirmPassword.PasswordChar = '\0';

            clsUtility.SetPlaceholder(txtPassword, "Password");
            clsUtility.SetPlaceholder(txtConfirmPassword, "Confirm Password");
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            if(_User == null)
            {
                MessageBox.Show($"No User with ID = {_UserID}" , "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            _EmployeeID = _User.EmployeeID;

            btnSearch.Enabled = false;
            txtEmployeeID.Enabled = false;
            txtEmployeeID.Text = _User.EmployeeID.ToString();


            gpUserInfo.Enabled = true;
            btnAddUpdateUser.Enabled = true;

            lblEmployeeName.Text = _User.EmployeeInfo.FullName;
            txtUsername.Text = _User.UserName;
            txtUsername.ForeColor = Color.Black;

            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update) _LoadData();
        }

        private void frmAddUpdateUser_Shown(object sender, EventArgs e)
        {
            txtEmployeeID.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) || txtEmployeeID.ForeColor == Color.Gray)
                return;

            _EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
            _Employee = clsEmployee.Find(_EmployeeID);

            if (_Employee == null)
            {

                MessageBox.Show($"No Employee with this ID = {_EmployeeID}", "Employee Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                _FocusOnEmployeeIDTextBox();
                return;
            }

            _User = clsUser.FindByEmployeeID(_EmployeeID);

            if (_User != null)
            {

                lblEmployeeName.Text = _Employee.FullName;
                lblEmployeeName.ForeColor = Color.Red;

                MessageBox.Show($"This user already exists", "User Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                _FocusOnEmployeeIDTextBox();
                return;
            }

            _User = new clsUser();

            lblEmployeeName.Text = _Employee.FullName;
            lblEmployeeName.ForeColor = Color.Green;

            _SetUIAfterEmployeeVerified();
        }

        private void _SetUIAfterEmployeeVerified()
        {
            btnSearch.Enabled = false;
            txtEmployeeID.Enabled = false;

            btnReset.Enabled = true;
            btnAddUpdateUser.Enabled = true;
            gpUserInfo.Enabled = true;
        }

        private void _FocusOnEmployeeIDTextBox()
        {
            txtEmployeeID.Text = string.Empty;
            txtEmployeeID.Focus();
            
            gpUserInfo.Enabled = false;

            btnAddUpdateUser.Enabled = false;
            
            lblEmployeeName.Text = "Employee's Name";
            lblEmployeeName.ForeColor = Color.Green;
        }

        private void TypeOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // For int
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            txtEmployeeID.Enabled = true;
            btnSearch.Enabled = true;
            btnReset.Enabled = false;

            txtEmployeeID.Focus();
            btnAddUpdateUser.Enabled = false;
            gpUserInfo.Enabled = false;

            lblEmployeeName.Text = "Employee's Name";
            lblEmployeeName.ForeColor = Color.Green;
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
                string placeholder = (tb == txtPassword) ? "Password" : "Confirm Password";
                clsUtility.SetPlaceholder(tb, placeholder);
            }
        }
       
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            bool isUsernameEmpty = string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.ForeColor == Color.Gray;

            bool doesUsernameExist = clsUser.DoesUserExist(txtUsername.Text.Trim()) && txtUsername.Text != _User.UserName;

            if (isUsernameEmpty || doesUsernameExist)
            {
                e.Cancel = true;

                Error.SetError(txtUsername, isUsernameEmpty ? "This field is required!" : "Username is taken!");
                return;
            }
            Error.SetError(txtUsername, string.Empty);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Update)
                return;

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.ForeColor == Color.Gray)
            {
                e.Cancel = true;
                Error.SetError(txtPassword, "Password is required!");
                return;
            }

            //if (txtPassword.Text.Length < 8)
            //{
            //    e.Cancel = true;
            //    Error.SetError(txtPassword, "At least 8 characters!");
            //    return;
            //}

            Error.SetError(txtPassword, string.Empty);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Update)
                return;

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || txtConfirmPassword.ForeColor == Color.Gray)
            {
                e.Cancel = true;
                Error.SetError(txtConfirmPassword, "Please confirm your password!");
                return;
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                Error.SetError(txtConfirmPassword, "Passwords do not match!");
                return;
            }

            Error.SetError(txtConfirmPassword, string.Empty);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // 1. Trigger validation on all fields
            if (!this.ValidateChildren())
                return;

            _User.EmployeeID = _EmployeeID;
            _User.UserName = txtUsername.Text.Trim();
            _User.Password = txtPassword.Text.Trim();

            if(!_User.Save())
            {
                MessageBox.Show("Failed to save user. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.CreateUser, $"Created new user '{_User.UserName}' profile");
                
                MessageBox.Show($"User added successfully!\nUser ID = {_User.UserID}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Update, $"Updated user '{_User.UserName}' information");
                
                MessageBox.Show("User updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }

            clsGlobalEvents.RaiseActionCompleted();
        }
    }
}
