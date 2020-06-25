using System;
using DAL;
using IDAL;
using Squid.Models;

namespace Logic
{
    public class LoginLogic
    {
        private IUser _userContext;

        public LoginLogic()
        {
            _userContext = new UserContext();
        }

        public User ValidateUser(string username, string passwordHash)
        {
            var user = _userContext.GetUserByUsername(username);
            if (user.PasswordHash == passwordHash)
            {
                return user;
            }

            return null;
        }
    }
}
