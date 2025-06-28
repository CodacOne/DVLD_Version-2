using BusinessLayer;
using Full_Project_Desktop.Global_Classes;
using Full_Project_Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Project_Desktop
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsInternationalLicense _InternationalLicense;
      
        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }


        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
           
         
          
       }


        /*/*//*/*///*****************************//*/*//*//*///
        /*/*//*/*///*****************************//*/*//*//*///
       

        private void PictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void LblName_Click(object sender, EventArgs e)
        {

        }

        private void LblLicenseID_Click(object sender, EventArgs e)
        {

        }

        private void _LoadPersonImage()
        {

          if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0)
                    { pbforPerson.Image = Resources.Male_512; }


            else
            { pbforPerson.Image = Resources.Female_512; }

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))

                {
                    pbforPerson.SizeMode = PictureBoxSizeMode.Zoom;
                    pbforPerson.ImageLocation = ImagePath;
                }

                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            lblIntenationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_InternationalLicense.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicense.IssueDate);
            lblExpiDate.Text = clsFormat.DateToShort(_InternationalLicense.ExpirationDate);

            _LoadPersonImage();



        }


        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void pbforPerson_Click(object sender, EventArgs e)
        {

        }
    }
}
