using System;
using System.Data;
using Bank_DataLayer;

namespace Bank_BusinessLayer
{
    public class clsTransfer
    {
        public int TransferID { get; set; }
        public int TransactionID { get; set; }
        public int SenderAccountID { get; set; }
        public int ReceiverAccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }

        // Navigation properties
        public clsAccount SenderAccountInfo { get; }
        public clsAccount ReceiverAccountInfo { get; }
        public clsTransaction TransactionInfo { get; }

        public clsTransfer()
        {
            this.TransferID = -1;
            this.TransactionID = -1;
            this.SenderAccountID = -1;
            this.ReceiverAccountID = -1;
            this.Amount = 0;
            this.CreatedAt = DateTime.Now;
            this.CreatedByUserID = -1;
        }

        private clsTransfer(int TransferID, int TransactionID, int SenderAccountID,
            int ReceiverAccountID, decimal Amount, DateTime CreatedAt, int CreatedByUserID)
        {
            this.TransferID = TransferID;
            this.TransactionID = TransactionID;
            this.SenderAccountID = SenderAccountID;
            this.ReceiverAccountID = ReceiverAccountID;
            this.Amount = Amount;
            this.CreatedAt = CreatedAt;
            this.CreatedByUserID = CreatedByUserID;

            this.SenderAccountInfo = clsAccount.Find(SenderAccountID);
            this.ReceiverAccountInfo = clsAccount.Find(ReceiverAccountID);
        }

        public static clsTransfer Find(int TransferID)
        {
            int TransactionID = -1, SenderAccountID = -1;
            int ReceiverAccountID = -1, CreatedByUserID = -1;
            decimal Amount = 0;
            DateTime CreatedAt = DateTime.Now;

            bool isFound = clsTransferData.GetTransferByID(TransferID, ref TransactionID,
                                             ref SenderAccountID, ref ReceiverAccountID, ref Amount,
                                             ref CreatedAt, ref CreatedByUserID);

            if (isFound)
                return new clsTransfer(TransferID, TransactionID, SenderAccountID,
                                        ReceiverAccountID, Amount, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllTransfers()
        {
            return clsTransferData.GetAllTransfers();
        }

        public static DataTable GetAllTransfersByAccountID(int AccountID)
        {
            return clsTransferData.GetAllTransfersByAccountID(AccountID);
        }

        private bool _AddNewTransfer()
        {
            this.TransferID = clsTransferData.AddNewTransfer(this.SenderAccountID,
                this.ReceiverAccountID, this.Amount, this.CreatedByUserID);

            return (this.TransferID != -1);
        }

        public bool Save()
        {
            return _AddNewTransfer();
        }
    }
}