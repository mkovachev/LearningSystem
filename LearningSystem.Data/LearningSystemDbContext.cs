using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(st => new { st.CourseId, st.StudentId });

            builder
                .Entity<StudentCourse>()
                .HasOne(st => st.Student)
                .WithMany(c => c.Courses)
                .HasForeignKey(st => st.StudentId);

            builder
               .Entity<StudentCourse>()
               .HasOne(c => c.Course)
               .WithMany(st => st.Students)
               .HasForeignKey(c => c.CourseId);

            base.OnModelCreating(builder);        
        }
    }
}
