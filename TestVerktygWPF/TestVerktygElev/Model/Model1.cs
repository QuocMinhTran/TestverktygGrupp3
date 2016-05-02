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
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<CourseGradeClasses> CourseGradeClasses { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<GradeClasses> GradeClasses { get; set; }
        public virtual DbSet<Occupations> Occupations { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionTypes { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentTests> StudentTests { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<TestQuestions> TestQuestions { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<WritenTests> WritenTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasMany(e => e.CourseGradeClasses)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.CouseRefID);

            modelBuilder.Entity<GradeClasses>()
                .HasMany(e => e.CourseGradeClasses)
                .WithRequired(e => e.GradeClasses)
                .HasForeignKey(e => e.GradeClassRefID);

            modelBuilder.Entity<GradeClasses>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.GradeClasses)
                .HasForeignKey(e => e.GradeClass_GradeClassID);

            modelBuilder.Entity<Occupations>()
                .HasMany(e => e.Admins)
                .WithOptional(e => e.Occupations)
                .HasForeignKey(e => e.Occupations_OccupationID);

            modelBuilder.Entity<Occupations>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Occupations)
                .HasForeignKey(e => e.Occupations_OccupationID);

            modelBuilder.Entity<Occupations>()
                .HasMany(e => e.Teachers)
                .WithOptional(e => e.Occupations)
                .HasForeignKey(e => e.Occupations_OccupationID);

            modelBuilder.Entity<Occupations>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.Occupations)
                .HasForeignKey(e => e.QuestionRefFk);

            modelBuilder.Entity<QuestionTypes>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.QuestionTypes)
                .HasForeignKey(e => e.QuestTypeRefFK);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.StudentTests)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.StudentRefFk);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.WritenTests)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.StudentRefFK);

            modelBuilder.Entity<Subjects>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Subjects)
                .HasForeignKey(e => e.Subject_SubjectsID);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Teachers)
                .HasForeignKey(e => e.TeacherRefFK);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.Tests)
                .WithRequired(e => e.Teachers)
                .HasForeignKey(e => e.TeacherRefFK);

            modelBuilder.Entity<Tests>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Tests)
                .HasForeignKey(e => e.Tests_TestID);

            modelBuilder.Entity<Tests>()
                .HasMany(e => e.StudentTests)
                .WithRequired(e => e.Tests)
                .HasForeignKey(e => e.TestRefFk);

            modelBuilder.Entity<Tests>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.Tests)
                .HasForeignKey(e => e.TestRefFk);

            modelBuilder.Entity<Tests>()
                .HasMany(e => e.WritenTests)
                .WithRequired(e => e.Tests)
                .HasForeignKey(e => e.TestRefFK);
        }
    }
}
