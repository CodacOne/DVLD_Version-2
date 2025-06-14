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


        public int ApplicationID
        {
            get; set;
        }


        public int LicenseClassID
        {
            get; set;
        }

        public string PeronalFullName
        {

            get
            {
                return base.PersonInfo.FullName;
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
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
        //  this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
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


        private bool _AddNewLocalDrivingApplication()
        {

            this.LocalDrivingLicenseApplicationID = clsDALocalDrivingApplication.AddNewLocalDrivingApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
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
          
            return clsDATestTypesAppointement.VisionTestAppointement(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///


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

            return clsDAApplication.GetLicenseIDByLocalDrivingID(LocalDrivingLicenseApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static bool CancelTheAppointmentAfterPassingOrFailing(int TestID)
        {


            return clsDATestTypesAppointement.CancelTheAppointmentAfterPassingOrFailing(TestID);

        }


        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////


    }



}
