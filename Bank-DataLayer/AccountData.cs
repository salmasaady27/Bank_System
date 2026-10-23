using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsAccountData
    {
        public static bool GetAccountByID(int AccountID, ref string AccountNumber, ref int ClientID,
                                             ref int AccountTypeID, ref decimal Balance, ref bool Status,
                                             ref DateTime CreatedAt, ref int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAccountByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);

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
                                ClientID = (int)reader["ClientID"];
                                AccountTypeID = (int)reader["AccountTypeID"];
                                AccountNumber = (string)reader["AccountNumber"];
                                Balance = (decimal)reader["Balance"];
                                Status = (bool)reader["Status"];
                                CreatedAt = (DateTime)reader["CreatedAt"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }

                        return (bool)outputIsFound.Value;
                    }
                }
            }
            catch { return false; }
        }

        public static bool GetAccountByAccountNumber(string AccountNumber, ref int AccountID, ref int ClientID, 
                                                ref int AccountTypeID, ref decimal Balance, ref bool Status,
                                                ref DateTime CreatedAt, ref int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAccountByAccountNumber", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

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
                                AccountID = (int)reader["AccountID"];
                                ClientID = (int)reader["ClientID"];
                                AccountTypeID = (int)reader["AccountTypeID"];
                                Balance = (decimal)reader["Balance"];
                                Status = (bool)reader["Status"];
                                CreatedAt = (DateTime)reader["CreatedAt"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                            }
                        }

                        return (bool)outputIsFound.Value;
                    }
                }
            }
            catch { return false; }
        }

        public static int AddNewAccount(int ClientID, int AccountTypeID,
            decimal Balance, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewAccount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", ClientID);
                        command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                        command.Parameters.AddWithValue("@Balance", Balance);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputID = new SqlParameter("@NewAccountID", SqlDbType.Int)
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

        
        public static bool UpdateAccount(int AccountID, int AccountTypeID,
            decimal Balance, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_UpdateAccount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
                        command.Parameters.AddWithValue("@Balance", Balance);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();
                        return (command.ExecuteNonQuery() > 0);
                    }
                }
            }
            catch { return false; }
        }

        public static bool DeleteAccount(int AccountID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_DeleteAccount", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);

                        connection.Open();
                        return (command.ExecuteNonQuery() > 0);
                    }
                }
            }
            catch { return false; }
        }

        public static DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllAccounts", connection))
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

        public static bool UpdateAccountStatusByID(int AccountID, bool Status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_UpdateAccountStatusByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@Status", Status);

                        connection.Open();
                        return ((int)command.ExecuteScalar() > 0);
                    }
                }
            }
            catch { return false; }
        }

        public static bool UpdateAccountStatusByAccountNumber(string AccountNumber, bool Status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_UpdateAccountStatusByAccountNumber", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        command.Parameters.AddWithValue("@Status", Status);

                        connection.Open();
                        return ((int)command.ExecuteScalar() > 0);
                    }
                }
            }
            catch { return false; }
        }

        public static bool CheckAccountNumberExists(string AccountNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckAccountNumberExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

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

        public static bool CheckClientHasAccountType(int ClientID, int AccountTypeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckClientHasAccountType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ClientID", ClientID);
                        command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);

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

        public static int GetTotalAccounts()
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTotalAccounts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter totalParam = new SqlParameter("@TotalAccounts", SqlDbType.Int)
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