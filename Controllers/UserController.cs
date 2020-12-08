using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI_NaverMusic.IServices;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;
        public UserController(IUserService user)
        {
            userService = user;
        }


        //GET ALL USERS 
        [HttpGet]
        [Route("[action]")]
        [Route("api/User/GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return userService.GetUsers();
        }


        //CREATE OR INSERT NEW USER
        [HttpPost]
        [Route("[action]")]
        [Route("api/User/AddUser")]
        public User AddUser(User newUser_)
        {
            return userService.AddUser(newUser_);
        }


        //UPDATE USER
        [HttpPut]
        [Route("[action]")]
        [Route("api/User/UpdateUser")]
        public User UpdateUser(User newUser_)
        {
            return userService.UpdateUser(newUser_);
        }


        //DELETE USER
        [HttpDelete]
        [Route("[action]")]
        [Route("api/User/DeleteUser")]
        public User DeleteUser(int id)
        {
            return userService.DeleteUser(id);
        }


        //GET USER BY ID
        [HttpGet]
        [Route("[action]")]
        [Route("api/User/GetUserById")]
        public User GetUserById(int id)
        {
            return userService.GetUserById(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/User/FindUser")]
        public User FindUser(string email, string pwd)
        {
            return userService.Login(email,pwd);
        }




    }

  


}
