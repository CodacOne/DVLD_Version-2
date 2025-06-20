using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess_Layer
{
  public  class clsDAApplication
    {
        /// <summary>
        public static bool GetApplicationInfoByID(int ApplicationID,
          ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
          ref byte ApplicationStatus, ref DateTime LastStatusDate,
          ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];


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


        //     public static DataTable GetAllLocalDrivingApplication()
        //     {

        //         DataTable Dt = new DataTable();

        //         SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

        //         string query = @"select LDLA.LocalDrivingLicenseApplicationID as [L.D.L AppID],LC.ClassName as [Driving Class]
        //       ,P.NationalNo as [NationalNo],(P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName + ' ' ) as [FullName]
        // ,A.ApplicationDate as [Application Date],

        //      	  (
        //        SELECT COUNT(*) 
        //        FROM TestAppointments TA
        //        JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
        //        WHERE 
        //            TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
        //            AND T.TestResult = 1
        //         ) AS [Passed Tests],



        // case 
        //when A.ApplicationStatus =1 then 'New'
        // when A.ApplicationStatus =2 then 'Cancelled '
        //  when A.ApplicationStatus =3 then 'Completed'
        //   ELSE 'Unknown'
        //  end as [Status]


        // from
        // LocalDrivingLicenseApplications LDLA 

        // join
        // LicenseClasses LC on LC.LicenseClassID=LDLA.LicenseClassID 

        //  join
        // Applications A on A.ApplicationID = LDLA.ApplicationID 
        //  join 
        // People P  on P.PersonID = A.ApplicantPersonID";


        //         SqlCommand command = new SqlCommand(query, Connection);


        //         try
        //         {
        //             Connection.Open();
        //             SqlDataReader Reader = command.ExecuteReader();

        //             if (Reader.HasRows)
        //             {
        //                 Dt.Load(Reader);

        //             }

        //             Reader.Close();
        //         }


        //         catch (Exception ex)
        //         {


        //             throw new Exception("Error : " + ex.Message);
        //         }

        //         finally
        //         {
        //             Connection.Close();
        //         }

        //         return Dt;
        //     }
        ////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////
        public static int AddNewApplication( int ApplicantPersonID, int ApplicationTypeID,
            byte ApplicationStatus, DateTime ApplicationDate, float PaidFees, DateTime LastStatusDate,
            int CreatedByUserID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);
           
            string query = @"Insert into Applications (ApplicantPersonID,ApplicationTypeID,ApplicationStatus,
                  ApplicationDate , PaidFees ,LastStatusDate ,CreatedByUserID) 
           Values (@ApplicantPersonID,@ApplicationTypeID,@ApplicationStatus,
              @ApplicationDate,@PaidFees,@LastStatusDate,@CreatedByUserID); 
            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

          
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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
        

        /*/*//*/*************************///////*///////////////////////////////
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
             byte ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Update  Applications  
                            set ApplicantPersonID = @ApplicantPersonID,
                                ApplicationDate = @ApplicationDate,
                                ApplicationTypeID = @ApplicationTypeID,
                                ApplicationStatus = @ApplicationStatus, 
                                LastStatusDate = @LastStatusDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID=@CreatedByUserID
                            where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("ApplicantPersonID", @ApplicantPersonID);
            command.Parameters.AddWithValue("ApplicationDate", @ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", @ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", @ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", @LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", @PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", @CreatedByUserID);


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

        public static bool DeleteApplication(int ApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Delete Applications 
                                where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT Found=1 FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        /*/*//*/*************************///////*///////////////////////////////


        public static DataTable GetAllDataToSchedulingTest(int LocalDrivingLicenseApplicationID)
        {
            DataTable Dt = new DataTable();

                     string query = @"
                SELECT 
             a.ApplicationID,
             a.ApplicationDate,
             a.ApplicationStatus,
             a.ApplicationTypeID AS AppTypeID,
             a.LastStatusDate,
             a.PaidFees,
             a.CreatedByUserID,
          
             at.ApplicationTypeTitle,
             at.ApplicationTypeID AS TypeID,
                   
              ldla.LocalDrivingLicenseApplicationID,
              ldla.ApplicationID AS LDLA_AppID,
              ldla.LicenseClassID AS LDLA_ClassID,
          
              lc.ClassName,
              lc.LicenseClassID,
          
              p.PersonID,
              p.FirstName,
              p.SecondName,
              p.ThirdName,
              p.LastName,
          
              u.UserID,
              u.UserName,

            (
        SELECT COUNT(*) 
        FROM TestAppointments TA
        JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
        WHERE 
            TA.LocalDrivingLicenseApplicationID = ldla.LocalDrivingLicenseApplicationID
            AND T.TestResult = 1
         ) AS [PassedTests]

          FROM Applications a
          INNER JOIN ApplicationTypes at ON a.ApplicationTypeID = at.ApplicationTypeID
          INNER JOIN LocalDrivingLicenseApplications ldla ON a.ApplicationID = ldla.ApplicationID
          INNER JOIN LicenseClasses lc ON ldla.LicenseClassID = lc.LicenseClassID
          INNER JOIN People p ON a.ApplicantPersonID = p.PersonID
          JOIN Users u ON a.CreatedByUserID = u.UserID
          
          
          WHERE ldla.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
              ";
          
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
         

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

        ////////////////////////////////////////////////////////////////
        public static int GetAllTestsFees(int TestTypeID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"select TestTypeFees from TestTypes
                                where TestTypeID=@TestTypeID ";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            int TestTypeFees = -1;

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    TestTypeFees = Convert.ToInt32(Reader["TestTypeFees"]);
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

            return TestTypeFees;
        }

        ///
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////

        public static bool DeleteLocalDriving(int LocalDrivingLicenseApplicationID)
        {
            // bool IsFound = false;
            

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Delete LocalDrivingLicenseApplications 
                         where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


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
        ////////////////////////////////////////////////////////////////
        ///       
      
        ////////////////////////////////////////////////////////////////
      
        /////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        public static int GetPersonIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

             string query = @"   SELECT        People.PersonID,
         LocalDrivingLicenseApplications.ApplicationID,
         LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
         Applications.ApplicationID AS Expr1
         
         FROM            Applications INNER JOIN
            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
            People ON Applications.ApplicantPersonID = People.PersonID
		where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);




            int PersonID = -1;
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    PersonID = Convert.ToInt32(Reader["PersonID"]);
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
        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////
    }



}
