namespace Home_task_DB_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courseworks",
                c => new
                    {
                        WorkId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        WorkType = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        PresentationDate = c.DateTime(nullable: false),
                        Mark = c.Byte(nullable: false),
                        StudentId = c.Int(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Middlename = c.String(nullable: false),
                        Group = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Middlename = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        Cathedra = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courseworks", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Courseworks", "StudentId", "dbo.Students");
            DropIndex("dbo.Courseworks", new[] { "TeacherId" });
            DropIndex("dbo.Courseworks", new[] { "StudentId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Courseworks");
        }
    }
}
