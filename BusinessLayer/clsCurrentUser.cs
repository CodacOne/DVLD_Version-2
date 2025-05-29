using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;

namespace BusinessLayer
{
   public  class clsCurrentUser
    {
        public static string CurrentUserName;
        public static int CurrentUserID;

        public int PersonID
        {
            get; set;
        }

        public int UserID
        {
            get; set;
        }

        public  string UserName
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


        private clsCurrentUser(int UserID, int PersonID, string UserName, string Password, Byte IsActive)
        {
            this.PersonID = PersonID;
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

        }


        //public string GetUserName()
        //{

        //    return UserName;

        //}


       ////////////*/*/**************//////////////////////////////////////////////////
       /// <summary>
       /// 


       public static clsCurrentUser FindCurrentUser(string _UserID)
        {

         DataTable Dt =  clsDAUsers.GeneralFilter(1, _UserID);

            if (Dt.Rows.Count > 0)
          
            {
                DataRow row = Dt.Rows[0];

            


                CurrentUserID = Convert.ToInt32(row["UserID"]);
                int UserID = CurrentUserID;
                int PersonID = Convert.ToInt32(row["PersonID"]);
                CurrentUserName  = row["UserName"].ToString();
                string UserName = CurrentUserName;

                string Password = row["Password"].ToString();
                Byte IsActive = Convert.ToByte(row["IsActive"]);

                return new clsCurrentUser(UserID, PersonID, UserName, Password, IsActive);

            }

            else
                return null;
          

        }










        ////////////*/*/**************//////////////////////////////////////////////////
    }



}
