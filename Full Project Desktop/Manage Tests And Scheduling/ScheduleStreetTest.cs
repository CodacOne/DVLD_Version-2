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
    public partial class ScheduleStreetTest : Form
    {

        private DataTable _Dt = new DataTable();
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _ResultTest = -1;

        clsAddAppointementVision _AppointementVision = new clsAddAppointementVision();

        private bool _UpdateMode = false;
        private int _TestAppointementID = -1;



        public ScheduleStreetTest(DataTable Dt, bool Mode, int TestAppointementID)
        {
            InitializeComponent();
            _Dt = Dt;
            _TestAppointementID = TestAppointementID;

            LoadDataToform(Dt);


            if (Mode == true)
            {

                // Mode Update 
                _UpdateMode = true;
                _LoadDateTimePrevoiusToFormForUpdate();
            }

            if (Mode == false)
            {
                // Mode Add 
                _UpdateMode = false;
            }




        }


        /*****////*/*/*////////////////////////////////////////////////////
        private void _LoadDateTimePrevoiusToFormForUpdate()
        {
            DataRow row = _Dt.Rows[0];


            dateTimePicker1.Value = _AppointementVision.GetDateTimeForAppointmentToUpdate(_TestAppointementID);
        }

        /*****////*/*/*////////////////////////////////////////////////////
        /*****////*/*/*////////////////////////////////////////////////////


        private void _UpdateAppointement()
        {

            DateTime NewDateTime = dateTimePicker1.Value;

            if (clsAddAppointementVision.UpdateAppointmentDate(_TestAppointementID, NewDateTime))
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Test Appointments  Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*****////*/*/*////////////////////////////////////////////////////
           /*****////*/*/*////////////////////////////////////////////////////

        public void ChangeModeTestForRetakeTest()
        {

            gbRetakeTestInfo.Enabled = true;
            lblRetakeFees.Text = "5";

            int ResultFees = Convert.ToInt32(lblRetakeFees.Text) + Convert.ToInt32(lblFees.Text);
            lblTotalFees.Text = ResultFees.ToString();
            lblError.Text = "Person Already Faild in this Test.";

            lblTitle.Text = "Schedule Retake Test";



        }


        /*****////*/*/*////////////////////////////////////////////////////
        /*****////*/*/*////////////////////////////////////////////////////
        /*****////*/*/*////////////////////////////////////////////////////

        public void LoadDataToform(DataTable Dt)
        {

            gbRetakeTestInfo.Enabled = false;

            if (Dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available to display.");
                return;
            }

            DataRow row = Dt.Rows[0];

            lblLocalDrivingID.Text = row["LocalDrivingLicenseApplicationID"].ToString();

            lblName.Text = row["FirstName"].ToString() + " " + row["SecondName"].ToString() + " " +
                row["ThirdName"].ToString() + " " + row["LastName"].ToString();

            lblTrial.Text = "0";
            lblDrivingClass.Text = row["ClassName"].ToString();
            lblFees.Text = clsLocalDrivingApplication.GetAllTestsFees(1).ToString();

            /////////// If Person Failed in Test >>  Will Retake Test

            _ResultTest = clsLocalDrivingApplication.GetResultForTest(_TestAppointementID);

            if (_ResultTest == 0)
            {
                ChangeModeTestForRetakeTest();
            }
            else
                return;


        }

        /*****////*/*/*////////////////////////////////////////////////////

        private void _AddNewAppointement()
        {

            DataRow row = _Dt.Rows[0];

            if (_Dt.Rows.Count == 0 || !_Dt.Columns.Contains("LocalDrivingLicenseApplicationID"))
            {
                MessageBox.Show("Missing or invalid data in _DtInfoDetainTable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)row["LocalDrivingLicenseApplicationID"] == 0)
            {
                MessageBox.Show("Invalid Application ID (0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _AppointementVision.LocalDrivingLicenseApplicationID = (int)row["LocalDrivingLicenseApplicationID"];
            _AppointementVision.TestTypeID = 1;

            _AppointementVision.AppointmentDate = dateTimePicker1.Value;
            _AppointementVision.PaidFees = Convert.ToSingle(row["PaidFees"]);
            _AppointementVision.CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);

            _AppointementVision.IsLocked = 0;

            int ApplicationID = Convert.ToInt32(row["ApplicationID"]);

            if (_ResultTest == 0)
            {
                _AppointementVision.RetakeTestApplicationID = ApplicationID;
            }



            if (_AppointementVision.Save())
            {

                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_ResultTest == 0)
                {
                    lblRetakeTestID.Text = _TestAppointementID.ToString();
                }
            }

            else
            {
                MessageBox.Show("Test Appointments  Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _UpdateMode = true;

        }

        /*****////*/*/*////////////////////////////////////////////////////


        /*****////*/*/*////////////////////////////////////////////////////

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {

            if (_UpdateMode == false)
            {
                _AddNewAppointement();
            }


            if (_UpdateMode == true)
            {
                _UpdateAppointement();
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*****////*/*/*////////////////////////////////////////////////////

        /*****////*/*/*////////////////////////////////////////////////////
        /*****////*/*/*////////////////////////////////////////////////////
    }
}
