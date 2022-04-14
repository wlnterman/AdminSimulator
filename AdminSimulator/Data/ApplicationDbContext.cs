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
            //Database.EnsureCreated();
        }
        public ApplicationDbContext()
            : base()
        {
        }
    }
}
