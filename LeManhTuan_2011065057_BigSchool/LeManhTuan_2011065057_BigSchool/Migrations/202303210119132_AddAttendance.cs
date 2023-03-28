namespace LeManhTuan_2011065057_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attentdances",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attentdances", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attentdances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attentdances", new[] { "AttendeeId" });
            DropIndex("dbo.Attentdances", new[] { "CourseId" });
            DropTable("dbo.Attentdances");
        }
    }
}
