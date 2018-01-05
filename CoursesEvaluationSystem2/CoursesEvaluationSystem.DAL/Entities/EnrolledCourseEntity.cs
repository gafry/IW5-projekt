using CoursesEvaluationSystem.DAL.Entities.Base.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.DAL.Entities
{
    public class EnrolledCourseEntity : EntityBase
    {
        [Required]
        public Guid StudentId { get; set; }
        virtual public StudentEntity Student { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public virtual ICollection<AssessmentRatingEntity> Assessments { get; set; } = new List<AssessmentRatingEntity>();
    }
}
