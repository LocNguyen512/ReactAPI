namespace TaskApi.Models;

public class TaskItem
{
    public int Id { get; set; }
    // Tên task. Bắt buộc.
    public string Title { get; set; } = default!; 
    
    // Ngày hết hạn. Cho phép null.
    public DateTime? DueDate { get; set; } 
    
    // Trạng thái: "Đang làm" (Working) hoặc "Hoàn thành" (Completed)
    public string Status { get; set; } = "Working"; 
}