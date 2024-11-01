using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; } 
        public bool IsActive { get; set; }

        public List<Contact> Contacts { get; set; }
        public User(int userId, string firstName, string lastName, bool isAdmin)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            IsActive = true;
            Contacts = new List<Contact>();
        }

        public override string ToString()
        {
            string role = (IsAdmin) ? "Admin":"Staff";
            string status = (IsActive) ? "Active" : "Inactive";
            return $"User Id : {UserId}\n" +
                $"Full Name : {FirstName} {LastName}\n" +
                $"User Role : {role}\n" +
                $"Status : {status}\n";
        }
    }
}
