using System;
using System.Threading.Tasks;


namespace Domain.Persistent.EF
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        
        public FakeUnitOfWork()
        {
            UserRepository = new FakeUserRepository();
        }

        public IUserRepository UserRepository { get; }

        public void Complete()
        {
           
        }

        public Task CompleteAsync()
        {
            return Task.FromResult(0);
        }

        public IUnitOfWork CreateNewInstance()
        {
            return new FakeUnitOfWork();
        }

        public void Dispose()
        {
            
        }
    }
}