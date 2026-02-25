
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.GetByIdCategory
{
    public class GetByIdCategoryModel(ICategoryService productService) : PageModel
    {
        private readonly ICategoryService service = productService;
        public Category category { get; set; } = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var result = await service.GetByIdAsync(id);
                 return Page();
        }
        
    }
    
}
