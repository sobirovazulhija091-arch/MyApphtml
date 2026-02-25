using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    private readonly  ICategoryService categoryService = _categoryService;

    [HttpPost]
    public async  Task<Response<string>> AddAsync(CategoryDto dto)
    {
          return await categoryService.AddAsync(dto);
    }

    [HttpGet]
    public async  Task<Response<List<Category>>> GetAllAsync()
    {
         return await categoryService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async  Task<Category> GetByIdAsync(int id)
    {
        return await categoryService.GetByIdAsync(id);
    }
     [HttpDelete]
     public async  Task<Response<string>> DeleteAsync(int id)
    {
        return await categoryService.DeleteAsync(id);
    }
}