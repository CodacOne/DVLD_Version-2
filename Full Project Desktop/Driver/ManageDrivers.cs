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
    public partial class ManageDrivers : Form
    {

        private string _InputText = "";
        private int _SelectedIndex = -1;
        public ManageDrivers()
        {
            InitializeComponent();

           
        }

        /*/*//***************************************//*/*//*//*/
        private void RefreshList()
        {
            cbFilter.SelectedIndex = 0;
            _SelectedIndex = 0;
            _InputText = "None";
            dgvManageDrivers.DataSource = clsDriver.DriversWithLicensesFilter(_SelectedIndex, _InputText);
            lblCountRecords.Text = dgvManageDrivers.Rows.Count.ToString();


            if (dgvManageDrivers.Rows.Count > 0)
            {
                dgvManageDrivers.Columns[0].HeaderText = "Driver ID";
                dgvManageDrivers.Columns[0].Width = 120;

                dgvManageDrivers.Columns[1].HeaderText = "Person ID";
                dgvManageDrivers.Columns[1].Width = 120;

                dgvManageDrivers.Columns[2].HeaderText = "National No.";
                dgvManageDrivers.Columns[2].Width = 140;

                dgvManageDrivers.Columns[3].HeaderText = "Full Name";
                dgvManageDrivers.Columns[3].Width = 320;

                dgvManageDrivers.Columns[4].HeaderText = "Date";
                dgvManageDrivers.Columns[4].Width = 170;

                dgvManageDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvManageDrivers.Columns[5].Width = 150;
            }


          
           


        }
            /*/*//***************************************//*/*//*//*/

            /*/*//***************************************//*/*//*//*/
            private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void DgvManageDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageDrivers_Load(object sender, EventArgs e)
        {
            RefreshList();

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            _InputText = txtSearch.Text.Trim();
            _SelectedIndex = cbFilter.SelectedIndex;

            // تحقق من صحة الإدخال عند البحث بالـ ID
            if ((_SelectedIndex == 1 || _SelectedIndex == 2) && !string.IsNullOrEmpty(_InputText))
            {
                if (!int.TryParse(_InputText, out _))
                {
                    MessageBox.Show("Please enter a valid number when searching by ID or Driver ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            dgvManageDrivers.DataSource = clsDriver.DriversWithLicensesFilter(_SelectedIndex, _InputText);
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvManageDrivers.CurrentRow.Cells[1].Value;
            ShowPersonDetailsNew frm = new ShowPersonDetailsNew(PersonID);
            frm.ShowDialog();

            ManageDrivers_Load(null,null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvManageDrivers.CurrentRow.Cells[1].Value;

            ShowLicenseHistory frm = new ShowLicenseHistory(PersonID);
            frm.ShowDialog();
        }
        /*/*//***************************************//*/*//*//*/

        /*/*//***************************************//*/*//*//*/
    }
}
