using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstIdentity.Data
{
    [Table("Product")]
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
