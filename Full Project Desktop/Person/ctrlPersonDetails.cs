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
    public partial class ctrlPersonDetails : UserControl
    {

        private clsPerson person = new clsPerson();

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
        /*/*//// <summary>
             /// //////////////////////////////////////
             /// 


        public void _LoadDataFromTable(clsPerson person)
        {

            _PersonID = person.PersonID;

            lblPersonID.Text = _PersonID.ToString();


            lblName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;

           LblNationalNo.Text = person.NationalNo;
                                               
       int Gender = person.Gendor;

            if(Gender ==0 && person.ImagePath=="")
            {
                lblGender.Text = "Male";

                pbforPerson.Image = Properties.Resources.male2;
            }



            if (Gender == 1 && person.ImagePath == "")
            {
                lblGender.Text = "Female";

                pbforPerson.Image = Properties.Resources.Female2;
            }
            // lblGender.Text


            lblEmail.Text = person.Email;
            lblAddress.Text = person.Address;
            lblDateOfBirth.Text = person.DateOfBirth.ToString();
            lblPhone.Text = person.Phone;


          int CountryID  = person.NationalityCountryID;

           clsCountries Countries1 = clsCountries.Find(CountryID);

           lblCountry.Text = Countries1.CountryName;







        }




        //////////////////////////////////////////////////////////////////////////////////////////


        /**//// <summary>
            /// ////////*//*/*////////////////////////////////////////

        private void UsclPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void LlEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewPerson frm = new AddNewPerson(_PersonID);
            frm.Show();

        }

        private void PbforPerson_Click(object sender, EventArgs e)
        {

        }
    }
}
