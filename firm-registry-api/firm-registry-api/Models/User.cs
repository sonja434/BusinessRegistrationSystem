using firm_registry_api.Models.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace firm_registry_api.Models
{
    public class User
    {
        public int Id { get; set; }                    
        public string FirstName { get; set; }        
        public string LastName { get; set; }      
        public string JMBG { get; set; }               
        public DateTime DateOfBirth { get; set; }       
        public Gender Gender { get; set; }          
        public string Residence { get; set; }      
        public string Username { get; set; }       
        public string Email { get; set; }     
        public string PasswordHash { get; set; } 
        public UserRole Role { get; set; } = UserRole.User;

        public bool IsValidJMBG()
        {
            if (string.IsNullOrWhiteSpace(JMBG)) return false;
            if (JMBG.Length != 13) return false;
            if (!long.TryParse(JMBG, out _)) return false;

            int day = int.Parse(JMBG.Substring(0, 2));
            int month = int.Parse(JMBG.Substring(2, 2));
            int year = int.Parse(JMBG.Substring(4, 3));
            year += year >= 900 ? 1000 : 2000;

            try
            {
                var date = new DateTime(year, month, day);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool IsValidDateOfBirth()
        {
            if (DateOfBirth < new DateTime(1, 1, 1)) return false;
            if (DateOfBirth > DateTime.Now) return false;
            return true;
        }
    }
}
