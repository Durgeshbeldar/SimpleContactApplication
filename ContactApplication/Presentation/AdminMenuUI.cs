using ContactApplication.Controllers;
using ContactApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Presentation
{
    internal class AdminMenuUI
    {
        public static AdminController adminController = new AdminController();
        public static void MenuUI(User user)
        {
            Console.WriteLine("***************************** WELCOME TO ADMIN PANEL *****************************\n");
            while (true)
            {
                DisplayMenu();
                int choice = UserInput.SelectOption();
                switch (choice)
                {
                    case 1:
                        AddNewUser();
                        break;
                    case 2:
                        ModifyUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        DisplayAllUsers();
                        break;
                    case 5:
                        FindUser();
                        break;
                    case 6:
                        ViewProfile(user);
                        break;
                    case 7:
                        Console.WriteLine("\nSuccessfully Logout From Admin Panel!\n");
                        return;
                    default:
                        Console.WriteLine("Invalid Input, Please Select Valid Option");
                        break;
                }
            }

        }
      

        static void DisplayMenu()
        {
            Console.WriteLine($"\nWhat Do You Wish To Do?\n\n" +
                $"1. Add New User\n" +
                $"2. Modify Existing User\n" +
                $"3. Delete User (Soft Delete)\n" +
                $"4. Display All Users\n" +
                $"5. Find User\n" +
                $"6. View Profile\n" +
                $"7. Logout\n");
        }

        static void AddNewUser()
        {
            try
            {
                User user = UserInput.GetNewUser(adminController);
                Console.WriteLine(adminController.AddUser(user));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ModifyUser()
        {
            int userId = UserInput.GetUserId();
            try
            {
                User user = adminController.GetUserById(userId);
                Console.WriteLine("Change User's First Name :");
                string firstName = Console.ReadLine();

                Console.WriteLine("Change User's Last Name :");
                string lastName = Console.ReadLine();

                string userRole = user.IsAdmin ? "Admin" : "Staff";

                bool isActive;
                Console.WriteLine($"Modify User Role : \n" +
                    $"Current Role is : {userRole} \n" +
                    $"Type Yes to Assigned Admin Role OR Type No to Assigned Normal User Role:");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice != "yes" && userChoice != "no")
                    throw new Exception("Invalid Input");
                if (userChoice == "yes")
                {
                    isActive = true;
                }
                else 
                { 
                    isActive = false; 
                }
                
                Console.WriteLine(adminController.ModifyUser(userId,firstName,lastName, isActive));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        static void DeleteUser()
        {
            int userId = UserInput.GetUserId();
            try
            {
                User user = adminController.GetUserById(userId);
                user.IsActive = false;
                adminController.SaveUsers();
                Console.WriteLine("User Deleted Successfully");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        static void DisplayAllUsers()
        {
            List<User> users = adminController.GetAllUsers();
            Console.WriteLine($"\nTotal {users.Count} Users Found\n" +
                "============================================");
            foreach (User user in users)
                Console.WriteLine(user + "--------------------------------------------\n");
        }

        static void FindUser()
        {
            try
            {
                int userId = UserInput.GetUserId();
                User user = adminController.GetUserById(userId);
                if (user.IsActive)
                {
                    Console.WriteLine("User Found Successfully : \n\n" +
                        user);
                }
                else
                {
                    Console.WriteLine("User is Soft Deleted...!");
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                FindUser();
            }
        }

        static void ViewProfile(User user)
        {
            try
            {
                if (user == null)
                    throw new Exception("User is Null, Please Create Your User Account.");
                    Console.WriteLine($"Your Profile Details :\n\n" +
                        $"{user}");
            }catch (Exception ex) 
            { Console.WriteLine( ex.Message); }
        }
        

       

    }
}
