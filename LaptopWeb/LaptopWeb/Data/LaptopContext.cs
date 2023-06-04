using LaptopWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopWeb.Data
{
    public class LaptopContext : DbContext
    {
        public LaptopContext(DbContextOptions<LaptopContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Trademark> Trademarks { get; set; }
        public DbSet<Laptop> Laptops{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
