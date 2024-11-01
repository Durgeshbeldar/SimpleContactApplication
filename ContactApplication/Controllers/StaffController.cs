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

        
        public Contact FindContactById(int id)
        {
            User updateUser = GetUserById(user.UserId);
            return updateUser.Contacts.FirstOrDefault(contact => contact.ContactId == id);
        }
        public bool IsUniqueContactDetailId(Contact contact, int id)
        {
            var contactDetail = contact.ContactDetails.FirstOrDefault
                (contactDetail => contactDetail.ContactDetailId == id);
            return contactDetail == null;
        }




    }
}
