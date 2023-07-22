namespace CasgemCqrs.Cqrs.Results
{
    public class GetProductUpdateByIdQueryResult
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Stock { get; set; }
    }
}
