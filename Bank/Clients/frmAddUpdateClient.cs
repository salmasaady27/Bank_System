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

namespace Bank.Clients
{
    public partial class frmAddUpdateClient : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _ClientID;
        private clsClient _Client;
        public frmAddUpdateClient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            btnAddUpdateClient.Text = "Add Client";

        }

        public frmAddUpdateClient(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
            _Mode = enMode.Update;
            btnAddUpdateClient.Text = "Update Client";
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew) _Client = new clsClient();


            // Adjust age to be greater than or equal 18 years
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            txtFirstName.KeyPress += TypeOnlyLetters;
            txtLastName.KeyPress += TypeOnlyLetters;
            txtPhone.KeyPress += TypeOnlyNumbers;


            clsUtility.SetPlaceholder(txtFirstName, "FirstName");
            clsUtility.SetPlaceholder(txtLastName, "LastName");
            clsUtility.SetPlaceholder(txtNationalNo, "National Number");
            clsUtility.SetPlaceholder(txtEmail, "Email");
            clsUtility.SetPlaceholder(txtPhone, "Phone");
            cbGender.SelectedIndex = 0;
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

        private void _LoadData()
        {
            _Client = clsClient.Find(_ClientID);

            if (_Client == null)
            {
                MessageBox.Show($"No Client with this ID = {_ClientID}", "Client Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            // If Found
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Text = _Client.FirstName;

            txtLastName.ForeColor = Color.Black;
            txtLastName.Text = _Client.LastName;

            txtNationalNo.ForeColor = Color.Black;
            txtNationalNo.Text = _Client.NationalNo;

            txtEmail.ForeColor = Color.Black;
            txtEmail.Text = _Client.Email;

            txtPhone.ForeColor = Color.Black;
            txtPhone.Text = _Client.Phone;

            dtpDateOfBirth.Value = _Client.DateOfBirth;
            cbGender.SelectedIndex = cbGender.FindString(_Client.GenderText.Trim());

        }

        private void frmAddUpdateClient_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update) _LoadData();
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


        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            bool isNationalNoEmpty = string.IsNullOrWhiteSpace(txtNationalNo.Text) || txtNationalNo.ForeColor == Color.Gray;
            bool doesNationalNoExist = clsPerson.DoesNationalNoExist(txtNationalNo.Text.Trim()) && txtNationalNo.Text != _Client.NationalNo;

            if (isNationalNoEmpty || doesNationalNoExist)
            {
                e.Cancel = true;
                Error.SetError(txtNationalNo, isNationalNoEmpty ? "This field is required!" : "National Number is taken!");

                return;
            }

            Error.SetError(txtNationalNo, string.Empty);
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.ForeColor == Color.Gray;

            if (isEmailEmpty || !clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                Error.SetError(txtEmail, isEmailEmpty ? "This field is required!" : "Invalid email format!");

                return;
            }

            Error.SetError(txtEmail, string.Empty);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!,Put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Client.FirstName = txtFirstName.Text;
            _Client.LastName = txtLastName.Text;
            _Client.NationalNo = txtNationalNo.Text;
            _Client.Email = txtEmail.Text;
            _Client.Phone = txtPhone.Text;

            _Client.Gender = cbGender.SelectedIndex == 0 ? 'M' : 'F';
            _Client.DateOfBirth = dtpDateOfBirth.Value;
            _Client.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!_Client.Save())
            {
                MessageBox.Show("Failed to save client. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.CreateClient, $"Created new client '{_Client.FullName}' profile");
                
                MessageBox.Show($"Client added successfully!\nClient ID = {_Client.ClientID}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnAddUpdateClient.Enabled = false;
                _Mode = enMode.Update;

                this.Close();
            }
            else
            {
                clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Update, $"Updated client '{_Client.FullName}' information");
               
                MessageBox.Show("Client updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            
            clsGlobalEvents.RaiseActionCompleted();
        }
    }
}
