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

        private clsUsers _User =new clsUsers();
        private int _PersonID;

        private int _ID;

        private bool _Mode = false;

        //****////***//*/*/*/////////////////***************////////////////////////////////


        public Add_New_User(int ID)
        {
            InitializeComponent();
            _ID = ID;

        
            UpdateUser();
        

        }



        //****////***//*/*/*/////////////////***************////////////////////////////////

        private void ChangeMode()
        {
            lblHeader.Text = "Update User";
            ctrl2PersonalInfoWithFilter1.ChangeModeToUpdate();
            _Mode = true;
            btnNext.Enabled = false;
        }

        //****////***//*/*/*/////////////////***************////////////////////////////////


        public Add_New_User()
        {
            InitializeComponent();
            
        }


        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {

        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            
        }


        /***************//**********************************************//****************************************/
        private void PbAdd_Click(object sender, EventArgs e)
        {
            AddNewPerson frmPerson = new AddNewPerson();
            frmPerson.ShowDialog();
        }

        private void Ctrl2PersonalInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        /***************//**********************************************//****************************************/

        /***************//**********************************************//****************************************/

        private void TxtNext_Click(object sender, EventArgs e)
        {
            
         

            _PersonID = ctrl2PersonalInfoWithFilter1.ValidatingforUser();

            if (_PersonID != -1 && _PersonID != -2)
            {

                tabControl1.SelectedTab = tpLoginInfo;
            }


            
         else  if(_PersonID == -1 )
            {

                MessageBox.Show("No Person With National No " , "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


            else

            {
                MessageBox.Show("Selected Person Already has a user,Choose another one.", "Select another Person",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


        }

        /***************//**********************************************//****************************************/
        
          private void _LoadDataUserToForm(clsUsers User)
        {
            lblUserID.Text = User.UserID.ToString();
            txtUsername.Text = User.UserName;
            txtPassword.Text = User.Password;
            txtConfirmPassword.Text = User.Password;

            if(User.IsActive==1)
            {
                cbIsActive.Checked = true;
            }

            else
                cbIsActive.Checked = false;

            //else

            //    MessageBox.Show("Data Saved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

         /***************//**********************************************//****************************************
         * /***************//**********************************************//****************************************/

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


        private void UpdateUser()
        {
            clsPerson person = clsPerson.FindByPersonID(_ID);

            if (person != null)
            {
                // Load data person to form 
                ctrl2PersonalInfoWithFilter1._LoadDataToForm(person);

            }


            ChangeMode();
            // Find And Load data User to form 
            clsUsers User = clsUsers.Find(person.PersonID);
            _LoadDataUserToForm(User);


           


        }


        /***************//**********************************************//****************************************/


        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {

            if (_Mode == true)
            {

                SaveUserDataToTabelDB();
            }


            else
            {
                // For Person
                _LoadDataFromFormToTable();

            }
           

        }



        private void SaveUserDataToTabelDB()
        {

            clsUsers User = clsUsers.Find(_ID);


            //  clsUsers User;
            User.PersonID = _ID;
            User.UserName = txtUsername.Text;
            User.Password = txtPassword.Text;
            User.IsActive = cbIsActive.Checked ? (byte)1 : (byte)0;


            if (User.Save())
            {
               

                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else

                MessageBox.Show("Data Saved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
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


        /***************//**********************************************//****************************************/
                                                                         /***************//**********************************************//****************************************/


    }
}
