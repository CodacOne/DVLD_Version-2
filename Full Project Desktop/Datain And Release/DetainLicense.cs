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
    public partial class DetainLicense : Form
    {

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private DataTable _DtInfoLicenseTable = new DataTable(); // معلومات من جدول الرخص
        private DataTable _DtAllInfoToDetainLicense = new DataTable(); // معلومات متفرقة للرخصة

        private int _LicenseClassID = -1;
        private int _licenseID = -1;
        private int _DetainID = -1;

        clsDetainLicense _DetainLicense = new clsDetainLicense();

        private int _PersonID = -1;   // لجلب البيانات الشخصية وتحميلها في ال Show License History
        private int _ApplicationID = -1;

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        public DetainLicense()
        {
            InitializeComponent();

            ctrlDriverLicenseWithFilter1.CurrentMode = ctrlDriverLicenseWithFilter.FormMode.Detain;
            ctrlDriverLicenseWithFilter1.DetainSaveStateChanged += Ctrl_DetainSaveStateChanged;

        }

        private void Ctrl_DetainSaveStateChanged(object sender, bool isEnabled)
        {
            btnSaved.Enabled = isEnabled; // أو أي زر
        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        public void LoadDataToDetainForm(int licenseID, DataTable DtAllInfoToDetainLicense)
        { 
            // تحميل البيانات  في الفورم
            _DtAllInfoToDetainLicense = DtAllInfoToDetainLicense;

            if (_DtAllInfoToDetainLicense.Rows.Count > 0)
            {
                DataRow Row = _DtAllInfoToDetainLicense.Rows[0];

                _PersonID = Convert.ToInt32(Row["PersonID"]);
            }


            _DtAllInfoToDetainLicense = DtAllInfoToDetainLicense;
            _licenseID = licenseID;

            _DtInfoLicenseTable = clsInternationalLicense.GetAllLocalLicenseInfoForRenewLicense(_licenseID);

            if (_DtInfoLicenseTable.Rows.Count > 0)
            {
                DataRow row = _DtInfoLicenseTable.Rows[0];

                lblLicenseID.Text = _licenseID.ToString();
             //   _LicenseClassID = Convert.ToInt32(row["LicenseClass"]);

                lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
               
             
                lblCreatedBy.Text = clsCurrentUser.CurrentUserName;
            }
            else
            {
                MessageBox.Show("License data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///


        private void GroupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void LblCreatedBy_Click(object sender, EventArgs e)
        {

        }

        private void CtrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        private void _LoadDataToObjectAndSaved()
        {
            // حجز الرخصة  Detain       
            if (_DtAllInfoToDetainLicense.Rows.Count > 0)
            {
                DataRow row = _DtAllInfoToDetainLicense.Rows[0];

                _DetainLicense.LicenseID = _licenseID;
                _DetainLicense.DetainDate = DateTime.Now;
                _DetainLicense.FineFees =Convert.ToInt32( txtFineFees.Text);
                _DetainLicense.CreatedByUserID= clsCurrentUser.CurrentUserID;
                _DetainLicense.IsReleaseId = false;



                if (_DetainLicense.Save())
                {
                    lblDetainID.Text = _DetainLicense.DetainID.ToString();
                    _DetainID = _DetainLicense.DetainID;
                    MessageBox.Show("License Detain Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("License Detain Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

        }

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

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
                                                               /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
    }
}
