using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class DbModel : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentClassCourse> StudentClassCourses { get; set; }
        public DbSet<StudentTest> StudentTests { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }

    }

}
