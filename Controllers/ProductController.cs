using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTOs;

namespace ECommerce.Controllers
{
	[Route("[controller]")]
	public class ProductController : Controller
	{
		private readonly IProductsService _productsService;
		private readonly ICategoriesService _categoriesService;
        public ProductController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }
        public async Task<IActionResult> Index(string searchQuery)
		{
			List<ProductDTO> products = await _productsService.GetAllProducts(searchQuery);
			return RedirectToAction("Index", "Category", products);
		}
		[Route("/{id}")]
		public async Task<IActionResult> Detail(int id)
		{
			ProductDTO? product = await _productsService.GetProductById(id);
			CategoryDTO? category = await _categoriesService.GetCategoryByName(product.TenLoai);
			if (product == null)
			{
				TempData["Message"] = "Product not found!";
                return Redirect("/404");
			}
			ViewBag.CategoryName = (category != null) ? category.TenLoai : "";
			return View(product);
		}
	}
}
