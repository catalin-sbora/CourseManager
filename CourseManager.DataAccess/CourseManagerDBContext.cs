using CourseManager.ApplicationLogic.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.DataAccess
{
    public class CourseManagerDbContext: DbContext
    {
        public CourseManagerDbContext(DbContextOptions<CourseManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseGrade> CourseGrades { get; set; }
        public DbSet<CoursePresence> CoursePresences { get; set; }
    }
}
