namespace CasgemCqrs.Cqrs.Commands
{
    public class CreatProductCommand
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Stock { get; set; }
    }
}
