using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.models;

namespace ProductAppAsync.src.config
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<User> Profile { get; set; }

    

       

    }
}
