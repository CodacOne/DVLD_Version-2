using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;

namespace BusinessLayer
{
    public class clsIssuedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int CreatedByUserID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public int PaidFees { get; set; }
        public byte IsActive { get; set; }
        public byte IssueReason { get; set; }

        // الباني الافتراضي
        public clsIssuedLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.CreatedByUserID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = 0;
            this.IssueReason = 0;
        }

        // باني بالبارامترات
        public clsIssuedLicense(int licenseID, int applicationID, int driverID, int createdByUserID,
            int licenseClassID, DateTime issueDate, DateTime expirationDate,
            string notes, byte isActive, byte issueReason, int paidFees)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.CreatedByUserID = createdByUserID;
            this.LicenseClassID = licenseClassID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.PaidFees = paidFees;
        }

        /*/*//*/****//**********************//*/*///***///


        /////////////////////////////////////////////////////////////////////
        ///
        private bool _AddNewLicense()
        {
    
            this.LicenseID = clsIssuingLicense.AddNewLicense(this.ApplicationID,
              this.DriverID, this.LicenseClassID, this.IssueReason,
              this.PaidFees, this.CreatedByUserID, this.IssueDate, this.ExpirationDate,
               this.Notes,this.IsActive );

            return (this.LicenseID != -1);


        }


        public static bool DisabledOldLicense(int OldLicenseID)
        {

          return  clsIssuingLicense.DisabledOldLicense(OldLicenseID);

        }


        /*/*//*/****//**********************//*/*///***///
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;

                        return _AddNewLicense();
                    }



                //case enMode.Update:
                //    {
                //        return _UpdateUser();


                //    }


                default:
                    return false;

            }
        }

        /*/*//*/****//**********************//*/*///***///



        public static int ValidationIfLicenseActiveOrNotActive(int LicenseID)
        {

            return clsIssuingLicense.ValidationIfLicenseActiveOrNotActive(LicenseID);

        }

        /*/*//*/****//**********************//*/*///***///


        public static bool IsLicenseDetainedOrNotDetained(int LicenseID)
        {
            return clsIssuingLicense.IsLicenseDetainedOrNotDetained(LicenseID);

        }


        /*/*//*/****//**********************//*/*///***///


        public static bool IsLicenseDisactivatedOrNotDisactivated(int LicenseID)
        {
            return clsIssuingLicense.IsLicenseDisactivatedOrNotDisactivated(LicenseID);

        }

        /*/*//*/****//**********************//*/*///***///
        /*/*//*/****//**********************//*/*///***///

        /*/*//*/****//**********************//*/*///***///

        /*/*//*/****//**********************//*/*///***///
    }
}
