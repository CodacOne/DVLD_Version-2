using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;


namespace BusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

      
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public bool Delete()
        {
            return clsDAApplication.DeleteApplication(this.ApplicationID);
        }


        public string ApplicantFullName
        {
            get
            {
                return clsPerson.FindByPersonID(ApplicantPersonID).FullName;
            }
        }

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public static int _ApplicationID;

        public  int ApplicationID
        {
            get; set;
        }

        
         public int ApplicantPersonID
        {
            get; set;
        }

         public DateTime ApplicationDate
        {
            get; set;
        }
     

        public int ApplicationTypeID
        {
            get; set;
        }

        public enApplicationStatus ApplicationStatus
        {
            get; set;
        }

        public float PaidFees
        {
            get; set;
        }

        public clsUsers CreateByUserInfo;
        public clsApplicationType ApplicationTypeInfo;
        public clsPerson PersonInfo;
        public int CreatedByUserID
        {
            get; set;
        }


        public DateTime LastStatusDate
        {
            get; set;
        }

      

        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;

            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.LastStatusDate = DateTime.Now;
            
            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsApplication(int ApplicationID, int ApplicantPersonID, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime ApplicationDate, float PaidFees, DateTime LastStatusDate,
            int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreateByUserInfo = clsUsers.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
        }


        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        ///
        public  bool _AddNewApplication()
        {
          
          _ApplicationID = clsDAApplication.AddNewApplication(this.ApplicantPersonID,
            this.ApplicationTypeID, (byte)this.ApplicationStatus, this.ApplicationDate,
            this.PaidFees, this.LastStatusDate, this.CreatedByUserID);

            this.ApplicationID = _ApplicationID;

            return (this.ApplicationID != -1);


        }

        /////////////////////////////////////////////////////////////////////
        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsDAApplication.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now; int ApplicationTypeID = -1;
            byte ApplicationStatus = 1; DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0; int CreatedByUserID = -1;

            bool IsFound = clsDAApplication.GetApplicationInfoByID
                                (
                                    ApplicationID, ref ApplicantPersonID,
                                    ref ApplicationDate, ref ApplicationTypeID,
                                    ref ApplicationStatus, ref LastStatusDate,
                                    ref PaidFees, ref CreatedByUserID
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsApplication(ApplicationID, ApplicantPersonID,
                                     ApplicationTypeID, (enApplicationStatus)ApplicationStatus
                                     ,ApplicationDate,PaidFees,
                                     LastStatusDate, CreatedByUserID);

            else
                return null;
        }
       
        /////////////////////////////////////////////////////////////////////
        ///


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        return _AddNewApplication();
                        Mode = enMode.Update;
                    }



                case enMode.Update:
                    {
                        return _UpdateApplication();

                    }


                default:
                    return false;

            }
        }

       

        /////////////////////////////////////////////////////////////////////
    }
}
