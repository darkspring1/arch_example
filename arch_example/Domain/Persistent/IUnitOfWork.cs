using System;
using System.Threading.Tasks;

namespace Domain.Persistent
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        
        void Complete();

        Task CompleteAsync();

        /// <summary>
        /// для парелельных запросов в ef core
        /// </summary>
        /// <returns></returns>
        IUnitOfWork CreateNewInstance();
    }
}
