using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public   class clsTestAppointement
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
       

        public int TestAppointmentID
        {
            get; set;
        }

        public clsTestTypes.enTestType TestTypeID
        {
            get; set;
        }

        public int LocalDrivingLicenseApplicationID
        {
            get; set;
        }

        public DateTime AppointmentDate
        {
            get; set;
        }


        
        public float PaidFees
        {
            get; set;
        }

        public int CreatedByUserID
        {
            get; set;
        }

        public bool IsLocked
        {
            get; set;
        }
        

        public int RetakeTestApplicationID
        {
            get; set;
        }

        public clsApplication RetakeTestAppInfo { set; get; }


        public int TestID
        {
            get { return _GetTestID(); }

        }

        /////////////////////////////////////////////////////////////////////
        public clsTestAppointement()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID =- 1;



            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsTestAppointement(int TestAppointmentID, clsTestTypes.enTestType TestTypeID, int LocalDrivingLicenseApplicationID,
      DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }

        /////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        private bool _AddNewAppointment()
        {
            this.TestAppointmentID = clsDATestAppointement.AddNewAppointmentVision((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees,
                this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }


        ////////////////////////////////////////////////////////////////////////

        private bool _UpdateAppointment()
        {
            return clsDATestAppointement.UpdateAppointmentVision(  this.TestAppointmentID, (int) this.TestTypeID,  this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,  this.PaidFees,  this.CreatedByUserID,  this.IsLocked, this.RetakeTestApplicationID );
        }


        /////////////////////////////////////////////////////////////////////

        private int _GetTestID()
        {
            return clsDATestAppointement.GetTestID(TestAppointmentID);
        }


        /////////////////////////////////////////////////////////////////////

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsDATestAppointement.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        /////////////////////////////////////////////////////////////////////
        public static int GetTestAppointementIDToUpdate(int LocalDrivingLicenseApplicationID)
        {
            return clsDATestAppointement.GetTestAppointementIDToUpdate(LocalDrivingLicenseApplicationID);
        }


        /////////////////////////////////////////////////////////////////////
        public static clsTestAppointement Find(int TestAppointmentID)
        {
            int TestTypeID = 1; int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsDATestAppointement.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestAppointement(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }
      



        /// /////////////////////////////////////////////////////////////////////
        /// 

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                          return _AddNewAppointment();
                    }



                case enMode.Update:
                    {
                        return _UpdateAppointment();

                    }


                default:
                    return false;

            }
        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        
        ////////////////////////////////////////////////////////////////////////
    }
}
