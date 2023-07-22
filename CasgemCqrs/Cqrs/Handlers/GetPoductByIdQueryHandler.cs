using CasgemCqrs.Cqrs.Commands;
using CasgemCqrs.Cqrs.Queries;
using CasgemCqrs.Cqrs.Results;
using CasgemCqrs.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CasgemCqrs.Cqrs.Handlers
{
    public class GetPoductByIdQueryHandler
    {
        private readonly Context _context;

        public GetPoductByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetPoductByIdQueryResult Handle(GetPoductByIdQueries query)
        {
            var values = _context.Products.Find(query.Id);
            return new GetPoductByIdQueryResult
            {
                ProductId = values.ProductId,
                ProductMark = values.Brand,
                ProductName = values.Name,
            };

        }
    }
}
