using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using webAPI_NaverMusic.IServices;
using webAPI_NaverMusic.Models;

namespace webAPI_NaverMusic.Services
{
    public class UserService: IUserService
    {

        BDNaverMusicContext dbContext;

        public UserService(BDNaverMusicContext _db)
        {
            dbContext = _db;
        }

        //GET ALL USERS
        public IEnumerable<User> GetUsers()
        {
            var user = dbContext.Users.ToList();
            return user;
        }

        //CREATE OR INSERT NEW USER
        public User AddUser(User _user)
        {
            string hashPass = hashPasword(_user.Pwd);

            if (_user != null)
            {
               _user.Pwd = hashPass;

                dbContext.Users.Add(_user);
                dbContext.SaveChanges();
                return _user;
            }
            return null;
        
        }


        private static string hashPasword(string pwd)
        {
            SHA1CryptoServiceProvider _shaEncrypt = new SHA1CryptoServiceProvider();
            _shaEncrypt.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pwd));
            byte[] encrypt = _shaEncrypt.Hash;
            StringBuilder passwordHash = new StringBuilder();
            foreach (byte res in encrypt)
            {
                passwordHash.Append(res.ToString("x2"));
            }
            _shaEncrypt.Clear();
            return passwordHash.ToString();
        
        }


        //UPDATE USER
        public User UpdateUser(User _user)
        {
            string hashPass = hashPasword(_user.Pwd);

            if (_user != null)
            {
                _user.Pwd = hashPass;
                dbContext.Entry(_user).State = EntityState.Modified;
            dbContext.SaveChanges();
                return _user;
            }

            return null;
          

        }

        //DELETEUSER
        public User DeleteUser(int _id)
        {
            var user_ = dbContext.Users.FirstOrDefault(x => x.IdUser == _id);
            dbContext.Entry(user_).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return user_;
        }


        //GET USER BY ID
        public User GetUserById(int _id)
        {
            var user_ = dbContext.Users.FirstOrDefault(x => x.IdUser == _id);
           
        
            return user_;
        }

        public User Login(string email, string pwd)
        {
            string hassPassword = hashPasword(pwd);

            var user_ = dbContext.Users.FirstOrDefault(z => z.Email == email);
            if (user_ != null)
            {
                if (email == user_.Email && hassPassword == user_.Pwd)
                {
                    return user_;
                }
            }
            
                return null;
        }







    }
}
