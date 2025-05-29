using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess_Layer
{
  public  class clsDAManageLocalDrivingApplication
    {
        /// <summary>
        /// 
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
        public static int FillDataToApplicationTable( int ApplicantPersonID, int ApplicationTypeID,
            int ApplicationStatus, DateTime ApplicationDate, float PaidFees, DateTime LastStatusDate,
            int CreatedByUserID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
           
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



        /////////////////////////////////////////////////////////////////////////////////////////////
        ///


        ////////////////////////////////////////////////////////////////
        public static int FillDataToLocalDrivingApplicationTable(int ApplicationID, int LicenseClassID)
              
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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



        /////////////////////////////////////////////////////////////////////////////////////////////
        ///
          /////////////////////////////////////////////////////////////////////////////////////////////
        public static bool CheckIfThereIsAPreviousOpenRequest(int PersonID, int LicenseClassID)
        {
            bool IsFound = false;


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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

        /*/*//*/*************************///////*///////////////////////////////
       

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


        ////////////////////////////////////////////////////////////////
        ///       
        public static int GetApplciationIDToCancel(int LocalDrivingLicenseApplicationID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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


            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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
          
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
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
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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
            

            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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
        public static bool ValidationIfExistSamelicenseClassOfSamePeople(String NationalNo,int LicenseClassID)
        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);
            
                 string query = @"SELECT 
                Applications.ApplicantPersonID, 
                People.NationalNo, 
                People.PersonID, 
                LicenseClasses.LicenseClassID, 
                LocalDrivingLicenseApplications.ApplicationID
            FROM Applications
            INNER JOIN LocalDrivingLicenseApplications 
                ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            INNER JOIN LicenseClasses 
                ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
            INNER JOIN People 
                ON Applications.ApplicantPersonID = People.PersonID
            WHERE People.NationalNo =@NationalNo
              AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
              ";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);


            bool IsFound = false;


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
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

        ///
        ////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////
        public static int GetLicenseIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

              string query = @"    SELECT  LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
            Licenses.LicenseID,
            Licenses.ApplicationID,
            Applications.ApplicationID AS Expr1,
            LocalDrivingLicenseApplications.ApplicationID AS Expr2
            
            FROM         LocalDrivingLicenseApplications INNER JOIN
                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                         Licenses ON Applications.ApplicationID = Licenses.ApplicationID
						 where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
          



            int LicenseID = -1;
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {



                    LicenseID = Convert.ToInt32(Reader["LicenseID"]);
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

            return LicenseID;
        }



        /////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        public static int GetPersonIDByLocalDrivingID(int LocalDrivingLicenseApplicationID)

        {
            SqlConnection Connection = new SqlConnection(clsConnectionString.connectionString);

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
