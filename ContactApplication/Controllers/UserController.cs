using ContactApplication.Models;
using ContactApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Controllers
{
    internal class UserController
    {
        protected List<User> _users = DataServices.GetUsers();

        public void SaveUsers()
        {
            DataServices.SaveUsers(_users);
        }
        public bool IsUsersExist()
        {
            if (_users.Count == 0)
                return false;
            return true;
        }

       

        public virtual User GetUserById(int id)
        {
            User user = _users.FirstOrDefault(user => user.UserId == id);
            if (user == null)
                throw new Exception("User Not Found OR Invalid User Id,  Please Enter Another User Id");
            if (!user.IsActive)
                throw new Exception("User is Not Allowed to Perform CRUD Operation, Please Enter Another User Id");
            return user;
        }

    }
}
