using ContactApplication.Controllers;
using ContactApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Presentation
{
    internal class UserInput
    {
        public static int SelectOption()
        {
            Console.WriteLine("Choose Your Option :");  
            int userOption;
            try
            {
                userOption = int.Parse(Console.ReadLine());
                return userOption;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return SelectOption();
            }
        }

        public static User GetNewUser(AdminController adminController)
        {
            int userId = GetUniqueUserId(adminController);

            Console.WriteLine("Enter User's First Name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter User's Last Name :");
            string lastName = Console.ReadLine();

            bool isAdmin = GetUserRole();
            
            User user = new User(userId, firstName, lastName, isAdmin);
            return user;
        }
        static int GetUniqueUserId(AdminController adminController)
        {
            int userId;
            try
            {
                Console.WriteLine("Enter Unique User Id : ");
                userId = int.Parse(Console.ReadLine());
                if (adminController.IsUniqueId(userId))
                    return userId;
                throw new Exception("User Id Already Exist, Please Enter Unique User Id");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return GetUniqueUserId(adminController);
            }
        }

        public static int GetUserId()
        {
            Console.WriteLine("Enter User Id : ");
            int userId; 
            try
            {
                userId = int.Parse(Console.ReadLine());
                return userId;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetUserId();
            }
        }

        public static bool GetUserRole()
        {
            try
            {
                Console.WriteLine("Do You Want to Registered it as Admin (Yes/No) ?");
                string userInput = Console.ReadLine().ToLower();
                if (userInput != "yes" && userInput != "no")
                    throw new Exception("Invalid Input, Please Enter Yes OR No Only!");

                if (userInput == "yes")
                    return true;
                return false;     
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetUserRole();
            }
        }

        // User Inputs For Contacts...

        public static Contact GetNewContact(StaffController staffController)
        {
            int contactId = GetUniqueContactId(staffController);

            Console.WriteLine("Enter First Name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name :");
            string lastName = Console.ReadLine();

            Contact contact = new Contact(contactId,firstName, lastName);
            return contact;
        }

        static int GetUniqueContactId(StaffController staffController)
        {
            int contactId;
            try
            {
                Console.WriteLine("Enter Unique Contact Id : ");
                contactId = int.Parse(Console.ReadLine());
                if (staffController.IsUniqueId(contactId))
                    return contactId;
                throw new Exception("Contact Id Already Exist, Please Enter Unique Contact Id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetUniqueContactId(staffController);
            }
        }

        public static int GetId(string entityName)
        {
            int Id;
            try
            {
                Console.WriteLine($"Enter {entityName} Id :");
                Id = int.Parse(Console.ReadLine());
                return Id;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return GetId(entityName);
            }
        }

        public static ContactDetail GetNewContactDetail(StaffController staffController, Contact contact)
        {
            int contactDetailId = GetUniqueContactDetailId(staffController, contact);
            string type;
            if (contact.ContactDetails.Count != 0)
            {
                Console.WriteLine("Enter Contact Detail Type : ");
                type = Console.ReadLine();
            }
            else
            {
                type = "Mobile Number";
            }

            Console.WriteLine($"Enter Value For {type} : ");
            string value = Console.ReadLine();

            ContactDetail contactDetail =  new ContactDetail(contactDetailId,type,value);
            return contactDetail;
        }
        static int GetUniqueContactDetailId(StaffController staffController ,Contact contact)
        {
            int contactDetailId;
            try
            {
                Console.WriteLine("Enter Unique Contact Id : ");
                contactDetailId = int.Parse(Console.ReadLine());
                if (staffController.IsUniqueORExistContactDetailId(contact,contactDetailId))
                    return contactDetailId;
                throw new Exception("ContactDetail Id is Already Exist, Please Enter Unique ContactDetail Id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetUniqueContactDetailId(staffController, contact);
            }
        }







    }
}
