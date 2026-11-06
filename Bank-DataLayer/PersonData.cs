
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataLayer
{                                                       
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID,ref string FirstName, ref string LastName,
                                      ref char Gender, ref DateTime DateOfBirth, ref string Phone, ref string Email)

        {
            bool isFound = false;

            try 
            {
                using(SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    string query = "select * from people where PersonID = @PersonID";
            
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Gender = (char)reader["Gender"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Phone = (string)reader["Phone"];
                                Email = (string)reader["Email"];
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }

                }
            }
            catch //(Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            return isFound;
        }
        public static int AddNewPerson(string FirstName, string LastName,
                                        char Gender, DateTime DateOfBirth, string Phone,
                                       string Email)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int PersonID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    string query = @"Insert into People (FirstName,LastName,Gender,DateOfBirth,Phone,Email)
                                         values (@FirstName,@LastName,@Gender,@DateOfBirth,@Phone,@Email)
                                select SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                }
            }
            catch //(Exception ex) 
            {
                //Console.WriteLine("Error" + ex.Message);
            }
            return PersonID;
        }

        public static bool UpdatePerson(int ID, string FirstName, string LastName,
                                        char Gender, DateTime DateOfBirth, string Phone,
                                        string Email)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    string query = @"Update People
		                        set FirstName = @FirstName,
			                        LastName = @LastName,
			                        Gender = @Gender,
			                        DateOfBirth = @DateOfBirth,
			                        Phone = @Phone,
			                        Email = @Email
			                        where PersonID = @PersonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", ID);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Email", Email);

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }

            }

            catch //(Exception ex) 
            {
                return false;
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    string query = @"Delete people where PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(@query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch //(Exception ex)
            {
                //Console.WriteLine("Error" + ex.Message);
                return false;
            }
            
            return (rowsAffected > 0);
        }

        public static bool DoesEmailExist(string Email)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    string query = @"select Found=1 from people where Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", Email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }

            }
            catch //(Exception ex) 
            {
                isFound = false;
            }

            return isFound;
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
