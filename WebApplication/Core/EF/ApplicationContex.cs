

using System;
using Faculty.Entities;
using Microsoft.EntityFrameworkCore;


namespace Faculty.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Semester>  Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FollowingStudent> FollowingStudents { get; set; }
        public DbSet<SessionMark> SessionMarks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            // Database.EnsureDeleted();
          //  Database.EnsureCreated();
        }
        
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("Host=localhost;Port=3306;Database=mydb_sharp;Username=tntrol;Password=password", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}