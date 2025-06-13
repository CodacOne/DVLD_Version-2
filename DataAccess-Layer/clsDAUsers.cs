using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace DataAccess_Layer
{
  public  class clsDAUsers
    {
        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        public static DataTable GetAllUsers()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT 
               Users.UserID,
               Users.PersonID,
               CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName) AS FullName,
               Users.UserName,
               Users.IsActive
           FROM Users
          INNER JOIN People ON Users.PersonID = People.PersonID";


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



        /// /**///*/*/*/*/*/*/////////////////*********************/////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName,
            ref string Password, ref byte IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    PersonID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : -1;
                    UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : "";
                    Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : "";
                    IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToByte(reader["IsActive"]) : (byte)0;


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

        ////////////////////////////////////////////////////////////////
        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
           ref int UserID, ref int PersonID, ref byte IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                   

                    isFound  = true;
                    UserID   =   reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : -1;
                    PersonID = reader["PersonID"] != DBNull.Value ? Convert.ToInt32(reader["PersonID"]) : -1;
                    UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : "";
                    Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : "";
                    IsActive = reader["IsActive"] != DBNull.Value ? Convert.ToByte(reader["IsActive"]) : (byte)0;


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
        ////////////////////////////////////////////////////////////////

        public static bool IsUserExistOrNot(int PersonID)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"select found=1 from Users 
                               where PersonID=@PersonID";


            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                IsFound = Reader.HasRows;


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



        ////////////////////////////////////////////////////////////////
        ///
        public static int AddNewUser( int PersonID, string UserName, string Password, Byte IsActive)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Insert into Users (PersonID,UserName,Password,IsActive) 
           Values (@PersonID,@UserName,@Password,@IsActive); 
            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

         
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);


   
                    int UserID = -1;
 
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    UserID = ID;
                }

            }


            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }


            finally
            {
                Connection.Close();
            }

            return UserID;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public static DataTable GeneralFilter(int TypeFilter, string Filter)
        {
            DataTable Dt = new DataTable();
            string query = "";
            SqlCommand command = new SqlCommand();

            switch (TypeFilter)
            {

                case 0: // UserID
                    query = @"SELECT U.UserID, U.PersonID, 
                             (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
                             U.UserName, U.IsActive
                      FROM Users U
                      JOIN People P ON P.PersonID = U.PersonID";

                    break;


                case 1: // UserID
                    query = @"SELECT U.UserID, U.PersonID, U.Password,
                             (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
                             U.UserName, U.IsActive
                      FROM Users U
                      JOIN People P ON P.PersonID = U.PersonID
                      WHERE U.UserID = @Filter";
                    command.Parameters.AddWithValue("@Filter", int.Parse(Filter));
                    break;

                case 2: // UserName
                    query = @"SELECT U.UserID, U.PersonID, 
                             (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
                             U.UserName, U.IsActive
                      FROM Users U
                      JOIN People P ON P.PersonID = U.PersonID
                      WHERE U.UserName LIKE @Filter";
                    command.Parameters.AddWithValue("@Filter", "%" + Filter + "%");
                    break;

                case 3: // PersonID
                    query = @"SELECT U.UserID, U.PersonID, 
                             (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
                             U.UserName, U.IsActive
                      FROM Users U
                      JOIN People P ON P.PersonID = U.PersonID
                      WHERE U.PersonID = @Filter";
                    command.Parameters.AddWithValue("@Filter", int.Parse(Filter));
                    break;

                case 4: // FullName
                    query = @"SELECT U.UserID, U.PersonID, 
                             (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
                             U.UserName, U.IsActive
                      FROM Users U
                      JOIN People P ON P.PersonID = U.PersonID
                      WHERE (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE @Filter";
                    command.Parameters.AddWithValue("@Filter", "%" + Filter + "%");
                    break;


                case 5: // IsActive
                    if (!byte.TryParse(Filter, out byte isActive))
                        return Dt; // أو return null; حسب المنطق في مشروعك
          
                          query = @"SELECT U.UserID, U.PersonID, 
                       (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
                       U.UserName, U.IsActive
                       FROM Users U
                       JOIN People P ON P.PersonID = U.PersonID
                       WHERE U.IsActive = @Filter";

                    command.Parameters.AddWithValue("@Filter", isActive);
                    break;


                default:
                    throw new ArgumentException("نوع الفلترة غير معروف");

            }

            using (SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString))
            {
                command.Connection = Connection;
                command.CommandText = query;

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
                    throw new Exception("Error: " + ex.Message);
                }
            }

            return Dt;
        }

       
        /////////////////////////////////////////////////////////////////////////////////////////////
        public static bool GetUserInfoByID(int PersonID, ref int UserID, ref string UserName,
          ref string Password, ref Byte IsActive)
        {
            bool IsFound = false;

           


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    UserID =Convert.ToInt32(Reader["UserID"]);
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = Convert.ToByte(Reader["IsActive"]);
                   
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


        /////////////////////////////////////////////////////////////////////////////////////////////
        public static int GetPersonIDByUserID(int UserID)
          
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT PersonID  FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {


                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                  

                }

                else
                {
                    PersonID = -1;

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

            return PersonID;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>



        public static bool UpdateUser(int PersonID, string UserName, string Password, Byte IsActive)

        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Update Users 
                  set  UserName=@UserName,
                       Password=@Password,
                       IsActive=@IsActive
                      
                       
                 where PersonID=@PersonID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
           
           
            try
            {
                Connection.Open();
                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    IsFound = true;

                }

                else
                {
                    return false;

                }


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

        ////////////////////////////////////////////////////////////////

        public static bool DeleteContactUser(int UserID)
        {
            // bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Delete Users 
                         where UserID=@UserID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                Connection.Open();
                int RowAffected = command.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    return true;

                }

                else
                {
                    return false;

                }


            }


            catch (Exception ex)
            {

               
                throw new Exception("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return false;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////*

        /**///*/*/*/*/*/*/////////////////*********************/////////////////////////////////


    }
}
