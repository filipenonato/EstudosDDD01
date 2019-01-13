using MyStore.Domain.Account.Entities;
using MyStore.Infrastructure.Persistence.Mappings;
using System.Data.Entity;

namespace MyStore.Infrastructure.Persistence.Contexts
{
    public class MyStoreDataContext : DbContext
    {
        public MyStoreDataContext() : base("MyStoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Configurations.Add(new UserMapping());
        }
    }
}
