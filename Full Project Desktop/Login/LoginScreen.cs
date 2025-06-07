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
    public partial class LoginScreen : Form
    {
        private string _UserName = "";

        private string _Password = "";


        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
                cbRememberMe.Checked = false;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
           
         
            clsUsers user = clsUsers.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            
            if (user != null )
            {
                if(cbRememberMe.Checked)
                {
                     clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim());
                }

                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                //incase the user is not active
                if (user.IsActive!=1)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // if user not Null will open the system
                clsGlobal.CurrentUser = user;
                MainForm frm = new MainForm(this);
                frm.ShowDialog();
                this.Hide();

            }

            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              


        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {
            _UserName = txtUserName.Text;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            _Password = txtPassword.Text;
        }
    }
}
