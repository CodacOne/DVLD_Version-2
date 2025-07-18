﻿using BusinessLayer;
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
    public partial class frmSchedueTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private int _AppointmentID = -1;

        public frmSchedueTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void ctrlSchedueTest1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSchedueTest_Load(object sender, EventArgs e)
        {
            ctrlSchedueTest1.TestTypeID = _TestTypeID;  // change picture and Text For User control base on Test Type
            ctrlSchedueTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }
    }
}
