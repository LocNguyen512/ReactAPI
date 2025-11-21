using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Khai báo DbSet cho TaskItem
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}