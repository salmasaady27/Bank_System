using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsTransferData
    {
        
        public static int AddNewTransfer(int SenderAccountID, int ReceiverAccountID,
                                            decimal Amount, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewTransfer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SenderAccountID", SenderAccountID);
                        command.Parameters.AddWithValue("@ReceiverAccountID", ReceiverAccountID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputID = new SqlParameter("@NewTransferID", SqlDbType.Int)
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

        public static DataTable GetAllTransfers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllTransfers", connection))
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

        public static bool GetTransferByID(int TransferID, ref int TransactionID, ref int SenderAccountID,
                                             ref int ReceiverAccountID, ref decimal Amount,
                                             ref DateTime CreatedAt, ref int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTransferByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TransferID", TransferID);

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
                                TransactionID = reader["TransactionID"] == DBNull.Value ? -1 : (int)reader["TransactionID"];
                                SenderAccountID = (int)reader["SenderAccountID"];
                                ReceiverAccountID = (int)reader["ReceiverAccountID"];
                                Amount = (decimal)reader["Amount"];
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

        public static DataTable GetAllTransfersByAccountID(int AccountID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllTransfersByAccountID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AccountID", AccountID);

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