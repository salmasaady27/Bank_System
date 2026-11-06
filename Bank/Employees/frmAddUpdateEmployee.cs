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

namespace Bank
{
    public partial class frmAddUpdateEmployee : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _EmployeeID;
        private clsEmployee _Employee;

        public frmAddUpdateEmployee()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            btnAddUpdateEmployee.Text = "Add Employee";

        }

        public frmAddUpdateEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
            _Mode = enMode.Update;
            btnAddUpdateEmployee.Text = "Update Employee";
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew) _Employee = new clsEmployee();


            // Adjust age to be greater than or equal 18 years
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            
            // Adjust Hire date 
            dtpHireDate.MaxDate = DateTime.Now;
            dtpHireDate.MinDate = DateTime.Now.AddYears(-50);

            txtFirstName.KeyPress += TypeOnlyLetters;
            txtLastName.KeyPress += TypeOnlyLetters;
            txtPhone.KeyPress += TypeOnlyNumbers;

            
            clsUtility.SetPlaceholder(txtFirstName, "FirstName");
            clsUtility.SetPlaceholder(txtLastName, "LastName");
            clsUtility.SetPlaceholder(txtNationalNo, "National Number");
            clsUtility.SetPlaceholder(txtEmail, "Email");
            clsUtility.SetPlaceholder(txtPhone, "Phone");
            cbGender.SelectedIndex = 0;
            cbJobTitle.SelectedIndex = 0;
        }
        private void _LoadData()
        {
            _Employee = clsEmployee.Find(_EmployeeID);

            if(_Employee == null)
            {
                MessageBox.Show($"No Employee with this ID = {_EmployeeID}", "Employee Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            // If Found
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Text = _Employee.FirstName;

            txtLastName.ForeColor = Color.Black;
            txtLastName.Text = _Employee.LastName;

            txtNationalNo.ForeColor = Color.Black;
            txtNationalNo.Text = _Employee.NationalNo;

            txtEmail.ForeColor = Color.Black;
            txtEmail.Text = _Employee.Email;

            txtPhone.ForeColor = Color.Black;
            txtPhone.Text = _Employee.Phone;

            dtpDateOfBirth.Value = _Employee.DateOfBirth;
            dtpHireDate.Value = _Employee.HireDate;
            cbGender.SelectedIndex = cbGender.FindString(_Employee.GenderText.Trim());
            cbJobTitle.SelectedIndex = cbJobTitle.FindString(_Employee.JobTitle.Trim());

        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update) _LoadData();
        }
             
        private void TypeOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // For int
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TypeOnlyLetters(object sender, KeyPressEventArgs e)
        {
            // For string
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(txt.Text) || txt.ForeColor == Color.Gray)
            {
                e.Cancel = true;
                Error.SetError(txt, "This field is required!");
                return;
            }
            
            Error.SetError(txt, string.Empty);
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!,Put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Employee.FirstName = txtFirstName.Text;
            _Employee.LastName = txtLastName.Text;
            _Employee.NationalNo = txtNationalNo.Text;
            _Employee.Email = txtEmail.Text;
            _Employee.Phone = txtPhone.Text;

            _Employee.Gender = cbGender.SelectedIndex == 0 ? 'M' : 'F' ;
            _Employee.JobTitle = cbJobTitle.Text;

            _Employee.DateOfBirth = dtpDateOfBirth.Value;
            _Employee.HireDate = dtpHireDate.Value;

           _Employee.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                        
            if (!_Employee.Save())
            {
                MessageBox.Show("Failed to save employee. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.CreateEmployee, $"Created new employee '{_Employee.FullName}' profile");
                
                MessageBox.Show($"Employee added successfully!\nEmployee ID = {_Employee.EmployeeID}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnAddUpdateEmployee.Enabled = false;
                _Mode = enMode.Update;
                
                this.Close();
            }
            else
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Update, $"Updated employee '{_Employee.FullName}' information");
                
                MessageBox.Show("Employee updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }

            clsGlobalEvents.RaiseActionCompleted();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.ForeColor == Color.Gray;

            if ( isEmailEmpty || !clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                Error.SetError(txtEmail, isEmailEmpty ? "This field is required!" : "Invalid email format!");
                
                return;
            }
            
            Error.SetError(txtEmail, string.Empty);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            bool isPhoneEmpty = string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.ForeColor == Color.Gray;

            if (isPhoneEmpty || !clsValidation.ValidatePhone(txtPhone.Text))
            {
                e.Cancel = true;
                Error.SetError(txtPhone, isPhoneEmpty ? "This field is required!" : "Invalid phone format!");

                return;
            }

            Error.SetError(txtPhone, string.Empty);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            bool isNationalNoEmpty = string.IsNullOrWhiteSpace(txtNationalNo.Text) || txtNationalNo.ForeColor == Color.Gray;
            bool doesNationalNoExist = clsPerson.DoesNationalNoExist(txtNationalNo.Text.Trim()) && txtNationalNo.Text != _Employee.NationalNo;

            if (isNationalNoEmpty || doesNationalNoExist)
            {
                e.Cancel = true;
                Error.SetError(txtNationalNo, isNationalNoEmpty ? "This field is required!" : "National Number is taken!");

                return;
            }

            Error.SetError(txtNationalNo, string.Empty);
        }
    }
}
