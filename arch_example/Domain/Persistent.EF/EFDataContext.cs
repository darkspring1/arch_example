using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Persistent.State;

namespace Domain.Persistent.EF
{
    public class EFDataContext : DbContext, IEntityFrameworkDataContext
    {
        const string schema = "public";


        readonly string _connectionString;

        public EFDataContext(string connectionString)
        {
            _connectionString = connectionString;
            /*
            Database.SetInitializer<EFDataContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            */
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"server=localhost;port=5432;database=SocialMass; user=postgres;password=postgres"
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password");

            //optionsBuilder.UseNpgsql("server=localhost;port=5432;database=SocialMass; user=postgres;password=postgres");
            optionsBuilder.UseNpgsql(_connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserState>().ToTable("Users", schema);
                
                //.HasRequired(t => t.Task)
                //.WithRequiredDependent();
        }
        /*
        public void ChangeObjectState(object entity, EntityState entityState)
        {
            var t = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(entity, entityState);
        }
        */
       

        public IEntityFrameworkDbSet<T> DbSet<T>() where T : class
        {
            return new EntityFrameworkDbSet<T>(Set<T>());
        }

        int IEntityFrameworkDataContext.SaveChanges()
        {
            return this.SaveChanges();
        }

        public IQueryable<T> Include<T>(IQueryable<T> source, params Expression<Func<T, object>>[] path) where T : class
        {
            foreach (var p in path) { source = source.Include(p); }
            return source;
        }

        Task<int> IEntityFrameworkDataContext.SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public IEntityFrameworkDataContext CreateNewInstance()
        {
            return new EFDataContext(_connectionString);
        }
    }
}
