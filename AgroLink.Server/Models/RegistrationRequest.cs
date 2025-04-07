namespace AgroLink.Server.Models
{
    public enum RegistrationStatus
    {
        Opened,
        InProcessing,
        Closed
    }

    public class RegistrationRequest
    {
        public int Id { get; set; } = 0;
        public RegistrationStatus Status { get; set; } = RegistrationStatus.Opened;
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required DateTime DateTime { get; set; }
        public string? LinkEndpoint { get; set; }
    
    }
}
