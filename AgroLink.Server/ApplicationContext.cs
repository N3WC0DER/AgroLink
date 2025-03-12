using AgroLink.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroLink.Server
{
    public class ApplicationContext : DbContext
    {
        public ILogger logger { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Forwarder> Forwarders { get; set; }
        public DbSet<ExportRequest> ExportRequests { get; set; }
        public DbSet<ExportRequestDetails> ExportRequestDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductKind> ProductKinds { get; set; }
        public DbSet<Truck> Trucks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
            
        }
        //проверить метод ApplicationContext
    }
}
