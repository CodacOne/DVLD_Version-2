using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BusinessLayer;

namespace Full_Project_Desktop
{
    public partial class CtrlPersonDetails : UserControl
    {

        private clsPerson _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }


        public CtrlPersonDetails()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.FindByPersonID(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.FindByNationalNo(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {

            int Gender = _Person.Gendor;

            if (Gender == 0)
            {

                pbforPerson.Image = Properties.Resources.male2;
            }

            else
            {
                pbforPerson.Image = Properties.Resources.Female2;
            }

            string ImagePath = _Person.ImagePath?.Trim();
            if (ImagePath != null)
            {
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


        }

        private void _FillPersonInfo()
        {

            /*New*/
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            LblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblGender.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountries.Find(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();

        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            LblNationalNo.Text = "[????]";
            lblName.Text = "[????]";
            pbforPerson.Image = Properties.Resources.male2;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbforPerson.Image =Properties.Resources.male2;

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LlEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdateNewPerson frm = new AddUpdateNewPerson(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }
    }
}
