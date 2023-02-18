using System;
using System.Collections.Generic;
using System.Text;

namespace graduate_work.Models
{
    internal class User
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsSpecialist { get; set; }

        public User(string name, string phoneNumber, string password, bool isSpecialist)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Password = password;
            IsSpecialist = isSpecialist;
        }

        /*public bool IsValid()
        {
            return (Name != string.Empty
                && PhoneNumber.Length == 16
                && 

        }*/
    }
}
