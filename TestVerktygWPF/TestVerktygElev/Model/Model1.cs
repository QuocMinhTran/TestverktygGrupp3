namespace TestVerktygElev
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CourseGradeClass> CourseGradeClasses { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<GradeClass> GradeClasses { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TestQuestion> TestQuestions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<WritenTest> WritenTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .HasMany(e => e.CourseGradeClasses)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.CouseRefID);

            modelBuilder.Entity<GradeClass>()
                .HasMany(e => e.CourseGradeClasses)
                .WithRequired(e => e.GradeClass)
                .HasForeignKey(e => e.GradeClassRefID);

            modelBuilder.Entity<GradeClass>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.GradeClass)
                .HasForeignKey(e => e.GradeClass_GradeClassID);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Occupation)
                .HasForeignKey(e => e.Occupations_OccupationID);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Occupation)
                .HasForeignKey(e => e.Occupations_OccupationID);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.Teachers)
                .WithOptional(e => e.Occupation)
                .HasForeignKey(e => e.Occupations_OccupationID);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Options)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuestionRefFK);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuestionRefFk);

            modelBuilder.Entity<QuestionType>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.QuestionType)
                .HasForeignKey(e => e.QuestTypeRefFK);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.WritenTests)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentRefFK);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.Subject_SubjectsID);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TeacherRefFK);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Tests)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TeacherRefFK);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.TestRefFk);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.WritenTests)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.TestRefFK);
        }
    }
}
