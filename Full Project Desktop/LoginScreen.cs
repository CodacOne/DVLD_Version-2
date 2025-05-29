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

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //// To Avoid transfer To Main Screen before to Login
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Please enter the username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter the password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }



            if (clsUsers.ValidateToLogIn(_UserName, _Password))
            {
             
                   MainForm frm = new MainForm();
                   frm.ShowDialog();
                   this.Hide();

            }


            else

                MessageBox.Show("Invalid UserName,Password");


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
