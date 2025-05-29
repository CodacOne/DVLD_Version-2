using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;

namespace BusinessLayer
{
  public  class clsLocalDrivingApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private int _ApplicationID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get; set;
        }


        public int ApplicationID
        {
            get; set;
        }


        public int LicenseClassID
        {
            get; set;
        }

        public clsLocalDrivingApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsLocalDrivingApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            Mode = enMode.Update;
        }

        /////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////
        ///
       

        /////////////////////////////////////////////////////////////////////


        private bool _AddNewLocalDrivingApplication()
        {

            this.LocalDrivingLicenseApplicationID = clsDAManageLocalDrivingApplication.FillDataToLocalDrivingApplicationTable(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewLocalDrivingApplication();
                    }



                //case enMode.Update:
                //    {
                //        return _UpdateUser();


                //    }


                default:
                    return false;

            }
        }

        /////////////////////////////////////////////////////////////////////
        ///
        /// 

        /////////////////////////////////////////////////////////////////////

        public static bool CheckIfThereIsAPreviousOpenApplication(int PersonID, int LicenseClassID)
        {

            return clsDAManageLocalDrivingApplication.CheckIfThereIsAPreviousOpenRequest(PersonID, LicenseClassID);


        }


        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        public static DataTable LicenseApplicationsFilter(int ColumnIndex, string Filter)
        {
            return clsDAManageLocalDrivingApplication.LicenseApplicationsFilter(ColumnIndex, Filter);

        }

        /////////////////////////////////////////////////////////////////////
        ///
           /////////////////////////////////////////////////////////////////////
        public static int GetCountManageApplicationType()
        {

            return clsDAManageApplicationType.GetApplicationTypesCount();


        }

        /////////////////////////////////////////////////////////////////////
        /// <summary>
       
        public static DataTable LocalDrivingApplictionType()
        {
            return clsDAManageApplicationType.GetAllApplicationTypes();

        }


        /////////////////////////////////////////////////////////////////////

        public static bool CancelApplication(int LocalDrivingLicenseApplicationID)
        {

         int ApplicationID = clsDAManageLocalDrivingApplication.GetApplciationIDToCancel(LocalDrivingLicenseApplicationID);

          return  clsDAManageLocalDrivingApplication.CancelApplicationCompletly(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /// <summary>

        public static DataTable GetAllDataToSchedulingTest(int LocalDrivingLicenseApplicationID)
        {
            return clsDAManageLocalDrivingApplication.GetAllDataToSchedulingTest(LocalDrivingLicenseApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        ///
        ///   /////////////////////////////////////////////////////////////////////
        ///

        public static bool DeleteLocalDriving(int LocalDrivingLicenseApplicationID)
        {
            
            return clsDAManageLocalDrivingApplication.DeleteLocalDriving(LocalDrivingLicenseApplicationID);


        }

        ///   /////////////////////////////////////////////////////////////////////
        ///

        public static bool ValidationIfExistSamelicenseClassOfSamePeople(String NationalNo, int LicenseClassID)
        {

          return clsDAManageLocalDrivingApplication.ValidationIfExistSamelicenseClassOfSamePeople(NationalNo, LicenseClassID);

        }

        ///   /////////////////////////////////////////////////////////////////////
        public static int GetAllTestsFees(int TestTypeID)
        {
            return clsDAManageLocalDrivingApplication.GetAllTestsFees(TestTypeID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///
         public static DataTable GetDataVisionTest(int ApplicationID)
        {
          
            return clsDATestTypesAppointement.VisionTestAppointement(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///


        /////////////////////////////////////////////////////////////////////
        ///
        public static bool ChechIfTestAppointmentIsActiveOrNot(int TestAppID)
        {


            return clsDATestTypesAppointement.ChechIfTestAppointmentIsActiveOrNot(TestAppID);

        }


        /////////////////////////////////////////////////////////////////////
        
        public static int GetTestAppID(int _LocalDrivingLicenseApplicationID)
        {

            int TestAppID = clsAddAppointementVision.GetTestAppointementIDToUpdate(_LocalDrivingLicenseApplicationID);

            return TestAppID;


        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static int GetResultForTest(int TestAppID)
        {

            return clsDATestTypesAppointement.GetResultForTestIfPassingOrFailing(TestAppID);

        }



        /////////////////////////////////////////////////////////////////////
        
        /////////////////////////////////////////////////////////////////////
        ///
        public static int GetLicenseIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)
        {

            return clsDAManageLocalDrivingApplication.GetLicenseIDByLocalDrivingID(LocalDrivingLicenseApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static bool CancelTheAppointmentAfterPassingOrFailing(int TestID)
        {


            return clsDATestTypesAppointement.CancelTheAppointmentAfterPassingOrFailing(TestID);

        }


        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        public static int CountVisionTestAppointement()
        {

            return clsDATestTypesAppointement.CountVisionTestAppointement();
            

        }

      

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////


    }



}
