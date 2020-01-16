using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Data
{

    public class HotelsDBContext : DbContext
    {
        protected IConfigurationRoot configuration;
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookIn> BookIns { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public HotelsDBContext ()     {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployeeCustomers>().HasOne(x => x.Employee).WithMany(x => x.EmployeeCustomers).OnDelete(DeleteBehavior.Restrict);
            // modelBuilder.Entity<EmployeeCustomers>().HasOne(x => x.Customer).WithMany(x => x.EmployeeCustomers).OnDelete(DeleteBehavior.Cascade);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             //optionsBuilder.UseSqlServer("HotelsDB": "server=DESKTOP-EETQ29P;database=HotelsDB;");
            configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public override int SaveChanges()
        {

            return this.SaveChanges(true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyEntityChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        private void ApplyEntityChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is ICMDat && x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified).ToList();

            foreach (var entry in entries)
            {
                var entity = (ICMDat)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entity.DeletedAt = DateTime.Now;

                }
                else
                {
                    entity.ModifiedAt = DateTime.Now;
                }
            }
        }
    }
}
