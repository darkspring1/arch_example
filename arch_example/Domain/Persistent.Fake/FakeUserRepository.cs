using Domain.Model;
using Domain.Persistent.State;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Persistent.EF
{
    public class FakeUserRepository : IUserRepository
    {

        static UserState[] _users = new []
        {
            new UserState { Email = "olt.egor@gmail.com", UserName = "Egor" }
        };


        User Create(UserState state)
        {
            return state == null ? null : new User(state);
        }


        public Task<User> FindAsync(string email)
        {
            var userState = _users.First(u => u.Email == email);
            return Task.FromResult(Create(userState));
        }

        public Task<User> GetByIdAsync(object key)
        {
            throw new NotImplementedException();
        }

        public void RegisterNewUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}