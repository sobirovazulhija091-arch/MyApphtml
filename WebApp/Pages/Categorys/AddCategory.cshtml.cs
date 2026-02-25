using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.AddCategory
{
    public class AddCategoryModel : PageModel
    {
        private readonly ICategoryService _service;

        public AddCategoryModel(ICategoryService  service)
        {
            _service = service;
        }
        [BindProperty]
        public CategoryDto dto { get; set; } = new();
        public async Task<IActionResult> OnPostAsync()
        {
            await _service.AddAsync(dto);
         return RedirectToPage("/Categorys/GetCategory");
        }
    }
}