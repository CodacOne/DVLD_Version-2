﻿using System;
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
    public partial class ShowDrivingLicenseApplicationInfo : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public ShowDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void ShowDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrl_T_VisionTestAppointment1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
