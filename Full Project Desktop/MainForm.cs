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
    public partial class MainForm : Form
    {
        LoginScreen _frmloginScreen;
        public MainForm(LoginScreen frmloginScreen)
        {
            InitializeComponent();
            _frmloginScreen = frmloginScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_People frm1 = new Manage_People();
            frm1.ShowDialog();
        }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            _frmloginScreen.Show();
            this.Close();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Users frmManage_Users = new Manage_Users();
            frmManage_Users.Show();

        }

        private void ManageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Aplication_Types frm = new Manage_Aplication_Types();
            frm.Show();


        }

        private void ManageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestType frm = new ManageTestType();

            frm.Show();
        }

        private void CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicense frm = new LocalLicense();
            frm.Show();
        }

        private void CsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDivingLicenseApplication frm = new ManageLocalDivingLicenseApplication();
            frm.Show();
        }

        private void InternationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageInternationalLicenseApplication frm = new ManageInternationalLicenseApplication();
            frm.Show();
        }
        
        private void InternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicense frm = new InternationalLicense();
            frm.Show();
        }

        private void RenewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicenseApplication frm = new RenewLicenseApplication();
            frm.Show();
        }

        private void ReplacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementForLostOrDamagedLicense frm = new ReplacementForLostOrDamagedLicense();
            frm.Show();
        }

        private void DetainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.Show();
        }

        private void ReleaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.Show();
        }

        private void VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDetainedLicense frm = new ManageDetainedLicense();
            frm.Show();
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDrivers frm = new ManageDrivers();
            frm.Show();
        }

        private void ReleaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.Show();
        }

        private void RetakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDivingLicenseApplication frm = new ManageLocalDivingLicenseApplication();
            frm.Show();
        }

        private void CurrentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = clsGlobal.CurrentUser.UserID;

            ShowDetailsForPersonAndUser frm = new ShowDetailsForPersonAndUser(UserID);
            frm.ShowDialog();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = clsGlobal.CurrentUser.UserID;
            Change_Password frm = new Change_Password(UserID);
            frm.ShowDialog();

        }
    }
}
