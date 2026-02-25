
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.GetByIdProduct
{
    public class GetByIdProductModel(IProductService productService) : PageModel
    {
        private readonly IProductService service = productService;
        public Product product { get; set; } = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var result = await service.GetByIdAsync(id);
                 return Page();
        }
    }
    
}
