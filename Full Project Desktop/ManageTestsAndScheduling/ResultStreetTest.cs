using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using BusinessLayer;


namespace Full_Project_Desktop
{
    public partial class ResultStreetTest : Form
    {

        private DataTable _Dt = new DataTable();
        private int _LocalDrivingLicenseApplicationID = -1;

        private int _CreatedByUserID = -1;
        private int _TestAppID = -1;

     



        public ResultStreetTest(DataTable Dt, int TestAppID)
        {
            InitializeComponent();

            _Dt = Dt;
            _TestAppID = TestAppID;


            _LoadDataToForm();


        }

        /*/*///////*/*////*/*/*/*/*/*/*/*/*/**********////////////////////////////////////
        private void _LoadDataToForm()
        {
            if (_Dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available to display.");
                return;
            }

            DataRow row = _Dt.Rows[0];

            lblDLAppID.Text = row["LocalDrivingLicenseApplicationID"].ToString();
            lblDrivingClassName.Text = row["ClassName"].ToString();


            lblName.Text = row["FirstName"].ToString() + " " + row["SecondName"].ToString() + " " +
                  row["ThirdName"].ToString() + " " + row["LastName"].ToString();

            lblTrial.Text = 0.ToString();
            lblDate.Text = Convert.ToDateTime(row["ApplicationDate"])
                 .ToString("ddMMMyyyy", CultureInfo.InvariantCulture);


            lblFees.Text = row["PaidFees"].ToString();

            lblTestID.Text = "Not Taken Yet.";


            //////
            _LocalDrivingLicenseApplicationID = Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]);
            _CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);
        }

        /*/*///////*/*////*/*/*/*/*/*/*/*/*/**********////////////////////////////////////
        private void _LoadDataToObject()
        {


        }

        /*/*///////*/*////*/*/*/*/*/*/*/*/*/**********////////////////////////////////////

        /*/*///////*/*////*/*/*/*/*/*/*/*/*/**********////////////////////////////////////
             /*/*///////*/*////*/*/*/*/*/*/*/*/*/**********////////////////////////////////////

        private void ChangeModeAfterSuccessOrFailed()
        {
            // if ChechIfTestAppointmentIsActiveOrNot = True >> is Locked 

            clsLocalDrivingApplication.CancelTheAppointmentAfterPassingOrFailing(_TestAppID);

        }


        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ResultStreetTest_Load(object sender, EventArgs e)
        {

        }

        private void BtnSaveurcl_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*/*//*/*****************************************/////////////////
    }
}
