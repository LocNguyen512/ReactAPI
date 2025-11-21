using TaskApi.Models;

namespace TaskApi.Interfaces;

public interface ITaskRepository
{
    // Các hàm CRUD cơ bản
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);

    // Hàm Lọc mở rộng (Sẽ được gọi từ Service)
    IQueryable<TaskItem> GetQueryable();
}