using ContactApplication.Controllers;
using ContactApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Presentation
{
    internal class UserInterface
    {
        //*********** Implemetation of Simple Contact Application in C# *******************
        
        public static UserController userController = new UserController();

        public static void ContactAppUI()
        {
            Console.WriteLine("***************************** WELCOME TO CONTACT APP *****************************\n");
            if (!userController.IsUsersExist())
            {
                Console.WriteLine("Users Not Found, Add Initial User as Admin!");
                AdminMenuUI.MenuUI(null);
                Environment.Exit(0);    
            }
            
            int userId = UserInput.GetUserId();
            
            User user = userController.GetUserById(userId);

            switch (user.IsAdmin)
            {
                case true:
                    AdminMenuUI.MenuUI(user);
                    break;
                case false:
                    StaffMenuUI.MenuUI(user);
                    break;
            }

        }

        
    }
}