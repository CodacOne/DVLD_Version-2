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

       

        /*/*//***************************************//*/*//*//*/
        private void RefreshList()
        {
            dgvManageDrivers.DataSource = clsDrivers.DriversWithLicensesFilter(_SelectedIndex, _InputText);


            dgvManageDrivers.Columns["DriverID"].FillWeight = 40;
            dgvManageDrivers.Columns["PersonID"].FillWeight = 40;
            dgvManageDrivers.Columns["NationalNo"].FillWeight = 40;
            dgvManageDrivers.Columns["FullName"].FillWeight = 150;
            dgvManageDrivers.Columns["ActiveLicense"].FillWeight =70;
            dgvManageDrivers.Columns["Date"].FillWeight = 90;

            int realRowCount = dgvManageDrivers.Rows.Cast<DataGridViewRow>()
               .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
            cbFilter.SelectedIndex = 0;


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

            dgvManageDrivers.DataSource = clsDrivers.DriversWithLicensesFilter(_SelectedIndex, _InputText);
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        /*/*//***************************************//*/*//*//*/

        /*/*//***************************************//*/*//*//*/
    }
}
