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
using Full_Project_Desktop.Global_Classes;

namespace Full_Project_Desktop
{
    public partial class ctrl_T_VisionTestAppointment : UserControl

   
    {

        private clsLocalDrivingApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public ctrl_T_VisionTestAppointment()
        {
            InitializeComponent();
        }



        //***///////////////////////////////////////////////////////////

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingApplication.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
           // _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            //incase there is license enable the show link.
            llShowLicenseInfo.Enabled = (_LicenseID != -1);


            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ctrlApplicationBasciInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasciInfo1.ResetApplicationInfo();
            lblDLAppID.Text = "[????]";
            lblAppliedForLicense.Text = "[????]";


        }

        //***///////////////////////////////////////////////////////////

        private void Ctrl_T_VisionTestAppointment_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LblID_Click(object sender, EventArgs e)
        {

        }

        private void LblCreatedBy_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CtrlApplicationBasciInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
