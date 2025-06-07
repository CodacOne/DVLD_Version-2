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


        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;

        }

        ////////////////////////////////////////////////////////////////
        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID,
            ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);





                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        /////////////////////////////////////////////////////////////////////////////////////////////
        public static bool EditApplicationType(int ApplicationTypeID, string Title, float Fees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Update  ApplicationTypes  
                            set ApplicationTypeTitle = @Title,
                                ApplicationFees = @Fees
                                where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }



        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        ///
        ////////////////////////////////////////////////////////////////
    }
}
