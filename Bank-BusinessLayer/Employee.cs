using Bank_DataLayer;
using System;
using System.Data;
using System.Security.Policy;


namespace Bank_BusinessLayer
{
    public class clsEmployee : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int EmployeeID { get; set; }

        public string JobTitle { get; set; }

        public DateTime HireDate { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedByUserID { get; set; }


        public clsEmployee()
        {
            this.EmployeeID = -1;
            this.JobTitle = "";
            this.HireDate = DateTime.Now;
            this.Status = true;
            this.CreatedAt = DateTime.Now;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsEmployee(int EmployeeID, int PersonID, string FirstName, string LastName, string NationalNo,
                                char Gender, DateTime DateOfBirth, string Phone, string Email,
                                string JobTitle, DateTime HireDate, bool Status,
                                DateTime CreatedAt, int CreatedByUserID) : base(PersonID, FirstName, LastName, NationalNo, Gender, DateOfBirth, Phone, Email)

        {
            this.EmployeeID = EmployeeID;
            this.JobTitle = JobTitle;
            this.HireDate = HireDate;
            this.Status = Status;
            this.CreatedAt = CreatedAt;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }
        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeData.AddNewEmployee(this.FirstName, this.LastName, this.NationalNo,
                                            this.Gender, this.DateOfBirth, this.Phone, this.Email, this.JobTitle,
                                            this.HireDate, this.Status, this.CreatedAt, this.CreatedByUserID);
            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(this.EmployeeID, this.PersonID, this.FirstName, this.LastName, this.NationalNo,
                                            this.Gender, this.DateOfBirth, this.Phone, this.Email, this.JobTitle,
                                            this.HireDate, this.Status, this.CreatedAt, this.CreatedByUserID);
        }

        public static clsEmployee Find(int EmployeeID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            string FirstName = "", LastName = "", NationalNo = "", Phone = "", Email = "", JobTitle = "";
            DateTime DateOfBirth = DateTime.Now, HireDate = DateTime.Now, CreatedAt = DateTime.Now;
            char Gender = 'M';
            bool Status = true;

            if (clsEmployeeData.GetEmployeeInfoByID(EmployeeID, ref PersonID, ref FirstName, ref LastName, ref NationalNo,
                                                ref Gender, ref DateOfBirth, ref Phone, ref Email, ref JobTitle,
                                                ref HireDate, ref Status, ref CreatedAt, ref CreatedByUserID))

                return new clsEmployee(EmployeeID, PersonID, FirstName, LastName, NationalNo,
                                        Gender, DateOfBirth, Phone, Email, JobTitle,
                                        HireDate, Status, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateEmployee();
            }
            return false;

        }

        public static DataTable GetAllEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }

        public static bool DoesNationalNoExist(string NationalNo)
        {
            return clsEmployeeData.CheckNationalNoExists(NationalNo);
        }

        public static bool Delete(int EmployeeID)
        {
            return clsEmployeeData.DeleteEmployee(EmployeeID);
        }
    }
}
