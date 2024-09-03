using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
    {
        
    }
    public DbSet<TodoItem> TodoItems { get; set; }

    
}