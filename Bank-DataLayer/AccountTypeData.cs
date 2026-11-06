using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsAccountTypeData
    {
        public static DataTable GetAllAccountTypes()
        {
            DataTable dt = new DataTable();

            try 
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllAccountTypes", connection)) 
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

        public static bool GetAccountTypeByID(int AccountTypeID, ref string TypeName,
                                                ref string Description, ref DateTime CreatedAt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAccountTypeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

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


        public static bool GetAccountTypeByName(string TypeName, ref int AccountTypeID,
                                                ref string Description, ref DateTime CreatedAt)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("USP_GetAccountTypeByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TypeName", TypeName);

                SqlParameter isFoundParam = new SqlParameter("@IsFound", SqlDbType.Bit);
                isFoundParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(isFoundParam);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        AccountTypeID = (int)reader["AccountTypeID"];
                        Description = reader["Description"] == DBNull.Value ? "" : (string)reader["Description"];
                        CreatedAt = (DateTime)reader["CreatedAt"];
                    }
                }

                return (bool)command.Parameters["@IsFound"].Value;
            }
        }
        public static bool CheckAccountTypeNameExists(string TypeName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckAccountTypeNameExists", connection))
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
