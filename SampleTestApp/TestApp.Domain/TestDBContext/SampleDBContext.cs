using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.User;

namespace TestApp.Domain.TestDBContext
{
    public class SampleDBContext:DbContext
    {
        public DbSet<User.User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserGroup.UserGroup> UserGroups { get; set; }
        public DbSet<UserGroup.AccessRule> AccessRules { get; set; }
        public DbSet<UserGroup.UserGroupAccessRule> UserGroupAccessRules { get; set; }
        public SampleDBContext(DbContextOptions<SampleDBContext> options)
     : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server with connection string from app settings
        //    options.UseSqlServer(Configuration.GetConnectionString(""));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().ToTable("User")
             .HasDiscriminator<int>("UserTypeId")
             .HasValue<User.User>(1)
             .HasValue<Admin>(2);

            modelBuilder.Entity<UserGroup.UserGroupAccessRule>().ToTable("UserGroupAccessRule").HasKey(k => new { k.UserGroupId, k.AccessRuleId });


        }
    }
}
