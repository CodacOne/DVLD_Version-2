using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

using BusinessLayer;
using Full_Project_Desktop;



namespace Full_Project_Desktop
{ 
    public partial class AddNewPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        // public enum enGendor { Male = 0, Female = 1 };


        private int _PersonID = -1;

        private clsPerson _Person;
       


        public AddNewPerson( )
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        /// 

        public AddNewPerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;

        }



       ////////////////////////////////////////////////////////////////////////////////////////

        private void _ChangeMode()
        {

                    lblPersonID.Text = _Person.PersonID.ToString();
                    lblTitleForm.Text = "Update Person";
                   
     
        }


        
        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        ///////////////////////////////////////////////////////////////////
        /*/*//*/**************/////*/*//*/**************/////*/*//*/**************////
        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsPerson.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["CountryName"]);

            }

            comboBox1.SelectedIndex = 168;
        }



        ///////////////////////////////////////////////////////////////////
        private void _ResetDefaultsValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitleForm.Text = "Add New Person";
            }
           
            else
            {
                lblTitleForm.Text = "Update Person";
            }


            if(rbMale.Checked)
            {
                pbforPerson.Image = Properties.Resources.male2;
            }

            else
            {
                pbforPerson.Image = Properties.Resources.Female2;
            }

            llRemove.Visible = (pbforPerson.ImageLocation != null);


            txtFirstName.Text = "";
            txtSecondName.Text= "";
            txtThirdName.Text = "";
            txtbLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            rbMale.Checked = true;
        
              

        }
        /*/*//*/**************/////*/*//*/**************/////*/*//*/**************////
        private void AddNewPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultsValues();

            if(_Mode == enMode.Update)
            {
               
            }


        }

        private void UrclAddNewPerson1_Load(object sender, EventArgs e)
        {

        }

        private void LblPersonID_Click(object sender, EventArgs e)
        {
           


        }


        public static void RefreshData(int ID, ctrlAddNewPerson userControl)
        {
           
          
        }


        public void Refresh_AddNewPerson()
        {
            lblPersonID.Text = ID1.ToString();
            lblTitleForm.Text = "Update Person";
        }

        private void TxtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {

                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "Should have a Value");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {

            TextBox txt = sender as TextBox;

            try
            {
                var mail = new MailAddress(txt.Text);

                errorProvider1.SetError(txt, "");
            }


            catch
            {

                errorProvider1.SetError(txt, "Invalid Email Address Format");
                e.Cancel = true; // 
                txt.Focus();
            }

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbforPerson.Image = new Bitmap(openFileDialog1.FileName);
            }

            _Remove_Visible();
        }

        private void TxtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {

                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Should have a Value");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtAddress, "");
            }
        }
        ////////////////////////////////////////
        private void _Remove_Visible()
        {
            if (pictureBox1.Image != null)
            {
                llRemove.Visible = true;

            }

            else

                llRemove.Visible = false;
        }
        /*/*//*/**************/////*/*//*/**************/////*/*//*/**************////
      
        /*/*//*/**************////
                               /// ////////////////////////////////////////
        private bool _FindNationalNumber()
        {
            if (clsPerson.IsNationalNumber(txtNationalNo.Text))
            {
                return true;

            }

            else

                return false;

        }
        /*/*//*/**************////
        /*/*//*/**************////


        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TxtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (_FindNationalNumber())
            {

                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtNationalNo, "National No Is Found");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtNationalNo, "");
            }
        }


    }
}
