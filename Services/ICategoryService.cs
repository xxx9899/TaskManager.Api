using TaskManager.Api.Models;

namespace TaskManager.Api.Services
{
    public interface  ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<bool> UpdateAsync(int id, Category category);
        Task<bool> DeleteAsync(int id);
    }
}
