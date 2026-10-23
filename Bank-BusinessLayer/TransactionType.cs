using System;
using System.Data;
using Bank_DataLayer;

namespace Bank_BusinessLayer
{
    public class clsTransactionType
    {
        //public enum enTransactionType { Deposit = 1, Withdrawal = 2, Transfer = 3 }

        public int TransactionTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsTransactionType()
        {
            this.TransactionTypeID = -1;
            this.TypeName = "";
            this.Description = "";
            this.CreatedAt = DateTime.Now;
        }

        private clsTransactionType(int TransactionTypeID, string TypeName, 
                                    string Description, DateTime CreatedAt)
        {
            this.TransactionTypeID = TransactionTypeID;
            this.TypeName = TypeName;
            this.Description = Description;
            this.CreatedAt = CreatedAt;
        }

        public static clsTransactionType Find(int TransactionTypeID)
        {
            string TypeName = "", Description = "";
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsTransactionTypeData.GetTransactionTypeByID(TransactionTypeID,
                ref TypeName, ref Description, ref CreatedAt);

            if (isFound)
                return new clsTransactionType(TransactionTypeID, TypeName, Description, CreatedAt);
            else
                return null;
        }

        public static DataTable GetAllTransactionTypes()
        {
            return clsTransactionTypeData.GetAllTransactionTypes();
        }

        public static bool DoesTransactionTypeExist(string TypeName)
        {
            return clsTransactionTypeData.CheckTransactionTypeNameExists(TypeName);
        }
    }
}
