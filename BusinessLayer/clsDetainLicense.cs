using DataAccess_Layer;
using System;
using System.Data;

namespace BusinessLayer
{
    public  class clsDetainLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public int FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleaseId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        /////////////////////////////////////////////////////////////////////
        public clsDetainLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleaseId = false;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;
            this.ReleaseApplicationID = null;

            Mode = enMode.AddNew;
        }

        /////////////////////////////////////////////////////////////////////
        private clsDetainLicense(int DetainID, int LicenseID, DateTime DetainDate, int FineFees,
                          int CreatedByUserID, bool IsReleaseId, DateTime? ReleaseDate,
                          int? ReleasedayUserID, int? ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleaseId = IsReleaseId;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedayUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        /////////////////////////////////////////////////////////////////////
        private bool _AddNewDetain()
        {
            this.DetainID = clsDADetainAndRelease.AddNewDetain(this.LicenseID, this.DetainDate, this.FineFees,
           this.CreatedByUserID, this.IsReleaseId, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

            return (this.DetainID != -1);
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
        /////////////////////////////////////////////////////////////////////
        private bool _UpdateDetain()
        {
            return clsDADetainAndRelease.UpdateDetain(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees,
                                           this.CreatedByUserID, this.IsReleaseId, this.ReleaseDate,
                                           this.ReleasedByUserID, this.ReleaseApplicationID);
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///



        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///
                                      /////////////////////////////////////////////////////////////////////
        public static bool UpdateDetain(int DetainID, bool IsReleased, DateTime? ReleaseDate,
        int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            return clsDADetainAndRelease.UpdateDetain(DetainID,IsReleased, ReleaseDate,
                                      ReleasedByUserID, ReleaseApplicationID);
        }


        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllDetainInfoByLicenseID(int LicenseID)
        {
            return clsDADetainAndRelease.GetAllDetainInfoByLicenseID(LicenseID);

        }

        /////////////////////////////////////////////////////////////////////
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetain())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                   // return _UpdateDetain();

                default:
                    return false;
            }
        }

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///


        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllInfoForListDetain_Dgv(int ColumnIndex, string Filter)
        {
            return clsDADetainAndRelease.GetAllInfoForListDetain_Dgv(ColumnIndex, Filter);

        }
        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

        /**//*/*//*//*//*/**//*/*//*//***************//*/*****///

    }
}
