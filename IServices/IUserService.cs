using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User GetUserById(int id);
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
        User Login(string email, string pwd);


    }
}
