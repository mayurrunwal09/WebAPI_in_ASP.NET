using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Models.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }
       public DbSet<Movie> Movies { get; set; }
    }
}
