using CasgemCqrs.Cqrs.Commands;
using CasgemCqrs.DAL;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CasgemCqrs.Cqrs.Handlers
{
    public class CreatProductCommandHandler
    {
        private readonly Context _context;

        public CreatProductCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(CreatProductCommand command)
        {
           _context.Products.Add(new Product
            {
               Name = command.Name,
               Brand = command.Brand,
               Category = command.Category,
               Price = command.Price,
               Stock = command.Stock,

           });
            _context.SaveChanges();
        }
    }
}
