﻿using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int ID { set; get; }
        public string Title { set; get; }
        public float Fees { set; get; }

        public clsApplicationType()

        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.AddNew;

        }

        public clsApplicationType(int ID, string ApplicationTypeTitel, float ApplicationTypeFees)

        {
            this.ID = ID;
            this.Title = ApplicationTypeTitel;
            this.Fees = ApplicationTypeFees;
            Mode = enMode.Update;
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ID = clsDAApplicationType.AddNewApplicationType(this.Title, this.Fees);


            return (this.ID != -1);
        }

        private bool _EditApplicationType()
        {
            //call DataAccess Layer 

            return clsDAApplicationType.EditApplicationType(this.ID, this.Title, this.Fees);
        }

        public static clsApplicationType Find(int ID)
        {
            string Title = ""; float Fees = 0;

            if (clsDAApplicationType.GetApplicationTypeInfoByID((int)ID, ref Title, ref Fees))

                return new clsApplicationType(ID, Title, Fees);
            else
                return null;

        }

        /**//*//*//******/////////////////////////////*


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _EditApplicationType();

            }

            return false;
        }


        /**//*//*//******/////////////////////////////*

    }
}
