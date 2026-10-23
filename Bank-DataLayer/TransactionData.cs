using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsTransactionData
    {
        public static int AddNewTransaction(int AccountID, int TransactionTypeID, decimal Amount,
                                                string Note, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewTransaction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AccountID", AccountID);
                        command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Note", (object)Note ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputID = new SqlParameter("@NewTransactionID", SqlDbType.Int)
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
            catch (SqlException ex) { return -1; }
        }

        public static DataTable GetAllTransactions()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllTransactions", connection))
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

        public static bool GetTransactionByID(int TransactionID, ref int AccountID, ref int TransactionTypeID,
                                                ref decimal Amount, ref string Note, ref DateTime CreatedAt,
                                                ref int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTransactionByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransactionID", TransactionID);

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
                                TransactionTypeID = (int)reader["TransactionTypeID"];
                                Amount = (decimal)reader["Amount"];
                                Note = reader["Note"] == DBNull.Value
                                                    ? "" : (string)reader["Note"];
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

        public static DataTable GetAllTransactionsByAccountID(int AccountID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllTransactionsByAccountID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        return dt;
                    }
                }
            }
            catch { return new DataTable(); }
        }

        public static int CountTodayTransactions()
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("USP_CountTodayTransactions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    object result = command.ExecuteScalar();

                    return (result != null) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public static DataTable GetTodayTransactions()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTodayTransactions", connection))
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
    }
}