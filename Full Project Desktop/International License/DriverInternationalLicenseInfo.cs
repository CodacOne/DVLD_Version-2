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
    public partial class DriverInternationalLicenseInfo : Form
    {

        private int _InternationalLicenseID;
        public DriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
          _InternationalLicenseID= InternationalLicenseID;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void CtrlDriverInternationalLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void DriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
