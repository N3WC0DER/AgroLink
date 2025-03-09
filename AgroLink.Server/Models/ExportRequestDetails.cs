namespace AgroLink.Server.Models
{
    public class ExportRequestDetails
    {

        public required int Id { get; set; }

        public required int RequestId { get; set; }

        public required int ProductId { get; set; }

        public required int Amount { get; set; }
    }
}
