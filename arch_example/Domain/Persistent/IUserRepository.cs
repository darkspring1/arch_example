using Domain.Model;
using System.Threading.Tasks;

namespace Domain.Persistent
{
    public interface IUserRepository
    {
        
        Task<User> GetByIdAsync(object key);

        void RegisterNewUser(User newUser);

        Task<User> FindAsync(string email);
    }
}