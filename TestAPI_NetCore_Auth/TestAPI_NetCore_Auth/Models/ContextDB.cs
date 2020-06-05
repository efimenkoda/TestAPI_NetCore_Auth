using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI_NetCore_Auth.Models
{
    public class ContextDB : DbContext
    {
        
        public ContextDB(DbContextOptions options) : base(options)
        {
           
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ivan = new AuthorizeUser() { Id = 1, Name = "Ivan", BirthDate = DateTime.Now, Amount = 1, };
            var petr = new AuthorizeUser() { Id = 2, Name = "Petr", BirthDate = DateTime.Now.AddDays(10), Amount = 2 };


            modelBuilder.Entity<AuthorizeUser>().HasData(
                new AuthorizeUser[]
                {
                    ivan, petr
                }
            );


            modelBuilder.Entity<Users>().HasData(
                new Users() { Id = 1, UserName = "Ivanov", Password = "12345", AuthorizeUserID = 1 },
                new Users() { Id = 2, UserName = "Petrov", Password = "123", AuthorizeUserID = 2 }

            );


        }
        public DbSet<Users> Users { get; set; }
        public DbSet<AuthorizeUser> AuthorizeUsers { get; set; }
    }
}
