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
        private int _UserID = -1;

        private string _NewPassword = "";
        private clsUsers _Users;
        public Change_Password(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
          
        }


        private void _ResetDefualtValues()
        {

            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();

        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _Users = clsUsers.FindByUserID(_UserID);

            if (_Users == null)
            {
                btnSave.Enabled = false;
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
                
            }

            // Load data to form 
            ctrlPersonAndUserInformation1._LoadUserDataToForm(_UserID);

           
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
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
            ;


            if (_Users.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
            ;
           
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
            if(!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _Users.Password = _NewPassword;   // load new password to Object 
            if (_Users.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            _NewPassword = txtConfirmPassword.Text;
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
            ;
        }

        ///*/*/*/*/*/*/**//////////////////////////////////////////////////
        ///

    }
}
