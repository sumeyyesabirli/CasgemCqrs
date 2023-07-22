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

        public IActionResult DeleteProduct(RemoveProductCommand command)
        {
            _removeProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(GetPoductByIdQueries query)
        {
            var values = _getPoductByIdQueryHandler.Handle(query);
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
