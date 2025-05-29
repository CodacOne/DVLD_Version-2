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
    public partial class ctrl2PersonalInfoWithFilter : UserControl
    {
       

        private string InputTextBox = "";
        private int InputNumber = 0;

        public int __PersonID = -1;

        public int _PersonID
        {
            get; set;
        }


        public ctrl2PersonalInfoWithFilter()
        {
            InitializeComponent();
        }

        private void Ctrl2PersonalInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 2;
        }


        public void ChangeModeToUpdate()
        {
            gbFilter.Enabled = false;
        }


        private void TxtBySearch_TextChanged(object sender, EventArgs e)
        {

            InputTextBox = txtBySearch.Text;
            InputNumber = cbFilter.SelectedIndex;


        }


        /*/*//*/*//*/*//// <summary>
        public void _LoadDataToForm(clsPerson Person)
        {


            if (Person != null)
            {
                // DataRow row = dt.Rows[0];

                _PersonID = Person.PersonID;
                lblPersonID.Text = _PersonID.ToString();



                LblNationalNo.Text = Person.NationalNo;

                lblName.Text = Person.FirstName + " " + Person.SecondName
                  + " " + Person.ThirdName + " " + Person.LastName;

                lblDateOfBirth.Text = Person.DateOfBirth.ToString();

                int Gender = Person.Gendor;

                if (Gender == 0)
                {
                    lblGendor.Text = "Male";
                }

                else
                {
                    lblGendor.Text = "Female";

                }

                lblAddress.Text = Person.Address;
                lblPhone.Text = Person.Phone;
                lblEmail.Text = Person.Email;


                string ImagePath = Person.ImagePath;


                ////

                if (ImagePath != null && System.IO.File.Exists(ImagePath))
                {
                    pbForUser.Image = Image.FromFile(ImagePath);

                }

                else

                {
                    if (Gender == 0)
                    {
                        pbForUser.Image = Properties.Resources.male2;
                    }

                    else
                    {
                        pbForUser.Image = Properties.Resources.Female2;

                    }

                }


                int CountryID = Person.NationalityCountryID;

                //
                clsCountries country = clsCountries.Find(CountryID);
                if (country != null)
                {
                    lblCountry.Text = country.CountryName;
                }


                //////////////////////////////////////////////////////////////////////
            }

            else
            {
                MessageBox.Show("No Person With National No =" + InputTextBox, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClearPersonInfo();
            }

        }


        //////////////////////////////////////////////////////////////////////
        private void ClearPersonInfo()
             {
            lblPersonID.Text = "[?????]";
            lblName.Text = "[?????]";
            LblNationalNo.Text = "[?????]";
            lblGendor.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblAddress.Text = "[?????]";
            lblDateOfBirth.Text = "[?????]";
            lblPhone.Text = "[?????]";
            lblCountry.Text = "[?????]";
            pbForUser.Image = Properties.Resources.Anontmous;

             }
             
    /////////////////////////////////////////////////////////////////////////
    /* 

      */


    /// //////////////////////////////////////////////////////////////////////

    private void PbSearch_Click(object sender, EventArgs e)
        {

          


        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddNewPerson frm = new AddNewPerson();
            frm.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
          


            switch (InputNumber)
            {  
               //  person=new clsPerson();

                case 2:
                   clsPerson   person = clsPerson.FindByNationalNo(InputTextBox);
                    _LoadDataToForm(person);
                    break;

                case  1:
                     person = clsPerson.FindByPersonID(Convert.ToInt32( InputTextBox));
                    _LoadDataToForm(person);
                    break;

                default :
                    MessageBox.Show("Error");
                    cbFilter.Focus();
                    break;
            }

           
        }

        private void TxtNext_Click(object sender, EventArgs e)
        {
            

        }


        public int ValidatingforUser()
        {

            if (!clsUsers.IsUserExistOrNot(__PersonID))
            {
                return __PersonID;
            }

            else

                return -2;


        }

        private void LblDateOfBirth_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewPerson frm = new AddNewPerson(__PersonID);
            frm.Show();
        }

        private void PbForUser_Click(object sender, EventArgs e)
        {

        }

        /**//**//**//**//**/////////////////////////////////////////////
    }
}
