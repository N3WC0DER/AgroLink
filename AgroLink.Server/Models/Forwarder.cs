using System.ComponentModel.DataAnnotations.Schema;

namespace AgroLink.Server.Models
{
    [Table("Forwarders")]
    public class Forwarder : User 
    {
        public required byte[] Photo { get; set; }
        public required List<Truck> Trucks { get; set; }
    }
}
