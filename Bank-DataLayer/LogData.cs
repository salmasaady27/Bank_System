using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsLogData
    {
        public static int AddNewLog(int UserID, int ActionTypeID, string Description)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@ActionTypeID", ActionTypeID);
                        command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

                        SqlParameter outputID = new SqlParameter("@NewLogID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputID);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return (int)outputID.Value;
                    }
                }
            }
            catch { return -1; }
        }

        public static DataTable GetAllLogs()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllLogs", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch { dt = new DataTable(); }

            return dt;
        }

        public static DataTable GetLogsByUserID(int UserID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllLogsByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch { dt = new DataTable(); }

            return dt;
        }
    }
}