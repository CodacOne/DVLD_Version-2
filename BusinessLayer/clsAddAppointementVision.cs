using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;


namespace BusinessLayer
{
    public   class clsAddAppointementVision
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
       

        public int TestAppointmentID
        {
            get; set;
        }

        public int TestTypeID
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

        public Byte IsLocked
        {
            get; set;
        }
        

        public int RetakeTestApplicationID
        {
            get; set;
        }
        /////////////////////////////////////////////////////////////////////
        public clsAddAppointementVision()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = 0;
            this.RetakeTestApplicationID =- 1;



            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsAddAppointementVision(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
      DateTime AppointmentDate, float PaidFees, int CreatedByUserID, Byte IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            Mode = enMode.Update;
        }

        /////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        private bool _UpdateAppointment()
        {
            return clsDATestTypesAppointement.UpdateAppointmentVision(  this.TestAppointmentID,  this.TestTypeID,  this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,  this.PaidFees,  this.CreatedByUserID,  this.IsLocked, this.RetakeTestApplicationID );
        }


        /////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////
        private bool _AddNewAppointment()
        {
            this.TestAppointmentID = clsDATestTypesAppointement.AddNewAppointmentVision(this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,
                this.CreatedByUserID,this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }



        /////////////////////////////////////////////////////////////////////
        public static int GetTestAppointementIDToUpdate(int LocalDrivingLicenseApplicationID)
        {
            return clsDATestTypesAppointement.GetTestAppointementIDToUpdate(LocalDrivingLicenseApplicationID);
        }


        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        public static bool UpdateAppointmentDate(int TestAppointmentID, DateTime NewAppointmentDate)
        {
            return clsDATestTypesAppointement.UpdateAppointmentDate(TestAppointmentID, NewAppointmentDate);
        }




        /////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////
        public DateTime GetDateTimeForAppointmentToUpdate(int TestAppointmentID)
        {
            this.AppointmentDate = clsDATestTypesAppointement.GetAppointmentDate(TestAppointmentID);

            return this.AppointmentDate ;
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
        
        ////////////////////////////////////////////////////////////////////////
    }
}
