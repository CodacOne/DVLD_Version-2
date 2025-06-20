using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Full_Project_Desktop.Global_Classes;

using BusinessLayer;

namespace Full_Project_Desktop
{
    public partial class CtrlApplicationBasciInfo : UserControl
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        private clsApplication _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public CtrlApplicationBasciInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }


        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
           // lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantFullName;
            lblApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedBy.Text = _Application.CreateByUserInfo.UserName;
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblApplicationDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedBy.Text = "[????]";

        }


        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LblType_Click(object sender, EventArgs e)
        {

        }

        private void LblApplicant_Click(object sender, EventArgs e)
        {

        }
    }
}
