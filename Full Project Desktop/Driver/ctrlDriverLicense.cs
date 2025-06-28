using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;


namespace Full_Project_Desktop
{
    public partial class ctrlDriverLicense : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

   
        public ctrlDriverLicense()
        {
            InitializeComponent();
         
        }

        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = clsDriver.GetLicenses(_DriverID);


            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;
            lblCountLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;

            }
        }

        /**//*/*////////////////////*/
         private void _LoadInternationalLicenseInfo()
        {

           _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);

            if(_dtDriverInternationalLicensesHistory == null )
            {
                return;
            }

            dgvManageInternationalHistory.DataSource = _dtDriverInternationalLicensesHistory;
            lblCountLocalLicensesRecords.Text = dgvManageInternationalHistory.Rows.Count.ToString();

            //if (_dtDriverInternationalLicensesHistory.Rows.Count > 0)
            //{
            //    dgvManageInternationalHistory.Columns[0].HeaderText = "Int.License ID";
            //    dgvManageInternationalHistory.Columns[0].Width = 160;

            //    dgvManageInternationalHistory.Columns[1].HeaderText = "Application ID";
            //    dgvManageInternationalHistory.Columns[1].Width = 130;

            //    dgvManageInternationalHistory.Columns[2].HeaderText = "L.License ID";
            //    dgvManageInternationalHistory.Columns[2].Width = 130;

            //    dgvManageInternationalHistory.Columns[3].HeaderText = "Issue Date";
            //    dgvManageInternationalHistory.Columns[3].Width = 180;

            //    dgvManageInternationalHistory.Columns[4].HeaderText = "Expiration Date";
            //    dgvManageInternationalHistory.Columns[4].Width = 180;

            //    dgvManageInternationalHistory.Columns[5].HeaderText = "Is Active";
            //    dgvManageInternationalHistory.Columns[5].Width = 120;

            //}

        }


        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no Driver  with ID  " + _DriverID.ToString(),
                    "not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }


        public void LoadInfoByPersonID(int PersonID)
        {

            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("There is no Driver linked with Person  with ID= " + _DriverID.ToString(),
                    "not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            if (_Driver != null)
            {
                _DriverID = clsDriver.FindByPersonID(PersonID).DriverID;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        /*/*//*/********************************//*/*/

        private void DgvLocalDrivingLicenseApplicationHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvManageInternational_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CtrlDriverLicense_Load(object sender, EventArgs e)
        {
            
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ShowLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            DriverDetails frm = new DriverDetails((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        private void labse_Click(object sender, EventArgs e)
        {

        }

        private void lblCountLocalLicensesRecords_Click(object sender, EventArgs e)
        {

        }

        /*/*//*/********************************//*/*/
        /*/*//*/********************************//*/*/
    }
}
