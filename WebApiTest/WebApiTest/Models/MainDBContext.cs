using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApiTest.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options) { }

        public DbSet<Student> Students { get; set; }    
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Enrollment>()
                        .HasOne(e => e.Student)
                        .WithMany(s=>s.Enrollments)
                        .HasForeignKey(e => e.StudenId);

            modelBuilder.Entity<Enrollment>()
                         .HasOne(e => e.Course)
                         .WithMany(c => c.Enrollments)
                         .HasForeignKey(e => e.CourseId);

          
        }
    }
}
