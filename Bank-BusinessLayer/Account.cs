using Bank_DataLayer;
using System;
using System.Data;

namespace Bank_BusinessLayer
{
    public class clsAccount
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enAccountType { Current = 1, Savings = 2, FixedDeposit = 3 }


        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public int AccountTypeID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }

        // Readable Only
        public clsClient ClientInfo { get; }
        public clsAccountType AccountTypeInfo { get; }

        public clsAccount()
        {
            this.AccountID = -1;
            this.ClientID = -1;
            this.AccountTypeID = (int)enAccountType.Current;
            this.AccountNumber = string.Empty;
            this.Balance = 0;
            this.Status = true;
            this.CreatedAt = DateTime.Now;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsAccount(int AccountID, string AccountNumber, int ClientID,
                             int AccountTypeID, decimal Balance, bool Status,
                             DateTime CreatedAt, int CreatedByUserID)
        {
            this.AccountID = AccountID;
            this.ClientID = ClientID;
            this.AccountTypeID = AccountTypeID;
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
            this.Status = Status;
            this.CreatedAt = CreatedAt;
            this.CreatedByUserID = CreatedByUserID;

            this.ClientInfo = clsClient.Find(ClientID);
            this.AccountTypeInfo = clsAccountType.Find(AccountTypeID);

            Mode = enMode.Update;
        }

        public static clsAccount Find(int AccountID)
        {
            int ClientID = -1, AccountTypeID = -1, CreatedByUserID = -1;
            string AccountNumber = "";
            decimal Balance = 0;
            bool Status = false;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsAccountData.GetAccountByID(AccountID, ref AccountNumber, ref ClientID,
                                                         ref AccountTypeID, ref Balance, ref Status,
                                                         ref CreatedAt, ref CreatedByUserID);

            if (isFound)
                return new clsAccount(AccountID, AccountNumber, ClientID, AccountTypeID,
                                        Balance, Status, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public static clsAccount Find(string AccountNumber)
        {
            int AccountID = -1, ClientID = -1, AccountTypeID = -1, CreatedByUserID = -1;
            decimal Balance = 0;
            bool Status = false;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsAccountData.GetAccountByAccountNumber(AccountNumber, ref AccountID,
                ref ClientID, ref AccountTypeID, ref Balance,
                ref Status, ref CreatedAt, ref CreatedByUserID);

            if (isFound)
                return new clsAccount(AccountID, AccountNumber, ClientID, AccountTypeID,
                                        Balance, Status, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllAccounts()
        {
            return clsAccountData.GetAllAccounts();
        }

        public static bool Delete(int AccountID)
        {
            return clsAccountData.DeleteAccount(AccountID);
        }

        public static bool DoesAccountExist(string AccountNumber)
        {
            return clsAccountData.CheckAccountNumberExists(AccountNumber);
        }

        public static bool ChangeStatus(int AccountID, bool Status)
        {
            return clsAccountData.UpdateAccountStatusByID(AccountID, Status);
        }

        public static bool ChangeStatus(string AccountNumber, bool Status)
        {
            return clsAccountData.UpdateAccountStatusByAccountNumber(AccountNumber, Status);
        }

        // For Account ID
        private bool _ChangeStatus(bool Status)
        {
            bool isUpdated = clsAccountData.UpdateAccountStatusByID(this.AccountID, Status);

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

        private bool _AddNewAccount()
        {
            this.AccountID = clsAccountData.AddNewAccount(this.ClientID, this.AccountTypeID,
                this.Balance, this.CreatedByUserID);

            return (this.AccountID != -1);
        }
        private bool _UpdateAccount()
        {
            return clsAccountData.UpdateAccount(this.AccountID, this.AccountTypeID,
                this.Balance, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAccount())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateAccount();
            }
            return false;
        }

        public static bool ClientHasAccountType(int ClientID, int AccountTypeID)
        {
            return clsAccountData.CheckClientHasAccountType(ClientID, AccountTypeID);
        }

        public static int GetTotalAccounts()
        {
            return clsAccountData.GetTotalAccounts();
        }

        public bool AccountIsActive()
        {
            return this.Status;
        }
    }
}
