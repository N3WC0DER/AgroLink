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
            //Products.AddRange(
            //    new Product { Id = 1, Name = "Potato", KindName = "Vegetables", UnitName = "kg" },
            //    new Product { Id = 2, Name = "Apple", KindName = "Fruits", UnitName = "kg" },
            //    new Product { Id = 3, Name = "Banana", KindName = "Fruits", UnitName = "kg" }
            //);
            //ExportRequests.AddRange(
            //    new ExportRequest { Id = 1, UserId = 1, Status = "Active", DateTime = DateTime.Now },
            //    new ExportRequest { Id = 2, UserId = 2, Status = "InProgress", DateTime = DateTime.Now }
            //);

            //ExportRequestDetails.AddRange(
            //    new ExportRequestDetails { Id = 1, RequestId = 1, ProductId = 1, Amount = 1 },
            //    new ExportRequestDetails { Id = 2, RequestId = 1, ProductId = 2, Amount = 2 },
            //    new ExportRequestDetails { Id = 3, RequestId = 2, ProductId = 1, Amount = 1 },
            //    new ExportRequestDetails { Id = 4, RequestId = 2, ProductId = 1, Amount = 2 },
            //    new ExportRequestDetails { Id = 5, RequestId = 2, ProductId = 3, Amount = 3 }
            //);

            //SaveChanges();
        }
    }
}
