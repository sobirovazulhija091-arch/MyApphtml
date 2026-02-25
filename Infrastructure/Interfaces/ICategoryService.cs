public interface ICategoryService
{
        Task<Response<string>> AddAsync(CategoryDto dto);
        // Task<Response<string>> UpdateAsync(int id, UpdateCategoryDto dto);
        Task<Response<string>> DeleteAsync(int id);
        Task<Response<List<Category>>> GetAllAsync();
        Task<Category> GetByIdAsync(int id); 
}