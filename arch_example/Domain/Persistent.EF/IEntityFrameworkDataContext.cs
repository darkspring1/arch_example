﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Persistent.EF
{
    public interface IEntityFrameworkDataContext : IDisposable
    {
        IEntityFrameworkDbSet<T> DbSet<T>() where T : class;

        IQueryable<T> Include<T>(IQueryable<T> source, params Expression<Func<T, object>>[] path) where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();


        /// <summary>
        /// для парелельных запросов в ef core
        /// </summary>
        /// <returns></returns>
        IEntityFrameworkDataContext CreateNewInstance();
    }
}