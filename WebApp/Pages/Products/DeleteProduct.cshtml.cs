using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.DeleteProduct
{
    public class DeleteProductModel(IProductService productService) : PageModel
    {
        private readonly IProductService service = productService;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(int id)
        {
            await service.DeleteAsync(id);
            return RedirectToPage("/Products/GetProduct");
        }
    }
}