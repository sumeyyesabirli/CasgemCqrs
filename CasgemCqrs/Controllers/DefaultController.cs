using CasgemCqrs.Cqrs.Commands;
using CasgemCqrs.Cqrs.Handlers;
using CasgemCqrs.Cqrs.Queries;
using CasgemCqrs.Cqrs.Results;
using Microsoft.AspNetCore.Mvc;

namespace CasgemCqrs.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreatProductCommandHandler _creatProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetPoductByIdQueryHandler _getPoductByIdQueryHandler;
        private readonly GetProductUpdateByIdQueryHandler _getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;


        public DefaultController(GetProductQueryHandler getProductQueryHandler,
            CreatProductCommandHandler creatProductCommandHandler,
            RemoveProductCommandHandler removeProductCommandHandler,
            GetPoductByIdQueryHandler getPoductByIdQueryHandler,
            GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler,
            UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _creatProductCommandHandler = creatProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getPoductByIdQueryHandler = getPoductByIdQueryHandler;
            _getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
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
        public IActionResult GetProduct(GetPoductByIdQueries queries )
        {
            var values = _getPoductByIdQueryHandler.Handle(queries);
            return View(values);
        }
        [HttpGet]
        public IActionResult GetProductUpdate(int id)
        {
            var values = _getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
