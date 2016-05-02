namespace TestVerktygElev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Name = c.String(),
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
                        Name = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Occupations_OccupationID = c.Int(),
                        Tests_TestID = c.Int(),
                        GradeClass_ID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Tests", t => t.Tests_TestID)
                .ForeignKey("dbo.GradeClasses", t => t.GradeClass_ID)
                .ForeignKey("dbo.Occupations", t => t.Occupations_OccupationID)
                .Index(t => t.Occupations_OccupationID)
                .Index(t => t.Tests_TestID)
                .Index(t => t.GradeClass_ID);
            
            CreateTable(
                "dbo.GradeClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GradeClassID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Name = c.String(),
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
                        AppData = c.String(),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.Teachers", t => t.TeacherRefFK, cascadeDelete: true)
                .Index(t => t.TeacherRefFK);
            
            CreateTable(
                "dbo.StudentTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentRefFk = c.Int(nullable: false),
                        TestRefFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.TestRefFk, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentRefFk, cascadeDelete: true)
                .Index(t => t.StudentRefFk)
                .Index(t => t.TestRefFk);
            
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
                        Questions = c.String(),
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
                        Question_QuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.OptionID)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionID)
                .Index(t => t.Question_QuestionID);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionTypeID = c.Int(nullable: false),
                        Option = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropForeignKey("dbo.StudentTests", "StudentRefFk", "dbo.Students");
            DropForeignKey("dbo.Students", "GradeClass_ID", "dbo.GradeClasses");
            DropForeignKey("dbo.CourseGradeClasses", "GradeClassRefID", "dbo.GradeClasses");
            DropForeignKey("dbo.Tests", "TeacherRefFK", "dbo.Teachers");
            DropForeignKey("dbo.TestQuestions", "TestRefFk", "dbo.Tests");
            DropForeignKey("dbo.TestQuestions", "QuestionRefFk", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestTypeRefFK", "dbo.QuestionTypes");
            DropForeignKey("dbo.Options", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.StudentTests", "TestRefFk", "dbo.Tests");
            DropForeignKey("dbo.Students", "Tests_TestID", "dbo.Tests");
            DropForeignKey("dbo.Courses", "TeacherRefFK", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "Subject_SubjectsID", "dbo.Subjects");
            DropForeignKey("dbo.CourseGradeClasses", "CouseRefID", "dbo.Courses");
            DropForeignKey("dbo.Admins", "Occupations_OccupationID", "dbo.Occupations");
            DropIndex("dbo.Options", new[] { "Question_QuestionID" });
            DropIndex("dbo.Questions", new[] { "QuestTypeRefFK" });
            DropIndex("dbo.TestQuestions", new[] { "QuestionRefFk" });
            DropIndex("dbo.TestQuestions", new[] { "TestRefFk" });
            DropIndex("dbo.StudentTests", new[] { "TestRefFk" });
            DropIndex("dbo.StudentTests", new[] { "StudentRefFk" });
            DropIndex("dbo.Tests", new[] { "TeacherRefFK" });
            DropIndex("dbo.Teachers", new[] { "Occupations_OccupationID" });
            DropIndex("dbo.Courses", new[] { "Subject_SubjectsID" });
            DropIndex("dbo.Courses", new[] { "TeacherRefFK" });
            DropIndex("dbo.CourseGradeClasses", new[] { "CouseRefID" });
            DropIndex("dbo.CourseGradeClasses", new[] { "GradeClassRefID" });
            DropIndex("dbo.Students", new[] { "GradeClass_ID" });
            DropIndex("dbo.Students", new[] { "Tests_TestID" });
            DropIndex("dbo.Students", new[] { "Occupations_OccupationID" });
            DropIndex("dbo.Admins", new[] { "Occupations_OccupationID" });
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Options");
            DropTable("dbo.Questions");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.StudentTests");
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
