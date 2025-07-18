﻿using BusinessLayer;
using Full_Project_Desktop.Global_Classes;
using Full_Project_Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Full_Project_Desktop
{
    public partial class CtrlDriverInfo : UserControl
    {

        private int _LicenseID;
        private clsLicense _License;
       
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return _License; } }

       

        /*/*//*/******************************************************************//*/*/

        private void _LoadPersonImage()
        {

            if (_License.DriverInfo.PersonInfo.Gendor == 0)
            { pbforPerson.Image = Resources.Male_512; }


            else
            { pbforPerson.Image = Resources.Female_512; }

          
            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath?.Trim();
           
                if (File.Exists(ImagePath))
                {
                    pbforPerson.SizeMode = PictureBoxSizeMode.Zoom;  // ضبط وضع عرض الصورة
                    pbforPerson.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


        }
        /*/*//*/******************************************************************//*/*/


        /*/*//*/******************************************************************//*/*/
        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;

            // Handle With Picture
            _LoadPersonImage();

        }


        /*/*//*/******************************************************************//*/*/
        public CtrlDriverInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        /*/*//*/******************************************************************//*/*/

        /*/*//*/******************************************************************//*/*/
    }
}
