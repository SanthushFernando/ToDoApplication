using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
