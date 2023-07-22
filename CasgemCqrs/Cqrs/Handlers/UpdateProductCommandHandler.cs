using CasgemCqrs.Cqrs.Commands;
using CasgemCqrs.DAL;
using Microsoft.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace CasgemCqrs.Cqrs.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
               var values= _context.Products.Find(command.ProductId);
                values.Brand = command.Brand;
               values.Category = command.Category;
               values.Name = command.Name;
               values.Price = command.Price;
               values.ProductId = command.ProductId;
               values.Stock = command.Stock;
               _context.SaveChanges();
        }
    }
}
