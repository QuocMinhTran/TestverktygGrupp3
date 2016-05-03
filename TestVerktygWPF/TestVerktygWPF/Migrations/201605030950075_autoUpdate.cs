namespace TestVerktygWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autoUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "Questions_QuestionID", c => c.Int());
            CreateIndex("dbo.Options", "Questions_QuestionID");
            AddForeignKey("dbo.Options", "Questions_QuestionID", "dbo.Questions", "QuestionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "Questions_QuestionID", "dbo.Questions");
            DropIndex("dbo.Options", new[] { "Questions_QuestionID" });
            DropColumn("dbo.Options", "Questions_QuestionID");
        }
    }
}
