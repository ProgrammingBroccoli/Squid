using System;
using System.Collections.Generic;
using IDAL;
using Squid.Models;

namespace DAL
{
    public class UserContext : IUser
    {
        public List<User> users;

        public UserContext()
        {
            users = new List<User>
            {
                new User{Username = "ShoarmazaakHelmond", PasswordHash = "shoarma123", Salt = 1, RoleId = 1}
            };
        }

        public User GetUserByUsername(string username)
        {   
            return users.Find(i => i.Username == username);
        }


    }
}
