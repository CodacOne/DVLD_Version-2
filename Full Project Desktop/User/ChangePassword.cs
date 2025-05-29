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
    public partial class Change_Password : Form
    {
        private int _PersonID = -1;

        private string _NewPassword = "";

        public Change_Password(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            ctrlPersonAndUserInformation1._LoadUserDataToForm(_PersonID);

        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        private void CtrlPersonAndUserInformation1_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text != ctrlPersonAndUserInformation1._Password)
            {

                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "Current Password Is Wrong");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
           
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {

                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password Conformation does not match Password");
              

            }

            else

            {
                e.Cancel = false;
                btnSave.Enabled = true;
                errorProvider1.SetError(txtConfirmPassword, "");
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            

            if (clsUsers.UpdateUser(ctrlPersonAndUserInformation1._UserID, _NewPassword))
            {


                MessageBox.Show("Password Changed Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else

                MessageBox.Show("Password Changed Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            _NewPassword = txtConfirmPassword.Text;
        }

        ///*/*/*/*/*/*/**//////////////////////////////////////////////////
        ///

    }
}
