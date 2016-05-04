namespace TestVerktygWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAnswers", "StudentTestFk", "dbo.StudentTests");
            DropIndex("dbo.StudentAnswers", new[] { "StudentTestFk" });
            DropTable("dbo.StudentAnswers");
        }
    }
}
