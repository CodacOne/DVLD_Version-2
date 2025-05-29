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
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _licenseID = -1;

        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
           
         
          
       }


        /*/*//*/*///*****************************//*/*//*//*///
        /*/*//*/*///*****************************//*/*//*//*///
        public void LoadDataToForm(int licenseID)
        {
            _licenseID = licenseID;


            DataTable Dt = clsInternationalLicense.GetInternationalLicenseInfo(_licenseID);

            if (Dt != null && Dt.Rows.Count > 0)
            {
                DataRow row = Dt.Rows[0];

                lblName.Text = $"{row["FirstName"]} {row["SecondName"]} {row["ThirdName"]} {row["LastName"]}";
                lblIntenationalLicenseID.Text = row["InternationalLicenseID"].ToString();
                lblApplicationID.Text = row["ApplicationID"].ToString();
                lblLicenseID.Text = row["LicenseID"].ToString();
                lblIsActive.Text = ((bool)row["IsActive"]) ? "Yes" : "No";
                lblNationalNo.Text = row["NationalNo"].ToString();
                lblDateOfBirth.Text = Convert.ToDateTime(row["DateOfBirth"]).ToString("dd/MMM/yyyy");
                lblGender.Text = (row["Gendor"].ToString() == "0") ? "Male" : "Female";

                lblDriverID.Text = row["DriverID"].ToString();
                lblIssueDate.Text = Convert.ToDateTime(row["IssueDate"]).ToString("dd/MMM/yyyy");
                lblExpiDate.Text = Convert.ToDateTime(row["ExpirationDate"]).ToString("dd/MMM/yyyy");

                // تحميل صورة السائق إن وجدت
                if (row["ImagePath"] != DBNull.Value && File.Exists(row["ImagePath"].ToString()))
                {
                    pictureBox9.Image = Image.FromFile(row["ImagePath"].ToString());
                }
                else
                {
                    pictureBox9.Image = null; // أو صورة افتراضية
                }
            }


            else
            {
                MessageBox.Show("No data found for the selected license ID.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
