using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService _productService) : ControllerBase
{
    private readonly IProductService productService = _productService;

    [HttpPost]
    public async Task<Response<string>> AddAsync(ProductDto dto)
    {
        return await productService.AddAsync(dto);
    }

    [HttpGet]
    public async Task<Response<List<Product>>> GetAllAsync()
    {
        return await productService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        return await productService.GetByIdAsync(id);
    }
}