using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Project_Desktop
{
    public partial class EditApplicationType : Form
    {
        int _ApplicaionTypeID = -1;
        clsApplicationType _ApplicationType;
        public EditApplicationType(int ApplicaionTypeID)
        {
            InitializeComponent();
            _ApplicaionTypeID = ApplicaionTypeID;
        }


        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void EditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_ApplicaionTypeID);

            if(_ApplicationType !=null)
            {
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text = _ApplicationType.Fees.ToString();

            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
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
            ;

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
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
            ;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveurcl_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.Title = txtTitle.Text.Trim();
            _ApplicationType.Fees = Convert.ToSingle(txtFees.Text.Trim());


            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }




    }
}
