namespace WebApplication4.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using WebApplication4.Models;

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
