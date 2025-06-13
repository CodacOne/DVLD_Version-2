using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public  class clsDALocalDrivingApplication
    {

        /*/*//*//////////////////////////////////////////*/

        public static bool GetLocalDrivingLicenseApplicationInfoByID(
       int LocalDrivingLicenseApplicationID, ref int ApplicationID,
       ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);


            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];



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
        public static int AddNewLocalDrivingApplication(int ApplicationID, int LicenseClassID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Insert into LocalDrivingLicenseApplications (ApplicationID,LicenseClassID) 
           Values (@ApplicationID,@LicenseClassID); 
            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



            int LocalDrivingLicenseApplicationID = -1;
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    LocalDrivingLicenseApplicationID = ID;
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

            return LocalDrivingLicenseApplicationID;
        }




        /*//*//*//////////////////////////////////////////*/
        public static bool UpdateLocalDrivingLicenseApplication(
           int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Update  LocalDrivingLicenseApplications  
                            set ApplicationID = @ApplicationID,
                                LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);


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

        /*/*//*//////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////
        ///
          //////////////////////////////////////////////////////////////////////////////////////////////*/
        public static bool CheckIfThereIsAPreviousOpenRequest(int PersonID, int LicenseClassID)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"       SELECT      Applications.ApplicantPersonID, LocalDrivingLicenseApplications.LicenseClassID,
              Applications.ApplicationStatus
        FROM          Applications INNER JOIN
         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
		 where ApplicantPersonID= @PersonID and LicenseClassID= @LicenseClassID and  ApplicationStatus = 1
                 ";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                   
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

        /*//*//*//////////////////////////////////////////*/

        public static DataTable LicenseApplicationsFilter(int ColumnIndex, string Filter)
        {
            DataTable Dt = new DataTable();

            string query = @"
           SELECT 
            LDLA.LocalDrivingLicenseApplicationID AS [L.D.L AppID],
            LC.ClassName AS [Driving Class],
            P.NationalNo AS [NationalNo],
            (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS [FullName],
            A.ApplicationDate AS [Application Date],
        
            (
                SELECT COUNT(*) 
                FROM TestAppointments TA
                JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID
                WHERE 
                    TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                    AND T.TestResult = 1
            ) AS [Passed Tests],
        
            CASE 
                WHEN A.ApplicationStatus = 1 THEN 'New'
                WHEN A.ApplicationStatus = 2 THEN 'Cancelled'
                WHEN A.ApplicationStatus = 3 THEN 'Completed'
                ELSE 'Unknown'
            END AS [Status]
    
        FROM LocalDrivingLicenseApplications LDLA
        JOIN LicenseClasses LC ON LC.LicenseClassID = LDLA.LicenseClassID
        JOIN Applications A ON A.ApplicationID = LDLA.ApplicationID
        JOIN People P ON P.PersonID = A.ApplicantPersonID

        WHERE 
            (
                @ColumnIndex NOT IN (1, 2, 3, 4)
                OR
                (@ColumnIndex = 1 AND CAST(LDLA.LocalDrivingLicenseApplicationID AS VARCHAR) LIKE '%' + @Filter + '%') OR
                (@ColumnIndex = 2 AND P.NationalNo LIKE '%' + @Filter + '%') OR
                (@ColumnIndex = 3 AND (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE '%' + @Filter + '%') OR
               
                (@ColumnIndex = 4 AND 
                    CASE 
                        WHEN A.ApplicationStatus = 1 THEN 'New'
                        WHEN A.ApplicationStatus = 2 THEN 'Cancelled'
                        WHEN A.ApplicationStatus = 3 THEN 'Completed'
                        ELSE 'Unknown'
                    END LIKE '%' + @Filter + '%')
            )
    ";

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ColumnIndex", ColumnIndex);
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

        /*//*//*//////////////////////////////////////////*/
        ////////////////////////////////////////////////////////////////
        ///       
        public static int GetApplciationIDToCancel(int LocalDrivingLicenseApplicationID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT ApplicationID FROM LocalDrivingLicenseApplications
                             where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID  ";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);



            int ApplicationID = -1;

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {



                    ApplicationID = (int)Reader["ApplicationID"];
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

            return ApplicationID;
        }

        ///
        ////////////////////////////////////////////////////////////////

        public static bool CancelApplicationCompletly(int ApplicationID, int ApplicationStatus = 2)

        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"Update Applications 
                  set  ApplicationStatus=@ApplicationStatus
                    where ApplicationID=@ApplicationID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);



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


        /*//*//*//////////////////////////////////////////*/

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }


        /*//*//*//////////////////////////////////////////*/

        /*//*//*//////////////////////////////////////////*/


    }
}
