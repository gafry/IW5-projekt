using CoursesEvaluationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.DAL
{
    public class CourseEvaluationContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<AssessmentRatingEntity> AssessmentRatings { get; set; }
        public DbSet<EnrolledCourseEntity> EnrolledCourses { get; set; }
    }
}
