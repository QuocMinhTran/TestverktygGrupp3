namespace TestVerktygWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbModelUpdate : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Students", t => t.StudentRefFK, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestRefFK, cascadeDelete: true)
                .Index(t => t.StudentRefFK)
                .Index(t => t.TestRefFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WritenTests", "TestRefFK", "dbo.Tests");
            DropForeignKey("dbo.WritenTests", "StudentRefFK", "dbo.Students");
            DropIndex("dbo.WritenTests", new[] { "TestRefFK" });
            DropIndex("dbo.WritenTests", new[] { "StudentRefFK" });
            DropTable("dbo.WritenTests");
        }
    }
}
