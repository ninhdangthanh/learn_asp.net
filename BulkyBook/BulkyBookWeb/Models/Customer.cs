using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

       
}
