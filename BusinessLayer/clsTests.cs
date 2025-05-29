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

      
        public Byte TsetResult
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
            this.TsetResult = 0;


            Mode = enMode.AddNew;

        }

        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsTests(int TestID, int TestAppointmentID, int CreatedByUserID, byte TestResult, string Notes)
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
        ///
        /////////////////////////////////////////////////////////////////////


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
                        // return _UpdateUser();
                        return false;

                    }


                default:
                    return false;

            }
        }









    }
}
