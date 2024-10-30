using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTOs;

namespace ECommerce.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly Hshop2023Context _db;
        private readonly ICategoriesService _categoriesService;
        
        public CategoryViewComponent(Hshop2023Context context, ICategoriesService categoriesService)
        {
            _db = context;
            _categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryDTO> categories = await _categoriesService.GetAllCategories();
            return View(categories);
        }
    }
}
