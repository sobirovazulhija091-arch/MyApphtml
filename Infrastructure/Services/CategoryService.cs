using System.Net;
using Microsoft.EntityFrameworkCore;
public class CategoryService(ApplicationDbContext dbContext):ICategoryService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<Response<string>> AddAsync(CategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
        };
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Add Successfully");
    }

    public async Task<Response<List<Category>>> GetAllAsync()
    {
       return new Response<List<Category>>(HttpStatusCode.OK,"OK",await context.Categories.ToListAsync());
    }

    public async Task<Response<Category>> GetByIdAsync(int id)
    {
       var find = await context.Categories.FindAsync(id);
        if (find == null)
        {
        return new Response<Category>(HttpStatusCode.NotFound,"Not Found");
        }
        return new Response<Category>(HttpStatusCode.OK,"OK",find);
    }
}