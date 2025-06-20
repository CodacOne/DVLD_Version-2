﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;

namespace BusinessLayer
{
  public  class clsLocalDrivingApplication : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private int _ApplicationID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get; set;
        }


        public int LicenseClassID
        {
            get; set;
        }

        public clsLicenseClass LicenseClassInfo;
      
        public string PersonFullName
        {
            get
            {
                return clsPerson.FindByPersonID(ApplicantPersonID).FullName;
            }

        }

        public clsLocalDrivingApplication()
        {
          this.LocalDrivingLicenseApplicationID = -1;
           
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsLocalDrivingApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
             DateTime ApplicationDate, int ApplicationTypeID,
              enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
              float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }


        /////////////////////////////////////////////////////////////////////
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsDALocalDrivingApplication.UpdateLocalDrivingLicenseApplication
                (
                this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }

      

        /////////////////////////////////////////////////////////////////////
        public static clsLocalDrivingApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            // 
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsDALocalDrivingApplication.GetLocalDrivingLicenseApplicationInfoByID
                (LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingApplication(
                    LocalDrivingLicenseApplicationID, Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;


        }

        public static clsLocalDrivingApplication FindByApplicationID(int ApplicationID)
        {
            // 
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsDALocalDrivingApplication.GetLocalDrivingLicenseApplicationInfoByApplicationID
                (ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingApplication(
                    LocalDrivingLicenseApplicationID, Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;


        }


        private bool _AddNewLocalDrivingApplication()
        {

            this.LocalDrivingLicenseApplicationID = clsDALocalDrivingApplication.AddNewLocalDrivingApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public byte GetPassedTestCount()
        {
            return clsTests.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTests.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }


        /////////////////////////////////////////////////////////////////////

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsDALocalDrivingApplication.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        /////////////////////////////////////////////////////////////////////

      

        /////////////////////////////////////////////////////////////////////

        public bool Save()
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;


            //After we save the main application now we save the sub application.
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }

        /////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        public byte TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsDALocalDrivingApplication.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {

            return clsDALocalDrivingApplication.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTests.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }


        public bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestTypeID)

        {

            return clsDALocalDrivingApplication.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)

        {
            return clsDALocalDrivingApplication.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        /////////////////////////////////////////////////////////////////////
        public static DataTable LicenseApplicationsFilter(int ColumnIndex, string Filter)
        {
            return clsDALocalDrivingApplication.LicenseApplicationsFilter(ColumnIndex, Filter);

        }


        /////////////////////////////////////////////////////////////////////
        /// <summary>
       
        public static DataTable LocalDrivingApplictionType()
        {
            return clsDAApplicationType.GetAllApplicationTypes();

        }


        /////////////////////////////////////////////////////////////////////

        public static bool CancelApplication(int LocalDrivingLicenseApplicationID)
        {

         int ApplicationID = clsDALocalDrivingApplication.GetApplciationIDToCancel(LocalDrivingLicenseApplicationID);

          return clsDALocalDrivingApplication.CancelApplicationCompletly(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /// <summary>

        public static DataTable GetAllDataToSchedulingTest(int LocalDrivingLicenseApplicationID)
        {
            return clsDAApplication.GetAllDataToSchedulingTest(LocalDrivingLicenseApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        ///
        ///   /////////////////////////////////////////////////////////////////////
        ///


        ///   /////////////////////////////////////////////////////////////////////
        public static int GetAllTestsFees(int TestTypeID)
        {
            return clsDAApplication.GetAllTestsFees(TestTypeID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///
         public static DataTable GetDataVisionTest(int ApplicationID)
        {
          
            return clsDATestAppointement.VisionTestAppointement(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///


        /////////////////////////////////////////////////////////////////////
        ///
        public static int GetResultForTest(int TestAppID)
        {

            return clsDATestAppointement.GetResultForTestIfPassingOrFailing(TestAppID);

        }



        /////////////////////////////////////////////////////////////////////
        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        /////////////////////////////////////////////////////////////////////
        ///
      


        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsDALocalDrivingApplication.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        /////////////////////////////////////////////////////////////////////
        ///
        public static bool CancelTheAppointmentAfterPassingOrFailing(int TestID)
        {


            return clsDATestAppointement.CancelTheAppointmentAfterPassingOrFailing(TestID);

        }


        /////////////////////////////////////////////////////////////////////
        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsDALocalDrivingApplication.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        /////////////////////////////////////////////////////////////////////


    }



}
