using Bank.Global_Classes;
using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bank
{
    public partial class frmEmployees : Form
    {
        private static DataTable _dtAllEmployees = clsEmployee.GetAllEmployees();
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllEmployees = clsEmployee.GetAllEmployees();
            dgvEmployees.DataSource = _dtAllEmployees;

            clsUtility.SetPlaceholder(txtFilterName, "Enter your name...");
            cbJobTitle.SelectedIndex = 0;
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            clsUtility.SetPlaceholder(txtFilterName, "Enter your name...");
            dgvEmployees.DataSource = _dtAllEmployees;
            //cbJobTitle.SelectedIndex = 0;

            if (dgvEmployees.Rows.Count > 0)
            {
                dgvEmployees.Columns[0].HeaderText = "Employee ID";
                dgvEmployees.Columns[0].Width = 80;

                dgvEmployees.Columns[1].HeaderText = "Full Name";
                dgvEmployees.Columns[1].Width = 130;

                dgvEmployees.Columns[2].HeaderText = "National No";
                dgvEmployees.Columns[2].Width = 100;

                dgvEmployees.Columns[3].HeaderText = "Phone";
                dgvEmployees.Columns[3].Width = 120;

                dgvEmployees.Columns[4].HeaderText = "Job Title";
                dgvEmployees.Columns[4].Width = 100;

                dgvEmployees.Columns[5].HeaderText = "Hire Date";
                dgvEmployees.Columns[5].Width = 90;

                dgvEmployees.Columns[6].HeaderText = "Status";
                dgvEmployees.Columns[6].Width = 100;
            }
        }

        private void txtFilterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // For string
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _FilterData()
        {
            string TextFilter = "";
            string JobTitleFilter = "";

            // Text filter
            if (!string.IsNullOrWhiteSpace(txtFilterName.Text) &&
                txtFilterName.Text != "Enter your name...")
            {
                TextFilter = string.Format("[{0}] like '{1}%'", "FullName", txtFilterName.Text.Trim());
            }

            // JobTitle filter
            if (cbJobTitle.SelectedItem != null && cbJobTitle.Text != "All")
            {
                JobTitleFilter = string.Format("[{0}] = '{1}'", "JobTitle", cbJobTitle.Text);
            }

            // Combine both filters
            if (!string.IsNullOrWhiteSpace(TextFilter) && !string.IsNullOrWhiteSpace(JobTitleFilter))
                _dtAllEmployees.DefaultView.RowFilter = string.Format("{0} AND {1}", TextFilter, JobTitleFilter);

            else if (!string.IsNullOrWhiteSpace(TextFilter))
                _dtAllEmployees.DefaultView.RowFilter = TextFilter;

            else if (!string.IsNullOrWhiteSpace(JobTitleFilter))
                _dtAllEmployees.DefaultView.RowFilter = JobTitleFilter;

            else
                _dtAllEmployees.DefaultView.RowFilter = "";
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void cbJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
            frm.ShowDialog();
            _RefreshList();

        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvEmployees.CurrentRow.Cells[0].Value;
            clsEmployee _Employee = clsEmployee.Find(EmployeeID);

            if (MessageBox.Show($"Are you sure you want to delete employee [{EmployeeID}]", "Confirm Delete",
                                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsEmployee.Delete(EmployeeID))
                {
                    clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Delete, $"Deleted employee '{_Employee.FullName}' profile");

                    MessageBox.Show("Employee has been deleted Successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    _RefreshList();
                    clsGlobalEvents.RaiseActionCompleted();
                }
                else
                    MessageBox.Show("Employee is not deleted due to data connected to it.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee((int)dgvEmployees.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }
    }
}
