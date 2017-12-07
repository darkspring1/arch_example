using System;
using System.Threading.Tasks;


namespace Domain.Persistent.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        readonly IEntityFrameworkDataContext _context;
        public EfUnitOfWork(IEntityFrameworkDataContext context)
        {
            _context = context;
            UserRepository = new UserRepository(context);
        }

        public IUserRepository UserRepository { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IUnitOfWork CreateNewInstance()
        {
            return new EfUnitOfWork(_context.CreateNewInstance());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}