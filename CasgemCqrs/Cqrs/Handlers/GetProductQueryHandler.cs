using CasgemCqrs.Cqrs.Results;
using CasgemCqrs.DAL;

namespace CasgemCqrs.Cqrs.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x=>new GetProductQueryResult
            {
                Brand= x.Brand,
                Category= x.Category,
                Name= x.Name,
                Price= x.Price,
                ProductId= x.ProductId,
                Stock= x.Stock,
                
            }).ToList();
            return values;
        }
    }
}
