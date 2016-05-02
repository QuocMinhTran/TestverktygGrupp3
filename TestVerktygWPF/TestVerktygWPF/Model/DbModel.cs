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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Subjects> Subjectss { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Questions> Questions { get; set; }

        //public DbSet<StudentTest> StudentTests { get; set; }
        public DbSet<GradeClass> GradeClasss { get; set; }
        public DbSet<CourseGradeClass> CourseGradeClasss { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<WritenTest> WritenTests { get; set; }

    }

}
