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
    public partial class frmClients : Form
    {
        private static DataTable _dtAllClients = clsClient.GetAllClients();
        public frmClients()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllClients = clsClient.GetAllClients();
            dgvClients.DataSource = _dtAllClients;
            dgvClients.Sort(dgvClients.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            clsUtility.SetPlaceholder(txtFilterName, "Enter your national number...");
            dgvClients.DataSource = _dtAllClients;

            if (dgvClients.Rows.Count > 0)
            {
                dgvClients.Columns[0].HeaderText = "Client ID";
                dgvClients.Columns[0].Width = 80;

                dgvClients.Columns[1].HeaderText = "Full Name";
                dgvClients.Columns[1].Width = 130;

                dgvClients.Columns[2].HeaderText = "National No";
                dgvClients.Columns[2].Width = 100;

                dgvClients.Columns[3].HeaderText = "Phone";
                dgvClients.Columns[3].Width = 120;

                dgvClients.Columns[4].HeaderText = "Email";
                dgvClients.Columns[4].Width = 170;

                dgvClients.Columns[5].HeaderText = "Created By";
                dgvClients.Columns[5].Width = 120;

            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateClient frm = new frmAddUpdateClient((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;
            clsClient Client = clsClient.Find(ClientID);
            
            if (MessageBox.Show($"Are you sure you want to delete client [{ClientID}]", "Confirm Delete",
                                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsClient.Delete(ClientID))
                {
                    clsLog.LogAction(clsGlobal.CurrentUser.UserID, clsLog.enActionType.Delete, $"Deleted client '{Client.FullName}' profile");

                    MessageBox.Show("Client has been deleted Successfully.", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshList();
                    clsGlobalEvents.RaiseActionCompleted();
                }
                else
                    MessageBox.Show("Client is not deleted due to data connected to it.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmAddUpdateClient frm = new frmAddUpdateClient();
            frm.ShowDialog();
            _RefreshList();
        }
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            string FilterColumnName = "NationalNo";

            if (txtFilterName.Text == "Enter your national number...")
                _dtAllClients.DefaultView.RowFilter = "";

            else
                _dtAllClients.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumnName, txtFilterName.Text.Trim());
        }
    }
}
