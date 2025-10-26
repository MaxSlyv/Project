namespace project.Models
{
    public class Client
    {
        public int Id_client { get; set; }
        public required string Full_name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
    }
}
