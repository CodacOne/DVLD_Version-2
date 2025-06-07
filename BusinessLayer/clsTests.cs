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

        public int TestID
        {
            get; set;
        }


        public int TestAppointementID
        {
            get; set;
        }

        public int CreatedByUserID
        {
            get; set;
        }

        public string Notes
        {
            get; set;
        }

      
        public bool TsetResult
        {
            get; set;
        }

        /////////////////////////////////////////////////////////////////////
        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointementID = -1;
            this.CreatedByUserID = -1;
            this.Notes = ""; 
            this.TsetResult = false;


            Mode = enMode.AddNew;

        }

        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsTests(int TestID, int TestAppointmentID, int CreatedByUserID, bool TestResult, string Notes)
        {
            this.TestID = TestID;
            this.TestAppointementID = TestAppointmentID ;
            this.CreatedByUserID = CreatedByUserID;
           
            this.TsetResult = TestResult;
            this.Notes = Notes;


            Mode = enMode.Update;
        }

        /////////////////////////////////////////////////////////////////////

        private bool _AddNewTest()
        {

            this.TestID = clsDATestTypesAppointement.AddNewTest(this.TestAppointementID, this.CreatedByUserID, this.TsetResult, this.Notes);

            return (this.TestID != -1);
        }


        /////////////////////////////////////////////////////////////////////
        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsDATestTypesAppointement.UpdateTest(this.TestID, this.TestAppointementID,
                this.TsetResult, this.Notes, this.CreatedByUserID);
        }

        /////////////////////////////////////////////////////////////////////
        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsDATestTypesAppointement.GetTestInfoByID(TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, CreatedByUserID, TestResult,
                        Notes );
            else
                return null;

        }

        /////////////////////////////////////////////////////////////////////
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsDATestTypesAppointement.GetPassedTestCount(LocalDrivingLicenseApplicationID);
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
