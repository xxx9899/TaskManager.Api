using TaskManager.Api.Models;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            // 这里以后可以加业务逻辑，比如检查邮箱是否重复
            await _repository.AddAsync(user);
            return user;
        }

        public async Task<bool> UpdateAsync(int id, User user)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Username = user.Username;
            existing.Email = user.Email;
            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repository.ExistsAsync(id)) return false;
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
