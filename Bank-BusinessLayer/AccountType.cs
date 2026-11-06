using System;
using System.Data;
using Bank_DataLayer;

namespace Bank_BusinessLayer
{
    public class clsAccountType
    {
        
        public int AccountTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsAccountType()
        {
            this.AccountTypeID = -1;
            this.TypeName = "";
            this.Description = "";
            this.CreatedAt = DateTime.Now;
        }

        private clsAccountType(int AccountTypeID, string TypeName, 
                                string Description, DateTime CreatedAt)
        {
            this.AccountTypeID = AccountTypeID;
            this.TypeName= TypeName; 
            this.Description = Description;
            this.CreatedAt = CreatedAt;
        }

        public static DataTable GetAllAccountTypes()
        {
            return clsAccountTypeData.GetAllAccountTypes();
        }

        public static bool DoesAccountTypeExist(string TypeName)
        {
            return clsAccountTypeData.CheckAccountTypeNameExists(TypeName);
        }

        public static clsAccountType Find(int AccountTypeID)
        {
            string TypeName = "", Description = "";
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsAccountTypeData.GetAccountTypeByID(AccountTypeID,
                ref TypeName, ref Description, ref CreatedAt);

            if (isFound)
                return new clsAccountType(AccountTypeID, TypeName, Description, CreatedAt);
            else
                return null;
        }

        public static clsAccountType Find(string TypeName)
        {
            int AccountTypeID = -1;
            string Description = string.Empty;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsAccountTypeData.GetAccountTypeByName(TypeName,
                ref AccountTypeID, ref Description, ref CreatedAt);

            if (isFound)
                return new clsAccountType(AccountTypeID, TypeName, Description, CreatedAt);
            else
                return null;
        }

    }
}
