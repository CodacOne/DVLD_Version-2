using BusinessLayer;
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
using Full_Project_Desktop.Global_Classes;


namespace Full_Project_Desktop
{
    public partial class CtrlScheduledTest : UserControl
    {

        private clsTestTypes.enTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingApplication _LocalDrivingLicenseApplication;
        /*//*//*//////////////////////////////////////////*/
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestTypes.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
                            pbTestTypeImage.Image = Properties.Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;  // ضبط وضع عرض الصورة
                            pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
                            pbTestTypeImage.Image = Properties.Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

        /*//*//*//////////////////////////////////////////*/

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }
        /*//*//*//////////////////////////////////////////*/
        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointement _TestAppointment;


        public CtrlScheduledTest()
        {
            InitializeComponent();
        }


        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;


            _TestAppointment = clsTestAppointement.Find(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClassName.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;


            //this will show the trials for this test before 
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();



            lblDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();



        }

        /*//*//*//////////////////////////////////////////*/

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /*//*//*//////////////////////////////////////////*/

        /*//*//*//////////////////////////////////////////*/

    }
}
