using System;
using System.Data;
using System.Data.SqlClient;


namespace Bank_DataLayer
{
    public class clsUserData
    {
        public static bool GetUserByID(int UserID, ref int EmployeeID, ref string Username, ref string PasswordHash, ref string Salt,
                                            ref bool Status, ref DateTime CreatedAt)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetUserByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        // Output parameters
                        SqlParameter isFound = new SqlParameter("@IsFound", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(isFound);


                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EmployeeID = (int)reader["EmployeeID"];
                                Username = (string)reader["Username"];
                                PasswordHash = (string)reader["PasswordHash"];
                                Salt = (string)reader["PasswordSalt"];
                                Status = (bool)reader["Status"];
                                CreatedAt = (DateTime)reader["CreatedAt"];

                                return true;
                            }
                        }

                        return false;
                    }
                }

            }
            catch 
            {
                return false;
            }

        }

        public static bool GetUserByEmployeeID(int EmployeeID, ref int UserID, ref string Username, ref string PasswordHash, ref string Salt,
                                            ref bool Status, ref DateTime CreatedAt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetUserByEmployeeID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        // Output parameters
                        SqlParameter isFound = new SqlParameter("@IsFound", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(isFound);


                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserID = (int)reader["UserID"];
                                Username = (string)reader["Username"];
                                PasswordHash = (string)reader["PasswordHash"];
                                Salt = (string)reader["PasswordSalt"];
                                Status = (bool)reader["Status"];
                                CreatedAt = (DateTime)reader["CreatedAt"];

                                return true;
                            }
                        }

                        return false;
                    }
                }

            }
            catch
            {
                return false;
            }

        }

        public static bool GetUserByUsername(string Username, ref int UserID, ref int EmployeeID, ref string PasswordHash, ref string Salt,
                                            ref bool Status, ref DateTime CreatedAt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetUserByUsername", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", Username);

                        // Output parameters
                        SqlParameter isFound = new SqlParameter("@IsFound", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(isFound);


                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserID = (int)reader["UserID"];
                                EmployeeID = (int)reader["EmployeeID"];
                                PasswordHash = (string)reader["PasswordHash"];
                                Salt = (string)reader["PasswordSalt"];
                                Status = (bool)reader["Status"];
                                CreatedAt = (DateTime)reader["CreatedAt"];

                                return true;
                            }
                        }

                        return false;
                    }
                }

            }
            catch
            {
                return false;
            }

        }
        public static int AddNewUser(int EmployeeID, string Username, string PasswordHash, string Salt)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                        command.Parameters.AddWithValue("@PasswordSalt", Salt);

                        SqlParameter outputID = new SqlParameter("@NewUserID", SqlDbType.Int)
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

        public static bool UpdateUser(int UserID, int EmployeeID, string Username, string PasswordHash, string Salt)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                        command.Parameters.AddWithValue("@PasswordSalt", Salt);

                        connection.Open();

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public static bool DeleteUser(int UserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();

                        return command.ExecuteNonQuery() > 0;
                    }
                }

            }
            catch
            {
                return false;
            }

        }

        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtUsers.Load(reader);
                        }
                    }
                }
            }
            catch
            {
                // Log the exception (you can use a logging framework or write to a file)
                // optionally log
            }

            return dtUsers;
        }

        public static bool CheckUsernameExists(string Username)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckUsernameExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", Username);

                        // Return value parameter
                        SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnValue);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return (int)returnValue.Value == 1;
                    }
                }
            }
            catch { return false; }
        }

        public static bool UpdateUserStatus(int UserID, bool Status)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = "USP_UpdateUserStatus";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Status", Status);

                        connection.Open();

                        int rowsAffected = (int)command.ExecuteScalar();

                        isUpdated = (rowsAffected > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                // log the exception if you have a logger
                isUpdated = false;
            }

            return isUpdated;
        }

        public static int GetTotalUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTotalUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter totalParam = new SqlParameter("@TotalUsers", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        command.Parameters.Add(totalParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return (int)totalParam.Value;
                    }
                }
            }
            catch { return 0; }
        }
        public static int GetTotalActiveUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTotalActiveUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter totalParam = new SqlParameter("@TotalActiveUsers", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        command.Parameters.Add(totalParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return (int)totalParam.Value;
                    }
                }
            }
            catch { return 0; }
        }

    } 
}
