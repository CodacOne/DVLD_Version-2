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
    public partial class Manage_Users : Form
    {
        public Manage_Users()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Add_New_User frmAdd_New_User = new Add_New_User();
            frmAdd_New_User.Show();
        }

        private void CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password frmChange_Password = new Change_Password((int)dgvManageUsrs.CurrentRow.Cells[1].Value);
            frmChange_Password.ShowDialog();
        }

        private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_User frmAdd_New_User = new Add_New_User();
            frmAdd_New_User.Show();
        }

        private void Manage_Users_Load(object sender, EventArgs e)
        {
            lblCountRecords.Text = clsUsers.GetCountUsers().ToString();

            _RefreshUsersList();


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }


        /*/*//*/*******************************/////////////////////////////

        private void _RefreshUsersList()
        {
            dgvManageUsrs.DataSource= clsUsers.GetAllUsers();
            dgvManageUsrs.Columns["FullName"].FillWeight = 200;
        }

        /*/*//*/*******************************/////////////////////////////

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string InputTExtBox = "";
            int InputNumber = 0;


            InputTExtBox = txtSearch.Text;
            InputNumber = cbFilter.SelectedIndex;

            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 3)
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    // المستخدم لم يكتب قيمة بعد، لا تحاول التحويل
                    return;
                }


            }

            dgvManageUsrs.DataSource = clsUsers.GetUsersAfterFilter(InputNumber, InputTExtBox);

        }

        private void TxtSearch_Validating(object sender, CancelEventArgs e)
        {
            //if (!int.TryParse(txtSearch.Text, out int value))
            //{
            //    MessageBox.Show("Please enter a valid integer value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSearch.Focus();
            //    return;
            //}

            if ((cbFilter.SelectedIndex==1 || cbFilter.SelectedIndex == 3 ) &&  !int.TryParse(txtSearch.Text, out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "Please enter a valid integer value.");
                txtSearch.Focus();
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSearch, "");
            }



        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_User frm = new Add_New_User((int)dgvManageUsrs.CurrentRow.Cells[1].Value);
            frm.Show();

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you want to delete User [" + dgvManageUsrs.CurrentRow.Cells[0].Value + "]",
                "Delete Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUsers.DeleteOneUserFromTable((int)dgvManageUsrs.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.");
                    _RefreshUsersList();

                }

                else

                    MessageBox.Show("User is not deleted Because it has data Linked to it.");
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetailsForPersonAndUser frm = new ShowDetailsForPersonAndUser((int)dgvManageUsrs.CurrentRow.Cells[1].Value);
            frm.Show();
        }

        private void LblCountRecords_Click(object sender, EventArgs e)
        {

        }

        private void DgvManageUsrs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            _RefreshUsersList();
        }


        /*/*//*/*******************************/////////////////////////////


    }
}
