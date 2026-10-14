using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<TaskItem>> GetByUserIdAsync(int userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task<List<TaskItem>> GetUncompletedAsync()
        {
            return await _repository.GetUncompletedAsync();
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            await _repository.AddAsync(task);
            return task;
        }

        public async Task<bool> UpdateAsync(int id, TaskItem task)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.CategoryId = task.CategoryId;
            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repository.ExistsAsync(id)) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> ToggleCompleteAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null) return false;

            task.IsCompleted = !task.IsCompleted;
            await _repository.UpdateAsync(task);
            return true;
        }
    }
}
