using System;
using System.Collections.Generic;
using CoursesEvaluationSystem.BL.Models.Base;

namespace CoursesEvaluationSystem.BL.Models
{
    public class EnrolledCourseModel : ModelBase
    {
        virtual public StudentModel Student { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        virtual public CourseModel Course { get; set; }
        public virtual ICollection<AssessmentRatingModel> Assessments { get; set; }
    }
}