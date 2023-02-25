using System.ComponentModel.DataAnnotations;

namespace RelationalDatabaseExample.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Contact { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
