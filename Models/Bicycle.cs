namespace project.Models
{
    public class Bicycle
    {
        public int Id_bicycle { get; set; }
        public required string Model_name { get; set; }
        public int Id_brand { get; set; }
        public required string Type1 { get; set; }
        public required string Frame_size { get; set; }
        public required string Frame_material { get; set; }
        public int Gear_count { get; set; }
        public decimal Price { get; set; }
        public int Stock_quantity { get; set; }
        public required Brand Brand { get; set; }
    }
}

