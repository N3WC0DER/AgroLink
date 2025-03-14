namespace AgroLink.Server.Models
{
    public class Forwarder : User 
    {
        public required byte[] Photo { get; set; }
        public required List<Truck> Trucks { get; set; }
    }
}
