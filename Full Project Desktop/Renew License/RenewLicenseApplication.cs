using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;



using BusinessLayer;

namespace Full_Project_Desktop
{
    public partial class RenewLicenseApplication : Form
    {
        clsManageApplication _Application = new clsManageApplication();
        clsIssuedLicense _NewLicense = new clsIssuedLicense();
        clsLocalDrivingApplication _LocalDrivingApplication = new clsLocalDrivingApplication();

        private int  _NewLicenseID = -1;

        private int  _LicenseClassID =-1;
        private int _ApplicationID =-1;
        private int _OldlicenseID = -1;
        private DataTable _DtInfoLicenseTable = new DataTable(); // ال License  معلومات تخص جدول    

        private DataTable _DtAllInfoToRenewLicense = new DataTable(); // معلومات متفرقة 

        private int _PersonID = -1;   // لجلب البيانات الشخصية وتحميلها في ال Show License History


        public RenewLicenseApplication()
        {
            InitializeComponent();
            btnRenewSaved.Enabled = true;
            ctrlDriverLicenseWithFilter1.CurrentMode = ctrlDriverLicenseWithFilter.FormMode.Renew;
        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        public void ChangeMode(bool Status)
        {
            btnRenewSaved.Enabled = !Status;
          
            llShowLicenseInfo.Enabled= !Status;

        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void _LoadDataToObjectAndSaved()
        {
            // جديد  App المرحلة الاولى اضافة 
            if (_DtAllInfoToRenewLicense.Rows.Count > 0)
            {
                DataRow row = _DtAllInfoToRenewLicense.Rows[0];

                _Application.ApplicantPersonID = Convert.ToInt32(row["PersonID"]);

                _Application.ApplicationDate = DateTime.Now;
                _Application.ApplicationTypeID = 2;    //  Renew نوع الطلب 
                _Application.ApplicationStatus = 3;    //  Completed حالة الطلب جديد 
                _Application.LastStatusDate= DateTime.Now;
                _Application.PaidFees = 5;           // $5 Renew رسوم التجديد     
                _Application.CreatedByUserID = clsCurrentUser.CurrentUserID;


                if (_Application.Save())
                {
                   

              MessageBox.Show("Added New Application Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblRLApplicationID.Text = _Application.ApplicationID.ToString();
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
        private void AddedNewLicense()
        {
            // جديد  License المرحلة الثانية اضافة 
            if (_DtAllInfoToRenewLicense.Rows.Count > 0)
            {
                DataRow row = _DtAllInfoToRenewLicense.Rows[0];
                
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

              int  PaidFees = clsDrivers.GetFeesOfLicenseClassTable(LicenseClassID);

                _NewLicense.PaidFees = PaidFees;
                _NewLicense.Notes = txtNotes.Text;


                _NewLicense.IsActive = 1;
                _NewLicense.IssueReason = 2;

                _NewLicense.CreatedByUserID = clsCurrentUser.CurrentUserID;

                if (_NewLicense.Save())
                {
                    int NewLicenseID = _NewLicense.LicenseID;
                    _NewLicenseID = NewLicenseID;
                   
                    MessageBox.Show($"Added New License With ID[{NewLicenseID}] Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();
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

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Label51_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label44_Click(object sender, EventArgs e)
        {

        }

        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {
            // Save Data And Storage it 

            if (MessageBox.Show("Are you Sure to ReNew The License ? ",
               "Renew Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                _LoadDataToObjectAndSaved();
            }

            else
                return;

            
        }

        private void CtrlDriverLicenseWithFilter_RenewDisabled(object sender, bool status)
        {
            ChangeMode(status); // تغيير حالة الزر أو الفورم بناءً على القيمة القادمة
        }


        /*/*//*//*//*********************************************************//*/*///

        public void LoadDataToRenewForm(int licenseID,DataTable DtAllInfoToRenewLicense)
        {

            if (DtAllInfoToRenewLicense.Rows.Count > 0)
            {
                DataRow Row = DtAllInfoToRenewLicense.Rows[0];
                
                _PersonID =Convert.ToInt32( Row["PersonID"]);
            }
                //تحميل البيانات لعرضها على الفورم وبعدها اما اجدد الشهادة او لا     
                _DtAllInfoToRenewLicense = DtAllInfoToRenewLicense;

             _OldlicenseID = licenseID;
            _DtInfoLicenseTable = clsInternationalLicense.GetAllLocalLicenseInfoForRenewLicense(_OldlicenseID);
           
            if (_DtInfoLicenseTable.Rows.Count > 0)
            {
                DataRow row = _DtInfoLicenseTable.Rows[0];

                lblOldLicenseID.Text = row["LicenseID"].ToString();

                _LicenseClassID = Convert.ToInt32(row["LicenseClass"]);
             


                lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);

          lblIssueDate.Text = Convert.ToDateTime(row["IssueDate"]).ToString("dd/MMM/yyyy");
          lblExpirationDate.Text = Convert.ToDateTime(row["ExpirationDate"]).ToString("dd/MMM/yyyy");

          lblApplicationFees.Text = "7";
          int PaidFees = Convert.ToInt32(row["PaidFees"]);
          lblLicenseFees.Text = PaidFees.ToString();

                lblTotFees.Text = (PaidFees + 7).ToString();

                lblCreatedBy.Text = clsCurrentUser.CurrentUserName;
                txtNotes.Text = row["Notes"].ToString();
               
            }

            
            }


        /*/*//*//*//*********************************************************//*/*///

        /*/*//*//*//*********************************************************//*/*///


        private void CtrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.RenewDisabled += CtrlDriverLicenseWithFilter_RenewDisabled;
        }

        private void RenewLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseHistory frm = new ShowLicenseHistory(_PersonID);
            frm.Show();
           
        }

        private void LlShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
          

            ShowDetailsLicense frm = new ShowDetailsLicense(_NewLicenseID);
            frm.Show();


        }
    }
}
