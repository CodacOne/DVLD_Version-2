using BusinessLayer;
using System;
using System.Windows.Forms;
using static BusinessLayer.clsTestTypes;

namespace Full_Project_Desktop
{
    public partial class EditTestType : Form
    {
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        clsTestTypes _TestsType;
        public EditTestType(clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditTestType_Load(object sender, EventArgs e)
        {
            // find test and get all info to test in Object _TestsType
            _TestsType = clsTestTypes.Find(_TestTypeID); 

            if (_TestsType != null)
            {


                lblID.Text = ((int)_TestTypeID).ToString();
                txtTitle.Text = _TestsType.Title;
                txtDescription.Text = _TestsType.Description;
                txtFees.Text = _TestsType.Fees.ToString();
            }

            else

            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }

        private void btnSaveurcl_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            // stored info to Object and send to update in database
            _TestsType.Title = txtTitle.Text.Trim();
            _TestsType.Description = txtDescription.Text.Trim();
            _TestsType.Fees = Convert.ToSingle(txtFees.Text.Trim());


            if (_TestsType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
            
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            
        }


    }
}
