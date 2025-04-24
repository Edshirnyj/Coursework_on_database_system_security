using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}