using Microsoft.EntityFrameworkCore;

namespace webapi3.Model
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
