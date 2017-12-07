using Microsoft.EntityFrameworkCore;
using SM.Domain.Persistent.EF;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Persistent.EF
{
    public abstract class BaseRepository<TEntity, TState>
        where TState : class
    {

        protected readonly IEntityFrameworkDataContext Context;
        protected readonly IEntityFrameworkDbSet<TState> Set;

        protected abstract TEntity Create(TState state);

        protected async Task<TEntity> CreateAsync(Task<TState> stateTask)
        {
            return Create(await stateTask);
        }

        protected async Task<TEntity[]> CreateArrayAsync(Task<TState[]> stateTask)
        {
            var states = await stateTask;
            return states.Select(Create).ToArray();
        }

        protected virtual Task<T> FirstOrDefaultAsync<T>(IQueryable<T> states)
        {
            return states.FirstOrDefaultAsync();
        }

        protected virtual Task<T> FirstAsync<T>(IQueryable<T> states, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return states.FirstAsync();
            }
            return states.FirstAsync(predicate);
        }

        public BaseRepository(IEntityFrameworkDataContext context)
        {
            Set = context.DbSet<TState>();
            Context = context;
        }
    }
}