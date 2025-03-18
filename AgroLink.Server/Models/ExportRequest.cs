namespace AgroLink.Server.Models
{
    public class ExportRequest
    {
        public required int Id { get; set; }

        public required Supplier Supplier { get; set; }

        public required DateTime DateTime { get; set; }

        public required ExportStatus Status { get; set; }

        public required Product Product { get; set; }
        
        public required int Amount { get; set; }

        public required Truck Truck { get; set; }

        public required byte[] Photo {  get; set; }
        
    }

    public enum ExportStatus
    {
        Active,
        InProcessing,
        SentForDelivery,
        Closed
    }

}
