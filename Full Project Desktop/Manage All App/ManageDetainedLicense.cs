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
        private DataTable _Dt = new DataTable();
        string InputTextBox = "";
        int InputNumber = 0;

        private int _PersonID = -1;


        public ManageDetainedLicense()
        {
            InitializeComponent();
        }


        /*/*//***************************************//*/*//*//*/
        private void RefreshList()
        {

            _Dt = clsDetainLicense.GetAllInfoForListDetain_Dgv(InputNumber, InputTextBox);
            if (_Dt.Rows.Count > 0)
            {
                DataRow row = _Dt.Rows[0];

                // نصوص السائق
                _PersonID = Convert.ToInt32(row["Person_ID"]);


            }

            dgvManageDetain.DataSource = _Dt;

            dgvManageDetain.Columns["D_ID"].FillWeight = 30;
            dgvManageDetain.Columns["L_ID"].FillWeight = 30;
            dgvManageDetain.Columns["N_No"].FillWeight = 50;
            dgvManageDetain.Columns["Is_Released"].FillWeight = 70;
            dgvManageDetain.Columns["FullName"].FillWeight = 130;
            dgvManageDetain.Columns["Person_ID"].FillWeight = 70;


            int realRowCount = dgvManageDetain.Rows.Cast<DataGridViewRow>()
               .Count(row => !row.IsNewRow);

            lblCountRecords.Text = realRowCount.ToString();
            cbFilter.SelectedIndex = 0;


        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
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
            RefreshList();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            InputTextBox = txtFilter.Text;
            InputNumber = cbFilter.SelectedIndex;

        }

        private void DgvManageDetain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.Show();

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.Show();

        }

        private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetailsLicense frm = new ShowDetailsLicense((int)dgvManageDetain.CurrentRow.Cells[1].Value);
            frm.Show();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLicenseHistory frm = new ShowLicenseHistory((int)dgvManageDetain.CurrentRow.Cells[6].Value);
            frm.Show();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails frm = new ShowDetails((int)dgvManageDetain.CurrentRow.Cells[6].Value);
            frm.Show();
        }
    }
}
