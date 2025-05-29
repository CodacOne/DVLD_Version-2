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
using System.Globalization;


namespace Full_Project_Desktop
{
    public partial class ReleaseDetainedLicense : Form
    {

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private DataTable _DtInfoDetainTable = new DataTable(); // معلومات من جدول الرخص
        private DataTable _DtAllInfoToReleaseLicense = new DataTable(); // معلومات متفرقة للرخصة

       private int _Release_AppID = -1;
        private int _licenseID = -1;
        private int _DetainID = -1;
        private int _PersonID = -1;   // لجلب البيانات الشخصية وتحميلها في ال Show License History
        private int _LicenseClassID = -1;
        clsDetainLicense _DetainLicense = new clsDetainLicense();

        clsManageApplication _Application = new clsManageApplication();
        clsIssuedLicense _NewLicense = new clsIssuedLicense();
        clsLocalDrivingApplication _LocalDrivingApplication = new clsLocalDrivingApplication();


        public ReleaseDetainedLicense()
        {
            InitializeComponent();
            ctrlDriverLicenseWithFilter1.CurrentMode = ctrlDriverLicenseWithFilter.FormMode.Release;
            ctrlDriverLicenseWithFilter1.ReleaseSaveStateChanged += Ctrl_ReleaseSaveStateChanged;
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
                                                               /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        public void LoadDataToReleaseForm(int licenseID, DataTable DtAllInfoToReleaseLicense)
        {
            // تحميل البيانات  في الفورم
            _DtAllInfoToReleaseLicense = DtAllInfoToReleaseLicense;

            if (_DtAllInfoToReleaseLicense.Rows.Count > 0)
            {
                DataRow Row = _DtAllInfoToReleaseLicense.Rows[0];

                _PersonID = Convert.ToInt32(Row["PersonID"]);
               // _Release_AppID= Convert.ToInt32(Row["AppID"]);
                _LicenseClassID = Convert.ToInt32(Row["LicenseClassID"]);
            }


            _licenseID = licenseID;

            _DtInfoDetainTable = clsDetainLicense.GetAllDetainInfoByLicenseID(_licenseID);

            if (_DtInfoDetainTable.Rows.Count > 0)
            {
                DataRow row = _DtInfoDetainTable.Rows[0];


                _DetainID = Convert.ToInt32(row["DetainID"]);
                lblDetainID.Text= _DetainID.ToString();
                lblLicenseID.Text = row["LicenseID"].ToString();
                lblCreatedBy.Text = clsCurrentUser.CurrentUserName;

                lblDetainDate.Text = Convert.ToDateTime(row["DetainDate"]).ToString("dd/MMM/yyyy");

                int FineFees = Convert.ToInt32(row["FineFees"]);
                lblFineFees.Text = FineFees.ToString();

                
                lblApplicationFees.Text = "15";

                lblTotalFees.Text = (FineFees + 15).ToString();


              
            }
            else
            {
                MessageBox.Show("License data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void CreateNewApplicationForReleases()
        {

            // جديد  App المرحلة الاولى اضافة 
            if (_DtAllInfoToReleaseLicense.Rows.Count > 0)
            {
                DataRow row = _DtAllInfoToReleaseLicense.Rows[0];

                _Application.ApplicantPersonID = Convert.ToInt32(row["PersonID"]);
                
                _Application.ApplicationDate = DateTime.Now;
                _Application.ApplicationTypeID = 5;    //  Release  نوع الطلب 
                _Application.ApplicationStatus = 3;    //  Completed حالة الطلب جديد 
                _Application.LastStatusDate = DateTime.Now;
                _Application.PaidFees =15;           // $5 Renew رسوم التجديد     
                _Application.CreatedByUserID = clsCurrentUser.CurrentUserID;


                if (_Application.Save())
                {

                   
               MessageBox.Show("Added New Application Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblRAppID.Text = _Application.ApplicationID.ToString();
                    _Release_AppID = _Application.ApplicationID;
                    
                    _LocalDrivingApplication.ApplicationID = _Release_AppID;
                    _LocalDrivingApplication.LicenseClassID = _LicenseClassID;
                    if (_LocalDrivingApplication.Save())
                    {

                        MessageBox.Show("Added New Local License Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                else
                {
                    MessageBox.Show("Added New Application Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void _LoadDataToObjectAndSaved()
        {
           

            //    المرحلة الاولى _Release_AppID    جديد    انشاء 

            CreateNewApplicationForReleases();

            // فك حجز الرخصة  Detain    المرحلة الثانية    
            if (_DtInfoDetainTable.Rows.Count > 0)
            {
                DataRow row = _DtInfoDetainTable.Rows[0];

                DateTime ReleaseDate = DateTime.Now;
               int ReleasedByUserID = clsCurrentUser.CurrentUserID;
                int ReleaseApplicationID = _Release_AppID;
                bool IsReleaseId = true;

        //        int DetainID, bool IsReleased, DateTime? ReleaseDate,
        //int? ReleasedByUserID, int? ReleaseApplicationID

                
                if (clsDetainLicense.UpdateDetain(_DetainID, IsReleaseId, ReleaseDate,
                    ReleasedByUserID, ReleaseApplicationID))
                {
                   
                   
                    MessageBox.Show("License Released Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("License Released Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void Ctrl_ReleaseSaveStateChanged(object sender, bool isEnabled)
        {
            btnSaved.Enabled = isEnabled; // أو أي زر
        }

      

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }
        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void BtnSaved_Click(object sender, EventArgs e)
        {
            // Save Data And Storage it 

            if (MessageBox.Show("Are you Sure to Detain The License ? ",
               "Detain Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                _LoadDataToObjectAndSaved();
            }

            else
                return;
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CtrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void LlShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDetailsLicense frm = new ShowDetailsLicense(_licenseID);
            frm.Show();
        }

        private void LlLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseHistory frm = new ShowLicenseHistory(_PersonID);
            frm.Show();
        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
    }
}
