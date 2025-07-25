using Microsoft.EntityFrameworkCore;
using TimeManagemetApp.Models.Models;

namespace TimeManagemetApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
    }
}
