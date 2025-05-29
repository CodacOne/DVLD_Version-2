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
    public partial class InternationalLicense : Form
    {

        private int _licenseID = -1;
        private DataTable _Dt = new DataTable();


        public InternationalLicense()
        {
            InitializeComponent();
            llShowLicenseInfo.Enabled = false;

            ctrlDriverLicenseWithFilter1.CurrentMode = ctrlDriverLicenseWithFilter.FormMode.International;
        }

        private void Label43_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_licenseID != -1)
            {
                DriverInternationalLicenseInfo frm = new DriverInternationalLicenseInfo(_licenseID);
                frm.Show();

            }

            else
                return;
        }

        private void InternationalLicense_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.LoadDataToForm(_licenseID, _Dt);
        }

        private void CtrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.SaveEnabled += CtrlDriverLicenseWithFilter_SaveEnabled;
            ctrlDriverLicenseWithFilter1.SaveDisabled += CtrlDriverLicenseWithFilter_SaveDisabled;
        }


        private void CtrlDriverLicenseWithFilter_SaveEnabled(object sender, EventArgs e)
        {
            ChangeMode(true); // تفعيل زر الحفظ أو أي شيء مشابه
        }

        private void CtrlDriverLicenseWithFilter_SaveDisabled(object sender, EventArgs e)
        {
            ChangeMode(false); // تعطيل زر الحفظ
        }

        public void LoadDataToInternationalLicenseForm(int licenseID, DataTable Dt)
        {
            _licenseID = licenseID;
            _Dt = Dt;

           
            ctrlApplicationInfo1.LoadDataToForm(licenseID, Dt);  // أو أي دالة داخل الكنترول
        }

        public void ChangeMode(bool Reverse)
        {

            llShowLicenseInfo.Enabled = !Reverse;
            btnSave.Enabled = Reverse;

        }




        private void CtrlApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.LoadDataToObject();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Dt.Rows.Count > 0)
            {
                DataRow row = _Dt.Rows[0];

                // نصوص السائق
                int AppID = Convert.ToInt32(row["AppID"]);
                int LocalDrivingID = clsInternationalLicense.GetLocalDrivingLicenseApplicationIDByApplicationID(AppID);
               
                ShowLicenseHistory frm = new ShowLicenseHistory(LocalDrivingID,true);
                frm.Show();
            }

            else
                MessageBox.Show("Error");
        }
    }
}
