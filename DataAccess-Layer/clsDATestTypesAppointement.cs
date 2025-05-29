using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace DataAccess_Layer
{
   public class clsDATestTypesAppointement
    {
        /*/*//*/*************************///////*///////////////////////////////


        public static DataTable VisionTestAppointement(int ApplicationID)
        {
            DataTable Dt = new DataTable();
            
                        string query = @"
                        SELECT 
                         TA.TestAppointmentID AS [Appointment ID],
                         TA.AppointmentDate,
                         TA.PaidFees,
                         TA.IsLocked
                     FROM 
                         Applications A
                     JOIN 
                         LocalDrivingLicenseApplications LDLA 
                         ON A.ApplicationID = LDLA.ApplicationID
                     JOIN 
                         TestAppointments TA 
                         ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                     WHERE 
                         A.ApplicationID =@ApplicationID ;
              
              ";

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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


        /////////////////////////////////////////////////////////////////////////////////////////////
        public static int CountVisionTestAppointement()
        {

            int Count = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT COUNT(*) FROM TestAppointments";

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

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


        ////////////////////////////////////////////////////////////////
        public static int AddNewAppointmentVision(int TestTypeID, int LocalDrivingLicenseApplicationID,
    DateTime AppointmentDate, float PaidFees, int CreatedByUserID, byte IsLocked, int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;

            string query = @"
        INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
        VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsConnectionString.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);

                if (RetakeTestApplicationID == -1)
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                else
                {
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                }


             //   command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        TestAppointmentID = id;
                    }

                }


                catch (Exception ex)
                {
                     throw new Exception("Error adding appointment: " + ex.Message);
                  

                }


            }

            return TestAppointmentID;
        }


        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static bool UpdateAppointmentVision(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
    DateTime AppointmentDate, float PaidFees, int CreatedByUserID, byte IsLocked, int RetakeTestApplicationID)
        {
            bool isUpdated = false;

            string query = @"UPDATE TestAppointments
                     SET TestTypeID = @TestTypeID,
                         LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                         AppointmentDate = @AppointmentDate,
                         PaidFees = @PaidFees,
                         CreatedByUserID = @CreatedByUserID,
                         IsLocked = @IsLocked,
                         RetakeTestApplicationID = @RetakeTestApplicationID
                     WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(clsConnectionString.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);

                if (RetakeTestApplicationID == -1)
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);


              //  command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    isUpdated = (rowsAffected > 0);
                }

                catch (Exception ex)
                {
                    throw new Exception("Error updating appointment: " + ex.Message);
                }


            }

            return isUpdated;
        }



        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static DateTime GetAppointmentDate(int TestAppointmentID)
        {
            DateTime appointmentDate = DateTime.MinValue;

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"SELECT AppointmentDate FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && DateTime.TryParse(result.ToString(), out DateTime parsedDate))
                {
                    appointmentDate = parsedDate;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return appointmentDate;
        }



        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static int GetTestAppointementIDToUpdate(int LocalDrivingLicenseApplicationID)
        {
           

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);
               
             string query = @"
               SELECT  
                   TestAppointmentID   FROM   TestAppointments
               WHERE 
                   LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            int TestID = -1;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    TestID = ID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }



            return TestID;
        }


        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


        public static bool UpdateAppointmentDate(int TestAppointmentID, DateTime NewAppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"UPDATE TestAppointments 
                     SET AppointmentDate = @NewAppointmentDate 
                     WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NewAppointmentDate", NewAppointmentDate);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
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
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static int AddNewTest(int TestAppointmentID, int CreatedByUserID ,byte TestResult, string Notes )
        {
            int TestID = -1;

            string query = @"
        INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
        VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
        SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    TestID = id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding test: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return TestID;
        }

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


        public static bool ChechIfTestAppointmentIsActiveOrNot(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select IsLocked from TestAppointments
                                    where TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            //   command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            bool isLocked = false;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                // التحقق إذا كانت النتيجة ليست فارغة أو NULL
                if (result != DBNull.Value)
                {
                    isLocked = Convert.ToBoolean(result);

                    
                }



            }


            catch (Exception ex)
            { isLocked = false;
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }


            return isLocked;
        }

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


        public static bool CancelTheAppointmentAfterPassingOrFailing(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);
            
            string query = @"UPDATE TestAppointments 
                     SET IsLocked = 1 
                     WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

          

            bool isUpdated = false;

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
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
               
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }


           
        }


        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


        public static int GetResultForTestIfPassingOrFailing(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select TestResult from Tests
                          where TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);



            int Result = -1;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                // التحقق إذا كانت النتيجة ليست فارغة أو NULL
                if (result != null && result != DBNull.Value)
                {
                    Result = Convert.ToInt32(result);
                }



            }


            catch (Exception ex)
            {
                Result = -1;
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }
                                  //  اذا رجع 1 معناها ناجح 
            return Result;

        }


        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*


    }

}
