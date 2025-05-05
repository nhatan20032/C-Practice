namespace CSharpPracice_1.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Category { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateAt { get; set; }
        public string? ImagePath { get; set; }        
    }
}
