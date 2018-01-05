using System;
using CoursesEvaluationSystem.BL.Models.Base;
using CoursesEvaluationSystem.DAL.Entities;

namespace CoursesEvaluationSystem.BL.Models
{
    public class AssessmentRatingModel : ModelBase
    {
        public AssessmentType Type { get; set; }
        public int Points { get; set; }
        public string Note { get; set; }
        public Guid EnrolledCourseId { get; set; }
        public virtual EnrolledCourseModel EnrolledCourse { get; set; }
    }
}