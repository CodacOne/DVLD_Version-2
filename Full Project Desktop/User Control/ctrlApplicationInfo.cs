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
    public partial class ctrlApplicationInfo : UserControl
    {

        clsInternationalLicense _InternationalLicense = new clsInternationalLicense();
        private int _licenseID = -1;
        private DataTable _Dt = new DataTable();
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }


        /*/*//*/*****************//*****************************///*/
        public void LoadDataToForm(int licenseID, DataTable Dt)
        {
            _Dt = Dt; 

           _licenseID = licenseID;

            lblApplicationDate.Text= Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            lblIssueDate.Text= Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            lblExpirationDate.Text = Convert.ToDateTime(DateTime.Now).AddYears(1).ToString("dd/MM/yyyy");
            lblFees.Text = "50";
            lblCreatedBy.Text = clsCurrentUser.CurrentUserName;
            lblLocalLicenseID.Text = licenseID.ToString();
            //*
        }


        /*/*//*/*****************//*****************************///*/
      

        /*/*//*/*****************//*****************************///*/
        public void LoadDataToObject()
        {

            if (_Dt.Rows.Count > 0)
            {
                DataRow row = _Dt.Rows[0];

                DateTime IssueDate = Convert.ToDateTime(row["IssueDate"]);
                DateTime ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]);
                // الحالة 
                bool IsActive = Convert.ToBoolean(row["IsActive"]);

                int AppID = Convert.ToInt32(row["AppID"]);
                int DriverID = Convert.ToInt32(row["DriverID"]);

                /*/*//*/*//*//*///*//*//*//*/

                _InternationalLicense.ApplicationID = AppID;
                _InternationalLicense.DriverID = DriverID;
                _InternationalLicense.IssuedUsingLocalLicenseID = _licenseID;

                _InternationalLicense.IssueDate = DateTime.Now;
                _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

                _InternationalLicense.IsActive = (byte)(IsActive ? 1 : 0);


                _InternationalLicense.CreatedByUserID = clsCurrentUser.CurrentUserID;


                if (IsActive == true && DateTime.Now < ExpirationDate)
                {
                    if (_InternationalLicense.Save())
                    {


           MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblApplicationID.Text = AppID.ToString();
                    lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Data Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("You cannot add because the local license is either inactive or expired.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);


                }

            }

            else
                return;
                    //*
        }



        /*/*//*/*****************//*****************************///*/
        private void GbApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        
        private void LblIssueDate_Click(object sender, EventArgs e)
        {

        }

        private void LblCreatedBy_Click(object sender, EventArgs e)
        {

        }

        private void LblExpirationDate_Click(object sender, EventArgs e)
        {

        }
    }
}
