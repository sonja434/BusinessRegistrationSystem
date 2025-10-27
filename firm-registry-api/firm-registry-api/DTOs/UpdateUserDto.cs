namespace firm_registry_api.DTOs
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? JMBG { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Residence { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
    }
}
