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
    public partial class Add_New_User : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private clsUsers _User;
       // clsUser _User;
        private int _PersonID;

      

       // private bool _Mode = false;

        //****////***//*/*/*/////////////////***************////////////////////////////////
        public Add_New_User(int PersonID)
        {
            // Update mode
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
         
        }
        //****////***//*/*/*/////////////////****
        public Add_New_User()
        {     
            // Addnew Mode  
            InitializeComponent();
            _Mode = enMode.AddNew;

        }



        //****////***//*/*/*/////////////////***************////////////////////////////////

        private void ChangeMode()
        {
            //lblHeader.Text = "Update User";
           
          
            //btnNext.Enabled = false;
        }

        //****////***//*/*/*/////////////////***************////////////////////////////////


    

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {

        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if(_Mode==enMode.Update)
            {

                _LoadDataToForm();
            }
            
        }

        /***************//**********************************************/
        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblHeader.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUsers();

                tpLoginInfo.Enabled = false;

              
            }
            else
            {
                lblHeader.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSaveurcl.Enabled = true;
                ctrlPeronDetailsWithFilterNew1.ChangeModeToUpdate();

            }

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;


        }

        /***************//**********************************************//****************************************/
        private void PbAdd_Click(object sender, EventArgs e)
        {
            AddUpdateNewPerson frmPerson = new AddUpdateNewPerson();
            frmPerson.ShowDialog();
        }

        private void Ctrl2PersonalInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        /***************//**********************************************//****************************************/

        /***************//**********************************************//****************************************/

        private void TxtNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)   //incase of Update  mode.
            {
                btnSaveurcl.Enabled = true;
                tpLoginInfo.Enabled = true;
                tabControl1.SelectedTab = tpLoginInfo;
                return;
            }


            ////incase of add new mode.
            //if (clsUsers.IsUserExistOrNot(ctrl2PersonalInfoWithFilter1._PersonID))
            //{

            //    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    ctrl2PersonalInfoWithFilter1.FilterFocus();
            //}

            else
            {
                btnSaveurcl.Enabled = true;
                tpLoginInfo.Enabled = true;
                tabControl1.SelectedTab = tpLoginInfo;
            }
           
         //else
         //   {

         //       MessageBox.Show("No Person With National No ", "Error", MessageBoxButtons.OK,
         //           MessageBoxIcon.Error);
         //   }

        }

      
         /**************///****************************************
          /***************//**********************************************//****************************************/

        private void _LoadDataFromFormToTable()
        {
            if (_User == null)
            {
                _User = new clsUsers();    // ✅ إنشاء الكائن
            }

               _User.PersonID = _PersonID;
               _User.UserName = txtUsername.Text;
               _User.Password = txtPassword.Text;
               _User.IsActive = cbIsActive.Checked ? (byte)1 : (byte)0; 


                if (_User.Save())
                {
                    lblUserID.Text = _User.UserID.ToString();
                     lblHeader.Text = "Update User";

                    MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else

                    MessageBox.Show("Data Saved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            /***************//******************************************/
        }


        private void _LoadDataToForm()
        {
            clsPerson person = clsPerson.FindByPersonID(_PersonID);

            if (person == null)
            {
                MessageBox.Show("No User with PersonID = " + _PersonID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;

            }

            // Load data person to form 
            ctrlPeronDetailsWithFilterNew1._LoadDataToForm(person);

            // Find And Load data User to form 
            clsUsers User = clsUsers.Find(person.PersonID);

            lblUserID.Text = User.UserID.ToString();
            txtUsername.Text = User.UserName;
            txtPassword.Text = User.Password;
            txtConfirmPassword.Text = User.Password;

            cbIsActive.Checked = (User.IsActive == 1);

        }


        /***************//**********************************************//****************************************/


        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            //  clsUsers User;
            _User.PersonID = _PersonID;
            _User.UserName = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = cbIsActive.Checked ? (byte)1 : (byte)0;


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblHeader.Text = "Update User";


                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /******///*/*///////////////*//// <summary>


        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {

                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password cannot be blank");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtPassword, "");
            }


        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        /***************//**********************************************/
        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {

                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password Conformation does not match Password");

            }

            else

            {
                e.Cancel = false;

                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void TpLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }


        /***************//**********************************************/
                                                                         


    }
}
