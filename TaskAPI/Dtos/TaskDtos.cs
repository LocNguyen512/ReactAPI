namespace TaskApi.Dtos;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = default!;
}

// DTO cho việc thêm task mới
public class CreateTaskDto
{
    public string Title { get; set; } = default!;
    public DateTime? DueDate { get; set; }
    // Status sẽ được Service tự set là "Đang làm"
}

// DTO cho việc cập nhật task (có thể sửa Title, DueDate hoặc Status)
public class UpdateTaskDto
{
    public string Title { get; set; } = default!;
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = default!; // Phải gửi Status lên để cập nhật
}