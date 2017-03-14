using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_DomainEntities;

namespace MVC_DAL
{
    //public class StoreContext : DbContext;
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext()
            : base("name=StoreContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<Logger> Loggers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<StoreContext>(null);            

            //Used When Creating New Database on Statup
            Database.SetInitializer<StoreContext>(new CreateDatabaseIfNotExists<StoreContext>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            //Change the names of default asp.net identity tables
            modelBuilder.Entity<User>()
                .ToTable("User");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }
    }
}
