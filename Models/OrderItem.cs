namespace project.Models
{
    public class OrderItem
    {
        public int Id_order_item { get; set; }
        public int Id_order { get; set; }
        public int Id_bicycle { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public required Order Order { get; set; }
        public required Bicycle Bicycle { get; set; }
    }
}
