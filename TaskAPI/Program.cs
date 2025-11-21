using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Interfaces; // Thêm: Import Interfaces
using TaskApi.Repositories; // Thêm: Import Repositories
using TaskApi.Services; 
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Đặt tên cho chính sách CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 

// 1. THÊM CẤU HÌNH CORS VÀO SERVICES
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Cho phép truy cập từ địa chỉ Frontend React (mặc định là 5173)
                          policy.WithOrigins("http://localhost:5173") 
                                .AllowAnyHeader()
                                .AllowAnyMethod(); // Cho phép các phương thức GET, POST, PUT, DELETE
                      });
});

// Add services to the container.
// Bổ sung các dịch vụ cho Swagger:
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// Thêm: Cho phép ứng dụng sử dụng Controllers để xử lý API
builder.Services.AddControllers();

// 1. Lấy Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

// 2. Đăng ký DbContext
builder.Services.AddDbContext<AppDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// 3. ĐĂNG KÝ CẤU TRÚC 3 LỚP (Controller, Service, Repository)
// Đăng ký Repository Layer (Thao tác với DB)
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Đăng ký Service Layer (Chứa logic nghiệp vụ)
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // KÍCH HOẠT GIAO DIỆN SWAGGER UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// KÍCH HOẠT MIDDLEWARE CORS (Phải đặt trước app.MapControllers)
app.UseCors(MyAllowSpecificOrigins); 

// Cho phép ứng dụng định tuyến các lời gọi đến Controllers
app.MapControllers(); // Quan trọng: Đây là lệnh để sử dụng Controller bạn đã tạo

app.Run();