using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess_Layer
{
  public  class clsDADetainAndRelease
    {

        /////////////////////////////*****************************************/////////////////////////

        /////////////////////////////*****************************************/////////////////////////
        public static int AddNewDetain(int LicenseID, DateTime DetainDate, int FineFees,
                       int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate,
                       int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"INSERT INTO DetainedLicenses 
            (LicenseID, DetainDate, FineFees, CreatedByUserID, 
             IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) 
            VALUES 
            (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 
             @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            // معالجة القيم التي يمكن أن تكون NULL
            if (ReleaseDate.HasValue)
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.Value);
            else
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);


            /**//**//**//**//**//**//**//**//**//**//**//**/
            if (ReleasedByUserID.HasValue)
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.Value);
            else
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value); // ✅ تصحيح الاسم هنا


            /**//**//**//**//**//**//**//**//**/

            if (ReleaseApplicationID.HasValue)
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.Value);
            else
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);


            /**//**//**//**//**//**//**//**//**/
                                            /**//**//**//**//**//**/
           
            int detainID = -1;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    detainID = id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding new detain record: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return detainID;
        }

        /////////////////////////////*****************************************/////////////////////////


        /////////////////////////////*****************************************/////////////////////////
        public static DataTable GetAllDetainInfoByLicenseID(int LicenseID)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);
            string Query = @"
          SELECT *  from DetainedLicenses
               wHERE LicenseID=@LicenseID ";
            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
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
            finally
            {
                connection.Close();
            }
            return Dt;
        }
        /////////////////////////////*****************************************/////////////////////////
      
   

        /////////////////////////////*****************************************/////////////////////////
        public static bool UpdateDetain(int DetainID, int LicenseID, DateTime DetainDate, int FineFees,
                                int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate,
                                int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
        UPDATE DetainedLicenses
        SET 
            LicenseID = @LicenseID,
            DetainDate = @DetainDate,
            FineFees = @FineFees,
            CreatedByUserID = @CreatedByUserID,
            IsReleased = @IsReleased,
            ReleaseDate = @ReleaseDate,
            ReleasedByUserID = @ReleasedByUserID,
            ReleaseApplicationID = @ReleaseApplicationID
        WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            // معالجة القيم التي يمكن أن تكون NULL
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.HasValue ? (object)ReleaseApplicationID.Value : DBNull.Value);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                isUpdated = (rowsAffected > 0);
            }

            catch (Exception ex)
            {
                isUpdated = false;
                throw new Exception("Error updating detain record: " + ex.Message);
            }


            finally
            {
                connection.Close();
            }

            return isUpdated;
        }


        public static bool UpdateDetain(int DetainID, bool IsReleased, DateTime? ReleaseDate,
        int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
    UPDATE DetainedLicenses
    SET 
        IsReleased = @IsReleased,
        ReleaseDate = @ReleaseDate,
        ReleasedByUserID = @ReleasedByUserID,
        ReleaseApplicationID = @ReleaseApplicationID
    WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate.HasValue ? (object)ReleaseDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID.HasValue ? (object)ReleasedByUserID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID.HasValue ? (object)ReleaseApplicationID.Value : DBNull.Value);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                isUpdated = (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw new Exception("Error updating detain record: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }


        /////////////////////////////*****************************************/////////////////////////
        public static DataTable GetAllInfoForListDetain_Dgv(int ColumnIndex, string Filter)
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionString.connectionString);

            string query = @"
       SELECT 
    DL.DetainID AS D_ID,
    DL.LicenseID AS L_ID,
    DL.DetainDate AS D_Date,
    DL.IsReleased AS Is_Released,
    DL.FineFees,
    DL.ReleaseDate AS Release_Date,
    P.PersonID AS Person_ID,
    P.NationalNo AS N_No,
           P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName AS FullName,
           DL.ReleaseApplicationID AS Release_App_ID
       FROM 
           dbo.DetainedLicenses AS DL
       INNER JOIN 
           dbo.Licenses AS L ON DL.LicenseID = L.LicenseID
       INNER JOIN 
           dbo.Applications AS A ON L.ApplicationID = A.ApplicationID
       INNER JOIN 
           dbo.People AS P ON P.PersonID = A.ApplicantPersonID
       WHERE 
    (@ColumnIndex = 0) OR
    (@ColumnIndex = 1 AND CAST(DL.DetainID AS VARCHAR) LIKE '%' + @Filter + '%') OR
    (@ColumnIndex = 2 AND CAST(DL.IsReleased AS VARCHAR) LIKE '%' + @Filter + '%') OR
    (@ColumnIndex = 3 AND P.NationalNo LIKE '%' + @Filter + '%') OR
    (@ColumnIndex = 4 AND (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName) LIKE '%' + @Filter + '%') OR
    (@ColumnIndex = 5 AND CAST(DL.ReleaseApplicationID AS VARCHAR) LIKE '%' + @Filter + '%')";


            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@ColumnIndex", ColumnIndex);
            Command.Parameters.AddWithValue("@Filter", Filter);

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
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Dt;
        }


        /////////////////////////////*****************************************/////////////////////////




        ///
        /////////////////////////////*****************************************/////////////////////////
        /////////////////////////////*****************************************/////////////////////////
    }



}
