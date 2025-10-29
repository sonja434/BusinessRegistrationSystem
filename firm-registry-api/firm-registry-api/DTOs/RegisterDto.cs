using firm_registry_api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace firm_registry_api.DTOs
{
    public class RegisterDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "JMBG must have 13 digits.")]
        public string JMBG { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string Residence { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
    }
}
