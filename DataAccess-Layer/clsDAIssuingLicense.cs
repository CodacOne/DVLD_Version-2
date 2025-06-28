using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Data;

namespace DataAccess_Layer
{
  public  class clsDAIssuingLicense
    {


        ////////////////////////////////////////////////////////////////
        ///
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"DECLARE @DriverID INT;
                    
                    IF EXISTS (
                        SELECT 1 FROM Drivers WHERE PersonID = @PersonID )
                    BEGIN 
                        SELECT @DriverID = DriverID FROM Drivers WHERE PersonID = @PersonID;
                    END
                    ELSE 
                    BEGIN
                        INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                        VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                    
                        SET @DriverID = SCOPE_IDENTITY();
                    END
                    
                    SELECT @DriverID AS DriverID;
                    ";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
          



            int DriverID = -1;

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    DriverID = ID;
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

            return DriverID;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*
      
        public static int GetFeesOfLicenseClassTable(int LicenseClassID)
        {


            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"
               SELECT  
                   ClassFees   FROM   LicenseClasses
               WHERE 
                   LicenseClassID =@LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int ClassFees = -1;

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    // IsFound = true;


                    ClassFees = Convert.ToInt32(Reader["ClassFees"]);

                }

                else
                {
                    ClassFees = -1;

                }

                Reader.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }



            return ClassFees;
        }
        

        ///////////////////////////////////////////////////////////////////////////////////////////////

        public static bool InsertLicense(
    int ApplicationID, int DriverID, int LicenseClass, int IssueReason,
    int PaidFees, int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate,
    string Notes, byte IsActive)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"
        INSERT INTO Licenses 
        (ApplicationID, DriverID, LicenseClass, IssueReason, PaidFees, CreatedByUserID, 
         IssueDate, ExpirationDate, Notes, IsActive)
        VALUES 
        (@ApplicationID, @DriverID, @LicenseClass, @IssueReason, @PaidFees, @CreatedByUserID, 
         @IssueDate, @ExpirationDate, @Notes, @IsActive);";

            SqlCommand command = new SqlCommand(query, connection);

           
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            bool isSuccess = false;

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }



      
          
        /////////////////////////////////////////////////////////////////////////////////////////////*/
        ///
        public static int GetApplicationIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)
        {
            bool IsFound = false;

           
            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = "SELECT ApplicationID FROM LocalDrivingLicenseApplications " +
                "WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            int ApplicationID = -1;


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                  
                   
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

            return ApplicationID;
        }


        //////////////////////////*****************************************/////////////////////////

        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        public static DataTable GetAllDriverInfo(int LicenseID)
        {
            
            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT 
                 Licenses.LicenseID AS [LicID],
                 Licenses.ApplicationID AS [AppID],
                 LicenseClasses.ClassName AS [ClassName],
                 Licenses.IssueDate,
                 Licenses.ExpirationDate,
                 Licenses.IsActive,
             
                 -- باقي الأعمدة الإضافية (للاستخدامات الأخرى أو العرض في التفاصيل):
                 People.PersonID,
                 People.NationalNo,
                 People.FirstName,
                 People.SecondName,
                 People.ThirdName,
                 People.LastName,
                 People.Gendor,
                 People.DateOfBirth,
                 People.ImagePath,
                 
                 Licenses.DriverID,
                 Licenses.Notes,
                 Licenses.IssueReason,
             
                 LicenseClasses.LicenseClassID,
                 Drivers.DriverID AS Expr1
             
             FROM Licenses
             INNER JOIN LicenseClasses 
                 ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
             INNER JOIN Applications 
                 ON Licenses.ApplicationID = Applications.ApplicationID
             INNER JOIN People 
                 ON Applications.ApplicantPersonID = People.PersonID
             INNER JOIN Drivers 
                 ON Licenses.DriverID = Drivers.DriverID 
                 AND People.PersonID = Drivers.PersonID
             	where LicenseID=@LicenseID";
             

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        /// <summary>
        /// 
        public static DataTable GetAllLicenseToThePersonForDgv(int PersonID)
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

                 string query = @"  SELECT Licenses.LicenseID,
          Applications.ApplicationID,
          LicenseClasses.ClassName, Licenses.IssueDate, 
          Licenses.ExpirationDate, 
          Licenses.IsActive
          FROM   Applications INNER JOIN
          Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
          
          LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN
          
          LocalDrivingLicenseApplications ON
          
          Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID AND LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID INNER JOIN
          
          People ON Applications.ApplicantPersonID = People.PersonID
          
          
          Where PersonID = @PersonID";
          
          
            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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
        ///
      

        ////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        public static DataTable GetDriverInfoOnlyForDgv(int LicenseID)
        {

            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT 
                 Licenses.LicenseID AS [Lic ID],
                 Licenses.ApplicationID AS [App ID],
                 LicenseClasses.ClassName AS [Class Name],
                 Licenses.IssueDate,
                 Licenses.ExpirationDate,
                 Licenses.IsActive
             
                FROM Licenses
                INNER JOIN LicenseClasses 
                    ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                INNER JOIN Applications 
                    ON Licenses.ApplicationID = Applications.ApplicationID
                INNER JOIN People 
                    ON Applications.ApplicantPersonID = People.PersonID
                INNER JOIN Drivers 
                    ON Licenses.DriverID = Drivers.DriverID 
                    AND People.PersonID = Drivers.PersonID
                	where LicenseID=@LicenseID";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
        /// //////////////////////////*****************************************/////////////////////////

        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static bool ValidateIfLicenseExistOrNOT(int ApplicationID)

        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"select  * from Licenses
                  where  ApplicationID=@ApplicationID
                      ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
           

         
            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
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

        //////////////////////////*****************************************/////////////////////////

        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static int GetLicenseIDByApplicatinID(int ApplicationID)
        {


            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"
               SELECT  
                   LicenseID   FROM   Licenses
               WHERE 
                   ApplicationID =@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            int LicenseID = -1;

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    // IsFound = true;


                    LicenseID = Convert.ToInt32(Reader["LicenseID"]);

                }

                else
                {
                    LicenseID = -1;

                }

                Reader.Close();
            }

            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }



            return LicenseID;
        }



        //////////////////////////*****************************************/////////////////////////
        public static DataTable DriversWithLicensesFilter(int ColumnIndex, string Filter)
        {
            DataTable Dt = new DataTable();

            /* SELECT 
            D.DriverID,
            D.PersonID,
            P.NationalNo,
            (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) AS FullName,
            L.IssueDate AS [Date],
            L.IsActive AS ActiveLicense
        FROM Drivers D
        INNER JOIN Licenses L ON D.DriverID = L.DriverID
        INNER JOIN People P ON D.PersonID = P.PersonID
        WHERE 
            (
            @ColumnIndex NOT IN (1, 2, 3, 4, 5)
            OR (@ColumnIndex = 1 AND CAST(D.DriverID AS VARCHAR) LIKE '%' + @Filter + '%')
            OR (@ColumnIndex = 2 AND CAST(D.PersonID AS VARCHAR) LIKE '%' + @Filter + '%')
            OR (@ColumnIndex = 3 AND P.NationalNo LIKE '%' + @Filter + '%')
            OR (@ColumnIndex = 4 AND (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE '%' + @Filter + '%')
            OR (@ColumnIndex = 5 AND 
                CASE 
                    WHEN L.IsActive = 1 THEN 'True'
                    WHEN L.IsActive = 0 THEN 'False'
                    ELSE 'Unknown'
                END LIKE '%' + @Filter + '%')
        )*/
               string query = @"SELECT * 
             FROM Drivers_View
             WHERE 
                 @ColumnIndex = 0
                 OR (@ColumnIndex = 1 AND CAST(DriverID AS VARCHAR) LIKE '%' + @Filter + '%')
                 OR (@ColumnIndex = 2 AND CAST(PersonID AS VARCHAR) LIKE '%' + @Filter + '%')
                 OR (@ColumnIndex = 3 AND NationalNo LIKE '%' + @Filter + '%')
                 OR (@ColumnIndex = 4 AND FullName LIKE '%' + @Filter + '%')
             ORDER BY FullName;

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

      
       //////////////////////*****************************************/////////////////////////
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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


            return LicenseID;
        }



        //////////////////////////*****************************************/////////////////////////
        //////////////////////////*****************************************/////////////////////////
    }
}
