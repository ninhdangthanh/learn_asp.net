namespace RelationalDatabaseExample.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public User User { get; set; }
        public Customer Customer{ get; set; }
    }
}
