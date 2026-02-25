using System.Net;
using Microsoft.EntityFrameworkCore;
public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> AddAsync(ProductDto dto)
    {
         var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId= dto.CategoryId
        };
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Add Successfully");
    }

    public async Task<Response<List<Product>>> GetAllAsync()
    {
        return new Response<List<Product>>(HttpStatusCode.OK,"OK",await context.Products.ToListAsync());
    }

    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        var find = await context.Products.FindAsync(id);
        if (find == null)
        {
        return new Response<Product>(HttpStatusCode.NotFound,"Not Found");
        }
        return new Response<Product>(HttpStatusCode.OK,"OK",find);
    }
}