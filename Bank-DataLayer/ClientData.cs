using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_DataLayer
{
    public class clsClientData
    {
        public static bool GetClientInfoByID(int ClientID, ref int PersonID, ref string FirstName,
                                             ref string LastName, ref string NationalNo, ref char Gender,
                                             ref DateTime DateOfBirth, ref string Phone, ref string Email,
                                             ref DateTime CreatedAt, ref int CreatedByUserID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetClientByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ClientID", ClientID);

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
                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                NationalNo = (string)reader["NationalNo"];
                                Gender = ((string)reader["Gender"])[0];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                                CreatedAt = (DateTime)reader["CreatedAt"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                return true;
                            }
                        }

                        return false;
                    }
                }
            }
            catch { return false; }
        }

        public static bool GetClientInfoByNationalNo(string NationalNo, ref int ClientID, ref int PersonID,
                                                     ref string FirstName, ref string LastName, ref char Gender,
                                                     ref DateTime DateOfBirth, ref string Phone, ref string Email,
                                                     ref DateTime CreatedAt, ref int CreatedByUserID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetClientByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Gender = ((string)reader["Gender"])[0];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                                CreatedAt = (DateTime)reader["CreatedAt"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                return true;
                            }
                        }

                        return false;
                    }
                }
            }
            catch { return false; }
        }
        public static int AddNewClient(string FirstName, string LastName, string NationalNo,
                                        char Gender, DateTime DateOfBirth, string Phone, 
                                        string Email, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        SqlParameter outputID = new SqlParameter("@NewClientID", SqlDbType.Int)
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

        public static bool UpdateClient(int ClientID, int PersonID, string FirstName, string LastName,
                                            string NationalNo, char Gender, DateTime DateOfBirth, 
                                            string Phone, string Email, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_UpdateClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClientID", ClientID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }
        public static bool DeleteClient(int ClientID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_DeleteClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ClientID", ClientID);

                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public static DataTable GetAllClients()
        {
            DataTable dtClients = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllClients", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtClients.Load(reader);
                        }
                    }
                }
            }
            catch
            {
                // Log the exception (you can use a logging framework or write to a file)
                // optionally log
            }

            return dtClients;
        }

        public static bool CheckClientNationalNoExists(string NationalNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckClientNationalNoExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static bool CheckPersonIsAlreadyClient(int PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckPersonIsAlreadyClient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static int GetTotalClients()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetTotalClients", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter totalParam = new SqlParameter("@TotalClients", SqlDbType.Int)
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


    

