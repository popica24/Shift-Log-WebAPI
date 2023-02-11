using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ShiftLogger.Models
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        
    }
}
