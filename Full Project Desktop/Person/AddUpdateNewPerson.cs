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
using System.IO;


using BusinessLayer;
using Full_Project_Desktop;



namespace Full_Project_Desktop
{ 
    public partial class AddUpdateNewPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        // public enum enGendor { Male = 0, Female = 1 };


        private int _PersonID = -1;

        private clsPerson _Person;
       


        public AddUpdateNewPerson( )
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        /// 

        public AddUpdateNewPerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;

        }



       ////////////////////////////////////////////////////////////////////////////////////////

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
                this.Text = "Add New Person";
                _Person = new clsPerson();
            }
           
            else
            {
                lblTitleForm.Text = "Update Person";
                this.Text = "Update Person";
            }

            pbforPerson.Image = Properties.Resources.male2;


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


        ///////////////////////////////////////////////////////////////////
        /// <summary>
        private void _LoadDataToForm( )
        {

            _Person= clsPerson.FindByPersonID(_PersonID);

            if(_Person ==null)
            {
                MessageBox.Show("No Person with ID = "+ _PersonID, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtbLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dateTimePicker1.Value = _Person.DateOfBirth;
            rbMale.Checked = _Person.Gendor == 0 ? true : false;
            rbFemale.Checked = _Person.Gendor == 1 ? true : false;
            clsCountries country = clsCountries.Find(_Person.NationalityCountryID);
            comboBox1.SelectedItem = country.CountryName;

            string ImagePath = _Person.ImagePath;

            if (ImagePath != " " )
            {
                pbforPerson.SizeMode = PictureBoxSizeMode.Zoom;  // ضبط وضع عرض الصورة
                pbforPerson.ImageLocation = ImagePath;

            }

            llRemove.Visible = (ImagePath != "");

        }


        /*/*//*/**************/////*/*//*/**************/////*/*//*/**************////
        private void AddNewPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultsValues();

            if(_Mode == enMode.Update)
            {
                _LoadDataToForm();
            }


        }

        private void UrclAddNewPerson1_Load(object sender, EventArgs e)
        {

        }

        private void LblPersonID_Click(object sender, EventArgs e)
        {
           


        }



        public void Refresh_AddNewPerson()
        {
           
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

            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbforPerson.SizeMode = PictureBoxSizeMode.StretchImage;
                pbforPerson.Load(selectedFilePath);
                llRemove.Visible = true;
                // ...
            }


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

        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {

        }

        /*/*//*/**************/////*/*//*/**************/////*/*//*/**************////

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.

            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                  try      //first we delete the old image from the folder in case there is any.
                  {
                        File.Delete(_Person.ImagePath);
                  }
                  catch (IOException)
                  {
                      // We could not delete the file.
                      //log it later   
                  }
            }


            if (pbforPerson.ImageLocation != null)
            {
                //then we copy the new image to the image folder after we rename it
                string SourceImageFile = pbforPerson.ImageLocation.ToString();

                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbforPerson.ImageLocation = SourceImageFile;
                    return true;
                }

                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        
                return true;
        }


        /*/*//*/**************/////*/*//*/**************/////*/*//*/**************////
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(_Mode != enMode.Update)
            {
                if (!this.ValidateChildren())
                {
                    MessageBox.Show("Some fileds are not Valide!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }


            if (!_HandlePersonImage())
            { return; }

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtbLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim(); 
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();

            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.Gendor = (byte)(rbMale.Checked ? 0 : 1);
            int selectedCountry = clsCountries.Find(comboBox1.Text).CountryID;
            _Person.NationalityCountryID = selectedCountry;

            if (_Person.ImagePath != null)
            {
                _Person.ImagePath = pbforPerson.ImageLocation;
            }

            else
            {
                _Person.ImagePath = null;
            }  
                

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitleForm.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
               // DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void RbMale_Click(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.
            if (pbforPerson.ImageLocation == null)
                pbforPerson.Image =Properties.Resources.male2;
        }

        private void RbFemale_Click(object sender, EventArgs e)
        {

            //change the defualt image to male incase there is no image set.
            if (pbforPerson.ImageLocation == null)
                pbforPerson.Image = Properties.Resources.Female2;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbforPerson.ImageLocation = null;


            if (rbMale.Checked)
                pbforPerson.Image = Properties.Resources.male2;
            else
                pbforPerson.Image = Properties.Resources.Female2;

            llRemove.Visible = false;

        }


        /*//*//*//**************////
        /*/*//*/**************////
    }
}
