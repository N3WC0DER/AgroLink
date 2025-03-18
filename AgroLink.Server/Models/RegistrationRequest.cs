namespace AgroLink.Server.Models
{
    public class RegistrationRequest
    {

        public required int Id { get; set; }
        public required string Name { get; set; }

        public required string Location { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required DateTime DateTime { get; set; }
        public required string? LinkEndpoint { get; set; }
    
    }
}
