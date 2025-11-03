using Microsoft.AspNetCore.Mvc;
using BuyTogether.Services.Interfaces;

namespace BuyTogether.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) => _productService = productService;

        public async Task<IActionResult> Index(string q)
        {
            var products = await _productService.GetAllActiveAsync(q);
            ViewBag.Query = q;
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}