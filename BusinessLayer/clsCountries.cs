using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using DataAccess_Layer;

namespace BusinessLayer
{
    public class clsCountries
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int CountryID
        {

            get; set;
        }


        public string CountryName
        {

            get; set;
        }

        public clsCountries()
        {
            this.CountryID = -1;
            this.CountryName = "";
            Mode = enMode.AddNew;
        }



        private clsCountries(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            Mode = enMode.Update;
        }


        //////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////

        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";


            if (clsDataAccessCountries.GetCountryInfoByID(CountryID, ref CountryName))
            {

                return new clsCountries(CountryID, CountryName);

            }


            else
            {
             
                return null;
            }

        }


        /// //////////////////////////////////////////////////////////////

        public static clsCountries Find(string CountryName)
        {
            int CountryID = -1;

            
            if (clsDataAccessCountries.GetCountryInfoByName(ref CountryID, CountryName))
            {

                return new clsCountries(CountryID, CountryName);

            }


            else
            {

                return null;
            }

        }

        /////////////////////////////////////////////////////////////////////
        ///

    }
}
