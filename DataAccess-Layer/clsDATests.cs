using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess_Layer
{
    public class clsDATests
    {

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
    (int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
      ref int TestAppointmentID, ref bool TestResult,
      ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT  top 1 Tests.TestID, 
         Tests.TestAppointmentID, Tests.TestResult, 
		    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
         FROM            LocalDrivingLicenseApplications INNER JOIN
                                  Tests INNER JOIN
                                  TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                  Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
         WHERE        (Applications.ApplicantPersonID = @PersonID) 
                 AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                 AND ( TestAppointments.TestTypeID=@TestTypeID)
         ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

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
    }
}
