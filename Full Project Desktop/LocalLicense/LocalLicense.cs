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
    public partial class LocalLicense : Form
    {
        clsManageApplication _ManageApplication = new clsManageApplication();

        clsLocalDrivingApplication _LocalDrivingApplication = new clsLocalDrivingApplication();


        public LocalLicense()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpLoginInfo;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            
        }

        private void TpLoginInfo_Click(object sender, EventArgs e)
        {

        }


        //**/*//*/*/*/**********************////////////////////////////


        private void _LoadDataTableApplicationFrom_Form()
        {
            _ManageApplication.ApplicantPersonID = ctrl2PersonalInfoWithFilter1._PersonID;
            _ManageApplication.ApplicationDate =DateTime.Parse(lblApplicationDate.Text);

            _ManageApplication.ApplicationTypeID = 1;
            _ManageApplication.ApplicationStatus = 1;
            _ManageApplication.LastStatusDate = DateTime.Now;
            _ManageApplication.PaidFees =float.Parse(lblApplicationFees.Text);
            _ManageApplication.CreatedByUserID = clsCurrentUser.CurrentUserID;
        }

        //**/*//*/*/*/**********************////////////////////////////


        private void _LoadDataTableLocalDrivingApplicationFrom_Form()
        {
            _LocalDrivingApplication.LicenseClassID = cbLicenseClass.SelectedIndex+1;

            _LocalDrivingApplication.ApplicationID = clsManageApplication._ApplicationID;

               
        }

        //**/*//*/*/*/**********************////////////////////////////

        private void LocalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString();

            lblCreatedBy.Text = clsCurrentUser.CurrentUserName;

            cbLicenseClass.SelectedIndex = 1;


        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TpPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        //*************/************************////////////////////////////////////

        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {
            //String NationalNo, int LicenseClassID

            //if (clsLocalDrivingApplication.ValidationIfExistSamelicenseClassOfSamePeople())
            //{

            //    *
            //}


            _LoadDataTableApplicationFrom_Form();


            //*/*/*************//*********************************************


            if (clsLocalDrivingApplication.CheckIfThereIsAPreviousOpenApplication
                    (ctrl2PersonalInfoWithFilter1._PersonID, cbLicenseClass.SelectedIndex + 1))
            {

                MessageBox.Show(
            $"Choose another License Class, the selected person already has an active application for the selected class with PersonID = {ctrl2PersonalInfoWithFilter1._PersonID}",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);


                return;
            }

            //*/*/*************//*********************************************


            if (_ManageApplication.Save())
            {
                _LoadDataTableLocalDrivingApplicationFrom_Form();

              


                if (_LocalDrivingApplication.Save())
                {
                    lblLocalDrivingApplication.Text = _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
                    MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Local Driving Application Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            else

                MessageBox.Show("Data Saved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }


        //*************/************************////////////////////////////////////

        //*************/************************////////////////////////////////////
    }
}
