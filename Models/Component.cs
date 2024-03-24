namespace JunkWebApi.Models
{
    public class Component 
    {
        public int Id { get; set; }
        public string  Name { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}
