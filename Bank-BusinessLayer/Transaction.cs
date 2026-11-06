using System;
using System.Data;
using Bank_DataLayer;

namespace Bank_BusinessLayer
{
    public class clsTransaction
    {
        public enum enTransactionType { Deposit = 1, Withdrawal = 2, Transfer = 3 }

        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public int TransactionTypeID { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }

        // Navigation properties
        public clsAccount AccountInfo { get; }
        public clsTransactionType TransactionTypeInfo { get; }

        public clsTransaction()
        {
            this.TransactionID = -1;
            this.AccountID = -1;
            this.TransactionTypeID = -1;
            this.Amount = 0;
            this.Note = string.Empty;
            this.CreatedAt = DateTime.Now;
            this.CreatedByUserID = -1;
        }

        private clsTransaction(int TransactionID, int AccountID, int TransactionTypeID,
            decimal Amount, string Note, DateTime CreatedAt, int CreatedByUserID)
        {
            this.TransactionID = TransactionID;
            this.AccountID = AccountID;
            this.TransactionTypeID = TransactionTypeID;
            this.Amount = Amount;
            this.Note = Note;
            this.CreatedAt = CreatedAt;
            this.CreatedByUserID = CreatedByUserID;

            this.AccountInfo = clsAccount.Find(AccountID);
            this.TransactionTypeInfo = clsTransactionType.Find(TransactionTypeID);
        }

        public static clsTransaction Find(int TransactionID)
        {
            int AccountID = -1, TransactionTypeID = -1, CreatedByUserID = -1;
            decimal Amount = 0;
            string Note = "";
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsTransactionData.GetTransactionByID(TransactionID, ref AccountID,
                ref TransactionTypeID, ref Amount, ref Note, ref CreatedAt, ref CreatedByUserID);

            if (isFound)
                return new clsTransaction(TransactionID, AccountID, TransactionTypeID,
                    Amount, Note, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllTransactions()
        {
            return clsTransactionData.GetAllTransactions();
        }

        public static DataTable GetTransactionsByAccountID(int AccountID)
        {
            return clsTransactionData.GetAllTransactionsByAccountID(AccountID);
        }

        private bool _AddNewTransaction()
        {
            this.TransactionID = clsTransactionData.AddNewTransaction(this.AccountID,
                this.TransactionTypeID, this.Amount, this.Note, this.CreatedByUserID);

            return (this.TransactionID != -1);
        }

        public bool Deposit()
        {
            this.TransactionTypeID = (int)enTransactionType.Deposit;
            this.Note = $"Deposit of {this.Amount:N2}";
            return _AddNewTransaction();
        }

        public bool Withdraw()
        {
            this.TransactionTypeID = (int)enTransactionType.Withdrawal;
            this.Note = $"Withdrawal of {this.Amount:N2}";
            return _AddNewTransaction();
        }
        public bool Save()
        {
           switch(this.TransactionTypeID)
           {
               case (int)enTransactionType.Deposit:
                   return Deposit();
               case (int)enTransactionType.Withdrawal:
                   return Withdraw();
               default:
                   return false;
           }
        }
        public static int CountTodayTransactions()
        {
            return clsTransactionData.CountTodayTransactions();
        }

        public static DataTable GetTodayTransactions()
        {
            return clsTransactionData.GetTodayTransactions();
        }
    }
}