namespace AgroLink.Server.Models
{
    public class Product
    {
        public required int Id { get; set; }

        public required ProductKind Kind { get; set; }

        public required String Name { get; set; }

        public required MeasurementUnit Unit { get; set; }
    }
}
