namespace BulkyBookWeb.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
