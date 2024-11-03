using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTOs;

namespace ECommerce.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task<IActionResult> Index(string searchQuery)
		{
			List<ProductDTO> products = await _productsService.GetAllProducts(searchQuery);
			return RedirectToAction("Index", "Category", products);
		}
	}
}
