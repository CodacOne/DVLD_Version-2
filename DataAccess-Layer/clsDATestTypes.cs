﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess_Layer
{
  public  class clsDATestTypes
    {

        public static DataTable GetAllTestTypes()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT * from TestTypes";


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
        public static bool GetTestTypeInfoByID(int TestTypeID,
           ref string TestTypeTitle, ref string TestDescription, ref float TestFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestDescription = (string)reader["TestTypeDescription"];
                    TestFees = Convert.ToSingle(reader["TestTypeFees"]);

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
                throw new Exception("Error : " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }

        public static bool UpdateTestType(int TestTypeID, string Title, string Description, float Fees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Update  TestTypes  
                            set TestTypeTitle = @TestTypeTitle,
                                TestTypeDescription=@TestTypeDescription,
                                TestTypeFees = @TestTypeFees
                                where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////


    }




}
