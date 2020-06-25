using System;
using Squid.Models;

namespace IDAL
{
    public interface IUser
    {
        User GetUserByUsername(string username);
    }
}
