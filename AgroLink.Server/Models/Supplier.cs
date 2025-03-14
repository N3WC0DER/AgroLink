namespace AgroLink.Server.Models
{
    public class Supplier : User
    {

        public required DateTime? Birtdate { get; set; }
        public required List<Product> Products { get; set; }

    
    }
}
