using Rohham.Entities;

namespace Rohham.Data.Repository
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUser(string userId);
    }
}