using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopWeb.Models
{
    public class Trademark
    {
        [Key]
        public int TrademarkId { get; set; }

        [Required]
        [Column("TrademarkName")]
        [Display(Name = "Hãng Laptop")]
        public string TrademarkName { get; set; }

        public ICollection<Laptop> Laptops { get; set; }
    }
}
