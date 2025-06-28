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
            lblLocalDrivingLicenseApplicationID.Text = licenseID.ToString();
            //*
        }


        /*/*//*/*****************//*****************************///*/
      

        /*/*//*/*****************//*****************************///*/
      


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
