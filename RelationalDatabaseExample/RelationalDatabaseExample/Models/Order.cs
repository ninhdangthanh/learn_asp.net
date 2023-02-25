using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationalDatabaseExample.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
