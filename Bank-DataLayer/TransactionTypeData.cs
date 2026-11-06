using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsTransactionTypeData
    {
        public static DataTable GetAllTransactionTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllTransactionTypes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                            dt.Load(reader);
                    }
                }
            }
            catch { dt = new DataTable(); }

            return dt;
        }

        public static bool GetTransactionTypeByID(int TransactionTypeID, ref string TypeName, 
                                                    ref string Description, ref DateTime CreatedAt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTransactionTypeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

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
                                TypeName = (string)reader["TypeName"];
                                Description = reader["Description"] == DBNull.Value ? "" : (string)reader["Description"];

                                CreatedAt = (DateTime)reader["CreatedAt"];
                            }
                        }

                        return (bool)outputIsFound.Value;
                    }
                }
            }
            catch { return false; }
        }

        public static bool CheckTransactionTypeNameExists(string TypeName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckTransactionTypeNameExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TypeName", TypeName);

                        SqlParameter returnValue = new SqlParameter()
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnValue);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return ((int)returnValue.Value == 1);
                    }
                }
            }
            catch { return false; }
        }
    }
}