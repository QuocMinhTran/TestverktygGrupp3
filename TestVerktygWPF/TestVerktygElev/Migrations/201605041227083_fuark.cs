namespace TestVerktygElev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        FirstName = c.String(),
                        LasttName = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Occupations_OccupationID = c.Int(),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.Occupations", t => t.Occupations_OccupationID)
                .Index(t => t.Occupations_OccupationID);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        OccupationID = c.Int(nullable: false, identity: true),
                        Occupations = c.String(),
                    })
                .PrimaryKey(t => t.OccupationID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        FirstName = c.String(),
                        LasttName = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Occupations_OccupationID = c.Int(),
                        GradeClass_GradeClassID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.GradeClasses", t => t.GradeClass_GradeClassID)
                .ForeignKey("dbo.Occupations", t => t.Occupations_OccupationID)
                .Index(t => t.Occupations_OccupationID)
                .Index(t => t.GradeClass_GradeClassID);
            
            CreateTable(
                "dbo.GradeClasses",
                c => new
                    {
                        GradeClassID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GradeClassID);
            
            CreateTable(
                "dbo.CourseGradeClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GradeClassRefID = c.Int(nullable: false),
                        CouseRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CouseRefID, cascadeDelete: true)
                .ForeignKey("dbo.GradeClasses", t => t.GradeClassRefID, cascadeDelete: true)
                .Index(t => t.GradeClassRefID)
                .Index(t => t.CouseRefID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        TeacherRefFK = c.Int(nullable: false),
                        Subject_SubjectsID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectsID)
                .ForeignKey("dbo.Teachers", t => t.TeacherRefFK, cascadeDelete: true)
                .Index(t => t.TeacherRefFK)
                .Index(t => t.Subject_SubjectsID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectsID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.SubjectsID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        FirstName = c.String(),
                        LasttName = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Occupations_OccupationID = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherID)
                .ForeignKey("dbo.Occupations", t => t.Occupations_OccupationID)
                .Index(t => t.Occupations_OccupationID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EndDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        TeacherRefFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.Teachers", t => t.TeacherRefFK, cascadeDelete: true)
                .Index(t => t.TeacherRefFK);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TestRefFk = c.Int(nullable: false),
                        QuestionRefFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionRefFk, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestRefFk, cascadeDelete: true)
                .Index(t => t.TestRefFk)
                .Index(t => t.QuestionRefFk);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionsLabel = c.String(),
                        AppData = c.String(),
                        QuestTypeRefFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestTypeRefFK, cascadeDelete: true)
                .Index(t => t.QuestTypeRefFK);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionID = c.Int(nullable: false, identity: true),
                        SelectivOption = c.String(),
                        RightAnswer = c.Boolean(nullable: false),
                        QuestionRefFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionID)
                .ForeignKey("dbo.Questions", t => t.QuestionRefFK, cascadeDelete: true)
                .Index(t => t.QuestionRefFK);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QuestionTypeID = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                    })
                .PrimaryKey(t => t.QuestionTypeID);
            
            CreateTable(
                "dbo.WritenTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        IsTestDone = c.Boolean(nullable: false),
                        WritenTime = c.Int(nullable: false),
                        StudentRefFK = c.Int(nullable: false),
                        TestRefFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.TestRefFK, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentRefFK, cascadeDelete: true)
                .Index(t => t.StudentRefFK)
                .Index(t => t.TestRefFK);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Occupations_OccupationID", "dbo.Occupations");
            DropForeignKey("dbo.Students", "Occupations_OccupationID", "dbo.Occupations");
            DropForeignKey("dbo.WritenTests", "StudentRefFK", "dbo.Students");
            DropForeignKey("dbo.Students", "GradeClass_GradeClassID", "dbo.GradeClasses");
            DropForeignKey("dbo.CourseGradeClasses", "GradeClassRefID", "dbo.GradeClasses");
            DropForeignKey("dbo.Tests", "TeacherRefFK", "dbo.Teachers");
            DropForeignKey("dbo.WritenTests", "TestRefFK", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "TestRefFk", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "QuestionRefFk", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestTypeRefFK", "dbo.QuestionTypes");
            DropForeignKey("dbo.Options", "QuestionRefFK", "dbo.Questions");
            DropForeignKey("dbo.Courses", "TeacherRefFK", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "Subject_SubjectsID", "dbo.Subjects");
            DropForeignKey("dbo.CourseGradeClasses", "CouseRefID", "dbo.Courses");
            DropForeignKey("dbo.Admins", "Occupations_OccupationID", "dbo.Occupations");
            DropIndex("dbo.WritenTests", new[] { "TestRefFK" });
            DropIndex("dbo.WritenTests", new[] { "StudentRefFK" });
            DropIndex("dbo.Options", new[] { "QuestionRefFK" });
            DropIndex("dbo.Questions", new[] { "QuestTypeRefFK" });
            DropIndex("dbo.TestQuestions", new[] { "QuestionRefFk" });
            DropIndex("dbo.TestQuestions", new[] { "TestRefFk" });
            DropIndex("dbo.Tests", new[] { "TeacherRefFK" });
            DropIndex("dbo.Teachers", new[] { "Occupations_OccupationID" });
            DropIndex("dbo.Courses", new[] { "Subject_SubjectsID" });
            DropIndex("dbo.Courses", new[] { "TeacherRefFK" });
            DropIndex("dbo.CourseGradeClasses", new[] { "CouseRefID" });
            DropIndex("dbo.CourseGradeClasses", new[] { "GradeClassRefID" });
            DropIndex("dbo.Students", new[] { "GradeClass_GradeClassID" });
            DropIndex("dbo.Students", new[] { "Occupations_OccupationID" });
            DropIndex("dbo.Admins", new[] { "Occupations_OccupationID" });
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.WritenTests");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Options");
            DropTable("dbo.Questions");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.Tests");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseGradeClasses");
            DropTable("dbo.GradeClasses");
            DropTable("dbo.Students");
            DropTable("dbo.Occupations");
            DropTable("dbo.Admins");
        }
    }
}
