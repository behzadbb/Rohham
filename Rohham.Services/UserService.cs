using Rohham.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        User GetUser(string userId);
    }

    public class UserService : IUserService
    {
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
