using System.ComponentModel.DataAnnotations.Schema;

namespace AgroLink.Server.Models
{
    [Table("Suppliers")]
    public class Supplier : User
    {

        public required DateTime? Birtdate { get; set; }
        public required List<Product> Products { get; set; }

    
    }
}
