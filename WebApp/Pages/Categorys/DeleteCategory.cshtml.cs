using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.DeleteCategory
{
    public class DeleteCategoryModel(ICategoryService categoryService) : PageModel
    {
        private readonly ICategoryService service = categoryService;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(int id)
        {
            await service.DeleteAsync(id);
            return RedirectToPage("/Categorys/GetCategory");
        }
    }
}