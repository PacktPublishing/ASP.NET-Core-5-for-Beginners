using Microsoft.EntityFrameworkCore;

namespace ToDo.RazorPages.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
