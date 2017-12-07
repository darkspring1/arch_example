using Domain.Model;
using Domain.Persistent.State;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Persistent.EF
{
    public class UserRepository : BaseRepository<User, UserState>, IUserRepository
    {
        public UserRepository(IEntityFrameworkDataContext context) : base(context)
        {
        }

        public Task<User> GetByIdAsync(object key)
        {
            var id = (Guid)key;
            var stateTask = FirstOrDefaultAsync(Include(Set.Entities.Where(u => u.Id == id)));
            return CreateAsync(stateTask);
        }

        internal IQueryable<UserState> Include(IQueryable<UserState> users)
        {
            return users;
        }
        

        protected override User Create(UserState state)
        {
            return state == null ? null : new User(state);
        }

        public void RegisterNewUser(User newUser)
        {
            newUser.State.Id = Guid.NewGuid();
            newUser.State.Id = Guid.NewGuid();
            Set.Add(newUser.State);
        }

        public Task<User> FindAsync(Guid userId)
        {
            var userStates = Context.DbSet<UserState>().Entities;
            var userState = FirstOrDefaultAsync(userStates
                .Where(p => p.Id == userId));

            return CreateAsync(userState);
        }

        public Task<User> FindAsync(string email)
        {
            var userState = FirstOrDefaultAsync(Set.Entities.Where(u => u.Email == email));
            return CreateAsync(userState);
        }
    }
}