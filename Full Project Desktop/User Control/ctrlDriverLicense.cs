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

        private int _ApplicationID = -1;
        private int _PersonID = -1;
        public ctrlDriverLicense()
        {
            InitializeComponent();



        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        /*/*//*/********************************//*/*/
        public void FillDataToForm(int PersonID)
        {
           
            RefreshDataLocalLicense(PersonID);


        }
        /*/*//*/********************************//*/*/

        public void RefreshDataLocalLicense(int PersonID)
        {
            _PersonID = PersonID;
            dgvLocalLicenseHistory.DataSource = clsDrivers.GetAllLicenseToThePersonForDgv(PersonID);

           
            int realRowCount = dgvLocalLicenseHistory.Rows.Cast<DataGridViewRow>()
                .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
        }

        /*/*//*/********************************//*/*/

        private void DgvLocalLicenseHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvManageInternational_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void RefreshListInternationalLicense()
        {

           DataTable _Dt = clsInternationalLicense.GetAllInternationalLicenseByPersonID(_PersonID);
           

            dgvManageInternational.DataSource = _Dt;

 

           // dgvManageInternational.Columns["IssueDate"].FillWeight = 110;
           // dgvManageInternational.Columns["ExpirationDate"].FillWeight = 110;
           //// dgvManageInternational.Columns["Driver ID"].FillWeight = 50;
           // dgvManageInternational.Columns["InternationalLicenseID"].FillWeight = 70;



        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CtrlDriverLicense_Load(object sender, EventArgs e)
        {
            RefreshListInternationalLicense();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ShowLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            ShowDetailsLicense frm = new ShowDetailsLicense((int)dgvLocalLicenseHistory.CurrentRow.Cells[0].Value);
            frm.Show();
        }

        /*/*//*/********************************//*/*/
                                                 /*/*//*/********************************//*/*/
    }
}
