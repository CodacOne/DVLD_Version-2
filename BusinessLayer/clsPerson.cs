using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DataAccess_Layer;


namespace BusinessLayer
{
    //public struct stPersonDetails
    //{
    //    public int PersonID;
    //    public string NationalNo;
    //    public string FirstName;
    //    public string SecondName;
    //    public string ThirdName;
    //    public string LastName;
    //    public byte Gendor;
    //    public string Email;
    //    public string Phone;
    //    public string Address;
    //    public DateTime DateOfBirth;
    //    public int NationalityCountryID;
    //    public string ImagePath;
    //}


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

        private clsPerson(stPersonDetails personData)
        {
            this.PersonID = personData.PersonID;
            this.NationalNo = personData.NationalNo;
            this.FirstName = personData.FirstName;
            this.SecondName = personData.SecondName;
            this.ThirdName = personData.ThirdName;

            this.LastName = personData.LastName;
            this.Email = personData.Email;
            this.Phone = personData.Phone;
            this.Address = personData.Address;
            this.Gendor = personData.Gendor;
            this.DateOfBirth = personData.DateOfBirth;
            this.NationalityCountryID = personData.NationalityCountryID;
            this.ImagePath = personData.ImagePath;

            Mode = enMode.Update;
        }


        /////////////////////////////////////////////////////////////////////
        ///
        // ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅
        public static DataTable GetAllPeople()
        {
            return clsDataAccess.GetAllPeople();

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



        // ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅
        public static clsPerson FindByPersonID(int ID)
        {
            
            stPersonDetails PersonDetails = new stPersonDetails();


            DateTime dateOfBirth = DateTime.Now;

            if (clsDataAccess.GetPersonInfoByID( ID, ref PersonDetails))
            {
                //  Console.WriteLine("ID is found");
                return new clsPerson(PersonDetails);

            }


            else
            {
                
                return null;
            }

        }


        /////////////////////////////////////////////////////////////////////
        /// <summary>


        // ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅ ✅
        public static clsPerson FindByNationalNo(string NationalNo)
        {

            stPersonDetails PersonDetails = new stPersonDetails();
            //DateTime dateOfBirth = DateTime.Now;

            if (clsDataAccess.GetPersonInfoByNationalNo(NationalNo,ref PersonDetails))
            {
                

                return new clsPerson(PersonDetails);

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
