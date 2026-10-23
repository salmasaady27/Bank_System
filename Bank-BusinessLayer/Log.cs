using Bank_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bank_BusinessLayer
{
    public class clsLog
    {
        public enum enActionType
        {
            Login = 1, Logout = 2, CreateEmployee = 3, CreateUser = 4,
            CreateClient = 5, CreateAccount = 6, Update = 7, Delete = 8,
            Deposit = 9, Withdrawal = 10, Transfer = 11, Deactivate = 12
        }

        public int LogID { get; set; }
        public int UserID { get; set; }
        public int ActionTypeID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public clsUser UserInfo { get; }
        public clsActionType ActionTypeInfo { get; }

        public clsLog()
        {
            this.LogID = -1;
            this.UserID = -1;
            this.ActionTypeID = -1;
            this.Description = string.Empty;
            this.CreatedAt = DateTime.Now;
        }

        private clsLog(int LogID, int UserID, int ActionTypeID,
                        string Description, DateTime CreatedAt)
        {
            this.LogID = LogID;
            this.UserID = UserID;
            this.ActionTypeID = ActionTypeID;
            this.Description = Description;
            this.CreatedAt = CreatedAt;

            this.UserInfo = clsUser.Find(UserID);
            this.ActionTypeInfo = clsActionType.Find(ActionTypeID);
        }

        public static DataTable GetAllLogs()
        {
            return clsLogData.GetAllLogs();
        }

        public static DataTable GetLogsByUserID(int UserID)
        {
            return clsLogData.GetLogsByUserID(UserID);
        }

        private bool _AddNewLog()
        {
            this.LogID = clsLogData.AddNewLog(this.UserID,
                this.ActionTypeID, this.Description);

            return (this.LogID != -1);
        }

        public bool Save()
        {
            return _AddNewLog();
        }

        public static bool LogAction(int UserID, enActionType ActionType,
            string Description)
        {
            clsLog log = new clsLog
            {
                UserID = UserID,
                ActionTypeID = (int)ActionType,
                Description = Description
            };

            return log.Save();
        }

    }
}