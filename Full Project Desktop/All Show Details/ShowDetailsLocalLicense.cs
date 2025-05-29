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
    public partial class ShowDetailsLicense : Form
    {
        private DataTable _Dt = new DataTable();

        private DataTable _DtForDriverInfo = new DataTable();

        private int _LicenseID = -1;

        public ShowDetailsLicense(int LicenseID)
        {
         InitializeComponent();

            _LicenseID = LicenseID;
            //  _Dt = clsLocalDrivingApplication.GetAllDataToSchedulingTest(LocalDrivingLicenseApplicationID);

            // عرض الداتا داخل الفورم
            FilDataToForm();

        }


        /**//*/*//*/*//*/**//*/*//***//*****//*****//***///*/////*
                                                         /**//*/*//*/*//*/**//*/*//***//*****//*****//***//*/////*/

        private void FilDataToForm()
        {

          //  DataRow row1 = _Dt.Rows[0]; 

          //int  ApplicationID = Convert.ToInt32(row1["ApplicationID"]);
            

            /**//*/*//*/*//*/**//*/*//***//*****//*****//***//*/////*/

           
            _DtForDriverInfo = clsDrivers.GetAllDriverInfo(_LicenseID);
            DataRow row = _DtForDriverInfo.Rows[0];

           // نصوص السائق
           lblClass.Text = row["ClassName"].ToString();
            lblName.Text = $"{row["FirstName"]} {row["SecondName"]} {row["ThirdName"]} {row["LastName"]}";
            int LicenseID =Convert.ToInt32( row["LicID"]);
            lblLicenseID.Text = LicenseID.ToString();

            lblNationalNo.Text = row["NationalNo"].ToString();
            lblGender.Text = (Convert.ToBoolean(row["Gendor"])) ? "Female" : "Male";


            lblDateBirth.Text = Convert.ToDateTime(row["DateOfBirth"]).ToString("dd/MM/yyyy");
            lblDriverID.Text = row["DriverID"].ToString();


            // التواريخ
            lblIssueDate.Text = Convert.ToDateTime(row["IssueDate"]).ToString("dd/MM/yyyy");
            lblExpirationDate.Text = Convert.ToDateTime(row["ExpirationDate"]).ToString("dd/MM/yyyy");

            // الحالة
            lblIsActive.Text = (Convert.ToBoolean(row["IsActive"])) ? "Yes" : "No";

            if(clsIssuedLicense.IsLicenseDetainedOrNotDetained(LicenseID))
            {
                lblIsDetained.Text = "Yes";
            }

          else  
            {
                lblIsDetained.Text = "No";
            }


            int IssueReason =Convert.ToInt32( row["IssueReason"]);

            switch(IssueReason)
            {
                case 1:
                 lblIssueReason.Text = "FirstTime";
                 break;

                case 2:
                    lblIssueReason.Text = "ReNew";
                    break;
                   
                case 3:
                    lblIssueReason.Text = "Replacement for Damaged";
                    break;

                case 4:
                    lblIssueReason.Text = "Replacement for Lost";
                    break;


            }
            


            lblNotes.Text = row["Notes"].ToString();

            // تحميل الصورة
            if (System.IO.File.Exists(row["ImagePath"].ToString()))
            {
                pictureBox1.Image = Image.FromFile(row["ImagePath"].ToString());
            }
            else
            {
                pictureBox1.Image = null;
            }
                 


        }
              /**//*/*//*/*//*/**//*/*//***//*****//*****//***///*////
              /**//*/*//*/*//*/**//*/*//***//*****//*****//***///*////
         private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LblDateBirth_Click(object sender, EventArgs e)
        {

        }

        private void ShowDetailsLicense_Load(object sender, EventArgs e)
        {

        }

        private void LblIssueReason_Click(object sender, EventArgs e)
        {

        }

        private void LblIsDetained_Click(object sender, EventArgs e)
        {

        }

        private void LblExpirationDate_Click(object sender, EventArgs e)
        {

        }
    }
}
