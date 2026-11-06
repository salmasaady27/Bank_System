using System;
using System.Data;
using System.Data.SqlClient;


namespace Bank_DataLayer
{
    public class clsEmployeeData
    {
        public static bool GetEmployeeInfoByID(int EmployeeID, ref int PersonID, ref string FirstName, ref string LastName, ref string NationalNo,
                                            ref char Gender, ref DateTime DateOfBirth, ref string Phone,
                                            ref string Email, ref string JobTitle, ref DateTime HireDate,
                                             ref bool Status, ref DateTime CreatedAt, ref int CreatedByUserID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetEmployeeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        // Output
                        SqlParameter outputID = new SqlParameter("@IsFound", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                FirstName = reader["FirstName"].ToString();
                                LastName = reader["LastName"].ToString();
                                NationalNo = reader["NationalNo"].ToString();
                                Gender = reader["Gender"].ToString()[0];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = reader["Phone"].ToString();
                                JobTitle = reader["JobTitle"].ToString();
                                HireDate = (DateTime)reader["HireDate"];
                                Status = (bool)reader["Status"];
                                CreatedAt = (DateTime)reader["CreatedAt"];

                                // Handle Null Value
                                CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? (int)reader["CreatedByUserID"] : -1;
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null;

                                return true;
                            }

                        }
                        return false;
                    }
                }
            }

            catch { return false; }

        }

        public static int AddNewEmployee(string FirstName, string LastName, string NationalNo,
                                            char Gender, DateTime DateOfBirth, string Phone,
                                            string Email, string JobTitle, DateTime HireDate, bool Status, DateTime CreatedAt,
                                             int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_AddNewEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Person Parameters
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);

                        // Employee Parameters
                        command.Parameters.AddWithValue("@JobTitle", JobTitle);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        //command.Parameters.AddWithValue("@Status", Status);
                        //command.Parameters.AddWithValue("@CreatedAt",CreatedAt);
                        command.Parameters.AddWithValue("@CreatedByUserID",
                            CreatedByUserID == -1 ? (object)DBNull.Value : CreatedByUserID);


                        SqlParameter outputID = new SqlParameter("@NewEmployeeID", SqlDbType.Int)
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

        public static bool UpdateEmployee(int EmployeeID, int PersonID, string FirstName, string LastName, string NationalNo,
                                            char Gender, DateTime DateOfBirth, string Phone,
                                            string Email, string JobTitle, DateTime HireDate,
                                            bool Status, DateTime CreatedAt, int CreatedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_UpdateEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Person Parameters
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);

                        // Employee Parameters

                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@JobTitle", JobTitle);
                        command.Parameters.AddWithValue("@HireDate", HireDate);
                        //command.Parameters.AddWithValue("@Status", Status);
                        //command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        connection.Open();

                        return command.ExecuteNonQuery() > 0;
                    }
                }

            }
            catch { return false; }

        }

        public static bool DeleteEmployee(int EmployeeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_DeleteEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        connection.Open();

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            
            catch { return false; }
            
        }

        public static DataTable GetAllEmployees()
        {
            DataTable dtEmployees = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_GetAllEmployees", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dtEmployees.Load(reader);
                        }
                    }
                }
            }
            catch
            {
                // Log the exception (you can use a logging framework or write to a file)
                // optionally log
            }

            return dtEmployees;
        }

        public static bool CheckNationalNoExists(string NationalNo)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("USP_CheckNationalNoExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        
                        // Return value parameter
                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return (int)returnValue.Value == 1;
                    }
                }
            }

            catch { return false; }

        }
    }
}
