namespace AgroLink.Server.Models
{
    public class Truck
    {

        public required int Id { get; set; }
        public required string Brand { get; set; }
        public required int Capacity { get; set; }

        public required TruckStatus Status { get; set; }
        public required List<Product> Products { get; set; }

    }
    public enum TruckStatus
    {
        InServicing,
        Ok
    }
}
