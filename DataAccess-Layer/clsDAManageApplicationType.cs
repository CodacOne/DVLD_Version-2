using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess_Layer
{
   public class clsDAManageApplicationType
    {
        public static DataTable GetAllApplicationTypes()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"SELECT * from ApplicationTypes";


            SqlCommand command = new SqlCommand(query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Dt.Load(Reader);

                }

                Reader.Close();
            }


            catch (Exception ex)
            {


                throw new Exception("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return Dt;
        }
        ////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////
        public static int GetApplicationTypesCount()
        {

            int Count = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT COUNT(*) FROM ApplicationTypes";

            SqlCommand command = new SqlCommand(query, Connection);



            try
            {
                Connection.Open();

                object Result = command.ExecuteScalar();

                Count = Convert.ToInt32(Result);

                return Count;

            }


            catch (Exception ex)
            {
                Count = -1;


                throw new Exception("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return Count;
        }


        ////////////////////////////////////////////////////////////////

    }
}
