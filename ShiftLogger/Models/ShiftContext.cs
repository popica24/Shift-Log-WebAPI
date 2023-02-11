using Microsoft.EntityFrameworkCore;
namespace ShiftLogger.Models
{
    public class ShiftContext : DbContext
    {
        public ShiftContext(DbContextOptions<ShiftContext> options) : base(options) { }
        public DbSet<ShiftModel> Shifts { get; set; }
    }
}
