using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.UpdateProduct
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductService _service;

        public UpdateProductModel(IProductService service)
        {
            _service = service;
        }
        [BindProperty]
        public UpdateProductDto dto { get; set; } = new();

        // Загружаем данные по id
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null){return NotFound();}
        var  dto = new UpdateProductDto
            {
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                CategoryId = result.CategoryId
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