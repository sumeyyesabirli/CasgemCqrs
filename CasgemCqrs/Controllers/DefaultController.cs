using CasgemCqrs.Cqrs.Commands;
using CasgemCqrs.Cqrs.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CasgemCqrs.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreatProductCommandHandler _creatProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, 
            CreatProductCommandHandler creatProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _creatProductCommandHandler = creatProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);    
                
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreatProductCommand command)
        {
            _creatProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
