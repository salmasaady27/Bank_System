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
using static Bank_BusinessLayer.clsAccount;
using static Bank_BusinessLayer.clsTransaction;

namespace Bank.Audit_Logs
{
    public partial class frmLogs : Form
    {
        private static DataTable _dtAllLogs = clsLog.GetAllLogs();
        public frmLogs()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllLogs = clsLog.GetAllLogs();
            dgvLogs.DataSource = _dtAllLogs;
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            clsUtility.SetPlaceholder(txtFilterDescription, "Search description...");
            dgvLogs.DataSource = _dtAllLogs;
            cbDate.SelectedIndex = 0;

            if (dgvLogs.Rows.Count >= 0)
            {
                dgvLogs.Columns[0].HeaderText = "Log ID";
                dgvLogs.Columns[0].Width = 100;

                dgvLogs.Columns[1].HeaderText = "Username";
                dgvLogs.Columns[1].Width = 120;

                dgvLogs.Columns[2].HeaderText = "Action Type";
                dgvLogs.Columns[2].Width = 120;

                dgvLogs.Columns[3].HeaderText = "Description";
                dgvLogs.Columns[3].Width = 250;

                dgvLogs.Columns[4].HeaderText = "Date";
                dgvLogs.Columns[4].Width = 110;

            }

            clsGlobalEvents.TransactionCompleted += (s, args) => _RefreshList();
            clsGlobalEvents.ActionCompleted += (s, args) => _RefreshList();
        }

        private void _FilterLogs()
        {
            string TextFilter = string.Empty;
            string DateFilter = string.Empty;

            // Text filter - Description
            if (!string.IsNullOrWhiteSpace(txtFilterDescription.Text) &&
                txtFilterDescription.Text != "Search description...")
            {
                TextFilter = string.Format("[{0}] like '%{1}%'", "Description", txtFilterDescription.Text.Trim());
            }

            // ComboBox filter - Date
            if (cbDate.SelectedItem != null && cbDate.Text != "All")
            {
                DateTime FromDate = DateTime.Today;
                DateTime ToDate = DateTime.Today.AddDays(1);

                switch (cbDate.Text)
                {
                    case "Today":
                        FromDate = DateTime.Today;
                        break;

                    case "Yesterday":
                        FromDate = DateTime.Today.AddDays(-1);
                        ToDate = DateTime.Today;
                        break;

                    case "Last Week":
                        FromDate = DateTime.Today.AddDays(-7);
                        break;

                    case "Last Month":
                        FromDate = DateTime.Today.AddMonths(-1);
                        break;

                    case "Last Year":
                        FromDate = DateTime.Today.AddYears(-1);
                        break;
                }

                DateFilter = string.Format("[{0}] >= #{1}# AND [{0}] < #{2}#",
                    "CreatedAt",
                    FromDate.ToString("MM/dd/yyyy"),
                    ToDate.ToString("MM/dd/yyyy"));
            }

            // Combine filters
            List<string> Filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(TextFilter))
                Filters.Add(TextFilter);

            if (!string.IsNullOrWhiteSpace(DateFilter))
                Filters.Add(DateFilter);

            _dtAllLogs.DefaultView.RowFilter = string.Join(" AND ", Filters);
            dgvLogs.DataSource = _dtAllLogs;
        }

        private void btnExportLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming later", "Export Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtFilterDescription_TextChanged(object sender, EventArgs e)
        {
            _FilterLogs();
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterLogs();
        }
    }
}
