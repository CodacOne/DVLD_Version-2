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
    public partial class Manage_People : Form
    {
        public Manage_People()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            AddNewPerson frmPerson = new AddNewPerson();
            frmPerson.ShowDialog();
        }

        /*/*/ ///    /*/*/ ///    /*/*/ ///

            private void _RefreshContactList()
        {
            dgvManagePeople.DataSource = clsPerson.GetAllPeople();
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Manage_People_Load(object sender, EventArgs e)
        {
            _RefreshContactList();

            lblCountPeople.Text = clsPerson.GetCountPeople().ToString();

            cbFilter.Items.Add("None");
            cbFilter.Items.Add("Person ID");
            cbFilter.Items.Add("National No");
            cbFilter.Items.Add("First Name");
            cbFilter.Items.Add("Second Name");
            cbFilter.Items.Add("Third Name");
            cbFilter.Items.Add("Last Name");
            cbFilter.Items.Add("Nationality");
            cbFilter.Items.Add("Gender");
            cbFilter.Items.Add("Phone");
            cbFilter.Items.Add("Email");
            cbFilter.SelectedIndex = 0;


        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Person frmUpdate = new Update_Person();
            frmUpdate.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilter.Clear();
            _RefreshContactList();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddNewPerson frm = new AddNewPerson((int)dgvManagePeople.CurrentRow.Cells[0].Value);

            frm.Show();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to delete Person [" + dgvManagePeople.CurrentRow.Cells[0].Value + "]",
                "Delete Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPerson.DeleteOnePersonFromTable((int)dgvManagePeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    _RefreshContactList();

                }

                else

                    MessageBox.Show("Person is not deleted Because it has data Linked to it.");
            }
        }

       private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string InputTExtBox = "";
            int    InputNumber = 0;


            InputTExtBox = txtFilter.Text;
            InputNumber = cbFilter.SelectedIndex;

            if (cbFilter.SelectedIndex == 7 || cbFilter.SelectedIndex == 8)
            {
                if (string.IsNullOrWhiteSpace(txtFilter.Text))
                {
                    // المستخدم لم يكتب قيمة بعد، لا تحاول التحويل
                    return;
                }

                if (!int.TryParse(txtFilter.Text, out int value))
                {
                    MessageBox.Show("Please enter a valid integer value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFilter.Focus();
                    return;
                }

             
            }


          
            dgvManagePeople.DataSource = clsPerson.GetPeopleAfterFilter(InputNumber, InputTExtBox);


        }
       

        private void TxtFilter_Validating(object sender, CancelEventArgs e)
        {
            if ( cbFilter.SelectedIndex==1 && !int.TryParse(txtFilter.Text, out int Value))
            {

                e.Cancel = true;
                txtFilter.Focus();
                errorProvider1.SetError(txtFilter, "Should have int Value");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtFilter, "");
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails frm = new ShowDetails((int)dgvManagePeople.CurrentRow.Cells[0].Value);
            frm.Show();


        }

        private void AddNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPerson frm = new AddNewPerson();
            frm.Show();
        }

        private void LblCountPeople_Click(object sender, EventArgs e)
        {

        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            _RefreshContactList();
        }


        /////*/*/**/////////////////////////////////////////////
    }
}
