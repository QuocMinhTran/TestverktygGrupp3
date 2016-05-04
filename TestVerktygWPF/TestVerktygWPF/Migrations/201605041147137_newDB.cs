namespace TestVerktygWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        RightAnswer = c.Boolean(nullable: false),
                        QuestionFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionFk, cascadeDelete: true)
                .Index(t => t.QuestionFk);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        QuestionType = c.String(),
                        AppData = c.String(),
                        TestFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.TestFk, cascadeDelete: true)
                .Index(t => t.TestFk);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EndDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        TimeStampe = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Occupations = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.Int(nullable: false),
                        Question = c.Int(nullable: false),
                        OrderPostition = c.Int(),
                        StudentTestFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentTests", t => t.StudentTestFk, cascadeDelete: true)
                .Index(t => t.StudentTestFk);
            
            CreateTable(
                "dbo.StudentTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        IsTestDone = c.Boolean(nullable: false),
                        WritenTime = c.Int(nullable: false),
                        StudentRefFk = c.Int(nullable: false),
                        TestRefFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentRefFk, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestRefFk, cascadeDelete: true)
                .Index(t => t.StudentRefFk)
                .Index(t => t.TestRefFk);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        StudentClassFk = c.Int(nullable: false),
                        OccupationFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Occupations", t => t.OccupationFk, cascadeDelete: true)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassFk, cascadeDelete: true)
                .Index(t => t.StudentClassFk)
                .Index(t => t.OccupationFk);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentClassCourses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentClassRefID = c.Int(nullable: false),
                        CouseRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CouseRefID, cascadeDelete: true)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassRefID, cascadeDelete: true)
                .Index(t => t.StudentClassRefID)
                .Index(t => t.CouseRefID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        StudentClassFk = c.Int(nullable: false),
                        OccupationFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Occupations", t => t.OccupationFk, cascadeDelete: true)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassFk, cascadeDelete: true)
                .Index(t => t.StudentClassFk)
                .Index(t => t.OccupationFk);
            
            CreateTable(
                "dbo.UserTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserFk = c.Int(nullable: false),
                        TestFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tests", t => t.TestFk, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserFk, cascadeDelete: true)
                .Index(t => t.UserFk)
                .Index(t => t.TestFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTests", "UserFk", "dbo.Users");
            DropForeignKey("dbo.UserTests", "TestFk", "dbo.Tests");
            DropForeignKey("dbo.Users", "StudentClassFk", "dbo.StudentClasses");
            DropForeignKey("dbo.Users", "OccupationFk", "dbo.Occupations");
            DropForeignKey("dbo.StudentClassCourses", "StudentClassRefID", "dbo.StudentClasses");
            DropForeignKey("dbo.StudentClassCourses", "CouseRefID", "dbo.Courses");
            DropForeignKey("dbo.StudentAnswers", "StudentTestFk", "dbo.StudentTests");
            DropForeignKey("dbo.StudentTests", "TestRefFk", "dbo.Tests");
            DropForeignKey("dbo.StudentTests", "StudentRefFk", "dbo.Students");
            DropForeignKey("dbo.Students", "StudentClassFk", "dbo.StudentClasses");
            DropForeignKey("dbo.Students", "OccupationFk", "dbo.Occupations");
            DropForeignKey("dbo.Answers", "QuestionFk", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TestFk", "dbo.Tests");
            DropIndex("dbo.UserTests", new[] { "TestFk" });
            DropIndex("dbo.UserTests", new[] { "UserFk" });
            DropIndex("dbo.Users", new[] { "OccupationFk" });
            DropIndex("dbo.Users", new[] { "StudentClassFk" });
            DropIndex("dbo.StudentClassCourses", new[] { "CouseRefID" });
            DropIndex("dbo.StudentClassCourses", new[] { "StudentClassRefID" });
            DropIndex("dbo.Students", new[] { "OccupationFk" });
            DropIndex("dbo.Students", new[] { "StudentClassFk" });
            DropIndex("dbo.StudentTests", new[] { "TestRefFk" });
            DropIndex("dbo.StudentTests", new[] { "StudentRefFk" });
            DropIndex("dbo.StudentAnswers", new[] { "StudentTestFk" });
            DropIndex("dbo.Questions", new[] { "TestFk" });
            DropIndex("dbo.Answers", new[] { "QuestionFk" });
            DropTable("dbo.UserTests");
            DropTable("dbo.Users");
            DropTable("dbo.StudentClassCourses");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Students");
            DropTable("dbo.StudentTests");
            DropTable("dbo.StudentAnswers");
            DropTable("dbo.Occupations");
            DropTable("dbo.Courses");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
