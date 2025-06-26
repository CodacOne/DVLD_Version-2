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
    public partial class DriverDetails : Form
    {
        private int  _LicenseID=-1;
        public DriverDetails(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DriverDetails_Load(object sender, EventArgs e)
        {
            ctrlDriverInfo1.LoadInfo(_LicenseID);
        }
    }
}
