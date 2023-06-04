using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaptopTieuLuan.Models
{
    public class Laptop
    {
        [Key]
        public int LaptopId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string price { get; set; }

        [Required]
        public int price_real { get; set; }

        [Required]
        public string series { get; set; }

        [Required]
        public string past_price { get; set; }

        [Required]
        public string cpu { get; set; }

        [Required]
        public string cpu_compact { get; set; }

        [Required]
        public string ram { get; set; }

        [Required]
        public string ram_compact { get; set; }

        [Required]
        public string memory_compact { get; set; }

        [Required]
        public string card { get; set; }

        [Required]
        public string screen { get; set; }

        [Required]
        public string screen_compact { get; set; }

        [Required]
        public string link_img { get; set; }

        public int TrademarkId { get; set; }

        public virtual Trademark Trademark { get; set; }
    }
}
