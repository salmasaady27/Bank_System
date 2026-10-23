using Bank_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer
{
    public class clsClient : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ClientID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserID { get; set; }

        public clsClient()
        {
            this.ClientID = -1;
            this.CreatedAt = DateTime.Now;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsClient(int ClientID, int PersonID, string FirstName, string LastName, string NationalNo,
                                char Gender, DateTime DateOfBirth, string Phone, string Email,
                                DateTime CreatedAt, int CreatedByUserID) : base(PersonID, FirstName, LastName, NationalNo,
                                                                                    Gender, DateOfBirth, Phone, Email)
        {
            this.ClientID = ClientID;
            this.CreatedAt = CreatedAt;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static clsClient Find(int ClientID)
        {
            int PersonID = -1;
            string FirstName = "", LastName = "", NationalNo = "", Phone = "", Email = "";
            char Gender = 'M';
            DateTime DateOfBirth = DateTime.Now, CreatedAt = DateTime.Now;
            int CreatedByUserID = -1;

            bool isFound = clsClientData.GetClientInfoByID(ClientID, ref PersonID, ref FirstName,
                ref LastName, ref NationalNo, ref Gender, ref DateOfBirth, ref Phone,
                ref Email, ref CreatedAt, ref CreatedByUserID);

            if (isFound)
                return new clsClient(ClientID, PersonID, FirstName, LastName, NationalNo,
                    Gender, DateOfBirth, Phone, Email, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public static clsClient Find(string NationalNo)
        {
            int ClientID = -1, PersonID = -1;
            string FirstName = "", LastName = "", Phone = "", Email = "";
            char Gender = 'M';
            DateTime DateOfBirth = DateTime.Now, CreatedAt = DateTime.Now;
            int CreatedByUserID = -1;

            bool isFound = clsClientData.GetClientInfoByNationalNo(NationalNo, ref ClientID,
                ref PersonID, ref FirstName, ref LastName, ref Gender, ref DateOfBirth,
                ref Phone, ref Email, ref CreatedAt, ref CreatedByUserID);

            if (isFound)
                return new clsClient(ClientID, PersonID, FirstName, LastName, NationalNo,
                    Gender, DateOfBirth, Phone, Email, CreatedAt, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllClients()
        {
            return clsClientData.GetAllClients();
        }

        public static bool Delete(int ClientID)
        {
            return clsClientData.DeleteClient(ClientID);
        }

        public static bool DoesClientExist(string NationalNo)
        {
            return clsClientData.CheckClientNationalNoExists(NationalNo);
        }

        public static bool IsPersonAlreadyClient(int PersonID)
        {
            return clsClientData.CheckPersonIsAlreadyClient(PersonID);
        }

        private bool _AddNewClient()
        {
            this.ClientID = clsClientData.AddNewClient(this.FirstName, this.LastName,
                this.NationalNo, this.Gender, this.DateOfBirth, this.Phone, this.Email,
                this.CreatedByUserID);

            return (this.ClientID != -1);
        }

        private bool _UpdateClient()
        {
            return clsClientData.UpdateClient(this.ClientID, this.PersonID, this.FirstName,
                this.LastName, this.NationalNo, this.Gender, this.DateOfBirth, this.Phone,
                this.Email, this.CreatedByUserID);
        }
        
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewClient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateClient();
            }

            return false;
        }

        public static int GetTotalClients()
        {
            return clsClientData.GetTotalClients();
        }
    }
}
