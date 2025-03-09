using AgroLink.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroLink.Server
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ExportRequest> ExportRequests { get; set; }
        public DbSet<ExportRequestDetails> ExportRequestDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
            // jrehfgerj
            // testt
        }
    }
}
