using RelationalDatabaseExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.EnrollmentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Customer)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(b => b.Orders)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

        }
    }
}
