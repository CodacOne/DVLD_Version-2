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
    public partial class CtrlDriverLicenseInfoWithFilter : UserControl
    {
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;


        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;


        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        public int LicenseID
        {
            get { return ctrlDriverInfo1.LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return ctrlDriverInfo1.SelectedLicenseInfo; } }


       
        public void LoadLicenseInfo(int LicenseID)
        {


            txtLicenseID.Text = LicenseID.ToString();
            ctrlDriverInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDriverInfo1.LicenseID;
            //if (OnLicenseSelected != null && FilterEnabled)
            //    // Raise the event with a parameter
            //    OnLicenseSelected(_LicenseID);

            if (FilterEnabled)
                OnLicenseSelected?.Invoke(_LicenseID);
        }


        public CtrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }
        }

        private void CtrlDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDriverInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
          
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            //if (!this.ValidateChildren())
            //{
            //    //Here we dont continue becuase the form is not valid
            //    MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtLicenseID.Focus();
            //    return;

            //}
            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);

           // txtLicenseID.Clear();
        }

        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLicenseID.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, "");
                return;
            }

            // تحقق من صحة القيمة عند وجود إدخال (مثلاً: تحقق أنها رقم)
            if (!int.TryParse(txtLicenseID.Text, out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "License ID must be a number!");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, "");
            }
        }
    }
}
