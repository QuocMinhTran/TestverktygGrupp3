using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
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
        public DbSet<Question> Questions { get; set; }

        public DbSet<StudentTest> StudentTests { get; set; }
        public DbSet<GradeClass> GradeClasss { get; set; }
        public DbSet<CourseGradeClass> CourseGradeClasss { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }

    }

    public class Admin //Done
    {
        public int AdminID { get; set; }
        public string Password { get; set; }
        public Occupation Occupations { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        
    }
    public class Teacher //Done
    {
        public int TeacherID { get; set; }
        public string Password { get; set; }
        public Occupation Occupations { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public Test Tests { get; set; }
        public string UserName { get; set; }
        //public Course Courses { get; set; }


    }
    public class Occupation //Done
    {
        public int OccupationID { get; set; }
        public string Occupations { get; set; }
    }
    public class Student //Done
    {
        public int StudentID { get; set; }
        public string Password { get; set; }
        public Occupation Occupations { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Test Tests { get; set; }
        public string UserName { get; set; }
    }

    public class StudentTest //Done
    {
        public int ID { get; set; }

        [ForeignKey("StudentRefFk")]
        public Student StudentFk { get; set; }
        public int StudentRefFk { get; set; }


        [ForeignKey("TestRefFk")]
        public Test TestFk { get; set; }
        public int TestRefFk { get; set; }

    }

    public class GradeClass //Done
    {
        public int ID { get; set; }

        public int GradeClassID { get; set; }
        public List<Student> Studends { get; set; }
        public string Name { get; set; }

    }
    public class Option //Done
    {
        public int OptionID { get; set; }
        public string SelectivOption { get; set; }
        public bool RightAnswer { get; set; }
    }

    public class TestQuestion //Done
    {
        public int ID { get; set; }

        [ForeignKey("TestRefFk")]
        public Test TestFk { get; set; }
        public int TestRefFk { get; set; }


        [ForeignKey("QuestionRefFk")]
        public Question QuestionFk { get; set; }
        public int QuestionRefFk { get; set; }

    }
    public class Test //Done
    {
        [Key]
        public int TestID { get; set; }
        public string Name { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }

        [ForeignKey("TeacherRefFK")]
        public Teacher TeacherFK { get; set; }
        public int TeacherRefFK { get; set; }


        public string AppData { get; set; }
    }
    public class Question //Done
    {
        public int QuestionID { get; set; }
        public string Questions { get; set; }
        public List<Option> Options { get; set; }

        [ForeignKey("QuestTypeRefFK")]
        public QuestionType QuestionTypeFK { get; set; }
        public int QuestTypeRefFK { get; set; }
    }
    public class QuestionType //Done
    {
        public int ID { get; set; }

        public int QuestionTypeID { get; set; }
        public string Option { get; set; }
    }
    public class CourseGradeClass //Done
    {
        public int ID { get; set; }

        [ForeignKey("GradeClassRefID")]
        public GradeClass GradeClassFK { get; set; }
        public int GradeClassRefID { get; set; }

        [ForeignKey("CouseRefID")]
        public Course CourseFK { get; set; }
        public int CouseRefID { get; set; }


    }
    public class Course //Done
    {
        [Key]
        public int CourseID { get; set; }

        public Subjects Subject { get; set; }

        [ForeignKey("TeacherRefFK")]
        public Teacher TeacherFK { get; set; }
        public int TeacherRefFK { get; set; }
    }
    

    public class Subjects //Done
    {
        public int SubjectsID { get; set; }
        public string Subject { get; set; }
    }

}
