using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace DataAccess_Layer
{
    public class clsDataAccessCountries
    {
        //public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        //{
        //    bool IsFound = false;


        //    SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

        //    string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

        //    SqlCommand command = new SqlCommand(query, Connection);
        //    command.Parameters.AddWithValue("@CountryID", CountryID);

        //    try
        //    {
        //        Connection.Open();
        //        SqlDataReader Reader = command.ExecuteReader();

        //        if (Reader.Read())
        //        {
        //            IsFound = true;


        //            CountryName = Convert.ToString(Reader["CountryName"]);

        //        }

        //        else
        //        {
        //            IsFound = false;

        //        }

        //        Reader.Close();


        //    }


        //    catch (Exception ex)
        //    {

        //        IsFound = false;
        //         throw new Exception("Error : " + ex.Message);
        //    }

        //    finally
        //    {
        //        Connection.Close();
        //    }

        //    return IsFound;
        //}

        //////////////////////////////////////////////////////////////////////////

        public static bool GetCountryInfoByName(ref int CountryID, string CountryName)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;


                    CountryID = (int)Reader["CountryID"];

                }

                else
                {
                    IsFound = false;

                }

                Reader.Close();


            }


            catch (Exception ex)
            {

                IsFound = false;
                throw new Exception("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }


        //////////////////////////////////////////////////////////////////////////

        public static bool GetCountryInfoByID( int CountryID, ref string CountryName)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;


                    CountryName = (string)Reader["CountryName"];

                }

                else
                {
                    IsFound = false;

                }

                Reader.Close();


            }


            catch (Exception ex)
            {

                IsFound = false;
                throw new Exception("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }


        //////////////////////////////////////////////////////////////////////////

    }
}