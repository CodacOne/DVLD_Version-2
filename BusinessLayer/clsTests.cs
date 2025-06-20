using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;


namespace BusinessLayer
{
  public  class clsTests
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public clsTestAppointement TestAppointmentInfo { set; get; }
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get; }

        public clsTests()

        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsTests(int TestID, int TestAppointmentID,
            bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointement.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }


        /////////////////////////////////////////////////////////////////////

        private bool _AddNewTest()
        {

            this.TestID = clsDATestAppointement.AddNewTest(this.TestAppointmentID, this.CreatedByUserID, this.TestResult, this.Notes);

            return (this.TestID != -1);
        }


        /////////////////////////////////////////////////////////////////////
        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsDATestAppointement.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }

        /////////////////////////////////////////////////////////////////////
        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsDATestAppointement.GetTestInfoByID(TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;

        }

        /////////////////////////////////////////////////////////////////////
        public static clsTests FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsDATests.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsDATestAppointement.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }

        /////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        /// <summary>



        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewTest();
                    }



                case enMode.Update:
                    {
                        return _UpdateTest();
                        return false;

                    }


                default:
                    return false;

            }
        }









    }
}
