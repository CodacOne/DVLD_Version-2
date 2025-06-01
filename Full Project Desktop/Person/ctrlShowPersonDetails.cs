using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BusinessLayer;


namespace Full_Project_Desktop
{
    public partial class ctrlPersonDetails : UserControl
    {

        private clsPerson _Person;

        private int _PersonID;
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void LblName_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LblAddress_Click(object sender, EventArgs e)
        {

        }
        /*/*/////*/*/////*/*/////*/*/////*/*/////*/*/////*/*/////*/*////

        public void _LoadDataToForm(int PersonID)
        {
            _Person = clsPerson.FindByPersonID(PersonID);

            _PersonID = PersonID;

            if (_Person != null)
            {

                lblPersonID.Text = _PersonID.ToString();
                lblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
                LblNationalNo.Text = _Person.NationalNo;
                lblEmail.Text = _Person.Email;
                lblAddress.Text = _Person.Address;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
                lblPhone.Text = _Person.Phone;
                lblGender.Text = _Person.Gendor == 0 ? "Male" : "Female";

                int CountryID = _Person.NationalityCountryID;
                clsCountries Countries1 = clsCountries.Find(CountryID);
                lblCountry.Text = Countries1.CountryName;
                _LoadImagePerson();
            }



            else       // if _PersonID is not Exist

            {
                ClearPersonInfo();
                MessageBox.Show("No Person with National No. = " + _PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void _LoadImagePerson()
        {

            int Gender = _Person.Gendor;
        
            if (Gender == 0 )
            {
                
                pbforPerson.Image = Properties.Resources.male2;
            }

            else
            {
                pbforPerson.Image = Properties.Resources.Female2;
            }

            string ImagePath = _Person.ImagePath?.Trim();
            if (ImagePath != null)
            {
                if (File.Exists(ImagePath))
                {
                    pbforPerson.SizeMode = PictureBoxSizeMode.Zoom;  // ضبط وضع عرض الصورة
                    pbforPerson.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }


        //////////////////////////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////
        private void ClearPersonInfo()
        {
            lblPersonID.Text = "[?????]";
            lblName.Text = "[?????]";
            LblNationalNo.Text = "[?????]";
            lblGender.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblAddress.Text = "[?????]";
            lblDateOfBirth.Text = "[?????]";
            lblPhone.Text = "[?????]";
            lblCountry.Text = "[?????]";
            pbforPerson.Image = Properties.Resources.Anontmous;

        }

        /////////////////////////////////////////////////////////////////////////

        /**//// <summary>


        private void UsclPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void LlEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // For Update person info
            AddUpdateNewPerson frm = new AddUpdateNewPerson(_PersonID);
            frm.Show();

            // To refresh person info After Update 
            _LoadDataToForm(_PersonID);

        }

        private void PbforPerson_Click(object sender, EventArgs e)
        {

        }
    }
}
