using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BusinessLayer;

namespace Full_Project_Desktop
{
    public partial class ReplacementForLostOrDamagedLicense : Form
    {

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        private DataTable _DtInfoLicenseTable = new DataTable(); // معلومات من جدول الرخص
        private DataTable _DtAllInfoToReplacementLicense = new DataTable(); // معلومات متفرقة للرخصة

        private int _LicenseClassID = -1;
        private int _OldlicenseID = -1;
       

        clsManageApplication _Application = new clsManageApplication();
        clsIssuedLicense _NewLicense = new clsIssuedLicense();
        clsLocalDrivingApplication _LocalDrivingApplication = new clsLocalDrivingApplication();

        private int _NewLicenseID = -1;

        private int _PersonID = -1;   // لجلب البيانات الشخصية وتحميلها في ال Show License History
        private int _ApplicationID = -1;

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///



        public ReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();

            // تعيين الوضع إلى الاستبدال
            ctrlDriverLicenseWithFilter1.CurrentMode = ctrlDriverLicenseWithFilter.FormMode.ReplacementForLostOrDamagedLicense;

            // الاشتراك في حدث تحديد الرخصة
            ctrlDriverLicenseWithFilter1.LicenseIDSelectedForReplacement += Ctrl_LicenseIDSelectedForReplacement;

            // الاشتراك في حدث تعطيل/تفعيل زر الحفظ (تمت الإضافة هنا)
            ctrlDriverLicenseWithFilter1.ReplacementDisabled += CtrlDriverLicenseWithFilter1_ReplacementDisabled;
        }

        private void CtrlDriverLicenseWithFilter1_ReplacementDisabled(object sender, bool isDisabled)
        {
           btnSaved.Enabled = !isDisabled;
          
            llShowLicenseInfo.Enabled = !isDisabled;

        }


        /*/*//*/*//******************************//**//// <summary>


           /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void _LoadDataToObjectAndSaved()
        {
            // جديد  App المرحلة الاولى اضافة 
            if (_DtAllInfoToReplacementLicense.Rows.Count > 0)
            {
                DataRow row = _DtAllInfoToReplacementLicense.Rows[0];

                _Application.ApplicantPersonID = Convert.ToInt32(row["PersonID"]);

              
                _Application.ApplicationDate = DateTime.Now;

                if (rbtnDamagedLicense.Checked)
                {
                    _Application.ApplicationTypeID = 4;
                    _Application.PaidFees = 5;           // $5 Damaged رسوم التجديد 
                }
                else if (rbtnLostLicense.Checked)
                {
                    _Application.ApplicationTypeID = 3;
                    _Application.PaidFees = 10;           // $10 Lost رسوم التجديد  
                }

               
                //  Renew نوع الطلب 
                _Application.ApplicationStatus = 3;    //  Completed حالة الطلب جديد 
                _Application.LastStatusDate = DateTime.Now;
                  
                _Application.CreatedByUserID = clsCurrentUser.CurrentUserID;


                if (_Application.Save())
                {


                    MessageBox.Show("Added New Application Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblLRApplicationID.Text = _Application.ApplicationID.ToString();
                    _ApplicationID = _Application.ApplicationID;

                    _LocalDrivingApplication.ApplicationID = _ApplicationID;
                    _LocalDrivingApplication.LicenseClassID = _LicenseClassID;

                    if (_LocalDrivingApplication.Save())
                    {

                        AddedNewLicense();
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
        private void AddedNewLicense()
        {
            // جديد  License المرحلة الثانية اضافة 
            if (_DtAllInfoToReplacementLicense.Rows.Count > 0)
            {
                DataRow row = _DtAllInfoToReplacementLicense.Rows[0];

                _NewLicense.ApplicationID = _ApplicationID;
                _NewLicense.DriverID = Convert.ToInt32(row["DriverID"]);
                int LicenseClassID = Convert.ToInt32(row["LicenseClassID"]);

                _NewLicense.LicenseClassID = LicenseClassID;

                _NewLicense.IssueDate = DateTime.Now;

                if (LicenseClassID == 1 || LicenseClassID == 2)
                {
                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(5);
                }

                else
                {

                    _NewLicense.ExpirationDate = DateTime.Now.AddYears(10);
                }

                int PaidFees = clsDrivers.GetFeesOfLicenseClassTable(LicenseClassID);

                _NewLicense.PaidFees = PaidFees;
                _NewLicense.Notes = "";


                _NewLicense.IsActive = 1;

                if (rbtnDamagedLicense.Checked)
                {
                    _NewLicense.IssueReason = 3;  //  سبب التجديد هو تضرر 

                }
                else if (rbtnLostLicense.Checked)
                {
                    _NewLicense.IssueReason = 4;  //  سبب التجديد هو ضياع 

                }

                

                _NewLicense.CreatedByUserID = clsCurrentUser.CurrentUserID;

                if (_NewLicense.Save())
                {
                    int NewLicenseID = _NewLicense.LicenseID;
                    _NewLicenseID = NewLicenseID;

                    MessageBox.Show($"Added New License With ID[{NewLicenseID}] Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
                    DisabledOldLicense(_OldlicenseID);
                }

                else
                {
                    MessageBox.Show("Added New License Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }



        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///


        private void DisabledOldLicense(int OldlicenseID)
        {

            clsIssuedLicense.DisabledOldLicense(OldlicenseID);

        }
        private void ReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            // يمكن إضافة أي تهيئة إضافية هنا لاحقاً
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        private void Ctrl_LicenseIDSelectedForReplacement(object sender, int licenseID)
        {
            // جلب البيانات من قاعدة البيانات أو من الكنترول نفسه
            _DtAllInfoToReplacementLicense = clsDrivers.GetDataForInternationalLicenseApplication(licenseID);

            LoadDataToReplacementForm(licenseID, _DtAllInfoToReplacementLicense);
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        public void LoadDataToReplacementForm(int licenseID, DataTable DtAllInfoToReplacementLicense)
        {
            if (DtAllInfoToReplacementLicense.Rows.Count > 0)
            {
                DataRow Row = DtAllInfoToReplacementLicense.Rows[0];

                _PersonID = Convert.ToInt32(Row["PersonID"]);
            }


            _DtAllInfoToReplacementLicense = DtAllInfoToReplacementLicense;
            _OldlicenseID = licenseID;

            _DtInfoLicenseTable = clsInternationalLicense.GetAllLocalLicenseInfoForRenewLicense(_OldlicenseID);

            if (_DtInfoLicenseTable.Rows.Count > 0)
            {
                DataRow row = _DtInfoLicenseTable.Rows[0];

                lblOldLicenseID.Text = row["LicenseID"].ToString();
                _LicenseClassID = Convert.ToInt32(row["LicenseClass"]);

                lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                lblApplicationFees.Text = "5"; 

                 if (rbtnDamagedLicense.Checked)
                {
                    
                    lblApplicationFees.Text = "5";          // $5 Damaged رسوم التجديد 
                }

                else if (rbtnLostLicense.Checked)
                {
                   
                    lblApplicationFees.Text = "10";        // $10 Lost رسوم التجديد  
                }

                lblCreatedBy.Text = clsCurrentUser.CurrentUserName;
            }
            else
            {
                MessageBox.Show("License data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        public void ChangeMode(bool Status)
        {
            btnSaved.Enabled = !Status;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // الأحداث الأخرى حسب الحاجة
        private void BtnSaveurcl_Click(object sender, EventArgs e) { }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void BtnSaved_Click(object sender, EventArgs e)
        {

            // Save Data And Storage it 

            if (MessageBox.Show("Are you Sure to Replacement The License ? ",
               "Replacement Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                _LoadDataToObjectAndSaved();
            }

            else
                return;


        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void GroupBox2_Enter(object sender, EventArgs e) { }

        private void Label8_Click(object sender, EventArgs e) { }

        private void Label33_Click(object sender, EventArgs e) { }

        private void CtrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void LlShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ShowDetailsLicense frm = new ShowDetailsLicense(_NewLicenseID);
            frm.Show();
        }
        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void LlLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseHistory frm = new ShowLicenseHistory(_PersonID);
            frm.Show();
        }
    }
}
