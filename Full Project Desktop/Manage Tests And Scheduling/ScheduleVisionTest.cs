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
    public partial class ScheduleVisionTest : Form
    {
         private DataTable _Dt = new DataTable();
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _ResultTest = -1;

        clsAddAppointementVision _AppointementVision = new clsAddAppointementVision();

        private bool _UpdateMode = false;
        private int _TestAppointementID = -1;

        public ScheduleVisionTest(DataTable Dt , bool Mode,int TestAppointementID)
        {
            InitializeComponent();
            _Dt = Dt;
            _TestAppointementID = TestAppointementID;


            //if (TestAppointementID==0)
            //{
            //    DataRow row = Dt.Rows[0];

            //    _LocalDrivingLicenseApplicationID =Convert.ToInt32( row["LocalDrivingLicenseApplicationID"]);
            //    _TestAppointementID= clsLocalDrivingApplication.GetTestAppID(_LocalDrivingLicenseApplicationID);
            //}


            
            LoadDataToform(Dt);


            if (Mode==true)
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


        /*****////*/*/*////////////////////////////////////////////////////
        /*****////*/*/*////////////////////////////////////////////////////



        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleVisionTest_Load(object sender, EventArgs e)
        {
           

           

        }


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

            if (_ResultTest == 0 )
            {
                ChangeModeTestForRetakeTest();
            }
            else
                return;


        }


        /*****////*/*/*////////////////////////////////////////////////////

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
            /**/
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        /*****////*/*/*////////////////////////////////////////////////////

        /*****////*/*/*////////////////////////////////////////////////////
        /*****////*/*/*////////////////////////////////////////////////////

        //private void SaveAppointment()
        //{
        //    bool success = false;

        //    if (_UpdateMode)
        //    {
        //        DateTime newDateTime = dateTimePicker1.Value;
        //        success = clsAddAppointementVision.UpdateAppointmentDate(_TestAppointementID, newDateTime);
        //    }
        //    else
        //    {
        //        DataRow row = _DtInfoDetainTable.Rows[0];

        //        _AppointementVision.LocalDrivingLicenseApplicationID = (int)row["LocalDrivingLicenseApplicationID"];
        //        _AppointementVision.TestTypeID = 1;
        //        _AppointementVision.AppointmentDate = dateTimePicker1.Value;
        //        _AppointementVision.PaidFees = Convert.ToSingle(row["PaidFees"]);
        //        _AppointementVision.CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);
        //        _AppointementVision.IsLocked = 0;

        //        if (_ResultTest == 0)
        //        {
        //            _AppointementVision.RetakeTestApplicationID = _TestAppointementID;
        //        }

        //        success = _AppointementVision.Save();
        //        if (success) _UpdateMode = true;
        //    }

        //    if (success)
        //    {
        //        MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        lblRetakeTestID.Text = _TestAppointementID.ToString();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Test Appointments Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}



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


            _AppointementVision.LocalDrivingLicenseApplicationID =(int) row["LocalDrivingLicenseApplicationID"];
            _AppointementVision.TestTypeID = 1;

            _AppointementVision.AppointmentDate = dateTimePicker1.Value;
            _AppointementVision.PaidFees=Convert.ToSingle( row["PaidFees"]);
            _AppointementVision.CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);

            _AppointementVision.IsLocked = 0;

           int ApplicationID =Convert.ToInt32(row["ApplicationID"]);

            if (_ResultTest == 0)
            {
                _AppointementVision.RetakeTestApplicationID = ApplicationID;
            }
           


            if (_AppointementVision.Save())
            {
                
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_ResultTest == 0)
                {
                    lblRetakeTestID.Text =_TestAppointementID.ToString();
                }
            }

            else
            {
                MessageBox.Show("Test Appointments  Save Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _UpdateMode = true;

        }

        /*****////*/*/*////////////////////////////////////////////////////


        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {

           // SaveAppointment();


            if (_UpdateMode == false)
            {
                _AddNewAppointement();
            }


            if (_UpdateMode == true)
            {
                _UpdateAppointement();
            }


        }

        private void LblDrivingClass_Click(object sender, EventArgs e)
        {

        }

        private void LblError_Click(object sender, EventArgs e)
        {

        }


        /*****////*/*/*////////////////////////////////////////////////////

    }

}
