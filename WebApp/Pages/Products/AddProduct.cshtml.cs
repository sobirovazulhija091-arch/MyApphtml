using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.AddProduct
{
    public class AddProductModel : PageModel
    {
        private readonly IProductService _service;

        public AddProductModel(IProductService service)
        {
            _service = service;
        }
        [BindProperty]
        public ProductDto dto { get; set; } = new();
        public async Task<IActionResult> OnPostAsync()
        {
            await _service.AddAsync(dto);
         return RedirectToPage("/Products/GetProduct");
        }
    }
}