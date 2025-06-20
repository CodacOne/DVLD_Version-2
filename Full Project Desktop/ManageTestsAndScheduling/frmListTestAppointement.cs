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

namespace Full_Project_Desktop
{
    public partial class frmListTestAppointement : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;

        public frmListTestAppointement(int LocalDrivingLicenseApplicationID , clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _TestType= TestType;
            

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypes.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
                        pbTestTypeImage.Image = Properties.Resources.Vision_512;
                        break;
                    }

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
                        pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
                        pbTestTypeImage.Image = Properties.Resources.driving_test_512;
                        break;
                    }
            }
        }


        private void LoadDataToDataGridView()
        {
            _dtLicenseTestAppointments = clsTestAppointement.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvForTestAppointement.DataSource = _dtLicenseTestAppointments;
            lblCountRecords.Text = dgvForTestAppointement.Rows.Count.ToString();

        }
        private void frmListTestAppointement_Load(object sender, EventArgs e)
        {
            // Change The picture and title for the form dependent on Test Type
            _LoadTestTypeImageAndTitle();

            ctrl_T_VisionTestAppointment1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
           
            LoadDataToDataGridView();
          


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            frmListTestAppointement_Load(null,null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            clsLocalDrivingApplication localDrivingLicenseApplication = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //---
            clsTests LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmSchedueTest frm1 = new frmSchedueTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmListTestAppointement_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSchedueTest frm2 = new frmSchedueTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointement_Load(null, null);
            //---
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvForTestAppointement.CurrentRow.Cells[0].Value;


            frmSchedueTest frm = new frmSchedueTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();

            // For Refresh after Edit
            frmListTestAppointement_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvForTestAppointement.CurrentRow.Cells[0].Value;

            //frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            //frm.ShowDialog();
            //frmListTestAppointments_Load(null, null);
        }
    }
}
