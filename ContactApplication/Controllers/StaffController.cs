using ContactApplication.Models;
using ContactApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Controllers
{
    internal class StaffController : UserController
    {
        public User user; 
        
        public StaffController(User user)
        {
            this.user = user;
        }

        public bool IsUniqueId(int id)
        {
            var contact = user.Contacts.FirstOrDefault(contact => contact.ContactId == id);
            return contact == null;
                
        }

        public void AddContact(Contact contact)
        {
            User updateUser = GetUserById(user.UserId);
            updateUser.Contacts.Add(contact);
            SaveUsers();
        }

        public void AddContactDetails(int id,ContactDetail contactDetail)
        {

            Contact contact = FindContactById(id);
            contact.ContactDetails.Add(contactDetail);
            SaveUsers();
        }

        public void ModifyContact(string firstName, string lastName, int contactId)
        {
            Contact contact = FindContactById(contactId);
            contact.FirstName = firstName;
            contact.LastName = lastName;
            SaveUsers();
        }

        public void DeleteContact(int contactId)
        {
            Contact contact = FindContactById(contactId);
            if (contact == null)
                throw new Exception("Invalid Contact Id OR contact Not Found, Please Enter Another ContactId ");
            contact.IsActive = false;
            SaveUsers();
        }
        
        public Contact FindContactById(int contactId)
        {
            User updateUser = GetUserById(user.UserId);
            Contact contact = updateUser.Contacts.FirstOrDefault(contact => contact.ContactId == contactId);
            if (contact == null)
            {
                throw new Exception("Invalid Contact Id OR Contact Not Found, Please Enter Another Id");
            }
            return contact;
        }

        public List<Contact> GetAllContact()
        {
            User updatedUser = GetUserById(user.UserId);
            return updatedUser.Contacts;
        }

      
        public bool IsUniqueORExistContactDetailId(Contact contact, int contactDetailId)
        {
            var contactDetail = contact.ContactDetails.FirstOrDefault
                (contactDetail => contactDetail.ContactDetailId == contactDetailId);
            return contactDetail == null;
        }

        public void ModifyContactDetail(string type, string value, int contactId, int contactDetailId)
        {
            Contact contact = FindContactById(contactId);
            var contactDetail = contact.ContactDetails.FirstOrDefault
                (contactDetail => contactDetail.ContactDetailId == contactDetailId);
            contactDetail.Type = type;  
            contactDetail.Value = value;
            SaveUsers();
        } 

        public void DeleteContactDetail(int contactId, int contactDetailId)
        {
            Contact contact = FindContactById(contactId);
            var contactDetail = contact.ContactDetails.FirstOrDefault
                (contactDetail => contactDetail.ContactDetailId == contactDetailId);
            contact.ContactDetails.Remove(contactDetail);
            SaveUsers();
        }
    }
}
