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
    public partial class ctrlPersonAndUserInformation : UserControl
    {

        public string _Password = "";
        public string _NewPassword = "";

        public int _UserID = -1;

        public ctrlPersonAndUserInformation()
        {
            InitializeComponent();
        }

        private void UsclPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        public void _LoadUserDataToForm(int PersonID)
        {
            DataTable Dt = clsUsers.GetPersonAndUserInformation(PersonID);


            if(Dt != null && Dt.Rows.Count>0)
            {
                DataRow Row = Dt.Rows[0];

                lblPersonID.Text = Row["PersonID"].ToString();
                lblName.Text = Row["FirstName"].ToString() + " " + Row["SecondName"].ToString() + " " + Row["ThirdName"].ToString() + " " +
                    Row["LastName"].ToString() + " ";
                LblNationalNo.Text = Row["NationalNo"].ToString();

               int Gender = Convert.ToInt32( Row["Gendor"]);
                lblGender.Text = Gender == 0 ? "Male" : "Femal";

                lblEmail.Text = Row["Email"].ToString();
                lblAddress.Text = Row["Address"].ToString();
               
                lblDateOfBirth.Text = Row["DateOfBirth"].ToString();
                lblPhone.Text = Row["Phone"].ToString();

               string ImagePath = Row["ImagePath"].ToString();


               
                if (ImagePath != null && System.IO.File.Exists(ImagePath))
                {
                    pbforPerson.Image = Image.FromFile(ImagePath);

                }

                else

                {
                    if (Gender == 0)
                    {
                        pbforPerson.Image = Properties.Resources.male2;
                    }

                    else
                    {
                        pbforPerson.Image = Properties.Resources.Female2;

                    }

                }



                lblCountry.Text = Row["CountryName"].ToString();

                _UserID = Convert.ToInt32(Row["UserID"]);
                lblUserID.Text = _UserID.ToString();

                lblUserName.Text = Row["UserName"].ToString();
                int Active = Convert.ToInt32(Row["IsActive"]);

                lblIsActive.Text = Active == 1 ? "Yes" : "No";

                _Password= Row["Password"].ToString();
            }


        }


        private void LblCountry_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CtrlPersonAndUserInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
