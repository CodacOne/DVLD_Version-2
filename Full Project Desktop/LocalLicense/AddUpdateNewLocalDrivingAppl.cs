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
using Full_Project_Desktop.Global_Classes;

namespace Full_Project_Desktop
{
    public partial class AddUpdateNewLocalDrivingAppl : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;

        clsApplication _ManageApplication = new clsApplication();

        clsLocalDrivingApplication _LocalDrivingApplication;

      //  private ctrlShowPersonalInfoWithFilter ctrlPersonInfoFilter;


        int _SelectedPersonID = -1;
       
        public AddUpdateNewLocalDrivingAppl()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }


        public AddUpdateNewLocalDrivingAppl(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        /**//**//*/*//*//*//*/*//*/*****/
        private void AddUpdateNewLocalDrivingAppl_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void TpPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private void CtrlPeronDetailsWithFilterNew1_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**//**//*/*//*//*//*/*//*/*****/
        private void BtnApplicationInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedIndex = 1;
                return;
            }


            //incase of add new mode.  
            if (ctrlPeronDetailsWithFilterNew1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedIndex = 1;

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPeronDetailsWithFilterNew1.FilterFocus();
            }
            tcApplicationInfo.SelectedIndex = 1;
        }

        //**/*//*/*/*/**********************////////////////////////////

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        //**/*//*/*/*/**********************////////////////////////////
        private void _ResetDefualtValues()
        {
            _FillLicenseClassesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";

                _LocalDrivingApplication = new clsLocalDrivingApplication();


                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            }

            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";


            }

        }

        /**//**//*/*//*//*//*/*//*/*****/
        private void _LoadData()
        {
            ctrlPeronDetailsWithFilterNew1.ChangeModeToUpdate();
            _LocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }


            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsUsers.FindByUserID(_LocalDrivingApplication.CreatedByUserID).UserName;


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            _SelectedPersonID = ctrlPeronDetailsWithFilterNew1.PersonID;

            int ActiveApplicationID = clsLocalDrivingApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (clsLicense.IsLicenseExistByPersonID(ctrlPeronDetailsWithFilterNew1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LocalDrivingApplication.ApplicantPersonID = ctrlPeronDetailsWithFilterNew1.PersonID; ;
            _LocalDrivingApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingApplication.ApplicationTypeID = 1;
            _LocalDrivingApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingApplication.Save())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /**//**//*/*//*//*//*/*//*/*****/


        /**//**//*/*//*//*//*/*//*/*****/
    }
}
