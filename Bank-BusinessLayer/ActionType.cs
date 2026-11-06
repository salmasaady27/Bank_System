using Bank_DataLayer;
using System;
using System.Data;

namespace Bank_BusinessLayer
{
    public class clsActionType
    {
        
        public int ActionTypeID { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsActionType()
        {
            this.ActionTypeID = -1;
            this.ActionName = string.Empty;
            this.Description = string.Empty;
            this.CreatedAt = DateTime.Now;
        }

        private clsActionType(int ActionTypeID, string ActionName,
            string Description, DateTime CreatedAt)
        {
            this.ActionTypeID = ActionTypeID;
            this.ActionName = ActionName;
            this.Description = Description;
            this.CreatedAt = CreatedAt;
        }

        public static clsActionType Find(int ActionTypeID)
        {
            string ActionName = string.Empty, Description = string.Empty;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsActionTypeData.GetActionTypeByID(ActionTypeID,
                ref ActionName, ref Description, ref CreatedAt);

            if (isFound)
                return new clsActionType(ActionTypeID, ActionName, Description, CreatedAt);
            else
                return null;
        }

        public static DataTable GetAllActionTypes()
        {
            return clsActionTypeData.GetAllActionTypes();
        }
    }
}