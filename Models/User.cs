using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squid.Models
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int Salt { get; set; }
        public int RoleId { get; set; }

        public User(string username, string passwordHash, int salt, int roleId)
        {
            this.Username = username;
            this.PasswordHash = passwordHash;
            this.Salt = salt;
            this.RoleId = roleId;
        }

        public User()
        {
        }

    }
}
