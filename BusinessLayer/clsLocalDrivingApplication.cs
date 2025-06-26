using System;
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
        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = clsDALocalDrivingApplication.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;

        }

        /////////////////////////////////////////////////////////////////////
        public bool Cancel()

        {
            return clsDALocalDrivingApplication.UpdateStatus(ApplicationID, 2);
        }


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

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }

        /////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        public bool PassedAllTests()
        {
            return clsTests.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsTests.PassedAllTests(LocalDrivingLicenseApplicationID);
        }
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
      


        /////////////////////////////////////////////////////////////////////
        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)

        {
            return clsDALocalDrivingApplication.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        /////////////////////////////////////////////////////////////////////


    }



}
