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
    public partial class IssueDriverLicenseForFirstTime : Form
    {
        private DataTable _Dt = new DataTable();

        private int _ApplicationID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;

        private int _DriverID = -1;

      clsDrivers _Driver = new clsDrivers();

        public IssueDriverLicenseForFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            DataTable Dt = new DataTable();

            _Dt = clsLocalDrivingApplication.GetAllDataToSchedulingTest(_LocalDrivingLicenseApplicationID);


            ctrl_T_VisionTestAppointment1.LoadDataToForm(_Dt);

            //DataRow row = _DtInfoDetainTable.Rows[0];

            //_Release_AppID = (int)row["ApplicationID"];

        }


       
        /*/*//*/**********************************************//*/*////

       private void LoadDataDriverAndSaveOnDataBase()
        {
            DataRow row = _Dt.Rows[0];


            _Driver.PersonID = Convert.ToInt32(row["PersonID"]);
            _Driver.CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);
            _Driver.CreatedDate = DateTime.Now;

            if (_Driver.Save())

            {
                _DriverID = _Driver.DriverID;
                LoadDataLicenseAndSaveOnDataBase();
            }
          
            else
            {
                MessageBox.Show("Failed Save Driver Data.", "Error");

            }
          

        }

        /*/*//*/**********************************************//*/*////
        /*/*//*/**********************************************//*/*////

        private void LoadDataLicenseAndSaveOnDataBase()
        {

         int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, IssueReason = -1,
               PaidFees = -1 , CreatedByUserID =-1;
         DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
         string Notes = ""; 
         Byte IsActive = 0;
        

            DataRow row = _Dt.Rows[0];

            ApplicationID = Convert.ToInt32(row["ApplicationID"]);

           
          
            LicenseClassID = Convert.ToInt32(row["LicenseClassID"]);

            IssueDate = DateTime.Now;

            if (LicenseClassID==1 || LicenseClassID==2)
            {
                ExpirationDate = DateTime.Now.AddYears(5);
            }

            else
            {

                ExpirationDate = DateTime.Now.AddYears(10);
            }



            PaidFees = clsDrivers.GetFeesOfLicenseClassTable(LicenseClassID);

            Notes = txtNotes.Text;
            IsActive = 1;
            IssueReason = 1;

            CreatedByUserID = Convert.ToInt32(row["CreatedByUserID"]);


            _DriverID = _Driver.DriverID;
            DriverID = _DriverID;


            if (clsDrivers.InsertLNewLicense(ApplicationID, DriverID, LicenseClassID, IssueReason,
     PaidFees, CreatedByUserID, IssueDate, ExpirationDate,
     Notes, IsActive))
            {

                MessageBox.Show("License Issued Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                MessageBox.Show("License Issued Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*/*//*/**********************************************//*/*////

        /*/*//*/**********************************************//*/*////

        private void Ctrl_T_VisionTestAppointment1_Load(object sender, EventArgs e)
        {

        }

        private void IssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {

        }
        /*/*//*//*//*********************************************************//*/*///


        private void Button2_Click(object sender, EventArgs e)
        {
            LoadDataDriverAndSaveOnDataBase();

            

        }


        /*/*//*//*//*********************************************************//*

        /*//*//*//*//*********************************************************/
    }
}
