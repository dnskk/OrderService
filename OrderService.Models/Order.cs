namespace OrderService.Models
{
    /// <summary>
    /// Order entity.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public string[] Products { get; set; }

        public decimal Price { get; set; }

        public int PostamatId { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerFullName { get; set; }
    }
}
