using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Data;

namespace DataAccess_Layer
{
  public  class clsIssuingLicense
    {


        ////////////////////////////////////////////////////////////////
        ///
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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


            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

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
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

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



        ///////////////////////////////////////////////////////////////////////////////////////////////
        public static int AddNewLicense(
            int ApplicationID, int DriverID, int LicenseClass, int IssueReason,
            int PaidFees, int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, byte IsActive)
        {
            int newLicenseID = -1; // القيمة الافتراضية في حال الفشل

            using (SqlConnection connection = new SqlConnection(clsConnectionString.connectionString))
            {
                string query = @"
            INSERT INTO Licenses 
                (ApplicationID, DriverID, LicenseClass, IssueReason, PaidFees, CreatedByUserID, 
                 IssueDate, ExpirationDate, Notes, IsActive)
            VALUES 
                (@ApplicationID, @DriverID, @LicenseClass, @IssueReason, @PaidFees, @CreatedByUserID, 
                 @IssueDate, @ExpirationDate, @Notes, @IsActive);
                 
            SELECT SCOPE_IDENTITY()";

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

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        newLicenseID = id;
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error while adding license: " + ex.Message);
                }

            }

            return newLicenseID; // يرجع -1 إذا فشلت الإضافة
        }

        /*//*//************************************************//*/*//*/**//*/
       

          
        /////////////////////////////////////////////////////////////////////////////////////////////*/
        ///
        public static int GetApplicationIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)
        {
            bool IsFound = false;

           
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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


            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

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

            string query = @"
        SELECT 
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
        )
    ";

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
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

        /// //////////////////////////*****************************************/////////////////////////
        ///////////////////////////////////////////////////////////////////
        /// 
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, int IsActive, int CreatedByUserID)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"INSERT INTO InternationalLicenses 
                     (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                     VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int InternationalLicenseID = -1;

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    InternationalLicenseID = ID;
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

            return InternationalLicenseID;
        }

        /// //////////////////////////*****************************************/////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool CheckIfLicenseExistsInInternationalCertificates(int IssuedUsingLocalLicenseID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
                SELECT IssuedUsingLocalLicenseID 
                FROM InternationalLicenses 
                WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
            ";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

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
                throw new Exception("Database Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }


        /// //////////////////////////*****************************************/////////////////////////
        public static DataTable GetInternationalLicenseInfo(int LicenseID)
        {
            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
        SELECT TOP 1
            InternationalLicenses.InternationalLicenseID,
            InternationalLicenses.DriverID,
            InternationalLicenses.ApplicationID,
            InternationalLicenses.IssuedUsingLocalLicenseID,
            InternationalLicenses.IssueDate,
            InternationalLicenses.ExpirationDate,
            InternationalLicenses.IsActive,

            Licenses.LicenseID,

            People.PersonID,
            People.NationalNo,
            People.FirstName,
            People.SecondName,
            People.ThirdName,
            People.LastName,
            People.DateOfBirth,
            People.Gendor,
            People.ImagePath

        FROM Licenses
        INNER JOIN InternationalLicenses 
            ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
        INNER JOIN Drivers 
            ON Licenses.DriverID = Drivers.DriverID 
            AND InternationalLicenses.DriverID = Drivers.DriverID
        INNER JOIN People 
            ON Drivers.PersonID = People.PersonID
        WHERE Licenses.LicenseID = @LicenseID";

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
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Dt;
        }
        //////////////////////////*****************************************/////////////////////////
        /// <summary>
        /// 
        /// //////////////////////////*****************************************/////////////////////////
        public static DataTable GetInternationalLicenseInforDgv()
        {
            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
                       
                select InternationalLicenseID as [Int.LicenseID] ,
                ApplicationID  as [Application ID] ,
                DriverID as [Driver ID],
                 IssuedUsingLocalLicenseID as [L.License ID],
                 IssueDate as [Issue Date],
                 ExpirationDate as [Expiration Date],
                 IsActive as [Is Active] 
                 from InternationalLicenses
                ";

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
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Dt;
        }
        //////////////////////////*****************************************/////////////////////////

        /// //////////////////////////*****************************************/////////////////////////
        public static DataTable GetInternationalLicenseOfPersonForDgv(int ApplicationID)
        {
            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
                       
                select InternationalLicenseID as [Int.LicenseID] ,
                ApplicationID  as [Application ID] ,
                DriverID as [Driver ID],
                 IssuedUsingLocalLicenseID as [L.License ID],
                 IssueDate as [Issue Date],
                 ExpirationDate as [Expiration Date],
                 IsActive as [Is Active] 
                 from InternationalLicenses
                  where ApplicationID=@ApplicationID

                ";

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
        //////////////////////////*****************************************/////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static int GetLocalDrivingLicenseApplicationIDByApplicationID(int ApplicationID)
        {


            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
              SELECT LocalDrivingLicenseApplicationID FROM LocalDrivingLicenseApplications
                             where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            int LocalDrivingLicenseApplicationID = -1;

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    // IsFound = true;


                    LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);

                }

                else
                {
                    LocalDrivingLicenseApplicationID = -1;

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



            return LocalDrivingLicenseApplicationID;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool CheckIfLocalLicenseExistsAndAndLicenseClassWorth_3(int LicenseID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
                SELECT * 
                FROM Licenses 
                WHERE LicenseID = @LicenseID and LicenseClass=3
            ";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                throw new Exception("Database Error: " + ex.Message);
            }


            finally
            {
                Connection.Close();
            }

            return IsFound;
        }


        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*

        public static int GetPersonIDByDriverID(int DriverID)
        {


            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
              SELECT PersonID FROM Drivers
                             where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            int PersonID = -1;

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    // IsFound = true;


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
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }



            return PersonID;
        }


        //////////////////////////*****************************************/////////////////////////
        ///✅ هذه الدالة تتحقق مما إذا كانت رخصة معينة لا تزال سارية المفعول
      //  (أي أن تاريخ انتهاء صلاحيتها أكبر من تاريخ اليوم)

        public static bool IsLicenseValid(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"SELECT ExpirationDate FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool isValid = false;

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    DateTime expirationDate = Convert.ToDateTime(result);

                    // ✅ التحقق من أن تاريخ الانتهاء أكبر من تاريخ اليوم
                    if (expirationDate > DateTime.Now)
                    {
                        isValid = true;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error checking license validity: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return isValid;
        }

        /*/***********************************************************
       /// //////////////////////////*****************************************/////////////////////////
        public static DataTable GetAllLocalLicenseInfoForRenewLicense(int LicenseID)
        {
            DataTable Dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"select * from Licenses
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
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return Dt;
        }

        /////////////////////////////*****************************************/////////////////////////
        ///
        public static bool DisabledOldLicense(int OldLicenseID)

        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"Update Licenses 
                  set  IsActive=0
                      
                       where LicenseID=@OldLicenseID ";


            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@OldLicenseID", OldLicenseID);
            

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



        /////////////////////////////*****************************************/////////////////////////
        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);
                  string Query = @"
          SELECT InternationalLicenses.InternationalLicenseID,
          Applications.ApplicationID,
          LicenseClasses.ClassName,
          InternationalLicenses.IssueDate,
          InternationalLicenses.ExpirationDate,
          InternationalLicenses.IsActive
          
        FROM   Applications INNER JOIN
                     InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID INNER JOIN
                     People ON Applications.ApplicantPersonID = People.PersonID CROSS JOIN
                     LicenseClasses
               wHERE ApplicantPersonID=@ApplicationPersonID And LicenseClassID=3";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }

            catch (Exception ex)
            {
                //
            }
            finally {
                connection.Close();
            }
            return Dt;
        }

        //////////////////////////*****************************************/////////////////////////
        ///
        ///  /////////////////////////////////////////////////////////////////////////////////////////////*/
        ///
        public static int ValidationIfLicenseActiveOrNotActive(int LicenseID)
        {
            int IsActive = -1;

            
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

            string query = "SELECT * FROM Licenses " +
                "WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            


            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {


                    IsActive = Convert.ToSByte(Reader["IsActive"]);


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

            return IsActive;
        }


        /////////////////////////////*****************************************/////////////////////////
        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*
        
        public static bool IsLicenseDetainedOrNotDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

             string query = @"
         select * from  DetainedLicenses
         where LicenseID=@LicenseID And IsReleased=0
         ";
           
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

           

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsDetained = true;

                }

                else
                {
                    IsDetained = false;

                }

                Reader.Close();
            }

            catch (Exception ex)
            {
                IsDetained = false;
                throw new Exception("Error: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }



            return IsDetained;
        }

        //////////////////////////*****************************************/////////////////////////
        /////////////////////////////*****************************************/////////////////////////
        /*/*//*/*//*/*//*/*//*/*/////////////////////////////////////////////////////////*
        
        public static bool IsLicenseDisactivatedOrNotDisactivated(int LicenseID)
        {
            bool IsActive = false;
           
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
         select IsActive from  Licenses
         where LicenseID=@LicenseID
         ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);



            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {


                    IsActive = Convert.ToBoolean(Reader["IsActive"]);


                }



                Reader.Close();


            }


            catch (Exception ex)
            {


                throw new Exception("Error : " + ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return IsActive;
        }
        //////////////////////////*****************************************/////////////////////////

        //////////////////////////*****************************************/////////////////////////
        //////////////////////////*****************************************/////////////////////////
    }
}
