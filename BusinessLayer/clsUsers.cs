using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


using DataAccess_Layer;

namespace BusinessLayer
{
   public  class clsUsers
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



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

      

        public Byte IsActive
        {
            get; set;
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
           




            Mode = enMode.Update;
        }




        /////////////////////////////////////////////////////////////////////


        /// /////////////////////////////////////////////////////////////////////

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

        public static bool UpdateUser(int UserID,string Password)
        {

            return clsDAUsers.UpdateUser(UserID, Password);


        }



        /////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllUsers()
        {
            return clsDAUsers.GetAllUsers();

        }

        /////////////////////////////////////////////////////////////////////
        public static int GetCountUsers()
        {

            return clsDAUsers.GetUsersCount();


        }

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
        public static bool ValidateToLogIn(string UserName, string Password)
        {
            
          int CurrentUserID =  clsDAUsers.LogIn(UserName, Password);


            if(CurrentUserID != -1)
            {
                clsCurrentUser.FindCurrentUser(CurrentUserID.ToString());

            }

            return (CurrentUserID != -1) ? true : false;
        }


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
        ///
        ///   /////////////////////////////////////////////////////////////////////
        public static DataTable GetPersonAndUserInformation(int PersonID)
        {
            return clsDAUsers.GetPersonAndUserInformation(PersonID);

        }


        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

    }
}
