using CasgemCqrs.Cqrs.Commands;
using CasgemCqrs.Cqrs.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CasgemCqrs.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreatProductCommandHandler _creatProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler,
            CreatProductCommandHandler creatProductCommandHandler, 
            RemoveProductCommandHandler removeProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _creatProductCommandHandler = creatProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
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

        public IActionResult DeletePoduct(RemoveProductCommand commadn)
        {
            _removeProductCommandHandler.Handle(commadn);
            return RedirectToAction("Index");
        }
    }
}
