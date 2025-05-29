using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data;

namespace BusinessLayer
{
  public  class clsManageTestTypes
    {
        /////////////////////////////////////////////////////////////////////
        public static DataTable GetAllTestTypes()
        {
            return clsDAManageTestTypes.GetAllTestTypes();

        }

        /////////////////////////////////////////////////////////////////////
        public static int GetTestTypesCount()
        {

            return clsDAManageTestTypes.GetTestTypesCount();


        }

        /////////////////////////////////////////////////////////////////////


    }
}
