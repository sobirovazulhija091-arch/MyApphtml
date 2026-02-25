public interface IProductService
{
        Task<Response<string>> AddAsync(ProductDto dto);
        Task<Response<string>> UpdateAsync(int id, UpdateProductDto dto);
        Task<Response<string>> DeleteAsync(int id);
       Task<Response<List<Product>>> GetAllAsync();
        Task<Product> GetByIdAsync(int id); 

}