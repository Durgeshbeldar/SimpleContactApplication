using ContactApplication.Controllers;
using ContactApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Presentation
{
    internal class StaffMenuUI
    {
        public static StaffController staffController;
        public static void MenuUI(User user)
        {
            staffController = new StaffController(user);
            while (true)
            {
                DisplayMenu();
                int choice = UserInput.SelectOption();
                switch (choice)
                {
                    case 1:
                        AddNewContact();
                        break;
                    case 2:
                        ModifyContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    case 4:
                        DisplayAllContacts();
                        break;
                    case 5:
                        FindContact();
                        break;
                        case 6:
                        return;
                default:
                        break;
                }
            }
        }

        static void AddNewContact()
        {
            Contact contact = UserInput.GetNewContact(staffController);
            staffController.AddContact(contact);
            ContactDetail contactDetail = UserInput.GetNewContactDetail(staffController , contact);
            staffController.AddContactDetails(contact.ContactId, contactDetail);
            Console.WriteLine("Contact Added Successfully");
        }
        
        static void FindContact()
        {
            try
            {
                int contactId = UserInput.GetId("Contact");
                Contact contact = staffController.FindContactById(contactId);
                if (contact == null)
                    throw new Exception("Contact Not Found, Please Enter Another Id");
                Console.WriteLine($"\nContact Successfully Found....\n\n" +
                    $"{contact}");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                FindContact();
            }
        }

        static void DisplayAllContacts()
        {
            throw new NotImplementedException();
        }

        static void DeleteContact()
        {
            throw new NotImplementedException();
        }

        static void ModifyContact()
        {
            throw new NotImplementedException();
        }

        static void DisplayMenu()
        {
            Console.WriteLine($"\nWhat Do You Wish To Do?\n\n" +
               "1. Add New Contact\n" +
               "2. Modify Contact\n" +
               "3. Delete Contact (Soft Delete)\n" +
               "4. Display All Contacts\n" +
               "5. Find Contact\n" +
               "6. Work On Contact Details\n" +
               "7. Logout\n");
        }


    }
}