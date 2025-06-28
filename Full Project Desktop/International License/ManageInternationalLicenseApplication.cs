using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;


namespace Full_Project_Desktop
{
    public partial class ManageInternationalLicenseApplication : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        public ManageInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvManageInternational.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            ShowLicenseHistory frm = new ShowLicenseHistory(PersonID);
            frm.ShowDialog();

        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DriverID = (int)dgvManageInternational.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            ShowPersonDetailsNew frm = new ShowPersonDetailsNew(PersonID);
            frm.ShowDialog();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ManageInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilter.SelectedIndex = 0;

            dgvManageInternational.DataSource = _dtInternationalLicenseApplications;
            lblInternationalLicensesRecords.Text = dgvManageInternational.Rows.Count.ToString();

            if (dgvManageInternational.Rows.Count > 0)
            {
                dgvManageInternational.Columns[0].HeaderText = "Int.License ID";
                dgvManageInternational.Columns[0].Width = 160;

                dgvManageInternational.Columns[1].HeaderText = "Application ID";
                dgvManageInternational.Columns[1].Width = 150;

                dgvManageInternational.Columns[2].HeaderText = "Driver ID";
                dgvManageInternational.Columns[2].Width = 130;

                dgvManageInternational.Columns[3].HeaderText = "L.License ID";
                dgvManageInternational.Columns[3].Width = 130;

                dgvManageInternational.Columns[4].HeaderText = "Issue Date";
                dgvManageInternational.Columns[4].Width = 180;

                dgvManageInternational.Columns[5].HeaderText = "Expiration Date";
                dgvManageInternational.Columns[5].Width = 180;

                dgvManageInternational.Columns[6].HeaderText = "Is Active";
                dgvManageInternational.Columns[6].Width = 120;

            }
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int InternationalLicenseID = (int)dgvManageInternational.CurrentRow.Cells[0].Value;
            DriverInternationalLicenseInfo frm = new DriverInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            InternationalLicense frm = new InternationalLicense();
            frm.Show();

        }

        private void DgvManageInternational_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilter.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilter.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    }
                    ;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = dgvManageInternational.Rows.Count.ToString();
                return;
            }



            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            lblInternationalLicensesRecords.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();

        }


    }
}
