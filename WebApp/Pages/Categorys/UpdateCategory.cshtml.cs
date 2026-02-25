using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.UpdateCategory
{
    public class UpdateCategoryModel : PageModel
    {
           private readonly ICategoryService _service;

        public UpdateCategoryModel(ICategoryService service)
        {
            _service = service;
        }
         [BindProperty]
        public UpdateCategoryDto dto { get; set; } = new();

        // Загружаем данные по id
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null){return NotFound();}
        var  dto = new UpdateCategoryDto
            {
                Name = result.Name,
                Description = result.Description,
            };
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.UpdateAsync(id, dto);
            return RedirectToPage("/Products/GetProduct");
        }
    }
}