using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;

using System.Data;

namespace BusinessLayer
{
  public  class clsDrivers
    {


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public int PersonID
        {
            get; set;
        }

        public int DriverID
        {
            get; set;
        }

        public int CreatedByUserID
        {
            get; set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }






        /////////////////////////////////////////////////////////////////////
        public clsDrivers()
        {
            this.PersonID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;



            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////
        /*/*//*/******************************************************************//*/*/
        private clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.PersonID = PersonID;
            this.DriverID = DriverID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
          

            Mode = enMode.Update;
        }

        /*/*//*/******************************************************************//*/*/
                                                                                   /////////////////////////////////////////////////////////////////////


        private bool _AddNewLocalDrivingApplication()
        {

            this.DriverID = clsIssuingLicense.AddNewDriver(this.PersonID, this.CreatedByUserID,this.CreatedDate);

            return (this.DriverID != -1);
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
        /////////////////////////////////////////////////////////////////////
        public static int GetFeesOfLicenseClassTable(int LicenseClassID)
        {

            return clsIssuingLicense.GetFeesOfLicenseClassTable(LicenseClassID);


        }

        /*/*//*/******************************************************************//*/*/
                                                                                   /////////////////////////////////////////////////////////////////////
      public static bool InsertLNewLicense(
    int ApplicationID, int DriverID, int LicenseClassID, int IssueReason,
    int PaidFees, int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate,
    string Notes, byte IsActive)
        {

            return clsIssuingLicense.InsertLicense( ApplicationID,  DriverID,  LicenseClassID,  IssueReason,
     PaidFees,  CreatedByUserID,  IssueDate,  ExpirationDate,
     Notes,  IsActive);


        }

        /*/*//*/******************************************************************//*/*/
        public static bool ValidationIFLicenseExistOrNot(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = clsIssuingLicense.GetApplicationIDByLocalDrivingID(LocalDrivingLicenseApplicationID);

            return clsIssuingLicense.ValidateIfLicenseExistOrNOT(ApplicationID);
        }


        /*/*//*/******************************************************************//*/*/

        
        public static DataTable GetAllDriverInfo(int LicenseID)
        {

            return clsIssuingLicense.GetAllDriverInfo(LicenseID);

        }

        /*/*//*/******************************************************************//*/*/


        public static DataTable GetDataForInternationalLicenseApplication(int LicenseID)
        {

            return clsIssuingLicense.GetAllDriverInfo(LicenseID);

        }

        /*/*//*/******************************************************************//*/*/


        public static DataTable GetDriverInfoOnly(int ApplicationID)
        {

            int LicenseID = clsIssuingLicense.GetLicenseIDByApplicatinID(ApplicationID);

            return clsIssuingLicense.GetDriverInfoOnlyForDgv(LicenseID);

        }
        

        /////////////////////////////////////////////////////////////////////


             public static DataTable GetAllLicenseToThePersonForDgv(int PersonID)
        {

           
            return clsIssuingLicense.GetAllLicenseToThePersonForDgv(PersonID);

        }
        

        /////////////////////////////////////////////////////////////////////

        /*/*//*/******************************************************************//*/*/


        public static DataTable DriversWithLicensesFilter(int ColumnIndex, string Filter)
        {

         return   clsIssuingLicense.DriversWithLicensesFilter(ColumnIndex, Filter);

        }


        /////////////////////////////////////////////////////////////////////
        /*/*//*/******************************************************************//*/*/

        /*/*//*/******************************************************************//*/*/
                                                                                   /*/*//*/******************************************************************//*/*/

        /*/*//*/******************************************************************//*/*/
    }
}
