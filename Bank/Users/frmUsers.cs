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

namespace Bank.Users
{
    public partial class frmUsers : Form
    {
        private DataTable _dtAllUsers = clsUser.GetAllUsers();

        public frmUsers()
        {
            InitializeComponent();
        }

        private void _RefreshList() 
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            clsUtility.SetPlaceholder(txtFilterName, "Enter your username...");

            dgvUsers.DataSource = _dtAllUsers;

            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;

                dgvUsers.Columns[1].HeaderText = "Employee Name";
                dgvUsers.Columns[1].Width = 180;

                dgvUsers.Columns[2].HeaderText = "Username";
                dgvUsers.Columns[2].Width = 150;

                dgvUsers.Columns[3].HeaderText = "Role";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 130;
            }
        }

        private void txtFilterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // For string
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterName.Text == "Enter your username...")
                _dtAllUsers.DefaultView.RowFilter = "";

            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "Username", txtFilterName.Text.Trim());
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            clsUser User = clsUser.Find(UserID);

            if (MessageBox.Show($"Are you sure you want to delete user [{UserID}]", "Confirm Delete",
                                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.Delete(UserID))
                {
                    clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Delete, $"Deleted user '{User.UserName}' profile");

                    MessageBox.Show("User has been deleted Successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshList();
                    clsGlobalEvents.RaiseActionCompleted();
                }
                else
                    MessageBox.Show("User is not deleted due to data connected to it.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshList();
        }

        private void cmsUser_Opening(object sender, CancelEventArgs e)
        {
            bool Status = Convert.ToBoolean(dgvUsers.CurrentRow.Cells[4].Value);
            tsmDeactivate.Text = Status ? "Deactivate" : "Activate";
        }

        private void tsmDeactivate_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            bool Status = Convert.ToBoolean(dgvUsers.CurrentRow.Cells[4].Value);

            clsUser User = clsUser.Find(UserID);

            bool Result = Status ? User.Deactivate() : User.Activate();

            if (Result)
            {
                MessageBox.Show(Status ? $"User {User.UserName} deactivated." : $"User {User.UserName} activated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshList();
            }

            else
                MessageBox.Show("Operation failed.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmResetPassword_Click(object sender, EventArgs e)
        {
            frmResetPassword frm = new frmResetPassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            
            _RefreshList();
        }
    }
}
