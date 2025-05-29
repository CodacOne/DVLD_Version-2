using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DataAccess_Layer;

namespace BusinessLayer
{
    public class clsPerson
    {
       public static int ID;


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public int PersonID
        {
            get; set;
        }

        public string NationalNo
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string SecondName
        {
            get; set;
        }

        public string ThirdName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }


        public Byte Gendor
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public DateTime DateOfBirth
        {
            get; set;
        }
        public int NationalityCountryID
        {
            get; set;
        }

        public string ImagePath
        {
            get; set;
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";

            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.Gendor = 0;
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }


        /*/////*/////*/////*/////*/////*/////*/////*////

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, Byte Gendor, string Address,
            string Phone, string Email, int NationalityCountryID , 
             string ImagePath)
        {
            this.PersonID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;

            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Gendor = Gendor;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllPeople()
        {
            return clsDataAccess.GetAllPeople();

        }


        public static int GetCountPeople()
        {

            return clsDataAccess.GetPeopleCount();


        }

        /////////////////////////////////////////////////////////////////////

        public static DataTable GetAllCountries()
        {
            return clsDataAccess.GetAllListCountries();

        }

        /////////////////////////////////////////////////////////////////////


        public static bool IsNationalNumber(string NationalNo)
        {

            return clsDataAccess.IsNationalNumberExistOrNot(NationalNo);
        }

        /////////////////////////////////////////////////////////////////////
        ///

        private  bool _AddNewPerson()
        {

         this.PersonID =   clsDataAccess.AddNewPerson(this.NationalNo ,this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email
                , this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        /////////////////////////////////////////////////////////////////////
        ///

        private bool _UpdatePerson()
        {

            return clsDataAccess.UpdatePerson(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                   this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email
                   , this.NationalityCountryID, this.ImagePath);

             
        }



        /////////////////////////////////////////////////////////////////////



        public static clsPerson FindByPersonID(int ID)
        {
            string NationalNo = "",  FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "";
            string Address = ""; Byte Gendor = 0; DateTime DateOfBirth =DateTime.Now;
            int NationalityCountryID = -1;
            string ImagePath = "";

            DateTime dateOfBirth = DateTime.Now;

            if (clsDataAccess.GetPersonInfoByID( ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
            ref LastName, ref DateOfBirth, ref Gendor, ref Address,
            ref Phone, ref Email, ref NationalityCountryID,
             ref ImagePath))
            {
                //  Console.WriteLine("ID is found");
                return new clsPerson( ID,  NationalNo,  FirstName,  SecondName,  ThirdName,
             LastName,  DateOfBirth,  Gendor,  Address,
             Phone,  Email,  NationalityCountryID,
              ImagePath);

            }


            else
            {
                
                return null;
            }

        }


        /////////////////////////////////////////////////////////////////////
        /// <summary>


        public static clsPerson FindByNationalNo(string NationalNo)
        {
            int PersonID = -1; string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "";
            string Address = ""; Byte Gendor = 0; DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            string ImagePath = "";

            //DateTime dateOfBirth = DateTime.Now;

            if (clsDataAccess.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
            ref LastName, ref DateOfBirth, ref Gendor, ref Address,
            ref Phone, ref Email, ref NationalityCountryID,
             ref ImagePath))
            {
                

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
             LastName, DateOfBirth, Gendor, Address,
             Phone, Email, NationalityCountryID,
              ImagePath);

            }


            else
            {

                return null;
            }

        }


        /////////////////////////////////////////////////////////////////////
        /// <summary>


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {

                        Mode = enMode.Update;
                        return _AddNewPerson();
                    }



                case enMode.Update:
                    {
                        return _UpdatePerson();

                       
                    }


                default:
                    return false;

            }
        }



        /////////////////////////////////////////////////////////////////////
        ///

      

        /////////////////////////////////////////////////////////////////////
        ///

        public static bool DeleteOnePersonFromTable(int ID)
        {

            return clsDataAccess.DeleteContactPerson(ID);


        }


        /////////////////////////////////////////////////////////////////////
        public static DataTable GetPeopleAfterFilter(int TypeFilter, string Filter)
        {
            return clsDataAccess.GeneralFilter(TypeFilter, Filter);

        }


        /////////////////////////////////////////////////////////////////////


    }
}
