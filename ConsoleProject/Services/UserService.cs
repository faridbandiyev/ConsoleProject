using ConsoleProject.Models;
using ConsoleProject.MyExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Services
{
    public class UserService
    {
        public User Login(string email, string password)
        {
            foreach (var user in DB.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            throw new NotFoundException("User not found");
        }

        public void AddUser(User user)
        {
            Array.Resize(ref DB.Users, DB.Users.Length + 1);
            DB.Users[DB.Users.Length - 1] = user;
        }
    }
}
