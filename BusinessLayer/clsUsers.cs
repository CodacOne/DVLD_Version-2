using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsApplication;

namespace BusinessLayer
{
   public  class clsUsers
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public clsPerson PersonInfo;
        public int PersonID
        {
            get; set;
        }

        public int UserID
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }


        public enApplicationStatus ApplicationStatus { set; get; }
        public Byte IsActive
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

        /////////////////////////////////////////////////////////////////////
        public clsUsers()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = 0;
           



            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsUsers(int UserID, int PersonID, string UserName, string Password,Byte  IsActive)
        {
            this.PersonID = PersonID;
            this.UserID   = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.FindByPersonID(PersonID);

            Mode = enMode.Update;
        }



        public static clsUsers Find(int PersonID)
        {
            int UserID = -1; string UserName = "", Password = ""; Byte IsActive = 0;


            if (clsDAUsers.GetUserInfoByID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive) )
            {
                //  Console.WriteLine("ID is found");
                return new clsUsers( UserID,  PersonID,  UserName,  Password,  IsActive);

            }


            else
            {

                return null;
            }

        }
        /////////////////////////////////////////////////////////////////////
        public static clsUsers FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            Byte IsActive = 0;

            bool IsFound = clsDAUsers.GetUserInfoByUserID
                                (UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        /////////////////////////////////////////////////////////////////////

        public static clsUsers FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            Byte IsActive = 0;

            bool IsFound = clsDAUsers.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        /////////////////////////////////////////////////////////////////////

        private bool _AddNewUser()
        {

            this.UserID = clsDAUsers.AddNewUser(this.PersonID, this.UserName, this.Password,this.IsActive);

            return (this.UserID != -1);
        }

        /////////////////////////////////////////////////////////////////////
        ///

        private bool _UpdateUser()
        {

            return clsDAUsers.UpdateUser(this.PersonID,this.UserName, this.Password, this.IsActive);


        }



        /////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllUsers()
        {
            return clsDAUsers.GetAllUsers();

        }

        /////////////////////////////////////////////////////////////////////
       

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewUser();
                    }



                case enMode.Update:
                    {
                         return _UpdateUser();
                      

                    }


                default:
                    return false;

            }
        }

        /////////////////////////////////////////////////////////////////////
        public static bool IsUserExistOrNot(int PersonID)
        {

            return clsDAUsers.IsUserExistOrNot(PersonID);


        }

        /////////////////////////////////////////////////////////////////////
       

        /////////////////////////////////////////////////////////////////////
        ///

        public static bool DeleteOneUserFromTable(int UserID)
        {

            return clsDAUsers.DeleteContactUser(UserID);


        }


        /////////////////////////////////////////////////////////////////////
        public static DataTable GetUsersAfterFilter(int TypeFilter, string Filter)
        {
            return clsDAUsers.GeneralFilter(TypeFilter, Filter);

        }



        /////////////////////////////////////////////////////////////////////
       

        ///   /////////////////////////////////////////////////////////////////////
        public static int  GetPersonIDByUserID(int UserID)
        {
            return clsDAUsers.GetPersonIDByUserID(UserID);

        }
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

    }
}
