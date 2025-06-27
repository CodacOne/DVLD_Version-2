using BusinessLayer;
using Full_Project_Desktop.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Project_Desktop
{
    public partial class DetainLicense : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public DetainLicense()
        {
            InitializeComponent();

           
        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        private void Ctrl_DetainSaveStateChanged(object sender, bool isEnabled)
        {
          
        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///


        private void GroupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
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

        private void BtnSaved_Click(object sender, EventArgs e)
        {
            // Save Data And Storage it 


            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainID == -1)  
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            llShowLicenseInfo.Enabled = true;


        }

        private void LlShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverDetails frm = new DriverDetails(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void LlLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         int PersonID  = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            ShowLicenseHistory frm = new ShowLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show($"Selected License id {_SelectedLicenseID} already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
    }
}
