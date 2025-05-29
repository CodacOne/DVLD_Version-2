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

        public int IssuedUsingLocalLicenseID
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
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = 0;
            this.CreatedByUserID = -1;




            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, Byte IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
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
            this.InternationalLicenseID =clsIssuingLicense.AddNewInternationalLicense(
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
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

            return clsIssuingLicense.CheckIfLicenseExistsInInternationalCertificates(LicenseID);


        }

        ///   /////////////////////////////////////////////////////////////////////
        ///   
        ///  /////////////////////////////////////////////////////////////////////
        ///

        public static bool CheckIfLocalLicenseExistsAndAndLicenseClassWorth_3(int LicenseID)
        {

            return clsIssuingLicense.CheckIfLocalLicenseExistsAndAndLicenseClassWorth_3(LicenseID);


        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetInternationalLicenseInfo(int LicenseID)
        {

            return clsIssuingLicense.GetInternationalLicenseInfo(LicenseID);

        }
        /////////////////////////////////////////////////////////////////////


        public static int GetLocalDrivingLicenseApplicationIDByApplicationID(int ApplicationID)
        {
            
            return clsIssuingLicense.GetLocalDrivingLicenseApplicationIDByApplicationID(ApplicationID);


        }

        

        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {

            return clsIssuingLicense.GetAllInternationalLicenseByPersonID(PersonID);

        }

        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetInternationalLicenseInforDgv()
        {

            return clsIssuingLicense.GetInternationalLicenseInforDgv();

        }

        /////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetInternationalLicenseOfPersonForDgv(int ApplicationID)
        {
            
            return clsIssuingLicense.GetInternationalLicenseOfPersonForDgv(ApplicationID);

        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        ///
        public static DataTable GetAllLocalLicenseInfoForRenewLicense(int LicenseID)
        {

            return clsIssuingLicense.GetAllLocalLicenseInfoForRenewLicense(LicenseID);

        }

        /////////////////////////////////////////////////////////////////////
        public static int GetPersonIDByDriverID(int DriverID)
        {

            return clsIssuingLicense.GetPersonIDByDriverID(DriverID);


        }

        ///////////////////////**********************//////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        public static bool IsLicenseValid(int LicenseID)
        {

            return clsIssuingLicense.IsLicenseValid(LicenseID);


        }
        ///////////////////////**********************//////////////////////////////****
        public static int GetPersonIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)
        {
            
            return clsDAManageLocalDrivingApplication.GetPersonIDByLocalDrivingID(LocalDrivingLicenseApplicationID);


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
