using Microsoft.EntityFrameworkCore;
using TaskApi.Dtos;
using TaskApi.Interfaces;
using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    // =================================================================
    // 1. READ ALL (với logic LỌC theo Status)
    // =================================================================
    public async Task<IEnumerable<TaskDto>> GetAllAsync(string? status)
    {
        // Lấy IQueryable từ Repository
        var query = _taskRepository.GetQueryable();

        // Logic lọc theo trạng thái
        if (!string.IsNullOrEmpty(status) && status.ToLower() != "tất cả") // Sửa ToLowerInvariant() -> ToLower()
        {
            // status không phân biệt chữ hoa/thường
            var normalizedStatus = status.ToLower(); // Sửa ToLowerInvariant() -> ToLower()
            
            // Sửa ToLowerInvariant() -> ToLower() để có thể dịch sang SQL
            query = query.Where(t => t.Status.ToLower() == normalizedStatus); 
        }

        // Sắp xếp theo ID giảm dần (task mới nhất lên đầu)
        var tasks = await query.OrderByDescending(t => t.Id).ToListAsync(); 

        // Chuyển đổi Model sang DTO
        return tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            DueDate = t.DueDate,
            Status = t.Status
        }).ToList();
    }
    
    // ... Phần còn lại của TaskService không thay đổi ...

    // =================================================================
    // 2. READ BY ID
    // =================================================================
    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        if (task == null) return null;

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            DueDate = task.DueDate,
            Status = task.Status
        };
    }

    // =================================================================
    // 3. CREATE (Tạo Task mới)
    // =================================================================
    public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
    {
        // Ánh xạ DTO sang Model
        var taskItem = new TaskItem
        {
            Title = dto.Title,
            DueDate = dto.DueDate,
            // Status mặc định là "Working" như yêu cầu bài tập
            Status = "Working" 
        };

        var createdTask = await _taskRepository.AddAsync(taskItem);

        // Ánh xạ Model kết quả sang DTO để trả về cho Controller
        return new TaskDto
        {
            Id = createdTask.Id,
            Title = createdTask.Title,
            DueDate = createdTask.DueDate,
            Status = createdTask.Status
        };
    }

    // =================================================================
    // 4. UPDATE (Cập nhật Task)
    // =================================================================
    public async Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var existingTask = await _taskRepository.GetByIdAsync(id);
        if (existingTask == null) 
        {
            return null; // Không tìm thấy Task để cập nhật
        }

        // Cập nhật các trường từ DTO
        existingTask.Title = dto.Title;
        existingTask.DueDate = dto.DueDate;
        // Cho phép cập nhật trạng thái (để chuyển từ Đang làm sang Hoàn thành và ngược lại)
        existingTask.Status = dto.Status; 

        await _taskRepository.UpdateAsync(existingTask);

        // Trả về DTO của Task đã cập nhật
        return new TaskDto
        {
            Id = existingTask.Id,
            Title = existingTask.Title,
            DueDate = existingTask.DueDate,
            Status = existingTask.Status
        };
    }

    // =================================================================
    // 5. DELETE (Xóa Task)
    // =================================================================
    public async Task<bool> DeleteAsync(int id)
    {
        var existingTask = await _taskRepository.GetByIdAsync(id);
        if (existingTask == null)
        {
            return false; // Không tìm thấy Task để xóa
        }
        
        // Gọi Repository để thực hiện xóa
        await _taskRepository.DeleteAsync(id);
        
        return true; // Xóa thành công
    }
}