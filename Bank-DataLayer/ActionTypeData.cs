using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsActionTypeData
    {
        public static DataTable GetAllActionTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllActionTypes", connection))
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

        public static bool GetActionTypeByID(int ActionTypeID, ref string ActionName,
                                                ref string Description, ref DateTime CreatedAt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetActionTypeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ActionTypeID", ActionTypeID);

                        SqlParameter outputIsFound = new SqlParameter("@IsFound", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIsFound);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ActionName = (string)reader["ActionName"];
                                Description = reader["Description"] == DBNull.Value
                                              ? "" : (string)reader["Description"];
                                CreatedAt = (DateTime)reader["CreatedAt"];
                            }
                        }

                        return (bool)outputIsFound.Value;
                    }
                }
            }
            catch { return false; }
        }
    }
}