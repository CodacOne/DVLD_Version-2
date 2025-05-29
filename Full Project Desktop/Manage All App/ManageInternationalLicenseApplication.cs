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
        private DataTable _Dt = new DataTable();
        private int _DriverID = -1;
       

        public ManageInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        /*/*//***************************************//*/*//*//*/
        private void RefreshList()
        {

            _Dt= clsInternationalLicense.GetInternationalLicenseInforDgv();
            if (_Dt.Rows.Count > 0)
            {
                DataRow row = _Dt.Rows[0];

                // نصوص السائق
                _DriverID =Convert.ToInt32( row["Driver ID"]);
               
               
            }

                dgvManageInternational.DataSource = _Dt;


            dgvManageInternational.Columns["Issue Date"].FillWeight = 110;
            dgvManageInternational.Columns["Expiration Date"].FillWeight = 110;
            dgvManageInternational.Columns["Driver ID"].FillWeight =50;
           dgvManageInternational.Columns["L.License ID"].FillWeight = 70;
           

            int realRowCount = dgvManageInternational.Rows.Cast<DataGridViewRow>()
               .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
            cbFilter.SelectedIndex = 0;


        }


        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          int  LocalDrivingID = clsInternationalLicense
                .GetLocalDrivingLicenseApplicationIDByApplicationID((int)dgvManageInternational.CurrentRow.Cells[1].Value);


            ShowLicenseHistory frm = new ShowLicenseHistory(LocalDrivingID);
            frm.Show();
        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsInternationalLicense.GetPersonIDByDriverID(_DriverID);
            ShowDetails frm = new ShowDetails(PersonID);
            frm.Show();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ManageInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DriverInternationalLicenseInfo frm = 
                new DriverInternationalLicenseInfo((int)dgvManageInternational.CurrentRow.Cells[3].Value);
            frm.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            InternationalLicense frm = new InternationalLicense();
            frm.Show();

        }

        private void DgvManageInternational_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
