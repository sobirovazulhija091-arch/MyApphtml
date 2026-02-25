using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.GetProduct;

public class GetProductModel : PageModel
{
    public List<Product> product { get; set; } = new();  

     private readonly IProductService _service;

        public GetProductModel(IProductService service)
        {
            _service = service;
        }
    public async Task OnGetAsync()
    {
        var result = await _service.GetAllAsync();
         product = result.Data ?? new List<Product>();
         
    }
}