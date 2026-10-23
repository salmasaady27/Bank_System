using Bank_DataLayer;
using System;
using System.Data;

namespace Bank_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public clsEmployee EmployeeInfo { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.PasswordHash = "";
            this.PasswordSalt = "";
            this.Status = true;
            this.CreatedAt = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int EmployeeID, string UserName, string PasswordHash,
                            string PasswordSalt, bool Status, DateTime CreatedAt)


        {
            this.UserID = UserID;
            this.EmployeeID = EmployeeID;
            this.EmployeeInfo = clsEmployee.Find(EmployeeID);
            this.UserName = UserName;
            this.Password = "";
            this.PasswordHash = PasswordHash;
            this.PasswordSalt = PasswordSalt;
            this.Status = Status;

            Mode = enMode.Update;
        }

        public static clsUser Find(int UserID)
        {
            int EmployeeID = -1;
            string UserName = "", PasswordHash = "", PasswordSalt = "";
            bool Status = false;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsUserData.GetUserByID(UserID, ref EmployeeID, ref UserName, 
                            ref PasswordHash, ref PasswordSalt, ref Status, ref CreatedAt);

            if (isFound)
                return new clsUser(UserID, EmployeeID, UserName, PasswordHash, PasswordSalt, Status, CreatedAt);
            else
                return null;
        }
        public static clsUser Find(string UserName)
        {
            int UserID = -1, EmployeeID = -1;
            string PasswordHash = "", PasswordSalt = "";
            bool Status = false;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsUserData.GetUserByUsername(UserName, ref UserID, ref EmployeeID,
                            ref PasswordHash, ref PasswordSalt, ref Status, ref CreatedAt);

            if (isFound)
                return new clsUser(UserID, EmployeeID, UserName, PasswordHash, PasswordSalt, Status, CreatedAt);
            else
                return null;
        }

        public static clsUser FindByEmployeeID(int EmployeeID)
        {
            int UserID = -1;
            string UserName = "", PasswordHash = "", PasswordSalt = "";
            bool Status = false;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsUserData.GetUserByEmployeeID(EmployeeID, ref UserID, ref UserName,
                            ref PasswordHash, ref PasswordSalt, ref Status, ref CreatedAt);

            if (isFound)
                return new clsUser(UserID, EmployeeID, UserName, PasswordHash, PasswordSalt, Status, CreatedAt);
            else
                return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool DoesUserExist(string UserName)
        {
            return clsUserData.CheckUsernameExists(UserName);
        }

        private bool _AddNewUser()
        {
            var result = clsPasswordHashing.HashPassword(this.Password);

            this.PasswordHash = result.passwordHashHex;
            this.PasswordSalt = result.saltHex;

            this.UserID = clsUserData.AddNewUser(this.EmployeeID, this.UserName, this.PasswordHash, this.PasswordSalt);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {

            // only re-hash if user typed a new password
            if (!string.IsNullOrWhiteSpace(this.Password))
            {
                var result = clsPasswordHashing.HashPassword(this.Password, this.PasswordSalt);
                this.PasswordHash = result.passwordHashHex;
                this.PasswordSalt = result.saltHex;
            }
            // else: keep existing PasswordHash and PasswordSalt untouched

            //var result = clsPasswordHashing.HashPassword(this.Password, this.PasswordSalt);
            //this.PasswordHash = result.passwordHashHex;

            return clsUserData.UpdateUser(this.UserID, this.EmployeeID, this.UserName, this.PasswordHash, this.PasswordSalt);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
        public static bool Delete(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        private bool _ChangeStatus(bool Status)
        {
            bool isUpdated = clsUserData.UpdateUserStatus(this.UserID, Status);

            if (isUpdated) this.Status = Status;
            return isUpdated;
        }

        public bool Activate()
        {
            return _ChangeStatus(true);
        }

        public bool Deactivate()
        {
            return _ChangeStatus(false);
        }

        public static bool ChangeStatus(int UserID, bool Status)
        {
            return clsUserData.UpdateUserStatus(UserID, Status);
        }

        public static int GetTotalUsers()
        {
            return clsUserData.GetTotalUsers();
        }

        public static int GetTotalActiveUsers()
        {
            return clsUserData.GetTotalActiveUsers();
        }

        //public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        //{
        //    //int UserID = -1, EmployeeID = -1;
        //    //string PasswordHash = "", PasswordSalt = "";
        //    //bool Status = false;
        //    //DateTime CreatedAt = DateTime.Now;

        //    //bool IsFound = clsUserData.GetUserInfoByUserNameAndPassword
        //    //                    (UserName, Password, ref UserID, ref PersonID, ref IsActive);

        //    //if (IsFound)
        //    //    //we return new object of that User with the right data
        //    //    return new clsUser(UserID, EmployeeID, UserName, PasswordHash, PasswordHash, Status, CreatedAt);
        //    //else
        //        return null;
        //}
        //public static bool DoesUserExist(int UserID)
        //{
        //    return clsUserData.DoesUserExist(UserID);
        //}

    }
}
