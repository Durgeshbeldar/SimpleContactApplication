using ContactApplication.Models;
using ContactApplication.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Controllers
{
    internal class AdminController : UserController
    {
       
        public string AddUser(User user)
        {
            _users.Add(user);
            SaveUsers();
            return "User Added to Database...!";
        }

        public override User GetUserById(int id)
        {
            User user = _users.FirstOrDefault(user => user.UserId == id);
            if (user == null)
                throw new Exception("User Not Found OR Invalid User Id,  Please Enter Another User Id");
            return user;
        }
        public string ModifyUser(int id,string firstName, string lastName, bool isActive)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.IsActive = isActive;
                SaveUsers();
                return "User Modified Successfully...!";
            }
            return "Error Occured, User Not Found.";
        }
        public List<User> GetAllUsers()
        {
            return _users;  
        }
        public bool IsUniqueId(int id)
        {
            var user = _users.FirstOrDefault(user => user.UserId == id);
            if (user == null)
                return true;
            return false;
        }


    }
}
