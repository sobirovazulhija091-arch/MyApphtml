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

    public async  Task<Category> GetByIdAsync(int id)
    {
       var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
           return category;
    }
    public async  Task<Response<string>> DeleteAsync(int id)
    {
          var category = await context.Categories.FindAsync(id);

    if (category == null)
    {
        return new Response<string>(HttpStatusCode.NotFound,"Category not found");
    }
    context.Categories.Remove(category);
    await context.SaveChangesAsync();
      return new Response<string>(HttpStatusCode.OK,"Deleted successfull");
    }
   public async Task<Response<string>> UpdateAsync(int id, UpdateCategoryDto dto)
    {
         var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        category.Name=dto.Name;
        category.Description=dto.Description;
         await context.SaveChangesAsync();
         return new Response<string>(HttpStatusCode.OK,"Update successfully");
    }
}