using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;

namespace BusinessLayer
{
  public  class clsTestTypes
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestTypes.enTestType ID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public float Fees { set; get; }
        public clsTestTypes()

        {
            this.ID = clsTestTypes.enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            Mode = enMode.AddNew;

        }

        public clsTestTypes(clsTestTypes.enTestType ID, string TestTypeTitel, string Description, float TestTypeFees)

        {
            this.ID = ID;
            this.Title = TestTypeTitel;
            this.Description = Description;

            this.Fees = TestTypeFees;
            Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.ID = (clsTestTypes.enTestType)clsDATestTypes.AddNewTestType(this.Title, this.Description, this.Fees);

            return (this.Title != "");
        }   
          
        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsDATestTypes.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;

            if (clsDATestTypes.GetTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))

                return new clsTestTypes(TestTypeID, Title, Description, Fees);
            else
                return null;

        }

       

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllTestTypes()
        {
            return clsDATestTypes.GetAllTestTypes();

        }

        /////////////////////////////////////////////////////////////////////
       

        /////////////////////////////////////////////////////////////////////


    }
}
