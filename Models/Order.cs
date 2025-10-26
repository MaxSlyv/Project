namespace project.Models
{
    public class Order
    {
        public int Id_order { get; set; }
        public DateTime Order_date { get; set; }
        public int Id_client { get; set; }
        public int Id_employee { get; set; }
        public required Client Client { get; set; }
        public required Employee Employee { get; set; }
    }
}
