namespace VeryInterestingApiBackend.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> Ingredients { get; set; }
        public string? Description { get; set; }
    }
}
