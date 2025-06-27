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
    public partial class ManageDetainedLicense : Form
    {
        private DataTable _dtDetainedLicenses ;

        string InputTextBox = "";
        int InputNumber = 0;

        private int _PersonID = -1;


        public ManageDetainedLicense()
        {
            InitializeComponent();
        }


        /*/*//***************************************//*/*//*//*/
        private void RefreshList(int InputNumber , string InputTextBox)
        {
            _dtDetainedLicenses = clsDetaineLicense.GetAllDetainedLicenses(InputNumber, InputTextBox);

            dgvManageDetain.DataSource = _dtDetainedLicenses;
            lblCountRecords.Text = dgvManageDetain.Rows.Count.ToString();
          
            if (dgvManageDetain.Rows.Count > 0)
            {
                dgvManageDetain.Columns[0].HeaderText = "D.ID";
                dgvManageDetain.Columns[0].Width = 90;

                dgvManageDetain.Columns[1].HeaderText = "L.ID";
                dgvManageDetain.Columns[1].Width = 90;

                dgvManageDetain.Columns[2].HeaderText = "D.Date";
                dgvManageDetain.Columns[2].Width = 160;

                dgvManageDetain.Columns[3].HeaderText = "Is Released";
                dgvManageDetain.Columns[3].Width = 110;

                dgvManageDetain.Columns[4].HeaderText = "Fine Fees";
                dgvManageDetain.Columns[4].Width = 110;

                dgvManageDetain.Columns[5].HeaderText = "Release Date";
                dgvManageDetain.Columns[5].Width = 160;

                dgvManageDetain.Columns[6].HeaderText = "N.No.";
                dgvManageDetain.Columns[6].Width = 90;

                dgvManageDetain.Columns[7].HeaderText = "Full Name";
                dgvManageDetain.Columns[7].Width = 330;

                dgvManageDetain.Columns[8].HeaderText = "Rlease App.ID";
                dgvManageDetain.Columns[8].Width = 150;

            }
         

        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDetainedLicense_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            RefreshList(0,"");
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            InputTextBox = "";

            InputTextBox = txtFilter.Text;
            InputNumber = cbFilter.SelectedIndex;
            RefreshList(InputNumber , InputTextBox);
          
        }

        private void DgvManageDetain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();

        }

        private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvManageDetain.CurrentRow.Cells[1].Value;
            DriverDetails frm = new DriverDetails(LicenseID);
            frm.ShowDialog();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvManageDetain.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;
           
            ShowLicenseHistory frm = new ShowLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvManageDetain.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;

            ShowPersonDetailsNew frm = new ShowPersonDetailsNew(PersonID);
            frm.ShowDialog();
        }
    }
}
