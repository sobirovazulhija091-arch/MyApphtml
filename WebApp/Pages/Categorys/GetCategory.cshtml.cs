using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.GetCategory;

public class GetCategoryModel : PageModel
{
    public List<Category> categories { get; set; } = new();  

     private readonly ICategoryService _service;

        public GetCategoryModel(ICategoryService  service)
        {
            _service = service;
        }
    public async Task OnGetAsync()
    {
        var result = await _service.GetAllAsync();
        categories = result.Data ?? new List<Category>();
         
    }
}