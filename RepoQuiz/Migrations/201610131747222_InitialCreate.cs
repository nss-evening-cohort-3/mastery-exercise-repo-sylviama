namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FirstNamePicks",
                c => new
                    {
                        FirstNameId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FirstNameId);
            
            CreateTable(
                "dbo.LastNamePicks",
                c => new
                    {
                        LastNameId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LastNameId);
            
            CreateTable(
                "dbo.MajorPicks",
                c => new
                    {
                        MajorId = c.Int(nullable: false, identity: true),
                        MajorName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MajorId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Major = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.MajorPicks");
            DropTable("dbo.LastNamePicks");
            DropTable("dbo.FirstNamePicks");
        }
    }
}
