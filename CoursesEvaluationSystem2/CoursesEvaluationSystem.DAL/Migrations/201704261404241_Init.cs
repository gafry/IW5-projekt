namespace CoursesEvaluationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssessmentRatingEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Note = c.String(),
                        EnrolledCourseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnrolledCourseEntities", t => t.EnrolledCourseId, cascadeDelete: true)
                .Index(t => t.EnrolledCourseId);
            
            CreateTable(
                "dbo.EnrolledCourseEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseEntities", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.StudentEntities", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Abbreviation = c.String(nullable: false),
                        GuaranteeId = c.Guid(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherEntities", t => t.GuaranteeId, cascadeDelete: true)
                .Index(t => t.GuaranteeId);
            
            CreateTable(
                "dbo.TeacherEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        Room = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        Grade = c.Int(nullable: false),
                        Photo = c.Binary(),
                        Login = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrolledCourseEntities", "StudentId", "dbo.StudentEntities");
            DropForeignKey("dbo.CourseEntities", "GuaranteeId", "dbo.TeacherEntities");
            DropForeignKey("dbo.EnrolledCourseEntities", "CourseId", "dbo.CourseEntities");
            DropForeignKey("dbo.AssessmentRatingEntities", "EnrolledCourseId", "dbo.EnrolledCourseEntities");
            DropIndex("dbo.CourseEntities", new[] { "GuaranteeId" });
            DropIndex("dbo.EnrolledCourseEntities", new[] { "CourseId" });
            DropIndex("dbo.EnrolledCourseEntities", new[] { "StudentId" });
            DropIndex("dbo.AssessmentRatingEntities", new[] { "EnrolledCourseId" });
            DropTable("dbo.StudentEntities");
            DropTable("dbo.TeacherEntities");
            DropTable("dbo.CourseEntities");
            DropTable("dbo.EnrolledCourseEntities");
            DropTable("dbo.AssessmentRatingEntities");
        }
    }
}
