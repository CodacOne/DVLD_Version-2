using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;

using System.Data;

namespace BusinessLayer
{
  public  class clsDriver
    {


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public clsPerson PersonInfo;
        public int PersonID { get; set;  }

        public int DriverID  { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime CreatedDate  {   get; set; }



        /////////////////////////////////////////////////////////////////////
        public clsDriver()
        {
            this.PersonID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;



            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.PersonID = PersonID;
            this.DriverID = DriverID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPerson.FindByPersonID(PersonID);

            Mode = enMode.Update;
        }

        /*/*//*/******************************************************************//*/*/
        public static clsDriver FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDADriver.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }


        /*/*//*/******************************************************************//*/*/
                                                                                   /////////////////////////////////////////////////////////////////////


        private bool _AddNewLocalDrivingApplication()
        {

            this.DriverID = clsDAIssuingLicense.AddNewDriver(this.PersonID, this.CreatedByUserID,this.CreatedDate);

            return (this.DriverID != -1);
        }

        /////////////////////////////////////////////////////////////////////
        /// <summary>

        public static clsDriver FindByDriverID(int DriverID)
        {

            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDADriver.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        
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
        /////////////////////////////////////////////////////////////////////
        public static int GetFeesOfLicenseClassTable(int LicenseClassID)
        {

            return clsDAIssuingLicense.GetFeesOfLicenseClassTable(LicenseClassID);


        }

        /*/*//*/******************************************************************//*/*/
                                                                                   /////////////////////////////////////////////////////////////////////
      public static bool InsertLNewLicense(
    int ApplicationID, int DriverID, int LicenseClassID, int IssueReason,
    int PaidFees, int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate,
    string Notes, byte IsActive)
        {

            return clsDAIssuingLicense.InsertLicense( ApplicationID,  DriverID,  LicenseClassID,  IssueReason,
     PaidFees,  CreatedByUserID,  IssueDate,  ExpirationDate,
     Notes,  IsActive);


        }

        /*/*//*/******************************************************************//*/*/
        public static bool ValidationIFLicenseExistOrNot(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = clsDAIssuingLicense.GetApplicationIDByLocalDrivingID(LocalDrivingLicenseApplicationID);

            return clsDAIssuingLicense.ValidateIfLicenseExistOrNOT(ApplicationID);
        }


        /*/*//*/******************************************************************//*/*/

        
        public static DataTable GetAllDriverInfo(int LicenseID)
        {

            return clsDAIssuingLicense.GetAllDriverInfo(LicenseID);

        }

        /*/*//*/******************************************************************//*/*/


        public static DataTable GetDataForInternationalLicenseApplication(int LicenseID)
        {

            return clsDAIssuingLicense.GetAllDriverInfo(LicenseID);

        }

        /*/*//*/******************************************************************//*/*/


        public static DataTable GetDriverInfoOnly(int ApplicationID)
        {

            int LicenseID = clsDAIssuingLicense.GetLicenseIDByApplicatinID(ApplicationID);

            return clsDAIssuingLicense.GetDriverInfoOnlyForDgv(LicenseID);

        }
        

        /////////////////////////////////////////////////////////////////////


             public static DataTable GetAllLicenseToThePersonForDgv(int PersonID)
        {

           
            return clsDAIssuingLicense.GetAllLicenseToThePersonForDgv(PersonID);

        }
        

        /////////////////////////////////////////////////////////////////////

        /*/*//*/******************************************************************//*/*/


        public static DataTable DriversWithLicensesFilter(int ColumnIndex, string Filter)
        {

         return   clsDAIssuingLicense.DriversWithLicensesFilter(ColumnIndex, Filter);

        }


        /////////////////////////////////////////////////////////////////////
        /*/*//*/******************************************************************//*/*/

        /*/*//*/******************************************************************//*/*/
                                                                                   /*/*//*/******************************************************************//*/*/

        /*/*//*/******************************************************************//*/*/
    }
}
