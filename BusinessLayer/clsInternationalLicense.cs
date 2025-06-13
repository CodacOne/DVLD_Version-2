using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;


namespace BusinessLayer
{
   public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public int InternationalLicenseID
        {
            get; set;
        }

        public int ApplicationID
        {
            get; set;
        }

        public int DriverID
        {
            get; set;
        }

        public int IssuedUsingLocalDrivingLicenseApplicationID
        {
            get; set;
        }


        public DateTime IssueDate
        {
            get; set;
        }



        public DateTime ExpirationDate
        {
            get; set;
        }

        public Byte IsActive
        {
            get; set;
        }

        public int CreatedByUserID
        {
            get; set;
        }

      



        /////////////////////////////////////////////////////////////////////
        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalDrivingLicenseApplicationID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = 0;
            this.CreatedByUserID = -1;




            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalDrivingLicenseApplicationID, DateTime IssueDate, DateTime ExpirationDate, Byte IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalDrivingLicenseApplicationID = IssuedUsingLocalDrivingLicenseApplicationID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;


            Mode = enMode.Update;
        }


        /////////////////////////////////////////////////////////////////////
        private bool _AddNewInternationalLicense()
        {
            // يفترض أن لديك كلاس Data Access مثل clsDAInternationalLicenses يحتوي على دالة للإضافة
            this.InternationalLicenseID =clsDAIssuingLicense.AddNewInternationalLicense(
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalDrivingLicenseApplicationID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID
            );

            return (this.InternationalLicenseID != -1);
        }

       

        /////////////////////////////////////////////////////////////////////
        ///

        public static bool LicenseExistOrNotInInternationalTable(int LicenseID)
        {

            return clsDAIssuingLicense.CheckIfLicenseExistsInInternationalCertificates(LicenseID);


        }

        ///   /////////////////////////////////////////////////////////////////////
        ///   
        ///  /////////////////////////////////////////////////////////////////////
        ///

        public static bool CheckIfLocalDrivingLicenseApplicationExistsAndAndLicenseClassWorth_3(int LicenseID)
        {

            return clsDAIssuingLicense.CheckIfLocalDrivingLicenseApplicationExistsAndAndLicenseClassWorth_3(LicenseID);


        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetInternationalLicenseInfo(int LicenseID)
        {

            return clsDAIssuingLicense.GetInternationalLicenseInfo(LicenseID);

        }
        /////////////////////////////////////////////////////////////////////


        public static int GetLocalDrivingLicenseApplicationIDByApplicationID(int ApplicationID)
        {
            
            return clsDAIssuingLicense.GetLocalDrivingLicenseApplicationIDByApplicationID(ApplicationID);


        }

        

        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {

            return clsDAIssuingLicense.GetAllInternationalLicenseByPersonID(PersonID);

        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetInternationalLicenseInforDgv()
        {

            return clsDAIssuingLicense.GetInternationalLicenseInforDgv();

        }

        /////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetInternationalLicenseOfPersonForDgv(int ApplicationID)
        {
            
            return clsDAIssuingLicense.GetInternationalLicenseOfPersonForDgv(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetAllLocalDrivingLicenseApplicationInfoForRenewLicense(int LicenseID)
        {

            return clsDAIssuingLicense.GetAllLocalDrivingLicenseApplicationInfoForRenewLicense(LicenseID);

        }

        /////////////////////////////////////////////////////////////////////
        public static int GetPersonIDByDriverID(int DriverID)
        {

            return clsDAIssuingLicense.GetPersonIDByDriverID(DriverID);


        }

        ///////////////////////**********************//////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        public static bool IsLicenseValid(int LicenseID)
        {

            return clsDAIssuingLicense.IsLicenseValid(LicenseID);


        }
        ///////////////////////**********************//////////////////////////////****
        public static int GetPersonIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)
        {
            
            return clsDAApplication.GetPersonIDByLocalDrivingID(LocalDrivingLicenseApplicationID);


        }


        ///////////////////////**********************//////////////////////////////****////

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewInternationalLicense();
                    }



                case enMode.Update:
                    {
                        //  return _UpdateUser();

                        return false;
                    }


                default:
                    return false;

            }
        }

        /////////////////////////////////////////////////////////////////////


    }
}
