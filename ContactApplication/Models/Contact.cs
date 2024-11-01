using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Models
{
    internal class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public List<ContactDetail> ContactDetails { get; set; }
        public Contact(int contactId, string firstName, string lastName)
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
            ContactDetails = new List<ContactDetail>();
        }

        string GetContactDetails()
        {
            string result = "";
            foreach (var contact in ContactDetails)
            {
                result = result + contact.ToString();
            }
            return result;
        }
        public override string ToString()
        {
            return $"Contact Id : {ContactId}\n" +
                $"Full Name : {FirstName} {LastName}\n" +
                $"\nContact Details : \n" +
                $"{GetContactDetails()}\n";
        }
    }
}
