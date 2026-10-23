using System;
using Bank_DataLayer;

namespace Bank_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public string NationalNo { get; set; }
        public Char Gender { get; set; }
        public string GenderText
        {
            get
            {
                switch (this.Gender)
                {
                    case 'M':
                        return "Male";
                    case 'F':
                        return "Female";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.NationalNo = "";
            this.Gender = 'M';
            this.DateOfBirth = DateTime.Now;
            this.Phone = "";
            this.Email = "";

            Mode = enMode.AddNew;
        }

        protected clsPerson(int PersonID, string FirstName, string LastName,
                                string NationalNo, char Gender, DateTime DateOfBirth,
                                string Phone, string Email)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.Email = Email;

            Mode = enMode.Update;
        }

        public static bool DoesNationalNoExist(string NationalNo)
        {
            return clsPersonData.CheckNationalNoExists(NationalNo);
        }

        public static bool DoesEmailExist(string Email)
        {
            return clsPersonData.DoesEmailExist(Email);
        }
    }
}
