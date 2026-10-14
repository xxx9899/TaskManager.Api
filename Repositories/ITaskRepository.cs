using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<List<TaskItem>> GetByUserIdAsync(int userId);
        Task<List<TaskItem>> GetByCategoryIdAsync(int categoryId);
        Task<List<TaskItem>> GetUncompletedAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
