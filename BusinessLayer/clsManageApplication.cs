using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;


namespace BusinessLayer
{
    public class clsManageApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

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

        public int ApplicationStatus
        {
            get; set;
        }

        public float PaidFees
        {
            get; set;
        }


        public int CreatedByUserID
        {
            get; set;
        }


        public DateTime LastStatusDate
        {
            get; set;
        }
      
        public clsManageApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = -1;

            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.LastStatusDate = DateTime.Now;
            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsManageApplication(int ApplicationID, int ApplicantPersonID, int ApplicationTypeID,
            int ApplicationStatus, DateTime ApplicationDate, float PaidFees, DateTime LastStatusDate,
            int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;

            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LastStatusDate = LastStatusDate;
            Mode = enMode.Update;
        }


        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        ///
        public  bool _AddNewApplication()
        {
          
          _ApplicationID = clsDAManageLocalDrivingApplication.FillDataToApplicationTable(this.ApplicantPersonID,
            this.ApplicationTypeID, this.ApplicationStatus, this.ApplicationDate,
            this.PaidFees, this.LastStatusDate, this.CreatedByUserID);

            this.ApplicationID = _ApplicationID;

            return (this.ApplicationID != -1);


        }

        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        ///
        /////////////////////////////////////////////////////////////////////
        public static int GetCountManageApplicationType()
        {

            return clsDAManageApplicationType.GetApplicationTypesCount();


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

                        return _AddNewApplication();
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
    }
}
