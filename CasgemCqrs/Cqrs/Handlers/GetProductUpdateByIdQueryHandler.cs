using CasgemCqrs.Cqrs.Queries;
using CasgemCqrs.Cqrs.Results;
using CasgemCqrs.DAL;

namespace CasgemCqrs.Cqrs.Handlers
{
    public class GetProductUpdateByIdQueryHandler
    {
        private readonly Context _context;

        public GetProductUpdateByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateByIdQueryResult Handle(GetProductUpdateByIdQuery query)
        {
            var value = _context.Products.Find(query.Id);
            return new GetProductUpdateByIdQueryResult
            {
                ProductId = value.ProductId,
                Category = value.Category,
                Name = value.Name,
                Price = value.Price,
                Stock = value.Stock,
                Brand = value.Brand
            };
        }
    }
}
