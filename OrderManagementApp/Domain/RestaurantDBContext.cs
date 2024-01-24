using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "Data Source=SID\\SQLEXPRESS;Initial Catalog=OrderManagementDb; Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
