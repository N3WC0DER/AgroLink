namespace AgroLink.Server.Models
{
    public class Supplier
    {

        public required DateTime Birtdate { get; set; }
        public required List<Product> Products { get; set; }

    
    }
}
