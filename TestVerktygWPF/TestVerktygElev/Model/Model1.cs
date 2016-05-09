namespace TestVerktygElev
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }
        public virtual DbSet<StudentClassCourse> StudentClassCourses { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentTest> StudentTests { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTest> UserTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentClassCourses)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.CouseRefID);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Occupation)
                .HasForeignKey(e => e.OccupationFk);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Occupation)
                .HasForeignKey(e => e.OccupationFk);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuestionFk);

            modelBuilder.Entity<StudentClass>()
                .HasMany(e => e.StudentClassCourses)
                .WithRequired(e => e.StudentClass)
                .HasForeignKey(e => e.StudentClassRefID);

            modelBuilder.Entity<StudentClass>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.StudentClass)
                .HasForeignKey(e => e.StudentClassFk);

            modelBuilder.Entity<StudentClass>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.StudentClass)
                .HasForeignKey(e => e.StudentClassFk);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentTests)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentRefFk);

            modelBuilder.Entity<StudentTest>()
                .HasMany(e => e.StudentAnswers)
                .WithRequired(e => e.StudentTest)
                .HasForeignKey(e => e.StudentTestFk);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.TestFk);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.StudentTests)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.TestRefFk);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.UserTests)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.TestFk);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserTests)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserFk);
        }
    }
}
