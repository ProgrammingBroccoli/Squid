using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using IDAL;
using Squid.Models;

namespace Logic
{
    public class UserLogic
    {
        private IUser _userContext;

        public UserLogic()
        {
            _userContext = new UserContext();
        }

        public User GetUserByUsername(string username)
        {
           return _userContext.GetUserByUsername(username);
        }
    }
}
