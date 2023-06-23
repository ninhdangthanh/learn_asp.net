using FirstApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApiProject.Data
{
    public class AppDbContext : DbContext
    {
           public AppDbContext(DbContextOptions options) : base(options) { }


            public DbSet<Contact> Contacts { get; set; }
    }
}
