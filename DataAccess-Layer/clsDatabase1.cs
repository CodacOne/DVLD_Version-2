using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Data.SqlClient;
using DataAccess_Layer;



namespace DataAccess_Layer
{
    // class 
    public class clsDataAccess
    {


      public static DataTable GetAllPeople()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "select * from People ";
              

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


      
        ////////////////////////////////////////////////////////////////////////////////////////////////

        public static DataTable GetAllListCountries()
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select * from Countries ";


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


        //////////////////////////////////////////////////////////////////////////
        ///
          ////////////////////////////////////////////////////////////////

        public static bool IsNationalNumberExistOrNot(string NationalNo)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select found=1 from People 
                               where NationalNo=@NationalNo";


            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);


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
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath) 
           Values (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath); 
            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);


            if (string.IsNullOrWhiteSpace(ThirdName))
            {
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }


            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);


            if (string.IsNullOrWhiteSpace(Email))
            {
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Email", Email);
            }


            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (string.IsNullOrWhiteSpace(ImagePath))
            {
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }


            int PersonID = -1;
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    PersonID = ID;
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

            return PersonID;
        }



        /////////////////////////////////////////////////////////////////////////////////////////////
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref Byte Gendor, ref string Address,
            ref string Phone, ref string Email, ref int NationalityCountryID,
             ref string ImagePath)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                  
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    ThirdName = (string)Reader["ThirdName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    Gendor = (Byte)Reader["Gendor"];

                    NationalityCountryID = (int)Reader["NationalityCountryID"];   
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    ImagePath = Convert.ToString(Reader["ImagePath"]);
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

        ///////////////////////////////////////////////////////////////////////////////
    
        /// 


        /////////////////////////////////////////////////////////////////////////////////////////////
        public static bool GetPersonInfoByNationalNo(string NationalNo , ref int PersonID, ref string FirstName,
            ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref Byte Gendor, ref string Address,
            ref string Phone, ref string Email, ref int NationalityCountryID,
             ref string ImagePath)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    //  CountryID = (int)Reader["ContactID"];
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    ThirdName = (string)Reader["ThirdName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    Gendor = (Byte)Reader["Gendor"];

                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    ImagePath = Convert.ToString(Reader["ImagePath"]);
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

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
     


     
        public static bool UpdatePerson(int PersonID, string NationalNo,  string FirstName,
             string SecondName,  string ThirdName,
             string LastName,  DateTime DateOfBirth,  Byte Gendor,  string Address,
             string Phone,  string Email,  int NationalityCountryID,
              string ImagePath)

        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Update People 
                  set  NationalNo=@NationalNo,
                       FirstName=@FirstName,
                       SecondName=@SecondName,
                       ThirdName=@ThirdName,
                       LastName=@LastName,
                       DateOfBirth=@DateOfBirth,
                       Gendor=@Gendor,
                       Address=@Address,
                       Phone=@Phone,
                       Email=@Email,
                       NationalityCountryID=@NationalityCountryID,
                       ImagePath=@ImagePath
                 where PersonID=@PersonID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);


            if (string.IsNullOrWhiteSpace(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }



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
       



        /////////////////////////////////////////////////////////////////////////////////////////////
        public static int GetPeopleCount()
        {

            int Count = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT COUNT(*) FROM People";

            SqlCommand command = new SqlCommand(query, Connection);

   

            try
            {
                Connection.Open();

                object Result = command.ExecuteScalar();

                Count =Convert.ToInt32(Result);

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
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        ////////////////////////////////////////////////////////////////

        public static bool DeleteContactPerson(int PersonID)
        {
            // bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Delete People 
                         where PersonID=@PersonID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


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

                //    IsFound = false;
                Console.WriteLine("Error : " + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return false;
        }

        ////////////////////////////////////////////////////////////////

        //public static DataTable GeneralFilter(int TypeFilter, string Filter)
        //{
        //    DataTable Dt = new DataTable();
        //    string query = "";

        //    bool IsFound = false;

        //    SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
        //    SqlCommand command = null;


        //    //if (string.IsNullOrWhiteSpace(Filter))
        //    //    throw new ArgumentException("Filter cannot be null or empty.");


        //    if (TypeFilter == 1)
        //    {
        //         query = @"select * from People 
        //                 where PersonID=@Filter ";

        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);


        //    }

        //    if (TypeFilter == 2)
        //    {
        //         query = @"select * from People 
        //                 where NationalNo=@Filter ";

        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);

        //    }

        //    if (TypeFilter == 3)
        //    {
        //         query = @"select * from People 
        //                 where FirstName=@Filter ";
        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);
        //    }


        //    if (TypeFilter == 4)
        //    {
        //        query = @"select * from People 
        //                 where SecondName=@Filter ";
        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);
        //    }


        //    if (TypeFilter == 5)
        //    {
        //        query = @"select * from People 
        //                 where ThirdName=@Filter ";
        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);
        //    }



        //    if (TypeFilter == 6)
        //    {
        //        query = @"select * from People 
        //                 where LastName=@Filter ";
        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);
        //    }


        //    if (TypeFilter == 7)
        //    {
        //        //  int NationalityCountryID = Convert.ToInt32(Filter);

        //        if (!int.TryParse(Filter, out int NationalityCountryID))
        //            throw new ArgumentException("Invalid value: NationalityCountryID must be a valid integer.");



        //        query = @"select * from People 
        //                 where NationalityCountryID=@NationalityCountryID ";
        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
        //    }



        //    if (TypeFilter == 8)
        //    {
        //        if (!int.TryParse(Filter, out int Gendor))
        //            throw new ArgumentException("Invalid value: Gender must be a valid integer.");


        //        query = @"SELECT * FROM People 
        //      WHERE Gendor = @Gendor";

        //        command = new SqlCommand(query, Connection);
        //        command.Parameters.AddWithValue("@Gendor", Gendor);
        //    }


        //    if (TypeFilter == 9)
        //    {
        //        query = @"select * from People 
        //                 where Phone=@Filter ";

        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);

        //    }

        //    if (TypeFilter == 10)
        //    {
        //        query = @"select * from People 
        //                 where Email=@Filter ";

        //        command = new SqlCommand(query, Connection);

        //        command.Parameters.AddWithValue("@Filter", Filter);

        //    }



        //    try
        //    {
        //        Connection.Open();
        //        SqlDataReader Reader = command.ExecuteReader();

        //        if (Reader.HasRows)
        //        {
        //            Dt.Load(Reader);

        //        }

        //        Reader.Close();
        //    }


        //    catch (Exception ex)
        //    {


        //        throw new Exception("Error : " + ex.Message);
        //    }

        //    finally
        //    {
        //        Connection.Close();
        //    }

        //    return Dt;
        //}


        ////////////////////////////////////////////////////////////////////////////////////////////////

        //public static DataTable GeneralFilter(int TypeFilter, string Filter)
        //{
        //    DataTable Dt = new DataTable();
        //    string query = "";
        //    SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
        //    SqlCommand command;

        //    //if (string.IsNullOrWhiteSpace(Filter))
        //    //    throw new ArgumentException("Filter cannot be null or empty.");

        //    command = new SqlCommand();
        //    command.Connection = Connection;

        //    switch (TypeFilter)
        //    {
        //        case 1:
        //            query = "SELECT * FROM People WHERE PersonID = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 2:
        //            query = "SELECT * FROM People WHERE NationalNo = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 3:
        //            query = "SELECT * FROM People WHERE FirstName = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 4:
        //            query = "SELECT * FROM People WHERE SecondName = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 5:
        //            query = "SELECT * FROM People WHERE ThirdName = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 6:
        //            query = "SELECT * FROM People WHERE LastName = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 7:
        //            if (!int.TryParse(Filter, out int nationalityID))
        //                throw new ArgumentException("Invalid value: NationalityCountryID must be a valid integer.");
        //            query = "SELECT * FROM People WHERE NationalityCountryID = @Filter";
        //            command.Parameters.AddWithValue("@Filter", nationalityID);
        //            break;

        //        case 8:
        //            if (!int.TryParse(Filter, out int gender))
        //                throw new ArgumentException("Invalid value: Gender must be a valid integer.");
        //            query = "SELECT * FROM People WHERE Gendor = @Filter";
        //            command.Parameters.AddWithValue("@Filter", gender);
        //            break;

        //        case 9:
        //            query = "SELECT * FROM People WHERE Phone = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        case 10:
        //            query = "SELECT * FROM People WHERE Email = @Filter";
        //            command.Parameters.AddWithValue("@Filter", Filter);
        //            break;

        //        default:
        //            throw new ArgumentException("Invalid TypeFilter value.");
        //    }

        //    command.CommandText = query;

        //    try
        //    {
        //        Connection.Open();
        //        SqlDataReader Reader = command.ExecuteReader();

        //        if (Reader.HasRows)
        //        {
        //            Dt.Load(Reader);
        //        }

        //        Reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        Connection.Close();
        //    }

        //    return Dt;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>\\
        /// 




        /// ////////////////////////////////////////////////////////////////////////////////////////////////

        /// ////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public static DataTable GeneralFilter(int TypeFilter, string Filter)
        {
            DataTable Dt = new DataTable();
            string query = @"
        SELECT * FROM People
        WHERE 
            CASE 
                WHEN @TypeFilter = 1 THEN CAST(PersonID AS VARCHAR)
                WHEN @TypeFilter = 2 THEN NationalNo
                WHEN @TypeFilter = 3 THEN FirstName
                WHEN @TypeFilter = 4 THEN SecondName
                WHEN @TypeFilter = 5 THEN ThirdName
                WHEN @TypeFilter = 6 THEN LastName
                WHEN @TypeFilter = 7 THEN CAST(NationalityCountryID AS VARCHAR)
                WHEN @TypeFilter = 8 THEN CAST(Gendor AS VARCHAR)
                WHEN @TypeFilter = 9 THEN Phone
                WHEN @TypeFilter = 10 THEN Email
                ELSE NULL
            END = @Filter";

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
            SqlCommand command = new SqlCommand(query, Connection);

            // إضافة المعاملات للفلتر
            command.Parameters.AddWithValue("@TypeFilter", TypeFilter);
            command.Parameters.AddWithValue("@Filter", Filter);

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
            finally
            {
                Connection.Close();
            }

            return Dt;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////*
       


        // **//
       

        ////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////
        /**/

    }
}
