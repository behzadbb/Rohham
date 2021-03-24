using Rohham.Data.Context;
using Rohham.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rohham.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext _db;
        public ApplicationDbContext Db
        {
            get
            {
                if (_db == null)
                {
                    var factory = new ApplicationDbContextFactory();
                    _db = factory.CreateDbContext(new string[] { });
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public void CreateUser(User user)
        {
            Db.Users.Add(user);
            Db.SaveChanges();
        }

        public User GetUser(string userId)
        {
            return Db.Users.Find(userId);
        }
    }
}