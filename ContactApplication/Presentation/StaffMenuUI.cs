using ContactApplication.Controllers;
using ContactApplication.Models;
using Newtonsoft.Json.Linq;
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
                        WorkOnContacts();
                        return;
                    case 7:
                        Console.WriteLine("\nSuccessfully Logout From Staff Panel!\n");
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Please Select Valid Option");
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

        static void ModifyContact()
        {
            try
            {
                int contactId = UserInput.GetId("Contact");
                Contact contact = staffController.FindContactById(contactId);

                Console.WriteLine("Change First Name : ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Change Last Name : ");
                string lastName = Console.ReadLine();

                staffController.ModifyContact(firstName, lastName, contactId);
                Console.WriteLine("Contact Modified Successfully...!");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
        static void DeleteContact()
        {
            try
            {
                int contactId = UserInput.GetId("Contact");
                staffController.DeleteContact(contactId);
                Console.WriteLine("Contact Deleted Successfully");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                DeleteContact();
            }

        }
        static void DisplayAllContacts()
        {
            List<Contact> contacts = staffController.GetAllContact();
            if(contacts.Count == 0) 
            {
                Console.WriteLine("No Contacts Found");
                return;
            }
            int count = 0;
            for(int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].IsActive == true)
                    count++;    
            }
            Console.WriteLine($"Total Contacts Found : {count}\n" +
                $"===================================================");
            foreach (Contact contact in contacts) 
            {
                if (contact.IsActive == false)
                    continue;
                Console.WriteLine(contact);
                Console.WriteLine("==================================================="); // separator
            }
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

        static void WorkOnContactDetailsDisplayMenu()
        {
            Console.WriteLine($"\nWhat Do You Wish To Do?\n\n" +
               "1. Add New Contact Detail\n" +
               "2. Modify Contact Detail\n" +
               "3. Delete Contact Detail (Hard Delete)\n" +
               "4. Display All Contact Details\n" +
               "5. Back\n");
        }


        // Work On Contacts ....

        static void WorkOnContacts()
        {
            Console.WriteLine("Enter Contact Id On which You Wanted Perform Operations");
            int contactId = UserInput.GetId("Contact");
            while (true)
            {
                WorkOnContactDetailsDisplayMenu();
                int choice = UserInput.SelectOption();
                switch (choice)
                {
                    case 1:
                        AddNewContactDetail(contactId);
                        break;
                    case 2:
                        ModifyContactDetail(contactId);
                        break;
                    case 3:
                        DeleteContactDetail(contactId);
                        break;
                    case 4:
                        DisplayAllContactDetails(contactId);
                        break;
                    case 5:
                        MenuUI(staffController.user);
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Please Select Valid Option");
                        break;
                }
            }

        }

        static void AddNewContactDetail(int contactId)
        {
            try
            {
                Contact contact = staffController.FindContactById(contactId);
                ContactDetail contactDetail = UserInput.GetNewContactDetail(staffController, contact);
                staffController.AddContactDetails(contactId, contactDetail);
                Console.WriteLine("Contact Detail Added Successfully...!");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ModifyContactDetail(int contactId)
        {
            try
            {
                int contactDetailId = UserInput.GetId("Contact Detail");
                Contact contact = staffController.FindContactById(contactId);

                // if its true which means Currosponding contact detail not found with this Id.
                
                if (staffController.IsUniqueORExistContactDetailId(contact, contactDetailId))
                throw new Exception("ContactDetail Not Found with this Id, Please Choose Another Id");

                Console.WriteLine("Rename The Contact Detail Type :  (Ex. Address to Mobile No/City/PinCode)");
                string type = Console.ReadLine();

                Console.WriteLine($"Modify the Currosponding Value to Contact Detail Type {type} :");
                string value = Console.ReadLine();

                staffController.ModifyContactDetail(type, value, contactId, contactDetailId);

                Console.WriteLine("Contact Details Modified Successfully");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteContactDetail(int contactId)
        {
            try
            {
                int contactDetailId = UserInput.GetId("Contact Detail");
                Contact contact = staffController.FindContactById(contactId);

                if (staffController.IsUniqueORExistContactDetailId(contact, contactDetailId))
                    throw new Exception("ContactDetail Not Found with this Id, Please Choose Another Id");

                staffController.DeleteContactDetail(contactId, contactDetailId);
                Console.WriteLine("Contact Details Deleted Successfully!");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message );
            }

        }

        static void DisplayAllContactDetails(int contactId)
        {
            try
            {
                Contact contact = staffController.FindContactById(contactId);
                if (contact == null)
                    throw new Exception("Contact Not Found Please Choose Another Id");
                Console.WriteLine(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}