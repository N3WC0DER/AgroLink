namespace AgroLink.Server.Models
{
    public class ExportRequest
    {
        public required int Id { get; set; }

        public required int UserId { get; set; }

        public required DateTime DateTime { get; set; }

        public required ExportStatus Status { get; set; }

           
    }

    public enum ExportStatus
    {
        Active,
        InProcessing,
        SentForDelivery,
        Closed
    }

}
