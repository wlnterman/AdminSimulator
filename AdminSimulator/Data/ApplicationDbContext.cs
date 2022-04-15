using AdminSimulator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSimulator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> AppUsers { get; set; } //Users
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("" +
                "Host=ec2-52-30-67-143.eu-west-1.compute.amazonaws.com;" +
                "Port=5432;" +
                "Database=dehep17tvubrp5;" +
                "Username=gxsjgrvjkfhlhz;" +
                "Password=abfbc336ffd5c3c0a84ce64b21ff3a0b2399dd480d70d8d6777ccb5f6ff6973e;" +
                "sslmode=Require;" +
                "Trust Server Certificate=true;");
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres");
        }
        public ApplicationDbContext()
            : base()
        {
        }
    }
}
